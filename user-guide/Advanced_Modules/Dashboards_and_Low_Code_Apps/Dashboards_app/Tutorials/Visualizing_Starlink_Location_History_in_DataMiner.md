---
uid: Tutorial_Visualizing_Starlink_Location_History_in_DataMiner
---

# Visualizing Starlink Location History in DataMiner

In this tutorial, you will explore how to leverage the Starlink Enterprise product solution to monitor and visualize real-time data as well as visualize historical location data.

Expected duration: 30 minutes

> [!NOTE]
> The content and screenshots for this tutorial have been created with the DataMiner 10.5.2 web apps.

> [!TIP]
> See also: [Kata #59: Visualizing Starlink Location History in DataMiner](https://community.dataminer.services/courses/kata-59/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
- Version 10.4.12 or higher of the DataMiner web apps.

## Overview

- [Step 1: Install the Starlink Enterprise package](#step-1-install-the-starlink-enterprise-package)
- [Step 2: Explore the app and data-sets](#step-2-explore-the-app-and-data-sets)
- [Step 3: Duplicate the app and let's begin](#step-3-duplicate-the-app-and-lets-begin)
- [Step 4: Create the GQI query to fetch the history location data](#step-4-create-the-gqi-query-to-fetch-the-history-location-data)
- [Step 5: Create a custom alarm template for the Animal Shelter protocol (optional)](#step-5-create-a-custom-alarm-template-for-the-animal-shelter-protocol-optional)
- [Step 6: Take ownership of an alarm](#step-6-take-ownership-of-an-alarm)
- [Step 7: Add a new customized page to the Alarms Filtering app](#step-7-add-a-new-customized-page-to-the-alarms-filtering-app)

## Step 1: Install the Starlink Enterprise package

1. Go to <https://catalog.dataminer.services/details/66a4c259-0fb1-4c27-aede-8bbd3a4925d0>.

1. Click the *Deploy* button to deploy the *Starlink Enterprise* package on your DMA.

   While the package is being deployed, you can follow the progress of the deployment in the [Admin app](xref:Accessing_the_Admin_app), on the *Deployments* page for your DMS. Make sure to use the *Refresh* button in the top-left corner.

1. Go to the root page of your DataMiner System, for example by clicking the *Home* button for your DMS on the [dataminer.services page](https://dataminer.services/).

1. Check if you can see the *Starlink Enterprise* app listed under *SatOps*.
   ![Apps Overview: SatOps](~/user-guide/images/Tutorial_Starlink_History_Locations_LCA.png)

   When the One-click-deployment is complete, the environment will already have the DEMO data readily available.

> [!TIP]
> In case you have a Starlink Enterprise business account: Start exploring **your own data** right-away.
>
>Follow the step-by-step guide to help you get started: [Starlink Enterprise Connector Documentation](https://docs.dataminer.services/connector/doc/Starlink_Enterprise.html#initialization).

## Step 2: Explore the app and data-sets

1. Go to DataMiner Cube and open the element *STRLE Starlink Enterprise*.
1. On the User Terminals page filter down on the terminal *Skyline demo cruise_UT***74d101*
 ![Cube: STRLE Starlink Enterprise - User Terminals](~/user-guide/images/Tutorial_Starlink_History_Locations_dataset-Cube.png)

1. Opening up the trend window you should see history data for the past 8-9 days.
Remember this data is only here for this use-case to work with on the terminal *Skyline demo cruise_UT*74d101*. Once operating with live data from your own Starlink Enterprise account you will of course have history data on all your mobile terminals.

 ![Cube: Trending - Latitude and Longitude](~/user-guide/images/Tutorial_Starlink_History_Locations_dataset-Trending.png)

## Step 3: Duplicate the app and let's begin

To get to a good starting point for the rest of this tutorial, you ideally start by working in a duplicate version of the app. This way you allow compatibility for the standard product solution track. (Alowing to deploy newer versions of the product solution that will come over time via the catalog), while still maintaining your own custom version of the app.

1. Edit your app and start of by duplicating the *Statistics* page.
Let's leave the new page as being *hidden*, as the page will only be useful if you made a user terminal selection.
   ![Duplicate Statistics page](~/user-guide/images/Tutorial_Starlink_History_Locations_duplicate-page.png)
1. Let's rename the page and give it a nice icon.
   ![Page renaming](~/user-guide/images/Tutorial_Starlink_History_Locations_renamedPage.png)
Duplicating the page to get to this point has the advantage that you now already have the default title and header KPIs available for our selected *User terminal*, keeping the app layout uniform.

1. Remove the other components from that page as we don't need these.
1. Add a *Time range* component onto your page. This will be necessary to instruct the time window of interest to visualize the location tracking.
   ![Add Time Range](~/user-guide/images/Tutorial_Starlink_History_Locations_TimeRangeComponent.png)

> [!NOTE]
> In case you don't see the KPIs being loaded, most likely you did not yet select a terminal on the map from the *Overview* page (or selected a row from the *User Terminals* page.)

## Step 4: Create the GQI query to fetch the history location data

1. Go to the Dashboards app, and open the Alarm Report dashboard.

1. In the top-right corner, click *Start editing*.

   ![Start editing the dashboard](~/user-guide/images/Tutorial_Alarm_Dashboard_StartEditing.png)

1. Add a dropdown component where users will be able to select a view in the DataMiner System:

   1. Drag and drop the edge of the components to create free space in the top-right corner of the dashboard.

   1. In the *Data* pane on the right, select the *Views* data source and drag it to the empty space on your dashboard.

   1. in the component, click *Pick a visualization*, and then select the *Dropdown* visualization.

      ![Pick the Dropdown visualization](~/user-guide/images/Tutorial_Alarm_Dashboard_PickAVisualization.png)

      This should result in a dropdown box where all views are available for selection:

      ![Dropdown box with all views](~/user-guide/images/Tutorial_Alarm_Dashboard_EndResultOfDropdown.png)

1. Link the *Distribution* query in the dashboard to the dropdown component for its view filter:

   1. In the *Data* pane on the right, expand the *Queries* node and click the pencil icon next to the *Distribution* query.

   1.Click the dot next to the second item in the query to view its detailed configuration:

      ![Expand the query](~/user-guide/images/Tutorial_Alarm_Dashboard_Expand_Query.png)

   1. Click the link icon next to the input field of the view filter.

      ![Click the view filter link icon](~/user-guide/images/Tutorial_Alarm_Dashboard_ChangeOfDistributionQueryStep1.png)

   1. In the *Data* box, select the dropdown component you have just created (*Dropdown 14* in the example below, but the number in your dashboard can be different).

      ![Distribution Query Step 2](~/user-guide/images/Tutorial_Alarm_Dashboard_ChangeOfDistributionQueryStep2.png)

      In case the dropdown is not among the available options you can select, close and reopen the Dashboards app to reload the UI.

   1. The *Property* box, select *ID*.

      This way, the view ID will be passed to the ad hoc data source, which will lead to the wanted result.

1. Also link the *Alarm Events* and *States* queries to the dropdown component for their view filter, in the same way as detailed above.

The dashboard will now give you an overview of the alarm distribution and the main alarms for the selected view (similar to the *Reports* page from the previous step), so that you can easily check the health of your DMS. You can also [share the dashboard with other users as a PDF or via dataminer.services](xref:Sharing_a_dashboard).

## Step 5: Create a custom alarm template for the Animal Shelter protocol (optional)

In the next step, you will need to be able to take ownership of an alarm. If you have installed the Animal Shelter package to have alarms in your system, you will first need to fine-tune the alarm template so that an active alarm will be created:

1. In DataMiner Cube, open the Protocols & Templates module.

1. In the *Protocols* column, select *Skyline Animal Shelter*.

1. in the *Versions* column, select *1.0.0.1*.

1. Right-click the *Default3* alarm template and select *Duplicate*.

1. Specify the name `Default3 - Labradors` and click *OK*.

   ![Duplicate an existing alarm template for Animal Shelter](~/user-guide/images/Tutorial_Alarm_Dashboard_DuplicateExistingAlarmTemplateForAnimalShelter.png)

1. Double-click the duplicated alarm template to open it.

1. Configure the alarm thresholds for the *Shelter Temperature* parameter as indicated below.

   ![Fine-tune the alarm template for Animal Shelter](~/user-guide/images/Tutorial_Alarm_Dashboard_FinetuneAlarmTemplateForAnimalShelter.png)

   This will make the alarm thresholds more strict, so that it is more likely that an alarm will be triggered.

1. Click *OK* to apply and close the window.

1. In the *Elements* column, click the *Assign Elements* button, assign the newly created alarm template to the *Labrador* elements, and click *Close*.

   ![Assign the template to the Labrador elements](~/user-guide/images/Tutorial_Alarm_Dashboard_AssingTemplateToLabradors.png)

## Step 6: Take ownership of an alarm

1. In the Alarm Console in DataMiner Cube, open the tab *Active Alarms*.

1. Right-click an alarm and select *Take ownership*

   This can for example be an alarm for a *Labrador* element that you forced by assigning the custom alarm template in the previous step.

   ![Taking ownership of an alarm](~/user-guide/images/Tutorial_Alarm_Dashboard_TakingOwnership.png)

1. In the message box, write a message (for example, `We will open a window.` for the *Shelter Temperature* alarm).

   ![Write an ownership message](~/user-guide/images/Tutorial_Alarm_Dashboard_OwnershipMessage.png)

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

   1. Configure the filter with the column *Is Active* and select the *Value* check box.

      This way, the filter will be applied for alarms for which the *Is Active* property is equal to true.

   1. Add another *Filter* operator.

   1. Configure the second filter with the column *Owner*, filter method *equals*, and your username as the value.

      In the example below, the username is *joachim*.

   ![My Own Alarms query](~/user-guide/images/Tutorial_Alarm_Dashboard_MyOwnAlarmsQuery.png)

1. Click the pencil icon next to the query name to stop editing the query.

1. Drag the query onto the page.

1. Click *Pick a visualization* and select the *Table* visualization.

   ![Select the table visualization](~/user-guide/images/Tutorial_Alarm_Dashboard_Select_Table_Visualization.png)

1. Take a look at the end result:

   The table should now list any alarms that you have taken ownership of, including the alarm from the previous step.

   ![Table listing the alarms](~/user-guide/images/Tutorial_Alarm_Dashboard_EndResultAlarmsThatITookOwnershipOf.png)

This is just one of the possible changes you can do to the Alarm Filtering app in order to get a custom filtered overview of the alarms in your system. Check out the other [tutorials related to Dashboards and Low-Code Apps](xref:Dashboards_Low-Code_Apps_Tutorials) to get inspiration as to how you can further customize this app to your needs.
