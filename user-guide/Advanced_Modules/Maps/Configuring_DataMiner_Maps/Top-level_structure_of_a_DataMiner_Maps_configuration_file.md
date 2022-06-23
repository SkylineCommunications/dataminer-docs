---
uid: Top-level_structure_of_a_DataMiner_Maps_configuration_file
---

# Top-level structure of a DataMiner Maps configuration file

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

See below for more information on the main tags in the above-mentioned example:

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

In the *\<Center>* tag, specify the latitude and the longitude of the geographic location that has to be in the center of the map when you open it.

Example:

```xml
<Center latitude="51" longitude="4.5" />
```

> [!NOTE]
>
> - In Google Maps, it is very easy to get the coordinates of a particular location. Just right-click the location on the map and choose *What’s here*? The latitude and longitude of that location will appear in the search box above the map.
> - If you set the attribute autoFit to true in the *\<Layer>* tag, this overrides the *\<Center>* tag. See [autoFit](xref:Attributes_of_the_Layer_tag#autofit).

From DataMiner 9.5.1 onwards, the following attributes are available to further refine the map centering configuration:

| Attribute  | Description |
|------------|-------------|
| force      | Can be set to true or false. When it is set to true, the map will remain centered when automatically fitted layers are added. For example: *\<Center latitude="51" longitude="5" force="true" />* |
| layer      | Can be set to the name of a layer defined in the map configuration, in order to dynamically center the map on the markers or lines of that specific layer. For example: *\<Center latitude="51" longitude="5" layer="LayerName" />* |
| marker     | Can be set to the unique ID of a marker in order to dynamically center the map on that single marker.<br> The marker ID can have the following formats, depending on its data source:<br> -  *element:DmaId/ElementId* <br> -  *param:DmaId/ElementId/TableParameterId/DisplayKey* <br> -  *service:DmaId/ServiceId* <br> -  *view:ViewId* <br> -  *sqlrow:DmaId/PrimaryKey* <br> For example: *\<Center latitude="51" longitude="5" marker="element:33/115" >* |
| filterVars | Use this attribute to define placeholders for the layer and marker attributes, which can later be replaced with URL parameters. If you specify several variables, separate them with a semicolon.<br> For example: *\<Center latitude="51" longitude="5" marker="param:271/\[MyElement\]/3000/\[SelectedRow\]" filterVars="MyElement;SelectedRow" />* |

> [!NOTE]
> When multiple centering options are specified, the centering priority from high to low is:
>
> - Centering on a single marker.
> - Centering on an entire layer.
> - Centering on "lat" and "long" coordinates passed via URL parameters. (See [lat=](xref:Options_for_opening_DataMiner_Cube#lat) and [long=](xref:Options_for_opening_DataMiner_Cube#long))
> - Centering on static coordinates defined in the \<Center> tag of the map configuration.

## FilterBox

If you add a *\<FilterBox>* tag, the map will contain a filter box that allows users to filter map items based on their name or their alarm severity level.

For more information, see [Adding a filter box to a DataMiner Map](xref:Adding_a_filter_box_to_a_DataMiner_Map).

## InitialZoom

In the *\<InitialZoom>* tag, specify the zoom level at which the map will initially be displayed.

- Enter 0 to have a map of the Earth fully zoomed out.

- Enter a number greater than 0 to have a map that is zoomed in at a higher resolution.

Default zoom level: 10

Example:

```xml
<InitialZoom>13</InitialZoom>
```

## Layers

In the *\<Layers>* tag, specify a *\<Layer>* tag for every layer that has to be displayed on top of the map.

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

Available from DataMiner 9.6.0 CU3/9.6.9 onwards. In the *\<LoadStrategy>* tag, specify whether invisible layers should be preloaded when the map is initialized.

The following values can be specified:

| Value   | Description                                                                    |
|---------|--------------------------------------------------------------------------------|
| all     | Preload all layers when the map is initialized (visible and invisible layers). |
| visible | Preload only the visible layers when the map is initialized.                   |

## MapType

In the *\<MapType>* tag, specify the type of map that has to be displayed initially.

- **road**: Displays the normal, 2D road map view (default).

- **satellite**: Displays Google Earth satellite images.

- **hybrid**: Displays a mix of normal road map views and Google Earth satellite images.

- **terrain**: Displays a physical relief map that shows elevation and water features (mountains, rivers, etc.).

Example:

```xml
<MapType>road</MapType>
```

## PolyLineOptions

Available from DataMiner 9.6.0 CU3/9.6.9 onwards. If polylines on the map should be visible even if only the start point or the end point of those lines are visible, specify this tag as follows:

```xml
<PolyLineOptions partial="true" />
```

## Scripts

In the *\<Scripts>* tag, specify a *\<Script>* tag for every external JavaScript file that has to be loaded when the map is opened.

> [!NOTE]
> This is an advanced feature. In most cases, no external JavaScript files need to be specified.

Example:

```xml
<Scripts>
  <Script src="sync/scripts/izegem.extra.js" />
</Scripts>
```

In the src attribute of a *\<Script>* tag, specify the path to a JavaScript file:

- an absolute path (starting with *http://*), or

- a path relative to *C:\\Skyline DataMiner\\Webpages\\Maps\\*

## ToggleGroups

In the *\<ToggleGroups>* tag, you can define layer groups.

For more information, see [Layer groups](xref:Layer_groups).
