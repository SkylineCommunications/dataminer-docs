---
uid: MO_Development_Personalizing_Apps
---

# Personalizing the MediaOps applications

There are a several ways you can personalize the MediaOps Solution to adjust it to your specific needs:

- Create a custom application using the MediaOps helpers.

   With this option, you only rely on using the helpers through code, which will remain **backwards compatible** (unless breaking changes are communicated). You must implement the data sources and the application yourself.

- Edit the existing applications.

  While this is a quick and easy way to customize the applications, keep in mind that **whenever you upgrade** the MediaOps Solution, you will have to **add your customizations again** on the deployed versions of the applications.

- Create duplicate applications.

  If you create a duplicate of a MediaOps application and modify this, this has the advantage that the modifications will not be lost whenever MediaOps is upgraded. However, there is no guarantee that the duplicated application will continue to work as expected after a new version of MediaOps is deployed. In addition, your duplicated applications **will not get any of the fixes and new functionality** included in MediaOps upgrades.

## Editing the Edit Job panel of the Scheduling application

The Scheduling application makes use of variables to know which job was selected when the [Edit job panel](xref:SCH_Edit_Job) is opened (which can happen from multiple pages).

As the actions that set the variable cannot be triggered when the application is being edited, you will need to select a job in edit mode as follows: First go to the *Ops Board* page and select an option that gives you jobs (e.g., upcoming), then go to the *Hidden Job Select* page and select a job from the table, which will set the job variable and allow you to edit the *Edit Job form* panel.
