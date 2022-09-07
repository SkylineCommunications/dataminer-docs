---
uid: General_Main_Release_10.1.0_new_features_7
---

# General Main Release 10.1.0 - New features (part 7)

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!NOTE]
> **Internet Explorer Support**
>
> Though DataMiner Cube is available as a desktop application, many users still like to use the DataMiner browser application that requires Internet Explorer. However, Microsoft no longer recommends using Internet Explorer, and support for Internet Explorer is expected to cease in 2025, though currently the program is still maintained as part of the support policy for the versions of Windows it is included in. For more information, see <https://docs.microsoft.com/en-us/lifecycle/faq/internet-explorer-microsoft-edge>.
>
> The preferred way to use DataMiner Cube is as a desktop application, which can be downloaded from each DMA’s landing page in any other browser than Internet Explorer. From DataMiner 10.0.9 onwards, this application also comes with a new start window for increased ease of use.
>
> However, if you do wish to use DataMiner Cube in a browser, this remains possible:
>
> - Microsoft Edge can be configured to open specific URLs in IE compatibility mode. If you configure Edge to open the DataMiner Cube URLs of DMAs in this mode, you will be able to access the DMAs with DataMiner Cube in Edge. However, make sure you only do this for the exact URLs of DataMiner Cube, as other DataMiner apps will not function optimally in IE compatibility mode. For more information see, <https://docs.microsoft.com/en-us/DeployEdge/edge-ie-mode-policies>.
> - You can still continue to use Internet Explorer to access DataMiner Cube as long as Microsoft support continues. However, in this case we highly recommend to use a different browser to access any other websites on the internet.

### DMS Spectrum Analysis

#### DataMiner Cube - Spectrum Analysis: Button to apply all settings at once \[ID_25242\]

On a spectrum analyzer element card, an "Apply all" button is now available in the settings pane, so that you can configure several settings and then apply them all at the same time.

#### DataMiner Cube - Spectrum Analysis: Y axis of spectrum graph will no longer show values with 3 decimals if the reference level is shown in dBm and no decimal accuracy is being used \[ID_25250\]

If the reference level is shown in dBm and no decimal accuracy is being used, from now on, the Y axis of a spectrum graph will no longer show values with 3 decimals.

#### DataMiner Cube - Spectrum Analysis: A preset will now also include the decimals to be used when displaying DBm values in spectrum graphs \[ID_25871\]

When you save a spectrum preset, from now on, that preset will also include the amount of decimals to be used when displaying DBm values on the Y axis of a spectrum graph.

### DMS tools

#### SLLogCollector: New tool to collect log files and memory dumps and send them to Skyline support \[ID_25346\]\[ID_25631\]

From now on, the SLLogCollector tool will be available on all DataMiner Agents.

In case of problems, Skyline support may ask you to use this tool to compress the necessary log files and memory dumps into a zip file, which you can then store in a folder on the DataMiner Agent or upload to Skyline.

On the DataMiner Agent, the tool itself can be found at the following location:

- C:\\Skyline DataMiner\\Tools\\SLLogCollector\\SL_LogCollector.exe

When you launch the tool, the following options will be selected by default:

- Include memory dump (when run-time errors have been found on the system)

- Save to SLLogCollector folder on desktop

#### SLReset: Factory reset tool \[ID_26026\]\[ID_26408\]\[ID_27227\]

SLReset.exe is a new tool that can be used to fully reset a DataMiner Agent to its state immediately after installation. It is located in the C:\\Skyline DataMiner\\Files\\ folder.

##### Optional argument

| Argument | Description                                                         |
|----------|---------------------------------------------------------------------|
| -y       | Skip any prompts that ask you whether to run online/offline actions |

##### Online actions (i.e. actions that are only run when the DMA being reset is running)

- ResetFailoverOnline

  Deletes the Failover configuration of the DMA if one is present.

- ResetClusterOnline

  Removes the DMA from the DMS if it is part of one.

##### Offline actions (i.e. actions that are always run whether or not the DMA being reset is running)

