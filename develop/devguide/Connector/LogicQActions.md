---
uid: LogicQActions
---

# QActions

Quick Actions (often referred to as "QActions") are used to implement custom functionality that cannot be implemented by other protocol constructs (for example, parsing a JSON response received from the device, etc.).

In the past, QActions were written in C#, JScript, or VBScript. However, recent protocols are written exclusively in C# (and VBScript is [no longer supported](xref:Software_support_life_cycles#dataminer-functionality-evolution-and-retirement)), so this section only considers C# QActions.

A QAction is defined in a connector using the [QAction](xref:Protocol.QActions.QAction) tag.

For example, the following QAction runs when a button (with parameter ID 100) is clicked, and it counts the number of times the button was clicked for the element:

```xml
<QAction id="100" name="Count Executions" encoding="csharp" triggers="100">
<![CDATA[
    using System;
    using Skyline.DataMiner.Scripting;

    public static class QAction
    {
        public static void Run(SLProtocol protocol)
        {
            int count = Convert.ToInt32(protocol.GetParameter(10));
            count++;
            protocol.SetParameter(10, count);

            protocol.Log("Number of times button was pressed on this element: " + count, LogType.Error, LogLevel.NoLogging);
        }
    }
]]>
</QAction>
```

A QAction can be given a descriptive name via the [name](xref:Protocol.QActions.QAction-name) attribute. This only serves to improve readability and has no influence on the functionality of the QAction.

The [encoding](xref:Protocol.QActions.QAction-encoding) attribute defines the language in which the QAction is written (this value is set to "csharp" for QActions written in C#).

The [triggers](xref:Protocol.QActions.QAction-triggers) attribute indicates the ID(s) of the parameter(s) that trigger the QAction. A QAction is executed on a change event of one of these parameters. (For more information about change events, see [Executing a QAction](xref:LogicQActionsExecution).)

The default entry point of the QAction is the static Run method of the QAction class. The entry point method has a parameter of type [SLProtocol](xref:Skyline.DataMiner.Scripting.SLProtocol), which serves as the link with the SLProtocol process (the QAction is executed by the SLScripting process).

The Run method in the example above increments the execution count and writes the execution count to the log file of the element running this protocol using the Log method of the SLProtocol interface (see [SLProtocol.Log](xref:Skyline.DataMiner.Scripting.SLProtocol.Log(System.String,Skyline.DataMiner.Scripting.LogType,Skyline.DataMiner.Scripting.LogLevel)) method).

> [!NOTE]
>
> - To access the log files of an element in DataMiner Cube, right-click the element in the Surveyor and select View > Log or click the apps button in the Cube navigation pane and select System Center > Logging > Elements and select the element.
> - For a complete overview of the SLProtocol interface, see [SLProtocol](xref:Skyline.DataMiner.Scripting.SLProtocol) interface. It is also possible to use the SLProtocolExt interface (see [SLProtocolExt](xref:Skyline.DataMiner.Scripting.SLProtocolExt) interface). This is an extension of the SLProtocol interface, which makes it possible to write more readable code.
> - The following example protocols are available in the [Protocol Development Guide Companion Files](https://community.dataminer.services/documentation/protocol-development-guide-companion-files/):
>
>   - SLC SDF QActions - Column Manipulation
>   - SLC SDF QActions - Triggering

## See also

DataMiner Protocol Markup Language

- [Protocol.QActions](xref:Protocol.QActions)
- [QAction@entryPoint](xref:Protocol.QActions.QAction-entryPoint) attribute
