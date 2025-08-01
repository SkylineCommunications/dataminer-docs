---
uid: About_DoD
---

# Definition of Done (DoD) tool

The Definition of Done tool is a web application designed to automate and streamline the process of managing task completion workflows. It ensures all required steps are clearly outlined, tracked, documented, and completed to maintain quality standards in development projects.

Additionally, the tool supports efficient work by providing convenient links and automated features that simplify task completion and adherence to procedures.

## Purpose

This tool helps development teams by:

- **Automating task workflow management** to ensure all required steps are completed before marking a task as done.

- **Improving quality assurance** through structured checklists and validation processes.

- **Enhancing team collaboration** via integration with Microsoft Teams and other collaboration tools.

- **Streamlining documentation** by automatically generating and organizing project documentation.

- **Tracking time and progress** through built-in time registration and progress monitoring features.

## Accessing the DoD tool

1. Navigate to the [DoD tool home page](https://dod.skyline.be) (available to Skyline employees only).

1. Sign in with your Azure AD credentials.

You can now access tasks through the [main interface](#user-interface).

## Using the DoD tool

### Working with tasks

1. On the DoD tool home page, enter a task ID and click the blue *Open* button, or navigate directly to `https://dod.skyline.be/task/{taskId}`.

1. Review the automatically generated DoD checklist.

1. Update the status of each DoD step by selecting *TODO*, *DONE*, or *SKIP STEP*.

1. In the *Guard* column, assign responsible team members to each step.

1. In the *Comment* column, provide additional context or reasons when skipping steps.

### Managing checklist items

- Click the "+" button to **duplicate** DoD steps and assign more guards.

- Use the delete button to **remove** any of the duplicated steps.

- **Edit** comments inline or click the pencil icon for more comfortable multiline editing.

- Select *SKIP STEP* from the *Status* dropdown menu to **skip** any of the DoD steps; with proper reasoning.

<!--To do: Review *User interface* section and further restructure page (ELS)-->

### User interface

#### Main Interface

- **Task Header** - Quick task information and actions
- **Checklist Table** - Comprehensive view of all task requirements
- **Smart Action Bar** - One-click access to integrated tools

![Definition of Done tool - Main View](~/develop/images/DoD_View.png)

- (1) Clipboard & URL management

- **Task Link** - Seamless navigation to collaboration
- **Task URL Copying** - Quick copying of task URLs for sharing

### ⏱️ 2. Time Registration

- **Punch In/Out** - Track time spent on tasks with punch in/out functionality
- **Time Validation** - Automatic validation of time entries (max 12 hours, logical time ranges)
- **Cross-task Management** - Handle switching between different tasks seamlessly
- **Time Entry Editing** - Modify start/end times and add comments to time logs

### 🛠️ 3. External Tools

- **OneNote Integration**

  - Generate structured OneNote notebooks and pages
  - Organize documentation by vendor, device, and version

- **External Tool Links**

  - Direct access to Catalog items
  - Admin tool integration
  - Connector documentation links (docs)
  - Device documentation access (SharePoint)

### 💬 4. Microsoft Teams Integration

- **Schedule Meetings** - Create Teams meetings directly from tasks
- **Group Chats** - Start group chats with relevant team members for task discussions

### ⚡ 5. Smart Actions

- **External Tool Links**

  - Pipeline status monitoring
  - Version Request

### 🗂️ Task Management

- **Dynamic Checklists** - Automatically generated DoD steps based on task type and category
- **Status Tracking** - Track progress with statuses: TODO, DONE, SKIPPED
- **Guard Assignment** - Assign responsible users (guards) to specific DoD steps
- **Comments & Reasons** - Add comments and skip reasons for audit trails
- **Step Management** - Add or remove DoD steps dynamically

## Supported Task Types

The tool currently supports the following task types:

- **Driver Development** - New connector development tasks
- **New Driver Feature** - Adding new features to existing connector
- **Driver Issue** - Bug fixes and issue resolution in existing connector

## Getting support

For technical issues or feature requests, contact the development team via Microsoft Teams or email.
