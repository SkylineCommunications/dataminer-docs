---
uid: Attributes_of_the_Layer_tag
---

# Attributes of the Layer tag

In a map configuration file, the *\<Layer>* tag can have the attributes detailed below.

## allowToggle

If you set this attribute to true, the user interface will allow users to either display or hide the layer.

Default: false

## autoFit

If you set this attribute to true, when the map is opened, the zoom level will automatically be set in such a way that all markers defined in the layer are visible.

Default: false

## limitToBounds

If this attribute is set to True, the layer only fetches the markers that are within the current bounds. This can be useful for layers with many objects, where fetching all of them at the same time would take much time.

By default, this attribute is set to False.

> [!NOTE]
> This feature only works for layers of type TableSource and SqlSource. In case of layers of type SqlSource, the SQL query will need to contain a WHERE clause similar to the following one: *where (Latitude \>= \[sw_lat\] and Latitude \<= \[ne_lat\]) and (Longitude \>= \[sw_lon\] and Longitude \<= \[ne_lon\])*

## linked

With this attribute, you can control whether the visibility of a polyline of a particular layer is controlled by the markers on the linked layers.

Example:

```xml
<Layer name="myLayer" autoFit="false" visible="true" toggleGroup="myGroup" allowToggle="true" sourceType="relations" limitToBouncds="false" refresh="3600000" linked="true">
```

## maxZoom

Maximum zoom level at which this layer is visible. When zooming in more, the layer will become invisible.

By default, a layer is always visible. Zoom levels go from 0 (entire world) up to around 19-23 (depending on the zoom location)

## minZoom

Minimum zoom level at which the layer is visible. When you zoom out more, the layer will become invisible.

By default, a layer is always visible. Zoom levels go from 0 (entire world) up to around 19-23 (depending on the zoom location).

> [!NOTE]
> Combining multiple layers that have a minZoom and maxZoom level can provide a drill-down experience, which can for instance be useful when using DataMiner Maps to display EPM element data.

## name

The name of the layer.

If you allow the layer to be hidden (see the allowToggle attribute above), then it is this name that will appear in the map legend.

## notifications

When this attribute is set to "true", notifications are displayed for the layer.

Example:

```xml
<Layer sourceType="table" refresh="5000" name="Countries" visible="true" allowToggle="true" autoFit="false" limitToBounds="false" notifications="true">
```

> [!NOTE]
> If this attribute is not specified, no notifications are displayed for the layer.

## refresh

The interval (in milliseconds) at which the data in the layer needs to be refreshed.

If you set this attribute to 0 or if you leave it out, the layer will not be refreshed.

> [!NOTE]
>
> - Augmenting the refresh rate will have a negative impact on the overall performance of DMAs as well as DMA clients.
> - This attribute does not work for layers of sourceType "traffic". Traffic information is only retrieved once, and not refreshed afterwards. See [Layers of sourceType "traffic"](xref:Layer_types#layers-of-sourcetype-traffic).

## sourceType

The type of layer. The following types are supported:

- **clouds**: A layer that displays cloud information. See [Layers of sourceType "clouds"](xref:Layer_types#layers-of-sourcetype-clouds).

- **connectivity**: A layer that visualizes DCF connections. See [Layers of sourceType "connectivity"](xref:Layer_types#layers-of-sourcetype-connectivity).

- **overlay**: A layer that displays a static image (JPG, PNG, GIF or KML). See [Layers of sourceType "overlay"](xref:Layer_types#layers-of-sourcetype-overlay).

- **parameters**: A layer that displays objects positioned according to latitude and longitude values stored in element or service parameters. See [Layers of sourceType "parameters"](xref:Layer_types#layers-of-sourcetype-parameters).

- **properties**: A layer that displays objects positioned according to latitude and longitude values retrieved from DataMiner Properties. See [Layers of sourceType "properties"](xref:Layer_types#layers-of-sourcetype-properties).

- **relations**: A layer that allows you to display lines between objects that are related via foreign key relationships in a DataMiner element.  See [Layers of SourceType "relations"](xref:Layer_types#layers-of-sourcetype-relations).

- **separator**: A dummy layer that only serves to display a "section title" in a layer group. For more information, see [Separators in layer groups](xref:Layer_groups#separators-in-layer-groups) and [Layers of sourceType "separator"](xref:Layer_types#layers-of-sourcetype-separator). |

- **sql**: A layer that displays objects positioned according to latitude and longitude values retrieved from a database table. See [Layers of sourceType "sql"](xref:Layer_types#layers-of-sourcetype-sql).

- **table**: A layer that displays objects based on data retrieved from dynamic table rows. See [Layers of sourceType "table"](xref:Layer_types#layers-of-sourcetype-table).

- **traffic**: A layer that displays traffic information. See [Layers of sourceType "traffic"](xref:Layer_types#layers-of-sourcetype-traffic).

- **weather**: A layer that displays weather information with temperatures in degrees Celsius. See [Layers of sourceType "weather"](xref:Layer_types#layers-of-sourcetype-weather).

- **weatherf**: A layer that displays weather information with temperatures in degrees Fahrenheit. See [Layers of sourceType "weatherf"](xref:Layer_types#layers-of-sourcetype-weatherf).

> [!NOTE]
>
> - The sourceType attribute of a *\<Layer>* tag dictates which subtags are allowed. A *\<TableSourceInfo>* tag, for example, is only allowed inside a *\<Layer>* tag if sourceType is "table". For more information, see [Layer types](xref:Layer_types).
> - For Google Maps, the Weather and Cloud layers are deprecated. As an alternative, you can combine OpenStreetMap and OpenWeatherMap instead. See [Configuring the DataMiner Maps host servers](xref:Configuring_the_DataMiner_Maps_host_servers) for more details.

## visible

If you set this attribute to false, then the layer will not be visible when the map is opened.

Default: true

> [!NOTE]
> If you set both visible and allowToggle to false, then the layer will not be visible when the map is opened and users will not be able to make it visible.
