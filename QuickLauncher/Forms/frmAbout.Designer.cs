//-------------------------------------------------------------------------------------------------
// QuickLauncher - A system tray application to quickly launch various shell folders and commands.
//    (C) 2026 Remus Rigo
//       v1.0.20260319
//-------------------------------------------------------------------------------------------------

namespace QuickLauncher.Wnd
{
   partial class frmAbout
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
         lblTitle = new Label();
         lblVer = new Label();
         lnkLblGitHub = new LinkLabel();
         imgPayPal = new PictureBox();
         imgRevolut = new PictureBox();
         ((System.ComponentModel.ISupportInitialize)imgPayPal).BeginInit();
         ((System.ComponentModel.ISupportInitialize)imgRevolut).BeginInit();
         SuspendLayout();
         // 
         // lblTitle
         // 
         lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
         lblTitle.Font = new Font("Verdana", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
         lblTitle.Location = new Point(2, 0);
         lblTitle.Name = "lblTitle";
         lblTitle.Size = new Size(326, 56);
         lblTitle.TabIndex = 0;
         lblTitle.Text = "QuickLauncher";
         lblTitle.TextAlign = ContentAlignment.MiddleCenter;
         // 
         // lblVer
         // 
         lblVer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
         lblVer.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
         lblVer.Location = new Point(2, 56);
         lblVer.Name = "lblVer";
         lblVer.Size = new Size(326, 25);
         lblVer.TabIndex = 1;
         lblVer.Text = "v1.0.20260319";
         lblVer.TextAlign = ContentAlignment.MiddleCenter;
         // 
         // lnkLblGitHub
         // 
         lnkLblGitHub.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
         lnkLblGitHub.Location = new Point(2, 82);
         lnkLblGitHub.Name = "lnkLblGitHub";
         lnkLblGitHub.Size = new Size(322, 36);
         lnkLblGitHub.TabIndex = 2;
         lnkLblGitHub.TabStop = true;
         lnkLblGitHub.Text = "© 2026 Remus Rigo";
         lnkLblGitHub.TextAlign = ContentAlignment.MiddleCenter;
         lnkLblGitHub.LinkClicked += lnkLblGitHub_LinkClicked;
         // 
         // imgPayPal
         // 
         imgPayPal.Image = (Image)resources.GetObject("imgPayPal.Image");
         imgPayPal.Location = new Point(2, 130);
         imgPayPal.Name = "imgPayPal";
         imgPayPal.Size = new Size(64, 64);
         imgPayPal.TabIndex = 3;
         imgPayPal.TabStop = false;
         imgPayPal.Click += imgPayPal_Click;
         // 
         // imgRevolut
         // 
         imgRevolut.Image = (Image)resources.GetObject("imgRevolut.Image");
         imgRevolut.Location = new Point(258, 130);
         imgRevolut.Name = "imgRevolut";
         imgRevolut.Size = new Size(64, 64);
         imgRevolut.TabIndex = 4;
         imgRevolut.TabStop = false;
         imgRevolut.Click += imgRevolut_Click;
         // 
         // frmAbout
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         ClientSize = new Size(329, 201);
         Controls.Add(imgRevolut);
         Controls.Add(imgPayPal);
         Controls.Add(lnkLblGitHub);
         Controls.Add(lblVer);
         Controls.Add(lblTitle);
         Name = "frmAbout";
         StartPosition = FormStartPosition.CenterScreen;
         Text = "frmAbout";
         Load += frmAbout_Load;
         ((System.ComponentModel.ISupportInitialize)imgPayPal).EndInit();
         ((System.ComponentModel.ISupportInitialize)imgRevolut).EndInit();
         ResumeLayout(false);
      }

      #endregion

      private Label lblTitle;
      private Label lblVer;
      private LinkLabel lnkLblGitHub;
      private PictureBox imgPayPal;
      private PictureBox imgRevolut;
   }
}