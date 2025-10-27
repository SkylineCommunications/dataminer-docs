---
uid: Automation_logging
---

# Automation logging

The *Automation* page shows the log information for the various Automation scripts that are present in the DMS.

The list on the left side of this page contains **all Automation scripts available in the system**. Clicking a script will expand it and display the DataMiner Agents on which it is available. Select a DMA to open the log details for that script on that specific Agent. The Agent you are currently connected to is shown in italics. However, log details will only be present after an Automation script has been executed on the DMA.

If an item has been selected, the expandable *Log settings* section at the top of the page allows you to [change the log levels](#changing-log-levels) that should be shown for **info, debug, and error logging**. Error logging is used only for errors, which will also be logged in SLErrors.txt, info logging is used for more informative log messages, e.g. "Running DataMiner 10.2.0.0", and debug logging is used for more detailed information.

To retrieve a **previous log file**, right-click an item in the list and select *Open previous*. If there is no previous log file, this option is not available.

> [!NOTE]
> The *Automation* logging page is available from DataMiner Cube 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9 onwards<!--RN 43144-->, but requires that DataMiner 10.5.6/10.6.0 or higher is installed on the server<!--RN 42737-->.

> [!TIP]
> To quickly access the logging page for a specific script, when you have selected the script in the [Automation module](xref:automation), click the *View log* button at the bottom of the card.

## Changing log levels

The log levels for each Automation script are indicated to the right of the DMA name in the log file list. Example: `0·0·0`, `1·0·0`, `1·3·2`, etc.

The lowest log level is 0, "No logging", which means that only essential information is logged and any more specific and detailed information is left out.

In the *Log settings* section, you can change the log levels for a specific Automation script.

To change the log levels:

1. Expand the Automation script(s) in the list.

1. Select the DMA(s) you want to configure.

   > [!NOTE]
   > To select multiple items at once, hold down the Ctrl key while selecting each item. To select a list of consecutive items, click the first one in the list and then click the last one while holding down the Shift key.

1. Expand the *Log settings* section at the top of the page.

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
