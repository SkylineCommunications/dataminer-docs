---
uid: Generating_shapes_based_on_table_rows
---

# Generating shapes based on table rows

In a Visio drawing, you can specify that a shape should be created automatically for every row in a table.

To implement this feature, do the following:

1. Create the shape representing a table row, and add the necessary child-level shape data fields to it. See [Child-level shape data](#child-level-shape-data).
1. Put the shape into a group, and add the necessary group-level shape data fields to the group. See [Group-level shape data](#group-level-shape-data).

When generating child shapes based on table rows, the service context is taken into account. In other words, if there is a service context, then shapes will only be created for rows that are included in the service. In order to determine if there is a service context, DataMiner will look for a service reference in the shape hierarchy. Starting from the container shape itself, it will search all the way up to Visio page level and eventually Visio file level. See also **ChildrenFilter** below.

When, inside a Microsoft Visio drawing, you specify placeholders like \[Param: ...\] and \[Property: ...\] in child shape data items of type "Row", you can use \[tableindex\] and \[displaytableindex\] inside those placeholders. These will then dynamically be replaced by either the row table index or the row display index.

> [!NOTE]
>
> - It is also possible to make the shapes use a different index than that of the original row. See [Making a shape use a different index than that of the original row](#making-a-shape-use-a-different-index-than-that-of-the-original-row).
> - Just like for shape positioning based on dynamic tables, you can also use the "LinkElement" and "DynamicData" ColumnOptions in the protocol when generating shapes based on table rows. If the "LinkElement" option is used, the newly created shapes can be linked to a specified element. With the "DynamicData" option, they can have their interface placeholders resolved by dynamic data. For more information, see [Shape positioning based on coordinates stored in dynamic tables](xref:Positioning_shapes_dynamically1#shape-positioning-based-on-coordinates-stored-in-dynamic-tables).
> - For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[children > TABLE ROWS]* page.

## Child-level shape data

The following shape data fields can be added to a shape that has to represent a table row:

- **ChildType**: In this mandatory shape data field, specify the following value:

  - Row

- **ChildMargin**: In this optional shape data field, you can specify the space between the different child items within the container shape.

  - A space relative to the width of the shape representing a child item, or
  - A fixed space (in pixels).

  Examples:

  ```txt
  1/20
  ```

  If the child shapes have a width of 100 px, the space between the child shapes will be 5 px (a twentieth of 100 px).

  ```txt
  5
  ```

  The space between the child shapes will always be 5 px

## Group-level shape data

The following shape data fields can be added to the group containing the table row shapes:

- **Children**: In this mandatory shape data field, specify the following value:

  - Row

  > [!NOTE]
  > With the DataMiner Cube user setting *Maximum number of child shapes in a Children container shape*, you can control the maximum number of Visio shapes allowed in a **Children** container shape. Default: 100

- **ChildrenSource**: In this mandatory shape data field, specify the ID of the source table, i.e. the table of which the rows have to be turned into shapes.

  Use the following syntax:

  ```txt
  DmaId/ElementId/ParameterId
  ```

  or

  ```txt
  ElementName/ParameterId
  ```

  > [!NOTE]
  >
  > - In this shape data field, you can use placeholders like e.g. \[this service\].
  > - From DataMiner 9.5.5/9.5.0 CU2 onwards, it is possible to specify an element alias from a particular service instead of the actual element name.

- **ChildrenOptions**: In this optional shape data field, you can specify a number of options.

  - **Center**: If you want the generated shapes to be centered, then add a shape data field of type **ChildrenOptions** to the container shape, and set its value to "Center".

  - **"Subscribe=true"**: If there is a service context, by default only the columns included in the service are taken into account when calculating the summary color ("\*\|ALARM") of a row. However, if you want all columns to be taken into account, then add a shape data field of type **ChildrenOptions** to the container shape, and set its value to "Subscribe=true".

  - **LazyLoading**: If the child shapes will be generated in a scrollable container shape (stack panel, wrap panel, etc.), use this option to configure lazy loading. Though the child shapes will then be generated immediately, they will only be initialized the moment they come into view.

- **ChildrenSort**: In this optional shape data field, you can specify how the different child item shapes should be sorted:

  | Value | Description |
  | ----- | ----------- |
  | Name | Sort by child item name. |
  | Property\|PropertyName | Sort by the specified child item property. |
  | Severity | Sort by alarm severity. |
  | TableColumn\|\<ParamID> | Sort based on the values in a specific column of the table for which shapes are generated. From DataMiner 9.5.2 onwards, multiple table columns can be specified, separated by pipe characters. Optionally, you can also add the sorting direction for each table column, separated from the table column by a comma. If no sorting direction is specified, by default, the shapes will be sorted in ascending order. E.g. "TableColumn\|101\|102,desc\|103" |

  > [!NOTE]
  >
  > - If you apply sorting by table column, the shapes will automatically be sorted again every time a value changes in the specified column.
  > - From DataMiner 10.2.0/10.1.1 onwards, placeholders such as \[var:VariableName\] can be used in ChildrenSort shape data. See [Placeholders for variables in shape data values](xref:Placeholders_for_variables_in_shape_data_values).

  To specify a sort order, add one of the following suffixes:

  | Suffix | Description                    |
  | ------ | ------------------------------ |
  | ,asc   | Ascending (default sort order) |
  | ,desc  | Descending                     |

  Examples:

  - Sort by severity, descending:

    ```txt
    Severity,desc
    ```

  - Sort by property "MyProperty", ascending:

    ```txt
    Property|MyProperty,asc
    ```

  - Sort in ascending order based on the values found in the column with parameter ID 102:

    ```txt
    TableColumn|102,asc
    ```

- **ChildrenPanel**: In this optional shape data field, you can specify how the child items have to be organized within the container shape.

  Possible values:

  - Stack
  - StackHorizontal
  - StackVertical
  - Grid\|Cols=999
  - Grid\|Rows=999
  - VirtualizingStack
  - VirtualizingStackHorizontal
  - VirtualizingStackVertical
  - Wrap
  - WrapVertical
  - WrapHorizontal

  > [!NOTE]
  > When alarm shapes are dynamically generated, all **ChildrenPanel** options except "StackHorizontal", "VirtualizingStackHorizontal" and "WrapHorizontal" will result in a virtualizing stack panel with vertical orientation.

- **SubscriptionFilter**: A shape data item of type **SubscriptionFilter** can be added to make child shapes appear only if a specific table column contains a certain value.

  Configure the value of the shape data as follows, with "Pid" being the parameter ID of the table column, and "X" being the filter that the value in the table column has to match:

  ```txt
  value=Pid == X
  ```

  Example:

  ```txt
  value=2102 == [param:*,300]
  ```

  > [!NOTE]
  > In order to avoid parsing problems due to ";" separators in table row filters, it is advised to specify an alternative separator in a \[sep:XY\] tag. See [About using separator characters](xref:Linking_a_shape_to_a_SET_command#about-using-separator-characters).

  > [!TIP]
  > See also: [Dynamic table filter syntax](xref:Dynamic_table_filter_syntax)

- **ChildrenFilter**:

  - When child shapes are generated based on table rows, the service context is taken into account. In other words, if there is a service context, then shapes will only be created for rows that are included in the service.

    If you want to ignore the default service filter and have shapes generated for all rows in the table, add a shape data field of type **ChildrenFilter** to the container shape, and set its value to "NoServiceTableFilter".

  - From DataMiner 9.5.1 onwards, it is possible to add a filter so that shapes will only be generated for rows that have a datetime within a particular time window.

    To configure this time window filter, add a shape data field of type **ChildrenFilter** to the **Children** shape, and configure it as follows: "TimeWindow:TimeColumn=XX,StartWindow=-XX,EndWindow=XX,UpdateTime=X".

    - **TimeColumn**: The parameter ID of the column containing the datetime of the row.
    - **StartWindow**: Number of seconds that will be added to the DataMiner time to indicate the start of the time window.
    - **EndWindow**: Number of seconds that will be added to the DataMiner time to indicate the end of the time window.
    - **UpdateTime**: The time it can take for the shapes to update when they are no longer in the time window (the default and minimum value is 1).

    For example:

    | Shape data field | Value                                                                 |
    | ---------------- | --------------------------------------------------------------------- |
    | ChildrenFilter   | TimeWindow:TimeColumn=5,StartWindow=-3600,EndWindow=3600,UpdateTime=5 |

    > [!NOTE]
    > As the time window filter is configured on the **Children** shape itself, and not on the child templates, only one filter can be specified for all child shapes.

  - Using placeholders such as "\[var:\]" and "\[param:\]" within **ChildrenFilter** shape data is supported from DataMiner 9.6.4 onwards. This can for instance be used to filter the child shapes using a session variable in the filter value.

- **Options**:

  When shapes are dynamically generated in an EPM environment, a subscription filter is automatically added to the table, which depends on the current selection of the EPM environment. From DataMiner 9.5.1 onwards, it is possible to disable this automatic filter, so that not only the shapes matching the current selection are generated. To disable the automatic filter, in the **Options** shape data field, specify "NoSelectionFilters". For example:

  | Shape data field | Value              |
  | ---------------- | ------------------ |
  | Children         | Row                |
  | ChildrenSource   | \*/1600            |
  | Options          | NoSelectionFilters |

## Displaying information from the data table in case it links to DataMiner elements

When you use dynamic shape positioning based on a table containing rows linked to DataMiner elements, by default all subshapes will be linked to the element IDs retrieved from the table. As a result, those subshapes will only be able to display information from the element to which they are linked.

If you do not want this default behavior, you can instead have the subshapes display information from specific columns in the table. To do so, use a double asterisk in the subshape's **Element** data field.

For example, if you specify the following shape data in the main shape and the subshape, then the subshape will display the contents of a specific row in column 118 of the data table.

| Shape      | Shape data field | Value                     |
| ---------- | ---------------- | ------------------------- |
| Main shape | Element          | \*                        |
| Subshape   | Element          | \*\*                      |
| Subshape   | Parameter        | 118,\[displayTableIndex\] |

> [!NOTE]
>
> - You can also use the double asterisk inside a \[Param:...\] placeholder. Example: Parameter=65022,\[Param:\*\*,118,\[displaytableindex\]\]
> - You can use the \[displaytableIndex\] and \[tableIndex\] placeholders to link to the original row key (see the example above).
> - The parameter and table index can either be separated by a comma, as illustrated above, or by a colon. The first separator that is found will be used to separate the parameter from the index, and any other separators will be considered part of the index.
> - With older versions of DataMiner, if the value of the cell you link to is empty, the display key will be shown instead. From DataMiner 9.0.0 CU15/DataMiner 9.5.3 onwards, in that case no value will be shown. However, to have the display key shown instead, you can specify the keyword "\[DisplayTableIndexValue\]" in the **Parameter** shape data field.

## Making a shape use a different index than that of the original row

Normally, when shapes are created dynamically based on rows in a table, the index used in those dynamically created shapes and subshapes will be the index of the original row. To make a shape use a different index, add the following two shape data fields:

- A shape data field of type **Options**, containing the option "AllowCustomIndex".
- A shape data field of type **Parameter**, containing the index that has to override the default rowindex.

| Shape data field | Value            |
| ---------------- | ---------------- |
| Options          | AllowCustomIndex |
| Parameter        | *customIndex*    |

> [!NOTE]
> If the "AllowCustomIndex" option is used, you can use the placeholders \[ParentTableIndex\] and \[ParentDisplayTableIndex\] to refer to the index and display index of the table row associated with the immediate parent shape.
