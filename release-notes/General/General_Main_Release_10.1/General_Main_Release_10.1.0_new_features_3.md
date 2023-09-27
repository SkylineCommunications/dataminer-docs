---
uid: General_Main_Release_10.1.0_new_features_3
---

# General Main Release 10.1.0 - New features (part 3)

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!NOTE]
> **Internet Explorer Support**
>
> Though DataMiner Cube is available as a desktop application, many users still like to use the DataMiner browser application that requires Internet Explorer. However, Microsoft no longer recommends using Internet Explorer, and support for Internet Explorer is expected to cease in 2025, though currently the program is still maintained as part of the support policy for the versions of Windows it is included in. For more information, see <https://docs.microsoft.com/en-us/lifecycle/faq/internet-explorer-microsoft-edge>.
>
> The preferred way to use DataMiner Cube is as a desktop application, which can be downloaded from each DMA’s landing page in any other browser than Internet Explorer. From DataMiner 10.0.9 onwards, this application also comes with a new start window for increased ease of use.
>
> However, if you do wish to use DataMiner Cube in a browser, this remains possible:
>
> - Microsoft Edge can be configured to open specific URLs in IE compatibility mode. If you configure Edge to open the DataMiner Cube URLs of DMAs in this mode, you will be able to access the DMAs with DataMiner Cube in Edge. However, make sure you only do this for the exact URLs of DataMiner Cube, as other DataMiner apps will not function optimally in IE compatibility mode. For more information see, <https://docs.microsoft.com/en-us/DeployEdge/edge-ie-mode-policies>.
> - You can still continue to use Internet Explorer to access DataMiner Cube as long as Microsoft support continues. However, in this case we highly recommend to use a different browser to access any other websites on the internet.

### DMS Cube (Visual Overview)

#### Visual Overview: Number groups in numeric parameter values displayed on element shapes will now be separated by a thin space / New DynamicUnits option \[ID_18321\]\[ID_26318\]\[ID_26330\]\[ID_26697\]\[ID_27544\]

In Visual Overview, three-digit number groups in numeric parameter values displayed on shapes with an *Element* and/or *Parameter* data field and a “\*” in the shape text will now by default be separated by a thin space. This will make large numbers more legible.

Also, a new *DynamicUnits* option will now allow you to enable the use of dynamic units, i.e. units that can be converted to other units according to rules configured in the protocol. You may decide to enable this feature if you want to have large values converted to more legible values (e.g. to convert 1000 Mb to 1 Gb, 1000 m to 1 km, etc.).

To enable this feature, add an *Options* data field and set its value to “DynamicUnits=true”. By default, this option is disabled (i.e. false). See the following example:

| Shape data field | Value             |
|------------------|-------------------|
| Element          | MyElement         |
| Parameter        | 25                |
| Options          | DynamicUnits=true |

If you enable the *DynamicUnits* option, the following units will be converted out of the box:

- bytes (B)

- bits (b)

- bits per second (bps)

- bytes per second (Bps)

- Kibibytes (kiB)

- no unit (\<empty>)

If you want other units to be converted when you enable the *DynamicUnits* option, you can define this in the element protocol. See the example below.

Suppose you want to apply the following unit conversion rule:

- Display value in mm if value \< 1 cm.

- Display value in cm if value \> 1 cm.

- Display value in m if value \> 1 m.

- Display value in km if value \> 1 km.

Then, in the protocol, add the following configuration:

```xml
<Display>
  <RTDisplay>true</RTDisplay>
  <Units>m</Units>
  <DynamicUnits>
    <Unit>mm</Unit>
    <Unit>cm</Unit>
    <Unit>km</Unit>
  </DynamicUnits>
  <Decimals>2</Decimals>
  ..
</Display>
```

It is also possible to factor in decimals defined in the dynamic units of a protocol parameter when using the *DynamicUnits* option. With a configuration like the following, a value of 0.15 m will be shown as 15.0 cm (i.e. with 1 decimal).

