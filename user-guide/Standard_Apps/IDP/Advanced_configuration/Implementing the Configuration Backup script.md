---
uid: ConfigurationBackupScript
---

# Implementing the Configuration Backup script

## Setting up the DataMiner Configuration Archive

DataMiner IDP can be used to create configuration backups from [elements](xref:About_elements) in the managed inventory. However, before backups can be taken the DataMiner Configuration Archive needs to be setup.

## About Configuration Backup scripts

The backup configuration of the device is heavily dependent on the type of the device: some devices have a single file (e.g. a startup-configuration), others require a set of files (typically archived). Others don't have the notion of a configuration file and the backup could be an collection of the relevant parameter sets so the element can be reconfigured easily any time.

There are a number of ways the backup script can provide the configuration backup to DataMiner IDP.

Summary :

A [CI Type](xref:CI_Types1) can be configured with a script that will be used to take the configuration backup of the element of this CI Type. The script will be executed for a specific element and typically interact with it.

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

## Full vs Core Configuration

- A **Full Configuration** backup should contain the required configuration so the device can be restored. When performing a *configuration update* operation, the selected full configuration will be taken from the DataMiner Configuration Archive and will be pushed to the device.
- The **Core Configuration** is only relevant when change detection needs to be done based on other information then the Full Configuration. It's typically used to exclude sections of the Full Configuration that do not contain important information for change detection.

## Backup without change detection

### Backup by exchanging file contents

The script can supply the contents of a backup as a string value to DataMiner IDP. These contents are typically read from one or more parameters of the corresponding element.

With this approach the script supplies the contents when invoking the method *SendBackupContentToIdp*  

```csharp
inputData = new BackupInputData(engine);
backupManager = new Backup(inputData);
backupManager.NotifyProcessStarted();

string contents = "Contents of the backup which are typically read\n"
                + "from one or more parameters from the corresponding element";
backupManager.SendBackupContentToIdp(contents);

backupManager.NotifyProcessSuccess();
```

In this case, IDP will create a new file in the DataMiner Configuration Archive with the supplied value. The created files will have the TXT file extension.

### Backup by exchanging file locations

Instead of supplying the contents of a backup file to IDP, the script can supply a path to a file location instead. In this case, IDP  will copy the file from that location to the archive. This location can be on a DMA in the cluster or on a separate server, as long as it can be accessed with the credentials configured in **File Transfer Credentials** in *Admin > Network Shares*.

This setup can be used when the device can be triggered to copy its configuration to a server itself (e.g. using a copy command) and then expose the server location in a way that DataMiner IDP can access it.

With this approach the script supplies the path when invoking the method *SendBackupFilePathToIdp*  

```csharp
inputData = new BackupInputData(engine);
backupManager = new Backup(inputData);
backupManager.NotifyProcessStarted();

string path = @"\\WINSERVER1\backup\config.txt";
backupManager.SendBackupFilePathToIdp(path);

backupManager.NotifyProcessSuccess();
```

Next, DataMiner IDP will connect to the path and transfer the file to the DataMiner Configuration Archive. The file extension will be kept in the DataMiner Configuration Archive.

> [!NOTE]
> XML and TXT extensions are be visualized by default. This can be changed in [Backups](xref:Configuration#Backup).

## Backup with change detection

DataMiner IDP can detect changes between consecutive backups. This can be either done between consecutive

1. Full Configuration backups or
1. Core Configuration backups

When the script supplies the backup to IDP, it needs to supply a **version** number for change detection. The version makes it possible to control different structures of configurations that may arise when different data needs to be compared.

For example, it could occur that you initially only want to perform change detection on the uplink interface configuration, but eventually you also want to compare other parts of the configuration such as specific downlink interfaces. In that case, if you include the new parts, e.g. the downlink interface configuration, this increases the version number to 2. This way, with the different version number, the subject of the change detection changes.

### Backup and change detection by exchanging file contents

As with a backup without change detection, the script supplies the contents of a backup as a string value to DataMiner IDP.

In case the Full Configuration backup should be used for change detection, the script supplies the contents when invoking the method *SendBackupContentWithChangeDetectionToIdp*.  

```csharp
inputData = new BackupInputData(engine);
backupManager = new Backup(inputData);
backupManager.NotifyProcessStarted();

string fullContent = "Contents of the full backup which are typically read\n"
                + "from one or more parameters from the corresponding element";
int version = 1
backupManager.SendBackupContentWithChangeDetectionToIdp(fullContent,version);

backupManager.NotifyProcessSuccess();
```

In case the Core Configuration backup should be used for change detection, the script supplies the contents when invoking the method *SendBackupContentWithChangeDetectionToIdp*  

```csharp
inputData = new BackupInputData(engine);
backupManager = new Backup(inputData);
backupManager.NotifyProcessStarted();

string fullContent = "Contents of the full backup which are typically read\n"
                + "from one or more parameters from the corresponding element";
string coreContent = "Contents of the core backup which is typically \n"
                + "smaller then the full backup";
int version = 1
backupManager.SendBackupContentWithChangeDetectionToIdp(fullContent,coreContent, version);

backupManager.NotifyProcessSuccess();
```

In both case, IDP will create a new file in the DataMiner Configuration Archive with the supplied value. The created files will have the TXT file extension.

### Backup and change detection by exchanging file locations

As with a backup without change detection, the script supplies a path to a file location.

In case the Full Configuration backup should be used for change detection, the script supplies the contents when invoking the method *SendBackupFilePathWithChangeDetectionToIdp*.  

```csharp
inputData = new BackupInputData(engine);
backupManager = new Backup(inputData);
backupManager.NotifyProcessStarted();

string pathfullPathFull = @"\\WINSERVER1\backup\fullConfig.txt";
int version = 1;
backupManager.SendBackupFilePathWithChangeDetectionToIdp(fullPath,version);

backupManager.NotifyProcessSuccess();
```

In case the Core Configuration backup should be used for change detection, the script supplies the contents when invoking the method *SendBackupFilePathWithChangeDetectionToIdp*.

```csharp
inputData = new BackupInputData(engine);
backupManager = new Backup(inputData);
backupManager.NotifyProcessStarted();

string fullPath = @"\\WINSERVER1\backup\fullConfig.txt";
string corePath = @"\\WINSERVER1\backup\coreConfig.txt";
int version = 1;
backupManager.SendBackupFilePathWithChangeDetectionToIdp(fullPath,corePath,version);

backupManager.NotifyProcessSuccess();
```

Next, DataMiner IDP will connect to the path and transfer the files to the DataMiner Configuration Archive. The file extension will be kept in the DataMiner Configuration Archive.

> [!NOTE]
> XML and TXT extensions are be visualized by default. This can be changed in [Backups](xref:Configuration#Backup).
