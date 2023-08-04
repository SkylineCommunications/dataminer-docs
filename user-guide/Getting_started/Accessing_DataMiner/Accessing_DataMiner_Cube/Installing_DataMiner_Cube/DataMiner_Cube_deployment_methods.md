---
uid: DataMiner_Cube_deployment_methods
---

# DataMiner Cube deployment methods

## Overview

Below you can find an overview of the different methods that can be used to deploy the DataMiner Cube desktop application.

> [!IMPORTANT]
> This information is primarily aimed at system administrators.

|                          | Bitness   | Automatic updates | Side-by-side version support | -9.6 | 10.0           | 10.1+          |
|--------------------------|-----------|-------------------|------------------------------|------|----------------|----------------|
| ClickOnce XBAP           | x86       | Yes [(2)](#fn_2)  | Yes                          | X    | X              | X [(4)](#fn_4) |
| ClickOnce StandAlone     | AnyCPU    | Yes [(2)](#fn_2)  | No                           | X    |                |                |	 	 
| MSI StandAlone           | AnyCPU    | No                | No                           | X    | X              |                |
| Launcher [(1)](#fn_1)    | AnyCPU    | Yes [(3)](#fn_3)  | Yes                          |      | X [(5)](#fn_5) | X              |
| MSI Launcher (bootstrap) | x64       | Yes [(3)](#fn_3)  | Yes                          |      |                | X [(6)](#fn_6) |
| MSI Launcher (shared)    | x64       | No                | Yes                          |      |                | X [(7)](#fn_7) |
| MSI CefSharp             | x86 + x64 | No                | Yes                          |      |                | X [(6)](#fn_6) |

<a id="fn_1"></a>(1) “Launcher” is an alternative name for the [DataMiner Cube start window](xref:Opening_the_desktop_app).<br>
<a id="fn_2"></a>(2) Updates from DMA only.<br>
<a id="fn_3"></a>(3) Updates from DMA and dataminer.services (see [Managing the start window of the desktop app](xref:Managing_the_start_window)).<br>
<a id="fn_4"></a>(4) XBAP will be phased out (due to Internet Explorer [end of life](https://docs.microsoft.com/en-us/lifecycle/announcements/internet-explorer-11-end-of-support) and known issues).<br>
<a id="fn_5"></a>(5) Introduced in 10.0.9.<br>
<a id="fn_6"></a>(6) Introduced in 10.1.9.<br>
<a id="fn_7"></a>(7) Introduced in 10.2.0

## Launcher installation

- Individual users can obtain the launcher either from a local DMA or from <https://dataminer.services/>.

  When the launcher is downloaded from a local DMA, that DMA will automatically be added to the start window when you first start up.

- Launcher installation uses the same approach as the [Microsoft Teams Desktop Installer](https://docs.microsoft.com/en-us/microsoftteams/get-clients).

- The application runs from `%LocalAppData%\Skyline\DataMiner\DataMinerCube`. It installs and updates automatically.

- Installation does not require administrator rights.

- To install the Cube desktop app, you need Modify access to the folders `%AppData%\Skyline` and `%LocalAppData%\Skyline`, as well as write access to the key `HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall`.

- To be able to run the app, you need Execute access for the files *DataMinerCube.exe* in the folder `%LocalAppData%\Skyline\DataMiner\DataMinerCube\` and *CefSharp.BrowserSubprocess.exe* in the folder `%LocalAppData%\Skyline\DataMiner\DataMinerCube\CefSharp\version\architecture\`.

- To create a desktop shortcut, you need Modify access to the folder `%UserProfile%\Desktop`.

- To create a start menu shortcut, you need Modify access to the folder `%AppData%\Microsoft\Windows\Start Menu\Programs`.

- The *Start with Windows* feature requires write access to the key `HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run`.

- The eventing communication mode will only be available if the firewall allows the application `*%LocalAppData%\Skyline\DataMiner\DataMinerCube\DataMinerCube.exe` to accept incoming connections.

## Bootstrap MSI installation

- The bootstrap MSI installation package can be obtained from <https://community.dataminer.services/download/dataminer-cube-msi-bootstrap/>.

- Bootstrap MSI installation uses the same approach as the [Microsoft Teams Machine-Wide Installer](https://docs.microsoft.com/en-us/microsoftteams/msi-deployment#how-the-microsoft-teams-msi-package-works).

- The launcher automatically gets installed for each individual user the next time they sign in on that machine. This avoids the need for each individual user to download and install the launcher.

- It is possible to provide a default configuration for all users by preparing a `CubeLauncherConfig.json` file and placing it in the folder where the bootstrapper is installed.

  Default installation folder: `C:\Program Files\Skyline Communications\DataMiner Cube\`

## Shared MSI installation

- Classic DataMiner Cube MSI installation with side-by-side version support.

- Package located on the local DMA: `C:\Skyline DataMiner\Webpages\Tools\Installs\DataMiner Cube.msi`

- The launcher and a specific Cube version get installed in a shared location.

  Default location: `C:\Program Files\Skyline Communications\DataMiner Cube\`

- Recommended when users have no permission to download or execute new applications.

- Only a single executable needs to be allowed on the Windows Firewall.

- No support for automatic updates.

- The `CubeVersion.msi` packages contain the following optional features (which are not exposed in the UI wizard):

  - *MainFeature*: CubeLauncher + one Cube version (mandatory).
  - *Autorun*: Adds a registry key to show the CubeLauncher icon in the notification area (i.e. "systray") at logon for all users.

    - If enabled, users cannot disable the autorun feature.
    - If not enabled, each user can choose to enable the autorun feature.

  - *ProtocolHandler*: Adds a registry key to support the `cube://` protocol handler for all users.

  Example showing how to select individual features:

  ```txt
  msiexec /i CubeVersion-10.2.1.msi ADDLOCAL=MainFeature,Autorun,ProtocolHandler
  ```

  Example showing how to select all features:

  ```txt
  msiexec /i CubeVersion-10.2.1.msi ADDLOCAL=ALL
  ```

  Installing multiple `CubeVersion.msi` packages side-by-side will keep the latest version of DataMinerCube.exe (i.e. the launcher) in place:

  - Installing an older version after a newer version will not overwrite the launcher.
  - Uninstalling the newest version will not roll back the launcher to the previously installed version.

  > [!CAUTION]
  > Uninstalling the last installed version (regardless of whether this is a newer or older version) will remove the desktop and start menu shortcuts. To restore these shortcuts, repair one of the other installed versions by running a command like the following one: `msiexec /fs CubeVersion-10.2.1.msi`

## CefSharp MSI

- Whatever Cube deployment method you use, you can install the CefSharp web browser plugin using one of the following packages.

  - Use [CefSharp v81](https://community.dataminer.services/download/dataminer-cube-msi-cefsharp-v81/) to installs CefSharp v81 on clients where you installed DataMiner Cube v10.2.2 using the Cube MSI installer.
  - Use [CefSharp v96](https://community.dataminer.services/download/dataminer-cube-msi-cefsharp-v96/) to install CefSharp v96 on clients where you installed DataMiner Cube v10.2.0 or v10.2.3 and above using the Cube MSI installer.

- Installing the CefSharp web browser plugin is mandatory when you opted for the shared MSI deployment.

- Installing the CefSharp web browser plugin avoids the need for each individual user to download the CefSharp web browser plugin from a DMA.

- Windows 8, 8.1 and 2012 R2 require Microsoft Visual C++ Runtime 2015 to be installed separately.

  For more information, see [the latest supported Visual C++ downloads](https://support.microsoft.com/en-us/topic/the-latest-supported-visual-c-downloads-2647da03-1eea-4433-9aff-95f26a218cc0).

## General remarks

- All MSI packages require administrator rights for installation.

- All MSI packages require a 64-bit operating system.

- The launcher is backwards compatible and can be used to deploy any 9.x or 10.x Cube version. Shared MSI installation packages can be provided on demand for older versions.

- All packages support using the INSTALLDIR parameter to customize the target folder.

  Default folder: `%ProgramFiles%\Skyline Communications\DataMiner Cube`

  Examples:

  ```txt
  msiexec /i CubeVersion-10.2.1.msi INSTALLDIR="C:\DataMinerCube\"

  msiexec.exe /q /i bootstrap.msi INSTALLDIR="C:\DataMinerCube\"
  ```

  For more information on msiexec command line arguments, see:

  - <https://docs.microsoft.com/en-us/windows-server/administration/windows-commands/msiexec>
  - <https://docs.microsoft.com/en-us/windows/win32/msi/command-line-options>

  > [!NOTE]
  > If a previous version of the application is already installed, newer versions will be installed alongside it and the INSTALLDIR parameter will be ignored.

- To allow seamless use of `cube://` hyperlinks in web browsers, the following group policies can be configured (examples for [Microsoft Edge](https://docs.microsoft.com/en-us/deployedge/microsoft-edge-policies#urlallowlist), but similar for [Google Chrome](https://chromeenterprise.google/policies/?policy=URLAllowlist)):

  - Allow from any source:

    ```txt
    [HKEY_CURRENT_USER\Software\Policies\Microsoft\Edge\URLAllowlist]
    "1"="cube://*"
    ```

  - Allow from specific trusted sources:

    ```txt
    [HKEY_CURRENT_USER\Software\Policies\Microsoft\Edge] "AutoLaunchProtocolsFromOrigins"="[{\"allowed_origins\":[\"http://intranet/\"],\"protocol\":\"cube\"}]"
    ```
