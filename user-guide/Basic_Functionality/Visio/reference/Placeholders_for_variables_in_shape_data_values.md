---
uid: Placeholders_for_variables_in_shape_data_values
---

# Placeholders for variables in shape data values

> [!TIP]
> For examples, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *Placeholders* page.

## Info keywords

A number of keywords can be used in **Info** shape data fields to display information about a shape. These keywords, wrapped in square brackets, can also be used as placeholders in the value of shape data fields. For example:

| Shape data field | Value                        |
|------------------|------------------------------|
| Alarm            | 10/20/500                    |
| SetVar           | MyVariable:\[root alarm id\] |

From DataMiner 10.0.13 onwards, **Info** keywords (wrapped in square brackets) can also be used as placeholders within other placeholders. For example: *\[var:\[NAME\]\]*

For an overview of the different keywords, see [Making a shape display information about the item it is linked to](xref:Making_a_shape_display_information_about_the_item_it_is_linked_to).

> [!NOTE]
>
> - To prevent infinite loops, do not use alarm keywords in shape data items of type **Alarm**.
> - These keywords cannot be used inside other placeholders.

## Other placeholders

> [!NOTE]
>
> - Placeholders are case-insensitive. In other words, you can use “\[this service\]”, “\[This Service\]”, etc.
> - In the “\[param: ...\]” placeholders mentioned below, ParameterID can be replaced by another “\[param: ...\]” placeholder. In other words, parameter references can be nested. Using other placeholders within placeholders is supported from DataMiner 9.5.8 onwards. However, when you do so, be careful not to create loops.
> - Using placeholders directly in the text of a shape is supported from DataMiner 9.5.8 onwards.
> - Many of the advanced features described below apply to DataMiner Cube only.

### \[AggregationRule:...\]

The placeholder \[AggregationRule: *folder/rule, view ID, protocol, element property, view property, remote primary key*\] can be used to link a shape to an aggregation rule, in order to display aggregated parameter values. See [Linking a shape to an aggregation rule](xref:Linking_a_shape_to_an_aggregation_rule).

It can also be used with:

- Shapes linked to a trend component, pie chart, bar chart, column chart, or stacked area chart, where it can be used in the **Parameters** shape data field instead of a parameter.

    > [!TIP]
    > See also:
    >
    > - [Linking a shape to a trend component](xref:Linking_a_shape_to_a_trend_component)
    > - [Creating a parameter chart](xref:Creating_a_parameter_chart)

- Shapes linked to a parameter summary, where it can be entered instead of a parameter in the **ParametersSummary** shape data field.

    > [!TIP]
    > See also: [Linking a shape to a calculation involving multiple parameters](xref:Linking_a_shape_to_a_calculation_involving_multiple_parameters)

The placeholder takes the following arguments:

- **Folder/rule**: The location of the rule in the aggregation directory. The root directory does not need to be specified.

- **View ID**: The ID of the view on which the aggregation rule is calculated.

- **Protocol**: The protocol by which the aggregation rule is grouped.

  > [!NOTE]
  > Grouping is only possible by base protocols.

- **Element property**: The element property by which the aggregation rule is grouped.

- **View property**: The view property by which the aggregation rule is grouped.

- **Remote primary key**: The remote primary key of the table row on which the aggregation rule is calculated (string or numeric value).

  > [!NOTE]
  > In case a discrete parameter is used for the remote primary key, do not use the display value.

> [!NOTE]
>
> - Not all the values need to be filled in. If the view ID or the remote primary key are not filled in, these will automatically be replaced by -1. In the most extreme case, it is possible to configure the placeholder with only the aggregation rule name, if it is a rule in the root folder.
> - Grouping can be defined either by element property or by view property. Within the same aggregation rule, it is not possible to group by both properties.
> - Using other placeholders within this placeholder is only supported from DataMiner 9.5.0 onwards.

Example:

```txt
[AggregationRule:Server farm/Avg Load,-1,,,1]
```

### \[attachedproperty:...\]

Unlike the \[property:...\] placeholder, which fetches a property of the object linked to the shape, the \[attachedproperty:...\] placeholder fetches a property of the object linked to the Visio drawing. This placeholder is mostly of use in Visio drawings that position shapes dynamically based on coordinates.

Properties used inside an \[attachedproperty:...\] placeholder can contain multiple ID:Value pairs (one for every shape that needs to be positioned) separated by pipe characters.

- ID: The ID of the object (Use DmaID/ID for elements and services, and use ViewID for views).

- Value: The actual value of the property.

Example:

Suppose you have a Visio drawing in which the shapes have to be positioned dynamically based on X and Y coordinates stored in properties, and that you want that drawing to be linked to both ServiceA and ServiceB. Using the \[attachedproperty:...\] placeholder, you can refer to data stored in properties of either of those two services.

If ServiceA has the following two properties:

- longitude: 1/2:0\|1/3:1

- latitude: 1/2:1\|1/3:1

... and if ServiceB has the following two properties:

- longitude: 1/2:1\|1/3:0

- latitude: 1/2:1\|1/3:1

... and if in the Visio drawing you set the **XPos** and **YPos** shape data fields to the following values:

