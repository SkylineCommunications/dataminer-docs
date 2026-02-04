---
uid: Creating_a_range_slider_control
---

# Creating a range slider control

In a Visio file, you can draw a range slider that visualizes and controls a certain parameter.

To create a slider, create two shapes and group them:

- The main shape, representing the scale, has to be disabled and linked to the element containing the parameter you want to control.
- The subshape, representing the thumb, has to be linked to the parameter. In that subshape, you also have to specify a *TranslateX* or *TranslateY* action and set it to "Range".

Example:

To the main shape, add the following shape data fields:

- a shape data field of type **Element** set to "219/1"
- a shape data field of type **Enabled** set to "false"

To the subshape, add a shape data field of type **Parameter** set to "1\|TranslateY;RANGE"

> [!TIP]
> For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[controls > CUSTOM]* page.
