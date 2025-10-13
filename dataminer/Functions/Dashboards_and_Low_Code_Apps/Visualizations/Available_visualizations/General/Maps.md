---
uid: DashboardMaps
---

# Maps

Available from DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/DataMiner 10.5.4 onwards<!-- RN 42309 -->.

This component is used to display markers and/or lines on a map. It currently only supports **Google Maps** ("gmaps") as the [Maps provider](xref:Configuring_the_DataMiner_Maps_host_servers).

![Maps](~/dataminer/images/Maps_Component.png)<br>*Maps component in DataMiner 10.4.4*

With this component, you can:

- (...)

- (...)

## Prerequisites

- To display the map, the machine running the browser must have internet access.

- To use the maps component, the host servers for DataMiner Maps have to be configured in the file `C:\Skyline DataMiner\Maps\ServerConfig.xml`. If this file does not exist, it will be created automatically when you use a maps component for the first time. To change the configuration, see [Configuring the DataMiner Maps host servers](xref:Configuring_the_DataMiner_Maps_host_servers).

## Supported data types

The maps component is used to display the results of queries in a map format. It should therefore **always be configured with [query data input](xref:Query_Data)**.

Each row in a query corresponds to (...)

## Interacting with the maps component

What is shown in the map:

Dependent on the Map settings, where you can configure the default map center, map zoom, and map bounds. In read mode, you can adjust the view of the map by zooming or panning. (...)

- **Zooming functionalities** are available for the maps component.

  - From DataMiner 10.4.0 [CU10]/10.5.1 onwards<!--RN 41387-->, the zooming method depends on the *Advanced* > *Hold Ctrl to zoom* setting in the *Settings* pane:

    - When this setting is enabled: Hold the Ctrl key while scrolling up or down to zoom in or out.

    - When this setting is disabled: Scroll up or down to zoom in or out.

  - From DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9<!--RN 40017--> up to DataMiner 10.4.0 [CU9]/10.4.12:

    - To zoom in, press Ctrl while scrolling up.

    - To zoom out, press Ctrl while scrolling down.

  - Prior to DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9:

    - To zoom in, scroll up.

    - To zoom out, scroll down.

- To **pan the map**, press and hold CTRL, then click and hold the scroll wheel while dragging the pointer in any direction.

- From DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4 onwards<!--RN 42322-->, when you **select a marker on the map**, it will by default be highlighted with a blue color. This can for instance be useful when the timeline's [component data](xref:Component_Data) (i.e. *Components* > *Maps* > *Selected markers*) is used in a linked component, clearly indicating which data is driving the content in the linked component.

## Adding data

Add one or multiple GQI data sources to the component. See [Adding data to a component](xref:Adding_data_to_component).

The data is visualized as a set of markers by default, but it can also be configured as a set of lines. In both cases, the component will try to automatically apply the dimensions needed to show the visualization of the data.

For markers, the process of applying the dimensions works as follows:

1. As a marker needs an ID, a latitude, and a longitude value to be visualized, the component will look for columns named "ID", "Latitude"/"Lat", and "Longitude"/"Lng" in your query result.

1. If these columns exist, a marker is configured for each query row in the result, taking the values of the ID, latitude, and longitude columns for that row.

1. If no match is found, the component will take the first column containing string values for the ID and the first two columns containing numbers for latitude and longitude while taking into account the columns that are already assigned to other dimensions.

1. The chosen column values are displayed for each query. If a dimension is set incorrectly, you can still change it manually at any point.

This process is similar for the configuration of lines, but instead of one latitude and longitude value, two pairs of coordinates need to be configured, one for the starting point and one for the end point of the line.

## Configuration options

### Maps layout

In the *Layout* pane, you can find the default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

Additionally, the following layout options are also available:

