//-------------------------------------------------------------------------------------------------
// QuickLauncher - A system tray application to quickly launch various shell folders and commands.
//    (C) 2026 Remus Rigo
//       v1.0.20260319
//-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuickLauncher.Wnd
{
   public partial class frmAbout : Form
   {
      public frmAbout()
      {
         InitializeComponent();
      }

      private void frmAbout_Load(object sender, EventArgs e)
      {
         lnkLblGitHub.Links.Add(0, lnkLblGitHub.Text.Length, "https://github.com/RemusRigo/");
      }

      private void lnkLblGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         Process.Start(new ProcessStartInfo("https://github.com/RemusRigo/") { UseShellExecute = true });
      }

      private void imgPayPal_Click(object sender, EventArgs e)
      {
         Process.Start(new ProcessStartInfo("https://paypal.me/remusrigo") { UseShellExecute = true });
      }

      private void imgRevolut_Click(object sender, EventArgs e)
      {
         Process.Start(new ProcessStartInfo("https://revolut.me/remusrigo") { UseShellExecute = true });
      }

   }
}
