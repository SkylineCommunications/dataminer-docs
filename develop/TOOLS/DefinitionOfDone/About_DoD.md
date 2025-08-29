---
uid: About_DoD
---

# Definition of Done (DoD)

The Definition of Done (DoD) platform is a web application that helps development teams ensure all necessary steps are completed before a task is marked as done. It automates and streamlines task workflows, improves quality assurance, and simplifies documentation and collaboration.

The platform supports efficient, high-quality work by offering:

- **Automated workflows** that ensure all required steps are tracked and completed.

- **Structured checklists** to improve quality assurance.

- **Integrated collaboration tools** such as Microsoft Teams.

- **Streamlined project documentation**, automatically generated and organized.

- **Progress tracking and time registration** through built-in features.

## Opening a task

1. Navigate to the [DoD home page](https://dod.skyline.be) (available to Skyline employees only).

1. Sign in with your Azure AD credentials.

1. Enter the task ID and click the blue *Open* button.

   > [!NOTE]
   > You can also open a task directly via `https://dod.skyline.be/task/{taskId}`.

## Supported task types

The DoD platform currently supports the following task types:

- **Driver Development**: New connector development.

- **New Driver Feature**: Feature additions to existing connectors.

- **Driver Issue**: Bug fixes or issue resolution for existing connectors.

## Usage

The user interface consists of three main sections:

![DoD UI](~/develop/images/DoD_UI.png)

- [Header bar](#the-dod-tool-header-bar) (1): Displays key task information and several action buttons.

- [Checklist table](#checklist-table) (2): Displays required steps to complete the task.

- [Smart action column](#smart-actions) (3): Offers one-click access to integrated tools.

### Header bar

The header bar contains the following items, from left to right:

| Item | Description |
|--|--|
| Task name | The name of the currently opened task. |
| ![External link](~/develop/images/DoD_External_Link.png) | Click this icon (or the task name) to open the task in Collaboration. |
| ![Share URL](~/develop/images/DoD_Share_URL.png) | Click this icon to copy the task URL to your clipboard for easy sharing. |
| ![Punch in](~/develop/images/DoD_Punch_in.png) | Use this button to start or stop tracking time for the current task. While tracking is active, the time spent on the task is logged automatically. You can edit time entries, add comments, and switch between tasks without losing time data. Time entries are validated automatically to ensure logical start and end times, with a maximum duration of 12 hours. |
| ![OneNote](~/develop/images/DoD_OneNote.png) | Click this icon to generate or access a OneNote notebook for the current task, structured automatically with pages organized by vendor, device, and version. |
| ![Catalog](~/develop/images/DoD_Catalog.png) | Click this icon to access the Catalog item linked to this task. |
| ![Admin tool](~/develop/images/DoD_Admin_Tool.png) | Click this icon to open the Connector Admin tool. |
| ![Connector documentation](~/develop/images/DoD_Connector_Documentation.png) | Click this icon to open the relevant connector documentation (DataMiner Docs). |
| ![Device documentation](~/develop/images/DoD_Device_Documentation.png) | Click this icon to access the relevant device documentation on SharePoint. |
| ![Teams meeting](~/develop/images/DoD_Teams_Meeting.png) | Click this icon to create a Microsoft Teams meeting. The meeting is automatically titled with the task name, and a task description is generated that includes the task and DoD links. Guards assigned to the task are added as required attendees. |
| ![Teams chat](~/develop/images/DoD_Teams_Chat.png) | Click this icon to create a Microsoft Teams chat with the guards assigned to the current task. |

### Checklist table

The checklist table displays the *Definition of Done* steps for the current task. Each row in the table represents a DoD step and includes the following columns:

- **Step**: Automatically generated DoD steps based on the task type and category.

- **Status**: Set the status of each step to *TO DO*, *DONE*, or *SKIPPED*.

  > [!NOTE]
  > Skipped steps require a comment to justify why they were skipped.

- **Guard**: Assign the team member responsible for confirming that the step was properly done.

- **Comment**: Add context or explain why steps were skipped. Comments can be edited inline or using the pencil icon for multiline input. Comments and skip justifications are stored to maintain a clear audit trail.

- **Action**: One-click access to integrated tools, if applicable for the step. For more information, see [Smart actions](#smart-actions).

You can manage checklist items as follows:

- Click the "+" button to **duplicate** a step and assign additional guards.

- Use the *Delete* button to **remove** duplicated steps.

- Click the pencil icon to **edit** comments in a multiline editor.

- Select *SKIPPED* from the *Status* dropdown menu to **skip** a step, with proper reasoning.

### Smart actions

When available, the *Actions* column includes smart action icons. These provide quick access to tools relevant to the task steps:

| Action icon | Description |
|--|--|
| ![Version request](~/develop/images/DoD_Version_Request.png) | Click this icon to create a new version request for the associated connector. |
| ![Pipeline status monitoring](~/develop/images/DoD_CICD.png) | Click this icon to view the status of the CI/CD pipeline linked to the connector version. |

## Getting support

For technical issues or feature requests, contact the development team via Microsoft Teams or email using the **Feedback** button.
