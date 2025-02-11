---
uid: Enabling_spiderfied_markers
---

# Enabling spiderfied markers

To make sure you can still see each individual marker in case several markers are very close together on a map, markers can be "spiderfied" into a circle or spiral, depending on the number of markers.

To enable the spiderfier, in the `<MapConfig>` tag of the map configuration file, add the `<SpiderfiedMarkers>` tag and configure it with the following attributes:

- **enable**: Possible values: *true* or *false*. When set to *true*, the spiderfier is enabled.
- **nearbyDistance**: The pixel radius within which a marker is considered to be overlapping with a clicked marker. Default value: 20.
- **circleSpiralSwitchover**: The lowest number of markers that will be fanned out into a spiral instead of a circle. Set this to 0 to always use spirals, or to a very large number to always use circles. Default value: 9.
- **legWeight**: Determines the thickness of the lines joining spiderfied markers to their original locations. Default value: 1.5.
- **circlefootseparation**: The pixel distance between each marker in a circle shape. Default value: 27 px.
- **spirallengthstart**: The initial length of the spiral legs when the number of markers is greater than the value specified in the *circleSpiralSwitchOver* attribute. Default value: 17 px.

> [!NOTE]
>
> - If an attribute is not specified, the default value will be applied.
> - For clustered markers, the *SpiderfyOnClick* attribute can be used. See [Attributes of the \<ClusteredMarkers> tag](xref:Grouping_markers_in_one_clustered_marker#attributes-of-the-clusteredmarkers-tag).

Example:

```xml
<MapConfig xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"  xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  ...
  <SpiderfiedMarkers enable="true" nearbydistance="20" circlespiralswitchover="9"
     legweight="1.5"/>
  ...
</MapConfig>
```

## Defining spiderfied markers per layer

Spiderfied markers can also be defined on layer level. To do so, add a `SpiderfiedMarkers` tag on layer level.

However, note that only the *circlefootseparation* value and *spirallengthstart* value can be defined on this level, overriding the *circlefootseparation* value and *spirallengthstart* value defined in the `SpiderfiedMarkers` tag of the MapConfig.

Example:

```xml
<MapConfig xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"  xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Center latitude="50.85" longitude="4.35" layer="[]" force="true" />
  <InitialZoom>5</InitialZoom>
  <ClusteredMarkers enable="true" maxzoom="5" gridsize="50" zoomonclick="false" spiderfyonclick="true">
    <MarkerImages>
      <MarkerImage id="default" url="images/icons/blocks.png" width="16" height="16" anchor="8,8"/>
    </MarkerImages>
  </ClusteredMarkers>
  <SpiderfiedMarkers enable="true" nearbydistance="42" circlespiralswitchover="6" legweight="1.5" circlefootseparation="10" spirallengthstart="12"/>
  <Layers>
    ...
    <Layer sourceType="table" refresh="3600000" name="Regions" visible="true" allowToggle="true" autoFit="false" limitToBounds="false" minZoom="1">
      <ClusteredMarkers gridsize="42">
        <MarkerImages>
          <MarkerImage id="other" url="images/icons/cluster-52px.png" width="52" height="52" anchor="0,0"/>
        </MarkerImages>
      </ClusteredMarkers>
      <SpiderfiedMarkers circlefootseparation="80" spirallengthstart="6"/>
      ...
    </Layer>
    ...
  <Layers>
  ...
</MapConfig>
```
