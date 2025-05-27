---
uid: Automation_logging
---

# Automation logging

The *Automation* page shows the log information for the various Automation scripts that are present in the DMS.

The list on the left side of this page contains a **log entry for each Automation script** present in the system. Clicking an item in the list will show the log details for the item. However, log details will only be present after an Automation script has been executed on the DMA.

If an item has been selected, the expandable *Log settings* section at the top of the page allows you to [change the log levels](#changing-log-levels) that should be shown for **info, debug, and error logging**. Error logging is used only for errors, which will also be logged in SLErrors.txt, info logging is used for more informative log messages, e.g. "Running DataMiner 10.2.0.0", and debug logging is used for more detailed information.

To retrieve a **previous log file**, right-click an item in the list and select *Open previous*. If there is no previous log file, this option is not available.

> [!NOTE]
> The *Automation* logging page is available from DataMiner Cube 10.4.0 [CU16]/10.5.0 [CU4]/10.5.7 onwards, but requires that DataMiner 10.5.6/10.6.0 or higher is installed on the server.

> [!TIP]
> To quickly access the logging page for a specific script, when you have selected the script in the [Automation module](xref:automation), click the *View log* button at the bottom of the card.

## Changing log levels

The log levels for each Automation script are indicated to the right of the module name in the log file list. Example: 0 0 0, 1 0 0, 1 3 2, etc. At the top of the list, the default settings are displayed.

In the *Log settings* section, you can change the log levels for a specific Automation Script.

To change the log levels:

1. Select the Automation script in the list.

1. Click *Log settings* at the top of the page.

1. Select the checkbox *Override log levels*.

1. Change the log levels for info, debug, and error logging as required.

1. Click *Apply levels* to apply your changes.

> [!NOTE]
>
> - To change the default log level, use the [DataMiner](xref:DataMiner_logging) logging page.
> - Logging requires resources from your DataMiner Agent (CPU and HD usage), so be careful with the higher log levels like *Log everything (5)* and *Development logging (6)*.

## Sorting the log file list

At the top of the left-hand list, next to the header, *A-Z* is displayed.

Click this field to change the sort order. Each time you click the field again, the sort order will change, cycling through the various options:

- Alphabetically A-Z

- Alphabetically Z-A

- By log level, ascending (*Level up*)

- By log level, descending (*Level down*)
