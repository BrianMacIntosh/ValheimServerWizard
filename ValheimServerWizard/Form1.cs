using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValheimServerWizard
{
	public partial class Form1 : Form
	{
		private Process m_serverProcess;

		private Task m_restartTask;

		//TODO: dispose me?
		private FileSystemWatcher m_worldsWatcher;

		public Form1()
		{
			InitializeComponent();

			playersListBox.Items.Clear();

			// collect worlds and start watcher
			CollectWorlds();
			m_worldsWatcher = new FileSystemWatcher();
			m_worldsWatcher.Created += HandleWorldCreated;
			m_worldsWatcher.Renamed += HandleWorldRenamed;
			m_worldsWatcher.Deleted += HandleWorldDeleted;

			LoadConfiguration();
		}

		private void HandleWorldCreated(object sender, FileSystemEventArgs e)
		{
			CollectWorlds();
		}

		private void HandleWorldRenamed(object sender, RenamedEventArgs e)
		{
			CollectWorlds();
		}

		private void HandleWorldDeleted(object sender, FileSystemEventArgs e)
		{
			CollectWorlds();
		}

		private void CollectWorlds()
		{
			object prevSelected = worldsListBox.SelectedItem;
			worldsListBox.Items.Clear();
			string worldsDirectory = WizardHelpers.GetWorldsDirectory();
			if (Directory.Exists(worldsDirectory))
			{
				foreach (string file in Directory.GetFiles(worldsDirectory, "*.fwl"))
				{
					worldsListBox.Items.Add(Path.GetFileNameWithoutExtension(file));
				}
			}
			worldsListBox.SelectedItem = prevSelected;
		}

		private void ServerStart()
		{
			if (IsServerProcessRunning)
			{
				return;
			}

			if (!ValidateArguments())
			{
				return;
			}

			string exePath = WizardHelpers.GetServerPath();

			if (string.IsNullOrEmpty(exePath))
			{
				MessageBox.Show("'valheim_server.exe' could not be found. It must be installed using Steam.", "Hosting Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string argsFormat = "-nographics -batchmode -name \"{0}\" -port {1} -world \"{2}\" -password \"{3}\" -public {4}";

			logTextBox.Text = "";

			m_serverProcess = new Process();
			m_serverProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			m_serverProcess.StartInfo.UseShellExecute = false;
			m_serverProcess.StartInfo.FileName = exePath;
			m_serverProcess.StartInfo.Arguments = string.Format(argsFormat,
				serverNameTextBox.Text, portNumeric.Value, worldsListBox.Text, passwordBox.Text, publicCheckBox.Checked ? "1" : "0");
			m_serverProcess.StartInfo.EnvironmentVariables.Add("SteamAppId", "892970");
			m_serverProcess.StartInfo.RedirectStandardOutput = true;
			m_serverProcess.StartInfo.RedirectStandardError = true;
			m_serverProcess.StartInfo.RedirectStandardInput = true;
			m_serverProcess.OutputDataReceived += HandleOutputDataReceived;
			m_serverProcess.ErrorDataReceived += HandleErrorDataReceived;
			m_serverProcess.Exited += HandleServerExit;
			m_serverProcess.EnableRaisingEvents = true;
			if (m_serverProcess.Start())
			{
				onlineLabel.Text = "STARTING";
				onlineLabel.ForeColor = Color.Orange;

				m_serverProcess.BeginOutputReadLine();
			}
			else
			{
				m_serverProcess = null;
			}

			RefreshStateButtons();
		}

		private bool ValidateArguments()
		{
			if (worldsListBox.SelectedItem == null)
			{
				MessageBox.Show("No world is selected.", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			if (serverNameTextBox.Text.Length <= 0)
			{
				MessageBox.Show("Server name cannot be empty.", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			if (serverNameTextBox.Text == passwordBox.Text)
			{
				MessageBox.Show("Password cannot be the same as the server name.", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			
			if (passwordBox.Text.Length < 5)
			{
				MessageBox.Show("Password must be at least 5 characters.", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			return true;
		}

		private void HandleOutputDataReceived(object sender, DataReceivedEventArgs e)
		{
			if (logTextBox.InvokeRequired)
			{
				logTextBox.Invoke(new DataReceivedEventHandler(HandleOutputDataReceived), sender, e);
				return;
			}

			if (!string.IsNullOrWhiteSpace(e.Data)
				&& e.Data != @"(Filename: C:\buildslave\unity\build\Runtime/Export/Debug/Debug.bindings.h Line: 35)")
			{
				logTextBox.AppendText(e.Data + "\r\n");

				if (e.Data.EndsWith("Game server connected"))
				{
					onlineLabel.Text = "ONLINE";
					onlineLabel.ForeColor = Color.Green;
				}

				int handshakeIndex = e.Data.IndexOf("Got handshake from client ");
				if (handshakeIndex >= 0)
				{
					string steamId = e.Data.Substring(handshakeIndex + "Got handshake from client ".Length);
					playersListBox.Items.Add(steamId);
					RefreshConnectedPlayersCount();
				}

				int closingIndex = e.Data.IndexOf("Closing socket ");
				if (closingIndex >= 0)
				{
					string steamId = e.Data.Substring(closingIndex + "Closing socket ".Length);
					playersListBox.Items.Remove(steamId);
					RefreshConnectedPlayersCount();
				}
			}
		}

		private void HandleErrorDataReceived(object sender, DataReceivedEventArgs e)
		{
			if (logTextBox.InvokeRequired)
			{
				logTextBox.Invoke(new DataReceivedEventHandler(HandleErrorDataReceived), sender, e);
				return;
			}

			if (!string.IsNullOrEmpty(e.Data)
				&& e.Data != @"(Filename: C:\buildslave\unity\build\Runtime/Export/Debug/Debug.bindings.h Line: 35)")
			{
				logTextBox.AppendText(e.Data + "\n");
			}
		}

		private void RefreshConnectedPlayersCount()
		{
			playerCountLabel.Text = playersListBox.Items.Count.ToString() + "/10";
		}

		private void ServerSendExit()
		{
			if (IsServerProcessRunning)
			{
				onlineLabel.Text = "STOPPING";
				onlineLabel.ForeColor = Color.Orange;

				m_serverProcess.CloseMainWindow();
			}
		}

		private async Task ServerRestart()
		{
			ServerSendExit();
			await Task.Run(() => m_serverProcess.WaitForExit());
			ServerStart();

			//TODO: fixme
			RefreshStateButtons();
		}

		private void HandleServerExit(object sender, EventArgs e)
		{
			if (InvokeRequired)
			{
				Invoke(new EventHandler(HandleServerExit), sender, e);
			}
			else
			{
				onlineLabel.Text = "STOPPED";
				onlineLabel.ForeColor = Color.Red;

				playersListBox.Items.Clear();

				RefreshStateButtons();
			}
		}

		private bool IsServerProcessRunning
		{
			get { return m_serverProcess != null && !m_serverProcess.HasExited; }
		}

		private bool IsRestartTaskRunning
		{
			get { return m_restartTask != null && !m_restartTask.IsCompleted; }
		}

		private void RefreshStateButtons()
		{
			startServerButton.Enabled = !IsServerProcessRunning && !IsRestartTaskRunning;
			stopButton.Enabled = IsServerProcessRunning && !IsRestartTaskRunning;
			restartButton.Enabled = IsServerProcessRunning && !IsRestartTaskRunning;
		}

		private string ConfigFileDirectory => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ValheimServerWizard");

		private string ConfigFilePath => Path.Combine(ConfigFileDirectory, "config.txt");

		private bool m_readingConfig = false;

		private void SaveConfiguration()
		{
			if (m_readingConfig)
			{
				return;
			}

			if (!Directory.Exists(ConfigFileDirectory))
			{
				Directory.CreateDirectory(ConfigFileDirectory);
			}

			using (StreamWriter writer = new StreamWriter(
				new FileStream(ConfigFilePath, FileMode.Create, FileAccess.Write), Encoding.UTF8))
			{
				writer.WriteLine(worldsListBox.SelectedItem != null ? worldsListBox.SelectedItem : "");
				writer.WriteLine(serverNameTextBox.Text);
				writer.WriteLine(portNumeric.Value);
				writer.WriteLine(passwordBox.Text);
				writer.WriteLine(publicCheckBox.Checked);
			}
		}

		private void LoadConfiguration()
		{
			try
			{
				if (File.Exists(ConfigFilePath))
				{
					using (StreamReader reader = new StreamReader(
						new FileStream(ConfigFilePath, FileMode.Open, FileAccess.Read), Encoding.UTF8))
					{
						m_readingConfig = true;
						worldsListBox.SelectedItem = reader.ReadLine();
						serverNameTextBox.Text = reader.ReadLine();
						portNumeric.Value = int.Parse(reader.ReadLine());
						passwordBox.Text = reader.ReadLine();
						publicCheckBox.Checked = bool.Parse(reader.ReadLine());
					}
				}
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				m_readingConfig = false;
			}
		}

		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (IsServerProcessRunning)
			{
				ServerSendExit();
				//m_serverProcess.WaitForExit();
			}
			Application.Exit();
		}

		private void startServerButton_Click(object sender, EventArgs e)
		{
			ServerStart();
		}

		private void stopButton_Click(object sender, EventArgs e)
		{
			ServerSendExit();
		}

		private void restartButton_Click(object sender, EventArgs e)
		{
			if (!IsRestartTaskRunning)
			{
				m_restartTask = ServerRestart();

				RefreshStateButtons();
			}
		}

		private void viewProfileButtom_Click(object sender, EventArgs e)
		{
			if (playersListBox.SelectedItem != null)
			{
				Process.Start("https://steamcommunity.com/profiles/" + playersListBox.SelectedItem);
			}
		}

		private void portNumeric_ValueChanged(object sender, EventArgs e)
		{
			maxPortNumeric.Value = portNumeric.Value + 1;

			//OPT: a bit aggressive?
			SaveConfiguration();
		}

		private void serverNameTextBox_Leave(object sender, EventArgs e)
		{
			SaveConfiguration();
		}

		private void worldsListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			SaveConfiguration();
		}

		private void passwordBox_Leave(object sender, EventArgs e)
		{
			SaveConfiguration();
		}

		private void publicCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SaveConfiguration();
		}

		private void showPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			passwordBox.UseSystemPasswordChar = !showPasswordCheckBox.Checked;
		}

		private void playersListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			viewProfileButton.Enabled = playersListBox.SelectedItem != null;
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (IsServerProcessRunning)
			{
				ServerSendExit();
				//m_serverProcess.WaitForExit();
			}
		}
	}
}