- StopTaskbarUtility
- StopDataMiner
- UndoIISConfig
- UndoFirewallConfig
- Unregister
- UninstallEndpoints
- DeleteTaskbarAppSettings
- FileCleanup

  > [!NOTE]
  > Deletes any unnecessary files in the C:\\Skyline DataMiner\\ folder.
  >
  > This action uses a whitelist to determine what to keep.
  >
  > On first execution, the default whitelist is added to the C:\\Skyline DataMiner\\Files\\ResetConfig.txt file. Subsequent executions will then check the whitelist found in that text file, to which you can add any file you want to keep.
  >
  > If you delete ResetConfig.txt, SLReset will again use the default whitelist.

- ResetDataMinerXml
- ResetNotifyMail
- ResetDoNotRemoveFiles
- ResetSLNetExeConfig
- ResetProtocolsIconXml
- ResetReportTemplatesXml
- ResetWebpagesWebConfigs
- DeleteExecutableEvents
- DBReset

  > [!NOTE]
  > This action runs the SLDataGateway.Tools.Database.exe located in the C:\\Skyline DataMiner\\Files\\x64\\ folder, and uses the input arguments harvested from DataMiner (DB.xml, credentials,...).
  >
  > For more information on SLDataGateway.Tools.Database.exe, see below.

- Register
- DcomConfig
- ConfigureServices
- FirewallConfig
- IISConfig
- StartSLTaskbarUtility
- StartDataMiner

##### SLDataGateway.Tools.Database.exe

This tool, when run with the factory-reset argument, resets the currently active MySQL, Cassandra or ElasticSearch database(s). When running this tool, you can specify the following arguments:

- `factory-reset`: Mandatory. Argument specifying that a factory reset must be done.

- `-t` or `--database-type <type>`: Mandatory. The type of database:

  - SQL (i.e. MySQL)
  - Cassandra
  - Elastic (i.e. ElasticSearch)

- `-i` or `--ip <ip>`: Mandatory. The IP address of the database host.

- `-u` or `--username <username>`: The username.

  If no account is specified, the following default credentials will be used:

  - MySQL: root (empty password)
  - Cassandra: root/root
  - ElasticSearch: no security

- `-p` or `--password <password>`: The password to be used with the specified username.

- `-f` or `--forced`: Skips all prompts.

  If this argument is not used, the user will be asked for a final confirmation.

- `-d` or `--Database <keyspace>`: The database/keyspace to be cleaned. If this argument is not used, everything will be cleaned.

- `-k` or `--keepcustomcredentials`: Preserves the specified Cassandra credentials (user and password) throughout the factory reset process.

- `-l`: The log level:

  - 0 = Off
  - 1 = Trace (default)
  - 2 = Debug
  - 3 = Info
  - 4 = Warning
  - 5 = Error
  - 6 = Fatal

- `--timeout`: Timeout (in milliseconds). If execution takes longer than the specified timeout, the program is killed.

  Default: int.MaxValue (\~2 billion)

> [!NOTE]
>
> - When you perform a factory reset, no backup of the DataMiner Agent will be taken.
> - SLReset must be run with administrative privileges.

#### SLNetClientTest tool: Generating SMIv2 MIB files \[ID_26320\]

In the SLNetClientTest tool, you can now generate SMIv2 MIB files for SNMP managers of type SNMPv2 and SNMPv3.

To do so, go to *Advanced \> Tests \> Generate MIB for SNMP Manager*, select an SNMP manager and click *Generate*.

> [!WARNING]
> The DataMiner SLNetClientTest program is an advanced system administration tool that should be used with extreme care (C:\\Skyline DataMiner\\Files\\SLNetClientTest.exe).

#### DMS Alerter: New 'Set the alarm as read in Cube after the alarm has been acknowledged' setting \[ID_26579\]

When, in DMS Alerter, the new *Set the alarm as read in Cube after the alarm has been acknowledged* setting is enabled, each time you acknowledge an alarm in DMS Alerter, that same alarm will automatically be marked as “read” in DataMiner Cube.

> [!NOTE]
> This feature will only work if one and the same user is running both DMS Alerter and DataMiner Cube on the same client machine.

