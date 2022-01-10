## Cube logging

The *Cube* page shows internal log information related to DataMiner Cube itself.

The log information is displayed in a list with the following columns:

| Column | Description                                                                                                                                                                                    |
|--------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Type   | The type of log message, e.g. Debug, Info.                                                                                                                                                     |
| Count  | Displayed from DataMiner 9.6.5 onwards. From this version onwards, if certain conditions are met, log items can be grouped. This column shows how many log items are grouped under this entry. |
| Time   | The time when the message was logged, displayed in the format MM/DD/YYYY HH:MM:SS.                                                                                                             |
| Text   | The log message itself.                                                                                                                                                                        |

Below the list, a details pane shows detailed information on any selected log item.

You can view additional information on the selected item by clicking the *Open* button in the details pane or by double-clicking the item in the list. This will open the detailed information in a pop-up window, which also contains a button that allows you to copy the information.

The following buttons at the bottom of this page allow further actions:

| Button                   | Functionality                                                                                                                     |
|--------------------------|-----------------------------------------------------------------------------------------------------------------------------------|
| Export debug information | Exports the log information as a ZIP file.                                                                                        |
| Email debug information  | Creates an email message to DataMiner Technical Support with the log information.                                                 |
| Open log folder          | Opens the folder containing the log files on the client machine. Note that Cube removes these files once they are seven days old. |
| Copy cube information    | Copies the log information to the clipboard.                                                                                      |

> [!NOTE]
> -  Use the filter box in the top-right corner to filter the displayed information. See [Using quick filters](../../part_1/GettingStarted/Using_quick_filters.md).
> -  By default, debug logging is not displayed. To display these log items, select the option *Show debug logging* at the top of the tab.
> -  From DataMiner 10.1.11/10.2.0 onwards, you can select the option *Show SPI logging* at the top of the tab to see information related to system performance indicators.
> -  When an exception is recorded in the Cube logging, this is indicated by an icon in the Cube header. Clicking the icon will open this logging section. For warnings and errors, by default no icon is displayed in the header. However, you can have such icons displayed by adding the following argument to the Cube URL:<br>*?enablefeature=loggingnotifications*
>
