---
uid: DataMiner_logging
---

# DataMiner logging

The *DataMiner* page shows the log information for the various DataMiner modules. From DataMiner 10.5.3/10.6.0 onwards<!-- RN 41674 -->, this also includes log information for DataMiner Extension Modules (DxMs).

This page consists of three sections:

- A log file list on the left side.

- An expandable *Log settings* section at the top of the page, which shows the log levels for info, debug and error logging.

  > [!NOTE]
  >
  > - Error logging is used only for errors, which will also be logged in SLErrors.txt, info logging is used for more informative log messages, e.g., "Running DataMiner 10.2.0.0", and debug logging is used for more detailed information.
  > - For DxM logs, this section is not available; logging must be [configured directly](#dataminer-extension-modules-dxm-logs) via the DxM configuration file.

- A pane on the right displaying the log details for any log file selected in the list on the left. You can refresh the displayed content by clicking the refresh icon at the top of the pane.

> [!NOTE]
> To retrieve a previous log file, right-click an item in the list and select *Open previous*. If there is no previous log file, this option is not available.

## Changing log levels

The log levels for each module (except DxMs) are indicated to the right of the module name in the log file list. Example: 0 0 0, 1 0 0, 1 3 2, etc. At the top of the list, the default settings are displayed.

The lowest log level is 0, "No logging", which means that only essential information is logged and any more specific and detailed information is left out. How much actually gets logged with this log level depends on the DataMiner process.

In the *Log settings* section, you can change the log levels for a specific module or change the default log levels of the DMA.

To change the default log levels:

1. Select *\<Default>* at the top of the list.

1. Click *Log settings* at the top of the page.

1. Change the log levels for info, debug and error logging as required.

1. Click *Apply levels* to apply your changes.

To change the log levels for a specific module:

1. Select the module in the list.

1. Click *Log settings* at the top of the page.

1. Select the checkbox *Override log levels*.

1. Change the log levels for info, debug and error logging as required.

1. Click *Apply levels* to apply your changes.

> [!NOTE]
>
> - Logging requires resources from your DataMiner Agent (CPU and HD usage), so be careful with the higher log levels like *Log everything (5)* and *Development logging (6)*.
> - Not all log files are available in DataMiner Cube. If you want to change the log levels for a log file that is not available in Cube, you can [do so using the SLNetClientTest tool](xref:SLNetClientTest_changing_log_levels).

## Sorting the log file list

At the top of the left-hand list, next to the header, *A-Z* is displayed.

Click this field to change the sort order. Each time you click the field again, the sort order will change, cycling through the various options:

- Alphabetically A-Z

- Alphabetically Z-A

- By log level, ascending (*Level up*)

- By log level, descending (*Level down*)

## Special items in the log file list

Some items in the list are of particular note:

| Log file | Description |
|--|--|
| DataMiner | General log file of the DMA. |
| Analytics | Log file regarding the SLAnalytics process, which takes care of trend predictions (if a Cassandra database is used). |
| Automation | Log file of the Automation engine of the DMA. |
| Cassandra Migration | Log file of the migration of the general database to Cassandra. Contains among others the settings used for the migration. See [Migrating the general database to Cassandra](xref:Migrating_the_general_database_to_Cassandra). |
| Connectivity | Log file regarding the DataMiner Connectivity Framework. |
| Correlation | Log file of the next-generation Correlation engine of the DMA. To facilitate troubleshooting, it is possible to activate verbose Correlation logging with the SLNetClientTest tool. However, note that this is an advanced system administration tool that should be used with extreme caution. See [Activating verbose Correlation logging](xref:SLNetClientTest_activating_verbose_correlation_logging). |
| Database Connection | Log file related to the connection to the various databases (e.g., general database, offload database, indexing database, etc.) |
| Database DataMiner | Log file with the traffic between the database and the SLDataMiner process of the DMA. |
| Database SLNet | Log file with the traffic between the database and the SLNet process of the DMA. Contains among others the username of a user that initiated a manual DMA Failover. |
| DMS | Log file with the traffic between the DMA and its peers in the DMS. Contains among others the file synchronization process. |
| Element in protocol | Log file that allows you to map elements to the protocol processes they use. For more information, see [Element in Protocol logging](xref:Element_in_Protocol_logging). |
| Errors | Log file with all errors that have occurred in the DataMiner processes of the DMA. |
| Errors in protocol | Log file with all errors generated by SLProtocol and SLManagedScripting. These are not contained in the general errors log file. |
| Mobile Gateway | Log file of the Mobile Gateway of the DMA. |
| Notifications | Log file of the Notifications engine of the DMA. Mentions among others any emails and SMS messages that have been sent. |
| Reports | Log file of the Reporter engine of the DMA. |
| Resource Manager | Log file of the *Resources* module, mentioning among others the creation, modification and deletion of bookings. |
| Scheduler | Log file of the Scheduler module. |
| SNMP Agents | Log file of the DMA’s SNMP agent software. |
| SNMP Managers | Log file of the DMA’s SNMP manager software. Mentions among others the SNMP notifications the DMA has been receiving. |
| Spectrum | Log file of the Spectrum Analyzer module of the DMA. If the logging level for this file is set to *Log everything*, it also includes logging for spectrum script execution and measurement point selection. |
| SSH | Dedicated log file for SSH connections. <br> Note the following regarding SSH logging:<br> - You can fully disable SSH logging by creating a file called *SLSshDisableLog.txt* in the folder `C:\Skyline Dataminer\Logging\`. This can be useful to improve performance in some cases. <br> - Alternatively, you can enable extended logging by creating a file called *SLSSHExt.txt* in the folder `C:\Skyline Dataminer\Logging\`. This will activate extended logging regarding the beginning and end of reads/writes and regarding what data is written/read. However, extended logging uses a lot of memory, so do not leave this enabled while this is not needed. Note that this file does not receive any logging itself, but it signals that extended logging should be put into the default SSH log file (*SLSsh.txt*). |
| Watchdog | Log file with the details of runtime errors detected by the SLWatchdog process. For more information, see [Watchdog logging](xref:Watchdog_logging) |

> [!NOTE]
>
> - For each of these log files, a corresponding TXT file is located in the `C:\Skyline DataMiner\Logging\` folder. The name of the TXT file is often the same as the name mentioned in Cube, but with an "SL" prefix. However, this is not always the case. If you select a log file in Cube, the corresponding TXT file name will be displayed at the top.
> - Some of the mentioned log files refer to advanced DataMiner modules that are not part of the DataMiner system by default.

## DataMiner Extension Modules (DxM) logs

The DataMiner Extension Modules logs are identified by their module name followed by the suffix *(DxM)*.

Each extension module includes a default configuration file, *appsettings.json*, where the DxM settings are defined. This file is located in the module's installation directory. To adjust the log settings, you will need to use a file named *appsettings.custom.json* file in the same directory. If this file does not exist yet, you will need to create it yourself. In this file, add the log settings that you want to override, with your custom value.

Note that if you change the settings directly in *appsettings.json*, this will work, but your changes will be overwritten as soon as the software is upgraded.
