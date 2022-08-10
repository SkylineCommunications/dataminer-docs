---
uid: Triggering_an_action_when_a_shape_is_dragged_onto_another_shape
---

# Triggering an action when a shape is dragged onto another shape

A shape can be set to perform a particular action when another shape is dropped onto it.

This "drop" behavior will often be implemented to visualize element properties or to pass parameters like element or service names to Automation scripts.

> [!NOTE]
>
> - This feature can only be used with shapes linked to elements, redundancy groups, services and views.
> - For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[data > DRAG AND DROP]* page.

> [!TIP]
> See also: [Triggering an action when the mouse pointer hovers over a shape](xref:Triggering_an_action_when_the_mouse_pointer_hovers_over_a_shape)

## Configuring the shape data field of the target shape

Add the following shape data fields to the shape:

- Depending on the purpose of the target shape:

  - A field of type **Element** or **View**, of which you leave the value empty.

    See [Example of a 'drop target' that visualizes the element name](#example-of-a-drop-target-that-visualizes-the-element-name).

  - A field of type **Execute**.

    See [Example of a 'drop target' that executes an Automation script](#example-of-a-drop-target-that-executes-an-automation-script).

  - A field of type **Parameter**.

    See [Example of a drag-and-drop action that passes on a table filter](#example-of-a-drag-and-drop-action-that-passes-on-a-table-filter).

  - A field of type **ParameterControl**.

    See [Turning a shape into a parameter control](xref:Turning_a_shape_into_a_parameter_control).

- A field of type **DropTarget**, with the value set to "TRUE".

- A field of type **Options**, with the following possible values:

  | Value      | Description                                                     |
  | ---------- | --------------------------------------------------------------- |
  | NoDragText | Ensures that no text message appears during the drag operation. |
  | DropOnly   | Ensures that the target shape is not clickable                  |

  > [!NOTE]
  > The "DropOnly" option can be combined with the "Selectable" option. See [Making shapes selectable](xref:Making_shapes_selectable).

## Example of a 'drop target' that visualizes the element name

First, we turn a shape into a "drop target" (i.e. a shape onto which we will drop other shapes) by adding to it the following shape data fields:

- **DropTarget**: TRUE
- **Element**: \<empty>
- **Info**: ELEMENT NAME

> [!NOTE]
> Do not forget to enter an asterisk ("\*") in the shape text.

Then, we make sure that the shapes we intend to drop onto the "drop target" contain valid shape data. In this example, all shapes to be dropped should contain a valid element ID:

- Element: DmaID/ElementID

  Example: `111/313`

When we now drop a shape with a valid element ID onto our newly created "drop target", the text inside the "drop target" will display the name of the element referred to by the element ID specified in the shape data of the shape we dropped onto the "drop target".

## Example of a 'drop target' that executes an Automation script

First, we turn a shape into a "drop target" (i.e. a shape onto which we will drop other shapes) by adding the following shape data fields to it:

- **DropTarget**: TRUE
- **Execute**: Script:...

  Example: `Script:SendServiceReport||||Send Service report|NoConfirmation`

  > [!NOTE]
  > Make sure a service ID is passed to the Automation script specified in the shape data field of type **Execute**.

Then, we make sure that the shapes we intend to drop onto the "drop target" contain valid shape data. In this example, all shapes to be dropped should contain a valid service ID:

- **Element**: DmaID/ServiceID

  Example: `111/312`

When we now drop a shape with a valid service ID onto our newly created "drop target", the service ID specified in the shape data of the shape we dropped onto the "drop target" will be passed to the Automation script, which will then be executed.

## Example of a drag-and-drop action that passes on a table filter

Create the following four shapes:

- Shape1 (source shape, i.e. shape that will be dropped onto shape3 or shape4)

  | Shape data field | Value           |
  | ---------------- | --------------- |
  | Element          | DmaID/ElementID |
  | Parameter        | pidPrimKey:\* 1 |

- Shape2 (source shape, i.e. shape that will be dropped onto shape3 or shape4)

  | Shape data field | Value           |
  | ---------------- | --------------- |
  | Element          | DmaID/ElementID |
  | Parameter        | pidPrimKey:\* 2 |

- Shape3 (target shape, i.e. shape onto which shape1 or shape2 will be dropped)

  | Shape data field | Value                         |
  | ---------------- | ----------------------------- |
  | Element          | DmaID/ElementID               |
  | Parameter        | ColumnID:\[tableindexFilter\] |
  | DropTarget       | True                          |

- Shape4 (target shape, i.e. shape onto which shape1 or shape2 will be dropped)

  | Shape data field | Value                         |
  | ---------------- | ----------------------------- |
  | Element          |                               |
  | Parameter        | ColumnID:\[tableindexFilter\] |
  | DropTarget       | True                          |

Result:

- When you drop shape1 or shape2 onto shape3, Shape3 will take the table filter.
- When you drop shape1 or shape2 onto shape4, Shape4 will take the table filter and the element.

> [!NOTE]
> From DataMiner 9.0 onwards, \[TableIndexFilter\] placeholders can be combined with dynamic placeholders like \[Param:...\], \[Var:...\], etc. in shape data that support this (Parameter, ParameterControl, ParameterControlOptions and Execute). However, note that they cannot be used recursively.

## Configuring drag-and-drop behavior for child shapes

When child shapes have been generated for every row in a table, it is also possible to drag and drop one child shape onto another.

To do so:

1. Create a target shape linked to an Automation script or parameter, or a shape turned into a parameter control.

   > [!TIP]
   > See also:
   >
   > - [Linking a shape to an Automation script](xref:Linking_a_shape_to_an_Automation_script)
   > - [Linking a shape to an element parameter](xref:Linking_a_shape_to_an_element_parameter)
   > - [Turning a shape into a parameter control](xref:Turning_a_shape_into_a_parameter_control)

1. Add a shape data field of type **DropTarget**, and set its value to "TRUE".

1. Make sure one of the following placeholders is used in the shape:

   | Placeholder                   | value                                                        |
   | ----------------------------- | ------------------------------------------------------------ |
   | \[TableIndexFilterResolved\]  | The primary key of the row represented by the dragged shape. |
   | \[TableDisplayIndexResolved\] | The display key of the row represented by the dragged shape. |

> [!NOTE]
> From DataMiner 9.0 onwards, \[TableIndexFilterResolved\] and \[TableDisplayIndexResolved\] placeholders can be combined with dynamic placeholders like \[Param:...\], \[Var:...\], etc. in shape data that support this (Parameter, ParameterControl, ParameterControlOptions and Execute). However, note that they cannot be used recursively.
