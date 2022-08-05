---
uid: Turning_a_shape_into_a_tab_control_that_displays_pages_of_a_Visio_file
---

# Turning a shape into a tab control that displays pages of a Visio file

When a shape is linked to a view, a service or an element, it can be turned into a tab control that displays all pages or specific pages of the Visio drawing linked to that view, service or element.

> [!TIP]
>
> - See also: [Making a shape display a particular page of the current Visio drawing](xref:Making_a_shape_display_a_particular_page_of_the_current_Visio_drawing)
> - For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view.

## Configuring a tab control that displays all pages of a Visio drawing

Add a shape data field of type **Options** to the shape, and set its value to "InlineVdx".

If you want to apply the background of the shape to the tab control, add the option "ApplyShapeBackground".

```txt
InlineVdx|ApplyShapeBackground
```

Aside from the default style, from DataMiner 9.5.14 onwards, an alternative style is possible for tab controls. To configure this alternative style, add the option "TabControlStyle=2".

```txt
InlineVdx|TabControlStyle=2
```

## Configuring a tab control that displays specific pages of a Visio drawing

Create a shape, add a shape data field to it of type **VdxPage** of which the value contains the list of pages to be visualized (separated by pipe characters).

In the following example, the shape will contain a tab control with three tabs (showing Page1, Page2 and Page3):

```txt
Page1|Page2|Page3
```

You can also add one additional level of subtabs. In the following example, the shape will contain a tab control with two main tabs (showing Page1 and Page2), and the second main tab (showing Page2) will have three subtabs (showing SubA, SubB and SubC):

```txt
Page1|Page2//SubA|Page2//SubB|Pag2//Sub3
```

To fine-tune the way the tab control is displayed, a number of options can be used:

- Normally, the pages you specify in a tab control shape will also appear as pages of the main Visio file. If you do not want a page to appear as a page of the main Visio file, you can add a shape data item of type **Options** to that page, and set its value to "Hidden".

- If you want the tab control to inherit the background color from the shape that contains it, you can add a shape data item of type **Options** to the shape, and set its value to "ApplyShapeBackground".

- From DataMiner 9.6.4 onwards, an alternative style can be configured for the tab control. To configure this alternative style, add a shape data field of type **Options** and set its value to "TabControlStyle=2".

  For example:

  | Shape data field | Value                     |
  | ---------------- | ------------------------- |
  | VdxPage          | First-Page\|\|Second-Page |
  | Options          | TabControlStyle=2         |
