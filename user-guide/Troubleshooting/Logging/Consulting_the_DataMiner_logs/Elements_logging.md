---
uid: Elements_logging
---

# Elements logging

The *Elements* page shows the log information for the various elements in the DMS.

This page consists of three sections:

- A log file list on the left side.

- An expandable *Log settings* section at the top of the page, which shows the log levels for info, debug and error logging.

    > [!NOTE]
    > Error logging is used only for errors, which will also be logged in SLErrors.txt, info logging is used for more informative log messages, e.g. "Running DataMiner 10.0.0.0", and debug logging is used for more detailed information. Which level is used depends on the configuration specified in the element protocol.

- A pane on the right displaying the log details for any log file selected in the list on the left. You can refresh the displayed content by clicking the refresh icon at the top of the pane.

> [!NOTE]
>
> - It is possible to retrieve a previous version of a log file by right-clicking an element in the list and selecting *Open previous*. If there is no previous log file, this option is not available.
> - To quickly go to the logging for a particular element from the Surveyor, right-click the element in the Surveyor and select *View \> Log*.
> - If an element is renamed, the log file for that element will also be renamed.

## Changing log levels

The log levels of each element are indicated to the right of the element name in the log file list. Example: 0 0 0, 1 0 0, 1 3 2, etc.

In the *Log settings* section, you can change the log levels for each element. To do so:

1. Select one or more elements in the log file list.

1. Click *Log settings* at the top of the page.

1. Change the log levels for info, debug and error logging, as required.

1. Click *Apply levels* to apply your changes.

> [!NOTE]
> Logging requires resources from your DataMiner Agent (CPU and HD usage), so be careful with the higher log levels like *Log everything (5)* and *Development logging (6)*.

## Sorting the log file list

Sorting the log file list in the *Elements* page is done in the same way as for the *DataMiner* page. See [Sorting the log file list](xref:DataMiner_logging#sorting-the-log-file-list).

## Clearing log files

It is possible to clear the log file for an element, or for several elements at a time.

To do so:

1. In the list on the left, select the element or elements.

1. Click the *Clear* button in the pane on the right.

    > [!NOTE]
    > If one element is selected, the button is located in the lower right corner of the pane. If several elements are selected, it is displayed in the top-left corner.
