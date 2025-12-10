---
uid: Tutorial_Alarm_Dashboard_for_your_daily_DMS_health_check
---

# Creating an alarm dashboard for a daily DMS health check

In this tutorial, you will learn how to create an alarm report dashboard that will provide a user-friendly overview of everything you need for your daily DMS health check. The tutorial will also dive into the Alarm Filtering app, which is a great tool to tackle even the worst alarm storms with a clear overview.

Expected duration: 20 minutes

> [!NOTE]
> The content and screenshots for this tutorial have been created with the DataMiner 10.4.12 web apps.

> [!TIP]
> See also: [Kata #52: Alarm Dashboards for your daily DMS Health Check](https://community.dataminer.services/courses/kata-52/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
- Version 10.3.5 or higher of the DataMiner web apps.

## Overview

- [Step 1: Install the Alarm Report package](#step-1-install-the-alarm-report-package)
- [Step 2: Install the Alarm Filtering app](#step-2-install-the-alarm-filtering-app)
- [Step 3: Install the Animal Shelter package (optional)](#step-3-install-the-animal-shelter-package-optional)
- [Step 4: Adapt the Alarm Report dashboard to filter on views](#step-4-adapt-the-alarm-report-dashboard-to-filter-on-views)
- [Step 5: Create a custom alarm template for the Animal Shelter protocol (optional)](#step-5-create-a-custom-alarm-template-for-the-animal-shelter-protocol-optional)
- [Step 6: Take ownership of an alarm](#step-6-take-ownership-of-an-alarm)
- [Step 7: Add a new customized page to the Alarms Filtering app](#step-7-add-a-new-customized-page-to-the-alarms-filtering-app)

## Step 1: Install the Alarm Report package

1. Go to <https://catalog.dataminer.services/details/5d795a13-814e-4ece-91da-049c3e8e9f38>.

1. Click the *Deploy* button to deploy the *Alarm Report* package on your DMA.

1. When the package has been deployed, [open the Dashboards app](xref:Accessing_the_web_apps) and check if you can see the *Alarm Report* dashboard.

   When the deployment is complete, this dashboard is added in the root view of your dashboards folder structure.

1. Optionally, move the dashboard to another folder:

   1. Right-click the dashboard in the pane on the left and select *Settings* in the context menu.

   1. Specify a new location and click *Apply*.

   > [!TIP]
   > For more detailed information, see [Moving a dashboard to a different folder](xref:Managing_dashboard_folders#moving-a-dashboard-to-a-different-folder)

## Step 2: Install the Alarm Filtering app

1. Go to <https://catalog.dataminer.services/details/9794badc-d191-4f36-9b96-08c415e620a4>.

1. Click the *Deploy* button to deploy the *Alarm Filtering App* package on your DMA.

1. Go to the root page of your DataMiner System, for example by clicking the *Home* button for your DMS on the [dataminer.services page](https://dataminer.services/).

1. Check if you can see the *Alarm Filtering* app listed under *Other Apps*.

   ![Alarm Filtering app](~/dataminer/images/Tutorial_Alarm_Dashboard_AlarmFilteringAppLogo.png)

## Step 3: Install the Animal Shelter package (optional)

To get to a good starting point for the rest of this tutorial, you ideally need a DataMiner System with a history of multiple alarms. If you already have an existing system available with multiple elements and views, you could use this for this tutorial, which means that you can skip this step in that case.

However, if you are for example using a **brand-new [DaaS system](xref:Creating_a_DMS_in_the_cloud)**, you will need to install a package that helps you create this starting point. You can use the **Animal Shelter** package for this, which is a Learning & Sample Solution designed specifically for this type of use case.

1. Go to <https://catalog.dataminer.services/details/e3e335a6-76c3-4254-90cb-3b2335300b0f>.

1. Click the *Deploy* button to deploy the *Animal Shelter* package on your DMA.

   Six elements will be created on the DMA, as mentioned in the description of the Catalog package.

   ![Overview of animals And parameters](~/dataminer/images/Tutorial_Alarm_Dashboard_OverviewOfAnimalsAndParameters.png)

1. If you are installing this package on a brand-new DaaS system, restart DataMiner to make sure the historical alarms are loaded correctly: In DataMiner Cube, go to *System Center* > *Agents*, and click the *(Re)start* button.

   > [!IMPORTANT]
   > Only restart DataMiner if you are using a brand-new DaaS system. In other cases, do not restart DataMiner, as this could affect other ongoing operations on your DataMiner System. For detailed information, refer to the deployment details in the *Technical Reference* section of the [package description](https://catalog.dataminer.services/details/e3e335a6-76c3-4254-90cb-3b2335300b0f).

1. In DataMiner Cube, navigate to the *DataMiner Catalog* > *Alarm Dashboard* view, and select the *REPORTS* page.

   When everything is loaded correctly, the alarm distribution will look like this:

   ![Report summary](~/dataminer/images/Tutorial_Alarm_Dashboard_ReportSummaryOnDaasAfterRestart.png)

## Step 4: Adapt the Alarm Report dashboard to filter on views

1. Go to the Dashboards app, and open the Alarm Report dashboard.

1. In the top-right corner, click *Start editing*.

   ![Start editing the dashboard](~/dataminer/images/Tutorial_Alarm_Dashboard_StartEditing.png)

1. Add a dropdown component where users will be able to select a view in the DataMiner System:

   1. Drag and drop the edge of the components to create free space in the top-right corner of the dashboard.

   1. In the *Data* pane on the right, select the *Views* data source and drag it to the empty space on your dashboard.

   1. in the component, click *Pick a visualization*, and then select the *Dropdown* visualization.

      ![Pick the Dropdown visualization](~/dataminer/images/Tutorial_Alarm_Dashboard_PickAVisualization.png)

      This should result in a dropdown box where all views are available for selection:

      ![Dropdown box with all views](~/dataminer/images/Tutorial_Alarm_Dashboard_EndResultOfDropdown.png)

1. Link the *Distribution* query in the dashboard to the dropdown component for its view filter:

   1. In the *Data* pane on the right, expand the *Queries* node and click the pencil icon next to the *Distribution* query.

   1.Click the dot next to the second item in the query to view its detailed configuration:

      ![Expand the query](~/dataminer/images/Tutorial_Alarm_Dashboard_Expand_Query.png)

   1. Click the link icon next to the input field of the view filter.

      ![Click the view filter link icon](~/dataminer/images/Tutorial_Alarm_Dashboard_ChangeOfDistributionQueryStep1.png)

   1. In the *Data* box, select the dropdown component you have just created (*Dropdown 14* in the example below, but the number in your dashboard can be different).

      ![Distribution Query Step 2](~/dataminer/images/Tutorial_Alarm_Dashboard_ChangeOfDistributionQueryStep2.png)

      In case the dropdown is not among the available options you can select, close and reopen the Dashboards app to reload the UI.

   1. The *Property* box, select *ID*.

      This way, the view ID will be passed to the ad hoc data source, which will lead to the wanted result.

1. Also link the *Alarm Events* and *States* queries to the dropdown component for their view filter, in the same way as detailed above.

The dashboard will now give you an overview of the alarm distribution and the main alarms for the selected view (similar to the *Reports* page from the previous step), so that you can easily check the health of your DMS. You can also [share the dashboard with other users as a static report by email or via dataminer.services](xref:Sharing_a_dashboard).

## Step 5: Create a custom alarm template for the Animal Shelter protocol (optional)

In the next step, you will need to be able to take ownership of an alarm. If you have installed the Animal Shelter package to have alarms in your system, you will first need to fine-tune the alarm template so that an active alarm will be created:

1. In DataMiner Cube, open the Protocols & Templates module.

1. In the *Protocols* column, select *Skyline Animal Shelter*.

1. in the *Versions* column, select *1.0.0.1*.

1. Right-click the *Default3* alarm template and select *Duplicate*.

1. Specify the name `Default3 - Labradors` and click *OK*.

   ![Duplicate an existing alarm template for Animal Shelter](~/dataminer/images/Tutorial_Alarm_Dashboard_DuplicateExistingAlarmTemplateForAnimalShelter.png)

1. Double-click the duplicated alarm template to open it.

1. Configure the alarm thresholds for the *Shelter Temperature* parameter as indicated below.

   ![Fine-tune the alarm template for Animal Shelter](~/dataminer/images/Tutorial_Alarm_Dashboard_FinetuneAlarmTemplateForAnimalShelter.png)

   This will make the alarm thresholds more strict, so that it is more likely that an alarm will be triggered.

1. Click *OK* to apply and close the window.

1. In the *Elements* column, click the *Assign Elements* button, assign the newly created alarm template to the *Labrador* elements, and click *Close*.

   ![Assign the template to the Labrador elements](~/dataminer/images/Tutorial_Alarm_Dashboard_AssingTemplateToLabradors.png)

## Step 6: Take ownership of an alarm

1. In the Alarm Console in DataMiner Cube, open the tab *Active Alarms*.

1. Right-click an alarm and select *Take ownership*

   This can for example be an alarm for a *Labrador* element that you forced by assigning the custom alarm template in the previous step.

   ![Taking ownership of an alarm](~/dataminer/images/Tutorial_Alarm_Dashboard_TakingOwnership.png)

1. In the message box, write a message (for example, `We will open a window.` for the *Shelter Temperature* alarm).

   ![Write an ownership message](~/dataminer/images/Tutorial_Alarm_Dashboard_OwnershipMessage.png)

1. Click *Take ownership* to close the dialog.

## Step 7: Add a new customized page to the Alarms Filtering app

1. Open the Alarm Filtering app that you installed in [step 2](#step-2-install-the-alarm-filtering-app).

1. Click the pencil icon in the top-right corner to start editing the app.

1. Click the + icon in the bar all the way on the left to add a new page, and name it `My Alarm Overview`.

1. In the *Data* pane on the right, expand the *Queries* node and click the + icon to add a query.

1. Configure the new query as follows:

   1. Enter the name `My own alarms`.

   1. Add the data source *Get alarms*.

   1. Add a *Filter* operator.

   1. Configure the filter with the column *Is Active* and select the *Value* checkbox.

      This way, the filter will be applied for alarms for which the *Is Active* property is equal to true.

   1. Add another *Filter* operator.

   1. Configure the second filter with the column *Owner*, filter method *equals*, and your username as the value.

      In the example below, the username is *joachim*.

   ![My Own Alarms query](~/dataminer/images/Tutorial_Alarm_Dashboard_MyOwnAlarmsQuery.png)

1. Click the pencil icon next to the query name to stop editing the query.

1. Drag the query onto the page.

1. Click *Pick a visualization* and select the *Table* visualization.

   ![Select the table visualization](~/dataminer/images/Tutorial_Alarm_Dashboard_Select_Table_Visualization.png)

1. Take a look at the end result:

   The table should now list any alarms that you have taken ownership of, including the alarm from the previous step.

   ![Table listing the alarms](~/dataminer/images/Tutorial_Alarm_Dashboard_EndResultAlarmsThatITookOwnershipOf.png)

This is just one of the possible changes you can do to the Alarm Filtering app in order to get a custom filtered overview of the alarms in your system. Check out the other [tutorials related to Dashboards and Low-Code Apps](xref:Dashboards_Low-Code_Apps_Tutorials) to get inspiration as to how you can further customize this app to your needs.