```xml
<Display>
  <RTDisplay>true</RTDisplay>
  <Units>m</Units>
  <DynamicUnits>
    <Unit>mm</Unit>
    <Unit decimals=”1”>cm</Unit>
    <Unit decimals=”3”>km</Unit>
  </DynamicUnits>
  <Decimals>2</Decimals>
  ..
</Display>
```

> [!NOTE]
> If parameter values of parameters with “decimals” set to 1 or less are converted to a bigger unit, these will be displayed with such a number of decimals that there are at least 3 significant figures. For example, 1320 MB will be displayed as 1.32 GB, even if the parameter has 0 decimals defined.

#### Visual Overview - Trend component: Filtering the legend’s element list and collapsing or expanding the legend by default \[ID_24349\]

When a shape is showing a trend component, it is now possible to

- filter the list of elements in the legend based on the value of a property of the Visio shape (see the *Filter* data item in the example below), and

- collapse or expand the legend by default (see the *ParametersOptions* data item in the example below).

Example:

| Shape data field  | Value                                                                |
|-------------------|----------------------------------------------------------------------|
| Component         | Trending                                                             |
| Parameters        | *DmaID:ElementID:ParameterID*         |
| ParametersOptions | CollapseLegend:true                                                  |
| Filter            | Property:*PropertyName=PropertyValue* |

#### Visual Overview: Linking a shape to an alarm via the root alarm ID \[ID_24367\]

From now on, a shape can also be linked to an alarm via the root alarm ID.

To do so, add a shape data field of type “Alarm” to the shape, and set its value to DmaID/RootAlarmID. If the alarm cannot be found, the shape will not be displayed.

If you want a shape linked to an alarm to visualize the root alarm ID, you can add a shape data field of type “Info”, and set its value to “ROOT ALARM ID”.

Example:

| Shape data field | Value             |
|------------------|-------------------|
| Alarm            | DmaID/RootAlarmID |
| Info             | ROOT ALARM ID     |

> [!NOTE]
>
> - If a shape is linked to an alarm, you can now also use the Info keywords in the shape text (enclosed in square brackets). For example: “The value of the alarm is \[value\].”
> - Note that, when you link shapes to alarms, only active alarms can currently be shown.

#### Visual Overview: Filtering an alarm tab by clicking an AlarmSummary shape \[ID_24380\]

By linking a shape to an alarm filter using an *AlarmSummary* data item, you can show statistical information about the alarms that match the filter. From now on, it is also possible to have the alarms displayed in an alarm tab, filtered according to the filter specified in the shape.

To do so, add a data item of type *AlarmTab*, and set its value to “Name=”, followed by the name of an alarm tab. See the example below.

When you click the shape, Cube will open the specified alarm tab (if it has a filter applied) and apply the alarm filter specified in the *AlarmSummary* data item. If the alarm tab specified in the *AlarmTab* data item has no alarm filter applied or if no alarm tab exists with that name, one will first be created.

| Shape data field | Value                                                                |
|------------------|----------------------------------------------------------------------|
| AlarmSummary     | type\|sharedfiltername\|ApplyLinkedViewServiceOrElementFilter\|Alarm |
| AlarmTab         | Name=AlarmTabName                                                    |

#### Visual Overview: Adding a search box to a SetVar selection box control \[ID_24448\]

Using a *SetVar* data field, you can turn a shape or a page into a selection box control that allows users to update a session variable. From now on, it is possible to add a search box to such a selection box.

To do so, specify “Control=FilterComboBox” in a *SetVarOptions* data field. See the following example:

| Shape data field | Value                                             |
|------------------|---------------------------------------------------|
| SetVar           | \[Sep::;\]MySessionVariable;\[Param:25/1245,568\] |
| SetVarOptions    | Control=FilterComboBox                            |

> [!NOTE]
> HTML5 mobile apps do not support selection boxes with a search box. Selection boxes that have a search box configured will be displayed as regular selection boxes without search box.

#### Visual Overview: Using 'info keywords' in all data items of a shape linked to an alarm \[ID_24485\]

Up to now, there were two ways to have a shape linked to an alarm show information about that alarm:

