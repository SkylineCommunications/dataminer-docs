---
uid: ConfigurationBackupScript
---

# Implementing the Configuration Backup script

## Setting up the DataMiner Configuration Archive

DataMiner IDP can be used to create configuration backups from [elements](xref:About_elements) in the managed inventory. However, before backups can be taken, the DataMiner Configuration Archive needs to be set up. You can do so on the [Admin > Configuration > Network Shares](xref:Configuration#network-shares) page of the IDP app.

## About Configuration Backup scripts

The backup configuration of the device depends heavily on the type of device: some devices have a single file (e.g. a startup configuration), others require a set of files (typically archived). Others do not really use a configuration file, so the backup could be a collection of the relevant parameter sets, allowing the element to be easily reconfigured at any time.

A [CI Type](xref:CI_Types1) can be configured with a script that will be used to take the configuration backup of the element of this CI Type. The script will be executed for a specific element and will typically interact with it.

> [!TIP]
> An example script *IDP_Example_Custom_ConfigurationBackup* is available in the Automation module after IDP has been installed. You can duplicate this script to use it as a starting point.

## Configuration types (running, startup, golden)

When a configuration backup is created, one of the following configuration types can be supplied:

- **Startup**: The configuration used during system startup (or reboot) to configure the device.

- **Running**: The current configuration the device runs on.

- **Golden**: This configuration type is typically not found on the device itself. It is used to identify the current configuration of the device as a valid configuration.

> [!NOTE]
>
> - When configuration changes are done, this typically affects the running configuration but not the startup configuration. If the running configuration is not saved to the startup configuration, the device will load the startup configuration at startup and unsaved configuration changes will be lost.
> - Not all devices use the terminology "startup configuration" and "running configuration". Some devices also do not use this concept.

The code examples in the [Backup with change detection](#backup-with-change-detection) and [Backup without change detection](#backup-without-change-detection) sections below do not take the configuration type into consideration. However,the device will likely require different commands to retrieve different configuration types. If multiple configuration types need to be supported, the custom script will need to have different code paths for the configuration type.

The class *BackupInputData* contains the configuration type. It can be used by the custom script as illustrated in the example below.

```csharp
// This will load the automation script's parameter data.
inputData = new BackupInputData(engine);
// This method will communicate with the IDP solution, to provide the required feedback for the backup process.
backupManager = new Backup(inputData);
switch (backupManager.InputData.ConfigurationType)
{
  case ConfigurationType.StartUp:
  // do something
  break;
  case ConfigurationType.Running:
  // do something
  break;
  case ConfigurationType.Golden:
  // do something
  break;
    default: throw new ArgumentException("Type not implemented");
}
```

## Full vs. core configuration

- A **full configuration** backup should contain the required configuration so the device can be restored. When a configuration update operation is performed, the selected full configuration will be taken from the DataMiner Configuration Archive and pushed to the device.
- The **core configuration** is only relevant when change detection needs to happen based on other information than the full configuration. It is typically used to exclude sections of the full configuration that do not contain important information for change detection.

## Backup without change detection

There are a number of ways the backup script can provide the configuration backup to DataMiner IDP. This is done by calling certain C# methods, as explained below.

### Backup by exchanging file contents

The script can supply the contents of a backup as a string value to DataMiner IDP. These contents are typically read from one or more parameters of the corresponding element.

With this approach, the script supplies the contents when invoking the method *SendBackupContentToIdp*.

```csharp
inputData = new BackupInputData(engine);
backupManager = new Backup(inputData);
backupManager.NotifyProcessStarted();

string contents = "Contents of the backup which are typically read\n"
                + "from one or more parameters from the corresponding element";
backupManager.SendBackupContentToIdp(contents);

backupManager.NotifyProcessSuccess();
```

In this case, IDP will create a new file with the supplied value in the DataMiner Configuration Archive. The created files will have the TXT file extension.

### Backup by exchanging file locations

Instead of supplying the contents of a backup file to IDP, the script can supply a path to a file location. In this case, IDP  will copy the file from that location to the archive. This location can be on a DMA in the cluster or on a separate server, as long as it can be accessed with the credentials configured in **File Transfer Credentials** on the [Admin > Configuration > Network Shares](xref:Configuration#network-shares) page of the IDP app.

This setup can be used when the device can be triggered to copy its configuration to a server itself (e.g. using a copy command) and then expose the server location in a way that DataMiner IDP can access it.

With this approach, the script supplies the path when invoking the method *SendBackupFilePathToIdp*.

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
> XML and TXT extensions are visualized by default. This can be changed on the [Admin > Configuration > Backup page](xref:Configuration#backup).

## Backup with change detection

DataMiner IDP can detect changes between consecutive backups. This can be done between either

- consecutive full configuration backups or
- consecutive core configuration backups.

When the script supplies the backup to IDP, it needs to supply a **version** number for change detection. The version makes it possible to control different structures of configurations that may arise when different data needs to be compared.

For example, it could occur that you initially only want to perform change detection on the uplink interface configuration, but eventually you also want to compare other parts of the configuration such as specific downlink interfaces. In that case, if you include the new parts, e.g. the downlink interface configuration, this increases the version number to 2. This way, with the different version number, the subject of the change detection changes.

### Backup and change detection by exchanging file contents

Like with a backup without change detection, the script supplies the contents of a backup as a string value to DataMiner IDP.

In case the **full configuration** backup should be used for change detection, the script supplies the contents when invoking the method *SendBackupContentWithChangeDetectionToIdp*.

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

In case the **core configuration** backup should be used for change detection, the script supplies the contents when invoking the method *SendBackupContentWithChangeDetectionToIdp*.

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

In both cases, IDP will create a new file in the DataMiner Configuration Archive with the supplied value. The created files will have the TXT file extension.

### Backup and change detection by exchanging file locations

As with a backup without change detection, the script supplies a path to a file location.

In case the **full configuration** backup should be used for change detection, the script supplies the contents when invoking the method *SendBackupFilePathWithChangeDetectionToIdp*.  

```csharp
inputData = new BackupInputData(engine);
backupManager = new Backup(inputData);
backupManager.NotifyProcessStarted();

string pathfull = @"\\WINSERVER1\backup\fullConfig.txt";
int version = 1;
backupManager.SendBackupFilePathWithChangeDetectionToIdp(fullPath,version);

backupManager.NotifyProcessSuccess();
```

In case the **core configuration** backup should be used for change detection, the script supplies the contents when invoking the method *SendBackupFilePathWithChangeDetectionToIdp*.

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
> XML and TXT extensions are visualized by default. You can change this on the [Admin > Configuration > Backup page](xref:Configuration#backup).
