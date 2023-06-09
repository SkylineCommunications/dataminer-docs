---
uid: Layer_types
---

# Layer types

The following types of layers can be used in a map configuration file:

- [Layers of sourceType 'clouds'](#layers-of-sourcetype-clouds)

- [Layers of sourceType 'connectivity'](#layers-of-sourcetype-connectivity)

- [Layers of sourceType 'objects'](#layers-of-sourcetype-objects)

- [Layers of sourceType 'overlay'](#layers-of-sourcetype-overlay)

- [Layers of sourceType 'parameters'](#layers-of-sourcetype-parameters)

- [Layers of sourceType 'properties'](#layers-of-sourcetype-properties)

- [Layers of SourceType 'relations'](#layers-of-sourcetype-relations)

- [Layers of sourceType 'separator'](#layers-of-sourcetype-separator)

- [Layers of sourceType 'sql'](#layers-of-sourcetype-sql)

- [Layers of sourceType 'table'](#layers-of-sourcetype-table)

- [Layers of sourceType 'traffic'](#layers-of-sourcetype-traffic)

- [Layers of sourceType 'weather'](#layers-of-sourcetype-weather)

- [Layers of sourceType 'weatherf'](#layers-of-sourcetype-weatherf)

## Layers of sourceType 'clouds'

Set the *sourceType* attribute of a layer to "clouds" if you want that layer to display cloud information.

> [!NOTE]
> For Google Maps, the Weather and Cloud layers are deprecated as of June 4, 2014. These are included in the Weather library, which is no longer available from June 4, 2015 onwards.
>
> As an alternative, you can combine OpenStreetMap and OpenWeatherMap instead. See [Configuring the DataMiner Maps host servers](xref:Configuring_the_DataMiner_Maps_host_servers) for more details.

## Layers of sourceType 'connectivity'

Available from DataMiner 9.6.9 onwards.

Set the *sourceType* attribute of a layer to "connectivity" if you want that layer to display DCF connections as lines between markers.

Within this layer, add a *\<LayerSourceInfo>* tag in which you specify the name of the layer that contains the objects of which the connections should be visualized. That layer must be of sourceType "objects".

> [!NOTE]
> In order to be displayed consistently, DCF connections and DCF properties need to be defined on both source and destination elements.

The following additional configuration is possible:

- You can configure the style of the connections in a *\<LineOptions>* tag. See [LineOptions](xref:LineOptions).

- If you want to show a DCF connection property in the *\<PopupSkeleton>* template, add a *\<Detail>* tag inside the *\<PopupDetails>* tag, and set its *type* attribute to "property" and its *property* attribute to the connection property name. See [PopupSkeleton](xref:PopupSkeleton_and_PopupDetails#popupskeleton).

Examples:

```xml
<Layers>
    <!--  SOURCE OBJECTS LAYER -->
    <Layer name="DataMiner Objects" sourceType="objects" refresh="10000" visible="true" allowToggle="true" autoFit="false" limitToBounds="false">
        <ObjectsSourceInfo>
            <!--  SERVICE: Earth  -->
            <!--  Contains child services for each continent  -->
            <!--  Each continent service contains elements representing cities  -->
            <ServiceChildren id="Earth" recursive="true" idVar="Continent">
                <Latitude>
                    <Property>Latitude</Property>
                </Latitude>
                <Longitude>
                    <Property>Longitude</Property>
                </Longitude>
            </ServiceChildren>
        </ObjectsSourceInfo>
        <MarkerImages>
            <MarkerImage id="cluster" url="images/icons/cluster-52px.png" width="52" height="52" anchor="26,26" single="false" shape="0,0,52,52" shapeType="rect"/>
        </MarkerImages>
        <PopupSkeleton>
            <![CDATA[ <h2>[city]</h2> <h4>Coordinates: ([latitude], [longitude])</h4> <h4>Element ID: [dmaid]/[eid]</h4> <img src="[image]" width="300"/> ]]>
        </PopupSkeleton>
        <PopupDetails>
            <Detail name="city" type="parameter" pid="1"/>
            <Detail name="image" type="property" property="Image"/>
        </PopupDetails>
    </Layer>
    <!--  DCF CONNECTIONS LAYER  -->
    <Layer name="DCF Connections" sourceType="connectivity" visible="true" allowToggle="true">
        <!--  Reference to the layer with source objects  -->
        <LayerSourceInfo>DataMiner Objects</LayerSourceInfo>
        <LineOptions weight="10" color="white" opacity="1"/>
        <PopupSkeleton>
            <![CDATA[ <h2>Connection: [title]</h2> <h4>Description: [description]</h4> <h4>Bandwidth: [bandwidth]</h4> ]]>
        </PopupSkeleton>
        <PopupDetails>
            <!--  Using properties defined on the DCF connections  -->
            <Detail name="description" type="property" property="Description"/>
            <Detail name="bandwidth" type="property" property="Bandwidth"/>
        </PopupDetails>
    </Layer>
</Layers>
```

## Layers of sourceType 'objects'

Available from DataMiner 9.6.7 onwards.

Set the *sourceType* attribute of a layer to "objects" if you want that layer to display information on elements or service elements.

In the *\<ObjectsSourceInfo>* tag of an "objects" layer, you can configure a collection of sources:

- *\<Element>* for individual elements

- *\<ServiceChildren>* for service child objects (i.e. elements and child services)

### Attributes for \<Element>

| Attribute | Description                                                                                                                                                                                                                                           |
|-----------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| id        | Element name or element ID (DMA ID/element ID)                                                                                                                                                                                                        |
| idVar     | Name of a variable that can be provided in the Maps URL, which will then be used as a dynamic ID.<br> For example, *idVar="MyElement"* will resolve the ID with the URL parameter *dMyElement*. |

### Attributes for \<ServiceChildren>

| Attribute | Description                                                                                                                                                                                                                                                                                                                     |
|-----------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| id        | Service name or service ID (DMA ID/service ID)                                                                                                                                                                                                                                                                                  |
| idVar     | Name of a variable that can be provided in the Maps URL, which will then be used as a dynamic ID.<br> For example, *idVar="MyService"* will resolve the ID with the URL parameter *dMyService*.                                                                           |
| recursive | Determines whether elements of child services will be included.<br> In an SRM setup, using *recursive="true"* will also allow you to show markers for contributing services. If a service in turn contains an enhanced service, any child elements or services it contains will be included as well. |

### Subtags of \<Element> and \<ServiceChildren>

| Tag          | Description                                                   |
|--------------|---------------------------------------------------------------|
| \<Latitude>  | Latitude coordinate (required).                               |
| \<Longitude> | Longitude coordinate (required).                              |
| \<Title>     | Marker title (optional, uses the DMA object name by default). |

Any of the above-mentioned subtags can contain raw text, a name of a property, or a parameter ID, optionally with table index.

Examples:

```xml
<Latitude>12.34</Latitude>
```

```xml
<Longitude>
    <Property>MyLongitudeProperty</Property>
</Longitude>
```

```xml
<Title>
    <Parameter>
        <ID>123</ID>
        <Index>MyTableIndex</Index>
    </Parameter>
</Title>
```

```xml
<!-- INDIVIDUAL ELEMENT MARKERS LAYER -->
<Layers>
    <Layer name="Individual Element Markers" sourceType="objects" refresh="10000" visible="false" allowToggle="true" autoFit="false" limitToBounds="false">
        <ObjectsSourceInfo>
            <!--  CITY 1: New York  -->
            <Element id="City 1">
                <Latitude>40.712776</Latitude>
                <Longitude>-74.005974</Longitude>
            </Element>
            <!--  CITY 1: Paris  -->
            <Element id="City 2">
                <Title>
                    <Parameter>
                        <ID>1</ID>
                    </Parameter>
                </Title>
                <Latitude>
                    <Property>Latitude</Property>
                </Latitude>
                <Longitude>
                    <Property>Longitude</Property>
                </Longitude>
            </Element>
            <!--  CITY 1: Buenos Aires  -->
            <Element id="City 3">
                <Title>
                    <Property>Title</Property>
                </Title>
                <Latitude>
                    <Parameter>
                        <ID>2</ID>
                    </Parameter>
                </Latitude>
                <Longitude>
                    <Parameter>
                        <ID>3</ID>
                    </Parameter>
                </Longitude>
            </Element>
            <!--  CITY 1: Sydney  -->
            <Element id="271/51461">
                <Title>***Sydney***</Title>
                <Latitude>
                    <Property>Latitude</Property>
                </Latitude>
                <Longitude>
                    <Property>Longitude</Property>
                </Longitude>
            </Element>
        </ObjectsSourceInfo>
        <MarkerImages>
            <MarkerImage id="cluster" url="images/icons/stars.png" width="20" height="20" anchor="10,10" single="false" shape="0,0,20,20" shapeType="rect"/>
        </MarkerImages>
        <PopupSkeleton>
            <![CDATA[ <h2>[title]</h2> <h4>Location: [city] ([latitude], [longitude])</h4> ]]>
        </PopupSkeleton>
        <PopupDetails>
            <Detail name="city" type="parameter" pid="1"/>
        </PopupDetails>
    </Layer>
</Layers>
```

```xml
<!-- RECURSIVE SERVICE ELEMENTS LAYER -->
<Layers>
    <Layer name="Recursive Service Elements" sourceType="objects" refresh="10000" visible="false" allowToggle="true" autoFit="false" limitToBounds="false">
        <ObjectsSourceInfo>
            <!--  SERVICE: Earth  -->
            <ServiceChildren id="Earth" recursive="true" idVar="Continent">
                <Latitude>
                    <Property>Latitude</Property>
                </Latitude>
                <Longitude>
                    <Property>Longitude</Property>
                </Longitude>
            </ServiceChildren>
        </ObjectsSourceInfo>
        <MarkerImages>
            <MarkerImage id="cluster" url="images/icons/cluster-52px.png" width="52" height="52" anchor="26,26" single="false" shape="0,0,52,52" shapeType="rect"/>
        </MarkerImages>
        <PopupSkeleton>
            <![CDATA[ <h2>[city]</h2> <h4>Coordinates: ([latitude], [longitude])</h4> <h4>Element ID: [dmaid]/[eid]</h4> <img src="[image]" width="300"/> ]]>
        </PopupSkeleton>
        <PopupDetails>
            <Detail name="city" type="parameter" pid="1"/>
            <Detail name="image" type="property" property="Image"/>
        </PopupDetails>
    </Layer>
</Layers>
```

```xml
<!--  SRM EXPOSE FLOW SETUP  -->
<Layers>
    <Layer name="SRM Expose Flow" sourceType="objects" refresh="10000" visible="false" allowToggle="true" autoFit="false" limitToBounds="false">
        <ObjectsSourceInfo>
            <ServiceChildren id="SRM - Expose Flow Service" recursive="true">
                <Title>
                    <Property>Title</Property>
                </Title>
                <Latitude>
                    <Property>Latitude</Property>
                </Latitude>
                <Longitude>
                    <Property>Longitude</Property>
                </Longitude>
            </ServiceChildren>
        </ObjectsSourceInfo>
        <MarkerImages>
            <MarkerImage id="cluster" url="images/icons/cluster-52px.png" width="52" height="52" anchor="26,26" single="false" shape="0,0,52,52" shapeType="rect"/>
        </MarkerImages>
        <PopupSkeleton>
            <![CDATA[ <h1>[title]: [location]</h1> <img src="images/srm-expose-flow/[image].jpg" width="300"/> ]]>
        </PopupSkeleton>
        <PopupDetails>
            <Detail name="location" type="property" property="Location"/>
            <Detail name="image" type="property" property="Image"/>
        </PopupDetails>
    </Layer>
</Layers>
```

## Layers of sourceType 'overlay'

Set the *sourceType* attribute of a layer to "overlay" if you want that layer to display a static image or if you want to create a GeoJSON layer. The image can be either a common JPG, PNG or GIF image (stored either locally on a DMA or somewhere on the internet), or a special KML image (stored either locally on a DMA, or on a publicly accessible web server).

- [Overlays of type 'image'](#overlays-of-type-image)

- [Overlays of type 'kml'](#overlays-of-type-kml)

- [Overlays of type 'geojson'](#overlays-of-type-geojson)

### Overlays of type 'image'

If you want a layer of sourceType "overlay" to display a JPG, PNG or GIF image, do the following.

1. Inside the *\<Layer>* tag, add a *\<GroundOverlay>* tag.

2. Set the type attribute to "image".

3. In the src attribute, specify the path to the image file.

    - an absolute path (starting with `http://`), or

    - a path relative to `C:\Skyline DataMiner\Webpages\Maps\`

4. Anchor the image to the map by linking its top-left corner and lower right corner to map coordinates.

    - Inside the *\<GroundOverlay>* tag, add a *\<TopLeft>* and a *\<BottomRight>* tag.

    - Specify the map coordinates in the latitude and longitude attributes.

Example:

```xml
<Layer sourceType="overlay">
    <GroundOverlay type="image" src="images/test/mechelen-overlay.JPG">
        <TopLeft latitude="51.030748" longitude="4.494814" />
        <BottomRight latitude="51.032873" longitude="4.500221" />
    </GroundOverlay>
</Layer>
```

### Overlays of type 'kml'

If you want a layer of sourceType "overlay" to display a KML image, do the following:

1. Inside the *\<Layer>* tag, add a *\<GroundOverlay>* tag.

2. Set the type attribute to "kml".

3. Depending on whether you want the KML files to be publicly available or not, specify a different attribute:

    - For a publicly available KML file, in the *publicHref* attribute, specify the URL of the KML file.

        Example:

        ```xml
        <Layer sourceType="overlay" name="My KML Layer" allowToggle="true" visible="false" toggleGroup="myGroup">
            <GroundOverlay type="kml" publicHref="http://www.mysite.com/kml/myfile.kml">
            </GroundOverlay>
        </Layer>
        ```

    - For a private KML file, in the *privateFilePath* attribute, specify the file path on the DMA where the file can be found.

        Example:

        ```xml
        <Layer sourceType="overlay" name="My KML Layer" allowToggle="true" visible="false" toggleGroup="myGroup">
            <GroundOverlay type="kml" privateFilePath="C:\Skyline DataMiner\Maps\KMLs\myfile.kml">
            </GroundOverlay>
        </Layer>
        ```

> [!NOTE]
>
> - Do not store private KML files in the folder `C:\Skyline DataMiner\Webpages` (or any subfolder). Files in that folder will be publicly accessible.
> - If you use a private KML file, only users who have logged on to DataMiner Maps will be able to request a download link. The download links can be used only once and expire after 5 minutes.
> - If you use a private KML file, your DataMiner Agent (at least the `https://mydma.company.com/API/*` URL) must be publicly accessible, so that Google Maps can download the KML file from the DataMiner Agent and render it.
> - For more information on the KML file format, see [http://code.google.com/apis/kml/documentation/mapsSupport.html](http://code.google.com/apis/kml/documentation/mapsSupport.html).
> - KML layers are always used as the bottom layers of the map, while other layers are drawn from top to bottom as defined in the configuration.

### Overlays of type 'geojson'

From DataMiner 9.5.8 onwards, you can add a GeoJSON layer. To do so:

1. Inside the *\<Layer>* tag, add a *\<GroundOverlay>* tag.

2. Set the *type* attribute of the *\<GroundOverlay>* tag to "geojson".

3. Set the *src* attribute of the *\<GroundOverlay>* tag to the address of the file, i.e. a URL starting with `http://` or `https://`, or a path relative to `C:\Skyline DataMiner\Webpages\Maps`.

Example:

```xml
<Layer name="GeoJSON Layer" sourceType="overlay" visible="true" autoFit="true" allowToggle="true">
    <GroundOverlay type="geojson" src="https://storage.googleapis.com/mapsdevsite/json/google.json">
    </GroundOverlay>
</Layer>
```

## Layers of sourceType 'parameters'

Set the *sourceType* attribute of a layer to "parameters" if you want that layer to display objects positioned according to latitude and longitude values stored in element or service parameters, and use the following tags to configure the layer.

- ParametersSourceInfo

- MarkerImages

- MarkerDetails

- PopupSkeleton and PopupDetails

For more information on those tags, see [Layer configuration tags](xref:Layer_configuration_tags).

> [!NOTE]
> On layers of sourceType "parameters", no markers will be shown unless an element variable is specified in the map URL and a match is found for this variable.

## Layers of sourceType 'properties'

Set the *sourceType* attribute of a layer to "properties" if you want that layer to display objects positioned according to latitude and longitude values retrieved from properties of DataMiner views, elements or services, and use the following tags to configure the layer.

- PropertiesSourceInfo

- MarkerImages

- MarkerDetails

- PopupSkeleton and PopupDetails

For more information on those tags, see [Layer configuration tags](xref:Layer_configuration_tags).

## Layers of SourceType 'relations'

Set the *sourceType* attribute of a layer to "relations" if you want that layer to display lines between objects that are related via foreign key relationships in a DataMiner element. If, for example, an EPM element has a Household and an Amplifier table that are linked by means of foreign key relationships, the links between those two tables can be visualized on a map.

Example:

```xml
<Layer sourceType="relations" allowToggle="true" name="FKs" visible="true" refresh="50000"  limitToBounds="true">
    <ForeignKeyRelationsSourceInfo>
        <DataMinerID>7</DataMinerID>
        <ElementID>507057</ElementID>
        <SourceTableID>50101</SourceTableID>
        <DestinationTableID>101</DestinationTableID>
        <SourceLatitudeColumnPID>50114</SourceLatitudeColumnPID>
        <SourceLongitudeColumnPID>50116</SourceLongitudeColumnPID>
        <DestinationLatitudeColumnPID>114</DestinationLatitudeColumnPID>
        <DestinationLongitudeColumnPID>116</DestinationLongitudeColumnPID>
        <!-- Optionally, a chain name can be specified in case multiple paths are possible -->
        <Chain></Chain>
    </ForeignKeyRelationsSourceInfo>
    <LineOptions weight="1" color="black" opacity="0.5" geodesic="true" />
</Layer>
```

From DataMiner 9.6.0 CU3/9.6.9 onwards, the following additional filters can be specified in the *\<ForeignKeyRelationsSourceInfo>* tag to filter the possible connection lines: *\<SourceTableFilters>*, *\<DestinationTableFilters>* and *\<ParentFilter>*.

*\<ParentFilter>* is specifically designed to enhance performance when filtering large tables based on another (parent) table. In the following example, the connection lines of the layer where the filter is defined are filtered based on the foreign key relation to the table in which column 1002 is equal to the value of the *SelectedRow* placeholder (received via the URL parameter "dSelectedRow"):

```xml
<ParentFilter>
    <ParentColumnPID>1002</ParentColumnPID>
    <ParentValue>[SelectedRow]</ParentValue>
</ParentFilter>
```

> [!NOTE]
> - To make sure correct results are returned, *\<SourceTableID>* and *\<DestinationTableID>* have to be in the correct order.
> - Optionally, the *\<LineOptions>* tag can be used in this tag. See [LineOptions](xref:LineOptions).
> - From DataMiner 10.0.3 onwards, the *recursivefullfilter* option is supported for table filters. See [Dynamic table filter syntax](xref:Dynamic_table_filter_syntax).

## Layers of sourceType 'separator'

Set the *sourceType* attribute of a layer to "separator" if you want that layer to be a dummy layer of which the only function is to display a kind of "section title" in a layer group.

For more information, see [Separators in layer groups](xref:Layer_groups#separators-in-layer-groups).

## Layers of sourceType 'sql'

Set the *sourceType* attribute of a layer to "sql" if you want that layer to display objects positioned according to latitude and longitude values retrieved from a database table, and use the following tag to configure the layer.

- SqlSourceInfo

For more information on that tag, see [SqlSourceInfo](xref:SqlSourceInfo).

## Layers of sourceType 'table'

Set the *sourceType* attribute of a layer to "table" if you want that layer to display objects positioned according to latitude and longitude values retrieved from a dynamic table of a particular DataMiner element, and use the following tags to configure the layer.

- TableSourceInfo

- LineOptions

- MarkerImages

- MarkerDetails

- PopupSkeleton and PopupDetails

For more information on those tags, see [Layer configuration tags](xref:Layer_configuration_tags).

## Layers of sourceType 'traffic'

Set the *sourceType* attribute of a layer to "traffic" if you want that layer to display traffic information.

> [!NOTE]
> Traffic information is only retrieved once, and not refreshed afterwards. This means that the "refresh" attribute does not work for layers of sourceType 'traffic'. See [refresh](xref:Attributes_of_the_Layer_tag#refresh).

## Layers of sourceType 'weather'

Set the *sourceType* attribute of a layer to "weather" if you want that layer to display weather information with temperatures in degrees Celsius.

> [!NOTE]
> For Google Maps, the Weather and Cloud layers are deprecated as of June 4, 2014. These are included in the Weather library, which is no longer available from June 4, 2015 onwards.
>
> As an alternative, you can combine OpenStreetMap and OpenWeatherMap instead. See [Configuring the DataMiner Maps host servers](xref:Configuring_the_DataMiner_Maps_host_servers) for more details.

## Layers of sourceType 'weatherf'

Set the *sourceType* attribute of a layer to "weatherf" if you want that layer to display weather information with temperatures in degrees Fahrenheit.

> [!NOTE]
> For Google Maps, the Weather and Cloud layers are deprecated as of June 4, 2014. These are included in the Weather library, which is no longer available from June 4, 2015 onwards.
>
> As an alternative, you can combine OpenStreetMap and OpenWeatherMap instead. See [Configuring the DataMiner Maps host servers](xref:Configuring_the_DataMiner_Maps_host_servers) for more details.