- Add an *Info* data item and set its value to a particular alarm keyword, and type a “\*” character in the shape text. The “\*” character will then be replaced by the value of the keyword you specified in the *Info* data item.

- Enter one or more alarm keywords (wrapped in square brackets) in the shape text. Those will then be replaced by their corresponding value.

From now on, it is also possible to specify alarm keywords in shape data items other than *Info*.

Example:

| Shape data field | Value                        |
|------------------|------------------------------|
| Alarm            | 10/20/500                    |
| SetVar           | MyVariable:\[root alarm id\] |

> [!NOTE]
>
> - To prevent infinite loops, do not specify alarm keywords in a shape data item of type *Alarm*.
> - Currently, it is not yet possible to use these keywords inside other keywords.

#### Visual Overview: Displaying a Visio page when the shape is not linked to an element, a view or a service \[ID_24507\]

Up to now, it was only possible to display a page of a Visio file associated with an object linked to a shape. To have a page named “Details” of a Visio file associated with an element named “MyElement” displayed in a separate window, for example, you had to add two data items to a shape: one of type *Element* set to “MyElement”, and one of type *VdxPage* set to “Details\|Window”.

From now on, it is also possible to display a page from the current Visio file by only adding a single data item of type *VdxPage* to a shape, without any reference to an element, view or service. This will allow you to also display Visio pages when a shape is linked to e.g. an alarm. See the following example:

| Shape data field | Value           |
|------------------|-----------------|
| VdxPage          | Details\|Window |

> [!NOTE]
> If you do not specify a window type suffix (“Window”, “Popup” or “ToolTip”), the Visio page will be displayed inside the shape.

#### Visual Overview: New option to disable path highlighting when clicking a connection line \[ID_24544\]

Up to now, when you clicked a connection line between shapes, the path connected to that line was highlighted by default.

This default behavior can now be changed by adding a *SelectionHighlighting* option to the shape that represents the connection and setting it to “False”. See the following example.

| Shape data field | Value                       |
|------------------|-----------------------------|
| Connection       | Connectivity                |
| Options          | SelectionHighlighting=False |

#### Visual Overview: New FilterContext option for shape linked to alarm filter \[ID_24577\]

When a shape is linked to an alarm filter, you can now add an additional element, service or view filter to the *AlarmSummary* shape data, using a pipe symbol ("\|") as separator. The syntax of this filter is "*FilterContext=*" followed by the name or ID of the element, service or view.

If you have configured the shape to open an alarm tab in the Alarm Console when it is clicked, this filter will also be taken into account for the alarm tab. For example:

| Shape data field | Value                                                       |
|------------------|-------------------------------------------------------------|
| AlarmSummary     | active\|MyFilterName\|false\|Alarm\|FilterContext=MyService |
| AlarmTab         | Name=MyFilteredTab                                          |

#### Visual Overview: New Set option 'SetTrigger=Event' & additional IOClicked event arguments \[ID_24582\]

##### New Set option 'SetTrigger=Event'

Up to now, in a page-level shape data field of type *Execute*, you could specify the “SetTrigger=ValueChanged” option in a *Set* command to have parameters or session variables updated on an open Visual Overview page when a specific value changes.

From now on, it is also possible to have a *Set* command update parameters or session variables on an open Visual Overview page when an event occurs on that page. To do so, you have to specify the “SetTrigger=Event” option.

In the following example, every time the event is triggered from the router control, the set command will be executed with the label of the clicked matrix. Clicking the same input or output multiple times will each time cause the set command to be executed. Note that, if you would specify “SetTrigger=ValueChanged” instead of “SetTrigger=Event”, clicking the same input or output multiple times would cause the set command to be executed only once.

| Shape data field | Value                                                      |
|------------------|------------------------------------------------------------|
| Execute          | Set\|1/1\|350\|\[Event:IOClicked,Label\]\|SetTrigger=Event |

> [!NOTE]
> All *Set* commands with a “SetTrigger=Event” option will be triggered when an event occurs, even those that do not contain an \[Event:\] placeholder.

##### Additional IOClicked event arguments

