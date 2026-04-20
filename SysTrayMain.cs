//-------------------------------------------------------------------------------------------------
// QuickLauncher - A system tray application to quickly launch various shell folders and commands.
//    (C) 2026 Remus Rigo
//       v1.0.20260319
//-------------------------------------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace QuickLauncher
{
   internal static class SysTrayMain
   {
	  [STAThread]
	  static void Main()
	  {

		 Application.EnableVisualStyles();
		 Application.SetCompatibleTextRenderingDefault(false);
		 Application.Run(new SysTray());
	  }
   }
}