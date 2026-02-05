---
uid: Grouping_shapes
---

# Grouping shapes

If, in a Visio drawing, you have to link more than one shape to the same element, view or service, then first group those shapes, and then specify shape data of type **Element**, **View** or **Service** on group level. This will considerably enhance performance.

> [!TIP]
> For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view.

## Example of grouping shapes

Suppose that you want to draw a square that has to display the alarm color of the element to which it is linked, and that the name of that element has to be displayed to the right of that square.

1. Draw the square.

1. To the right of the square, draw a text box.

   - Inside the text box, enter "\*".
   - Add a shape data field of type **Info** to the text box, and set its value to "ELEMENT NAME".

1. Group the square and the text box.

1. Add a shape data field of type **Element** to the group, and set its value to the ID (or the name) of the element.

Result: When the Visio drawing is displayed, the square will show the alarm color of the associated element, and the name of that element will be displayed in the text box on the right.

## Making subshapes execute parameter sets or Automation scripts on the element linked to the parent shape

Within a group, you can configure a subshape to execute a script or parameter set on the element that is linked to the entire group.

To do so, in the subshape in question, replace the element reference in the *Execute* command by an asterisk ("\*").

In addition, to execute a script, add the **Enabled** shape data field to both the group shape and the subshape, setting it to "false" for the group shape, and to "true" for the subshape. Also add the **Options** shape data field to the subshape, and set it to "NoCopyElementProperty".

For example:

- Group shape data:

  | Shape data field | Value     |
  | ---------------- | --------- |
  | Element          | MyElement |
  | Enabled          | false     |

- Subshape shape data:

  | Shape data field | Value                             |
  | ---------------- | --------------------------------- |
  | Execute          | Script:MyExampleScript\|dummy1=\* |
  | Options          | NoCopyElementProperty             |
  | Enabled          | true                              |

When there are multiple grouping levels, the element will be determined bottom-up. Starting from the subshape, the parent shapes are checked one by one in search of a valid element ID. If you want a parent shape linked to an element ID to be ignored, add a shape data field to it of type **Options**, and set its value to "SkipAsHost".

> [!TIP]
> See also:
>
> - [Linking a shape to a SET command](xref:Linking_a_shape_to_a_SET_command)
> - [Linking a shape to an Automation script](xref:Linking_a_shape_to_an_Automation_script)

## Extending a container shape shortcut menu with child shape shortcut menu items

When working with shape groups, you can extend the shortcut menu of the container shape with shortcut menu items from its child shapes.

To do so, in a child shape of which the shortcut menu items have to be added to the shortcut menu of the container shape, add a shape data field of type **Options** and set its value to "PushContextMenu".