The following additional arguments can now be specified when configuring the router control event “IOClicked” in an \[Event:\] placeholder:

| Argument | Description                                                       |
|----------|-------------------------------------------------------------------|
| Type     | “input” or “output”, depending on the type of the interface.      |
| Matrix   | The name of the matrix that contains the clicked input or output. |

#### Visual Overview: New MinChartHeight parameter option for trend component \[ID_24706\]

It is now possible to configure the minimum height of the chart area of a trend component. Previously, this was always set to 200 pixels. To make sure this height is reached, the legend of the trend component will become smaller when necessary, or it may even be hidden.

To configure the minimum height of a trend component, add the option *MinChartHeight* to the *ParametersOptions* shape data.

For example, with the configuration below, the minimum height of the chart area will be 400 pixels.

| Shape data field  | Value                               |
|-------------------|-------------------------------------|
| Component         | Trending                            |
| ParametersOptions | ShowLegend:true\|MinChartHeight=400 |
| Parameters        | 1/20:500:\*                         |

#### Visual Overview: Shapes linked to views can now have an 'AlarmLevel' shape data field \[ID_24952\]

To a shape linked to a view, you can now add a shape data field of type “AlarmLevel” to configure which of the view’s alarm levels you want the shape’s background color to display.

| Shape data field | Value                                                                                                                                                                                                                                                                                                                                                                                                                                           |
|------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| AlarmLevel       | Instance/BubbleUp/Summary<br> -  Instance: Alarm level of the monitored aggregation rules on the view.<br> -  BubbleUp: Highest alarm level of any child element or child view.<br> -  Summary: Highest of the Instance and BubbleUp alarm levels. |

#### Visual Overview - ListView: Enhanced filter capabilities \[ID_25114\]

##### View filters

When specifying view filters using the view name instead of the view ID, an alternative syntax can now be used: *ViewName=\<name>*

Also, you can now use the "==" operator instead of the "=" operator. If the *ViewName* syntax is used, DataMiner will first try to filter by name, and then by ID in case the name cannot be found. If the *View* syntax is used, DataMiner will first try to filter by ID ,and then by name if the ID cannot be found. The filter can contain only one *View* or *ViewName* part.

##### Element/service filters

From now on, if you set the *Source* shape data field to “Elements” or “Services”, additional possibilities are available to add an element or service filter in the *Filter* shape data field:

- The following operators are supported: “*==*” (equals), “*!=*” (does not equal), “*contains*”, “*notContains*”, “*startswith*”, “*notStartswith*”, “*endsWith*", “*notEndsWith*", "*\<*" (smaller than, only usable with numbers) and "*\>*" (greater than, only usable with numbers). The value that is being compared with should always be included in single quotes.

- The following terms can be used to filter on:

  | Filter term | Description |
  |-------------|-------------|
  | Element.ID | The ID of an element. |
  | Element.Name | The name of an element. |
  | Element.Description | The description of an element. |
  | Element.DataMiner | The name of the DMA on which an element is located. |
  | Element.AlarmLevel | The technical alarm level of the element. This is the non-localized, DataMiner-internal equivalent of the alarm state. For example, the alarm level "Undefined" is the same as the alarm state "Not monitored, the alarm level "Normal" is equivalent to the alarm state "Normaal" if the Dutch version of Cube is used. |
  | Element.AlarmState | The alarm state of the element. For the difference with the alarm level, see "Element.AlarmLevel". |
  | Element.AlarmCount | The number of alarms of the element. |
  | Element.Type | The type of element as defined in the protocol. |
  | Element.DisplayType | The display type of the element as defined in the protocol, e.g. *spectrum analyzer*, *element manager*. |
  | Element.IP | The IP of the element. |
  | Element.State | The current state of the element, e.g. Paused, Stopped. |
  | Element.Protocol | The protocol used by the element. |
  | Element.ProtocolVersion | The protocol version used by the element. |
  | Element.ProtocolType | The protocol type used by the element. |
  | Element.AlarmTemplate | The alarm template used by the element. |
  | Element.TrendTemplate | The trend template used by the element. |
  | Element.Property.*PropertyName* | The property of the element with the specified property name. |
  | Service.ID | The ID of a service. |
  | Service.Name | The name of a service. |
  | Service.Description | The description of a service. |
  | Service.DataMiner | The name of the DMA on which a service is located. |
  | Service.AlarmLevel | The technical alarm level of the service. This is the non-localized, DataMiner-internal equivalent of the alarm state. For example, the alarm level "Undefined" is the same as the alarm state "Not monitored, the alarm level "Normal" is equivalent to the alarm state "Normaal" if the Dutch version of Cube is used. |
  | Service.AlarmState | The alarm state of the service. For the difference with the alarm level, see "Service.AlarmLevel". |
  | Service.AlarmCount | The number of alarms of the service. |
  | Service.Property.*PropertyName* | The property of the service with the specified property name. |

