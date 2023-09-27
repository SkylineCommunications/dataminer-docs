---
uid: Enabling_grouping_of_dynamically_positioned_shapes
---

# Enabling grouping of dynamically positioned shapes

To get a cleaner look for Visual Overviews containing many dynamically positioned shapes that are very close together, you can enable shape grouping. This way, dynamically positioned shapes that overlap will be grouped.

> [!NOTE]
> For dynamically positioned shapes based on tables, grouping is possible from DataMiner 9.5.1 onwards. For dynamically positioned shapes based on properties, grouping is possible from DataMiner 9.5.3 onwards.

To enable grouping of dynamically positioned shapes, add a shape with shape data *ShapeGrouping* to the Visual Overview and set its value to “All”.

| Shape data field | Value |
|------------------|-------|
| ShapeGrouping    | All   |

The size and geometry of the group shapes will be the same as that of the shape to which the *ShapeGrouping* shape data was added. The context menu of the grouping shape will contain all options of the underlying shapes.

> [!NOTE]
>
> - To display the number of shapes that are grouped into a single group shape, add an asterisk (“\*”) in the *ShapeGrouping* shape.
> - From DataMiner 10.3.1/10.4.0 onwards, to display the number of children in a group of dynamically positioned shapes, add "[Count]" in the *ShapeGrouping* shape. Alternatively, to display the parameter value of the shape data *GroupBy* of the first child of the group, add "[GroupValue]" in the *ShapeGrouping* shape. If the *GroupBy* value has multiple column parameters or properties, these will be separated by commas. You can also use the "[GroupValue]" and "[Count]" placeholders together to create more complex labels, e.g. `[GroupValue]([Count])`, which might result in "MyFirstChildGroupValue (5)".
> - From DataMiner 9.5.2 onwards, clicking the grouped shape will open a details pane with more information on the different shapes it combines.
> - Displaying DCF connections between grouped shapes is possible from DataMiner 9.5.3 onwards. In that case, when an element is represented by a group shape, all connections to that element will be drawn to the group shape.

## Optional grouping configuration

The following optional shape data can be added to the *ShapeGrouping* shape to further fine-tune shape grouping for shapes that are positioned based on a table:

- **GroupBy**

  This shape data can be used to group overlapping shapes based on table parameter values or property values.

  - To group overlapping shapes if they represent values identical to those of one or more particular table parameters, add this shape data and specify one or more column IDs in the value: *Column=*\[columnID\]*,*\[columnID\]*,*etc.

    The specified column IDs represent the table parameters that must have identical values for the shapes to be grouped.

    For example, if you specify the following, shapes will only be grouped if the values in the columns with PID 101, 102 and 103 are the same:

    | Shape data field | Value              |
    |------------------|--------------------|
    | GroupBy          | Column=101,102,103 |

  - To group overlapping shapes based on the value of a particular property, add this shape data and specify *Property=*, followed by the property name:

    | Shape data field | Value                 |
    |------------------|-----------------------|
    | GroupBy          | Property=*MyProperty* |

    To specify multiple properties, use a comma as separator. For example:

    ```txt
    Property=MyFirstProperty,MySecondProperty
    ```

- **OrderBy**

  Add this shape data to define the order in which shapes are grouped. Specify one or more column IDs in the value: *Column=*\[columnID\]*,*\[columnID\]*,*etc.

  These column IDs will determine the order in which the shapes are grouped. For example, if you specify the following, the shapes will be grouped according to the order specified in parameter 103:

  | Shape data field | Value      |
  |------------------|------------|
  | OrderBy          | Column=103 |

  If this shape data is not specified, the primary key column determines the order of the grouping. If two of the values of an *Orderby* column are the same, shapes corresponding to these values can be grouped in either order.

## Configuration of the connection drop-down menu

When table connections are used, multiple table connections for shapes that are grouped together will also be grouped together into a single connection. Clicking on a grouped connection will open the details pane of that connection. This details pane will display a drop-down menu where you can select the connection for which details need to be displayed.

You can customize the format of the items in the drop-down menu by adding an *Options* shape data field to the connection shape and specifying the value "*ConnectionSelectionFormat=\[Custom text containing a row value\]*".

For example:

| Shape data field | Value                                                                                    |
|------------------|------------------------------------------------------------------------------------------|
| GroupBy          | ConnectionSelectionFormat=Circuit: \[pid:8302\] (\[pid:8311\]-\[pid:8312\]-\[pid:8313\]) |
