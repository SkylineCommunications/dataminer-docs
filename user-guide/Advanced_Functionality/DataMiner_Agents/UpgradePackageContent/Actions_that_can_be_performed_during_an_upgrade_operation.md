---
uid: Actions_that_can_be_performed_during_an_upgrade_operation
---

# Actions that can be performed during an upgrade operation

In the *UpdateContent.txt* file, you can define a list of actions that have to be performed during an upgrade operation.

In addition, there can also be a file named *StartUpActions.txt* contained in the upgrade package, which can contain similar commands. In that case, *UpdateContent.txt* must contain an “Update Upgrades” command to unpack the *StartUpActions.txt* file to the correct Skyline DataMiner directory.

#### UpdateContent.txt

##### Action overview

- **SLEEP \[x\]**: Sleep for x seconds:

    ```txt
    SLEEP 1
    ```

- **Lock**: Lock the service manager.

- **Unlock**: Unlock the service manager.

- **Disable**: Disable and stop the DataMiner services (except SLWatchdog).

- **Enable**: Enable the DataMiner services. Also set the “Automatic startup” flags and descriptions.

- **Update \[x\]**: Replace the files in subfolder “x” of *C:\\Skyline DataMiner* by the files found the corresponding folder “x” of Update.zip:

    ```txt
    Update Files
    ```

    To replace the files in *C:\\Skyline DataMiner* (i.e. the root folder), use:

    ```txt
    Update Root
    ```

    > [!NOTE]
    > If you want to update a file in the *Files* or the *Tools* folder, first try to delete the file. If you get a “file in use” error, then add “*.SLReplace*” to the file name and schedule SLReplace to run at the end of the upgrade operation.

- **Register**: Register the DataMiner services and DLLs using the command *RegisterDLLs.bat /s*.

- **Kill**: Kill the running DataMiner processes.

- **Start**: Start the DataMiner service.

- **IIS \[Start\|Stop\]**: Start or stop IIS:

    ```txt
    IIS Start
    ```

- **InstallApp**: Supported from DataMiner 10.0.9 onwards. Installs an application package from the specified path.

    ```txt
    InstallApp ./Path/To/AppPackage/AppPackage.zip
    ```

    > [!NOTE]
    > -  Application packages can only be installed on a DMA that is not stopped.
    > -  For more information, see [Application packages](xref:TOOApplicationPackages#application-packages).

- **Delete**: Try to delete all files listed in *FilesToDelete.txt*.

- **Delete \[x\]**: Try to delete the specified file from the *C:\\Skyline DataMiner\\Upgrades* folder:

    ```txt
    Delete file.exe
    ```

- **EXTRACT \[x\]**: Extract the specified file and place its contents in the *C:\\Skyline DataMiner\\Upgrades* folder:

    ```txt
    EXTRACT doThis.bat
    ```

- **Execute \[x\] \[y\]**: Execute the file “y” and wait for max. “x” seconds.

    The file “y” has to be located in one of the following folders:

    - C:\\Skyline DataMiner\\Upgrades

    - C:\\Skyline DataMiner\\Tools

    - C:\\Skyline DataMiner\\Files

    - C:\\Windows

    ```txt
    Execute 60 doThis.bat
    ```

- **JS \[x\] \[y\]**: Execute the JavaScript file “y” using the command *cscript.exe /b /nologo* and wait for max. “x” seconds.

    The file “y” has to be located in one of the following folders:

    - C:\\Skyline DataMiner\\Upgrades

    - C:\\Skyline DataMiner\\Tools

    - C:\\Skyline DataMiner\\Files

    - C:\\Windows

    ```txt
    JS 60 ConfigureIIS.js
    ```

- **PS \[scriptname\] \[flag\]**: Available from DataMiner 10.0.3 onwards. Executes the specified PowerShell script. The flag is optional and can be used in the same way as when you call a PowerShell script from the command console. The script name must include the script extension, e.g. “.ps1”. The script must be located in the folder *C:\\Skyline DataMiner\\Tools*.

    For example:

    ```txt
    PS MyScript.ps1 -flag 20
    ```

- **SetOption\[KillIE\|NODELAYEDSTART\|EXTRACTALL\|NOROLLBACK\|REBOOT\|SKIPSNMP\]:**

    Sets one of the following options:

    | Command      | Description                                                             |
    |----------------|-------------------------------------------------------------------------|
    | KillIE         | Kill all iexplore processes.                                            |
    | NODELAYEDSTART | Remove “Delayed start” option from SLDataMiner service.                 |
    | EXTRACTALL     | Replace all files.                                                      |
    | NOROLLBACK     | Do not create a rollback package.                                       |
    | REBOOT         | Reboot the DataMiner Agent machine at the end of the upgrade operation. |
    | SKIPSNMP       | Keep the Windows SNMP service active.                                   |

    ```txt
    SetOption KillIE
    ```

- **UpgradeDB**: Upgrades the DataMiner database.

- **UpgradeDataMinerTaskBarUtility**: Upgrades the SLTaskBarUtility program.

- **ExecuteUpgrade \[x\]**: Executes an upgrade “subroutine”.

    | When “x” is ...            | then ...                                     |
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

- **Sync “filepath”**: Use this command to synchronize a file across the entire DMS cluster. This includes new DMAs that may be created in the future. This option is ideal for assemblies (WFM) and for Visio files, as it automatically invalidates the client cache.

- **UploadDataMinerProtocol “filepath”**: Use this command to embed .dmprotocol files in the upgrade package and upload and process them during DataMiner startup. Make sure that the specified file path is accessible for DataMiner, as otherwise the action cannot be performed.

- **SetAsProduction “\[ProtocolName\]\[ProtocolVersion\]”**: Use this command to set the particular protocol version as production version.

    > [!NOTE]
    > When a protocol linked to WFM assemblies is set to production, those assemblies are also copied to the production folder and synchronized throughout the DataMiner System.

- **StartElement “\[ElementName\]”**: Use this command to automatically start an element after the upgrade.

##### Example of a StartUpActions.txt file

```txt
Sync "C:\Skyline DataMiner\Protocols\Visio_files\New_vdx.zip"
Sync "C:\Skyline DataMiner\Protocols\WFMConcept\1.0.0.0\TestAssembly.dll"
SetAsProduction "WFMConcept\1.0.0.0"
UploadDataMinerProtocol "C:\Skyline DataMiner\Protocols\Concept - Assemblies_1.0.0.0.dmprotocol"
```
