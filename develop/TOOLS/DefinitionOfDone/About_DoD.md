---
uid: About_DoD
---

# Definition of Done (DoD) Tool

## Overview

The Definition of Done Tool is a web application designed to automate and streamline the process of managing task completion workflows. It ensures that all required steps are clearly outlined, tracked, documented and completed to maintain high-quality standards in development projects. While enforcing quality, it also helps you work faster and more easily by providing you with many handy links and automated features simplifying the process of task completion and adhering to procedures.

## Purpose

This tool helps development teams by:

- **Automating task workflow management** - Ensures all required steps are completed before marking a task as done
- **Improving quality assurance** - Provides structured checklists and validation processes
- **Enhancing team collaboration** - Integrates with Microsoft Teams and other collaboration tools
- **Streamlining documentation** - Automatically generates and organizes project documentation
- **Tracking time and progress** - Built-in time registration and progress monitoring

## Key Features

### 🗂️ Task Management

- **Dynamic Checklists** - Automatically generated DoD steps based on task type and category
- **Status Tracking** - Track progress with statuses: TODO, DONE, SKIPPED
- **Guard Assignment** - Assign responsible users (guards) to specific DoD steps
- **Comments & Reasons** - Add comments and skip reasons for audit trails
- **Step Management** - Add or remove DoD steps dynamically

### ⏱️ Time Registration

- **Punch In/Out** - Track time spent on tasks with punch in/out functionality
- **Time Validation** - Automatic validation of time entries (max 12 hours, logical time ranges)
- **Cross-task Management** - Handle switching between different tasks seamlessly
- **Time Entry Editing** - Modify start/end times and add comments to time logs

### ⚡ Smart Actions

- **Microsoft Teams Integration**

  ![Teams Integration](../../images/TeamsIntegration.png)
  1. Schedule Teams meetings directly from tasks
  2. Create group chats with relevant team members for task discussions

- **OneNote Integration**

  ![Onenote Integration Create](../../images/OnenoteIntegrationCreate.png)
  ![Onenote Integration](../../images/OnenoteIntegration.png)
  - Generate structured OneNote notebooks and pages
  - Organize documentation by vendor, device, and version

- **External Tool Links**
  - Direct access to Catalog items
  - Connector documentation links (docs)
  - Device documentation access (SharePoint)
  - Admin tool integration
  - Pipeline status monitoring

### 📋 Clipboard & URL Management

- **Task URL Copying** - Quick copying of task URLs for sharing
- **Navigation** - Seamless navigation between related tools and documentation

## Supported Task Types

The tool currently supports the following task types:

- **Driver Issue** - Bug fixes and issue resolution in drivers
- **Driver Development** - New driver development tasks
- **New Driver Feature** - Adding new features to existing drivers

## How to Use the Tool

### 1. **Getting Started**

1. Navigate to the DoD Tool application
2. Sign in using your Azure AD credentials
3. Access tasks through the main interface

### 2. **Working with Tasks**

1. **Open a Task**: Fill in a task ID and click "Open" or Navigate to `/task/{taskId}`
2. **Review Checklist**: Examine the automatically generated DoD steps
3. **Update Status**: Change status of DoD steps (TODO ? DONE/SKIPPED)
4. **Assign Guards**: Select responsible team members for each DoD steps
5. **Add Comments**: Provide additional context or skip reasons

### 3. **Managing Checklist Items**

1. **Add Steps**: Click the + button to add additional DoD steps
2. **Delete Steps**: Use the delete button to remove unnecessary steps
3. **Edit Comments**: Click the pencil icon to edit comments in detail
4. **Skip Items**: Use the dropdown to skip steps with proper reasoning

## User Interface Features

### Main Interface

- **Task Header** - Quick task information and actions
- **Checklist Table** - Comprehensive view of all task requirements
- **Smart Action Bar** - One-click access to integrated tools

## Getting Support

For technical issues or feature requests:

1. Contact the development team through Teams.
2. Contact the development team through email.
