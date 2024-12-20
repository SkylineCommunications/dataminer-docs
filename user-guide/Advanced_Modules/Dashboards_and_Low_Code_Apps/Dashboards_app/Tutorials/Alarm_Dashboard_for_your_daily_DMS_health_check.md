---
uid: Tutorial_Alarm_Dashboard_for_your_daily_DMS_health_check
---

# Creating an alarm dashboard for a daily DMS health check

In this tutorial, you will learn how to create an alarm report dashboard that will provide a user-friendly overview of everything you need for your daily DMS health check. The tutorial will also dive into the Alarm Filtering app, which is a great tool to tackle even the worst alarm storms with a clear overview.

Expected duration: 20 minutes

> [!NOTE]
> The content and screenshots for this tutorial have been created with the DataMiner 10.4.12 web apps.

> [!TIP]
> See also: [Kata #52: Alarm Dashboards for your daily DMS Health Check](https://community.dataminer.services/courses/kata-52/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

## Prerequisites

- A DataMiner System that is connected to dataminer.services.
- Version 10.3.5 or higher of the DataMiner web apps.

## Overview

- [Step 1: Install the Alarm Report package](#step-1-install-the-alarm-report-package)
- [Step 2: Install the Alarm Filtering app](#step-2-install-the-alarm-filtering-app)
- [Step 3: Install the Animal Shelter package (optional)](#step-3-install-the-animal-shelter-package-optional)
- [Step 4: Adapt the Alarm Report dashboard to filter on views](#step-4-adapt-the-alarm-report-dashboard-to-filter-on-views)
- [Step 5: Create an alarm template for the Labradors (optional)](#step-5-create-an-alarm-template-for-the-labradors-optional)
- [Step 6: Take ownership of an alarm](#step-6-take-ownership-of-an-alarm)
- [Step 7: Add a new customized page to the Alarms Filtering app](#step-7-add-a-new-customized-page-to-the-alarms-filtering-app)

## Step 1: Install the Alarm Report package

1. Go to <https://catalog.dataminer.services/details/5d795a13-814e-4ece-91da-049c3e8e9f38>.

1. Click the *Deploy* button to deploy the *Alarm Report* package on your DMA.

   While the package is being deployed, you can follow the progress of the deployment in the [Admin app](xref:Accessing_the_Admin_app), on the *Deployments* page for your DMS. Make sure to use the *Refresh* button in the top-left corner.

1. Open the Dashboards app and check if you can see the *Alarm Report* dashboard.

   When the deployment is complete, this dashboard is added in the root view of your dashboard folder structure.

1. Optionally, move the dashboard to another folder:

   1. Right-click the dashboard in the pane on the left and select *Settings*.

      ![Dashboard settings](~/user-guide/images/Tutorial_Alarm_Dashboard_RelocateDashboardSettings.png)

   1. Specify a new location and click *Apply*.

      > [!TIP]
      > For more detailed information, see [Moving a dashboard to a different folder](xref:Managing_dashboard_folders#moving-a-dashboard-to-a-different-folder)

## Step 2: Install the Alarm Filtering app

1. Go to <https://catalog.dataminer.services/details/9794badc-d191-4f36-9b96-08c415e620a4>.

1. Click the *Deploy* button to deploy the *Alarm Filtering App* package on your DMA.

1. Go to root page of your DataMiner System, for example by clicking the *Home* button for your DMS on the [dataminer.services page](https://dataminer.services/).

1. Check if you can see the *Alarm Filtering* app listed under *Other Apps*.

   When the package is fully deployed, this app should be available.

   ![Alarm Filtering app](~/user-guide/images/Tutorial_Alarm_Dashboard_AlarmFilteringAppLogo.png)

## Step 3: Install the Animal Shelter package (optional)

To get to a good starting point for the rest of this tutorial, you ideally need a DataMiner System with a history of multiple alarms. If you already have an existing production or staging system available with multiple elements and views, you could use this for this tutorial, which means that you can skip this step in that case.

However, if you are for example working on a **brand-new DataMiner As A Service (DaaS) system**, you will need to install a package that helps you create this starting point. You can use the **Animal Shelter** package for this, which is a Learning & Sample Solution designed specifically for this type of use case.

1. Go to <https://catalog.dataminer.services/details/e3e335a6-76c3-4254-90cb-3b2335300b0f>.

1. Click the *Deploy* button to deploy the *Animal Shelter* package on your DMA.

   Six elements will be created on the DMA, as mentioned in the description of the Catalog package.

   ![Overview of animals And parameters](~/user-guide/images/Tutorial_Alarm_Dashboard_OverviewOfAnimalsAndParameters.png)

1. If you are installing this package on a brand-new DaaS system, restart DataMiner to make sure the historical alarms are loaded correctly: In DataMiner Cube, go to the *Agents* page in System Center, and click the *(Re)start* button.

   > [!IMPORTANT]
   > Only restart DataMiner if you are using a brand-new DaaS system. In other cases, do not restart DataMiner, as this could affect other ongoing operations on your DataMiner System. For detailed information, refer to the deployment details in the Technical Reference section of the [package description](https://catalog.dataminer.services/details/e3e335a6-76c3-4254-90cb-3b2335300b0f).

1. In DataMiner Cube, navigate to the *DataMiner Catalog* > *Alarm Dashboard* view, and select the *REPORTS* page.

   When everything is loaded correctly, the alarm distribution will look like this:

   ![Report summary](~/user-guide/images/Tutorial_Alarm_Dashboard_ReportSummaryOnDaasAfterRestart.png)

## Step 4: Adapt the Alarm Report dashboard to filter on views

1. Open the Alarm Report Dashboard

1. Click **Start editing** on the right upper corner of your screen.

   ![Start Editing](~/user-guide/images/Tutorial_Alarm_Dashboard_StartEditing.png)

1. Add a dropdown with all the views as the dropdown options.

   1. Make other components smaller, to make a free space on the top right of the typical Dashboard grid.
   1. On the right of your screen, you see the possible options of Data Sources. Drag the option Views to the empty space on your dashboard.
   1. Alter the visualization to a dropdown like indicated in the screenshot below.

      ![Start Editing](~/user-guide/images/Tutorial_Alarm_Dashboard_PickAVisualization.png)

   1. As an end result, you should have a dropdown with all views.

      ![All Views](~/user-guide/images/Tutorial_Alarm_Dashboard_EndResultOfDropdown.png)

1. Adapt the **Distribution query** to use the new Dropdown as a feed for the View Input. This query makes use of an Ad Hoc Data Source that has a View filter as one of the two inputs.

   1. Click the icon in the input field of the View Filter.

      ![Distribution Query Step 1](~/user-guide/images/Tutorial_Alarm_Dashboard_ChangeOfDistributionQueryStep1.png)

   1. Use as a Data Source the Dropdown you just created (it can be another number than the 14 of the screenshot). The Property needs to be ID, as it in that case will pass the View ID to the Ad Hoc Data Source, which will lead to the wanted result.

      ![Distribution Query Step 2](~/user-guide/images/Tutorial_Alarm_Dashboard_ChangeOfDistributionQueryStep2.png)

1. Repeat step 4 for the query **Alarm Events** and **States**.

## Step 5: Create an alarm template for the Labradors (optional)

In the KATA video, the tutorial works up to step 6, where we take ownership of an active alarm and where we filter on the ownership on Step 7.

In case you use the Animal Shelter package and want to force the creation of an active creative alarm, we can fine-tune the alarm template for the Labradors.

1. Open the Protocols & Templates module.
1. Navigate to **Skyline Animal Shelter** in the Protocols column.
1. Navigate to **1.0.0.1** in the Versions column.
1. Right-click the Default 3 alarm template to create a duplicate that can be named 'Default 3 - Labradors'.

   ![Duplicate Existing Alarm Template For Animal Shelter](~/user-guide/images/Tutorial_Alarm_Dashboard_DuplicateExistingAlarmTemplateForAnimalShelter.png)

1. Fine-tune the thresholds for the Shelter Temperature parameter. You want to make them more strict, so that it is more likely the current Shelter Temperature is out of the limits and creates an active alarm. Click *OK* to apply and close the window.

   ![Fine-tune the alarm template for Animal Shelter](~/user-guide/images/Tutorial_Alarm_Dashboard_FinetuneAlarmTemplateForAnimalShelter.png)

1. As a final step, click *Assign Elements* and assign the newly created alarm template to the Labrador elements.

   ![Assign Template to Labradors](~/user-guide/images/Tutorial_Alarm_Dashboard_AssingTemplateToLabradors.png)

## Step 6: Take ownership of an alarm

1. In the Alarm Console, open the tab **Active Alarms**.
1. Pick an alarm (like the alarm you forced to create by fine-tuning the alarm template for the labradors in the previous step).
1. Right-click the alarm and select *Take ownership*.

   ![Taking ownership of an alarm](~/user-guide/images/Tutorial_Alarm_Dashboard_TakingOwnership.png)

1. Write a message (in case of the Shelter Temperature, you could say "I'll open a window to cool down.".) in the message box.

   ![Write an ownership message](~/user-guide/images/Tutorial_Alarm_Dashboard_OwnershipMessage.png)

1. Click *Take ownership* to close the dialog.

## Step 7: Add a new customized page to the Alarms Filtering app

1. Open the Alarm Filtering App that you installed in Step 2.
1. Click the pencil icon in the right upper corner to start editing the app.
1. Create a new page and name it "My Alarm Overview".
1. Add a new query named "My own alarms"
1. Filter on the property "Is Active" equal to true
1. Filter on the property "Owner" equal to your own user name, in this example it is *joachim*.

   ![My Own Alarms Query](~/user-guide/images/Tutorial_Alarm_Dashboard_MyOwnAlarmsQuery.png)

1. After creating the query, click the pencil icon next to the query name to stop editing the query.
1. Drag the query on the page and choose Table as the Visualization.
1. You should see the alarm that you took ownership of as an end result.

   ![Alarms that I took ownership of](~/user-guide/images/Tutorial_Alarm_Dashboard_EndResultAlarmsThatITookOwnershipOf.png)

> [!TIP]
> This is just one possible adaptation you can do to the Alarm Filtering App. By checking other tutorials related to Dashboards and Low Code Apps, you can get inspiration to further enhance this app to your needs.
