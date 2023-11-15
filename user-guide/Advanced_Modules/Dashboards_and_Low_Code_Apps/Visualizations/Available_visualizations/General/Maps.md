---
uid: DashboardMaps
---

# Maps

This component is used to display markers and/or lines on a map. It uses one or more GQI queries as data input. 

> [!NOTE]
> To use the Maps component, the host servers for DataMiner Maps have to be configured in the file *C:\Skyline DataMiner\Maps\ServerConfig.xml*. If this file does not exist, it will be created automatically when using a Maps component for the first time. To change the configuration, see [Configuring the DataMiner Maps host servers](xref:Configuring_the_DataMiner_Maps_host_servers)

## Adding Data

Add one or multiple GQI data sources to the component. See [Applying a data feed](xref:Apply_Data_Feed).

The data is visualized as a set of markers by default, but can also be configured as a set of lines. In both cases, the compoment will try to automatically apply the dimensions needed to show the visualization of the data. For markers, the process of applying the dimensions works as follows: 

1. A marker needs an ID, a latitude and a longitude value to be visualized. The component will look for columns named 'ID', 'Latitude'/'Lat' and 'Longitude'/'Lng' in your query result. 
2. If these columns exist, a marker is configured for each query row in the result, taking the values of the ID, Latitude and Longitude columns for that row.
3. If no match is found, the component will take the first column containing string values for the ID and the first two columns containing numbers for latitude and longitude while taking into account the columns that are already assigned to other dimensions.
4. The chosen column values can be seen for each query. If a dimension is set incorrectly, it can still be changed manually by the user at any point.

This process is similar for the configuration of lines, but instead of one latitude and longitude value, 2 pairs of coordinates need to be configured, one for the starting point and one for the end point of the line.

## Layer settings

In the layer settings, which can be found in the *Component > Layout > Layer settings* tab, the following settings can be configured: 

- *Weight*: The first setting for each layer is the weight, which is set to 1 by default. When markers or lines from different layers overlap with each other, the weight of the layer will decide which marker to put in the foreground and which in the background. The heigher the weight of the layer, the more it will be pushed to the foreground.

- *Query type*: By default, each query will be configured as a set of markers, which is made clear by the circle icon next to the name of the query. When hovering over the query name, a line icon will also become visible. Clicking this icon changes the visualization of the data from a set of markers to a set of lines and reconfigures the dimensions so they are suitable to be visualized as lines.

- *Dimensions*: For each dimension, a dropdown is shown where the chosen column for that dimension can be changed. All dropdowns contain only valid options for that dimension, i.e. string valued columns for the ID and numeric valued columns for the latitude and longitude.

- *Template*: This setting is only available when the query is configured as a set of markers. The appearance of the markers can be changed using the template editor. In the *Template* setting, a preview of the appearance of the marker can be seen as well as an edit button. Clicking this button opens the editor and allows you to make changes to the template. 

> [!NOTE]
> The center of the marker template is decided by the latitude and longitude values for that marker.

- *Style*: When the query is configured as a set of lines, the *Style* settings can be used to change the appearance of the lines. With these settings, you can change the color, direction visualization, type and width of the lines.

- *Advanced settings*: The advanced settings tab consists of two settings:
    - *Show in zoom level*: A range setting which allows you to configure in which range of zoom levels the query should be visible.
    - *Weight*: Similar to the weight setting on layer level, this setting is used to decide which markers or lines to push to the foreground when two markers or lines from the same layer overlap with each other.

## Map settings

In the *Component > Layout > Map settings* tab, the following options are available:

- *Map center*: A latitude and longitude input to set the default center of the map. To easily get the coördinates of a point on the map, you can right click on the component to make a popup appear which allows you to copy the latitude and/or longitude value of that point to your clipboard.
- *Map zoom*: A zoom range input to configure the minimum and maximum zoom level and another input to configure the default zoom of the map.
- *Map bounds*: When enabled (disabled by default), 4 inputs are shown to configure the north, east, south and west bounds of the map.
- *Map type*: A dropdown to change the type of the map. The available types for a map depend on the provider. In the case of Google Maps, the only supported provider at this moment, the available options are roadmap, satellite, hybrid and terrain. This setting can also be made visible on the component itself by enabling the 'Show map type control' setting. 
- *Save current view*: After panning and zooming to a certain location, clicking the *Save current view* button sets the center and zoom settings to the current center and zoom level of the component.

## Adding actions

When using the maps component in a [low-code app](xref:Application_framework), a set of different component actions can be configured (see [Configuring low-code app events](xref:LowCodeApps_event_config)). The following actions are available:

- *Fetch the data*: This action fetches the data from the component again.
- *Pan to view*: This action pans to a certain location. The coordinates for this action can be static or dynamic by using a feed.
- *Set zoom level*: This action zooms to a certain level on the map. The zoom level can be static or dynamic by using a feed.
- *Overlay actions*: Using app actions, different types of overlays can be shown on the map. The supported overlay types are .kml, .kmz and .geoJSON. The source of the overlay needs to be specified in an input (that can also be received from a feed ) and can be either a local source, specified by a relative path in the *C:\Skyline DataMiner\Maps* folder or a web source, specified by a public URL that hosts the overlay. The following overlay actions are available: 
    - *Open overlay*
    - *Close overlay*
    - *Toggle overlay*
    - *Close all overlays*

> [!NOTE]
> While local sources are more secure and not openly accessible like public sources on the internet, you do have to make sure the route to the GetSecureFile API method (*https://DMA/API/v1/GetSecureFile.aspx*) is openly accessible in order to use the local overlay files.

> [!NOTE]
> For more information about the different types of overlays, see [Layer types](xref:Layer_types#layers-of-sourcetype-overlay)
