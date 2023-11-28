---
uid: TutorialMaps
---

# Using the maps component in a low-code app

In this tutorial, you will learn how to add and configure a maps component in a low-code app, by means of an example where the maps component is used to visualize cell towers, their connections, and their coverage. Following this tutorial will take approximately 30 minutes.

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

1. In the *Layout* tab for the component expand the *Layer settings* and then expand the *Cell towers* query.

1. In the *Template* box, click *Edit*.

   This will open the template editor.
   
1. Modify the default ellipse layer to use as the background for a text shape:

   1. In the *Layers* tab on the left, select the layer and then modify the *Dimensions* on the right to position it on the bottom right of the template.

   1. Below *Show ellipse* on the right, click the color icon to select a custom color for the background.

1. Create a text layer that displays the number of transceivers on the tower:

   1. In the *Tools* tab on the left, select *Text* and then click and drag in the center pane to add a text layer.

   1. In the box below *Show text* on the right, enter the text `{Tranceivers}`.

      This placeholder text will be replaced by the content of the corresponding cell value from the query data source.

1. Create an icon layer to represent the cell towers:

   1. In the *Tools* tab on the left, select *Ellipse* and then click and drag to place the icon in the right location in the center pane.

   1. In the pane on the right, click *Icon*, enter `tower` in the filter box, and select the tower icon.

The result should look like this:

![CellTowersTemplate](~/user-guide/images/MapsCellTowersTemplate.png)

![CellTowersTemplateResult](~/user-guide/images/MapsCellTowersTemplateResult.png)

## Step 5: Add grouped markers

The templates you added in the previous step look good, but at this point the visualization still feels cluttered when you zoom out all the way. You can deal with this by adding grouped markers. For this, you will need to create additional queries to retrieve data from the *CellTowersGroups* and *CellTowersCities* JSON files you installed with the package in step 1:

To visualize these you need 2 new queries identical to the first one, but with a different file as a source. Theses queries can then be added to the maps component. You also configure a simple template for both queries that shows the *Count* of cell towers that are grouped in the markers:

1. Modify the default ellipse layer to use as the background for a text shape:

   1. Below *Show ellipse* on the right, click the color icon to select a custom color for the background.
   
1. Create a text layer that displays the number of transceivers in the group:

   1. In the *Tools* tab on the left, select *Text* and then click and drag in the center pane to add a text layer.

   1. In the box below *Show text* on the right, enter the text `{Count}`.

      This placeholder text will be replaced by the content of the corresponding cell value from the query data source.

The resulting template should look like this:

![GroupedCellTowersTemplate](~/user-guide/images/MapsGroupedCellTowersTemplate.png)

You only want to show these new markers between certain zoom levels, this can be configured in the *Advanced settings* part of the layer settings:

1. In the *Layout* tab for the component expand the *Layer settings* and then expand the *Cell towers* layer.

1. Expand a query and open the *Advanced settings* section for that query.

1. Enter the minimum and maximum zoom levels where the markers of the query should be shown on the map:

      Cell towers should be shown from 60 to 100.

      Cell towers groups should be shown from 52 to 60.

      Cell towers cities should be shown from 50 to 52.

This configuration makes more and more grouped markers appear when zooming in on the map until the cell towers themselves become visible.

Combined with the custom template, you will have created this:

![GroupedCellTowersTemplate](~/user-guide/images/MapsGroupedCellTowers.gif)

## Step 6: Visualize connections

Now that all the cell towers are visualized on the map, you can visualize the connections between them. The *CellTowers* dataset contains a *source* column with the ID of the cell tower an other tower is linked to. You can create a new query that starts from the *CellTowers* query and joins on itself based on this column. You can also create a new concatenated column of the IDs of both towers and only select the interesting columns. This results in a new dataset with a unique ID, and 2 sets of coordinates that you can visualize as lines on the map:

1. Start from the *Cell towers* query.

