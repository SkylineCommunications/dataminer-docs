---
uid: Process_Automation_App_Two
---

# Process Automation app

When you deploy Process Automation, the Process Automation app is added in DataMiner Cube.

This app supports the following features:

- Creating and configuring process definitions

- Creating activation windows

- Monitoring processes and tokens

> [!TIP]
> With the DataMiner *Low-Code Apps* module, you can also create a customized app to monitor processes. See [DataMiner Low-Code Apps](xref:Application_framework).

## Overview of the Process Automation app UI

The *Process Automation* app (or PA app) is available in the *Applications* section of the app list in the Surveyor.

### Process definitions

This is the first tab you see when opening the PA app. It displays an overview of all process definitions and allows you to select existing process definitions to expand the workspace on the right.

On the top of the page the following buttons are displayed:

- **New**: Allows you to create a new process definition.

- **Configure**: Allows you to open the *process definition configuration* wizard. Here you can configure each node in the process definition and provide information on the profile instance selection, profile instance creating, and the link with DOM field descriptors.

- **Activate**: Allows you to open the *create activation window* wizard. Here you can provide all required information to create an activation window.

- **Delete**: Allows you to delete the selected process definition.

In the bottom right corner the following buttons are displayed:

- **Edit label**: Only available when selecting an activity. Click this button to edit the label displayed underneath the activity.

- **Save all**: Only available after making changes in your workspace. Click to save all changes.

- **Discard all**: Only available after making changes in your workspace. Click to reject all changes.

### Processes

This tab provides an overview of all processes and the following related information:

- **Process ID**: Unique identifier of a process.

- **Process Name**: Human-readable identifier of a process. This is used in custom code to push tokens into the process.

- **Process Instance Name**: The name of the active activation window.

- **Process Definition**: Unique identifier of a process definition.

- **Process Instance ID**: Unique identifier of an activation window.

- **Status (Active/Not Active)**: Indicates when there is an active activation window.

- **Start Event Type**: Indicates whether there is a *None Event* or *Timer Start Event*.

- **Process Activity**: Set to *Idle* or *Busy*. Indicates whether a process is busy processing tokens.

### Active tokens

This tab provides an overview of all main tokens pushed into the various processes and the following related information: display keys [IDX], names, statuses, error states, arrival times, processing start times, processing end times, business keys, and business IDs.
