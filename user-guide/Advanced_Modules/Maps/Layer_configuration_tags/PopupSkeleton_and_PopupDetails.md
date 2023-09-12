---
uid: PopupSkeleton_and_PopupDetails
---

# PopupSkeleton and PopupDetails

In the `<PopupSkeleton>` and `<PopupDetails>` tags, you can specify the contents of the balloon that will appear when you click a marker.

## PopupSkeleton

In the `<PopupSkeleton>` tag, specify all fixed content, including the necessary placeholders for variable data. Use HTML syntax inside a CDATA tag and put the placeholders between square brackets.

> [!NOTE]
>
> - Marker balloons can contain tab controls. These tab controls, which are based on a CSS class called “tabs”, have to be designed as shown in [Showing values returned by an SQL query](#showing-values-returned-by-an-sql-query): an enumeration of the tab titles, followed by the contents of each tab.
> - The placeholders [latitude], [longitude], and [alarmstate] can be used directly in the PopupSkeleton definition without the need to define them in a PopupDetails element. They will display the coordinates and alarm state of the actual marker, respectively.
> - You can specify a list of EPM tables in the PopupSkeleton tag, which will be displayed in a marker pop-up balloon. For an example, see [Displaying EPM tables in a marker pop-up balloon](#displaying-epm-tables-in-a-marker-pop-up-balloon).

> [!TIP]
> See also:
> [Examples of PopupSkeleton and PopupDetails configuration](#examples-of-popupskeleton-and-popupdetails-configuration)

## PopupDetails

In the `<PopupDetails>` tag, add a `<Detail>` tag for every placeholder used in the `<PopupSkeleton>` tag.

### Attributes of the Detail tag

#### alarmFilter

The name of a predefined DataMiner Cube alarm filter.

If you specify "alarmcount" in the *Type* attribute to retrieve the number of alarms linked to a particular item, you can use this *alarmFilter* attribute to specify a predefined alarm filter to e.g. retrieve only the number of critical alarms.

#### alias

The alias of an element in a service.

Allows detail placeholders.

#### detailVars

A semicolon-separated list of detail names, which can then be used within attributes that support detail placeholders.

See [Placeholders](#placeholders).

#### element

Either an element ID (DMA ID/Element ID) or an element name.

Allows detail placeholders.

#### elementVar

Can be used to refer to URL parameters, similar to when this attribute is used in the `<ParametersSourceInfo>` tag, for example.

See [elementVar](xref:ParametersSourceInfo#elementvar).

#### idx

The index of a table parameter.

Allows detail placeholders.

#### name

The name of the corresponding placeholder in the `<PopupSkeleton>` tag.

#### parameter

A parameter ID.

Allows detail placeholders. With this attribute, you can also specify enhanced services parameters.

#### pid

A parameter ID.

#### property

The name of a property.

Allows detail placeholders.

#### service

A service ID (dmaId/serviceId) or a service name.

Allows detail placeholders.

#### serviceVar

Can be used to refer to URL parameters, similar to when this attribute is used in the `<ParametersSourceInfo>` tag, for example.

See [serviceVar](xref:ParametersSourceInfo#servicevar).

#### view

A view ID or a view name preceded by a dot (".").

#### type

See [Type overview](#type-overview).

### Type overview

#### element/[element subtype] - viewelement/[element subtype] - elementalias/[element subtype]

Instead of *[element subtype]*, depending on what should be retrieved, specify the following:

- *id*: Element ID (format: dmaId/elementId).
- *name*: Element name.
- *parameter*/*[parameter subtype]*: A parameter detail.

  For more information on the possible details that can be retrieved, see [parameter/[parameter subtype]](#parameterparameter-subtype) below.

- *property*: A property of the element.
- *alarmcount*: The number of alarms linked to the element.
- *alarmstate*: The current alarm state of the element.

#### marker/[marker subtype]

This type can be used to retrieve element, parameter, service, or view information, depending on the actual marker type.

Instead of *[marker subtype]*, depending on what should be retrieved, specify the following:

- *id*: The ID of the element/parameter/service/view.
- *name*: The name of the element/parameter/service/view.
- *alarmcount*: The number of alarms linked to the element/parameter/service/view.
- *alarmstate*: The current alarm state of the element/parameter/service/view.

#### parameter/[parameter subtype]

When retrieving a parameter value of an element, only *parameter* needs to be specified. See [Specific PopDetails configurations](#specific-popdetails-configurations).

The following can be specified instead of *[parameter subtype]*:

- *value*: The parameter value.
- *name*: The parameter name.
- *alarmcount*: The number of alarms linked to the parameter.
- *alarmstate*: The current alarm state of the parameter.

#### parameter_elementalias

Used when retrieving a parameter of a child element of a service on the map. See [Specific PopDetails configurations](#specific-popdetails-configurations).

#### parameter_samerow

Used to retrieve cell values from a dynamic table row. See [Specific PopDetails configurations](#specific-popdetails-configurations).

#### property

Used when retrieving a property for a particular element, service, or view. See [Specific PopDetails configurations](#specific-popdetails-configurations).

#### property_elementalias

Used when retrieving a property of a child element of a service on the map. See [Specific PopDetails configurations](#specific-popdetails-configurations).

#### service/[service subtype]

Instead of *[service subtype]*, depending on what should be retrieved, specify the following:

- *id*: The service ID (format: dmaId/serviceId).
- *name*: The service name.
- *property*: A property of the service.
- *alarmcount*: The number of alarms linked to the service.
- *alarmstate*: The current alarm state of the service.

#### view/[view subtype]

Instead of *[view subtype]*, depending on what should be retrieved, specify the following:

- *id*: The view ID.
- *name*: The view name.
- *property*: A property of the view.
- *alarmcount*: The number of alarms linked to the view.
- *alarmstate*: The current alarm state of the view.

### Specific PopDetails configurations

In each `<Detail>` tag, the attributes that should be specified depend on what is to be retrieved:

- To retrieve cell values from the currently selected dynamic table row, in case of a layer of sourceType “table”, use the following configuration:

  | Attribute | Value |
  |-----------|-------|
  | name      | Name of the corresponding placeholder in the `<PopupSkeleton>` tag |
  | type      | *parameter_samerow* |
  | pid       | The column ID |

- To retrieve property values belonging to the current element, service, or view, in case of a layer of sourceType “properties”, use the following configuration for the `<PopupDetail>` tags:

  | Attribute | Value |
  |-----------|-------|
  | name      | Name of the corresponding placeholder in the `<PopupSkeleton>` tag |
  | type      | *property* |
  | property  | The name of the property that is to be retrieved |

- To retrieve parameter values belonging to an element, in case of a layer of sourceType “parameters”, use the following configuration:

  | Attribute | Value |
  |-----------|-------|
  | name      | Name of the corresponding placeholder in the `<PopupSkeleton>` tag |
  | type      | *parameter* |
  | pid       | The ID of the parameter that is to be retrieved. For a table parameter, this should be the column ID. |
  | idx       | The row index, in case the parameter is a table parameter. (Optional) |

- To show property values from an element included in a service on the map, in case of a layer of sourceType “properties” or “parameters”, use the following configuration:

  | Attribute | Value |
  |-----------|-------|
  | name      | Name of the corresponding placeholder in the `<PopupSkeleton>` tag |
  | type      | *property_elementalias* |
  | alias     | The alias of the element in the service. If no alias is configured, specify the actual name of the element instead. |
  | property  | The name of the property that is to be retrieved |

- To show parameter values from an element included in a service on the map, in case of a layer of sourceType “properties” or “parameters”, use the following configuration:

  | Attribute | Value |
  |-----------|-------|
  | name      | Name of the corresponding placeholder in the `<PopupSkeleton>` tag |
  | type      | *parameter_elementalias* |
  | alias     | The alias of the element in the service. If no alias is configured, specify the actual name of the element instead. |
  | pid       | The ID of the parameter that is to be retrieved |

## Placeholders

The following placeholders do not need to be defined in `<Detail>` tags. They are always available (depending on the context):

| Placeholder  | Description                  |
|--------------|------------------------------|
| [dmaid]      | DataMiner ID                 |
| [eid]        | Element ID                   |
| [sid]        | Service ID                   |
| [viewid]     | View ID                      |
| [pid]        | Parameter ID                 |
| [primarykey] | Primary key of the parameter |
| [dispkey]    | Display key of the parameter |

If you wish to use another detail placeholder in a suitable `<Detail>` tag attribute, that detail placeholder needs to be defined and included in the *detailVars* attribute. See the following example:

```xml
<PopupDetails>
  <Detail name="headendid" type="parameter" pid="5003"/>
  <Detail name="headendlat" type="parameter" pid="3004" idx="[headendid]" detailVars="headendid"/>
  <Detail name="headendlong" type="parameter" pid="3005" idx="[headendid]" detailVars="headendid"/>
  <Detail name="headendstate" type="parameter/alarmstate" pid="3003" idx="[headendid]" detailVars="headendid"/>
  <Detail name="regionid" type="parameter" pid="3002" idx="[headendid]" detailVars="headendid"/>
  <Detail name="regionname" type="parameter" pid="1002" idx="[regionid]" detailVars="regionid"/>
</PopupDetails>
```

To determine the detail source, the following items are checked (in this order):

- element/parameter/view/service/property/alias/idx attributes

- dmaid/eid/pid attributes (including previously resolved elementVar/serviceVar/idVar)

- the actual marker context

> [!NOTE]
> It is not possible to use a URL parameter like *myElement* or *myService* as a detail placeholder in the *detailVars* attribute.
>
> To use URL parameters, specify an *elementVar* or *serviceVar* attribute, or add a `<ViewFilter>` subtag within the `<Details>` tag, and add the parameter using the *idVar* attribute in the subtag. E.g.: `<ViewFilter includeSubViews="true" idVar="myView" />`. A similar `<ViewFilter>` subtag can be used in the `<PropertiesSourceInfo>` tag. For more information, see [idVar](xref:PropertiesSourceInfo#idvar).

## Examples of PopupSkeleton and PopupDetails configuration

### Showing cell values from a dynamic table row

An example where placeholders are replaced by cell values from the currently selected dynamic table row:

```xml
<PopupSkeleton>
  <![CDATA[
    <p>Latitude: [latitude]</p>
    <p>Longitude: [longitude]</p>
  ]]>
</PopupSkeleton>
<PopupDetails>
  <Detail name="latitude" type="parameter_samerow" pid="114" />
  <Detail name="longitude" type="parameter_samerow" pid="116" />
</PopupDetails>
```

### Showing property values

An example where placeholders are replaced by property values retrieved from the current element, service, or view:

```xml
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
```

### Showing parameter values

An example where placeholders are replaced by parameter values retrieved from the current element or service:

```xml
<PopupSkeleton>
  <![CDATA[
    <p>[customparametervalue]</p>
  ]]>
</PopupSkeleton>
<PopupDetails>
  <Detail name="customparametervalue" type="parameter" pid="102" />
</PopupDetails>
```

### Showing parameter values from an element included in a service

An example where placeholders are replaced with parameter values from an element included in a service shown on the map.

```xml
<PopupSkeleton>
  <![CDATA[
    <p>Latitude: [Latitude]</p>
    <p>Longitude: [Longitude]</p>
  ]]>
</PopupSkeleton>
<PopupDetails>
  <Detail name="Latitude" type="parameter_elementalias" alias="tab" pid ="503" idx="1" />
  <Detail name="Longitude" type="parameter_elementalias" alias="tab" pid="505" idx="1"/>
</PopupDetails>
```

### Displaying a map layer

An example of a marker balloon containing a map layer:

```xml
<PopupSkeleton>
  <![CDATA[
    <a href="#" class="showlayer">MySpecialLayer</a>
  ]]>
</PopupSkeleton>
```

> [!NOTE]
> The layer name can also be a placeholder for a variable defined in the `<PopupDetails>` section.
>
> Example: `<a href=”#” class=”showlayer”><small>[Network]</small></a>`

### Showing values returned by an SQL query

On a layer of sourceType “sql”, you can show marker balloons containing values returned by an SQL query.

The “column” attributes of the `<Detail>` tags have to contain name of columns in the SQL query result.

> [!NOTE]
> The SQL query has to return unique PrimaryKey values.

```xml
<Layer sourceType="sql" refresh="1800000" name="Date Picker" visible="false" allowToggle="true" toggleGroup="Route Trace" option="datepicker">
  <SqlSourceInfo style="lines" filterVars="datefrom;dateto">
    <DataMinerID>157</DataMinerID>
    <Sql><![CDATA[
      SELECT b.GPSLat AS Latitude,
           b.GPSLong AS Longitude,
           c.GPSLatPrev AS Latitude2,
           c.GPSLongPrev AS Longitude2,
           b.GPSName AS Title,
           b.AutoInc AS PrimaryKey,
           b.TimeStamp AS Timestamp,
           b.GPSCustom2 As AlarmLevel
      FROM....;
    ]]></Sql>
  </SqlSourceInfo>
  <PopupSkeleton>
    <![CDATA[
    <div class="tabs" style="height:250px;font-size:120%; border-width:0;padding-top:15px;">
      <ul><li><a href="#tabs-1">General</a></li></ul>
      <div id="tabs-1">
      <p>[Title]</p>
      <table border="1" cellpadding="3" cellspacing="0" width="300">
        <tr>
          <td><small>Latitude</small></td>
          <td><small>[Latitude]</small></td>
        </tr>
        <tr>
          <td><small>Longitude</small></td>
          <td><small>[Longitude]</small></td>
        </tr>
        <tr>
          <td><small>Timestamp</small></td>
          <td><small>[Timestamp]</small></td>
        </tr>
        <tr>
          <td><small>AlarmLevel</small></td>
          <td><small>[AlarmLevel]</small></td>
        </tr>
      </table>
    </div>
    ]]>
  </PopupSkeleton>
  <PopupDetails>
    <Detail name="Title" type="sql_samerow" column="Title" />
    <Detail name="Latitude" type="sql_samerow" column="Latitude" />
    <Detail name="Longitude" type="sql_samerow" column="Longitude" />
    <Detail name="Timestamp" type="sql_samerow" column="Timestamp" />
    <Detail name="AlarmLevel" type="sql_samerow" column="AlarmLevel" />
  </PopupDetails>
</Layer>
```

### Showing data of another element in a pop-up balloon

It is possible to show data from another element in a pop-up balloon.

That other element can be selected in two ways:

- By specifying the other element in the URL of the map.
- By putting the data element in the same view as the marker element.

#### Specifying the other element in the URL of the map

Pass the other element in a URL variable:

`http://localhost/maps/map.aspx?config=MyTest&dpopupdata=MyOtherElement`

Refer to that variable in the configuration file:

```xml
<PopupDetails>
  <Detail name="longitude" type="property" property="longitude" elementVar="popupdata" />
</PopupDetails>
```

> [!NOTE]
> The URL variable has to contain either the element name or the element ID (i.e. DmaID/ElementID).

#### Putting the data element in the same view as the marker element

Create a view that contains two elements: the marker element (i.e. the element containing the marker coordinates) and the data element (i.e. the element that contains the data to be shown in the pop-up balloon). Use `<Detail>` tags of type *parameter_sameviewelement* or *property_sameviewelement* to fetch data from the data element:

```xml
<PopupDetails>
  <Detail name="longitude" type="parameter_sameviewelement" pid="350" />
  <Detail name="latitude" type="property_sameviewelement" property="latitude" />
</PopupDetails>
```

### Adding tab pages to a marker balloon

An example of a marker balloon with three tabs:

```xml
<PopupSkeleton>
  <![CDATA[
    <div class="tabs" style="font-size:12px;height:100px;width:300px;">
      <ul>
        <li>
          <a href="#tabs-1">Tab Title 1</a>
        </li>
        <li>
          <a href="#tabs-2">Tab Title 2</a>
        </li>
        <li>
          <a href="#tabs-3">Tab Title 3</a>
        </li>
      </ul>
      <div id="tabs-1">Contents of tab 1.</div>
      <div id="tabs-2">Contents of tab 2.</div>
      <div id="tabs-3">Contents of tab 3.</div>
    </div>
   ]]>
</PopupSkeleton>
```

On the map, the above-mentioned code will be rendered in the following way.

![Tab pages in a marker balloon](~/user-guide/images/maps_balloon_tabs.png)

### Displaying EPM tables in a marker pop-up balloon

In the following example, the contents of columns 7002, 7005, and 7006 from table 7000 will be displayed in divisions #CM, #eMTA, and #STB respectively, and they will be filtered based on the content of column 7003, which will be compared against the value of the “data-cpe-type” attribute.

```xml
<PopupSkeleton>
  <![CDATA[
    <div class="tabs" style="font-size:12px;min-height:158px;">
      <ul>
        <li><a href="#General">General</a></li>
        <li><a href="#CM">CM</a></li>
        <li><a href="#eMTA">eMTA</a></li>
        <li><a href="#STB">STB</a></li>
      </ul>
      <div id="General">
        <p>[dispkey]</p>
        <p>Latitude: [latitude]</p>
        <p>Longitude: [longitude]</p>
      </div>
      <div class="cpe definition">
        7000|7003|7002,7005,7006
      </div>
      <div id="CM" class="cpe data" data-cpe-type="CM">
        7000
      </div>
      <div id="eMTA" class="cpe data" data-cpe-type="eMTA">
        7000
      </div>
      <div id="STB" class="cpe data" data-cpe-type="STB">
        7000
      </div>
    </div>
  ]]>
</PopupSkeleton>
```

### Navigating to EPM information from a map using JavaScript

It is possible to configure the `<PopupSkeleton>` tag so that a user can navigate from the pop-up balloon to the EPM interface or display particular EPM information from the pop-up balloon.

To do so, you can use the following JavaScript methods:

- `NavigateCPEChain(int dataminerID, int elementID, string chain, int columnOrTablePid, string primaryKey)`

  Selects an item in the EPM interface on the given element and chain. To only open the chain, set the last two arguments to -1 and ''.

- `OpenCPEKPIPopup(int columnOrTablePid, string value)`

  Opens a KPI pop-up window on the current chain of the given item.

- `OpenCPELinksPopup(int columnOrTablePid, string value, string linksName)`

  Opens the links pop-up window with the name passed in linksName on the current chain of the given item.

- `OpenCPEKPIPopupFromChain(string chain, int columnOrTablePid, string value)`

  Opens the KPI pop-up window on the given chain of the given item.

- `OpenCPELinksPopupFromChain(string chain, int columnOrTablePid, string columnPK, string linksName)`

  Opens the links pop-up window with the name passed in linksName on the given chain of the given item.

Example:

```xml
<PopupSkeleton>
  <![CDATA[
    <p>[dispkey]</p>
    <p>Latitude: [latitude]</p>
    <p>Longitude: [longitude]</p>
    <p><a href="javascript:window.external.NavigateCPE([dmaid], [eid], [pid], [pid], '[primarykey]');">Open ([dispkey])</a></p>
    <p><a href="javascript:window.external.NavigateCPEChain([dmaid], [eid], 'topology2', [pid],'[primarykey]');">Open ([dispkey]) in Topology2</a></p>
    <p><a href="javascript:window.external.NavigateCPEChain([dmaid], [eid], 'topology2', 0,'');">Topology2</a></p>
    <p><a href="javascript:window.external.NavigateCPEChain(57, 7, 'topology2', 0,'');">Topology2 on other element</a></p>
    <p><a href="javascript:window.external.OpenCPEKPIPopup([pid],'[primarykey]');">Open KPIs</a></p>
    <p><a href="javascript:window.external.OpenCPELinksPopup([pid],'[primarykey]', 'Customers');">Open Customers</a></p>
  ]]>
</PopupSkeleton>
```

![Navigating to EPM information from a map](~/user-guide/images/maps_popupskeleton_CPElinks.png)
