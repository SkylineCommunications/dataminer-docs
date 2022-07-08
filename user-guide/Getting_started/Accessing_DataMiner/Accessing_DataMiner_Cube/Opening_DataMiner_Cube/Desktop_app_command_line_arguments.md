---
uid: Desktop_app_command_line_arguments
---

# Desktop application command-line arguments

When you start the DataMiner Cube desktop application, the latest Cube binary files are downloaded to your client PC (`%localappdata%\Skyline\DataMiner\DataMinerCube\`) and executed.

Several command line arguments can be specified when starting the application. For a list, see below. In normal circumstances, none of these are required. They will be added automatically where applicable. However, in a number of special cases, it might be necessary to use them, either once or permanently (e.g. in a shortcut).

> [!NOTE]
> All arguments and options are case-insensitive.

## Overview

### /Alias=Xyz

Displays a custom alias ("Xyz") instead of the cluster name in the Cube header. Must be combined with the `/Host=hostname` argument. The alias will be used as long as the client is connected with the specified host.

Available from DataMiner 10.0.13 onwards.

### /Autorun

Starts the DataMiner Cube desktop application in the system tray. The application will only close when you close it explicitly via the context menu of the system tray icon.

Available from DataMiner 10.1.0/10.0.9 onwards.

### /Bootstrap

Combines the `/Install` and `/Silent` arguments and also copies a number of files, such as *DataMinerCube.exe.config* en *CubeLauncherConfig.json*.

Available from DataMiner 10.2.0/10.1.9 onwards.

### /Display

Opens the DataMiner Cube start window.

Available from DataMiner 10.1.0/10.0.9 onwards.

### /Hostname=xyz

Adds the DataMiner System with hostname "xyz" to the list of DataMiner Systems (if it has not been added yet).

Available from DataMiner 10.1.0/10.0.9 onwards.

### /Install

Checks if DataMiner Cube is installed. If not, the installation wizard is opened.

Available from DataMiner 10.1.0/10.0.13 onwards.

### /Install /Silent

Checks if DataMiner Cube is installed. If not, it is installed with the default options. Exits afterwards.

Available from DataMiner 10.1.0/10.0.13 onwards.

### /InstallOptions

Can be combined with `/Install` or `/Install /Silent` to modify the installation options.

Available from DataMiner 10.0.13 onwards.

Supported options:

- *DesktopShortcut*
- *NoDesktopShortcut*
- *StartMenuShortcut*
- *NoStartMenuShortcut*
- *StartOnLogin* (Starts DataMiner Cube in the system tray after login.)
- *NoStartOnLogin*
- *OpenAfterInstall* (Opens the start window after installation.)
- *NoOpenAfterInstall* (Default for silent installs.)

For example, the following command can be used to silently check the DataMiner Cube installation and start the installation if necessary (for example, in a logon script to automatically install DataMiner Cube from a network share for all users).

```txt
PathToCubeExe.exe /Install /Silent /InstallOptions:StartOnLogin
```

### /Launch

Opens DataMiner Cube and immediately connects to the DataMiner System specified in the `/Hostname` argument.

If no hostname argument was used, DataMiner Cube will connect to the DataMiner System that was last added to the list of DataMiner Systems.

Available from DataMiner 10.1.0/10.0.9 onwards.

### /Modify

Opens a window that allows you to modify the installation.

Available from DataMiner 10.1.0/10.0.9 onwards.

### /Modify /Silent

Allows the installation to be modified without any user interaction. Must be combined with `/ModifyOptions` to specify the modifications.

Available from DataMiner 10.1.0/10.0.13 onwards.

### /ModifyOptions

Can be combined with `/Modify` to preselect modifications in the modify UI, or with `/Modify /Silent` to specify the desired modifications.

Available from DataMiner 10.1.0/10.0.13 onwards.

Supported options:

- *ClearProtocolCache*
- *ClearVisioCache*
- *ClearVersionCache* (Removes all cached versions.)
- *RemoveVersion:versionnumber* (Removes a specific cached version. Can be used multiple times)

To combine multiple options, use a comma as separator.

For example, this is a silent command to modify the DataMiner Cube installation (clearing the protocol cache, clearing the Visio cache and removing two cached versions):

```txt
PathToCubeExe.exe /Modify /Silent /ModifyOptions:ClearProtocolCache,ClearVisioCache,RemoveVersion:9.5.1638.4080,RemoveVersion:10.0.2042.1636
```

### /NoInstall

Runs the DataMiner Cube desktop application without checking whether anything needs to be installed or upgraded.

Available from DataMiner 10.1.0/10.0.9 onwards.

### /NoSelfUpdate

Runs the currently installed version of the DataMiner Cube desktop application. If a newer version exists, no automatic upgrade will be performed.

Available from DataMiner 10.1.0/10.0.9 onwards.

### /Position=x,y

Opens the DataMiner Cube desktop application at position "x,y" of the current working area.

Available from DataMiner 10.1.0/10.0.9 onwards.

### /UnInstall

Uninstalls the DataMiner Cube desktop application.

Available from DataMiner 10.1.0/10.0.9 onwards.

### /UnInstall /Silent

Uninstalls the DataMiner Cube desktop application in silent mode (without UI).

Available from DataMiner 10.1.0/10.0.9 onwards.

### /Update

Combines `/UpdateClients` and `/UpdateLauncher`.

Available from DataMiner 10.1.0/10.0.9 onwards.

### /UpdateClients

Updates the Cube versions of all the DataMiner Systems to which you have connected in the last 100 days.

Available from DataMiner 10.1.0/10.0.9 onwards.

### /UpdateLauncher

Checks for newer versions of the DataMiner Cube desktop application on the 10 DataMiner Systems to which you connected last. If a newer version is found, the application will be automatically upgraded.

Available from DataMiner 10.1.0/10.0.9 onwards.

> [!NOTE]
> If there is internet access, <https://dataminer.services> will be checked as well.
