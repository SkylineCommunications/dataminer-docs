---
uid: Tutorial_Apps_Script_Upon_Page_Load
---
# Running a script when a page opens

This tutorial explains how you can run an Automation script every time a user opens a page.

Expected duration: 10 minutes

## Overview

- [Step 1: Create an information event script](#step-1-create-an-information-event-script)
- [Step 2: Use the 'on page load' event](#step-2-use-the-on-page-load-event)

> [!TIP]
> See also: [Kata #8: Actions and events in a low-code app](https://community.dataminer.services/courses/kata-8/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

## Step 1: Create an information event script

1. Open DataMiner Cube and go to the **Automation** module.

1. [Create a new folder](xref:Managing_Automation_scripts#adding-a-new-automation-script-folder) with the name "Utility".

1. Within this folder, [add a new Automation script](xref:Managing_Automation_scripts#adding-a-new-automation-script) with the name "Generate Information Event".

1. Add a script parameter named "Message".

   This parameter will contain the message that needs to be mentioned in an information event.

1. Add a C# action containing the following code:

   ```csharp
   engine.GenerateInformation(engine.GetScriptParam("Message")?.Value ?? "No message.");
   ```

   Your script should look like this:

   ![Generate information event script](~/user-guide/images/GenerateInformationEventScript.png)

1. Check whether the script runs correctly:

   1. Click the *Execute* button.

   1. Provide a message to display in an information event.

   1. Check the information events for the message.

## Step 2: Use the 'on page load' event

1. Make sure you are editing the app.

1. On the page for which you want to generate an information event, go to the *Events* section and expand it.

1. Click the "Configure actions" icon to display the action editor.

   ![On page load event](~/user-guide/images/OnPageLoad.png)

1. Configure the action to run the Automation script:

   1. Select the action *Launch a script*.

   1. Select the script *Generate information event*.

   1. Expand the *Parameters* section and fill in "IPAM - IPs visited".

   1. Click *Ok*.

   ![Launch a script action](~/user-guide/images/LaunchAScriptAction.png)

1. Publish the app.

1. Navigate to the page in the app and check if an information event is generated.

## Next tutorial

You can also chain actions so they are executed one after another:

- [Chaining actions](xref:Tutorial_Apps_Chaining_Actions)

## Learning paths

This tutorial is part of the following learning path:

- [Low-Code Apps](xref:Tutorial_Apps)

## Related documentation

- [Configuring low-code app events](xref:LowCodeApps_event_config)
