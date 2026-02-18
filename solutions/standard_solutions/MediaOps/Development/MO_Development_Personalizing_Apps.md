---
uid: MO_Development_Personalizing_Apps
---

# Personalize the applications

There are a couple of options to personalize the MediaOps solution to fit your needs better:

1. Edit the existing application

   On every installation/upgrade of the MediaOps solution, you will have to add your customizations again on the deployed version of the application.

1. Create a duplicate of the application

   When you create a duplicate of the application, you will not have the problem that the application is updated during the installation/upgrade of the MediaOps solution. However, there is no guarantee that the duplicated application will remain working after a new version of MediaOps is deployed. In addition, fixes and new functionalities in new versions of the solution will not be applied on your duplicated application.

1. Create a custom application

   With this option you only rely on using the helpers through code which will remain backwards compatible (unless breaking changes are communicated). You must implement data sources and the application yourself.

## Editing the Scheduling application

The scheduling application makes use of variables to know which job was selected (which can happen from multiple pages) when opening the [Edit job panel](xref:SCH_Edit_Job). As the actions that set the variable can't be triggered when editing the application, you can select a job from edit mode with a trick. First go to the 'Ops Board page' and select an option that gives you jobs (e.g., upcoming), then go to the 'Hidden Job Select' page and select a job from the table which will set the job variable and allow you to edit the 'Edit Job form' panel.
