---
uid: TutorialMaps
---

# Using the maps component in a low-code app

In this tutorial, you will learn how to add and configure a maps component in a low-code app, by means of an example where the maps component is used to visualize cell towers, their connections, and their coverage.

Expected duration: 30 minutes.

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

   ![Save current view](~/user-guide/images/MapsTutorialSaveCurrentView.png)

   This will set the default map center and default zoom level to what is currently displayed.

1. Under *Map zoom*, use the slider to limit the minimum zoom level.

   This will make it impossible for a user to zoom out past a certain level.

1. Under *Map bounds*, select *Enable bounds*.

   This will limit the bounds of the map, so that the user cannot pan too far away away from the markers.

   ![MapsSettings](~/user-guide/images/MapsSettings.png)

## Step 4: Style the markers

At this point, the cell tower markers are always shown in the component, but they still look very basic. To make them stand out more and display some additional information, you can edit their template:

1. In the *Layout* tab for the component, expand the *Layer settings* and then expand the *Cell towers* query.

1. In the *Template* box, click *Edit*.

   This will open the template editor.

1. Modify the default ellipse layer to use as the background for a text shape:

   1. In the *Layers* tab on the left, select the layer and then modify the *Dimensions* on the right to position it at the bottom right of the template.

   1. Below *Show ellipse* on the right, click the color icon to select a custom color for the background.

      ![Custom color selection for ellipse](~/user-guide/images/MapsTutorialEllipseColor.png)

1. Create a text layer that displays the number of transceivers on the tower:

   1. In the *Tools* tab on the left, select *Text* and then click and drag in the center pane to add a text layer.

   1. In the box below *Show text* on the right, enter the text `{Tranceivers}`.

      ![Placeholder text](~/user-guide/images/MapsTutorialTranceiversText.png)

      This placeholder text will be replaced by the content of the corresponding cell value from the query data source.

1. Create an icon layer to represent the cell towers:

   1. In the *Tools* tab on the left, select *Icon* and then click and drag to place the icon in the right location in the center pane.

   1. In the pane on the right, click *Icon*, enter `tower` in the filter box, and select the tower icon.

      ![Tower icon](~/user-guide/images/MapsTutorialTowerIcon.png)

The result should look like this:

![CellTowersTemplate](~/user-guide/images/MapsCellTowersTemplate.png)

![CellTowersTemplateResult](~/user-guide/images/MapsCellTowersTemplateResult.png)

## Step 5: Add grouped markers

The templates you added in the previous step look good, but at this point the visualization still feels cluttered when you zoom out all the way. You can deal with this by adding grouped markers. For this, you will need to create additional queries to retrieve data from the *CellTowersGroups* and *CellTowersCities* JSON files you installed with the package in step 1.

1. In the data pane, [create a new query](xref:Creating_GQI_query) named *Cell tower groups*, and configure it to retrieve the cell towers from the *CellTowersGroups.json* file using the *JSON Reader* ad hoc data source.

1. Create another query similar to the previous one, but this time use the name *Cell tower cities* and the *CellTowersCities.json* file.

1. Drag the two new queries to the maps component.

1. Configure a template for both queries that shows the *Count* of cell towers that are grouped in the markers:

   1. Modify the default ellipse layer to use as the background for a text shape:

      1. In the *Layers* tab on the left, select the layer.

      1. Below *Show ellipse* on the right, click the color icon to select a custom color for the background.

         ![Custom color selection for ellipse](~/user-guide/images/MapsTutorialEllipseColor2.png)

   1. Create a text layer that displays the number of transceivers in the group:

      1. In the *Tools* tab on the left, select *Text* and then click and drag in the center pane to add a text layer.

      1. In the box below *Show text* on the right, enter the text `{Count}`.

         This placeholder text will be replaced by the content of the corresponding cell value from the query data source.

   The resulting template should look like this:

   ![GroupedCellTowersTemplate](~/user-guide/images/MapsGroupedCellTowersTemplate.png)

1. Configure the new markers to only be shown between certain zoom levels:

   1. In the *Layout* tab for the component, expand the *Layer settings* and then expand the *Cell towers* layer.

   1. Expand a query and open the *Advanced settings* section for that query.

   1. Enter the minimum and maximum zoom levels where the markers of the query should be shown on the map:

      - Cell towers should be shown from 60 to 100.

        ![Cell towers zoom level](~/user-guide/images/MapsTutorialZoomLevel.png)

      - Cell towers groups should be shown from 52 to 60.

      - Cell towers cities should be shown from 50 to 52.

When you zoom in on the map, more and more grouped markers should now be shown, until the cell towers themselves become visible:

![GroupedCellTowersTemplate](~/user-guide/images/MapsGroupedCellTowers.gif)

## Step 6: Visualize connections

Now that all the cell towers are shown on the map, you can visualize the connections between them:

1. Create a new query.

1. Select the data source *Start from* and the query *Cell towers*.

   This *CellTowers* data set contains a *source* column with the ID of the cell tower that another tower is linked to.