- XPos: \[attachedproperty:longitude\]

- YPos: \[attachedproperty:latitude\]

... then:

- In the drawing linked to ServiceA, two shapes will be positioned:

  - One shape linked to object 1/2 at longitude 0 and latitude 1.

  - One shape linked to object 1/3 at longitude 1 and latitude 1.

- In the drawing linked to ServiceB, two shapes will be positioned:

  - One shape linked to object 1/2 at longitude 1 and latitude 1.

  - One shape linked to object 1/3 at longitude 0 and latitude 1.

### \[Avg:X,Y,Z\]

Available from DataMiner 9.5.8 onwards.

Average of a list of entries, e.g. X, Y, Z (which will be parsed to numbers).

### \[cardvar:VariableName\]

Reference to a session variable (scope: current DataMiner Cube card).

As parameters of which the value is an empty string are considered initialized, you can use a \[var:...\] placeholders to refer to a parameter containing an empty string.

### [color:severity=...]

Available from DataMiner 10.1.11/10.2.0 onwards.

The alarm color for a specific severity level.

For example: `[color:severity=minor]`

> [!TIP]
> See also: [Setting the background color of a static shape](xref:Setting_the_background_color_of_a_static_shape)

### \[ConnectionLineDisplayIdx\]

Display key of the connection that was clicked.

