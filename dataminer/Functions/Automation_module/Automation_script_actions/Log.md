---
uid: Log
---

# Log

Use this action to have a script create a log message that will be saved in the SLAutomation.txt log file. It can either be a pre-determined message, or a message depending on a variable:

- To have a fixed message logged, click the default *Variable* field to select *Message* instead, and type a message in the next field.

- To have a message logged based on a variable, keep *Variable* selected and then click the next field to select the variable.

To find the logging, you can consult the [DataMiner logging](xref:DataMiner_logging) in DataMiner Cube or check the *SLAutomation.txt* log file in the folder `C:\Skyline DataMiner\Logging` on the DataMiner server.

> [!TIP]
> It is also possible to add this action within a C# block in a script. For more information, see [Log](xref:Skyline.DataMiner.Automation.Engine.Log(System.String)).
