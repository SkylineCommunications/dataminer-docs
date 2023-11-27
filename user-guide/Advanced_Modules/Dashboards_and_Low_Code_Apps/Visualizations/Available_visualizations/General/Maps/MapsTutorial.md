---
uid: TutorialMaps
---

# Using the maps component in a low-code app

In this tutorial, you will learn how to add and configure a maps component in a low-code app, by means of an example where the maps component is used to visualize cell towers, their connections, and their coverage.

The content and screenshots for this tutorial have been created in DataMiner version 10.4.1.

## Prerequisites

- A DataMiner System using DataMiner 10.4.1 or higher, which is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

> [!NOTE]
> Depending on your DataMiner version, you may need to activate the [ReportsAndDashboardsGQIMaps](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsgqimaps) soft-launch option to be able to use the maps component. See [Soft-launch options](xref:SoftLaunchOptions).

## Overview

- [Step 1: Set up the data](#step-1-set-up-the-data)
- [Step 2: Visualize the cell towers](#step-2-visualize-the-cell-towers)
- [Step 3: Configure the map](#step-3-configure-the-map)
- [Step 4: Style the markers](#step-4-style-the-markers)
- [Step 5: Add grouped markers](#step-5-add-grouped-markers)
- [Step 6: Visualize connections](#step-6-visualize-connections)
- [Step 7: Add navigation buttons](#step-7-add-navigation-buttons)
- [Step 8: Add an overlay](#step-8-add-an-overlay)

## Step 1: Set up the data

1. Go to <https://catalog.dataminer.services/catalog/5506>.

1. Click the *Deploy* button to deploy the *Maps tutorial* package on your DMA.

   This package contains an [ad hoc data source](xref:Get_ad_hoc_data) that can read in a JSON file and return GQI rows. It also contains three JSON files with cell tower data that will be visualized in this tutorial.

## Step 2: Visualize the cell towers

1. [Create a new low-code app](xref:Creating_custom_apps).

1. In the data pane, [create a new query](xref:Creating_GQI_query).

1. Configure the query to retrieve the cell towers from the *CellTowers.json* file using the *JSON Reader* ad hoc data source.

   ![CellTowersQuery](~/user-guide/images/MapsCellTowersQuery.png)

1. Add a [maps visualization](xref:DashboardMaps) to the page and add the query to it by [applying a data feed](xref:Apply_Data_Feed).

   The maps component will look at the columns returned by the query and will try to automatically configure the identifier, latitude, and longitude. This means that the cell towers will automatically be shown on the map. By default, the query will be in the first layer.

1. Make sure the component is selected and go to the *Layout* tab on the right.

1. Under *Layer settings*, rename the first layer to *Cell towers*:

   ![CellTowersSettings](~/user-guide/images/MapsCellTowersSettings.png)

## Step 3: Configure the map

The markers you added in the previous step are all located on a small part of the map, but the map itself shows a large part of the world by default. To make it easier for the users to locate the markers, you can set some default values and limits for the map:

1. Zoom to the area of the map that you would like to have as the default view.

1. In the *Layout* tab, go to the *Map settings* section, and click *Save current view*.

   This will set the default map center and default zoom level to what is currently displayed.

1. Under *Map zoom*, use the slider to limit the minimum zoom level.

   This will make it impossible for a user to zoom out past a certain level.

1. Under *Map bounds*, select *Enable bounds*.

   This will limit the bounds of the map, so that the user cannot pan too far away away from the markers.

   ![MapsSettings](~/user-guide/images/MapsSettings.png)

## Step 4: Style the markers

At this point, the cell tower markers are always shown in the component, but they still look very basic. To make them stand out more and display some additional information, you can edit their template:

1. In the *Layout* tab for the component expand the *Layer settings* and then expand the *Cell towers* layer.

1. In the *Template* box, click *Edit*.

   This will open the template editor.

1. Create a text layer that displays the number of transceivers on the tower:

   1. In the *Tools* tab on the left, select *Text* and then click and drag in the center pane to add a text layer.

   1. In the box below *Show text* on the right, enter the text `{Tranceivers}`.

      This placeholder text will be replaced by the content of the corresponding cell value from the query data source.

1. Create an ellipse layer as the background for the text:

   1. In the *Tools* tab on the left, select *Ellipse* and then click and drag to create an ellipse shape around the text placeholder in the center pane.

   1. Below *Show ellipse* on the right, click the color icon to select a custom color for the background.

1. Create an icon layer to represent the cell towers:

   1. In the *Tools* tab on the left, select *Ellipse* and then click and drag to place the icon in the right location in the center pane.

   1. In the pane on the right, click *Icon*, enter `tower` in the filter box, and select the tower icon.

The result should look like this:

![CellTowersTemplate](~/user-guide/images/MapsCellTowersTemplate.png)

![CellTowersTemplateResult](~/user-guide/images/MapsCellTowersTemplateResult.png)

## Step 5: Add grouped markers

The templates you added in the previous step look good, but at this point the visualization still feels cluttered when you zoom out all the way. You can deal with this by adding grouped markers. For this, you will need to create additional queries to retrieve data from the *CellTowersGroups* and *CellTowersCities* JSON files you installed with the package in step 1:

To visualize these we need 2 new queries identical to our first one, but with a different file as a source. Theses queries can then be added to the maps component. We also configure a simple template for both queries that shows the *Count* of cell towers that are grouped in the markers.

![GroupedCellTowersTemplate](~/user-guide/images/MapsGroupedCellTowersTemplate.png)

We only want to show these new markers between certain zoom levels, this can be configured in the *Advanced settings* part of the layer settings.

- Cell towers should be shown from 60 to 100.
- Cell towers groups should be shown from 52 to 60.
- Cell towers cities should be shown from 50 to 52.

This configuration makes more and more grouped markers appear when zooming in on the map until the cell towers themselves become visible.

![GroupedCellTowersTemplate](~/user-guide/images/MapsGroupedCellTowers.gif)

## Step 6: Visualize connections

Now that all the cell towers are visualized on the map, we can visualize the connections between them. The *CellTowers* dataset contains a *source* column with the ID of the cell tower an other tower is linked to. We can create a new query that starts from our *CellTowers* query and joins on itself based on this column. We also create a new concatenated column of the IDs of both towers and only select the interesting columns. This results in a new dataset with a unique ID, and 2 sets of coordinates that we can visualize as lines on the map.

![CellTowersConnectionsQuery](~/user-guide/images/MapsCellTowersConnectionsQuery.png)

We want to be able to show and hide these connections, so we will add them to the maps component in an other layer than the cell towers. This is done by first adding the query as before. Then, a new layer is added in the layer settings and the query can be dragged & dropped from the first layer onto that new layer. To make sure the connections are shown underneath our markers in the other layer, the layer weight can be set higher. By default, the query will be visualized as markers, this can be changed by hovering over the query name and clicking *Set as line*. The component will try to automatically configure the dimensions and show the lines on the map. Just as with the markers, lines can also by styled to match our application. 

![CellTowerConnectionsSettings](~/user-guide/images/MapsCellTowersConnectionsSettings.png)

![CellTowerConnections](~/user-guide/images/MapsCellTowersConnections.png)

## Step 7: Add navigation buttons

The maps component can show (grouped) cell towers and connections. Another feature that we can add is the ability to easily navigate between different groups of markers. For this we will add a new component to our page, the grid component. This component can also visualize query results using templates. We will visualize a new query that starts from our cell tower cities and sorts them by transceiver count.

![SortedCellTowersCitiesQuery](~/user-guide/images/MapsSortedCellTowersCitiesQuery.png)

Then we can configure the grid template, via the layout settings of the component, to execute an action when clicked. For this, we add a transparent rectangle shape over the entire template. We configure 2 actions that execute after each other:

1. *Pan to view* action to pan to our grouped marker. We link the latitude & longitude arguments to the corresponding columns that are fed by our grid.

   ![PanToViewAction](~/user-guide/images/MapsPanToViewAction.png)

1. *Set zoom level* action to set the zoom level to a level where we can see the cell towers.

   ![SetZoomLevelAction](~/user-guide/images/MapsSetZoomLevelAction.png)

Now these actions are executed whenever an item in the grid is clicked.

![NavigationActions](~/user-guide/images/MapsNavigationActions.gif)

## Step 8: Add an overlay

We will add an overlay to the component to visualize the coverage of all the cell towers. This can be done via a KML file that is toggled with a component action. First we add a new button component to the page, next to our grid. Then we can configure an action on the button to toggle the overlay. We will opt for the use of a local overlay file that came with the catalog package in step 1.

![OverlayAction](~/user-guide/images/MapsOverlayAction.png)

![Overlay](~/user-guide/images/MapsOverlay.gif)

With step 8, the low-code app is done. The application can visualize (grouped) markers, their connections and their coverage. We have also added an easy way to navigate to different cell towers on the map.
