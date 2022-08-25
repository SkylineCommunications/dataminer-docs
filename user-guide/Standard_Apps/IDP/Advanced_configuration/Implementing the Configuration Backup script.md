---
uid: ConfigurationBackupScript
---

# Implementing the Configuration Backup script

## Setting up the DataMiner Configuration Archive

DataMiner IDP can be used to create configuration backups from [elements](xref:About_elements) in the managed inventory. However, before backups can be taken the DataMiner Configuration Archive needs to be setup.

If you use exchange files (see below) the file transfer credentials also need to be configured.

## About Configuration Backup scripts

A [CI Type](xref:CI_Types1) can be configured with a script that will be used to take the configuration backup of the element of this CI Type. This script will typically read element data and pass this on to DataMiner IDP.

The script integrates with the connector and the element, and it will be executed for a specific element. 

> [!TIP]
> An example script *IDP_Example_Custom_ConfigurationBackup* is available in the Automation module after IDP has been installed. You can duplicate this script to use it as a starting point.

The Configuration Backup needs to call certain C# methods to inform IDP of the configuration backup. 
  
```csharp
try
{
// This will load the automation script's parameter data.
inputData = new BackupInputData(engine);

// This method will communicate with the IDP solution, to provide the required feedback for the backup process.
backupManager = new Backup(inputData);

// When the backup process starts normally, this method should be called.
backupManager.NotifyProcessStarted();

// When the backup process starts normally, here comes the code to take and send backup to IDP.
// 

// On a normal execution, IDP should be notified of its success through this method.
backupManager.NotifyProcessSuccess();
        }
catch (ScriptAbortException)
{
// For any exceptions, or other unexpected behavior, the IDP solution should be informed, if possible, of the failure.
backupManager?.NotifyProcessFailure("Backup script was aborted.");
throw;
}
catch (BackupFailedException ex)
{
backupManager?.NotifyProcessFailure($"Custom backup code failed with the following exception:{Environment.NewLine}{ex}");
engine.ExitFail(ex.ToString());
}
catch (Exception ex)
{
backupManager?.NotifyProcessFailure($"The main script failed due to an exception:{Environment.NewLine}{ex}");
engine.ExitFail(ex.ToString());
}
```

## Configuration types (running, startup, golden)



when creating a configuration backup, the following configuration type can be supplied

- startup
- running
- golden

## Full Configuration vs Core Configuration

A **Full Configuration** backup should contain the required configuration so the device can be restored. When performing a *configuration update* operation, the selected full configuration will be taken from the DataMiner Configuration Archive and will be pushed to the device. 

The **Core Configuration** is the part of the Full Configuration which is used to perform change detection. 



## Change Detection

DataMiner IDP can detect changes between consecutive backups. The change 


An extra method is now available to have IDP store a device configuration in the configuration archive. Previously, only the StoreResult method could be used, but now you can also use the StoreResultAndChangeDetection method, which will pass the comparison version and the change detection data along with the configuration backup.

The “version” makes it possible to control different structures of configurations that may arise when different data needs to be compared. For example, it could occur that you initially only want to perform change detection on the uplink interface configuration, but eventually you also want to compare other parts of the configuration such as specific downlink interfaces. In that case, if you include the new parts, e.g. the downlink interface configuration, this increases the version number to 2. This way, with the different version number, the subject of the change detection changes.

The “separate data” from the full backup can be used to exclude sections of the original that do not contain important information for the comparison.

In the IDP app, you can find the change detection information on the Configuration tab:

On the Summary subtab, there is a new column that indicates when IDP last detected a change in the configuration.
On the Backups subtab, there is a new column that indicates if a search result contains changes compared to the previous backup. The column will either display Changed or Unchanged, depending on whether a change was detected, or Unknown, if IDP could not determine whether there was a change.
Also on the Backups subtab, when you select a file to visualize its content, you can now select to view the Full Configuration Backup or the Core Configuration Only.
Similarly, on the Compare subtab, when you select a configuration file to visualize its content, you can now select to view the Full Configuration Backup or the Core Configuration Only.

## Methods to pass the configuration backup to IDP

### Backup based on string values



### Backup based on transferring files

It is  possible to configure a backup script with a file location, so that IDP  will copy the file from that location to the archive. This location can be on a DMA in the cluster or on a separate server, as long as it can be accessed with the credentials configured in **File Transfer Credentials** in *Admin > Network Shares*.

To configure this, in the backup script, supply the path to and call the method SendBackupFilePathToIdp of the Backup object. 

```csharp

string path = @"\\WINSERVER1\backup\config.txt";
backupManager.SendBackupFilePathToIdp(path);
```

Next, the DataMiner IDP will connect to the path and transfer the file to the DataMiner Configuration Archive.


