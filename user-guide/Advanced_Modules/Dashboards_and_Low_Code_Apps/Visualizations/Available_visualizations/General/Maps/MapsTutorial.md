---
uid: TutorialMaps
---

# Using the maps component in a low-code app

In this tutorial, you will learn how to add and configure a maps component in a low-code app, by means of an example where the maps component is used to visualize cell towers, their connections and their coverage.

The content and screenshots for this tutorial have been created in DataMiner version 10.4.1.

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
Before you can begin to create the app, you will need to add some data to your system that you can visualize in the app. To do so, deploy the [Maps tutorial](https://catalog.dataminer.services/catalog/5506) from the catalog.

This package contains an [ad hoc data source](xref:Get_ad_hoc_data) that can read in a JSON file and return GQI rows. It also contains 3 JSON files with cell tower data that will be visualized in this tutorial.

> [!TIP]
> Deploying a package is very similar to deploying a DataMiner connector. See [Deploying a DataMiner connector to your system](xref:Deploying_A_DataMiner_Connector_to_your_system).

After the package is deployed, you can [create a new application](xref:Creating_custom_apps) to visualize the data.

## Step 2: Visualize the cell towers

Since the maps component can only visualize query rows, a query is needed that represents our cell towers. For this we fetch all cell towers from the *CellTowers.json* file using the *JSON Reader* ad hoc source.

![CellTowersQuery](~/user-guide/images/MapsCellTowersQuery.png)

Now that we have our query, we can add a maps component to the page and add the query to it by [applying a data feed](xref:Apply_Data_Feed). The maps component will look at the columns returned by our query and will try to automatically configure the identifier, latitude & longitude dimensions. This means that our cell towers will automatically be visible on the map. By default the query will be in the first layer, this layer can be renamed to *Cell towers*. The layer settings can be found in the layout settings of the maps component.

![CellTowersSettings](~/user-guide/images/MapsCellTowersSettings.png)

## Step 3: Configure the map

The markers we have added in step 2 are all located on a small part of the map, but the map itself shows a large part of the world by default. To make it easier for the users of our app to locate the markers, we can set some default values & limits on the map. We can set a default map center & default zoom level by navigating to what we want as a default view on the component and by then pressing the *Save current view* button in the layout settings of the component. We can also limit the minimum zoom level so the user cannot zoom out past a certain level and limit the bounds so the user cannot pan to far away away from the markers.

![MapsSettings](~/user-guide/images/MapsSettings.png)

## Step 4: Style the markers

The cell tower markers are now always visible on our component, but they are still looking very basic. We will edit their template to make them stand out more and display some useful information in them. The template of the markers can be edited via the layer settings using the template editor. The template consists of 3 shapes:

- A text shape that displays the number of transceivers on the tower. For this the *Transceivers* column from the query is used as the text value using the interpolation feature.
- An ellipse as a background for the text.
- An icon that indicates a cell tower.

![CellTowersTemplate](~/user-guide/images/MapsCellTowersTemplate.png)

![CellTowersTemplateResult](~/user-guide/images/MapsCellTowersTemplateResult.png)

## Step 5: Add grouped markers

The templates added in the previous step are looking good, but the visualization feels cluttered when zoomed out al the way. In this step we will add grouped markers. The catalog package from step 1 contains 2 more JSON files, *CellTowersGroups* & *CellTowersCities*, that represent a more grouped overview of the cell towers. To visualize these we need 2 new queries identical to our first one, but with a different file as a source. Theses queries can then be added to the maps component. We also configure a simple template for both queries that shows the *Count* of cell towers that are grouped in the markers.

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

![CellTowerConnectionsSettings](~/user-guide/images/MapsCellTowerConnectionsSettings.png)

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