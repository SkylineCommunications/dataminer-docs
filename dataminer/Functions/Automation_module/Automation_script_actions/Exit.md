---
uid: Exit
---

# Exit

Use this action to terminate an Automation script without delay:

1. Next to *Exit script with*, choose *Success* or *Failure* in the dropdown list:

   - Success: the execution of the script will be considered "successful" after it is terminated due to this action.

   - Failure: the execution of the script will be considered "failed" after it is terminated due to this action. In this case, a "Fail" message will be generated in the Alarm Console.

1. Click the underlined field after the colon and enter the message that must be displayed in the Automation logging, as well as in the Alarm Console in case of failure.

> [!NOTE]
> It is also possible to add this action within a C# block in a script. For more information, see [ExitFail](xref:Skyline.DataMiner.Automation.Engine.ExitFail(System.String)) and [ExitSuccess](xref:Skyline.DataMiner.Automation.Engine.ExitSuccess(System.String)).