- You can combine different search terms with each other and with one view filter, using pipe characters ("\|"). The pipe character is used as an AND operator.

- Session variables can also be used in these filters.

- Examples:

  - To filter on all elements of which the name contains the word "function" and the element property IDP is set to "Source":

    ```txt
    Element.Name contains 'function'|Element.Property.IDP == 'Source'
    ```

  - To filter on all services of which the name contains the word "\_booking" and that are hosted by the DataMiner Agent "MyDMA":

    ```txt
    Service.DataMiner == 'MyDMA'|Service.Name contains '_booking'
    ```

  - To filter on all elements using the protocol "MyProtocol" with the protocol type "serial" which are not of element type "Relay":

    ```txt
    Element.Protocol == 'MyProtocol'|Element.ProtocolType == 'serial'|Element.Type notContains 'Relay'
    ```

  - To filter on all element using the property IDP with a property value equal to that of the session variable "MySelectedValue":

    ```txt
    Element.Property.IDP == [var:MySelectedValue]
    ```

> [!NOTE]
> The filters are not case-sensitive. For example, a service with the name "MyName" will be found when the filter *Service.Name == 'myname'* is used

#### Visual Overview: SetVar controls 'ListBox' and 'FilterComboBox' now use virtualization \[ID_25436\]

The SetVar controls “ListBox” and “FilterComboBox” now both use virtualization. This will allow those controls to load large data sets without major performance loss.

#### Visual Overview: Retrieving a booking ID using the \[Reservation:\] placeholder \[ID_25447\]

Using the following syntax, it is now possible to retrieve the ID of a booking by means of a \[Reservation:\] placeholder.

```txt
[reservation:<bookingID/service>,ID]
```

#### Service & Resource Management - Visual Overview: Dynamically generating booking shapes \[ID_26154\]

It is now possible to automatically generate booking shapes. To implement this feature, do the following:

1. Create a shape representing the booking items, add a *ChildType* data field to that shape, and set its value to “Booking”.

2. Create a shape group containing the shape you made in step 1, add a *Children* data field to the shape group, and set its value to “Booking”.

By default, all bookings in the Cube cache will be shown. If that cache does not contain any bookings, then a default set of bookings will be retrieved (i.e. from 1 day in the past to 2 days in the future).

- If you want to retrieve all bookings within a specific time range from the server, then add a *ChildrenSource* data field to the shape group and set its value to a specific time range (e.g. “StartTime=\<dateTime>; EndTime=\<dateTime>”).

    > [!NOTE]
    > If you retrieve a specific set of bookings by using a *ChildrenSource* data field set to a specific time range, the retrieved bookings will be added to the ones already present in the cache. If, by specifying a time range, you only want to filter the bookings currently in the cache, then use a *ChildrenFilter* data field instead.

- If you want to filter the bookings, then add a *ChildrenFilter* data field to the shape group and set its value to a booking filter, using the same filter format that is used when specifying a ListView filter.

- If you want to sort the bookings, then add a *ChildrenSort* data field to the shape group and set its value to “Name” (i.e. the default setting), “Property\|Start time” or “Property\|End time”, optionally followed by “,asc” (i.e. the default order) or “,desc”.