| Section | Subsection | Option | Description |
|--|--|--|--|
| Filtering & Highlighting | N/A | Highlight | Toggle the switch to determine whether the nodes that match the criteria specified in a query filter will be highlighted. Enabled by default. For more information, see [Highlighting filtered results](#highlighting-filtered-results). |
| Filtering & Highlighting | N/A | Opacity | Set the level of transparency of the items that do not match the criteria specified in a query filter. This option is only available when *Highlight* is enabled. For more information, see [Highlighting filtered results](#highlighting-filtered-results). |
| Layer settings | N/A | Weight | Determine which marker is put in the foreground and which in the background in case markers or lines from different layers overlap with each other. The higher the weight of the layer, the more it will be pushed to the foreground. The default weight is 1. |
| Layer settings | N/A | ![Set as marker](~/dataminer/images/Maps_Circle_icon.png) or ![Set as line](~/dataminer/images/Maps_Line_icon.png) | Hover over the query name to see whether it is configured as a set of markers (default) or as a set of lines. To change the configuration, click the ![Set as marker](~/dataminer/images/Maps_Circle_icon.png) icon to set it as markers, or the ![Set as line](~/dataminer/images/Maps_Line_icon.png) icon to set it as lines. |
| Layer settings | N/A | Identifier/Latitude/Longitude | For each dimension, a dropdown box is shown where the column used for that dimension can be changed. You can only select valid options for each dimension. For markers, you need to select string-valued columns for the ID and numeric-valued columns for the latitude and longitude. For lines, you need to select a latitude and longitude for both the source and the destination. |
| Layer settings | Template | Browse templates *or*<br>Reuse template (depending on your DataMiner version) | Available for markers only. Reuse a saved template from another component in the same dashboard or low-code app. This option is only available if a template is already in use<!--RN 42226-->. |
| Layer settings | Template | Edit | Available for markers only. Open the Template Editor<!--RN 34761--> to customize the appearance of the markers. For more information, refer to [Customizing markers](#customizing-markers). |
| Layer settings | N/A | On line click | Available from DataMiner 10.4.0 [CU19]/10.5.0 [CU7]/10.5.10 onwards<!-- RN 43562 -->, for lines only. [Configure an event](xref:LowCodeApps_event_config) that will occur when a line is clicked. |
| Layer settings | Style | Color | Available for lines only. Change the color of the lines. |
| Layer settings | Style | Conditional coloring | Available from DataMiner 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9 onwards<!--RN 43377-->, for lines only. Specify color filters for specific columns, so that lines can be highlighted based on a condition. |
| Layer settings | Style | Width | Available for lines only. Change the width of the lines. |
| Layer settings | Style | Type | Available for lines only. Change the type of lines (normal, dashed, dotted, or alternate). |
| Layer settings | Style | Direction visualization | Available for lines only. Specify how the direction of the line should be visualized on the map (none, flow, or arrow). |
| Layer settings | Advanced settings | Show in zoom level | Determine in which range of zoom levels the query should be visible. |
| Layer settings | Advanced settings | Weight | Similar to the weight setting on layer level. Determine which markers or lines are pushed to the foreground when two markers or lines from the same layer overlap with each other. |
| Map settings | N/A | Save current view | After you have panned and/or zoomed to a certain location, click this button to set the center and zoom settings to the current center and zoom level of the component. |
| Map settings | Map center | Latitude/Longitude | Determine the default center of the map by means of the latitude and longitude of the center location. To easily get the coordinates of a point on the map, right-click the component and select the latitude and/or longitude value to copy it to the clipboard. |
| Map settings | Map zoom | Zoom range | Select the minimum and maximum zoom level. |
| Map settings | Map zoom | Default zoom | Specify the default zoom level of the map. |
| Map settings | Map bounds | Enable bounds | Enable this option to configure the north, east, south, and west bounds of the map. |
| Map settings | Default map type | Map type | Select the type of the map. The available types depend on the map provider. At present, only Google Maps is supported, with the following map types: *roadmap*, *satellite*, *hybrid*, and *terrain*. |
| Map settings | Default map type | Show map type control | Enable this option to make the map type setting visible in the component itself. |

> [!NOTE]
> From DataMiner 10.4.0 [CU20]/10.5.0 [CU8]/10.5.11 onwards, lines can also be colored based on the [conditional coloring](xref:DashboardQueryFilter#conditional-coloring) of a linked query filter. This will override the color configuration in the layer settings of the maps component. Note that if the query filter contains multiple color conditions, only the first color condition will be applied, as a line can only have one color.<!-- RN 43617 -->

#### Highlighting filtered results

#### Customizing markers

  > [!NOTE]
  > The center of the marker template is determined by the latitude and longitude values for that marker.

  > [!TIP]
  > For more information on how to use the Template Editor to customize the appearance of the markers, see [Using the Template Editor](xref:Template_Editor).

### Maps settings

In the *Settings* pane for this component, you can customize its behavior to suit your requirements.

| Section | Option | Description |
|--|--|--|
| WebSocket settings | Inherit WebSocket settings from page/panel | Clear the checkbox to use a custom polling interval for this component. When cleared, you can specify a different polling interval (in seconds). |
| General | Override dynamic units | Clear the checkbox to prevent parameter units from changing dynamically based on their value and protocol definition. Disabled by default. |
| Data retrieval | Update data | Toggle the switch to determine whether the data on the map should be refreshed automatically (provided this is supported by the data source). See [Query updates](xref:Query_updates)<!--RN 37269-->. Disabled by default. |
| Advanced | Hold Ctrl to zoom | Available from DataMiner 10.4.0 [CU10]/10.5.1 onwards<!--RN 41387-->. Select the checkbox to make the scroll wheel zoom only when you hold the Ctrl key. |

> [!NOTE]
> The *Update data* setting is currently only applicable for the markers on the map. Real-time updates are not yet supported for lines.

## Adding actions

When a maps component is used in a [low-code app](xref:Application_framework), a set of different component actions can be configured (see [Configuring app events](xref:LowCodeApps_event_config)).

The following actions are available:

- *Clear selection*: This action clears the selection of data in the component. Available from DataMiner 10.4.0 [CU20]/10.5.0 [CU8]/10.5.11 onwards<!--RN 43635-->.

- *Fetch the data*: This action fetches the data from the component again.

- *Pan to view*: This action pans to a certain location. The coordinates for this action can be static or dynamic (using the *Link to* option).

- *Set zoom level*: This action zooms to a certain level on the map. The zoom level can be static or dynamic (using the *Link to* option).

- *Overlay actions*: Using app actions, different types of overlays can be shown on the map. The supported overlay types are .kml, .kmz and .geoJSON. The source of the overlay needs to be specified in an input (which can also be received using the *Link to* option), and it can be either a local source, specified by a relative path in the `C:\Skyline DataMiner\Maps` folder, or a web source, specified by a public URL that hosts the overlay. The following overlay actions are available:

  - *Open overlay*

  - *Close overlay*

  - *Toggle overlay*

  - *Close all overlays*

  > [!NOTE]
  > While local sources are more secure and not openly accessible like public sources on the internet, you do have to make sure the route to the *GetSecureFile* API method (`https://DMA/API/v1/GetSecureFile.aspx`) is openly accessible in order to use the local overlay files.

  > [!TIP]
  > For more information about the different types of overlays, see [Layer types](xref:Layer_types#layers-of-sourcetype-overlay)

## Enabling the component in soft launch

From DataMiner 10.3.2 onwards, the maps component is available in soft launch, if the soft-launch option *ReportsAndDashboardsGQIMaps* is enabled. For more information, see [Soft-launch option](xref:SoftLaunchOptions).

If you use the preview version of the maps component, its functionality may be different from what is described on this page.
