---
uid: ParametersSourceInfo
---

# ParametersSourceInfo

In the `<ParametersSourceInfo>` tag, specify the parameters from which to retrieve the necessary data in order to draw the layer’s objects, which can be either markers or lines.

- In the *type* attribute, specify the type of DataMiner items from which to retrieve the parameter values: elements or services.

- If the type attribute is set to "services", also specify an *alias* attribute or *elementDataVar* attribute, setting it to the element in the service that has the location data. E.g. `<ParametersSourceInfo type="services" alias="locationelement">`.

  The location coordinates of the specified element are used to display the service on the map.

  > [!TIP]
  > See also: [elementDataVar](#elementdatavar)

- If the *style* attribute is set to "markers" (i.e. the default setting), the layer will display markers, each positioned at a location specified by one pair of latitude/longitude values.

- If the *style* attribute is set to "lines", the layer will display lines, each connecting two pairs of latitude/longitude values. Each line will be displayed as a geodesic, a segment of a "great circle" representing the shortest distance between two points on the surface of the Earth.

## ParametersSourceInfo subTags

Inside the `<ParametersSourceInfo>` tag, you can place the tags detailed below.

### LatitudePID/LongitudePID/LatitudePID2/LongitudePID2

The parameter IDs containing the latitude and longitude values.

- If the style attribute is set to "markers", only one pair of latitude/longitude values has to be specified in the `<LatitudePID>` and `<LongitudePID>` tags. In that case, the `<LatitudePID2>` and `<LongitudePID2>` tags will not be used and can therefore be omitted.

- If the style attribute is set to "lines", two pairs of latitude/longitude values have to be specified: one pair in the `<LatitudePID>` and `<LongitudePID>` tags, and another pair in the `<LatitudePID2>` and `<LongitudePID2>` tags.

### MarkerSelectionPID

In this optional tag, you can specify the ID of the parameter containing a marker image ID.

If, for a specific marker, this parameter contains an image ID corresponding to a particular MarkerImage ID, then the marker will be displayed on the map using that specific marker image. If, however, no marker image can be found of which the ID matches the image ID that was retrieved, then the marker will be displayed using the first marker image defined in the `<MarkerImages>` tag.

### ViewFilter

In this tag, specify a view ID if you want to narrow down the number of views from which to retrieve the necessary parameter values.

- In the id attribute, specify the ID of the view.

- In the includeSubViews attribute, specify whether or not to include the underlying subviews. Default: false

### ProtocolFilter

In this tag, specify the name of a protocol if you want the layer data only to be retrieved from parameters of elements based on that specific protocol.

### ParameterFilters

In this optional tag, you can specify one or more filters in `<ParameterFilter>` tags.

Use the following syntax:

```txt
value=[ParameterID][Operator][Value]
```

> [!NOTE]
>
> - There must be a space before and after the operator. Possible operators: == (equal to) and != (not equal to)
> - In a parameter filter, you can use placeholders referring to variables declared in the `<ParametersSourceInfo>` tag. The \[DMA_USERNAME\] placeholder, however, is a general placeholder that does not need to be declared. At runtime, it will be replaced by the name of the current user.

## Passing ParametersSourceInfo data along in the map’s URL

The element, service and view filter can be passed along as a parameter in the map’s URL.

### elementDataVar

If you want to have an element placed on a map using location coordinates stored in another element, add an elementDataVar attribute to the `<ParametersSourceInfo>` tag, and set its value to "elementdata".

Then assign the name of the element containing the coordinates to the elementdata variable in the map’s URL (with a "d" prefix):

```txt
http://localhost/maps/map.aspx?config=mechelen&dview=Computer&delement=LocationElementName&delementdata=DataElementName
```

Result:

- The "location element" specified in the *element* variable will supply:

  - the location coordinates

  - the pop-up details (by default)

    > [!NOTE]
    > If you want to show data from another element in a pop-up balloon, refer to [Showing data of another element in a pop-up balloon](xref:PopupSkeleton_and_PopupDetails#showing-data-of-another-element-in-a-pop-up-balloon).

- The "data element" specified in the *elementdata* variable will supply:

  - the element name

  - the alarm color

  - the MarkerSelectionPID (i.e. the parameter containing the marker image ID)

- The parameter filter will be applied on the "data element".

> [!NOTE]
> It is possible to specify this attribute in the `<PropertiesSourceInfo>` tag instead. See [Passing PropertiesSourceInfo data along in the map’s URL](xref:PropertiesSourceInfo#passing-propertiessourceinfo-data-along-in-the-maps-url).

### elementVar

If, in the `<ParametersSourceInfo>` tag, you add an elementVar attribute with value "myElement" (referring to an element using the syntax "DMAID/ElementID" or "NameOfElement"), then you can use a map URL like one of the following instead (notice the "d" in front of the parameter name!):

```txt
maps.aspx?config=MyConfigFile&dmyElement=7/46840
maps.aspx?config=MyConfigFile&dmyElement=VesselData
```

### serviceVar

Similar to the elementVar attribute, you can also use the serviceVar attribute to pass a service name or service ID along in the map’s URL. To do so, add a serviceVar attribute with value "myService", referring to a service using the syntax "DMAID/ServiceID" or "NameOfService".

Example:

```xml
<ParametersSourceInfo type="services" serviceVar="MyService">
...
</ParametersSourceInfo>
```

You can then use a map URL like the following:

```txt
http://localhost/maps/map.aspx?config=managedservices&dMyService=ship
```

### idVars

If, in the `<ParametersSourceInfo>` tag, you add a `<ViewFilter>` tag with an idVars attribute set to "myView" (referring to a view either by ID or by name), then you can pass the view as a parameter in the map’s URL in the following manner (notice the "d" in front of the parameter name!):

```txt
maps.aspx?config=MyConfigFile&dmyView=specialview
```

> [!NOTE]
> In the value of an idVars attribute, you can specify several parameters separated by semicolons (";").

## Examples

### Example of a layer retrieving its data from element parameters

```xml
<Layer sourceType="parameters" refresh="20000" autoFit="true" visible="false" allowToggle="true"  name="element parameters" toggleGroup="Elements">
  <ParametersSourceInfo type="elements">
    <LatitudePID>102</LatitudePID>
    <LongitudePID>105</LongitudePID>
    <MarkerSelectionPID>2108</MarkerSelectionPID>
    <ProtocolFilter>[DVE Child] Concept Stress</ProtocolFilter>
    <ViewFilter idVar="NewView" includeSubViews="true" />
  </ParametersSourceInfo>
  <PopupSkeleton>
    <![CDATA[
    <ul>
    <li>MyTitle</li>
    <li>[eid]</li>
    <li>[dmaid]</li>
    <li>[customparametervalue]</li>
    </ul>
    ]]>
  </PopupSkeleton>
  <PopupDetails>
    <Detail name="customparametervalue" type="parameter" pid="102" />
  </PopupDetails>
  <MarkerImages>
    <MarkerImage id="default" url="images/icons/SATIP2_2.png" width="20" height="36" anchor="10,36"/>
  </MarkerImages>
</Layer>
```

### Example of a layer retrieving its data from service parameters and using pop-up balloons

```xml
<Layer sourceType="parameters" refresh="20000" autoFit="false" visible="false" allowToggle="true"  name="Service parameters iDirect">
  <ParametersSourceInfo type="services" alias="locationelement">
    <LatitudePID>2007</LatitudePID>
    <LongitudePID>2008</LongitudePID>
  </ParametersSourceInfo>
  <PopupSkeleton>
    <![CDATA[
      <p>username: [username]</p>
      <p>latitude: [latitude]</p>
      <p>longitude: [longitude]</p>
    ]]>
  </PopupSkeleton>
  <PopupDetails>
    <Detail name="username" type="parameter_elementalias" alias="locationelement" pid="2002" />
    <Detail name="latitude" type="parameter_elementalias" alias="locationelement" pid="2007" />
    <Detail name="longitude" type="parameter_elementalias" alias="locationelement" pid="2008" />
  </PopupDetails>
</Layer>
```

### Example of a layer retrieving line data from element parameters

```xml
<Layer sourceType="parameters" refresh="20000" autoFit="true" visible="false" allowToggle="true" name="element line parameters" toggleGroup="Elements">
  <ParametersSourceInfo type="elements" style="lines">
    <LatitudePID>102</LatitudePID>
    <LongitudePID>105</LongitudePID>
    <LatitudePID2>101</LatitudePID2>
    <LongitudePID2>105</LongitudePID2>
    <ProtocolFilter>[DVE Child] Concept Stress</ProtocolFilter>
    <ViewFilter id="5" includeSubViews="true" />
  </ParametersSourceInfo>
  ...
</Layer>
```

### Example of a ParametersSourceInfo tag containing parameter filters

```xml
<ParametersSourceInfo type="elements" filterVars="vessel">
  <LatitudePID>102</LatitudePID>
  <LongitudePID>105</LongitudePID>
  <ProtocolFilter>Demo</ProtocolFilter>
  <ViewFilter id="5" includeSubViews="true" />
  <ParameterFilters>
    <ParameterFilter>value=110 != 0</ParameterFilter>
    <ParameterFilter>value=111 == [vessel]</ParameterFilter>
  </ParameterFilters>
</ParametersSourceInfo>
```
