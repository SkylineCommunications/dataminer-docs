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
- [Step 5: Test the GQI result by a table](#step-5-test-the-gqi-result-by-a-table)
- [Step 6: Visualize the history data on the maps component](#step-6-visualize-the-history-data-on-the-maps-component)

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

1. Let's rename the page to *Location Tracking* and give it a nice icon.
   ![Page renaming](~/user-guide/images/Tutorial_Starlink_History_Locations_renamedPage.png)
Duplicating the page to get to this point has the advantage that you now already have the default title and header KPIs available for our selected *User terminal* (as visualized here above). Keeping the app layout uniform.

1. Remove the other components from that page as we don't need these.

1. Add a *Time range* component onto your page. This will be necessary in a later step to provide the GQI query the time window of interest to visualize the location tracking.
   ![Add Time Range](~/user-guide/images/Tutorial_Starlink_History_Locations_TimeRangeComponent.png)

1. Add a button to navigate to our newly created page. Go onto the *Overview* page and edit the panel *Terminal Info*.
   ![Edit Overview Side Panel](~/user-guide/images/Tutorial_Starlink_History_Locations_editPanel.png)

1. Duplicate one of the buttons at the bottom that brings you to the *Statistics* or *Data Usage* pages.
Configure via the settings on the button to open the newly created page *Location Tracking*.
   ![Edit Overview Side Panel](~/user-guide/images/Tutorial_Starlink_History_Locations_openPageButton.png)

> [!NOTE]
> In case you don't see the KPIs being loaded while editing, most likely you did not yet select a terminal on the map from the *Overview* page (or selected a row from the *User Terminals* page.)

## Step 4: Create the GQI query to fetch the history location data

In the next step you will configure the GQI query that will fetch the trended datapoints.

> [!NOTE]
> Before you create the new GQI query, make sure you select a terminal while being in edit mode. If the query can't resolve into a valid result, you won't be able to save the query.

1. Select the terminal *Skyline demo cruise_UT***74d101* on the map. You can find the terminal on the map docked in the harbour of Barcelona (Spain).
1. Navigate to the *QUERIES* and *Add* a new query.
1. Provide a name (example: *Location History AVG 5M*).
1. Select *Get ad hoc data* and choose *Starlink - Get History GEO Locations - AVG.5M*.
1. Link The *Element ID* to *Dropdown 29 (Overview)* containing the dynamic element reference. Select Type *Elements* and Property *Element ID*.
1. Link the *User Terminal Device ID* with the flow *Link User Terminal ID selection*, Property *Primary Key*.
1. Link the *History Time Range Start* with your new Time Range component, Property *From*.
1. Repeat the same for *History Time Range End*, Property *To*.

1. In the top-right corner, click *Start editing*.

   ![GQI: Ad hoc data](~/user-guide/images/Tutorial_Starlink_History_Locations_GQI_result.png)

## Step 5: Test the GQI result by a table

As a best practice, lets validate if our query functions correctly by taking a look via the table view.

1. Add a new component on the page of type *Table*
1. Select your new GQI (*Location History AVG 5M*) and drag it onto the table.
1. Make sure you selected the *cruise test terminal* and validate if you see data appearing in the table.
1. Changing the time span with your component should increase/decrease the number of results in the table as there could be more or less data points returned.

![GQI: Test the results](~/user-guide/images/Tutorial_Starlink_History_Locations_GQI_dataTest.png)

## Step 6: Visualize the history data on the maps component

In this final step, you will now visualize the data points on the maps component.

1. Add a new component on the page of type *Maps*
   ![Add Maps component](~/user-guide/images/Tutorial_Starlink_History_Locations_MapsComponent.png)

1. Select your new GQI (*Location History AVG 5M*) and drag it onto the map.

1. Double check the *Layer Settings* (Component Layout). *Identifier, Latitude, Longitude* should be automatically linked with your GQI outputs with similar namings.
   ![Configure the layer](~/user-guide/images/Tutorial_Starlink_History_Locations_MapsLayerSettings.png)

1. Configure the template to customize the shape and add conditional formatting: change colors and add condition for last data point to be green:
    1. The Ad Hoc data source is sampling the results to avoid too many data being displayed. The last result in the dataset will always have ID 1000.
    1. Change the color of the Ellipse to blue.
    1. Add a new conditional case: When *ID* has the value *1000*, change the color to green.
    ![Configure the layer](~/user-guide/images/Tutorial_Starlink_History_Locations_ConditinalCaseLastDataPoint.png)

1. Display a notification showing the Time stamp when a point is selected:
    1. Configure the *On click* actions
    1. Select *Show a notification*
    1. Title: *Time stamp at this location*
    1. Message: *{TimeStamp}*
    Any output columns of the GQI could be used in the placeholder.
1. Visualize the selected location when pressed:
    1. Configure a new Conditional case
    1. Criteria:  *When Is selected*
    1. Value: *Yes*
    1. Change the color of the icon.
    ![Maps Notification message](~/user-guide/images/Tutorial_Starlink_History_Locations_MapsNotifications.png)

1. Center the map to your preference by moving it to your preference and click *Save current view* in the Maps Settings.
   ![Configure the colors](~/user-guide/images/Tutorial_Starlink_History_Locations_CenterMap.png)

1. Lets take a look at the end result:

   If you have published the app, let's enjoy and take a look at the history tracking in action! Setting the time span to cover the last *8 full days*, you will now be see the whole cruise trip where our *Skyline demo cruise* sailed by. During the whole trip, the Starlink terminal was providing internet services to all people on board, while also allowing site seeing in Europe.
   When selecting a specific location of the history track, the notification will show you the time stamp when the cruise was on that exact location.

   ![Starlink Location History in DataMiner](~/user-guide/images/Tutorial_Starlink_History_Locations_Result.png)

## 🛳️ Cruise Route: Mediterranean Journey (8 Days)**

- Barcelona departure (Day 1)
- Marseille (Day 2)
- Monaco overnight (Day 2-3)
- Genoa (Day 3)
- Rome/Civitavecchia extended stay (Day 4)
- Naples (Day 5)
- Cagliari (Sardinian) (Day 6-7)
- Barcelona arrival (Day 8)

We hope we have sparked your creativity to apply even more customizations covering your use-cases and workflows. Check out the other [tutorials related to Dashboards and Low-Code Apps](xref:Dashboards_Low-Code_Apps_Tutorials) to get inspiration as to how you can further customize this app to your needs.
