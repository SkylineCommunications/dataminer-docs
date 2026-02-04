---
uid: Working_with_shape_data_in_Microsoft_Visio
description: In Microsoft Visio, use the Shape Data pane to add data fields to pages, shapes, or groups of shapes to enrich drawings with DataMiner functionality.
---

# Working with shape data in Microsoft Visio

Microsoft Visio drawings can be enriched with DataMiner functionality using special shape data fields.

Shape data are sets of user-defined fields that hold data. They can be added to pages, shapes, and even groups of shapes.

> [!TIP]
> Do you prefer a hands-on approach? Try our tutorial on [Getting started with basic shapes](xref:Getting_started_with_basic_shapes).

## Opening the Shape Data pane

The *Shape Data* pane lists all shape data linked to the item you selected.

To open this pane:

- On the *View* tab, in the *Show* group, click *Task Panes*, and then click *Shape Data*.

> [!NOTE]
> The title of the *Shape Data* pane contains the name of the currently selected item. If you select a shape, the title will be e.g. "Shape Data - Sheet.27". If you select a page (by clicking anywhere on that page), the title will be "Shape Data - ThePage".

## Adding a data field to a page, a shape or a group of shapes

1. Select the page, the shape or the group of shapes to which you want to add data.

   For more information on how to group shapes, see [Grouping shapes](xref:Grouping_shapes).

1. Right-click in the *Shape Data* pane, and click *Define Shape Data*.

1. In the *Define Shape Data* dialog box, click *New*, and then do the following:

   1. In the *Label* box, enter the name of the data field. Example: *Element*, *Execute*, *Link*, etc.

      For a complete overview of all DataMiner shape data fields, see [Overview of DataMiner shape data fields](xref:Overview_of_DataMiner_shape_data_fields).

   1. In the *Type* list, select "String".

   1. In the *Value* box, enter the value. Example: *112/1457*, *MyElement*, *Script:MyScript*, *#http://www.skyline.be*, etc.

   > [!NOTE]
   > When you open the *Define Shape Data* dialog box, you might notice a data item named "Property1". Instead of creating a new data item, you can also rename that "Property1" item that Visio has created for you.

1. Click OK.

## Using DataMiner features in Visio

An add-in is available in Visio that allows you to manage DataMiner-related data more easily. In addition, you can also access DataMiner stencils, allowing you to speed up the design of visually appealing Visio drawings.

> [!NOTE]
> Depending on the configuration of the general user settings, this add-in may be unavailable. See [Enabling or disabling the advanced editing Visio add-in](xref:ClientSettings_json#enabling-or-disabling-the-advanced-editing-visio-add-in).

### Accessing the DataMiner stencils

DataMiner stencils are preconfigured shapes or groups of shapes that match the DataMiner house style. They use macros that automatically fill in the necessary shape data when you add shapes to a drawing. This way, only minimal information still needs to be filled in to get the shapes ready for use.

To use the DataMiner stencils in Visio:

1. In the *Shapes* pane, go to *More Shapes* > *DataMiner*.

1. Select the group of stencils you want to use.

   Currently, the following groups of stencils are available:

   - *Buttons*: Contains various kinds of buttons, including action buttons, page buttons and toggle buttons.

   - *Icons*: Contains a collection of general and DataMiner-specific icons, such as a satellite, antenna, filter, redundancy group, ticket, etc.

   - *KPI*: Contains stencils that can be used to display information on one or more parameters. There are also blocks available with preconfigured connection points, so that you can easily show the logical connections between parameters.

1. Drag the stencils you want to use from the *Shapes* pane to the drawing.

> [!NOTE]
> To use the stencils in Visio, Automation events need to be enabled in the Visio options (Under *Visio Options* > *Advanced* > *General*).

### Accessing the 'Advanced editing' add-in

1. Open a Visio drawing by right-clicking a Visio drawing in DataMiner Cube and selecting *Edit in Visio*.

1. Go to the *Add-ins* menu in Visio and click *Advanced editing*.

   The *Advanced editing* panel will be opened. This panel will remain available until you close the Visio application.

### Using the 'Advanced editing' panel

The panel can be used as follows:

- To view a list of the page data items currently linked to the page, click anywhere on the page background.

- To view a list of the shape data items currently linked to a shape, select that shape.

- To remove a data item from either the page or a selected shape, click the x to the right of the item in the relevant page or shape data list.

- To add a data item to the page:

  1. Click the page background, so that no shapes are selected.

  1. In the *Advanced editing* panel, click *Add page data*.

  1. Select a data item in the dropdown list.

  1. In the value box next to the data item, specify the value.

- To add a data item to a shape:

  1. Select the shape.

  1. In the *Advanced editing* panel, click *Add shape data*.

  1. Select a data item in the dropdown list.

  1. In the value box next to the data item, specify the value.

- To change the value of an existing data item, simply specify the new value in the value box.

  > [!NOTE]
  > To add a placeholder (i.e. a dynamic part) in a value, add a square bracket ("\["), select the placeholder from the list, and press TAB.

- To change one of the data items to a different data item, in the data box, specify a different item. If you specify a data item that is unknown to DataMiner or that is already in the list, it will be highlighted.

- From DataMiner 10.2.5/10.3.0, the following special options are available via the "..." button in the top-right corner of the *Advanced Editing* panel:

  - *Add theming*: Adds the following theme options to the page-level *Options* data field: `#000000=ThemeForeground|#FF0000=ThemeAccentColor|#FFFFFF=ThemeBackground`. If no page-level *Options* data field exists yet, it will be created. For more information, see [#RRGGBB=ThemeForeground\|#RRGGBB=ThemeAccentColor\|#RRGGBB=ThemeBackground](xref:Overview_of_page_and_shape_options#rrggbbthemeforegroundrrggbbthemeaccentcolorrrggbbthemebackground).

  - *Add pretty hover*: Adds the `HoverType=Geometry` option to the page-level *Options* data field. If no page-level *Options* data field exists yet, it will be created. For more information, see [HoverType=Geometry](xref:Overview_of_page_and_shape_options#hovertypegeometry).
