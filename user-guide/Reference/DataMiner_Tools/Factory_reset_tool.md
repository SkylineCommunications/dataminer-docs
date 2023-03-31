---
uid: Factory_reset_tool
---

# Factory reset tool

The factory reset tool *SLReset.exe* can be used by an administrator to fully reset a DataMiner Agent to its default state from immediately after installation.

From DataMiner 10.0.12 onwards, this tool is available on each DMA server in the folder `C:\Skyline DataMiner\Files\`. It is not supported for older versions of DataMiner.

> [!CAUTION]
> There is no automatic backup of the DMA before the factory reset is performed. Make sure you have taken any backups you need before you run this tool.

> [!NOTE]
> The factory reset will also remove all known users of the DataMiner System, so you will only be able to log in with the built-in Administrator account afterwards.

Optionally, you can run the tool with the `–y` input argument in order to skip prompts that ask you for permission to run specific actions.

From DataMiner 10.2.0/10.2.2 onwards, you can also run it with the `-ho [hostname]` argument to specify the hostname. This is especially useful when resetting a DataMiner Agent that only allows you to connect via HTTPS.

## Actions

This tool will perform the following actions if the DMA that is being reset is running:

- ResetFailoverOnline: Deletes the Failover configuration of the DMA if one is present.
- ResetClusterOnline: Removes the DMA from the DMS if it is part of one.

It will always perform the following actions, regardless of whether the DMA is running:

- StopTaskbarUtility
- StopDataMiner
- UndoIISConfig
- UndoFirewallConfig
- Unregister
- UninstallEndpoints
- DeleteTaskbarAppSettings
- FileCleanup

  This action deletes any unnecessary files in the folder `C:\Skyline DataMiner\`. It uses a whitelist to determine which files to keep. When it is first executed, the default whitelist is added to `C:\Skyline DataMiner\Files\ResetConfig.txt`. Afterwards, you can add files you want to keep to this whitelist, so that these are not removed when the tool is executed again. If you delete *ResetConfig.txt*, the default whitelist will be used again.

- ResetDataMinerXml
- ResetNotifyMail
- ResetDoNotRemoveFiles
- ResetSLNetExeConfig
- ResetProtocolsIconXml
- ResetReportTemplatesXml
- ResetWebpagesWebConfigs
- DeleteExecutableEvents
- DBReset

  This action runs the tool *SLDataGateway.Tools.Database.exe*, using input arguments harvested from DataMiner (*DB.xml*, credentials, etc.). For more information, see [SLDataGateway.Tools.Database.exe](#sldatagatewaytoolsdatabaseexe) below.

- Register
- DcomConfig
- ConfigureServices
- FirewallConfig
- IISConfig
- StartSLTaskbarUtility
- StartDataMiner
- Cleanclustereddatabases

  Available from DataMiner 10.1.0 \[CU6\]/10.1.9 onwards. Prior to DataMiner 10.2.0 \[CU9\]/10.2.12, this action will remove all keyspaces and indices from the Cassandra cluster and Elasticsearch databases. From DataMiner 10.2.0 \[CU9\]/10.2.12 onwards, this action will remove the tables, keyspaces, and indices defined in the *DB.xml* file from the databases (clusters as well as single-node Cassandra databases on remote machines).

## SLDataGateway.Tools.Database.exe

*SLDataGateway.Tools.Database.exe* is a tool used by *SLReset.exe* in order to reset the database. This tool can also be run separately. It is located in the folder `C:\Skyline DataMiner\Files\x64\`.

This tool can be run with the following arguments:

- `factory-reset`: Mandatory argument. Specifies that a factory reset must be done.

- `-t <type>` or `–database-type <type>`: Mandatory argument. Indicates the type of database:

  - *SQL* (i.e. MySQL)
  - *Cassandra*
  - *Elastic* (i.e. Elasticsearch)

- `-i <ip>` or `–ip <ip>`: Mandatory argument. The IP address of the database host.

- `-u <username>` or `–username <username>`: Username used for authentication. If no user credentials are specified, the following default credentials will be used:

  - MySQL: *root* (empty password)
  - Cassandra: *root/root*
  - Elasticsearch: no security

- `-p <password>` or `–password <password>`: Password used for authentication. If no user credentials are specified, the following default credentials will be used:

  - MySQL: *root* (empty password)
  - Cassandra: *root/root*
  - Elasticsearch: no security

- `-f` or `–forced`: Skip all prompts. If this argument is not used, the user will be asked for a final confirmation.

- `-d <keyspace>` or `–Database <keyspace>`: Database/keyspace to be cleaned. If this argument is not used, everything will be cleaned.

- `-k` or `–keepcustomcredentials`: Preserve the specified Cassandra credentials (user and password) throughout the factory reset process.

- `-l <level>`: Log level:

  - 0 = Off
  - 1 = Trace (default)
  - 2 = Debug
  - 3 = Info
  - 4 = Warning
  - 5 = Error
  - 6 = Fatal

- `–timeout <ms>`: Timeout (milliseconds). If execution takes longer than the specified timeout, the program is killed.

  Default: int.MaxValue (~2 billion)
