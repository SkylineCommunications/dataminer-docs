---
uid: Grouping_markers_in_one_clustered_marker
---

# Grouping markers in one clustered marker

Especially for maps with a large number of markers, it can be useful to group multiple markers in one clustered marker. The clustered marker will show the number of markers in the group, and will take the alarm color of the highest alarm level of any of the markers.

## Minimal configuration

The following is the minimal configuration required to use clustered markers:

```xml
<MapConfig>
 <ClusteredMarkers enable="true"/>
 ...
 <Layers>
 ...
 </Layers>
</MapConfig>
```

## Default configuration

Clustered markers can be configured using a number of settings. If you do not specify any of those settings, DataMiner will use the following default configuration:

```xml
<ClusteredMarkers enable="false" maxzoom="-1" gridsize="60" zoomonclick="true">
  <MarkerImages>
    <MarkerImage id="default" url="images/icons/cluster-52px.png" width="52" height="52" anchor="26,52"/>
    <MarkerImage id="default" url="images/icons/cluster-55px.png"  width="55" height="55" anchor="27,55"/>
    <MarkerImage id="default" url="images/icons/cluster-65px.png"  width="65" height="65" anchor="32,65"/>
    <MarkerImage id="default" url="images/icons/cluster-77px.png"  width="77" height="77" anchor="38,77"/>
    <MarkerImage id="default" url="images/icons/cluster-89px.png"  width="89" height="89" anchor="45,89"/>
  </MarkerImages>
</ClusteredMarkers>
```

## Attributes of the \<ClusteredMarkers> tag

The following attributes can be used in the `<ClusteredMarkers>` tag:

- **Enable**: Enables or disables marker clustering.

- **MaxZoom**: Sets the maximum zoom factor in which clustered markers are shown (-1 = default, 0 = entire world).

- **GridSize**: Sets the size of the clustered grid (in pixels).

- **ZoomOnClick**: Determines whether the "zoom on click" feature is enabled.

- **SpiderfyOnClick**: When *SpiderfyOnClick* is set to "true", clustered markers will be spiderfied when clicked. As this option replaces the default ZoomOnClick option, in this case, ZoomOnClick should be set to false.

  Example: `<ClusteredMarkers enable="true" maxzoom="5" gridsize="60" zoomonclick="false" spiderfyonclick="true">`

## \<MarkerImages> tag

In the `<MarkerImages>` tag, you can define the set of marker images that can be used by the cluster. The configuration settings are identical to those used in the Layers.MarkerImages tag. See [MarkerImages](xref:MarkerImages).

The first MarkerImage will be used for clusters containing a small number of markers, while the last MarkerImage will be used for clusters with a very large number of markers. These images can be small, large, transparent, semi-transparent, etc.

## Defining clustered markers per layer

It is possible to define clustered markers at layer level. To do so, add a ClusteredMarkers tag at layer level. However, note that only the GridSize and MarkerImages can be defined at this level, overriding the grid size value and marker images defined in the ClusteredMarkers tag of the MapConfig.

> [!NOTE]
> For an example of this configuration, combined with the configuration of spiderfied markers at layer level, refer to [Defining spiderfied markers per layer](xref:Enabling_spiderfied_markers#defining-spiderfied-markers-per-layer).
