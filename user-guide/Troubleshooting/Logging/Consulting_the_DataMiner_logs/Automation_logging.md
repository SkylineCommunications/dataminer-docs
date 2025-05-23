---
uid: Automation_logging
---

# Automation logging

The *Automation* page shows the log information for the various automation scripts that are present in the DMS.

This page consists of three sections:

- A log file list, one for each Automation Script present in the system, on the left side.

- An expandable *Log settings* section at the top of the page, which shows the log levels for info, debug and error logging.

  > [!NOTE]
  >
  > - Error logging is used only for errors, which will also be logged in SLErrors.txt, info logging is used for more informative log messages, e.g. "Running DataMiner 10.2.0.0", and debug logging is used for more detailed information.

- A pane on the right displaying the log details for any log file selected in the list on the left. You can refresh the displayed content by clicking the refresh icon at the top of the pane.

  > [!NOTE]
  > - Logging will only be present after the Automation Script is executed in the DMA.

> [!NOTE]
> To retrieve a previous log file, right-click an item in the list and select *Open previous*. If there is no previous log file, this option is not available.

## Changing log levels

The log levels for each automation script are indicated to the right of the module name in the log file list. Example: 0 0 0, 1 0 0, 1 3 2, etc. At the top of the list, the default settings are displayed.

In the *Log settings* section, you can change the log levels for a specific Automation Script.

To change the log levels:

1. Select the Automation Script in the list.

1. Click *Log settings* at the top of the page.

1. Select the checkbox *Override log levels*.

1. Change the log levels for info, debug and error logging as required.

1. Click *Apply levels* to apply your changes.

> [!NOTE]
>
> - To change the Default log level please use the [DataMiner](xref:DataMiner_logging) page.
> - Logging requires resources from your DataMiner Agent (CPU and HD usage), so be careful with the higher log levels like *Log everything (5)* and *Development logging (6)*.

## Sorting the log file list

At the top of the left-hand list, next to the header, *A-Z* is displayed.

Click this field to change the sort order. Each time you click the field again, the sort order will change, cycling through the various options:

- Alphabetically A-Z

- Alphabetically Z-A

- By log level, ascending (*Level up*)

- By log level, descending (*Level down*)
