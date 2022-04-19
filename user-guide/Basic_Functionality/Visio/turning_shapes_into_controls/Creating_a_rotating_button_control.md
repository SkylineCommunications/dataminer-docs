---
uid: Creating_a_rotating_button_control
---

# Creating a rotating button control

In a Visio file, you can draw a rotating button that visualizes and controls a certain parameter.

To create a rotating button (e.g. a volume control), create a circular shape, and link it to the element containing the parameter you want to control, and to the parameter itself.

In the shape data item of type **Parameter**, specify the “Rotate” action, and set it to “_Range_”. Also specify the angle range within which the button can be rotated.

#### Example:

Add the following shape data fields to the shape:

- a shape data field of type **Element**, set to _219/50537_

- a shape data field of type **Parameter**, set to _Parameter 1\|ROTATE;range,30-330_

- a shape data field of type **Enabled**, set to _false_

> [!NOTE]
>
> - For an example of use, refer to the view "Linking Shapes" on the [Ziine Demo System](xref:ZiineDemoSystem). The example can be found on the Visual page _controls > CUSTOM_.
