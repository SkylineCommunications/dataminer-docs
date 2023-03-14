---
uid: Enabling_dynamic_zoom_on_dynamically_positioned_shapes
---

# Enabling dynamic zoom on dynamically positioned shapes

From DataMiner 9.5.1 onwards, dynamic zooming can be configured when shapes are positioned dynamically. When dynamic zooming is enabled, shapes will not change in size when you zoom in, but will instead be repositioned. Shapes will move away from each other when you zoom in and will move closer together when you zoom out.

Dynamic zooming is especially interesting for Visual Overviews where dynamically positioned shapes are very close to each other, as zooming in will provide a better overview of all shapes in a certain area.

To enable dynamic zooming on a page, add the following shape data to the page:

| Shape data field | Value       |
|------------------|-------------|
| Options          | DynamicZoom |

> [!NOTE]
>
> - When used in combination with grouping overlapping dynamically positioned shapes, several overlapping shapes that were grouped into one shape will be split into separate shapes when you zoom in. See [Enabling grouping of dynamically positioned shapes](xref:Enabling_grouping_of_dynamically_positioned_shapes).
> - When you use dynamic zooming, shapes will always be displayed using a scale of 100%.
> - Prior to DataMiner 10.3.4/10.4.0, only individual shapes can be rearranged when you use dynamic zooming. From those DataMiner versions onwards, grouped shapes can be rearranged as well. <!-- RN 35323 -->

## Disabling rescaling of a particular shape

By default, when dynamic zoom is enabled, shapes that are not linked to DataMiner objects are automatically rescaled when you zoom in or out.

From DataMiner 9.5.4 onwards, it is possible to disable the rescaling of a shape when dynamic zooming is used. To do so, add the *PageScale* option to that shape.

| Shape data | Value     |
|------------|-----------|
| Options    | PageScale |

> [!NOTE]
> This option does not work for shapes on Visio background pages.
