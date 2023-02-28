---
uid: Analyze_Startup_Logs
---

# Analyze startup logs

In case a DMA fails to start up for some reason, you can use this tool to analyze the log files and get information on what could be the cause of the problem.

> You can download this tool from [DataMiner Dojo](https://community.dataminer.services/download/analyze-startup-logs/).

## Log file analysis

To analyze log files with this tool:

1. Extract the zip file you just downloaded in a local folder.

1. Double-click *AnalyzeStartupLogsUI.exe*.

1. If you are not executing the tool directly on the server with the DataMiner startup issues, click the *Browse* button next to the *Log Folder* box to navigate to the *Logs\Skyline* *DataMiner\Logging* folder of the [SLLogCollector tool](xref:SLLogCollector).

1. If you want to use a custom script instead of the default built-in script, click the *Browse* button next to the *Script* box and navigate to the custom script.

1. If you want to analyze the *\*_BAK.txt* log files instead of the current log files, select Use BAK files.

   > [!NOTE]
   > If both the current log files and the BAK files no longer contain the information you need to investigate the startup issue, consider restarting the DMA, copying the log files early on, and running the analyzer on those files.

1. If you want the analyzer to continue to look for entries in other log files after it has run into an error for one of the files, click the *More Options* button and select *Continue on errors*. This can be useful when the default script checks an entry that is not available in the version you are analyzing, or when some log files have already been updated since the issue occurred.

1. Click the *Analyze* button.

After the analysis has run, the *Output* section will be filled in with all entries that were found. Any errors will be displayed in red. A summary window will be displayed with tips on root causes if possible.

![Analyze Startup](~/user-guide/images/Analyze_Startup.png)

More options are available via the right-click menu of each item in the *Output* section:

![Output](~/user-guide/images/Output.png)

- *View Details*: Opens a window with more details on the current entry

- *Jump to Rule in Edit Mode*: Jumps to the matching entry in the script, if the editor is open. See [Editing scripts](#editing-scripts).

- *Re-Analyze without checking this entry*: Opens the editor and removes the current entry, then runs the analyzer again. This can be useful if the script halts for an incorrect reason. This allows you to still execute the rest of the script.

- *Re-Analyze without checking this file*: Opens the editor and removes all entries for the current file, then runs the analyzer again. This can be useful if the script halts for an incorrect reason (e.g. log file is no longer up to date). This allows you to still execute the rest of the script on the remaining files.

- *Export Results*: Saves the current results along with the summary into a text file.

## Editing scripts

The tool includes a built-in editor for the verification scripts.

To access the editor, make sure the script you want to edit is selected and then click the *Edit* button at the top of the tool. This will open a window like in the following example:

![Edit Script](~/user-guide/images/Edit_Script.png)

In this window, the *Script Contents* section contains the consecutive log lines that the script will search for. With the search box at the top of the section, you can quickly search for a specific entry. Via the context menu for each item in the script and via the buttons in the top right corner of the editor, you can change the order of the log lines, add log lines, or delete lines from the script.

In the *Details* section below this, you can find detailed information about the item selected in the *Script Contents* section:

- *Log File*: The name of the log file that will be searched.

- *Message Format*: The text to search for.

- *Is Regular Expression*: Indicates whether the message format above is a regular expression.

- *Test Format*: This info is not present in the saved configuration. Paste an example log line in here and the Message Format will highlight whether the test line matches the format.

- *When Stuck Before*: Indicate tips on what could be wrong when this line was not found but the previous one in the script was.

- *When Stuck After*: Indicate tips on what could be wrong when this line was found but the next one in the script was not.

While you are editing a script, you can run a test by going back to the main analyzer window and clicking the *Analyze* button.

You can save a script with the *Save* and *Save As* buttons.

> [!NOTE]
> The default built-in script cannot be modified, so any changes to this script can only be saved as a new script with *Save As* button.
