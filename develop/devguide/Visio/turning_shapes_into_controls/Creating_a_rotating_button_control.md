---
uid: Creating_a_rotating_button_control
---

# Creating a rotating button control

In a Visio file, you can draw a rotating button that visualizes and controls a certain parameter.

To create a rotating button (e.g. a volume control), create a circular shape, and link it to the element containing the parameter you want to control, and to the parameter itself.

In the shape data item of type **Parameter**, specify the *Rotate* action, and set it to "Range". Also specify the angle range within which the button can be rotated.

Example:

Add the following shape data fields to the shape:

- a shape data field of type **Element**, set to "219/50537"
- a shape data field of type **Parameter**, set to "Parameter 1\|ROTATE;range,30-330"
- a shape data field of type **Enabled**, set to "false"

> [!NOTE]
> For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[controls > CUSTOM]* page.
