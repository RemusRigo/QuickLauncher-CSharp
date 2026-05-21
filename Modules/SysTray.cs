//-------------------------------------------------------------------------------------------------
// QuickLauncher - A system tray application to quickly launch various shell folders and commands.
//    (C) 2026 Remus Rigo
//       v1.0.20260319
//-------------------------------------------------------------------------------------------------

using QuickLauncher.Wnd;
using System;
using System.Windows.Forms;

public class SysTray : ApplicationContext
{
   private NotifyIcon tray = new NotifyIcon();
   private ContextMenuStrip mnuLeft = new ContextMenuStrip();
   private ContextMenuStrip mnuRight = new ContextMenuStrip();

   public SysTray()
   {
	  InitializeTray();
   }

   private void InitializeTray()
   {
	  //-------------------------------------------------------------------------------------------
	  // build left click menu
	  mnuLeft = new ContextMenuStrip();
	  mnuLeft.Items.Add("Rebuild missing folders", null, (s, e) => AppRebuild());
	  mnuLeft.Items.Add(new ToolStripSeparator());
	  mnuLeft.Items.Add("About", null, (s, e) => AppAbout()); 
	  mnuLeft.Items.Add("Exit", null, (s, e) => ExitThread());

	  //-------------------------------------------------------------------------------------------
	  // build right click menu
	  mnuRight = new ContextMenuStrip();
	  var mnuShellCommands = new ToolStripMenuItem("Shell: commands");
	  var dicShellCommandsCategorized = new Dictionary<string, Dictionary<string, string>>
	  {
	     ["Current User"] = new Dictionary<string, string>
		 {
		    ["Profile"] = "Shell:Profile",
			["3D Objects"] = "Shell:3D Objects",
			["Contacts"] = "Shell:Contacts",
			["Desktop"] = "Shell:Desktop",
			["Downloads"] = "Shell:Downloads",
			["Favorites"] = "Shell:Favorites",
			["Games"] = "Shell:Games",
			["Links"] = "Shell:Links",
			["Music"] = "Shell:My Music",
			["Playlists"] = "Shell:Playlists",
			["Personal"] = "Shell:Personal",
			["Pictures"] = "Shell:My Pictures",
			["Camera Roll"] = "Shell:Camera Roll",
			["Photo Albums"] = "Shell:PhotoAlbums",
			["Screenshots"] = "Shell:Screenshots",
			["Videos"] = "Shell:My Video",
			["Original Images"] = "Shell:Original Images",
			["Recycle Bin Folder"] = "Shell:RecycleBinFolder",
			["Ringtones"] = "Shell:Ringtones",
			["Saved Games"] = "Shell:SavedGames",
			["Searches"] = "Shell:Searches",
			["SendTo"] = "Shell:SendTo",
			["Libraries"] = "Shell:Libraries",
			["Documents Library"] = "Shell:DocumentsLibrary",
			["Music Library"] = "Shell:MusicLibrary",
			["Pictures Library"] = "Shell:PicturesLibrary",
			["Videos Library"] = "Shell:VideosLibrary",
			["Users Libraries Folder"] = "Shell:UsersLibrariesFolder",
			["User Pinned"] = "Shell:User Pinned",
			["User Profiles"] = "Shell:UserProfiles",
			["User ProgramFiles"] = "Shell:UserProgramFiles",
			["User ProgramFiles Common"] = "Shell:UserProgramFilesCommon",
			["User Tiles"] = "Shell:UserTiles",
            ["Users Files Folder"] = "Shell:UsersFilesFolder"
		 },
		 ["Current User AppData"] = new Dictionary<string, string>
		 {
		    ["AppData"] = "Shell:AppData",
			["Local AppData"] = "Shell:Local AppData",
			["Local AppData Low"] = "Shell:LocalAppDataLow",
			["Account Pictures"] = "Shell:AccountPictures",
			["Application Shortcuts"] = "Shell:Application Shortcuts",
			["Cache"] = "Shell:Cache",
			["CD Burning"] = "Shell:CD Burning",
			["Cookies"] = "Shell:Cookies",
			["Cookies\\Low"] = "Shell:Cookies\\Low",
			["Credential Manager"] = "Shell:CredentialManager",
			["Cryptokeys"] = "Shell:Cryptokeys",
			["Dp API Keys"] = "Shell:DpAPIKeys",
			["History"] = "Shell:History",
			["Gadgets (Win 7)"] = "Shell:Gadgets", // Windows 7 only
			["GameTasks"] = "Shell:GameTasks",
			["Implicit App Shortcuts"] = "Shell:ImplicitAppShortcuts",
			["Quick Launch"] = "Shell:Quick Launch",
			["PrintHood"] = "Shell:PrintHood",
			["Recent"] = "Shell:Recent",
			["Start Menu"] = "Shell:Start Menu",
			["Startup"] = "Shell:Startup",
			["System Certificates"] = "Shell:SystemCertificates",
			["Templates"] = "Shell:Templates"
		 },
		 ["Public"] = new Dictionary<string, string>
		 { 
		    ["Common Desktop"] = "Shell:Common Desktop",
			["Common Documents"] = "Shell:Common Documents",
			["Common Downloads"] = "Shell:CommonDownloads",
			["Common Music"] = "Shell:CommonMusic",
			["Common Pictures"] = "Shell:CommonPictures",
			["Common Video"] = "Shell:CommonVideo",
			["Common Start Menu"] = "Shell:Common Start Menu",
			["Common Startup"] = "Shell:Common Startup",
			["Public"] = "Shell:Public",
			["Public Account Pictures"] = "Shell:PublicAccountPictures",
			["Public Libraries"] = "Shell:PublicLibraries",
			["Public User Tiles"] = "Shell:PublicUserTiles"
		 },
		 ["Control Panel"] = new Dictionary<string, string>
		 { 
		    ["Control Panel Folder"] = "Shell:ControlPanelFolder",
		    ["Add New Programs Folder"] = "Shell:AddNewProgramsFolder",
		    ["Administrative Tools"] = "Shell:Administrative Tools",
		    ["Apps Folder"] = "Shell:AppsFolder",
		    ["Change Remove Programs Folder"] = "Shell:ChangeRemoveProgramsFolder",
		    ["Connections Folder"] = "Shell:ConnectionsFolder",
		    ["NetHood"] = "Shell:NetHood",
		    ["Printers Folder"] = "Shell:PrintersFolder",
		    ["SyncCenter Folder"] = "Shell:SyncCenterFolder",
		    ["SyncCenter Results Folder"] = "Shell:SyncResultsFolder",
		    ["SyncCenter Setup Folder"] = "Shell:SyncSetupFolder",
		    ["SyncCenter Conflict Folder"] = "Shell:ConflictFolder",
		    ["SyncCenter CSC (Client Side Caching) Folder"] = "Shell:CSCFolder",
		    ["Windows"] = "Shell:Windows"
		 },
		 ["Settings"] = new Dictionary<string, string>
		 { 
		    ["App Updates Folder"] = "Shell:AppUpdatesFolder"
		 },
		 ["Windows"] = new Dictionary<string, string>
		 { 
		    ["Fonts"] = "Shell:Fonts",
		    ["My Computer Folder"] = "Shell:MyComputerFolder",
		    ["Network Places Folder"] = "Shell:NetworkPlacesFolder",
		    ["Resource Dir"] = "Shell:ResourceDir",
		    ["System (System32)"] = "Shell:System",
		    ["System X86 (SysWOW64)"] = "Shell:SystemX86",
		    ["Windows"] = "Shell:Windows"
		 },
		 ["Program Files"] = new Dictionary<string, string>
		 { 
		    ["ProgramFiles"] = "Shell:ProgramFiles",
		    ["ProgramFiles Common"] = "Shell:ProgramFilesCommon",
		    ["ProgramFiles CommonX64"] = "Shell:ProgramFilesCommonX64",
		    ["ProgramFiles CommonX86"] = "Shell:ProgramFilesCommonX86",
		    ["ProgramFiles X64"] = "Shell:ProgramFilesX64",
		    ["ProgramFiles X86"] = "Shell:ProgramFilesX86",
		    ["Programs"] = "Shell:Programs",
		    ["Default Gadgets (Win Vista/7/8)"] = "Shell:Default Gadgets" // Windows Vista, Windows 7, and Windows 8		
		 },
		 ["ProgramData"] = new Dictionary<string, string>
		 { 
		    ["Common AppData"] = "Shell:Common AppData",
		    ["Common Administrative Tools"] = "Shell:Common Administrative Tools",
		    ["Common Programs"] = "Shell:Common Programs",
		    ["Common Ringtones"] = "Shell:CommonRingtones",
		    ["Common Templates"] = "Shell:Common Templates",
		    ["Device Metadata Store"] = "Shell:Device Metadata Store",
		    ["OEM Links"] = "Shell:OEM Links",
		    ["Public Game Tasks"] = "Shell:PublicGameTasks"
		 },
		 ["OneDrive"] = new Dictionary<string, string>
		 { 
		    ["OneDrive"] = "Shell:OneDrive",
		    ["OneDrive CameraRoll"] = "Shell:OneDriveCameraRoll",
		    ["OneDrive Documents"] = "Shell:OneDriveDocuments",
		    ["OneDrive Music"] = "Shell:neDriveMusic",
		    ["OneDrive Pictures"] = "Shell:OneDrivePictures",
		    ["SkyDrive CameraRoll "] = "Shell:SkyDriveCameraRoll",
		    ["SkyDrive Documents "] = "Shell:SkyDriveDocuments",
		    ["SkyDrive Music "] = "Shell:SkyDriveMusic",
		    ["SkyDrive Pictures "] = "Shell:SkyDrivePictures"
		 }		 
	  };

	  var dicShellCommandsUncategorized = new Dictionary<string, string>
	  {
		 ["HomeGroup Current User Folder"] = "Shell:HomeGroupCurrentUserFolder",
		 ["HomeGroup Folder"] = "Shell:HomeGroupFolder",
		 ["Internet Folder"] = "Shell:InternetFolder", // deprecated
		 ["Localized Resources Dir"] = "Shell:LocalizedResourcesDir",
		 ["MAPI Folder "] = "Shell:MAPIFolder",
		 ["Recorded TV Library"] = "Shell:RecordedTVLibrary",
		 ["Retail Demo"] = "Shell:Retail Demo",
		 ["Roamed Tile Images"] = "Shell:Roamed Tile Images",
		 ["Roaming Tiles"] = "Shell:Roaming Tiles",
		 ["Sample Music"] = "Shell:SampleMusic",
		 ["Sample Pictures"] = "Shell:SamplePictures",
		 ["Sample Videos"] = "Shell:SampleVideos",
		 ["Search History Folder"] = "Shell:SearchHistoryFolder",
		 ["Search Home Folder"] = "Shell:SearchHomeFolder",
		 ["Search Templates Folder"] = "Shell:SearchTemplatesFolder",
		 ["Start Menu All Programs"] = "Shell:StartMenuAllPrograms",
		 ["This PC Desktop Folder"] = "Shell:ThisPCDesktopFolder"
	  };

	  // Add categorized shell commands to menu
	  foreach (var category in dicShellCommandsCategorized)
	  {
		 var categoryItem = new ToolStripMenuItem(category.Key);
		 foreach (var entry in category.Value)
		 {
			string displayName = entry.Key;
			string shellCommand = entry.Value;
			var item = new ToolStripMenuItem(displayName);
			item.Click += (s, e) => LaunchShellCommands(shellCommand);
			categoryItem.DropDownItems.Add(item);
		 }
		 mnuShellCommands.DropDownItems.Add(categoryItem);
	  }

	  // Add uncategorized shell commands to menu
	  foreach (var entry in dicShellCommandsUncategorized)
	  {
		 var item = new ToolStripMenuItem(entry.Key);
		 string localShell = entry.Value;
		 item.Click += (s, e) => LaunchShellCommands(localShell);
		 mnuShellCommands.DropDownItems.Add(item);
	  }

	  mnuRight.Items.Add(mnuShellCommands);
	  mnuRight.Items.Add(new ToolStripSeparator());
	  mnuRight.Items.Add("Exit", null, (s, e) => ExitThread());

	  //-------------------------------------------------------------------------------------------
	  // Create tray icon
	  tray = new NotifyIcon();
	  tray.Icon = QuickLauncher.Res.Resources.terminal;
	  tray.Visible = true; 
	  tray.Text = "Quick Launcher";

	  tray.MouseClick += Tray_MouseClick;
	  tray.MouseDown += Tray_MouseClick;
	  tray.MouseUp += Tray_MouseClick;
   }

