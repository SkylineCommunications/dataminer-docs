---
uid: DataMiner_logging
---

# DataMiner logging

The *DataMiner* page shows the log information for the various DataMiner modules.

This page consists of three sections:

- A log file list on the left side.

- An expandable *Log settings* section at the top of the page, which shows the log levels for info, debug and error logging.

  > [!NOTE]
  > Error logging is used only for errors, which will also be logged in SLErrors.txt, info logging is used for more informative log messages, e.g. "Running DataMiner 10.0.0.0", and debug logging is used for more detailed information.

- A pane on the right displaying the log details for any log file selected in the list on the left. You can refresh the displayed content by clicking the refresh icon at the top of the pane.

> [!NOTE]
> To retrieve a previous log file, right-click an item in the list and select *Open previous*. If there is no previous log file, this option is not available.

## Changing log levels

### [From DataMiner 10.0.4 onwards](#tab/tabid-1)

From DataMiner 10.0.4 onwards, the log levels for each module are indicated to the right of the module name in the log file list. Example: 0 0 0, 1 0 0, 1 3 2, etc. At the top of the list, the default settings are displayed.

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

### [Prior to DataMiner 10.0.4](#tab/tabid-2)

The log levels of a DMA are indicated in the group header of that DMA. Example: 0 0 0, 1 0 0, 1 3 2, etc.

In the *Log settings* section, you can change the log levels for all modules of a DMA. To do so:

1. Select one of the modules of the DMA in the log file list.

- An expandable *Log settings* section at the top of the page, which shows the log levels for info, debug and error logging.

  > [!NOTE]
  > Error logging is used only for errors, which will also be logged in SLErrors.txt, info logging is used for more informative log messages, e.g. "Running DataMiner 10.0.0.0", and debug logging is used for more detailed information.

1. Change the log levels for info, debug and error logging as required.

1. Click *Apply levels* to apply your changes.

> [!NOTE]
> Logging requires resources from your DataMiner Agent (CPU and HD usage), so be careful with the higher log levels like *Log everything (5)* and *Development logging (6)*.

***

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
| SSH | Dedicated log file for SSH connections. <br> Note the following regarding SSH logging:<br> - You can fully disable SSH logging by creating a file called “*SLSshDisableLog.txt*” in the folder *C:\\Skyline Dataminer\\Logging\\*. This can be useful to improve performance in some cases. <br> - Alternatively, you can enable extended logging by creating a file called “*SLSSHExt.txt*” in the folder *C:\\Skyline Dataminer\\Logging\\*. This will activate extended logging regarding the beginning and end of reads/writes and regarding what data is written/read. However, extended logging uses a lot of memory, so do not leave this enabled while this is not needed. |
| Watchdog | Log file with the details of runtime errors detected by the SLWatchdog process. For more information, see [Watchdog logging](xref:Watchdog_logging) |

> [!NOTE]
> Some of the mentioned log files refer to advanced DataMiner modules that are not part of the DataMiner system by default.
