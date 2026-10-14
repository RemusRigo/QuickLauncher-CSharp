# QuickLauncher: User's Guide



## Downloads & Runtimes

Download the latest release from the [Releases page](https://github.com/RemusRigo/QuickLauncher-CSharp/releases).

|Folder|Target Framework|Architecture|Required Runtime|
|-|-|-|-|
|`net10.0-windows`|.NET 10.0|Any CPU|[.NET 10.0 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/10.0)|

> The plain ".NET Runtime" is not enough; QuickLauncher needs the **Desktop** Runtime.
> To check which runtimes are installed, run `dotnet --list-runtimes` and look for a `Microsoft.WindowsDesktop.App 10.x` line.



## Install

QuickLauncher is portable: there is no installer.

1. Download and extract the release to a permanent folder, for example `D:\My Apps\QuickLauncher\`.
2. Double-click `QuickLauncher.exe`. A terminal icon appears in the system tray.
3. Optional: to start it with Windows, press **Win+R**, type `shell:startup`, and put a shortcut to `QuickLauncher.exe` in that folder.

> If Windows blocks the file ("Windows protected your PC"), right-click `QuickLauncher.exe` →
> **Properties** → check **Unblock** → **OK**, then try again.



## Right-click menu: Shell commands

Right-click the tray icon → **Shell: commands**, choose a category, then a folder. It opens in File Explorer.

Categories: Current User, Current User AppData, Public, Control Panel, Settings, Windows, Program Files, ProgramData, OneDrive.

Each item runs `explorer.exe shell:<name>`; you can type the same command in **Win+R**.
Some folders exist only on some Windows versions; those don't open.



## Left-click menu

|Menu|Description|
|-|-|
|**Rebuild missing folders**|Create standard folders that are often deleted: `3D Objects`, `Contacts`, `Music\Playlists`, `Pictures\Camera Roll`, `Pictures\Slide Shows`, and a few system folders (needs administrator rights for `Program Files` and `ProgramData`)|
|**About**|Version information|
|**Exit**|Close QuickLauncher|



## Uninstall

1. Click the tray icon → **Exit**.
2. Delete the shortcut from `shell:startup` (if you created one) and the QuickLauncher folder.
