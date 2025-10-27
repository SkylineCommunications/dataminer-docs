---
uid: Top-level_structure_of_a_DataMiner_Maps_configuration_file
---

# Top-level structure of a DataMiner Maps configuration file

On a DataMiner Agent, the configuration files for the DataMiner Maps have to be placed in the `C:\Skyline DataMiner\Maps\Configs` directory.

> [!NOTE]
> DataMiner Map configuration files are not automatically synchronized throughout a DataMiner System. Therefore, if you create or update a configuration file on a particular DMA, always perform a [force synchronization](xref:Synchronizing_data_between_DataMiner_Agents#forcing-synchronization-of-a-file-with-the-dms) of that configuration file.

This is an example of a DataMiner Maps configuration file:

```xml
<?xml version ="1.0"?>
<MapConfig xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"  xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <LoadStrategy>all</LoadStrategy>
  <Center latitude="51" longitude="4.5" />
  <FilterBox visible="true">...</FilterBox>
  <InitialZoom>13</InitialZoom>
  <Layers>...</Layers>
  <MapType>road</MapType>
  <Scripts>...</Scripts>
  <ToggleGroups>...</ToggleGroups>
  <PolyLineOptions partial="true" />
</MapConfig>
```

These are the main tags in this example:

- [Center](#center)
- [FilterBox](#filterbox)
- [InitialZoom](#initialzoom)
- [Layers](#layers)
- [LoadStrategy](#loadstrategy)
- [MapType](#maptype)
- [PolyLineOptions](#polylineoptions)
- [Scripts](#scripts)
- [ToggleGroups](#togglegroups)

## Center

In the `<Center>` tag, specify the latitude and the longitude of the geographic location that has to be at the center of the map when you open it.

Example:

```xml
<Center latitude="51" longitude="4.5" />
```

> [!TIP]
> You can quickly find the coordinates of a location in Google Maps, by right-clicking the location on the map and selecting *What’s here?* The latitude and longitude of the location will then be shown in a box above the map.

The following attributes are available to further refine the map centering configuration:

- **force**: Can be set to true or false. When this is set to true, the map will remain centered when automatically fitted layers are added.

  For example: `<Center latitude="51" longitude="5" force="true" />`

- **layer**: Can be set to the name of a layer defined in the map configuration, in order to dynamically center the map on the markers or lines of that specific layer.

  For example: `<Center latitude="51" longitude="5" layer="LayerName" />`

- **marker**: Can be set to the unique ID of a marker in order to dynamically center the map on that single marker. The marker ID can have the following formats, depending on its data source:

  - *element:DmaId/ElementId*
  - *param:DmaId/ElementId/TableParameterId/DisplayKey*
  - *service:DmaId/ServiceId*
  - *view:ViewId*
  - *sqlrow:DmaId/PrimaryKey*

  For example: `<Center latitude="51" longitude="5" marker="element:33/115" >`

- **filterVars**: Use this attribute to define placeholders for the layer and marker attributes, which can later be replaced with URL parameters. If you specify several variables, separate them with a semicolon.

  For example: `<Center latitude="51" longitude="5" marker="param:271/\[MyElement\]/3000/\[SelectedRow\]" filterVars="MyElement;SelectedRow" />`

> [!NOTE]
>
> - If you set the attribute *autoFit* to true in the `<Layer>` tag, this overrides the `<Center>` tag. See [autoFit](xref:Attributes_of_the_Layer_tag#autofit).
> - When multiple centering options are specified, the centering priority from high to low is:
>   - Centering on a single marker.
>   - Centering on an entire layer.
>   - Centering on "lat" and "long" coordinates passed via URL parameters. (See [Displaying a DataMiner map in a web browser](xref:Displaying_a_DataMiner_map_in_a_web_browser))
>   - Centering on static coordinates defined in the `<Center>` tag of the map configuration.

## FilterBox

If you add a `<FilterBox>` tag, the map will contain a filter box that allows users to filter map items based on their name or their alarm severity level.

For more information, see [Adding a filter box to a DataMiner Map](xref:Adding_a_filter_box_to_a_DataMiner_Map).

## InitialZoom

In the `<InitialZoom>` tag, specify the zoom level at which the map will initially be displayed.

- Enter 0 to have a map of the Earth fully zoomed out.

- Enter a number greater than 0 to have a map that is zoomed in at a higher resolution.

Default zoom level: 10

Example:

```xml
<InitialZoom>13</InitialZoom>
```

## Layers

In the `<Layers>` tag, specify a `<Layer>` tag for every layer that has to be displayed on top of the map.

Example:

```xml
<Layers>
  <Layer
    sourceType="table"
    refresh="5000"
    name="Cable Modems"
    visible="false"
    allowToggle="true">
    ...
  </Layer>
</Layers>
```

For more information, see [Attributes of the Layer tag](xref:Attributes_of_the_Layer_tag).

## LoadStrategy

In the `<LoadStrategy>` tag, specify whether invisible layers should be preloaded when the map is initialized.

The following values can be specified:

- **all**: Preloads all layers when the map is initialized (visible and invisible layers).
- **visible**: Preloads only the visible layers when the map is initialized.

## MapType

In the `<MapType>` tag, specify the type of map that has to be displayed initially:

- **road**: Displays the normal, 2D road map view (default).

- **satellite**: Displays Google Earth satellite images.

- **hybrid**: Displays a mix of normal road map views and Google Earth satellite images.

- **terrain**: Displays a physical relief map that shows elevation and water features (mountains, rivers, etc.).

Example:

```xml
<MapType>road</MapType>
```

## PolyLineOptions

If polylines on the map should be visible even if only the start point or the end point of those lines are visible, specify this tag as follows:

```xml
<PolyLineOptions partial="true" />
```

## Scripts

In the `<Scripts>` tag, specify a `<Script>` tag for every external JavaScript file that has to be loaded when the map is opened.

> [!NOTE]
> This is an advanced feature. In most cases, no external JavaScript files need to be specified.

Example:

```xml
<Scripts>
  <Script src="sync/scripts/izegem.extra.js" />
</Scripts>
```

In the src attribute of a `<Script>` tag, specify the path to a JavaScript file:

- an absolute path (starting with *http://*), or

- a path relative to `C:\Skyline DataMiner\Webpages\Maps\`

## ToggleGroups

In the `<ToggleGroups>` tag, you can define layer groups.

For more information, see [Layer groups](xref:Layer_groups).