> [!NOTE]
> Dynamically generated booking shapes are functionally identical to shapes linked to bookings using a *Reservation* data field. For example, they support the same placeholders.

#### Visual Overview: New parameter control option 'ClientSidePollingInterval' \[ID_26223\]

When you have turned a shape into a table control that displays a direct view table, you can now use the *ClientSidePollingInterval* option to specify that this table should be refreshed at regular intervals.

| Shape data field        | Value                                                                                                                                       |
|-------------------------|---------------------------------------------------------------------------------------------------------------------------------------------|
| ParameterControlOptions | ClientSidePollingInterval:\<interval><br> Example: To configure a polling interval of 1 minute, specify ClientSidePollingInterval:00:01:00. |

Minimum interval: 1 second

#### Visual Overview: Element-level Visio files \[ID_26648\]\[ID_27376\]

Up to now, when you assigned a Visio file to an element, it was assigned on protocol-level, i.e. to all elements sharing the same protocol. Now, it is also possible to assign a Visio file to one particular element. If you do so, the element-level Visio file will override the element’s protocol-level Visio file.

In the header bar menu of an element card, you will now have two “set as active Visio file” commands:

- Set as active *‘protocol name’* protocol Visio file

- Set as active *‘element name’* element Visio file

If you pick the protocol Visio file option, the following options are available:

| Option | Function |
|--|--|
| Custom | Assigns the available custom protocol drawing to all elements using this protocol. |
| Protocol default | Assigns the protocol default drawing to all elements using this protocol. Protocol default drawings are Visio drawings that are included in certain protocol packages. |
| General default | Assigns the general default drawing to all elements using this protocol. This is the drawing shipped with the DataMiner software. |

If you pick the element Visio file option, the following options are available:

| Option | Function |
|--|--|
| New blank | Opens a new, blank drawing in Microsoft Visio, which will automatically be assigned to the current element. |
| New upload | Opens the *Open* dialog box, which allows you to upload a new drawing to the DMS and automatically assign it to the current element. |
| Existing | Opens the *Custom* dialog box, which allows you to assign a previously uploaded drawing to the current element:<br> - Click a drawing in the list, set the default page, and click *OK*.<br> - Click *Other File...* to upload additional drawings to the DMS. |

#### Visual Overview / Service & Resource Management: Reservation placeholder now supports Status field \[ID_26859\]

Using the syntax “\[Reservation:\<id>,\<fieldName>\]”, it is possible to resolve a booking field based on the ID and the name of that field.

The Status field has now been added to the list of possible fields. This field indicates the current status of the booking (e.g. “Ended”, “Pending”, “Ongoing”, etc.).

#### Visual Overview: New AllowInheritance option to keep child shape from automatically inheriting parent shape data \[ID_27084\]

It is now possible to configure a child shape of a *View* or *Element* shape to not automatically inherit the *View* or *Element* shape data of the parent shape. To do so, add the option *AllowInheritance=False*. Note that this renders the existing option *NoCopyElementProperty* obsolete, since this did the same thing for *Element* shapes only.

#### Visual Overview: Conditional shape manipulation actions no longer require the shape to be linked to an element, service or view \[ID_27569\]

Up to now, the following conditional shape manipulation actions could only be configured on shapes linked to an element, service or view. From now on, these actions will no longer require the shape to be linked to an element, service or view.

- Show
- Hide
- FlipX
- FlipY
- Enabled

> [!NOTE]
> In case of “Enabled”, the shape in question needs to be clickable.

#### Visual Overview: New icons added to DataMiner stencils \[ID_27571\]

##### New icons

The following additional icons are now available in the DataMiner stencils:

- General input
- General output
- OT
- OR
- Multiplexer
- Demultiplexer
- Modulator
- Demodulator
- North-south deployment
- Augmented
- East-west LSO
- Virtual machine
- MPLS
- Bespoke
- DNS
- Platform services
- OS
- AWS Direct Connect
- Kubernetes
- Elastic
- Paas
- Iaas
- Saas
- Infrastructure
- Applications.2
- Single source of truth
- Consistency
- Dynamics
- File management
- Synchronized
- Easy access
- End-to-End View
- User-definable
- Intuitive UI
- Full support
- Single sign-on
- Advanced access control
- Simplify Processes
- Sophisticated services
- Level up your service quality
- Graphical user interface
- Access information
- Plug ’n play creation
- Inspect
- OTT
- Encoder
- Close Caption Encoder