   private void Tray_MouseClick(object? sender, MouseEventArgs e)
   {
	  var mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

	  if (e.Button == MouseButtons.Left)
	  {
		 tray.ContextMenuStrip = mnuLeft;
		 mi?.Invoke(tray, null);
	  }
	  else if (e.Button == MouseButtons.Right)
	  {
		 tray.ContextMenuStrip = mnuRight;
		 mi?.Invoke(tray, null);
	  }
   }

   private void LaunchShellCommands(string cmd)
   {
	  try
	  {
		 System.Diagnostics.Process.Start("explorer.exe", cmd);
	  }
	  catch { }
   }

   private void AppRebuild()
   {
	   try
	   {
			System.IO.Directory.CreateDirectory(Environment.ExpandEnvironmentVariables("%UserProfile%\\3D Objects"));
			System.IO.Directory.CreateDirectory(Environment.ExpandEnvironmentVariables("%UserProfile%\\Contacts"));
			System.IO.Directory.CreateDirectory(Environment.ExpandEnvironmentVariables("%UserProfile%\\Music\\Playlists"));
			System.IO.Directory.CreateDirectory(Environment.ExpandEnvironmentVariables("%UserProfile%\\Pictures\\Camera Roll"));
			System.IO.Directory.CreateDirectory(Environment.ExpandEnvironmentVariables("%UserProfile%\\Pictures\\Slide Shows"));
			System.IO.Directory.CreateDirectory(Environment.ExpandEnvironmentVariables("%LocalAppData%\\Microsoft\\Windows\\Burn\\Burn"));
			System.IO.Directory.CreateDirectory(Environment.ExpandEnvironmentVariables("%LocalAppData%\\Microsoft\\Windows Photo Gallery\\Original Images"));
			System.IO.Directory.CreateDirectory(Environment.ExpandEnvironmentVariables("%ProgramFiles%\\Windows Sidebar\\Gadgets"));
			System.IO.Directory.CreateDirectory(Environment.ExpandEnvironmentVariables("%ProgramData%\\OEM Links"));
	   }
	   catch
		{
		}
   }

   private void AppAbout()
   {
      using (frmAbout frm = new frmAbout())
      {
         frm.ShowInTaskbar = false;
         frm.ShowDialog();
         //  Dispose() is called automatically when exiting the using block, even if an exception occurs
      }
   }

   protected override void ExitThreadCore()
   {
	  tray.Visible = false;
	  tray.Dispose();
	  base.ExitThreadCore();
   }
}
