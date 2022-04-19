---
uid: Creating_a_range_slider_control
---

# Creating a range slider control

In a Visio file, you can draw a range slider that visualizes and controls a certain parameter.

To create a slider, create two shapes and group them:

- The main shape, representing the scale, has to be disabled and linked to the element containing the parameter you want to control.

- The subshape, representing the thumb, has to be linked to the parameter. In that subshape, you also have to specify a “TranslateX” or “TranslateY” action and set it to “_Range_”.

Example:

To the main shape, add the following shape data fields:

- a shape data field of type **Element** set to _219/1_

- a shape data field of type **Enabled** set to _false_

To the subshape, add a shape data field of type **Parameter** set to _1\|TranslateY;RANGE_

> [!NOTE]
>
> - For an example of use, refer to the view "Linking Shapes" on the [Ziine Demo System](xref:ZiineDemoSystem). The example can be found on the Visual page _controls > CUSTOM_.
