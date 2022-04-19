---
uid: Turning_a_shape_into_a_parameter_control
---

# Turning a shape into a parameter control

Using a shape data field of type **ParameterControl**, you can turn a shape into a parameter control.

> [!TIP]
> See also:
> [Adding options to a parameter control](xref:Adding_options_to_a_parameter_control)

> [!NOTE]
>
> - This feature only works in DataMiner Cube.
> - Parameter controls are updated in real time.
> - For an example of use, refer to the view "Linking Shapes" on the [Ziine Demo System](xref:ZiineDemoSystem). The example can be found on the Visual page _controls > PARAM_.

## Configuring the shape data field

Add a shape data field of type **ParameterControl** to the shape.

- In case of a simple parameter, set the value of the shape data field to:

  ```txt
  ParameterID
  ```

  > [!NOTE]
  > A parameter of which the measurement type setting is “progress” will automatically be displayed as a progress bar.

- In case of a table parameter, set the value of the shape data field to:

  ```txt
  ParameterID:TableRowKey
  ```

  > [!NOTE]
  > If you plan to show an entire table or a partial table in Visio, make sure that table is not a hidden table. Hidden tables are tables that are not shown on the Cube card of the element or service they belong to.

  See below for more information on table row key syntax.

> [!NOTE]
> When specifying a value, you can use placeholders. See [Placeholders for variables in shape data values](xref:Placeholders_for_variables_in_shape_data_values)

## Adding a filter box to a table control

When using a shape of type **ParameterControls** to visualize a table in a Visio drawing, you can add a table filter to that shape.

1. Create two shapes and group them. One shape will contain the table and the other shape will contain the filter box.

2. Add the following shape data field to the shape that has to contain the table:

   | Shape data field        | Value |
   | ----------------------- | ----- |
   | ParameterControlOptions | Table |

3. Add the following shape data field to the shape that has to contain the filter box:

   | Shape data field        | Value  |
   | ----------------------- | ------ |
   | ParameterControlOptions | Filter |

4. Add the following shape data fields to the group:

   | Shape data field        | Value                                                                                                           |
   | ----------------------- | --------------------------------------------------------------------------------------------------------------- |
   | Element                 | Element ID or element name.                                                                                     |
   | ParameterControl        | ID of the table parameter.                                                                                      |
   | ParameterControlOptions | “CustomTextBoxInfo:”, followed by the text that has to appear inside the filter box (e.g. “Enter filter here”). |

## Table row key syntax

You can refer to table cells in the following ways.

| Syntax        | Description                                                                                    |
| ------------- | ---------------------------------------------------------------------------------------------- |
| Pid:abc       | Link the shape to the cell with display key “abc”.                                             |
| Pid:abc\*     | Link the shape to the last updated cell of which the display key matches the wildcard “abc\*”. |
| Pid:^pk^abc   | Link the shape to the cell with primary key “abc”.                                             |
| Pid:^pk^abc\* | Link the shape to the last updated cell of which the primary key matches the wildcard “abc\*”. |

## Dynamically disabling a parameter control

You can dynamically disable parameter controls by configuring a conditional shape manipulation action of the type “Enabled”. See [Extended conditional shape manipulation actions](xref:Extended_conditional_shape_manipulation_actions).

However, to fully disable a control, so that it cannot set session variables, navigate to other pages, or allow path highlighting, you must also add a shape data field of type **Options**, and set the value to “_AllowControlDisable_”.

> [!NOTE]
> In some element protocols, editing of some table cells may be dynamically disabled, based on the value of another cell. In that case, unless a different “Enabled” condition has been configured, a Visio shape that has been turned into a parameter control takes into account this “disableWrite” setting. However, even in this case it is still necessary to use the “AllowControlDisable” option to fully disable the control.

## Allowing dynamic shape behavior

Up to DataMiner 9.0.0 CU5, **ParameterControl** shapes with dynamic value placeholders only turn into a parameter control when all placeholders can be resolved. Otherwise an element shape is displayed.

From DataMiner 9.0.0 CU5 onwards, **ParameterControl** shapes are by default always displayed as a parameter control. However, it is still possible to activate the legacy behavior, by adding the following option to the shape:

| Shape data field | Value                                  |
| ---------------- | -------------------------------------- |
| Options          | AllowDynamicShapeType=ParameterControl |