1. Inner join the query of another query starting from the *Cell towers* query.

1. Join the *Source* on the *Tower ID*.

1. Create a new concatenated column, names *Connection ID* from the *Tower ID* of both queries.

1. Select only the necessary columns to display the connections: *Connection ID*, *Latitude*, *Longitude*, *Latitude (2)* & *Longitude (2)*.

The resulting query will look like this:

![CellTowersConnectionsQuery](~/user-guide/images/MapsCellTowersConnectionsQuery.png)

You want to be able to show and hide these connections, so you will add them to the maps component in an other layer than the cell towers:

1. Add the query to the component in the same way as the other queries.

1. Add a new layer using the *Add layer* button in the *Layer settings*.

1. Drag & drop the *Connectionc* query to the new layer.

1. To make sure that the connections are shown underneath the markers, the layer weight of the new layer is increased by one.

1. Change the query to be visualized as connections by hovering over the query and clicking *Set as line* on the right of the query name.

   The component will try to automatically configure the dimensions and show the lines on the map.

1. Style the connections using the *Style* section.

   1. Pick a color, width & type for the lines.

After configuring the connections, their settings will look like this:

![CellTowerConnectionsSettings](~/user-guide/images/MapsCellTowersConnectionsSettings.png)

![CellTowerConnections](~/user-guide/images/MapsCellTowersConnections.png)

## Step 7: Add navigation buttons

The maps component can show (grouped) cell towers and connections. Another feature that you can add is the ability to easily navigate between different groups of markers. For this you will add a new component to our page, the grid component. This component can also visualize query results using templates. You will visualize a new query that starts from our cell tower cities and sorts them by transceiver count.

![SortedCellTowersCitiesQuery](~/user-guide/images/MapsSortedCellTowersCitiesQuery.png)

Then you can configure the grid template, via the layout settings of the component, to execute an action when clicked:

1. Modify the default text layer to use display the text bigger & centered in the template:

   1. Below *Show ellipse* on the right, change the font size with the input on the right.

   1. In the same section, change the color of the text.

   1. At the bottom of the section, use the buttons to center the text horizontally & vertically.

1. Create a transparent layer that executes actions when clicked:

   1. In the *Tools* tab on the left, select *Rectangle* and then click and drag in the center pane to add a rectangle layer.

   1. Below *Show rectangle* on the right, click the color icon to select a custom color for the background.

      Make sure the opacity is set to 0.

   1. Add the actions that should be executed using the *Configure actions* button on the right.

      1. *Pan to view* action to pan to our grouped marker. Link the latitude & longitude arguments to the corresponding columns that are fed by our grid.

      ![PanToViewAction](~/user-guide/images/MapsPanToViewAction.png)

      1. *Set zoom level* action to set the zoom level to a level where we can see the cell towers.

      ![SetZoomLevelAction](~/user-guide/images/MapsSetZoomLevelAction.png)

      Now these actions are executed whenever an item in the grid is clicked.

In the end, the component will look and function like this:

![NavigationActions](~/user-guide/images/MapsNavigationActions.gif)

## Step 8: Add an overlay

You will add an overlay to the component to visualize the coverage of all the cell towers. This can be done via a KML file that is toggled with a component action:

1. Add a new button component to the page, next to the existing grid component.

1. Configure an action on the button.

   1. In the *Settings* tab of the component, click the button next to the *On click* event.

   1. Add a *Execute component action* to toggle an overlay for the maps component.

   1. Enter `KMLs/CellTowersCoverage.kml` as a local source for the overlay. This overlay file was provided with the catalog package from step 1.

This will result in the following config:

![OverlayAction](~/user-guide/images/MapsOverlayAction.png)

![Overlay](~/user-guide/images/MapsOverlay.gif)

With step 8, the low-code app is done. The application can visualize (grouped) markers, their connections and their coverage. You have also added an easy way to navigate to different cell towers on the map.
