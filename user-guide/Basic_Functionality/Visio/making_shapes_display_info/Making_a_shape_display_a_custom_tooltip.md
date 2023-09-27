---
uid: Making_a_shape_display_a_custom_tooltip
---

# Making a shape display a custom tooltip

Using a shape data field of type **Info**, you can add custom tooltips to shapes. Alternatively, you can also use a shape data field of type **Tooltip** in order to display information about the item to which a shape is linked.

> [!TIP]
>
> - For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[data > OTHER]* page.
> - See also: [Visio – Adding a tooltip on a view object](https://community.dataminer.services/video/visio-adding-a-tooltip-on-a-view-object/) ![Video](~/user-guide/images/video_Duo.png)

## Configuring the shape data field

Add a shape data field of type **Info** to the shape, and set its value to the text that has to appear in the tooltip when users hover over the shape.

> [!NOTE]
> Make sure the value you enter is not one of the reserved keywords listed in [Making a shape display information about the item it is linked to](xref:Making_a_shape_display_information_about_the_item_it_is_linked_to).

Alternatively, or in addition to the **Info** shape data field, you can also add a shape data field of type **Tooltip** and set its value to the text that has to appear in the tooltip.

If an **Info** shape data field is used as well, the **Tooltip** shape data field will always override it. You can make the **Tooltip** shape data field refer to any attribute used in the **Info** shape data field by placing it in square brackets.

For example, to create a tooltip that contains some text and mentions the name of the element to which a shape is linked, you can configure the following shape data:

| Shape data field | Value                         |
| ---------------- | ----------------------------- |
| Element          | The element name              |
| Info             | *Name*                        |
| Tooltip          | *Linked to element: \[Name\]* |
