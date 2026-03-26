---
uid: Tutorial_Visualizing_Starlink_Location_History_in_DataMiner
---

# Visualizing the Starlink location history in DataMiner

In this tutorial, you will explore how to leverage the Starlink Enterprise solution to monitor and visualize both real-time data and historical location data, by means of ad hoc data sources in a DataMiner low-code app.

Expected duration: 30 minutes

> [!NOTE]
>
> - In the latest versions of the Starlink Enterprise package (v2.0.0 and higher), the *Location History Tracking* feature is already included by default. This means that you can take a look at the configuration of this feature in the *Starlink Enterprise* app and then follow this tutorial to try to build it yourself step by step, as a valuable exercise to deepen your understanding of low-code apps and map integrations.
> - The content and screenshots for this tutorial have been created with the DataMiner 10.5.3 web apps.

> [!TIP]
> See also: [Kata #59: Visualizing Starlink location history in DataMiner](https://community.dataminer.services/courses/kata-59/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
- Version 10.4.12 or higher of the DataMiner web apps.

> [!NOTE]
> If you do not use a DaaS system, and you use a DataMiner version prior to DataMiner 10.5.0 [CU1]/DataMiner 10.5.4, you will also need to activate the [ReportsAndDashboardsGQIMaps](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsgqimaps) soft-launch option to be able to use the maps component. See [Soft-launch options](xref:SoftLaunchOptions).

## Overview

- [Step 1: Install the Starlink Enterprise package](#step-1-install-the-starlink-enterprise-package)
- [Step 2: Explore the app and datasets](#step-2-explore-the-app-and-datasets)
- [Step 3: Create a duplicate app with custom components](#step-3-create-a-duplicate-app-with-custom-components)
- [Step 4: Create the GQI query to fetch the history location data](#step-4-create-the-gqi-query-to-fetch-the-history-location-data)
- [Step 5: Test the GQI result using a table](#step-5-test-the-gqi-result-using-a-table)
- [Step 6: Visualize the history data on the maps component](#step-6-visualize-the-history-data-on-the-maps-component)

## Step 1: Install the Starlink Enterprise package

1. Go to the [Starlink Enterprise](https://catalog.dataminer.services/details/66a4c259-0fb1-4c27-aede-8bbd3a4925d0) solution in the Catalog.

1. Click the *Deploy* button to deploy the package on your DMA.

1. When the package has been deployed, go to the root page of your DataMiner System, for example by clicking the *Home* button for your DMS on the [dataminer.services page](https://dataminer.services/).

1. Check if you can see the *Starlink Enterprise* app listed under *SatOps*.

   ![Apps overview: SatOps](~/dataminer/images/Tutorial_Starlink_History_Locations_LCA.png)

> [!TIP]
> The deployed app will include demo data, but in case you have a Starlink Enterprise business account, you can already start exploring **your own data** right away. Refer to the [Starlink Enterprise Connector documentation](https://docs.dataminer.services/connector/doc/Starlink_Enterprise.html#initialization) to get started.

## Step 2: Explore the app and datasets

1. In the DataMiner Cube Surveyor, navigate to *DataMiner Catalog* > *Apps & Solutions* > *Starlink Enterprise* > *Starlink API (STRLE)* and open the element *STRLE Starlink Enterprise*.

1. On the *User Terminals* page, use the filter box at the top to filter the table so that only the terminal *Skyline demo cruise_UT\*74d101* is shown.

   ![Cube: STRLE Starlink Enterprise - User Terminals](~/dataminer/images/Tutorial_Starlink_History_Locations_dataset-Cube.png)

1. Click the trend icon in the *Latitude* column.

   This will show history data for the past 8 to 9 days. This is the information that will be visualized in a more user-friendly way in a low-code app later in this tutorial.

> [!NOTE]
> The data for the *Skyline demo cruise_UT\*74d101* terminal is demo data meant for testing purposes. If you start working with live data from your own Starlink Enterprise account, you will be able to view actual history data for your own mobile terminals.

![Cube: Trending - Latitude and Longitude](~/dataminer/images/Tutorial_Starlink_History_Locations_dataset-Trending.png)

## Step 3: Create a duplicate app with custom components

To get to a good starting point for the rest of this tutorial, you will first need to create a duplicate version of the app. This way, you allow compatibility with the standard product solution track, so that you will be able to deploy newer versions of the product solution when they become available in the Catalog, while still maintaining your own custom version of the app.

1. On the root page of your DataMiner System, hover over the Starlink Enterprises icon and click *...* > *Duplicate*.

   ![Duplicate the Starlink Enterprises app](~/dataminer/images/Tutorial_Starlink_History_Locations_duplicate_app.png)

   This will create a duplicate and immediately open it in edit mode.

1. Click the *...* button for the *Statistics* page, and select *Duplicate*.

   By default, this page will be set to be hidden in the sidebar (just like the *Statistics* page). You can leave it that way, as the page will only be useful when a user terminal selection has been made.

   ![Duplicate the Statistics page](~/dataminer/images/Tutorial_Starlink_History_Locations_duplicate-page.png)

1. At the top of the page configuration pane (to the right of the sidebar), rename the page to *Location Tracking*, and then select a suitable icon.

   ![Rename the page](~/dataminer/images/Tutorial_Starlink_History_Locations_renamedPage.png)

   Because you duplicated the page, it already contains the default title and header KPIs available for the selected user terminal (as shown above), keeping the app layout uniform.

1. Remove the other components (i.e., the line & area chart and gauge components) from the page, as these will not be needed.

1. Add a *Time range* component onto your page.

   This will be necessary in a later step to provide the GQI query with the time window of interest to visualize the location tracking.

   ![Add a time range component](~/dataminer/images/Tutorial_Starlink_History_Locations_TimeRangeComponent.png)

1. Add a button to navigate to the newly created page:

   1. Go to the *Overview* page, expand the *Panels* section, and click the pencil icon to edit the panel *Terminal Info*.

      ![Edit the Terminal Info panel](~/dataminer/images/Tutorial_Starlink_History_Locations_editPanel.png)

   1. Duplicate one of the buttons at the bottom of the panel, and move the new button to be next to the existing buttons.

      ![Duplicate a button](~/dataminer/images/Tutorial_Starlink_History_Locations_duplicate_button.png)

   1. While the button is selected, go to the *Layout* pane, change *Label* to *Location Tracking*, and select a suitable icon.

   1. While the button is selected, go to the *Settings* pane and click *Configure actions*.

   1. In the *Page* box, select the new *Location Tracking* page, and then click *Ok*.

      ![Configure the button actions](~/dataminer/images/Tutorial_Starlink_History_Locations_openPageButton.png)

> [!NOTE]
> If no terminal is selected on the map on the *Overview* page or on the *User Terminals* page, no KPIs will be displayed in the panel while you edit it.

## Step 4: Create the GQI query to fetch the history location data

In this step, you will configure the GQI query that will fetch the trended data points.

1. On the *Overview* page, select the terminal *Skyline demo cruise_UT\*74d101* on the map.

   You can find the terminal on the map docked in the harbor of Barcelona (Spain).

   > [!NOTE]
   > Do not skip this step. Before you start making the new GQI query, it is important that a terminal is selected. Otherwise, the query will not be able to resolve into a valid result and you will not be able to save it.

1. In the *Data* tab on the right, expand the *QUERIES* section and click the + button to add a new query.

1. Specify a name for your query, e.g., *Location History AVG 5M*.

1. Select the data source *Get ad hoc data* and select the filter *Starlink - Get History GEO Locations - AVG.5M*.

1. Link the element ID to the dropdown containing the dynamic element reference:

   1. Click the link icon next to the *Starlink Enterprise Element ID* box:

   1. Select the following values and then click *Link*:

      - Data: *Dropdown 29 (Overview)*
      - Type: *Elements*
      - Property: *Element ID*

      ![Link the ID to the dropdown](~/dataminer/images/Tutorial_Starlink_History_Locations_Link_to_dropdown_29.png)

1. Similarly, link the *User Terminal Device ID* to the terminal ID selection:

   - Data: *Link User Terminal ID selection*
   - Property: *Primary Key*

1. Link *History Time Range Start* to the new time range component:

   - Data: *Time range X* ("X" can be different number depending on your setup; pick the one matching the component on your *Location Tracking* page)
   - Property: *From*.

1. Do the same for *History Time Range End*, with the property *To*.

1. In the top-right corner of the query, click the pencil icon to stop editing it.

   ![GQI query using ad hoc data](~/dataminer/images/Tutorial_Starlink_History_Locations_GQI_result.png)

## Step 5: Test the GQI result using a table

As a best practice, you should validate if your query works correctly. In this step, you will do so by taking a look at it in a table.

1. Make sure the cruise test terminal is still selected on the map.

1. Add a new component to the page of type *Table*.

1. Drag your new query (*Location History AVG 5M*) from the data pane onto the table.

   If no data is shown in the table at this point, double-check whether the cruise test terminal is still selected.

1. Use the time range component to change the timespan shown in the table.

   This should increase or decrease the number of results in the table, depending on your changes.

![GQI results in a table](~/dataminer/images/Tutorial_Starlink_History_Locations_GQI_dataTest.png)

## Step 6: Visualize the history data on the maps component

In this final step, you will now visualize the data points on the maps component.

1. Add a new component to the page of type *Maps*:

   ![Add a maps component](~/dataminer/images/Tutorial_Starlink_History_Locations_MapsComponent.png)

1. Drag your new query (*Location History AVG 5M*) from the data pane onto the map.

1. While the map component is selected, check the *Layer Settings* in the *Layout* pane: *Identifier*, *Latitude*, and *Longitude* should be automatically linked to your GQI outputs with similar names.

   ![Configure the layer](~/dataminer/images/Tutorial_Starlink_History_Locations_MapsLayerSettings.png)

1. Configure the template to customize the shape and add conditional formatting, using custom colors and a condition for the last data point to be green:

   1. Still in the *Layer Settings* section, in the *Template* box, click *Edit* to open the [template editor](xref:Template_Editor).

   1. In the pane on the right, set the color for the default ellipse layer to blue.

      ![Configure a custom color](~/dataminer/images/Tutorial_Starlink_History_Locations_template_custom_color.png)

   1. Under *Conditional cases* in the pane on the right, click *+ Add case* to start configuring a condition.

   1. Configure the condition so that when *ID* has the value *1000*, the color changes to green.

      The ad hoc data sources samples the results to avoid too much data being displayed. The last result in the dataset will always have ID 1000, which is why this is the value you should use here.

      ![Configure the layer](~/dataminer/images/Tutorial_Starlink_History_Locations_ConditinalCaseLastDataPoint.png)

1. Configure the template to visualize the selected location:

   1. Go to the *Tools* tab on the left, select *Icon*, and then drag and drop in the central pane to draw the area where the icon should be displayed.

   1. In the pane on the right, select the icon you want to display, e.g., a spiral.

   1. Under *Conditional cases*, click *+ Add case*.

   1. Configure the following condition:

      - Criteria:  *When Is selected*
      - Value: *Yes*
      - Result: Show icon, with a custom color (e.g., purple).

1. Display a notification showing the timestamp when a point is selected:

   1. While your additional layer is selected, in the pane on the right, click *Configure actions*, and then configure the action as follows:

      - Action: *Show a notification*
      - Title: *Timestamp at this location*
      - Message: *{TimeStamp}*

      The message uses a placeholder that can contain any of the output columns of the query.

      ![Maps notification message](~/dataminer/images/Tutorial_Starlink_History_Locations_MapsNotifications.png)

   1. Click *OK*.

1. Click *Save* to close the template editor.

1. Center the map to your preference, then go to the *Map Settings* in the *Layout* pane, and click *Save current view*.

   ![Save the current map view](~/dataminer/images/Tutorial_Starlink_History_Locations_CenterMap.png)

1. Publish the app so you can take a look at the end result.

Now you can take a look at the history tracking in action! If you set the timespan to cover the last 8 full days, you will now see the whole cruise trip of our *Skyline demo cruise*. During the whole trip, the Starlink terminal was providing internet services to all people on board, while also allowing site seeing in Europe.

When you select a specific location of the history track, the notification will show you the timestamp when the cruise was on that exact location.

![Starlink location history in DataMiner](~/dataminer/images/Tutorial_Starlink_History_Locations_Result.png)

As result, you should be able to trace the cruise route of the 8-day mediterranean journey:

- Barcelona departure (Day 1)
- Marseille (Day 2)
- Monaco overnight (Day 2-3)
- Genoa (Day 3)
- Rome/Civitavecchia extended stay (Day 4)
- Naples (Day 5)
- Cagliari (Sardinian) (Day 6-7)
- Barcelona arrival (Day 8)

Hopefully, this will have sparked your creativity to apply even more customizations covering your use cases and workflows. Check out the other [tutorials related to Dashboards and Low-Code Apps](xref:Dashboards_Low-Code_Apps_Tutorials) to get inspiration as to how you can further customize this app to your needs.
