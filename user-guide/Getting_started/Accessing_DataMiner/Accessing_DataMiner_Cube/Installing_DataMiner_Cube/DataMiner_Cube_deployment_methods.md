---
uid: DataMiner_Cube_deployment_methods
---

# DataMiner Cube deployment methods

## Overview

Below you can find an overview of the different methods that can be used to deploy the DataMiner Cube desktop application. This information is primarily aimed at system administrators.

|                          | Bitness   | Automatic updates | Side-by-side version support | -9.6 | 10.0           | 10.1+          |
|--------------------------|-----------|-------------------|------------------------------|------|----------------|----------------|
| ClickOnce XBAP           | x86       | Yes [(2)](#fn_2)  | Yes                          | X    | X              | X [(4)](#fn_4) |
| ClickOnce StandAlone     | AnyCPU    | Yes [(2)](#fn_2)  | No                           | X    |                |                |	 	 
| MSI StandAlone           | AnyCPU    | No                | No                           | X    | X              |                |
| Launcher [(1)](#fn_1)    | AnyCPU    | Yes [(3)](#fn_3)  | Yes                          |      | X [(5)](#fn_5) | X              |
| MSI Launcher (bootstrap) | x64       | Yes [(3)](#fn_3)  | Yes                          |      |                | X [(6)](#fn_6) |
| MSI Launcher (shared)    | x64       | No                | Yes                          |      |                | X [(7)](#fn_7) |
| MSI CefSharp v81         | x86 + x64 | No                | Yes                          |      |                | X [(6)](#fn_6) |

<a id="fn_1"></a>(1) “Launcher” is an alternative name for the [DataMiner Cube start window](xref:Opening_DataMiner_Cube).<br>
<a id="fn_2"></a>(2) Updates from DMA only.<br>
<a id="fn_3"></a>(3) Updates from DMA and DataMiner Cloud Platform (see [DataMiner Cube Start Window updates](https://community.dataminer.services/documentation/dataminer-cube-launcher-updates/)).<br>
<a id="fn_4"></a>(4) XBAP will eventually be phased out (due to Internet Explorer [end of life](https://docs.microsoft.com/en-us/lifecycle/announcements/internet-explorer-11-end-of-support) and known issues).<br>
<a id="fn_5"></a>(5) Introduced in 10.0.9.<br>
<a id="fn_6"></a>(6) Introduced in 10.1.9.<br>
<a id="fn_7"></a>(7) Expected to be introduced in 10.2.

## Launcher installation

- Individual users can obtain the launcher either from a local DMA or from <https://dataminer.services/>.

    When the launcher is downloaded from a local DMA, that DMA will automatically be added to the start window when you first start up.

- Launcher installation uses the same approach as the [Microsoft Teams Desktop Installer](https://docs.microsoft.com/en-us/microsoftteams/get-clients).

- The application runs from `%LocalAppData%\Skyline\DataMiner\DataMinerCube`. It installs and updates automatically.

- Installation does not require administrator rights.

## Bootstrap MSI installation

- The bootstrap MSI installation package can be obtained from <https://community.dataminer.services/download/dataminer-cube-msi-bootstrap/>.

- Bootstrap MSI installation uses the same approach as the [Microsoft Teams Machine-Wide Installer](https://docs.microsoft.com/en-us/microsoftteams/msi-deployment#how-the-microsoft-teams-msi-package-works).

- The launcher automatically gets installed for each individual user the next time they sign in on that machine. This avoids the need for each individual user to download and install the launcher.

- It is possible to provide a default configuration for all users by preparing a `CubeLauncherConfig.json` file and placing it in the folder where the bootstrapper is installed.<br>Default installation folder: `C:\Program Files\Skyline Communications\DataMiner Cube\`

## Shared MSI installation

- Classic MSI deployment.

- The launcher and a specific Cube version get installed in a shared location.<br>Default location: `C:\Program Files\Skyline Communications\DataMiner Cube\`

- Recommended when users have no permission to download or execute new applications.

- Only a single executable needs to be allowed on the Windows Firewall.

- Multiple versions can be installed side by side.

- No support for automatic updates.

## CefSharp MSI

- Can be combined with any of the Cube deployment methods.

- Avoids the need for each individual user to download the CefSharp web browser plugin from a DMA.

- Deployment is in a fixed location: `C:\ProgramData\Skyline\DataMiner\DataMinerCube\CefSharp\`

- Windows 8, 8.1 and 2012 R2 require Microsoft Visual C++ Runtime 2015 to be installed separately. For more information, see [the latest supported Visual C++ downloads](https://support.microsoft.com/en-us/topic/the-latest-supported-visual-c-downloads-2647da03-1eea-4433-9aff-95f26a218cc0).

## General remarks

- All MSI packages require administrator rights for installation.

- All MSI packages require a 64-bit operating system.

- The launcher is backwards compatible and can be used to deploy any 9.x or 10.x Cube version. Shared MSI installation packages can be provided on demand for older versions.

- All packages support using the INSTALLDIR parameter to customize the target folder (default folder: `%ProgramFiles\Skyline Communications\DataMiner Cube`).

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