##### Renamed icons

In the DataMiner stencils, the following existing icons have been renamed:

| Old name            | New name          |
|---------------------|-------------------|
| no Acces            | No Access.2       |
| dmcube_cubemobile   | DM Cube Mobile    |
| IP alt              | IP.2              |
| Rotate 2            | Rotate            |
| Rotate alt          | Rotate.2          |
| service manager.262 | Service Manager.2 |
| SLA alt             | SLA.2             |
| th                  | Apps              |
| Virtual-Machine     | Virtual Machine   |

##### Capital Case

All icon names are now in capital case.

#### Visual Overview: Linking the view range of a trend graph component to session variables & specifying a custom view range \[ID_27779\]

A Visio shape showing a trend graph component can now be made to update session variables with its view range (i.e. start time and end time). To do so, add a shape data field of type SetVar, and set its value to “RangeStart:\<VariableA>\|RangeEnd:\<VariableB>”

Example:

| Shape data field | Value                                        |
|------------------|----------------------------------------------|
| SetVar           | RangeStart:MyRangeVar1\|RangeEnd:MyRangeVar1 |

> [!NOTE]
> The values set in the session variables will be datetime text strings formatted according to the current culture.

Also, to have a trend graph component show a custom range, you can now add “Range:Start=\<dateTimeTextA>,End=\<dateTimeTextB>” to a shape data field of type ParametersOptions.

Example:

| Shape data field  | Value                                             |
|-------------------|---------------------------------------------------|
| ParametersOptions | Range:Start=\<dateTimeTextA>,End=\<dateTimeTextB> |

> [!NOTE]
>
> - You do not have to specify two time values. You can specify a start time, an end time or both (separated by a comma).
> - The datetime text strings need to be formatted according to the current or invariant culture.

#### Visual Overview: Info keywords can now be used as dynamic placeholders in other shape data fields \[ID_27880\]

All keywords that can be specified in shape data fields of type “Info” can now also be used as dynamic placeholders in shape data fields of other types.

When using one of those keywords in a shape data field of type other that “Info”, make sure to enclose it in square brackets similar to other placeholders.

Example: \[var:\[NAME\]\]

#### Visual Overview: Automation script session variables & OnClosing shape data field \[ID_27895\]

In Visual Overview, it is now possible to pass Automation script output to session variables. Also, you can now use the page-level shape data field OnClosing to configure whether a Visual Overview window should automatically be closed or not.

##### Passing Automation script output to session variables

When an Automation script executed in Visual Overview finishes successfully, it is now possible to pass the output values of that script to session variables in Visual Overview using the new CreateKey(string variablename) method (namespace: Skyline.DataMiner.Automation, class name: UIVariables.VisualOverview).

In the following example, a session variable named “MyOutput” will be created and will receive the value “MyValue”.

```txt
engine.AddScriptOutput(UIVariables.VisualOverview.CreateKey("MyOutput"), "MyValue");
```

- If you execute the same Automation script on different pages, then you can use the SessionVariablePrefix option to make sure the output is saved in separate session variables.

    If, for example, you use prefix “One\_” on one page and prefix “Two\_” on another page, and the Automation scripts pass their output to a session variable named “MyPage”, then the output will end up in two separate session variables named “One_MyPage” and “Two_MyPage” respectively.

- When you set the SetVarOnFail option to true (either on page level or shape level), then the session variables in question will always be created, regardless of whether the script finishes successfully or not.

##### New 'OnClosing' shape data field

From now on, you can use the page-level shape data field OnClosing to configure whether a Visual Overview window should automatically be closed or not.

In a shape data field of type OnClosing, specify a script (example: Script:MyScript), and make sure the script contains an instruction like the following one:

```csharp
engine.AddScriptOutput(UIVariables.VisualOverview.ClosingWindow_Result, ClosingMode.Continue.ToString());
```

The session variable named ClosingWindow_Result can be set to “Continue”, “Stop” or “Abort”. In the example above, it is set to “Continue”.

If ClosingWindow_Result is set to “Stop”, a message box of type “Yes/No” will appear. If the user then clicks “Yes”, the window will be closed.

Note that, in the session variable named ClosingWindow_Message, you can specify a custom message to be displayed. If you specify such a message, then it will be shown in a message box of type “OK”, regardless of the value of the ClosingWindow_Result variable. However, if ClosingWindow_Result is set to “Stop”, then this custom message will be displayed in the message box of type “Yes/No” mentioned above.

> [!NOTE]
>
> - The OnClosing shape data field only works for windows. It does not work for popups or tooltips.
> - The OnClosing and OnClose shape data fields do not influence each other. Both function independently from each other.
> - If you want to combine OnClosing and OnClose, then in Visual Overview, you can pass session variable X to the OnClosing script and make it return session variable Y. That variable can then be passed to the OnClose script, which can optionally be made to return session variable Z.

#### Visual Overview: New AutoIgnoreExternalChanges option when embedding a Service Manager component \[ID_27899\]

Up to now, when embedding a Service Manager component in Visual Overview, you could specify the AutoLoadExternalChanges option if you wanted external changes to be loaded automatically when there were no local changes. From now on, you can also specify the AutoIgnoreExternalChanges option if you want external changes to be discarded automatically.

Both options will keep the information bar from being displayed at the bottom of the Visual Overview, asking the user to load or discard the external changes.

> [!NOTE]
> If you specify both options, then AutoLoadExternalChanges will take precedence over AutoIgnoreExternalChanges:
>
> - As long as there are no (unsaved) client-side changes, external changes will be loaded automatically.
> - As soon as there are (unsaved) client-side changes, external changes will be discarded.

#### Visual Overview: KPI stencil and Button stencil have been restyled \[ID_28691\]

The KPI stencil and the Button stencil have been restyled.

##### KPI stencil

- Apart from being restyled, the following shapes have also been renamed:

    | Old name           | New name           |
    |----------------------|--------------------|
    | kpi-noIcon-v         | kpi-noIconV        |
    | kpi-noIcon-h         | kpi-noIconH        |
    | param-normal         | list-normal        |
    | param-normal-compact | list-compact       |
    | param-combi-compact  | list-combi-compact |
    | param-multi          | list-multi         |
    | param-combi          | list-combi-compact |

- A KPI and its associated icon can now be displayed in two different ways:

    | Shape   | Description                                                    |
    |-----------|----------------------------------------------------------------|
    | kpi-icon  | Focus on the parameter alarm state, with an icon on top of it. |
    | kpi-icon2 | Fixed background (dark blue), with an icon on top of it.       |

    > [!NOTE]
    > Make sure to replace the icon by one that suits the requirements.
    >
    > All available icons can be found in the Icons stencil.

- The master shapes of which the name starts with “kpi-” can now show the element icon with the alarm state (\_showElement) and an icon that can be clicked to navigate to the alarm overview of the linked element (\_showAlarm).

- The write icon in the top-right corner of a shape has been changed from a black triangle to a cogwheel.

##### Button stencil

- The style of the toggle buttons now matches the style of the toggle button in DataMiner Cube.

- All other buttons have had their rounding style adapted in order to match that of the buttons found on the Data pages of element cards.

    > [!NOTE]
    > It is advised to add an ellipsis (...) to the text on a button if user interaction is required after clicking the button in question.

> [!NOTE]
> The toggle buttons now use the theme accent color. This means that you will need an additional Options shape data field on page level with, for example, the following value:
>
> *#000000=ThemeForeground\|#FF0000=ThemeAccentColor\|#FFFFFF=ThemeBackground*

#### Visual Overview: New icon added to Icons stencils \[ID_28696\]

The following icon has been added to the Icons stencil:

- Alarms
