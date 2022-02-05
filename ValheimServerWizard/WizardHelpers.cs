using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace ValheimServerWizard
{
	public static class WizardHelpers
	{
		/// <summary>
		/// The full path to the server EXE.
		/// </summary>
		private static string s_serverPath;

		/// <summary>
		/// Returns all the Steam library folders on this computer.
		/// </summary>
		public static IEnumerable<string> FindSteamLibraryFolders()
		{
			// try to find the Steam folder
			foreach (string drive in Directory.GetLogicalDrives())
			{
				string testSteamappsPath;
				string testFoldersFile;

				testSteamappsPath = Path.Combine(drive, @"Program Files\Steam\steamapps");
				if (Directory.Exists(testSteamappsPath))
				{
					yield return testSteamappsPath;

					testFoldersFile = Path.Combine(testSteamappsPath, "libraryfolders.vdf");
					if (File.Exists(testFoldersFile))
					{
						foreach (string externalLibrary in ReadLibraryFolders(testFoldersFile))
						{
							yield return externalLibrary;
						}
					}
				}

				testSteamappsPath = Path.Combine(drive, @"Program Files (x86)\Steam\steamapps");
				if (Directory.Exists(testSteamappsPath))
				{
					yield return testSteamappsPath;

					testFoldersFile = Path.Combine(testSteamappsPath, "libraryfolders.vdf");
					if (File.Exists(testFoldersFile))
					{
						foreach (string externalLibrary in ReadLibraryFolders(testFoldersFile))
						{
							yield return externalLibrary;
						}
					}
				}
			}
		}

		/// <summary>
		/// Returns all the external Steam library folders identified in the specified file.
		/// </summary>
		public static IEnumerable<string> ReadLibraryFolders(string sourceFile)
		{
			Regex lineRegex = new Regex("^\\s*\"path\"\\s*\"(.+)\"$");

			using (StreamReader reader = new StreamReader(new FileStream(sourceFile, FileMode.Open, FileAccess.Read), Encoding.UTF8))
			{
				while (!reader.EndOfStream)
				{
					string line = reader.ReadLine().Trim();
					Match match = lineRegex.Match(line);
					if (match.Success)
					{
						//HACK: it's not really a regex
						yield return Path.Combine(Regex.Unescape(match.Groups[1].Value), "steamapps");
					}
				}
			}
		}

		/// <summary>
		/// Returns the full path to the server EXE.
		/// </summary>
		public static string GetServerPath()
		{
			if (string.IsNullOrEmpty(s_serverPath))
			{
				foreach (string library in FindSteamLibraryFolders())
				{
					string testPath = Path.Combine(library, @"common\Valheim dedicated server\valheim_server.exe");
					if (File.Exists(testPath))
					{
						s_serverPath = testPath;
						break;
					}
				}
			}
			return s_serverPath;
		}

		/// <summary>
		/// Returns the full path to the worlds directory.
		/// </summary>
		public static string GetWorldsDirectory()
		{
			return Path.Combine(GetValheimAppDataDirectory(), "worlds");
		}

		/// <summary>
		/// Returns the full path to the Valheim app data directory.
		/// </summary>
		public static string GetValheimAppDataDirectory()
		{
			Guid localLowId = new Guid("A520A1A4-1780-4FF6-BD18-167343C5AF16");
			return Path.Combine(GetKnownFolderPath(localLowId), "IronGate", "Valheim");
		}

		//https://stackoverflow.com/questions/4494290/detect-the-location-of-appdata-locallow
		private static string GetKnownFolderPath(Guid knownFolderId)
		{
			IntPtr pszPath = IntPtr.Zero;
			try
			{
				int hr = SHGetKnownFolderPath(knownFolderId, 0, IntPtr.Zero, out pszPath);
				if (hr >= 0)
					return Marshal.PtrToStringAuto(pszPath);
				throw Marshal.GetExceptionForHR(hr);
			}
			finally
			{
				if (pszPath != IntPtr.Zero)
					Marshal.FreeCoTaskMem(pszPath);
			}
		}

		[DllImport("shell32.dll")]
		static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken, out IntPtr pszPath);
	}
}