1. Create a new query that starts from the *CellTowers* query and joins itself based on this column:

   1. As the name of the query, specify *Connections*.

   1. Select the operator *Join* and the type *Inner*.

   1. Below the *Join* operator, select the data source *Start from* and the query *Cell towers*.

   1. Select the fields *Source* and *Tower ID*.

1. Create a new concatenated column of the IDs of both towers:

   1. Continuing from the same query, add the operator *Column manipulations* with the manipulation method *Concatenate*.

   1. Select the column *Tower ID*.

   1. In the *Format* box, specify `{0}/{1}`.

   1. In the *New column name* box, specify *Connection ID*.

1. Select only the necessary columns to display the connections:

   1. Continuing from the same query, add the operator *Select*.

   1. Make sure only the following columns are selected: *Connection ID*, *Latitude*, *Longitude*, *Latitude (2)*, and *Longitude (2)*.

   This will result in a new data set with a unique ID and two sets of coordinates that you can visualize as lines on the map:

   ![CellTowersConnectionsQuery](~/user-guide/images/MapsCellTowersConnectionsQuery.png)

1. To be able to show and hide these connections, add them to the maps component in another layer than the cell towers:

   1. Drag the query from the *Data* pane to the component.

   1. In the *Layout* pane, under *Layer settings*, click *Add layer* to add a new layer.

   1. Drag and drop the *Connections* query from the top layer to the new layer.

   1. To make sure that the connections are shown underneath the markers, increase the weight of the new layer by one.

   1. To make sure the query is visualized as connection lines, hover over the query and click *Set as line* to the right of the query name.

      ![Set as line](~/user-guide/images/MapsTutorialConnectionsLine.png)

      The component will try to automatically configure the dimensions and show the lines on the map.

   1. In the *Style* section, pick a color, width, and type for the lines.

This is what the configuration of the connections will look like:

![CellTowerConnectionsSettings](~/user-guide/images/MapsCellTowersConnectionsSettings.png)

This will be the result in the maps component:

![CellTowerConnections](~/user-guide/images/MapsCellTowersConnections.png)

## Step 7: Add navigation buttons

Now that your map will show the grouped cell towers and connections, you should add a way to easily navigate between different groups of markers. For this, you can add a grid component that visualizes another query:

1. In the visualizations pane, in the *Other* section, select the grid visualization and drag it to the area below your map component.

1. In the *Data* pane, create a query that starts from the cell tower cities and sorts them by transceiver count:

   ![SortedCellTowersCitiesQuery](~/user-guide/images/MapsSortedCellTowersCitiesQuery.png)

1. Drag the new query to the grid component.

1. Go to the *Layout* pane for the component, and click *Edit* in the *Item templates* section.

1. Configure the template as follows:

   1. Modify the default text layer to display the text in a larger font and center it in the template:

      1. Below *Show text* on the right, change the font size:

         ![Change the font size](~/user-guide/images/MapsTutorialTextFont.png)

      1. In the same section, change the color of the text:

         ![Change the text color](~/user-guide/images/MapsTutorialTextColor.png)

      1. Use the buttons at the bottom to center the text horizontally and vertically:

         ![Change the text alignment](~/user-guide/images/MapsTutorialTextAlignment.png)

   1. Create a transparent layer that executes actions when clicked:

      1. In the *Tools* tab on the left, select *Rectangle* and then click and drag in the center pane to add a rectangle layer.

      1. Below *Show rectangle* on the right, select a custom color for the background, making sure the opacity is set to 100:

         ![Select the background color](~/user-guide/images/MapsTutorialRectangleColor.png)

      1. Click the *Configure actions* button on the right to add the actions that should be executed when an item in the grid is clicked:

         1. Select *Execute component action* and *Pan to view* to pan to the grouped marker.

         1. Link the latitude and longitude arguments to the corresponding columns that are fed by the grid:

            ![PanToViewAction](~/user-guide/images/MapsPanToViewAction.png)

         1. Click *Add action* at the bottom to add another action.

         1. Select *Execute component action* and *Set zoom level* to set the zoom level to a level where the cell towers are visible:

            ![SetZoomLevelAction](~/user-guide/images/MapsSetZoomLevelAction.png)

         1. Click *Ok* to close the actions configuration and *Save* to save the template.

In the end, the component should look and function like this:

![NavigationActions](~/user-guide/images/MapsNavigationActions.gif)

## Step 8: Add an overlay

As a final touch to finish the configuration, you can now add an overlay to the component to visualize the coverage of all the cell towers. This can be done via a KML file that is toggled with a component action:

1. In the visualizations pane, in the *Other* section, select the button visualization and drag it below your maps component, to the right of the grid component.

1. Configure an action for the button:

   1. In the *Settings* tab for the component, click the button next to *On click*.

   1. Select *Execute component action* and *Toggle overlay*.

   1. Enter `KMLs/CellTowersCoverage.kml` as a local source for the overlay.

      This overlay file is included in the package you deployed in step 1.

   ![OverlayAction](~/user-guide/images/MapsOverlayAction.png)

You should now have a fully functioning application that can visualize (grouped) markers, their connections, and their coverage, and that allows users to easily navigate to the different cell towers on the map.

![Overlay](~/user-guide/images/MapsOverlay.gif)
