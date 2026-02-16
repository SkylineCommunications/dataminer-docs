---
uid: Launching_and_attaching_interactive_Automation_scripts
---

# Launching and attaching interactive automation scripts

This guide explains how to reliably launch an interactive automation script in different scenarios.

## Launching a script directly (from the Cube UI)

If you want a script to show the UI when user interaction is required:

- If possible, set the [Interactivity](xref:DMSScript.Interactivity) element in the script XML:

  - *Always*: The script will always show the UI.

  - *Optional*: The UI is only shown when necessary.

  - *Auto* (default): Automatic detection is used.

    > [!NOTE]
    > The `Interactivity` element is supported from DataMiner 10.5.9/10.6.0 onwards.<!-- RN 42954 --> Older versions always use automatic detection.

- If you rely on automatic detection:

  - Make sure UI calls (e.g., `engine.ShowUI`) are clearly present in the code.

  - If a framework wraps `ShowUI`, add a hint comment (e.g., `// engine.ShowUI`).

This is why:

- Automatic detection scans the script for UI usage. If it cannot detect this, the session will not be interactive, and the script will fail to run.

- The *Always* and *Optional* options avoid detection pitfalls by explicitly defining behavior.

## Launching a script from non-UI contexts (Scheduler, Correlation, QAction, other non-interactive scripts)

If you want to show the UI to an active Cube user when prompted, use the following configuration:

```csharp
if (!engine.FindInteractiveClient("Scheduled task requires operator input to proceed.", timeoutSeconds))
{
    engine.ExitFail("No interactive client attached within the timeout. Aborting.");
}
```

This is why:

- Non-UI contexts (e.g., Scheduler) are not users. The script cannot show them the UI.

- [FindInteractiveClient](xref:Find_interactive_client) lets a user attach to the script. All active users are shown a message to attach to the script. The first user to click *Attach* sees the UI.

  ![DataMiner Cube pop-up message to attach to a script](~/develop/images/cube-interactive-client-attach-dialog.png)

> [!IMPORTANT]
> `FindInteractiveClient` will not work for a user connected to a web session.

## Auto-attaching a script to specific users from non-UI contexts

If you want a script to automatically attach to specific users without prompting, there are several possibilities, as illustrated by the following examples:

- Example: Attach immediately to users **in specified groups**.

  ```csharp
  engine.FindInteractiveClient(String.Empty, timeoutSeconds, "Operators;PowerUsers", AutomationScriptAttachOptions.AttachImmediately);
  ```

- Example: Attach immediately to a **specific user by username**.

  ```csharp
  engine.FindInteractiveClient(String.Empty, timeoutSeconds, "user:JohnSmith", AutomationScriptAttachOptions.AttachImmediately);
  ```

- Example: Attach immediately to a **specific Cube session by user cookie**.

  ```csharp
  engine.FindInteractiveClient(String.Empty, timeoutSeconds, "userCookie:C57D3BEFAD4F445B9BC37B9FAFB84ADB", AutomationScriptAttachOptions.AttachImmediately);
  ```

  > [!Note]
  > Each Cube session has its own cookie. Use the cookie to target the right session, because a user might have several Cube sessions on different devices. See [Retrieving user cookies](#retrieving-user-cookies).

### Retrieving user cookies

A QAction that was triggered by a user clicking on a button parameter will know the cookie of that user:

```csharp
string id = protocol.UserCookie;
// Formats may vary, e.g.:
// C57D3BEFAD4F445B9BC37B9FAFB84ADB
// 39D49F3E377C4B6D94AF5F4731C8052D:NO_INFORMATION
// {448BB4B8-4E55-4CB7-BCC3-848923BD19DA}:AUTOMATION:Automation script:581/120:John Smith
```

From an automation script started by a user:

```csharp
string id = engine.UserCookie;
```

From an SLNet connection:

```csharp
Guid id = protocol.GetUserConnection().ConnectionID;
// example: 448BB4B8-4E55-4CB7-BCC3-848923BD19DA
// Note: protocol.SLNet and Engine.SLNetRaw cookies are process-associated, not user-associated.
```

## Launching a script as a specific user

If you want to run a script as if launched by a specific user, so no extra script parameter is needed to pass a user cookie, there are several possibilities:

- Attach to the same user:

  ```csharp
  engine.FindInteractiveClient(String.Empty, timeoutSeconds, $"user:{engine.UserLoginName}", AutomationScriptAttachOptions.AttachImmediately);
  ```

- Attach via cookie:

  ```csharp
  engine.FindInteractiveClient(String.Empty, timeoutSeconds, $"userCookie:{engine.UserCookie}", AutomationScriptAttachOptions.AttachImmediately);
  ```

- Start the script via SLNet and pass the user cookie:

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
