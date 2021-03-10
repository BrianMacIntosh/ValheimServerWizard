using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ValheimServerWizard
{
	public static class WizardHelpers
	{
		/// <summary>
		/// The full path to the server EXE.
		/// </summary>
		private static string s_serverPath;

		/// <summary>
		/// Returns the full path to the server EXE.
		/// </summary>
		public static string GetServerPath()
		{
			if (string.IsNullOrEmpty(s_serverPath))
			{
				// try to find the EXE
				foreach (string drive in Directory.GetLogicalDrives())
				{
					string testPath = Path.Combine(drive, @"SteamLibrary\steamapps\common\Valheim dedicated server\valheim_server.exe");
					if (File.Exists(testPath))
					{
						s_serverPath = testPath;
						break;
					}

					testPath = Path.Combine(drive, @"Program Files (x86)\Steam\steamapps\common\valheim_server.exe");
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
			Guid localLowId = new Guid("A520A1A4-1780-4FF6-BD18-167343C5AF16");
			return Path.Combine(GetKnownFolderPath(localLowId), "IronGate", "Valheim", "worlds");
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
