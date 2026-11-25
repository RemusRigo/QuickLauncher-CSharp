//-------------------------------------------------------------------------------------------------
// QuickLauncher - A system tray application to quickly launch various shell folders and commands.
//    (C) 2026 Remus Rigo
//       v1.0.20261125
//-------------------------------------------------------------------------------------------------

namespace QuickLauncher.Modules
{
   internal static class SysTrayMain
   {
	  // one QuickLauncher per user session ("Local\": other users logged in at the same time can run their own)
	  private const string SingleInstanceName = @"QuickLauncher-CSharp-SingleInstance";

	  [STAThread]
	  static void Main()
	  {
		 using var mutex = new System.Threading.Mutex(true, SingleInstanceName, out bool createdNew);
		 if (!createdNew)
		 {
			MessageBox.Show("QuickLauncher is already running: look for its icon in the system tray.", "QuickLauncher", MessageBoxButtons.OK, MessageBoxIcon.Information);
			return;
		 }

		 Application.EnableVisualStyles();
		 Application.SetCompatibleTextRenderingDefault(false);
		 Application.Run(new SysTray());
		 // the mutex stays owned until here (end of the using), so a second copy can't start while this one runs
	  }
   }
}