---
uid: Tracking_the_progress_of_automation_scripts
description: "Use the PROGRESS option of the ExecuteScriptMessage to receive ScriptProgressEventMessage notifications when an automation script starts, progresses, and finishes."
---

# Tracking the progress of automation scripts

When you start an automation script via SLNet, you can add the `PROGRESS` option to the `ExecuteScriptMessage` to receive `ScriptProgressEventMessage` notifications about that script. This is especially useful when you run a script asynchronously using the `DEFER:TRUE` option, as it allows the client to track when the script starts and finishes.

> [!NOTE]
> From DataMiner 10.7.1/10.8.0 onwards, the `PROGRESS` option is supported for both interactive and non-interactive scripts.<!-- RN 46778 --> In earlier versions, progress notifications are only available for interactive scripts.

## Tracking a script

1. Subscribe to `ScriptProgressEventMessage` events **before** sending the `ExecuteScriptMessage`.

1. Send the `ExecuteScriptMessage` with the `PROGRESS` option, and keep the `ScriptID` from the `ExecuteScriptResponseMessage`.

1. Use the script ID and the DataMiner ID to identify the events that belong to this script execution.

```csharp
var executeMessage = new ExecuteScriptMessage("MyScript")
{
    DataMinerID = dmaId,
    Options = new SA(new[] { "DEFER:TRUE", "PROGRESS" })
};

var response = (ExecuteScriptResponseMessage)connection.HandleSingleResponseMessage(executeMessage);
var scriptId = response.ScriptID;
```

## Notifications

For scripts executed with the `PROGRESS` option, a `ScriptProgressEventMessage` can indicate the following:

| Notification | Description |
|--------------|-------------|
| Started | The script has started executing. |
| Completed | The script has finished executing. The notification includes the execution result. |
| RunStatus or DelayInfo | Additional execution status information, for example when the script is waiting for locked resources or when an error occurs. |
| Progress | Progress that is explicitly communicated by the script. |

For interactive scripts that are executed with the `INTERACTIVE` option, the client can additionally receive the following notifications:

| Notification | Description |
|--------------|-------------|
| InteractiveUI | The script is paused and requires input from the client. |
| Detached | The client has detached from the script. |
| Hidden | The client interface should be hidden. |
