---
uid: Positioning_shapes_dynamically1
---

# Positioning shapes dynamically

There are two ways to dynamically position shapes in Visio drawings.

- Based on coordinates stored in properties of elements, services or views: see [Shape positioning based on coordinates stored in properties of elements, services or views](#shape-positioning-based-on-coordinates-stored-in-properties-of-elements-services-or-views).

- Based on coordinates stored in dynamic tables: see [Shape positioning based on coordinates stored in dynamic tables](#shape-positioning-based-on-coordinates-stored-in-dynamic-tables).

Regardless of the method used to dynamically position shapes, it is possible to also have connections drawn between the dynamically positioned shapes. See [Connections between dynamically positioned shapes](#connections-between-dynamically-positioned-shapes).

In addition, certain options can be configured for dynamically positioned shapes. See [Options for dynamically positioned shapes](#options-for-dynamically-positioned-shapes).

## Shape positioning based on coordinates stored in properties of elements, services or views

Suppose you have a view that contains three elements, and you want the Visio drawing linked to that view to display automatically positioned shapes representing each of those three elements.

1. In the drawing, create two calibration shapes. See [Calibrating the X and Y coordinates in a Visio drawing](xref:Calibrating_the_X_and_Y_coordinates_in_a_Visio_drawing).

1. In the drawing, create one shape representing an element, and add the following shape data fields to it:

   | Shape data field | Value              |
   |------------------|--------------------|
   | Element          | \[auto\]           |
   | XPos             | \[property:AxisX\] |
   | YPos             | \[property:AxisY\] |

   > [!NOTE]
   > If you want to manually adjust the X and Y coordinates, you can also add shape data fields of type **XPosOffSet** and **YPosOffSet**.

1. To each of the three elements, add the properties “*AxisX*” and “*AxisY*”, and assign a value to them.

Result: For every element underneath the view, the drawing will contain a shape linked to that element and positioned based on the coordinates specified in the properties of that element.

### Shape data

- **Element or view**: Enter the following if you want a shape to be drawn for every element, service or view specified. If you specify multiple elements, services or views, separate them by colons (”:”).

  ```txt
  DmaID/ItemID:DmaID/ItemID:...
  ```

  Enter the following if you want a shape to be drawn for every element, service or view directly underneath the view to which the drawing is linked.

  ```txt
  [auto]
  ```

  Enter the following if you want a shape to be drawn for every element, service or view underneath the view to which the drawing is linked, including those elements or views underneath any subviews.

  ```txt
  [auto:includeSubViews]
  ```

  Enter the following if you want a shape to be drawn for every element, service or view mentioned in the specified property of the element, service or view to which the drawing is linked. If, in a property, you want to specify multiple elements, services or views, separate them by colons (”:”).

  ```txt
  [property:PropertyName]
  ```

- **XPos**: Property of the specified element, service or view, which must contain a decimal number between the minimum and the maximum xpos specified in the two calibration shapes. See [Calibrating the X and Y coordinates in a Visio drawing](xref:Calibrating_the_X_and_Y_coordinates_in_a_Visio_drawing).

  ```txt
  [property:PropertyName]
  ```

- **YPos**: Property of the specified element, service or view, which must contain a decimal number between the minimum and the maximum ypos specified in the two calibration shapes. See [Calibrating the X and Y coordinates in a Visio drawing](xref:Calibrating_the_X_and_Y_coordinates_in_a_Visio_drawing).

  ```txt
  [property:PropertyName]
  ```

- **XPosOffSet**: Value to be added to the value found in **XPos**. Allows you to manually adjust the X coordinate.

- **YPosOffSet**: Value to be added to the value found in **YPos**. Allows you to manually adjust the Y coordinate.

- **SubscriptionFilter**: A shape data item of type **SubscriptionFilter** can be added to a shape to make it appear only if a specific table column contains a certain value.

  Suppose you have a list of cities stored in a dynamic table, and you want to indicate the location of each of those cities on a map using circles of different diameter based on the size of the city. You create two circular shapes (a small one and a large one) and add the following shape data items to them:

  - XPos: ...

  - YPos: ...

  - SubscriptionFilter: Value=Pid == X

    - Pid: Parameter ID of the table column

    - X=1 (large city) or X=2 (small city)

  The result will be that:

  - the shape of which SubscriptionFilter contains “*value=120 == 1*” will be used to indicate a city of which the column with parameter ID 120 contains “1”, and

  - the shape of which SubscriptionFilter contains “*value=120 == 2*” will be used to indicate a city of which the column with parameter ID 120 contains “2”.

  > [!NOTE]
  >
  > - The circles indicating the location of the cities will bear the current alarm color of the corresponding table row.
  > - In order to avoid parsing problems due to “;” separators in table row filters, it is advised to specify an alternative separator in a \[sep:XY\] tag. See [About using separator characters](xref:Linking_a_shape_to_a_SET_command#about-using-separator-characters).

  > [!TIP]
  > See also: [Dynamic table filter syntax](xref:Dynamic_table_filter_syntax)

- **SelectionDetails**: If you want the shape to act as a Details pane displaying the row data, then add a shape data item to it of type **SelectionDetails** and set its value to “1”.

  > [!TIP]
  > See also: [Table configuration in the protocol](#table-configuration-in-the-protocol)

## Shape positioning based on coordinates stored in dynamic tables

Suppose you want a Visio drawing to contain an automatically positioned shape for every row in a dynamic table of a particular element.

1. In the drawing, create two calibration shapes. See [Calibrating the X and Y coordinates in a Visio drawing](xref:Calibrating_the_X_and_Y_coordinates_in_a_Visio_drawing).

1. In the drawing, create one shape, and add the following shape data field to it:

   | Shape data field | Value |
   |------------------|-------|
   | Xpos             | \[param:*DmaID*/*ElementID*,*TableParameterID*\] |

   > [!NOTE]
   > If you want to manually adjust the X coordinate, you can also add a shape data field of type **XPosOffSet**. Set this field to the value that should be added to the value found in **Xpos**.

   For example:

   | Shape data field | Value               |
   |------------------|---------------------|
   | Xpos             | \[param:9/542,110\] |

   Result: For every row in table parameter 110 of element 9/542, the drawing will contain a shape displaying the contents of the table’s display column, positioned based on the coordinates specified in the columns marked with “xpos” and “ypos” in the element protocol.

> [!NOTE]
> If you want to refer to a parameter of the current element, you can replace the element reference by an asterisk (“\*”). Example: **Xpos** = \[param:\*,110\]

### Linking the automatically positioned shapes to elements, services or views fetched from a table

The element, service, or view to which a shape has to be linked can also be fetched from a table. In other words, you can dynamically create a shape for every row in a table.

Those dynamically created shapes can be configured as ordinary element, service, or view shapes. They can be configured to show real-time parameter values, element states, etc.

- In the “dynamic shape” to which you have added a shape data field of type **XPos** containing a placeholder referring to a table parameter, also add a shape data field of type **Element** (in case of elements or services) or **View** (in case of views), and set its value to “\*”.

- The table column from which the element has to be fetched (see below), has to contain element IDs (format: DmaID/ElementID), element names, service IDs (format: DmaID/ServiceID), service names, view IDs, or view names.

### Table configuration in the protocol

In the protocol, check the definition of the table parameter that will supply the data to be used:

- The “display column” has to be the column containing the data to be displayed in the dynamically positioned shapes.

- The column containing the element has to be marked as the “LinkElement” column:

  ```xml
  <ColumnOption idx="..." pid="..." type="..." value="..." options=";LinkElement" />
  ```

- The column containing the X coordinates has to be marked as the “xpos” column:

  ```xml
  <ColumnOption idx="..." pid="..." type="..." value="" options=";xpos" />
  ```

- The column containing the Y coordinates has to be marked as the “ypos” column:

  ```xml
  <ColumnOption idx="..." pid="..." type="..." value="" options=";ypos" />
  ```

- Columns that should always be hidden in a Details pane have to be marked with “HideKPI”:

  ```xml
  <ColumnOption idx="..." pid="..." type="..." value="" options=";HideKPI" />
  ```

- Columns that should only be hidden in a Details pane if the value is “Not Initialized” have to be marked with “HideKPIWhenNotInitialized”:

  ```xml
  <ColumnOption idx="..." pid="..." type="..." value="" options=";HideKPIWhenNotInitialized" />
  ```

### Applying a row filter before dynamically positioned shapes are generated

From DataMiner 9.0.5 onwards, it is possible to apply a row filter when dynamically positioning shapes based on table data. Using this filter can considerably increase overall performance.

To do so, add a shape data field of type **Filter** to the shape mentioned above, and enter a row filter, using the same syntax as for extended shape manipulation conditions.

For example:

| Shape data field | Value                                      |
|------------------|--------------------------------------------|
| Xpos             | \[param:9/542,110\]                        |
| Filter           | \<A>-A\|Element:\*\|Alarmlevel\|\>=Warning |

> [!NOTE]
> A single asterisk (“\*”) in the filter will refer to the element specified in the table’s LinkElement column (if any). A double asterisk (“\*\*”) will refer to the element that contains the table.

> [!TIP]
> See also: [Extended conditional shape manipulation actions](xref:Extended_conditional_shape_manipulation_actions)

### Dynamically selecting shape templates for dynamically positioned shapes

From DataMiner 9.5.8 onwards, it is possible to specify shape templates for the creation of dynamically positioned shapes based on table data. This can be used to avoid having to define multiple dynamically positioned shapes based on the same table but with different subscription filters.

To do so, create template shapes as child shapes for the XPos shape. For each template shape, add a shape data field of type **Template**, and enter a filter as the value, using the same syntax as for extended shape manipulation conditions.

> [!NOTE]
> The filter allows you to specify a parameter without identifying the element. The value of the parameter will then be retrieved from the table referred to by the parameter placeholder in the XPos shape.

> [!TIP]
> See also: [Extended conditional shape manipulation actions](xref:Extended_conditional_shape_manipulation_actions)

When the condition for a particular template is true for a particular row of the table, the template will be applied for that row.

In the following example, a parent shape subscribes to the table, and three child shapes each have a template defined:

- Parent shape

  | Shape data field | Value                  |
  |------------------|------------------------|
  | XPos             | \[param:100/20, 1000\] |

- Child shape A

  | Shape data field | Value                       |
  |------------------|-----------------------------|
  | Template         | \<A>-A\|Parameter:1101\|==1 |

- Child shape B

  | Shape data field | Value                       |
  |------------------|-----------------------------|
  | Template         | \<A>-A\|Parameter:1101\|==2 |

- Child shape C

  | Shape data field | Value                       |
  |------------------|-----------------------------|
  | Template         | \<A>-A\|Parameter:1101\|==3 |

### Dynamically setting the interfaces of each dynamically positioned element

If you use shape positioning based on coordinates stored in dynamic tables, you can also dynamically set the interfaces of each dynamically positioned element.

To do so:

1. In the protocol, go to the definition of the table that contains the positioning data, and add an extra column named e.g. “InterfaceData” next to the “xpos” and “ypos” columns. In the *ColumnOptions* tag of this additional column, add the option “DynamicData”.

1. To the subshapes that represent the interfaces, add a shape data field of type **Interface**, and set its value to *\[Dynamic:InterfaceName\]*.

   Example:

   ```txt
   [Dynamic:input1]
   ```

1. In DataMiner Cube, open the element, go to the table that contains the positioning data, and add the necessary interface data in the “InterfaceData” column using the following syntax:

   ```txt
   InterfaceName=4;InterfaceName=34;
   ```

   Example:

   ```txt
   input1=5;input2=8;output1=5
   ```

> [!NOTE]
> Changes to interfaces are automatically processed by DataMiner Cube and reflected in Visual Overview. If, for example, an element with a particular interface is stopped, the interface will no longer be shown in Visual Overview.

## Options for dynamically positioned shapes

A number of options are available in case you use dynamic positioning of shapes:

- [Disabling the automatic selection filter in an EPM environment](#disabling-the-automatic-selection-filter-in-an-epm-environment)

- [Overriding the default table loading behavior](#overriding-the-default-table-loading-behavior)

- [Positioning shapes based on their rotation point](#positioning-shapes-based-on-their-rotation-point)

### Disabling the automatic selection filter in an EPM environment

When shapes are dynamically positioned in an EPM environment, a subscription filter is automatically added to the table, which depends on the current selection of the EPM environment. From DataMiner 9.5.1 onwards, it is possible to disable this automatic filter, so that dynamic positioning is applied to all shapes, and not just to those matching the selection filter.

To do so, add an **Options** shape data field to the shape that has the **XPos** shape data field, and set it to *NoSelectionFilters*.

Example:

| Shape data field | Value               |
|------------------|---------------------|
| Xpos             | \[param:9/542,110\] |
| Options          | NoSelectionFilters  |

### Overriding the default table loading behavior

From DataMiner 9.5.1 onwards, by default, DataMiner only loads those columns of a dynamic table that are needed to display the table connections and any information those shapes have to contain.

However, in some cases it can be useful to have the entire table retrieved, for example because variable values have to be displayed on the dynamically positioned shapes. In such a case, you can override the default retrieval method by adding the “*ForceFullTable*” option to the template shape. Note, however, that using this option will have a negative impact on overall performance.

| Shape data field | Value          |
|------------------|----------------|
| Options          | ForceFullTable |

### Positioning shapes based on their rotation point

By default, the position of a dynamically positioned shape is determined based on the physical center of the shape. However, from DataMiner 9.5.12 onwards, it is possible to configure the Xpos shape so that the rotation point of the shape is used instead. To do so, add the **Options** shape data field and set it to *PositionOnCenterOfRotation*.

For example:

| Shape data field | Value                      |
|------------------|----------------------------|
| Xpos             | \[param:451/3808,500\]     |
| Options          | PositionOnCenterOfRotation |

## Connections between dynamically positioned shapes

When using dynamic shape positioning based on coordinates stored in tables, the dynamically positioned shapes can be automatically connected by lines.

For this feature to work, the shape positioning data (i.e. the data describing where to draw which shape) and the connection data (i.e. the data describing the connections to be drawn between shapes) have to be located in separate tables of the same element.

> [!NOTE]
>
> - Using different tables for the positioning data is supported, but the keys from the different tables that are used to create the connections must be unique over all the tables. The shapes are linked via the primary keys of the positioning data tables, not via a foreign key relation. Each connection line makes a connection between the two primary keys of the dynamically positioned shapes.
> - Normally, the shape data fields described below will only be used in EPM environments.

### Dynamic lines

Line objects that have to be used to automatically connect shapes should be assigned the following three shape data fields:

- Connection: In this shape data field, specify the table columns (Element ID as well as column IDs) where DataMiner can find the data describing where to draw the necessary connections:

  ```txt
  DmaID/ElementID|FROMColID|ToColID|Alarm
  ```

  Example:

  ```txt
  6/111664|4003|4004|Alarm
  ```

  Within this shape data field, you can also configure the following options

  - By default, lines that connect shapes always run from shape center to shape center. If you want these lines to run from shape edge to shape edge instead, you can use the *EdgeModeX* or *EdgeModeY* option.

    | Value                                        | Description                                |
    |------------------------------------------------|--------------------------------------------|
    | DmaID/ElementID\|FromColID\|ToColID            | Connection between shape centers (default) |
    | DmaID/ElementID\|FromColID\|ToColID\|EdgeModeX | Connection between left/right shape sides  |
    | DmaID/ElementID\|FromColID\|ToColID\|EdgeModeY | Connection between top/bottom shape sides. |

  - By default, the lines run between the rotation centers of the shapes. If the *CenterModeX* or *CenterModeY* options (available from DataMiner 9.5.12 onwards) are specified, the lines will instead be drawn to the physical center of shapes in the X or Y direction, respectively.

    | Shape data field        | Description                                                         |
    |---------------------------|---------------------------------------------------------------------|
    | Connectivity\|CenterModeX | Connection between the physical center of shapes in the X direction |
    | Connectivity\|CenterModeY | Connection between the physical center of shapes in the Y direction |

    > [!NOTE]
    >
    > - The CenterMode and EdgeMode options can be combined. However, it is not possible to use both *EdgemodeX* and *CenterModeX* or both *EdgeModeY* and *CenterModeY* at the same time.
    > - These options can also be used on *Element* shapes that are positioned manually in Visio.

- **SelectionDetails**: In this shape data field, you can specify the IDs of any additional tables that you want to see listed in the Details pane of the EPM interface when someone selects the connection:

  ```txt
  |ExtraTableID1|ExtraTableID2|...
  ```

  Example:

  ```txt
  |3000
  ```

- **SubscriptionFilter**: If you use different types of lines for different types of connections, then in this shape data field, you can specify a filter that will make sure that the line object in question is only used for connections of which the specified column of the row describing the connection contains a particular value. If you want to specify multiple comparisons, separate them by semicolons (”;”).

  ```txt
  value=[comparison]
  ```

  Example:

  ```txt
  value=4005 == 1 (use this line if column ID 4005 contains "1")
  ```

  > [!TIP]
  > See also: [Dynamic table filter syntax](xref:Dynamic_table_filter_syntax)

### Dynamic shapes

If you add a shape data field of type **SelectionDetails** to a shape other than a line, you can specify the IDs of any additional tables that you want to see listed in the *Details* pane of the EPM interface when someone selects that shape:

```txt
|ExtraTableID1|ExtraTableID2|...
```

Example:

```txt
|2000
```

### Navigation options for automatically drawn connections

By default, when you click a connection, a KPI window appears. However, you can also specify that when you click a connection, you go to another Visio page, or you get to see a Visio page in either a new window or a pop-up.

| In order to ...    | use a shape data field of type ... | and specify ...  |
|--------------------|------------------------------------|------------------|
| go to another page | NavigatePage                       | Pagename         |
| open a new window  | VdxPage                            | Pagename\|Window |
| open a pop-up      | VdxPage                            | Pagename\|Popup  |

> [!NOTE]
> From DataMiner 10.2.11/10.3.0, [dynamic placeholders](xref:Placeholders_for_variables_in_shape_data_values) are supported in the *NavigatePage* shape data value.

By adding an extra shape data field of type **SetVar**, you can specify that a session variable is set the moment a connection is clicked.

In the **SetVar** statement, you can use the following placeholders:

| Placeholder                         | Description                                                               |
|-------------------------------------|---------------------------------------------------------------------------|
| \[ConnectionLineDisplayIdx\]        | Display key of the connection that was clicked.                           |
| \[ConnectionLineIdx\]               | Primary key of the connection that was clicked.                           |
| \[ConnectionlineFromKey\]           | Starting point of the connection that was clicked.                        |
| \[ConnectionLineToKey\]             | End point of the connection that was clicked.                             |
| \[SourceInterfaceElementID\]        | DmaID/ElementID of the source interface                                   |
| \[SourceInterfaceElementName\]      | Element name of the source interface                                      |
| \[SourceInterfaceIdx\]              | Interface ID of the source interface                                      |
| \[SourceInterfaceLinkedIdx\]        | Primary key of the table row to which the source interface is linked      |
| \[SourceInterfaceName\]             | Name of the source interface                                              |
| \[DestinationInterfaceElementID\]   | DmaID/ElementID of the destination interface                              |
| \[DestinationInterfaceElementName\] | Element name of the destination interface                                 |
| \[DestinationInterfaceIdx\]         | Interface ID of the destination interface                                 |
| \[DestinationInterfaceLinkedIdx\]   | Primary key of the table row to which the destination interface is linked |
| \[DestinationInterfaceName\]        | Name of the destination interface                                         |

Example:

```txt
MyVariable:[ConnectionLineDisplayIdx] ([ConnectionLineIdx]) (from '[ConnectionLineFromKey]' to '[ConnectionLineToKey]')
```

> [!NOTE]
>
> - If a connection has no clear direction (i.e. when both interfaces are set to “inout”), it is impossible to know which interface will be the source and which will be the destination.
> - If a line represents multiple connections (i.e. when the *MultipleLinesMode* and *MultipleCurvedLinesMode* options are not used), and a **SetVar** command has been configured on one of those connections, clicking the line will cause the placeholders to be replaced by the corresponding values from each connection, separated by a pipe character (“\|”). A different separator character can also be defined with a **SetVarOptions** shape data field that is set to the *MultipleValueSep=* option.
