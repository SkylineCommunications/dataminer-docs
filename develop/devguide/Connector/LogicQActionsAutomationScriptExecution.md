---
uid: LogicQActionsAutomationScriptExecution
---

# Starting an Automation script from a QAction

To start an Automation script from a QAction, the SLNet message "ExecuteScriptMessage" can be used. You can send this message using the [ExecuteScript](xref:Skyline.DataMiner.Scripting.SLProtocol.ExecuteScript(System.String)) method on SLProtocol.<!-- RN 24475 -->

```csharp
public static void Run(SLProtocol protocol)
{
    try
    {
        string[] scriptOptions = { "OPTIONS:0", "CHECKSETS:TRUE", "EXTENDED_ERROR_INFO", "DEFER:TRUE" };
        
        ExecuteScriptMessage message = new ExecuteScriptMessage
        {
            ScriptName = "Automation script",
            Options = new SA(scriptOptions),
            DataMinerID = -1,
            HostingDataMinerID = -1
        };
        
        var response = protocol.ExecuteScript(message) as ExecuteScriptResponseMessage;
        bool succeeded = response != null && !response.HadError;
        
        if (!succeeded)
        {
            // Script did not succeed.
        }
    }
    catch (Exception ex)
    {
        protocol.Log("QA" + protocol.QActionID + "|" + protocol.GetTriggerParameter() + "|Run|Exception thrown:" + Environment.NewLine + ex, LogType.Error, LogLevel.NoLogging);
    }
}
```

For more information, refer to Skyline.DataMiner.Net.Messages.

> [!NOTE]
> To start an Automation script from a QAction, the use of the Interop.SLAutomation DLL is now deprecated. The ExecuteScriptMessage should be used instead.
