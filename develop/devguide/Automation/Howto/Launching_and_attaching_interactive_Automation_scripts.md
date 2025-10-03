---
uid: Launching_and_attaching_interactive_Automation_scripts
---

# Launching and attaching interactive Automation scripts

This guide explains how to reliably launch an interactive Automation script across different scenarios.

## Launching directly (from Cube UI)

Goal: Allow the script to show UI when user interaction is required.

- If you can edit the script XML, set the [Interactivity](xref:DMSScript.Interactivity) element:
    - Always: Script must always show UI.
    - Optional: UI shown only if needed.
    - Auto (default): Use automatic detection.

- If you rely on Auto detection:
    - Make sure UI calls (e.g. engine.ShowUI) are clearly present in the code.
    - If a framework wraps ShowUI, add a hint comment (e.g. // engine.ShowUI).

Why:
- Auto scans the script for UI usage. If it cannot detect this, the session won’t be interactive and the script will fail to run.
- Always/Optional avoids detection pitfalls by explicitly defining behavior.

Notes:
- Interactivity is available from DataMiner 10.5.9/10.6.0 onward. Older versions always use automatic detection.

## Launching from non-UI contexts (Scheduler, Correlation, QAction, other non-interactive scripts)

Goal: Show the UI to an active Cube user when prompted.

Use:
```csharp
engine.FindInteractiveClient("Scheduled task requires operator input to proceed.", timeoutSeconds);
```

Why:
- Non-UI contexts (e.g. Scheduler) are not users. The script cannot show UI to them.
- [FindInteractiveClient](xref:Find_interactive_client) lets a user attach, all active users are shown a popup to attach to the script, the first to click Attach sees the UI.

## Auto-attach to a specific user from non-UI contexts

Goal: Show the UI to a specific user without prompting.

Use:
```csharp
engine.FindInteractiveClient(String.Empty, timeoutSeconds, "user:JohnSmith", AutomationScriptAttachOptions.AttachImmediately);
```

Or:
```csharp
engine.FindInteractiveClient(String.Empty, timeoutSeconds, "userCookie:C57D3BEFAD4F445B9BC37B9FAFB84ADB", AutomationScriptAttachOptions.AttachImmediately);
```

Notes:
- Each Cube client instance has a unique user cookie. Prefer the cookie for precise targeting, especially if a user has multiple Cube sessions.

### Retrieving user cookies

A QAction that was triggered by a user clicking on a button parameter will know the cookie of that user:
```csharp
string id = protocol.UserCookie;
// Formats may vary, e.g.:
// C57D3BEFAD4F445B9BC37B9FAFB84ADB
// 39D49F3E377C4B6D94AF5F4731C8052D:NO_INFORMATION
// {448BB4B8-4E55-4CB7-BCC3-848923BD19DA}:AUTOMATION:Automation script:581/120:John Smith
```

From an Automation script started by a user:
```csharp
string id = engine.UserCookie;
```

From an SLNet connection:
```csharp
Guid id = protocol.GetUserConnection().ConnectionID;
// example: 448BB4B8-4E55-4CB7-BCC3-848923BD19DA
// Note: protocol.SLNet and Engine.SLNetRaw cookies are process-associated, not user-associated.
```

### Launch as a specific user

Goal: Run the script as if launched by a specific user, so you don't need an extra script parameter to pass the user cookie.

Attach to the same user:
```csharp
engine.FindInteractiveClient(String.Empty, timeoutSeconds, $"user:{engine.UserLoginName}", AutomationScriptAttachOptions.AttachImmediately);
```
Or via cookie:
```csharp
engine.FindInteractiveClient(String.Empty, timeoutSeconds, $"user:{engine.UserCookie}", AutomationScriptAttachOptions.AttachImmediately);
```

Start the script via SLNet and pass the user cookie:
```csharp
var executeScriptMessage = new ExecuteScriptMessage
{
    ScriptName = "my interactive script",
    Options = new SA(new[]
    {
        "EXTENDED_ERROR_INFO",
        "DEFER:TRUE",
        $"USER:{userCookie}",
    }),
};

connection.SendSingleResponseMessage(executeScriptMessage);
```
