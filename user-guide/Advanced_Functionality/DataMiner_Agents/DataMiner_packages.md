---
uid: DataMiner_packages
---

# DataMiner packages

A DataMiner package is an archive file that contains all the files necessary to make a modification to a DataMiner System, for example to upgrade, downgrade or restore a DataMiner Agent, or to install a DataMiner app or DataMiner protocol.

It is possible to modify a DataMiner package by changing the packet extension to .zip. You can then access the files within the package as you would with a regular zip file. However, be careful when modifying the files within a DataMiner package, as this may cause it to function incorrectly.

The following types of DataMiner packages are available:

- [Upgrade package (.dmupgrade)](#upgrade-package-dmupgrade)
- [Update package (.dmupdate)](#update-package-dmupdate)
- [Backup package (.dmbackup)](#backup-package-dmbackup)
- [Application package (.dmapp)](#application-package-dmapp)
- [Protocol package (.dmprotocol)](#protocol-package-dmprotocol)
- [Import package (.dmimport)](#import-package-dmimport)

## Upgrade package (.dmupgrade)

Package containing all files necessary to upgrade a DataMiner Agent to a newer version.

- This type of file is published on dataminer.services by Skyline’s Quality Assurance Department.

- File extension: *.dmupgrade*

> [!NOTE]
>
> - The maximum upload size of upgrade packages is limited depending on the DataMiner version, but it is possible to increase this limit. See [Increasing the maximum upload size for upgrade packages in a DMS](xref:SLNetClientTest_increasing_max_upload).
> - The name of each DataMiner upgrade package contains a version and build number for easy identification. For example, a package named "DataMiner 10.4.9.0-14794 Full Upgrade.dmupgrade" contains DataMiner version 10.4.9.0 with build ID 14794.

### Contents of an upgrade package

A DataMiner upgrade package contains the following files:

- Description.txt

- Update.zip

- SLUpgrade.dll and SLUpgrade64.dll

#### Description.txt

A text file containing the description of the package.

For example:

```txt
DataMiner Upgrade (Full)
```

#### Update.zip

A zip file containing:

- A number of folders containing data to be placed in *C:\\Skyline DataMiner* or one of its subfolders.

- Three text files:

  | File name         | Contents                                             |
  |-------------------|------------------------------------------------------|
  | FilesToDelete.txt | The list of files to delete.                         |
  | FilesToLeave.txt  | The list of files to keep.                           |
  | UpdateContent.txt | The actions to perform during the upgrade operation. |

In both *FilesToDelete.txt* and *FilesToLeave.txt*, each line refers to a file (or a collection of files) by means of an absolute path.

Example:

```txt
...
c:\skyline dataminer\logging\*.txt
c:\skyline dataminer\tools\TableDef.txt
...
```

For more information on *UpdateContent.txt*, see [Actions that can be performed during an upgrade operation](#actions-that-can-be-performed-during-an-upgrade-operation).

It is also possible that a file named *StartUpActions.txt* is placed in the folder *Upgrades/StartUpActions* in *Update.zip*. This file can contain commands similar to those in the *UpdateContent.txt* file.

#### SLUpgrade.dll and SLUpgrade64.dll

The DLL file that executes the upgrade operation.

Loads *Update.zip*.

### Steps taken during an upgrade operation

When you start an upgrade operation, the following will happen:

1. The package is extracted in *C:\\Skyline DataMiner\\Upgrades\\Packages\\[name of the upgrade]*.

1. A log file *progress.log* is created in the folder *C:\\Skyline DataMiner\\Upgrades\\Packages\\\[name of the upgrade\]*.

1. The existence of the different required components is checked.

1. All actions defined in *UpdateContent.txt* are performed one by one. See [Actions that can be performed during an upgrade operation](#actions-that-can-be-performed-during-an-upgrade-operation).

### Actions that can be performed during an upgrade operation

In the *UpdateContent.txt* file, a list of actions is defined that have to be performed during an upgrade operation. There can also be a file named *StartUpActions.txt* in the upgrade package, which can contain similar commands. In that case, *UpdateContent.txt* must contain an "Update Upgrades" command to unpack the *StartUpActions.txt* file to the correct Skyline DataMiner directory.

#### UpdateContent.txt

##### Action overview

- **SLEEP \[x\]**: Sleep for x seconds:

  ```txt
  SLEEP 1
  ```

- **Lock**: Lock the service manager.

- **Unlock**: Unlock the service manager.

- **Disable**: Disable and stop the DataMiner services (except SLWatchdog).

- **Enable**: Enable the DataMiner services. Also set the "Automatic startup" flags and descriptions.

- **Update \[x\]**: Replace the files in subfolder "x" of *C:\\Skyline DataMiner* by the files found the corresponding folder "x" of Update.zip:

  ```txt
  Update Files
  ```

  To replace the files in *C:\\Skyline DataMiner* (i.e. the root folder):

  ```txt
  Update Root
  ```

  To update a file in the *Files* or the *Tools* folder, there should first be an attempt to delete the file. Then if a "file in use" error is returned, "*.SLReplace*" should be added to the file name and SLReplace should be scheduled to run at the end of the upgrade operation.

- **Register**: Register the DataMiner services and DLLs using the command *RegisterDLLs.bat /s*.

- **Kill**: Kill the running DataMiner processes.

- **Start**: Start the DataMiner service.

- **IIS \[Start\|Stop\]**: Start or stop IIS:

  ```txt
  IIS Start
  ```

- **InstallApp**: Installs an [application package](xref:ApplicationPackages) from the specified path.

  ```txt
  InstallApp ./Path/To/AppPackage/AppPackage.zip
  ```

  > [!NOTE]
  > Application packages can only be installed on a DMA that is not stopped.

- **Delete**: Try to delete all files listed in *FilesToDelete.txt*.

- **Delete \[x\]**: Try to delete the specified file from the *C:\\Skyline DataMiner\\Upgrades* folder:

  ```txt
  Delete file.exe
  ```

- **EXTRACT \[x\]**: Extract the specified file and place its contents in the *C:\\Skyline DataMiner\\Upgrades* folder:

  ```txt
  EXTRACT doThis.bat
  ```

- **Execute \[x\] \[y\]**: Execute the file "y" and wait for max. "x" seconds.

  The file "y" has to be located in one of the following folders:

  - C:\\Skyline DataMiner\\Upgrades

  - C:\\Skyline DataMiner\\Tools

  - C:\\Skyline DataMiner\\Files

  - C:\\Windows

  ```txt
  Execute 60 doThis.bat
  ```

- **JS \[x\] \[y\]**: Execute the JavaScript file "y" using the command *cscript.exe /b /nologo* and wait for max. "x" seconds.

  The file "y" has to be located in one of the following folders:

  - C:\\Skyline DataMiner\\Upgrades

  - C:\\Skyline DataMiner\\Tools

  - C:\\Skyline DataMiner\\Files

  - C:\\Windows

  ```txt
  JS 60 ConfigureIIS.js
  ```

- **PS \[scriptname\] \[flag\]**: Executes the specified PowerShell script. The flag is optional and can be used in the same way as when you call a PowerShell script from the command console. The script name must include the script extension, e.g. ".ps1". The script must be located in the folder *C:\\Skyline DataMiner\\Tools*.

  For example:

  ```txt
  PS MyScript.ps1 -flag 20
  ```

- **SetOption\[KillIE\|NODELAYEDSTART\|EXTRACTALL\|NOROLLBACK\|REBOOT\|SKIPSNMP\]:**

  Sets one of the following options:

  | Command        | Description                                                             |
  |----------------|-------------------------------------------------------------------------|
  | KillIE         | Kill all iexplore processes.                                            |
  | NODELAYEDSTART | Remove "Delayed start" option from SLDataMiner service.                 |
  | EXTRACTALL     | Replace all files.                                                      |
  | NOROLLBACK     | Do not create a rollback package.                                       |
  | REBOOT         | Reboot the DataMiner Agent machine at the end of the upgrade operation. |
  | SKIPSNMP       | Keep the Windows SNMP service active.                                   |

  ```txt
  SetOption KillIE
  ```

- **UpgradeDB**: Upgrades the DataMiner database.

- **UpgradeDataMinerTaskBarUtility**: Upgrades the SLTaskBarUtility program.

- **ExecuteUpgrade \[x\]**: Executes an upgrade "subroutine".

  | When "x" is ...            | then ...                                     |
  |------------------------------|----------------------------------------------|
  | a name of an upgrade package | that particular upgrade package is executed. |
  | LASTROLLBACK                 | the last rollback package is executed.       |

  ```txt
  ExecuteUpgrade filename.zip
  ```

  ```txt
  ExecuteUpgrade LASTROLLBACK
  ```

  > [!NOTE]
  > The package has to be a full upgrade package, including SLUpgrade.dll etc.

- **AddRollbackAction \[x\]**: Adds an extra action to the rollback package

##### Example of an UpdateContent.txt file

```txt
Lock
Disable
Kill
IIS Stop
delete
Update Files
Update WebPages
Update Tools
Update Root
Update ProtocolScripts
Update Protocols
Update MIBs
Update Backup
Update Users
Update Views
Update Upgrades
UpgradeSLTaskbarUtility
UpgradeDB
Register
Enable
Unlock
js 300 SetNtfsPermissions.js
js 600 ConfigureIIS.js
Execute 60 DMAEventLogCreator.exe
IIS Start
Start
```

#### StartUpActions.txt

##### Action overview

- **Sync "filepath"**: Synchronizes a file across the entire DMS cluster. This includes new DMAs that may be created in the future. This option is ideal for assemblies (WFM) and for Visio files, as it automatically invalidates the client cache.

- **UploadDataMinerProtocol "filepath"**: Embeds .dmprotocol files in the upgrade package and uploads and processes them during DataMiner startup. The specified file path must be accessible for DataMiner, as otherwise the action cannot be performed.

- **SetAsProduction "\[ProtocolName\]\[ProtocolVersion\]"**: Sets the protocol version as the production version.

  > [!NOTE]
  > When a protocol linked to WFM assemblies is set to production, those assemblies are also copied to the production folder and synchronized throughout the DataMiner System.

- **StartElement "\[ElementName\]"**: Automatically starts an element after the upgrade.

##### Example of a StartUpActions.txt file

```txt
Sync "C:\Skyline DataMiner\Protocols\Visio_files\New_vdx.zip"
Sync "C:\Skyline DataMiner\Protocols\WFMConcept\1.0.0.0\TestAssembly.dll"
SetAsProduction "WFMConcept\1.0.0.0"
UploadDataMinerProtocol "C:\Skyline DataMiner\Protocols\Concept - Assemblies_1.0.0.0.dmprotocol"
```

## Update package (.dmupdate)

Package containing minor updates for an existing release. Update packages contain mostly bug fixes, but can also contain new features. The packages are very similar to upgrade packages, but they only contain the files that have changed compared to the base version for which they are an update.

- This type of file is published on dataminer.services by Skyline’s Quality Assurance Department.

- File extension: *.dmupdate*

## Backup package (.dmbackup)

Package containing all files necessary to restore a particular DataMiner Agent installation.

- This type of file is created each time you select the *Maintenance \> Backup* menu command in the SLTaskBarUtility program.

- File extension: *.dmbackup*

## Application package (.dmapp)

Package containing all files necessary to install a particular DataMiner app on an existing DataMiner System.

- This type of file is created by Skyline’s System Engineering department.

- File extension: *.dmapp*

> [!NOTE]
>
> - These packages can be installed in the same way as a .dmupgrade package. See [Upgrading a DataMiner Agent using DataMiner Taskbar Utility](xref:Upgrading_a_DataMiner_Agent_using_DataMiner_Taskbar_Utility).
> - .dmapp packages can also contain report templates, dashboards and aggregation rules.

> [!TIP]
> See also: [Application packages](xref:ApplicationPackages)

## Protocol package (.dmprotocol)

Package containing all files necessary to install a particular DataMiner protocol on an existing DataMiner System.

- This type of file is created by Skyline’s System Engineering department.

- File extension: *.dmprotocol*

The actual content of a protocol package differs from that of the other packages mentioned above. It contains the following items:

- Protocol.xml

- Default Microsoft Visio drawing (.vdx or .vsdx format)

- Default alarm and/or trend templates

- Additional assemblies (if needed)

- Protocol-specific help

## Import package (.dmimport)

Depending on what was exported into the package, this package may contain elements, services, views, properties, protocols, Automation scripts, etc.

- This file is created through an export from the Surveyor in DataMiner Cube.

- File extension: *.dmimport*

> [!TIP]
> See also: [Exporting and importing packages on a DMA](xref:Exporting_and_importing_packages_on_a_DMA)
