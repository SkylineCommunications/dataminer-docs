---
uid: Log
---

# Log

Use this action to have a script create a log message that will be saved in the SLAutomation.txt log file. It can either be a pre-determined message, or a message depending on a variable:

- To have a fixed message logged, click the default *Variable* field to select *Message* instead, and type a message in the next field.

- To have a message logged based on a variable, keep *Variable* selected and then click the next field to select the variable.

To find the logging, you can consult the [DataMiner logging](xref:DataMiner_logging) in DataMiner Cube or check the *SLAutomation.txt* log file in the folder `C:\Skyline DataMiner\Logging` on the DataMiner server.

Note that from DataMiner 10.5.6/10.6.0 onwards<!-- RN 42572 -->, when this action is used, logging will also be added in a dedicated log file with the name of the automation script in the folder `C:\Skyline DataMiner\Logging\Automation`. This file gets created the first time the script is run. After a DataMiner restart, the first time a script is executed, its existing log file will get the "_Bak" suffix, and a new log file will be created. When DataMiner upgrades, these log files will be removed.

Log entries are added in the following format in the dedicated log file per script: `1|2|3|4|5|6|7|8`

1. Date/time
1. "SLManagedAutomation"
1. Method that created the log entry
1. Log type
1. Log level
1. Thread ID
1. Script run ID
1. Message

Example: `2025/04/01 16:31:31.813|SLManagedAutomation|RunSafe|INF|0|959|473|Example message`

> [!NOTE]
>
> - In the automation script log file, you will find an indication of when the script execution started and stopped. However, this indication will be slightly different from the one you will find in the *SLAutomation.txt* log file. The one in the *SLAutomation.txt* log file will represent the total time it took for the script to run, while the one in the script log file will only take into account the C# blocks in the automation script.
> - For each entry that is logged in one of the above-mentioned script log files, an identical copy will also be logged in the *SLAutomation.txt* file. However, note that the timestamps of both entries may not be identical.

> [!TIP]
> It is also possible to add this action within a C# block in a script. For more information, see [Log](xref:Skyline.DataMiner.Automation.Engine.Log(System.String)).
