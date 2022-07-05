---
uid: PropertiesSourceInfo
---

# PropertiesSourceInfo

In the *\<PropertiesSourceInfo>* tag, specify the DataMiner properties from which to retrieve the necessary data in order to draw the layer’s objects, which can be either markers or lines.

In the *type* attribute, specify the type of DataMiner items from which to retrieve the parameter values: views, elements or services.

## PropertiesSourceInfo subTags

Inside the *\<PropertiesSourceInfo>* tag, you can place the following tags.

### LatitudePropertyName/LongitudePropertyName

The names of the properties containing the latitude and longitude values.

### ViewFilter

In this tag, specify a view ID if you want to narrow down the number of views from which to retrieve the necessary property values.

- In the *id* attribute, specify the ID of the view.

- In the *includeSubViews* attribute, specify whether or not to include the underlying subviews. Default: false

> [!NOTE]
> Specifying a *\<ViewFilter>* tag only works if the type attribute of the *\<PropertiesSourceInfo>* tag is set to “views”.

### ProtocolFilter

In this tag, specify the name of a protocol if you want the layer data only to be retrieved from properties of elements based on that specific protocol.

### PropertyFilters

In this optional tag, you can specify one or more filters in *\<PropertyFilter>* tags.

Use the following syntax:

```txt
value=[PropertyName][Operator][Value]
```

> [!NOTE]
>
> - There must be a space before and after the operator. Possible operators: == (equal to) and != (not equal to)
> - In a property filter, you can use placeholders referring to variables declared in the *\<PropertiesSourceInfo>* tag. The \[DMA_USERNAME\] placeholder, however, is a general placeholder that does not need to be declared. At runtime, it will be replaced by the name of the current user.

## Passing PropertiesSourceInfo data along in the map’s URL

The element, service and view filter can be passed along as a parameter in the map’s URL.

### elementDataVar

If you want to have an element placed on a map using location coordinates stored in another element, add an elementDataVar attribute to the *\<PropertiesSourceInfo>* tag, and set its value to “elementdata”.

Then assign the name of the element containing the coordinates to the elementdata variable in the map’s URL (with a “d” prefix”):

```txt
http://localhost/maps/map.aspx?config=mechelen&dview=Computer&delement=LocationElementName&delementdata=DataElementName
```

Result:

- The “location element” specified in the *element* variable will supply:

    - the location coordinates

    - the pop-up details (by default)

        > [!NOTE]
        > If you want to show data from another element in a pop-up balloon, refer to [Showing data of another element in a pop-up balloon](xref:PopupSkeleton_and_PopupDetails#showing-data-of-another-element-in-a-pop-up-balloon).

- The “data element” specified in the *elementdata* variable will supply:

    - the element name

    - the alarm color

    - the MarkerSelectionPID (i.e. the parameter containing the marker image ID)

- The properties filter will be applied on the “data element”.

> [!NOTE]
> It is possible to specify this attribute in the *\<ParametersSourceInfo>* tag instead. See [Passing ParametersSourceInfo data along in the map’s URL](xref:ParametersSourceInfo#passing-parameterssourceinfo-data-along-in-the-maps-url).

### elementVar

If, in the *\<PropertiesSourceInfo>* tag, you add an elementVar attribute with value “myElement” (referring to an element using the syntax “DMAID/ElementID” or “NameOfElement”), then you can use a map URL like one of the following instead (notice the “d” in front of the parameter name!):

```txt
maps.aspx?config=MyConfigFile&dmyElement=7/46840
maps.aspx?config=MyConfigFile&dmyElement=VesselData
```

### serviceVar

Similar to the elementVar attribute, you can also use the serviceVar attribute to pass a service name or service ID along in the map’s URL. To do so, add a serviceVar attribute with value “myService”, referring to a service using the syntax “DMAID/ServiceID” or “NameOfService”.

#### Example:

```xml
<PropertiesSourceInfo type="services" serviceVar="MyService"
...
</PropertiesSourceInfo>
```

You can then use a map URL like the following:

```txt
http://localhost/maps/map.aspx?config=managedservices&dMyService=ship
```

### idVar

If, in the *\<PropertiesSourceInfo>* tag, you add a *\<ViewFilter>* tag with an idVar attribute set to “myView” (referring to a view either by ID or by name), then you can pass the view as a parameter in the map’s URL like this (notice the “d” in front of the parameter name!):

```txt
maps.aspx?config=MyConfigFile&dmyView=specialview
```

> [!NOTE]
> In the value of an idVar attribute, you can specify several parameters separated by semicolons (”;”).

## Examples

### Example of a layer retrieving its data from element properties

```xml
<Layer sourceType="properties" refresh="20000">
  <PropertiesSourceInfo type="elements">
    <LatitudePropertyName>Latitude</LatitudePropertyName>
    <LongitudePropertyName>Longitude</LongitudePropertyName>
    <ViewFilter id="123" idVar="paramView" includeSubViews="true" />
    <ProtocolFilter>MyProtocol</ProtocolFilter>
  </PropertiesSourceInfo>
  <MarkerImages>
    <MarkerImage id="flags" url="images/icons/flag.png" width="20" height="32" anchor="0,32" single="false" shadowUrl="images/icons/flag_shadow.png" shadowWidth="37" shadowHeight="32" shadowAnchor="0,32" shapeType="poly"  shape="1,1,1,20,18,20,18,1" />
  </MarkerImages>
  <PopupSkeleton>
    <![CDATA[
      <p>Latitude: [latitude]</p>
      <p>Longitude: [longitude]</p>
    ]]>
  </PopupSkeleton>
  <PopupDetails>
    <Detail name="latitude" type="property" property="Latitude" />
    <Detail name="longitude" type="property" property="Longitude" />
  </PopupDetails>
</Layer>
```

### Example of a PropertiesSourceInfo tag containing property filters

```xml
<PropertiesSourceInfo type="elements" filterVars="customer">
  <LatitudePropertyName>Latitude</LatitudePropertyName>
  <LongitudePropertyName>Longitude</LongitudePropertyName>
  <ProtocolFilter>Demo</ProtocolFilter>
  <PropertyFilters>
    <PropertyFilter>Created by == [DMA_USERNAME]</PropertyFilter>
    <PropertyFilter>Customer == [customer]</PropertyFilter>
    <PropertyFilter>Latitude != n/a</PropertyFilter>
  </PropertyFilters>
</PropertiesSourceInfo>
```

### Example of a PropertiesSourceInfo tag containing an elementDataVar attribute

```xml
<Layer sourceType="properties" refresh="20000" autoFit="false" visible="false" allowToggle="true"  name="Properties">
  <PropertiesSourceInfo type="elements" elementVar="element" elementDataVar="elementdata">
    <LatitudePropertyName>Latitude</LatitudePropertyName>
    <LongitudePropertyName>Longitude</LongitudePropertyName>
  </PropertiesSourceInfo>
</Layer>
```