#### DMS Alerter: New 'Hide the comment window when acknowledging an alarm' setting \[ID_26621\]

A new setting, *Hide the comment window when acknowledging an alarm*, is available in the Alerter app. If this setting is enabled, you can take ownership of an alarm in an Alerter pop-up balloon without having to add a comment.

#### StandaloneElasticBackup tool \[ID_27683\]

The StandaloneElasticBackup.exe tool allows you to back up and restore Elasticsearch database clusters.

##### General syntax

```txt
StandaloneElasticBackup.exe <action> <arguments>
```

##### Actions

This tool allows you to perform the following actions:

| Action  | Description                |
|---------|----------------------------|
| init    | Initialize a repository.   |
| backup  | Take a backup/snapshot.    |
| restore | Restore a backup/snapshot. |

Example:

```txt
StandaloneElasticBackup.exe backup --host 127.0.0.1 -u elastic --pw mypw123 -r reponame
```

##### General arguments

- `--host` or `-h`: The host on which the command has to be run. Default: 127.0.0.1.
- `--port` or `-p`: The port on which Elasticsearch will be contacted. Default: 9200.
- `--username` or `-u`: The username that has to used to connect to Elasticsearch. Only use this option when credentials have to be used.
- `--pw`: The password that has to used to connect to Elasticsearch. Only use this option when credentials have to be used.

##### Arguments to add when you want to initialize the repository

Run StandaloneElasticBackup.exe with the following two (mandatory) arguments to initialize the repository that should be made to take a snapshot.

- `--repo` or `-r`: The name of the repository to be created.
- `--path`: The path of the repository as defined in the yaml.xml file of the Elasticsearch cluster, enclosed by “”. This is the location where the snapshot will be placed.

> [!NOTE]
>
> - Snapshots are incremental. Do not delete any of them.
> - See also: [https://www.elastic.co/guide/en/elasticsearch/reference/current/snapshots-register-repository.html](https://www.elastic.co/guide/en/elasticsearch/reference/current/snapshots-register-repository.html)

##### Arguments to add when you want to take a backup/snapshot

Run StandaloneElasticBackup.exe with the following two (mandatory) arguments to take a backup/snapshot.

- `--repo` or `-r`: The repository in which to take the backup.

  - If none is defined and only one repository is found in the Elasticsearch cluster, then that one will be used.
  - If none is defined and none can be found, then no backup will be taken.

- `--snapshotname` or `-n`: The (lowercase) name of the snapshot to be taken. Default: DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"); |

##### Arguments to add when you want to restore a backup/snapshot

Run StandaloneElasticBackup.exe with the following two (mandatory) arguments to restore a backup/snapshot.

- `--repo` or `-r`: The repository containing the backup to be restored.

  - If none is defined and only one repository is found in the Elasticsearch cluster, then that one will be used.
  - If none is defined and none can be found, then an error will be thrown.

- `--snapshotname` or `-n`: The name of the snapshot to be restored.

> [!NOTE]
>
> - If, before restoring a backup, you notice that all data was deleted from the database, then re-initialize the repository.
> - It is advised to disable security when restoring a backup with security enabled. To do so, comment the security setting in the yaml file.

#### SLNetClientTest: Viewing and deleting trend data patterns \[ID_28098\]

In the SLNetClientTest program, it is now possible to view and delete trend data patterns.

> [!WARNING]
> The DataMiner SLNetClientTest program is an advanced system administration tool that should be used with extreme care (C:\\Skyline DataMiner\\Files\\SLNetClientTest.exe).

#### SLNetClientTest: Viewing and editing SLNet configuration options with regard to NATS \[ID_28683\]

In the SLNetClientTest program, it is now possible to view and edit the following SLNet configuration options with regard to NATS, which are stored in the MaintenanceSettings.xml file:

- NATSDisasterCheck

- NATSResetWindow

- NATSRestartTimeout

> [!WARNING]
> The DataMiner SLNetClientTest program is an advanced system administration tool that should be used with extreme care (C:\\Skyline DataMiner\\Files\\SLNetClientTest.exe).
