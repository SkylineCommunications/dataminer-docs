---
uid: Docking_a_shape_to_one_or_more_borders_of_a_Visio_drawing
---

# Docking a shape to one or more borders of a Visio drawing

A shape can be docked to one or more borders of a Visio drawing. This is only possible for shapes that act as controls (e.g. web browser controls, parameter controls, child item containers, SetVar controls, command buttons, etc.).

> [!NOTE]
>
> - Docked shapes are resized relative to the size (aspect ratio) of the drawing.
> - For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[positioning > DOCKING]* page.

## Configuring the shape data field

To dock a shape, add a shape data field to it of type **Dock**, and set its value to one or more of the following options, separated by means of pipe characters ("\|").

- Left
- Top
- Right
- Bottom

## Example

```txt
Left|Top
```

The shape will be docked to both the left and top border of the Visio drawing.
