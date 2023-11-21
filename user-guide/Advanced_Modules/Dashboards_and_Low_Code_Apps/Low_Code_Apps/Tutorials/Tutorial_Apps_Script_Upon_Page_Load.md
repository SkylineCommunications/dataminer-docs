---
uid: Tutorial_Apps_Script_Upon_Page_Load
---
# Running a script upon page load

This tutorial explains how you can run an automation script every time a user is opening a page.

Expected duration: 10 minutes

## Overview

- [Step 1: Create the information event script](#step-1-create-the-information-event-script)
- [Step 2: Use the on page load event](#step-2-use-the-on-page-load-event)

## Step 1: Create the information event script

1. Navigate to the **Automation** module within Cube. Create a fresh folder labeled "Utility". Within this folder, generate a new automation script named "Generate Information Event".

1. Add a script parameter named "Message" which will contain the message that needs to be wrapped in an information event.

1. Add a C# action containing the following code:

```csharp
engine.GenerateInformation(engine.GetScriptParam("Message")?.Value ?? "No message.");
```

Your script should look like this. Verify its functionality by running the script, providing a message when prompted and check the information events for the message.

   ![Generate information event script](~/user-guide/images/GenerateInformationEventScript.png)

## Step 2: Use the on page load event

1. Make sure you're editing the app.

1. On the page for which you want to generate an information event, go to the "Events" section and expand it.

1. Click on the "Configure actions" icon to display the action editor.

   ![On page load event](~/user-guide/images/OnPageLoad.png)

1. Configure the action to run the automation script.

   - Choose the "Launch a script" action.
   - Select the "Generate information event" script.
   - Expand the "Parameters" section and fill in "IPAM - IPs visited".
   - Press "Ok" and publish the app.
   - Verify that an information event is generated upon navigating to the page.

   ![Launch a script action](~/user-guide/images/LaunchAScriptAction.png)

## Next tutorial

You can also chain actions so they're executed one after another:

- [Chaining actions](Tutorial_Apps_Chaining_Actions)

## Learning paths

This tutorial is part of the following learning path:

- [Low-Code Apps](xref:Tutorial_Apps)

## Related documentation

- [Close a panel of a low-code app](xref:LowCodeApps_event_config)
