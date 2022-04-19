---
uid: Linking_a_shape_to_the_alarm_state_of_a_Data_Display_page
---

# Linking a shape to the alarm state of a Data Display page

If you have linked a shape to an element, that shape can be set to indicate the current alarm state of a particular Data Display page of that element.

> [!NOTE]
>
> - For an example of use, refer to the view "Linking Shapes" on the [Ziine Demo System](xref:ZiineDemoSystem). The example can be found on the Visual page _linking > ALARM_.

## Configuring the shape data field

Add a shape data field of type **DataDisplayPage** to the shape, and set its value to the name of a Data Display page.

For example, if you specify the following shape data, the shape will have the color of the current alarm state of the “Audio” page of the element named “IRD 01”.

| Shape data field | Value  |
| ---------------- | ------ |
| Element          | IRD 01 |
| DataDisplayPage  | Audio  |