> [!TIP]
> See also: [Navigation options for automatically drawn connections](xref:Positioning_shapes_dynamically1#navigation-options-for-automatically-drawn-connections)

### \[ConnectionLineIdx\]

Primary key of the connection that was clicked.

> [!TIP]
> See also:
> [Navigation options for automatically drawn connections](xref:Positioning_shapes_dynamically1#navigation-options-for-automatically-drawn-connections)

### \[ConnectionlineFromKey\]

Starting point of the connection that was clicked.

> [!TIP]
> See also: [Navigation options for automatically drawn connections](xref:Positioning_shapes_dynamically1#navigation-options-for-automatically-drawn-connections)

### \[ConnectionLineToKey\]

End point of the connection that was clicked.

> [!TIP]
> See also: [Navigation options for automatically drawn connections](xref:Positioning_shapes_dynamically1#navigation-options-for-automatically-drawn-connections)

### \[DataMinerTime\]

Available from DataMiner 9.6.7 onwards.

The current DataMiner time, refreshed every second.

By default, the regional date/time format will be used. To use a different format, specify the format in the placeholder. For example:

| Format | Description |
|--|--|
| `[DataMinerTime:Format=HH:mm:ss]` | Custom format. |
| `[DataMinerTime:Format=f]` | Full date/time pattern (short time). |
| `[DataMinerTime:Format=g]` | General date/time pattern (short time). |
| `[DataMinerTime:Format=F]` | Full date/time pattern (long time). |
| `[DataMinerTime:Format=G]` | General date/time pattern (long time). |

> [!NOTE]
> For more information on possible formats, refer to <https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings>.

### \[DestinationInterfaceElementID\]

Available from DataMiner 9.5.3 onwards.

The DMA ID and element ID of the destination interface of the connection that was clicked.

> [!TIP]
> See also: [Navigation options for automatically drawn connections](xref:Positioning_shapes_dynamically1#navigation-options-for-automatically-drawn-connections)

### \[DestinationInterfaceElementName\]

Available from DataMiner 9.5.3 onwards.

The element name of the destination interface of the connection that was clicked.

> [!TIP]
> See also: [Navigation options for automatically drawn connections](xref:Positioning_shapes_dynamically1#navigation-options-for-automatically-drawn-connections)

### \[DestinationInterfaceIdx\]

Available from DataMiner 9.5.3 onwards.

The interface ID of the destination interface of the connection that was clicked.

> [!TIP]
> See also: [Navigation options for automatically drawn connections](xref:Positioning_shapes_dynamically1#navigation-options-for-automatically-drawn-connections)

### \[DestinationInterfaceLinkedIdx\]

Available from DataMiner 9.5.3 onwards.

The primary key of the table row to which the destination interface of the connection that was clicked is linked.

> [!TIP]
> See also: [Navigation options for automatically drawn connections](xref:Positioning_shapes_dynamically1#navigation-options-for-automatically-drawn-connections)

### \[DestinationInterfaceName\]

Available from DataMiner 9.5.3 onwards.

The interface name of the destination interface of the connection that was clicked.

> [!TIP]
> See also: [Navigation options for automatically drawn connections](xref:Positioning_shapes_dynamically1#navigation-options-for-automatically-drawn-connections)

### \[displaytableindex\]

When, inside a Microsoft Visio drawing, you specify placeholders like \[param: ...\] and \[property: ...\] in child shape data items of type “Row”, you can use \[displaytableindex\] inside those placeholders. This placeholder will then dynamically be replaced by the row’s display index.

> [!TIP]
> See also: [\[tableindex\]](#tableindex)

### \<DMAIP>

This placeholder can only be used inside another placeholder, or in a URL for a shape data field of type **Link**. It is replaced with the first configured value from the following list that can be found for the DMA you are connecting to:

- The certificate address

- The hostname

- The primary IP address

> [!NOTE]
> From DataMiner 10.2.0/10.2.3 onwards, the URI scheme of the DMA (i.e. HTTP or HTTPS) is automatically applied when this placeholder is resolved, unless the placeholder does not represent the URI host (e.g. when it is used as a query argument).

> [!TIP]
> See also: [Special placeholders that can be used inside a URL](xref:Linking_a_shape_to_a_webpage#special-placeholders-that-can-be-used-within-a-url)

### \[Element:\<input>,\<output>\]

Available from DataMiner 10.1.12/10.2.0 onwards.

This placeholder can be used to refer to the name or the ID of an element.

- *\<input>* should be either an element name or an element ID (in the format DMA ID/element ID).

- *\<output>* can be either *Name* or *ID*.

For example: *\[Element:231/15,Name\]*

### \[EscapeDataString:x\]

Use this placeholder to insert a URL-encoded string into the value of a shape data field.

If, for example, you enter “\[EscapeDataString:String to be encoded+?\]” in a shape data field, this will be resolved to “String%20to%20be%20encoded%2B%3F%20”.

Note that the string to be encoded can itself contain dynamic placeholders.

### \[Event:...\]

Available from DataMiner 9.6.13 onwards. This placeholder can be used to trigger an action when a particular event occurs. It should be defined as follows: *\[Event:**\<EventName>**,**\<ArgumentName>**\]*

During the event, the \[Event:...\] placeholder will be replaced by the value of the argument specified in the placeholder.

- Prior to DataMiner 10.2.0/10.1.1, only one Router Control event is supported:

  - EventName: *IOClicked*

  - Possible arguments:

    - **Label**: The label of the input or output that was clicked.

    - **Index**: The index of the input or output that was clicked.

    - **DCF interface ID**: The ID of the DCF interface that is linked to the input or output that was clicked.

    - **DCF interface name**: The name of the DCF interface that is linked to the input or output that was clicked.

    - **Type**: Available from DataMiner 10.0.3 onwards. Can be "input" or "output", depending on the type of interface.

    - **Matrix**: Available from DataMiner 10.0.3 onwards. The name of the matrix that contains the clicked input or output.

  - Example: *\[Event:IOClicked,Label\]*

- From DataMiner 10.2.0/10.1.1 onwards, this placeholder can also be used with the **NodeDoubleClicked** tag. In this case, the event will be triggered when a node is double-clicked in an embedded service definition (see [Embedding a Service Manager component](xref:Embedding_a_Service_Manager_component)). The event placeholder will then be replaced with the value of its argument.

  - Possible arguments:

    - **ID**: The ID of the service definition node.

    - **Label**: The label of the service definition node.

  - Example: *\[event:NodeDoubleClicked,ID\]*

> [!NOTE]
>
> - If you specify multiple \[Event:...\] placeholders in a shape data field, only one action will be triggered when that event occurs.
> - It is advised not to insert \[Event:...\] placeholders in other dynamic parts or placeholders.

### \[Field\]

Reference to the current field selection (only for EPM environments).

From DataMiner 9.5.1 onwards, this placeholder can also be used inside other placeholders.

### \[FieldID\]

Available from DataMiner 9.5.1 onwards.

Reference to the ID of the currently selected field (only for EPM environments).

This placeholder can also be used inside other placeholders. For example, if you specify *\[param:1/1,101:\[fieldID\]\]*, this will be replaced by parameter 101, with the ID of the selected field as the row index.

### \[firstmac\]

The first MAC address in the list of active MAC addresses on the client machine.

### \[Guid\]

The GUID. This can for example be used to initialize a session variable with a particular GUID. See [Initializing a session variable with a GUID](xref:Initializing_a_session_variable#initializing-a-session-variable-with-a-guid).

### \[Interlace:\<array1>,\<array2>,\<oldSep>,\<newSep>\]

Available from DataMiner 9.5.8 onwards. Splits the specified arrays delimited with \<oldSep>, and interlaces them using \<newSep> as separator.

For example, if you specify “*\[Interlace:X\|Y\|Z,1\|2\|3,A\|B\|C,\|,;\]*” in the shape data, this will be resolved to “X;1;A;Y;2;B;Z;3;C”.

### \[LocalTime\]

Available from DataMiner 9.6.9 onwards. Reference to the current DataMiner time in the time zone of the connected client machine.

By default, this time will be displayed in the regional date/time format. If you want the time to be displayed in a different format, specify the format inside the placeholder. For example:

```txt
[LocalTime:Format=HH:mm:ss]
```

> [!NOTE]
> The time shown by this dynamic placeholder is refreshed every second.

### \[Max:X,Y,Z\]

Available from DataMiner 9.5.8 onwards.

Maximum of a list of entries, e.g. X, Y, Z (which will be parsed to numbers).

### \[Min:X,Y,Z\]

Available from DataMiner 9.5.8 onwards.

Minimum of a list of entries, e.g. X, Y, Z (which will be parsed to numbers).

### \[pagevar:VariableName\]

Reference to a session variable (scope: current Visio page).

As parameters of which the value is an empty string are considered initialized, you can use a \[var:...\] placeholders to refer to a parameter containing an empty string.

### \[param:DmaID/ElementID,ParameterID\]

Reference to a parameter belonging to a specific element.

The element can be specified either by its name or by its ID (DmaID/ElementID). If specified in a Visio file to be linked to a protocol, ElementID can be replaced by a “\*” wildcard.

> [!NOTE]
>
> - As parameters of which the value is an empty string are considered initialized, you can use a \[param:...\] placeholders to refer to a parameter containing an empty string.
> - Inside a \[param:...\] placeholder, you can use \[var:...\] placeholders to refer to session variables. Example: \[param:\[var:Element\],101\]

From DataMiner 9.6.7 onwards, you can use this placeholder to refer to a column parameter. In that case, all the values of that column parameter will be retrieved, with a pipe character (“\|”) as separator.

For example, if the value below is used to configure a tooltip, all values of column parameter 110 are retrieved and displayed as “One\|Two\|Three”

| Shape data field | Value                                                |
|------------------|------------------------------------------------------|
| Tooltip          | Summary of parameter 110 is: \[Param:MyElement,110\] |

If you want a custom separator instead of the default separator (“\|”), specify the custom separator in a shape data item of type **Options**. For example:

| Shape data field | Value              |
|------------------|--------------------|
| Options          | MultipleValueSep=; |

### \[param:DmaID/ElementID,ParameterID,TableRow\]

Reference to a dynamic table parameter belonging to a specific element.

The element can be specified either by its name or by its ID (DmaID/ElementID). If specified in a Visio file to be linked to a protocol, ElementID can be replaced by a “\*” wildcard.

TableRow - which can refer to either the primary key or the display key - can be a simple ID or name, but it can also be a string containing wildcards (“\*” or “?”) and/or placeholders like \[param:...\] or \[property:...\].

> [!NOTE]
>
> - As parameters of which the value is an empty string are considered initialized, you can use a \[param:...\] placeholders to refer to a parameter containing an empty string.
> - Inside a \[param:...\] placeholder, you can use \[var:...\] placeholders to refer to session variables. Example: \[param:\[var:Element\],101,5\]
> - If you use this placeholder in the **Parameter** shape data field when linking a shape to a parameter, and the cell the placeholder refers to contains a parameter ID, instead of the cell value, the value of the parameter corresponding to that ID is displayed.

### \[ParentTableIndex\]

This placeholder can be used when hierarchical shapes are created dynamically based on rows in a table. The placeholder will be replaced by the index of the table row associated with the immediate parent shape.

> [!NOTE]
> When you use this placeholder, you should always specify the “AllowCustomIndex” option. Otherwise, Visual Overview will replace the index of the shape with the index of the table row associated with the immediate parent shape. See [Making a shape use a different index than that of the original row](xref:Generating_shapes_based_on_table_rows#making-a-shape-use-a-different-index-than-that-of-the-original-row).
>
> \[ParentTableIndex\] should only be used when the index has to be retrieved from a nested row-based child shape.

### \[ParentDisplayTableIndex\]

This placeholder can be used when hierarchical shapes are created dynamically based on rows in a table. The placeholder will be replaced by the display index of the table row associated with the immediate parent shape.

> [!NOTE]
> When you use this placeholder, you should always specify the “AllowCustomIndex” option. Otherwise, Visual Overview will replace the display index of the shape with the display index of the table row associated with the immediate parent shape. See [Making a shape use a different index than that of the original row](xref:Generating_shapes_based_on_table_rows#making-a-shape-use-a-different-index-than-that-of-the-original-row).
>
> \[ParentDisplayTableIndex\] should only be used when the index has to be retrieved from a nested row-based child shape.

### \[Profile:...\]

Reference to specific profile instances. See [Creating a list of profile instances](xref:Adding_options_to_a_session_variable_control#creating-a-list-of-profile-instances).

### \[property:PropertyName\]

Reference to a custom DataMiner property.

- \[property:...\] placeholders in shape data fields of type **Xpos**, **YPos**, **VdxPage** and **Link** refer to properties of the object to which the shape is linked.

- \[property:...\] placeholders in other shape data fields refer to properties of the object to which the Visio file is linked.

If you want to override the above-mentioned general rule, you can add to the shape a data field of type **Options** and set its value to either “ForcePropertyFromShape” or “ForcePropertyFromPage”.

> [!TIP]
> See also: [Adding options to shapes linked to elements or services](xref:Adding_options_to_shapes_linked_to_elements_or_services)

> [!NOTE]
> If the specified property refers to a non-existing element, service or redundancy group, then the shape will not be displayed.

### \[RegexReplace:x,y,z\]

Use this placeholder to have a value placed in a text string based on the result of a regular expression.

In this placeholder, specify three items, separated by commas:

| Item | Description                                       |
|------|---------------------------------------------------|
| x    | The regular expression.                           |
| y    | The input (e.g. a session variable).              |
| z    | The string that will replace each of the matches. |

> [!NOTE]
>
> - \[RegexReplace:x,y,z\] placeholders can be nested.
> - If any of the three input items contains a comma, the separator needs to be replaced (see [About using separator characters](xref:Linking_a_shape_to_a_SET_command#about-using-separator-characters)):
>
>   ```txt
>   [RegexReplace:[Sep:,#]x#y#z]
>   ```

Examples:

- In case the *sessionvar* variable contains the value “*alpha\|beta\|gamma\|delta*”, you can place the following placeholder in the value of a shape data field:

  ```txt
  [RegexReplace:(?<token>[^|]+)((?<separator>[|])|$),[var:sessionvar],value=1005 == ${token};]
  ```

  The placeholder will then be replaced by the following string of text:

  ```txt
  value=1005 == alpha;value=1005 == beta;value=1005 == gamma; value=1005 == delta;
  ```

- You can use this placeholder to remove the unit suffix of a parameter, so that it can be used within the [Sum](#sumxyz) placeholder. This is necessary if the sum uses a [param](#paramdmaidelementidparameterid) placeholder and the value of the parameter includes a unit, to make sure that value can be parsed into an integer. For example, to remove the unit "Frames" and calculate the sum of the parameter with ID 5 and a fixed value of 17, you can use this placeholder:

  ```txt
  [sum:[RegexReplace:\sFrames$,[param:*,5],],17]
  ```

### \[Reservation:...\]

From DataMiner 9.6.7 onwards, this placeholder can be used to retrieve a property of a booking, which can be a profile instance GUID, a resource GUID or a custom property.

For this purpose, the following basic syntax is used:

```txt
[reservation:<GUID or service>,<property>|<argA>|<argB>]
```

- This syntax consists of the following components:

  - The GUID of the booking or the name or ID of the service linked to it (or a \[this service\] placeholder referring to a service).

  - The property to be retrieved, which can be specified as follows:

    - **ProfileID**: The GUID of the profile instance linked to the resource retrieved from the booking. If this property is used, the node ID must be specified in *\<argA>*.

    - **ResourceID**: The GUID of the resource linked to the booking. If this property is used, the node ID must be specified in *\<argA>*.

    - **Property=*\<propName>***: The value of a custom property of the booking. The name of that custom property must be specified in \<propName>.

    > [!NOTE]
    > In case the property is not present for a particular booking, nothing will be displayed.

    For example:

    ```txt
    [reservation:[this service],Property=Class]
    ```

  - The arguments necessary to be able to retrieve the property, specified using the following syntax: *\<ArgumentName>=\<ArgumentValue>*. For example, *NodeID=15*.

    Depending on the specified property, these arguments may not be needed.

- Alternatively, from DataMiner 9.6.8 onwards, you can add “,*start*” or “*,end*” within this placeholder in order to retrieve the start or end time of a specific booking.

  For example, to retrieve the start time of a booking, configure the placeholder as follows:

  ```txt
  [Reservation:<ReservationGuid>,Start]
  ```

- From DataMiner 10.0.6 onwards, this placeholder can also be used to retrieve the ID of a booking, using the following syntax:

  ```txt
  [reservation:<bookingID or service name or service ID or placeholder referring to a service>,ID]
  ```

  For example:

  ```txt
  [reservation:[this service],ID]
  ```

- From DataMiner 10.0.10 onwards, this placeholder can also be used to retrieve the status of a booking (e.g. “Ended”, “Pending”, “Ongoing”, etc.), using similar syntax:

  ```txt
  [reservation:<bookingID or service name or service ID or placeholder referring to a service>,Status]
  ```

  For example:

  ```txt
  [reservation:[var:IdOfSelection],Status]
  ```

- From DataMiner 10.1.10/10.2.0 onwards, this placeholder can also be used to retrieve the ID of the service definition of a booking, using the following syntax:

  ```txt
  [reservation:<service ID or booking ID>,ServiceDefinitionID]
  ```

  For example:

  ```txt
  [reservation:[this service],ServiceDefinitionID]
  ```

> [!NOTE]
> This placeholder can be used inside a \[Sum:...\] or \[Subtract:...\] placeholder.

### \[Resource:...\]

From DataMiner 9.6.8 onwards, this placeholder can be used to retrieve a property of a resource, which can be the name of the resource, the ID of the element linked to the resource, a custom property, etc.

For this purpose, the following syntax must be used:

```txt
[Resource:<GUID>,<property>]
```

This syntax consists of the following components:

- The GUID of the resource.

- The property to be retrieved, which can be specified as follows:

  - **FullElementID**: The ID of the resource element (i.e. the DVE representing the resource) in the format DmaID/ElementID. This can for instance be used to link to an actual element in *Element* shape data.

  - **Name**: The name of the resource.

  - **Property=*\<propName>***: The value of a custom property of the resource. The name of that custom property must be specified in \<propName>, e.g. *Property=State*.

  - **InUse**: From DataMiner 10.3.0/10.2.3 onwards, you can specify *InUse* to make the placeholder indicate whether a resource is being used in any bookings (with the result "true" or "false"). From DataMiner 10.3.0/10.2.6 onwards, this placeholder can also be used for a shape linked to an element, to indicate whether the element is being used in a resource, is a DVE parent of a function resource, or represents the physical device corresponding with a virtual function resource. However, note that the [UseResource=true](xref:Linking_a_shape_to_a_resource) option must be specified on the element shape for this to work.

    ```txt
    [Resource:<GUID>,InUse]
    ```

    > [!NOTE]
    >
    > - Prior to DataMiner 10.2.6/10.3.0, the *InUse* check is only performed when the visual overview is opened or when the resource itself is changed.
    > - Using the *InUse* placeholder may affect performance in case the system contains a large number of bookings.

  - **ContributingBooking**: From DataMiner 10.3.0/10.2.11 onwards, you can specify *ContributingBooking* to retrieve the contributing booking ID of a resource.

### \[ServiceDefinition:\]

Full syntax: *\[ServiceDefinition:*\<ServiceDefinitionID>*,*\<Property>*\]*

From DataMiner 10.2.0/10.1.10 onwards, you can use this placeholder to retrieve properties of a service definition.

The following properties are supported:

- **Name**: The name of the service definition.

- **Actions**: The name of the scripts that are defined on the service definition. Names of multiple actions will be separated by colons (“:”). This will allow them to be inserted directly into e.g. a SetVar shape.

- **Property=*\<propertyName>***: The value of a custom property of the service definition.

- **Type**: Supported from DataMiner 10.3.0/10.2.4 onwards. The type of service definition. This can be *Default* (representing the default type "SRM"), *ProcessAutomation* (representing the type "Skyline Process Automation"), or *CustomProcessAutomation*.

For example:

```txt
[ServiceDefinition:[reservation:[this service],ServiceDefinitionID],Actions]
```

From DataMiner 10.2.0/10.2.3 onwards, you can pass a node label in this placeholder to look up a node ID. For example:

```txt
[ServiceDefinition:aaaa-bbb-ccc-ddd,NodeID|NodeLabel=Primary Receiver]
```

You can for instance use this to find a resource by passing a label of a service definition node. For example:

```txt
[Reservation:[this service],ResourceID|NodeID=[ServiceDefinition:aaaa-bbb-ccc-ddd,NodeID|NodeLabel=Primary Receiver]]
```

> [!NOTE]
> Passing a label of a service definition node is preferable over passing the service definition node ID, as this ID is susceptible to change.

### \[servicedefinitionfilter\]

Reference to the row filter of an included table parameter (in a Visio file linked to a service).

> [!NOTE]
> This placeholder can also refer to mediation layer parameters. This allows you to use the same Visio file for different services based on the same service definition.

### \[ServiceFilter\]

Reference to the service that was clicked in the service list (only for EPM environments).

> [!NOTE]
> This placeholder works in exactly the same way as the \[ServiceFilterName\] placeholder.

### \[ServiceFilterIdx\]

Reference to the primary key of the selected service in the Service Overview Manager. This placeholder can only be used in **AlarmFilter** shape data when a Service Overview Manager is used.

> [!TIP]
> See also: [Making a shape filter Alarm Console tabs when clicked](xref:Making_a_shape_filter_Alarm_Console_tabs_when_clicked)

### \[ServiceFilterName\]

Reference to the service that was clicked in the service list (only for EPM environments).

> [!NOTE]
> This placeholder works in exactly the same way as the \[ServiceFilter\] placeholder.

### \[ServiceSelectionFilter\]

Used when embedding an alarm timeline component, in order to select a single parameter to be displayed based on the service/location.

> [!TIP]
> See also: [Embedding an alarm timeline component](xref:Embedding_an_alarm_timeline_component)

### \[Service definition properties\]

Available from DataMiner 9.5.3 onwards.

Use this placeholder in a shape data item of type **Tooltip** or in shape text. The tooltip or shape text will then display service definition properties, separated by line breaks. Each property will be displayed as “\<Property name>: \<Property value>”.

- For a top-level element shape (i.e. not an interface shape), all properties of the node specified in the service definition will be shown.

- For an interface shape, all interface properties of the service definition will be shown.

- For a connection line, all properties defined for that line in the service definition will be shown.

> [!TIP]
> See also: [Making a shape display a custom tooltip](xref:Making_a_shape_display_a_custom_tooltip)

### \[Service definition property:\<property name>\]

Available from DataMiner 9.5.3 onwards.

Use this placeholder in a shape data item of type **Tooltip** or in shape text. The tooltip or shape text will then display the property value of the specified service definition property.

- For a top-level element shape (i.e. not an interface shape), the property has to be one of the properties of the node specified in the service definition.

- For an interface shape, the property has to be one of the interface properties of the service definition.

- For a connection line, the property has to be one of the properties defined for that line in the service definition.

> [!TIP]
> See also: [Making a shape display a custom tooltip](xref:Making_a_shape_display_a_custom_tooltip)

### \[SLAFromService:\<service(s)>\]

Available from DataMiner 9.5.11 onwards.

This placeholder will be replaced with the DMA ID/Element ID combinations of the SLAs for the specified services. One or more services can be specified, separated by semicolons.

For example, if a system contains two services, Service A (with two SLAs with IDs 1/1 and 1/2) and Service B (with one SLA with ID 1/3), the following placeholder will be replaced by *1/1;1/2;1/3*:

```txt
[SLAFromService:Service A;Service B]
```

### \[SourceInterfaceElementID\]

Available from DataMiner 9.5.3 onwards.

The DMA ID and element ID of the source interface of the connection that was clicked.

> [!TIP]
> See also: [Navigation options for automatically drawn connections](xref:Positioning_shapes_dynamically1#navigation-options-for-automatically-drawn-connections)

### \[SourceInterfaceElementName\]

Available from DataMiner 9.5.3 onwards.

The element name of the source interface of the connection that was clicked.

> [!TIP]
> See also: [Navigation options for automatically drawn connections](xref:Positioning_shapes_dynamically1#navigation-options-for-automatically-drawn-connections)

### \[SourceInterfaceIdx\]

Available from DataMiner 9.5.3 onwards.

The interface ID of the source interface of the connection that was clicked.

> [!TIP]
> See also: [Navigation options for automatically drawn connections](xref:Positioning_shapes_dynamically1#navigation-options-for-automatically-drawn-connections)

### \[SourceInterfaceLinkedIdx\]

Available from DataMiner 9.5.3 onwards.

The primary key of the table row to which the source interface of the connection that was clicked is linked.

> [!TIP]
> See also: [Navigation options for automatically drawn connections](xref:Positioning_shapes_dynamically1#navigation-options-for-automatically-drawn-connections)

### \[SourceInterfaceName\]

Available from DataMiner 9.5.3 onwards.

The interface name of the source interface of the connection that was clicked.

> [!TIP]
> See also: [Navigation options for automatically drawn connections](xref:Positioning_shapes_dynamically1#navigation-options-for-automatically-drawn-connections)

### \[Subtract:...\]

From DataMiner 9.6.8 onwards, this placeholder can be used to calculate datetime and time span values by subtracting one or more values from a specified value. For example:

- Calculating a time span by subtracting one datetime value from another:

    \[Subtract:14/02/1989 22:22:22,12/01/1989 11:10:9\]

- Calculating a time span by subtracting a datetime value and two time span values from a datetime value:

    \[Subtract:14/02/1989 22:22:22,12/01/1989 11:10:9,00:01:00,00:00:05\]

- Calculating a datetime value by subtracting a time span from a datetime value:

    \[Subtract:14/02/1989 22:22:22,00:02:00\]

- Calculating a time span by subtracting one time span from another:

    \[Subtract:23:33:15,00:03:15\]

By default, datetime and time span values will be displayed in the regional date/time format. If you want such a value to be displayed in another format, then specify the format inside the placeholder, for example: *\[Subtract:23:33:15,00:03:15\|Format=hh\:mm\]*.

> [!NOTE]
> For more info on possible formats, refer to <https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-timespan-format-strings>.

From DataMiner 10.3.8/10.4.0 onwards, the subtract placeholder also supports numerics. Just like with time spans, you can subtract consecutive numbers from the first number.

- Subtracting one number from another:

    \[Subtract:10,3\]

- Subtracting multiple numbers from the first number:

    \[Subtract:10.1,3.3, 2.6\]

### \[Sum:X,Y,Z\]

Available from DataMiner 9.5.8 onwards.

Sum of a list of entries, e.g. X, Y, Z (which will be parsed to numbers).

From DataMiner 9.6.8 onwards, this placeholder also supports datetime and time span values.

### \[tableindex\]

When, inside a Microsoft Visio drawing, you specify placeholders like \[param: ...\] and \[property: ...\] in child shape data items of type “Row”, you can use \[tableindex\] inside those placeholders. This placeholder will then dynamically be replaced by the row’s table index.

> [!TIP]
> See also: [\[displaytableindex\]](#displaytableindex)

### \[tableIndexFilter\]

Takes the table index of the item that is dropped onto or hovered over the item in which this placeholder has been specified.

> [!TIP]
> See also: [Example of a drag-and-drop action that passes on a table filter](xref:Triggering_an_action_when_a_shape_is_dragged_onto_another_shape#example-of-a-drag-and-drop-action-that-passes-on-a-table-filter)

### \[TableIndexFilterResolved\]

When drag-and-drop behavior has been configured for child shapes, this placeholder represents the primary key of the row represented by the dragged shape.

> [!TIP]
> See also: [Configuring drag-and-drop behavior for child shapes](xref:Triggering_an_action_when_a_shape_is_dragged_onto_another_shape#configuring-drag-and-drop-behavior-for-child-shapes)

### \[TableDisplayIndexResolved\]

When drag-and-drop behavior has been configured for child shapes, this placeholder represents the display key of the row represented by the dragged shape.

> [!TIP]
> See also: [Configuring drag-and-drop behavior for child shapes](xref:Triggering_an_action_when_a_shape_is_dragged_onto_another_shape#configuring-drag-and-drop-behavior-for-child-shapes)

### \[ThisGroup\]

This placeholder can be used from DataMiner 9.5.1 onwards. It is replaced with all the security groups that the currently logged-in user is part of. Multiple groups will be concatenated with a pipe ("\|") character.

### \[thisMAC\]

All MAC addresses of the client machine, separated by pipe characters (“\|”).

### \[thisusername\]

The name of the current user.

### \[thisuserfullname\]

The full name of the current user.

### \[This card object\]

The name of the view, service or element to which the Visio file is linked.

### \[This card objectID\]

The ID of the view, service or element to which the Visio file is linked.

### \[this element\]

Reference to the element to which the Visio drawing is linked.

It is possible to override the default behavior of this placeholder for child shapes. In case you want the placeholder to refer to the element linked to the parent shape of a child shape, instead of the element linked to the entire Visio drawing, add a shape data field of type **Options**, and set its value to “*ForcePropertyFromParent*”.

> [!TIP]
> See also: [ForcePropertyFrom Parent](xref:Overview_of_page_and_shape_options)

### \[this ElementID\]

Reference to the element ID of the element to which the Visio drawing is linked. This placeholder is resolved as *DataMinerID/ElementID.*

It is possible to override the default behavior of this placeholder for child shapes. In case you want the placeholder to refer to the element linked to the parent shape of a child shape, instead of the element linked to the entire Visio drawing, add a shape data field of type **Options**, and set its value to “*ForcePropertyFromParent*”.

> [!TIP]
> See also: [ForcePropertyFrom Parent](xref:Overview_of_page_and_shape_options)

### \[This EnhancedServiceID\]

In a drawing linked to an enhanced service, you can refer to this service with this placeholder.

### \[this reservationID\]

From DataMiner 10.2.8/10.3.0 onwards, you can use this placeholder in shape data or shape text of shapes linked to a booking (e.g. dynamically generated shapes that represent bookings) to retrieve the GUID of the booking. The placeholder can also be nested, for example to retrieve booking properties or resources.

For example:

`[Resource:[reservation:[this reservationID],ResourceID|NodeID=18|],Name]`

`[reservation:[this reservationID],Property=Monitoring]`

> [!NOTE]
> This placeholder is often used in combination with the shape data **Options** set to `AllowInheritance=False|ForcePropertyFromParent`. See [AllowInheritance=False](xref:Overview_of_page_and_shape_options#allowinheritancefalse) and [ForcePropertyFromParent](xref:Overview_of_page_and_shape_options#forcepropertyfromparent).

### \[this service\]

Reference to the service to which the Visio drawing is linked.

It is possible to override the default behavior of this placeholder for child shapes. In case you want the placeholder to refer to the service linked to the parent shape of a child shape, instead of the service linked to the entire Visio drawing, add a shape data field of type **Options**, and set its value to “*ForcePropertyFromParent*”.

> [!TIP]
> See also: [ForcePropertyFrom Parent](xref:Overview_of_page_and_shape_options)

### \[this ServiceID\]

Reference to the service to which the Visio drawing is linked. This placeholder is resolved as *DataMinerID/ServiceID.*

It is possible to override the default behavior of this placeholder for child shapes. In case you want the placeholder to refer to the service linked to the parent shape of a child shape, instead of the service linked to the entire Visio drawing, add a shape data field of type **Options**, and set its value to “*ForcePropertyFromParent*”.

> [!TIP]
> See also: [ForcePropertyFrom Parent](xref:Overview_of_page_and_shape_options)

### \[this view\]

Reference to the view to which the Visio drawing is linked.

It is possible to override the default behavior of this placeholder for child shapes. In case you want the placeholder to refer to the view linked to the parent shape of a child shape, instead of the view linked to the entire Visio drawing, add a shape data field of type **Options**, and set its value to “*ForcePropertyFromParent*”.

> [!TIP]
> See also: [ForcePropertyFrom Parent](xref:Overview_of_page_and_shape_options)

### \[this ViewID\]

Reference to the view ID of the view to which the Visio drawing is linked.

It is possible to override the default behavior of this placeholder for child shapes. In case you want the placeholder to refer to the view linked to the parent shape of a child shape, instead of the view linked to the entire Visio drawing, add a shape data field of type **Options**, and set its value to “*ForcePropertyFromParent*”.

> [!TIP]
> See also: [ForcePropertyFrom Parent](xref:Overview_of_page_and_shape_options)

### \[UTCTime\]

Available from DataMiner 9.6.9 onwards. Reference to the current DataMiner time in the UTC time zone.

By default, this time will be displayed in the regional date/time format. If you want the time to be displayed in a different format, specify the format inside the placeholder. For example:

```txt
[UTCTime:Format=HH:mm:ss]
```

> [!NOTE]
> The time shown by this dynamic placeholder is refreshed every second.

### \[var:VariableName\]

Reference to a session variable (scope: current DataMiner Cube session).

As parameters of which the value is an empty string are considered initialized, you can use a \[var:...\] placeholders to refer to a parameter containing an empty string.

### \[xpos\]

In child shapes of a shape that is dynamically linked to an element (i.e. shape data field of type **Element** set to \*), you can use \[xpos\] and \[ypos\] placeholders.

In references to table parameters, for example, you can specify the tableIndex using \[xpos\] and \[ypos\] placeholders.

Example: The parameter reference *13206:\[xpos\]\_0\|Alarm* will become *13206:5_0\|Alarm* if the shape is displayed in horizontal position 5.

### \[ypos\]

See [\[xpos\]](#xpos).
