---
uid: DMSScript.Script.Exe-type
---

# type attribute

Specifies the action type.

## Content Type

Contains one of the following values:

|Value | Description |
|--- |--- |
|assign|Assigns a value.|
|assigndummy|Assigns an automation script's dummy to a specific element by using a variable or a value.|
|assigntemplate|Assigns an alarm or trend template to a dummy.|
|changestate|Sets the state of a dummy in an automation script.|
|clearmemory|Clears the content of an automation script's memory file.|
|comment|Adds an extra comment to the script.|
|csharp|Executes a block of C# code.|
|else|Marks the start of the else clause of an If-Else statement.|
|endif|Marks the end of the If-Else statement.|
|exit|Terminates the automation script without delay.|
|get|Gets a parameter or memory value.|
|goto|Jumps to the specified label.|
|findinteractiveclient|Asks an interactive user to attach to the script.|
|if|Defines an If condition to make certain actions in the script depend on one or more conditions.|
|information|Generates an information event in the alarm console.|
|label|Adds a label allowing to jump to this point through a goto action.|
|logmessage|Creates a log message that will be saved in the SLAutomation.txt log file.|
|notification|Sends a notification via email or SMS.|
|report|Uploads a report to an FTP server or a shared folder.|
|script|Runs another automation script from within the current script.|
|set|Sets a parameter, memory position or variable.|
|sleep|Pauses the automation script for the specified period of time.|
|ui|Configures a dialog box asking for a user response.|
|wait|Defines a wait for a positive result.|

## Parent

[Exe](xref:DMSScript.Script.Exe)

## Remarks

Refer to [Automation script actions](xref:AutomationActions) for more information about automation script actions.
