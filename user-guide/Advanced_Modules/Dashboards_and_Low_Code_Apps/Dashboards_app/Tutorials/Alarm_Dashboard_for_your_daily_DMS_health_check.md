---
uid: Tutorial_Alarm_Dashboard_for_your_daily_DMS_health_check
---

# Alarm Dashboard for your daily DMS health check

In this tutorial, you’ll learn how to create an Alarm Report Dashboard that’s not just sleek and shareable but also gives you exactly what you need for your daily DMS health check.

Moreover, we’ll dive into the Alarm Filtering app—your trusty tool to sail through even the wildest alarm storms while keeping a clear overview.

Expected duration: 20 minutes

> [!NOTE]
> The content and screenshots for this tutorial have been created with the DataMiner 10.4.12 web apps.

> [!TIP]
> See also: [Kata #52: Alarm Dashboards for your daily DMS Health Check](https://community.dataminer.services/courses/kata-52/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

## Prerequisites

- A DataMiner System that is connected to dataminer.services.
- Version 10.3.5 or higher of the DataMiner web apps.

## Overview

- [Alarm Dashboard for your daily DMS health check](#alarm-dashboard-for-your-daily-dms-health-check)
  - [Prerequisites](#prerequisites)
  - [Overview](#overview)
  - [Step 1: Install the Alarm Report Package](#step-1-install-the-alarm-report-package)
  - [Step 2: Install the Alarm Filtering App](#step-2-install-the-alarm-filtering-app)
  - [Step 3: Optionally install the Animal Shelter Package](#step-3-optionally-install-the-animal-shelter-package)
  - [Step 4: Adapt the Alarm Report Dashboard so that it can filter on Views](#step-4-adapt-the-alarm-report-dashboard-so-that-it-can-filter-on-views)
  - [Step 5: Optionally create a new specific alarm template for the Labradors](#step-5-optionally-create-a-new-specific-alarm-template-for-the-labradors)
  - [Step 6: Taking ownership of an alarm](#step-6-taking-ownership-of-an-alarm)
  - [Step 7: Add a new customized page to the Alarms Filtering App](#step-7-add-a-new-customized-page-to-the-alarms-filtering-app)
  - [Learning paths](#learning-paths)
  - [Related documentation](#related-documentation)

## Step 1: Install the Alarm Report Package

1. Go to <https://catalog.dataminer.services/details/5d795a13-814e-4ece-91da-049c3e8e9f38>.

1. Click the *Deploy* button to deploy the *Alarm Report* package on your DMA.

   This package will install the Alarm Report Dashboard that we will work with later on. It will by default be created in the root view of your Dashboard folder structure. 

   > [!TIP]
   > If you want to relocate this dashboard to another folder, you can right click on the Alarm Report name and click on Settings.
   > ![Relocated Dashboard Settings](~/user-guide/images/Tutorial_Alarm_Dashboard_RelocateDashboardSettings.png)
   >
   > In the new panel, you can edit the Location as indicated in the section [Move a dashboard to a different folder](xref:Managing_dashboard_folders#moving-a-dashboard-to-a-different-folder)

## Step 2: Install the Alarm Filtering App

1. Go to <https://catalog.dataminer.services/details/9794badc-d191-4f36-9b96-08c415e620a4>.

1. Click the *Deploy* button to deploy the *Alarm Filtering App* package on your DMA.

As a result you should see the Alarm Filtering App appearing on the home screen of your DataMiner Web Services, under the section "Other Apps".

![Alarm Filtering App](~/user-guide/images/Tutorial_Alarm_Dashboard_AlarmFilteringAppLogo.png)

## Step 3: Optionally install the Animal Shelter Package

> [!NOTE]
> This is an optional step.

To get to a good starting point for the rest of this tutorial, you ideally need a DataMiner System with a history of multiple alarms. In case of an already longer existing Production or Staging system, with multiple elements and views, this is probably the case. 

In case you are working on a _brand new_ DataMiner As A Service (DaaS) system, this is not the case, and you might want to install a package that helps to create this starting point.

In this case, it is advised to proceed with the following steps to install the **Animal Shelter** Package, which is a _learning &amp; solution_ specifically created for this type of use cases.

1. Go to <https://catalog.dataminer.services/details/e3e335a6-76c3-4254-90cb-3b2335300b0f>.

2. Click the *Deploy* button to deploy the *Animal Shelter* package on your DMA. As a result, 6 elements will be created, as described in the Readme-page of the Catalog package.

![Overview Of Animals And Parameters](~/user-guide/images/Tutorial_Alarm_Dashboard_OverviewOfAnimalsAndParameters.png)

1. Restart your DataMiner Agent to make sure the historical alarms are loaded in correctly.

   > [!WARNING]
   > Please check the Deployment Details on the Technical Reference section of the [Catalog package Readme](https://catalog.dataminer.services/details/e3e335a6-76c3-4254-90cb-3b2335300b0f). The restart of the DataMiner System  is only recommended in the very specific case of a _brand new DaaS_. In other cases, it's even not recommended as it can have an impact on any other ongoing operations on your DataMiner System. 

2. Please double check by clicking on the view **Alarm Dashboard** and more specifically on the **REPORTS** section. If everything was loaded in correctly, the alarm distribution should look like indicated below.

![Report Summary](~/user-guide/images/Tutorial_Alarm_Dashboard_ReportSummaryOnDaasAfterRestart.png)

## Step 4: Adapt the Alarm Report Dashboard so that it can filter on Views

1. Open the Alarm Report Dashboard

2. Click on **Start editing** on the right upper corner of your screen.

   ![Start Editing](~/user-guide/images/Tutorial_Alarm_Dashboard_StartEditing.png)

3. Add a dropdown with all the views as the dropdown options.

   1. Make other components smaller, to make a free space on the top right of the typical Dashboard grid.
   2. On the right of your screen, you see the possible options of Data Sources. Drag the option Views to the empty space on your dashboard.
   3. Alter the visualization to a dropdown like indicated in the screenshot below.

      ![Start Editing](~/user-guide/images/Tutorial_Alarm_Dashboard_PickAVisualization.png)

   4. As an end result, you should have a dropdown with all views.

      ![All Views](~/user-guide/images/Tutorial_Alarm_Dashboard_EndResultOfDropdown.png)

4. Adapt the **Distribution query** to use the new Dropdown as a feed for the View Input. This query makes use of an Ad Hoc Data Source that has a View filter as one of the two inputs.

   1. Click on the icon on the input field of the View Filter.

      ![Distribution Query Step 1](~/user-guide/images/Tutorial_Alarm_Dashboard_ChangeOfDistributionQueryStep1.png)

   2. Use as a Data Source the Dropdown you just created (it can be another number than the 14 of the screenshot). The Property needs to be ID, as it in that case will pass the View ID to the Ad Hoc Data Source, which will lead to the wanted result.

      ![Distribution Query Step 2](~/user-guide/images/Tutorial_Alarm_Dashboard_ChangeOfDistributionQueryStep2.png)

5. Repeat step 4 for the query **Alarm Events** and **States**.

## Step 5: Optionally create a new specific alarm template for the Labradors

In the KATA video, the tutorial works up to step 6, where we take ownership of an active alarm and where we filter on the ownership on Step 7.

In case you use the Animal Shelter package and want to force the creation of an active creative alarm, we can fine-tune the alarm template for the Labradors.

1. Open the _Protocols &amp; Templates_ module.
1. Navigate to **Skyline Animal Shelter** in the Protocols column.
1. Navigate to **1.0.0.1** in the Versions column.
1. Right-click on the Default 3 Alarm template to create a duplicate that can be named 'Default 3 - Labradors'.

   ![Duplicate Existing Alarm Template For Animal Shelter](~/user-guide/images/Tutorial_Alarm_Dashboard_DuplicateExistingAlarmTemplateForAnimalShelter.png)

1. Fine-tune the thresholds for the Shelter Temperature parameter. You want to make them more strict, so that it is more likely the current Shelter Temperature is out of the limits and creates an active alarm. Click on OK to Apply and close the window.

   ![Finetune Alarm Template Alarm Template For Animal Shelter](~/user-guide/images/Tutorial_Alarm_Dashboard_FinetuneAlarmTemplateForAnimalShelter.png)

1. As a final step, click on **Assign Elements...** and assign the newly created Alarm Template to the Labrador elements.

   ![Assign Template to Labradors](~/user-guide/images/Tutorial_Alarm_Dashboard_AssingTemplateToLabradors.png)

## Step 6: Taking ownership of an alarm

1. In the Alarm Console, open the tab **Active Alarms**.
2. Pick an alarm (like the alarm you forced to create by fine-tuning the alarm template for the labradors in the previous step).
3. Right-click on the alarm to open the context menu and click on **Take ownership...**.

   ![Taking ownership of an alarm](~/user-guide/images/Tutorial_Alarm_Dashboard_TakingOwnership.png)

4. Write a message (in case of the Shelter Temperature, you could say "I'll open a window to cool down.".) in the message box.

   ![Write an ownership message](~/user-guide/images/Tutorial_Alarm_Dashboard_OwnershipMessage.png)

5. Click on Take ownership and the dialog will close.

## Step 7: Add a new customized page to the Alarms Filtering App

1. Open the Alarm Filtering App that you installed in Step 2.
2. Click on the pencil on the right upper corner to start editing the app.
3. Create a new page and name it "My Alarm Overview".
4. Add a new query named "My own alarms"
5. Filter on the property "Is Active" equal to true
6. Filter on the property "Owner" equal to your own user name, in this example it is _joachim_.

   ![My Own Alarms Query](~/user-guide/images/Tutorial_Alarm_Dashboard_MyOwnAlarmsQuery.png)

7. After creating the query, click on the pencil icon next to the query name to stop the editing of the query.
8. Drag the query on the page and choose Table as the Visualization.
9. You should see the alarm that you took ownership of as an end result.

   ![Alarms that I took ownership of](~/user-guide/images/Tutorial_Alarm_Dashboard_EndResultAlarmsThatITookOwnershipOf.png)

> [!TIP]
> This is just one possible adaptation you can do to the Alarm Filtering App. By checking other tutorials related to Dashboards and Low Code Apps, you can get inspiration to further enhance this app to your needs.

## Learning paths

This tutorial is part of the following learning path:

- [Dashboards](xref:Tutorial_Dashboards)

## Related documentation

- [Alarm Templates](xref:About_alarm_templates)
