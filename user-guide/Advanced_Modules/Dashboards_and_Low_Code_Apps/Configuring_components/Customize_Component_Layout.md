---
uid: Customize_Component_Layout
---

# Customizing the component layout

Each component in a dashboard or low-code app has a number of default options. By default, the configuration of these options is determined by the layout of the [dashboard](xref:Configuring_the_dashboard_layout) or [low-code app](xref:LowCodeApps_Layout) on the whole. However, it is possible to override this. The way this can be done depends on the DataMiner version.

## [From DataMiner 10.0.8 onwards](#tab/tabid-1)

1. Select the component and go to the ***Layout*** tab on the right.

1. In the ***Styles*** section, you can then change the component theme in different ways:

   - To **change the component theme** to one of the different existing component themes for your current dashboard or low-code app theme, click the current theme and select a different theme in the drop-down list.

   - To **customize the component theme**, enable the *Customize* toggle button to customize the currently selected theme.

     - In the *Title* section, specify the following:

       - *Font*: Select a font type in the drop-down list

       - *Font size*: The size (in pixels) of the title

       - *Alignment*: Left, center, right, or justify

       You can also further customize your title with *Bold*, *Italics*, and *Underline*.

     - In the *Colors* section, specify a custom background color and/or font color, either by specifying the color in RGB format or by using the color picker box on the right.

       From DataMiner 10.0.12 onwards, under *Colors* > *Color palette*, you can customize additional component colors, e.g. for the lines in a line chart.

     - In the *Spacing* section, specify the following:

       - *Vertical margin*: The amount of space (in pixels) above the component.

       - *Horizontal margin*: The amount of space (in pixels) next to the component.

       - *Vertical padding*: The amount of space (in pixels) that should be left free at the top of the bottom inside the component.

       - *Horizontal padding*: The amount of space (in pixels) that should be left free on the left and right side of the component.

       > [!NOTE]
       > If a smaller value than the dashboard's or low code app's default value is configured for these settings, it will not be taken into account.

     - In the *Border* section, specify the following:

       - *Roundness*: The roundness (in pixels) of the border that should be displayed around the components.

       - *Style*:

         - No border

         - Line

         - Dashes

         - Dots

       - *Sides*: Select which sides of the component border should be shown (from DataMiner 10.0.9 onwards).

       - *Thickness*: The thickness (in pixels) of the border that should be displayed around the components.

       - *Color*: Specify a custom border color, either by specifying the color in RGB format or by using the color picker box on the right.

     - In the *Shadow* section, select the size of the shadow displayed behind the components.

     > [!NOTE]
     > When you have customized a component theme, you can also save it, so that it becomes available with the other component themes for the current dashboard or low-code app theme. To do so, click *Save as component theme* and specify the name of the theme. However, note that this is only possible if the dashboard or low-code app is currently using a saved theme. If it is not, you will first need to save the dashboard or low-code app theme before you can save the component theme.

## [Prior to DataMiner 10.0.8](#tab/tabid-2)

1. Select the component and go to the *Layout* tab on the right.

1. Clear the checkbox *Inherit from dashboard*.

1. Configure the following options in the expandable sections according to your preference:

    - In the *Title* section, select the alignment for the component title and specify whether a border should be displayed around the title.

    - In the *Colors* section specify a custom background color and/or font color, either by specifying the color in RGB format or by using the color picker box on the right.

    - In the *Container* section, specify the following:

        - *Vertical margin*: The amount of space (in pixels) above the component.

        - *Horizontal margin*: The amount of space (in pixels) next to the component.

        - *Vertical padding*: The amount of space (in pixels) that should be left free at the top of the bottom inside the component.

        - *Horizontal padding*: The amount of space (in pixels) that should be left free on the left and right side of the component.

        > [!NOTE]
        > If a smaller value than the dashboard's or low code app's default value is configured for these settings, it will not be taken into account.

    - In the *Borders* section, select the type of border that should be displayed around the components.

    - In the *Shadow* section, select the size of the shadow displayed behind the components.

Depending on the visualization, additional layout options may be available. For more information, refer to the relevant section in [Available visualizations](xref:Available_visualizations).

***

## Template Editor

> [!IMPORTANT]
> At present, the Template Editor is only available in preview, if the [ReportsAndDashboardsDynamicVisuals](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsdynamicvisuals) and [ReportsAndDashboardsScheduler](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsscheduler) soft-launch options are enabled. For more information, see [Soft-launch options](xref:SoftLaunchOptions).

Available from DataMiner 10.4.1/10.5.0. Currently only supported for specific components, such as the grid, timeline, and table component.

To access the Template Editor:

- For the grid and timeline components:

  1. Select the component and go to the *Layout* tab on the right.

  1. In the *Item templates* section, click *Edit*.

     > [!NOTE]
     > A preview of the template currently used for this component is displayed in the *Item templates* section.

- For the table component:

  1. Select the component and go to the *Layout* tab on the right.

  1. In the *Column appearance* section, click the downward arrow next to *Select a column* and select the column you want to create a template for.

  1. Click the ellipsis ("...") in the top-right corner and select *Customize preset*.

### Using the Template Editor

The Template Editor UI consists of the following main components:

- Side pane:

  - The *Layers* tab (1A)

  - The *Tools* tab (1B)

- Preview (2)

- Info pane (3)

![Template Editor](~/user-guide/images/Template_Editor.png)<br/>*The Template Editor in DataMiner 10.4.1*

#### Working with layers

In the side pane of the Template Editor, go to the *Layers* tab to access an overview of all layers. Layers are used in the Template Editor to make non-destructive edits by stacking icons, text, rectangles, and ellipses one on top of the other without compromising the pixels of individual elements.

The benefits of working with layers:

- Add elements on top of each other without removing data.

- You can apply filters to only one layer of the template. See [Changing layer settings](#changing-layer-settings).

- You can discard any unsatisfactory layers without affecting the entire template.

- You can mask layers so that they are temporarily hidden without having to delete them.

- ...

If one layer is positioned higher than another, the higher layer will appear in front of the lower one. To **change the order of layers**, click the ![*Drag-and-drop*](~/user-guide/images/drag-and-drop.png) button and drag the layer up or down in the *layers* panel. Release the mouse button when you reach the position where you want to place the selected layer.

To **mask a layer**, hover the mouse over the layer and click the *eye* icon in the lower right corner. The layer is now no longer visible in the end result. Clicking the *eye* icon also makes the layer visible again.

To **delete a layer**, hover the mouse over the layer and click the *delete* button in the top-right corner. Alternatively, select the associated element (i.e. icon, text, rectangle, or ellipse) in the preview and press the *Delete* button on your keyboard.

To **add a new layer**, [add a new element in the *Tools* tab](#adding-new-tools).

In the lower left corner of each layer, an icon indicates the type of layer: an *icon*, *text*, *rectangle*, or *ellipse* layer.

#### Adding new tools

In the *Tools* tab, you can add new layers to the template. Each tool you add to the template equals a new layer. You can add the following elements:

- icon

- text

- rectangle

- ellipse

![*Tools* tab](~/user-guide/images/Tools_Tab.png)<br/>*The Template Editor in DataMiner 10.4.1*

1. To add a new tool to the template, click the *Icon*, *Text*, *Rectangle*, or *Ellipse* button.

   When you move your cursor to the preview, the cursor turns into a crosshair.

1. In the preview, press and hold down the left mouse button to select the area you choose for the element to go. Dotted lines appear in a frame around the selected area. <!--You arrived here-->

#### Changing layer settings

In the *Info* pane on the right, ...

If no layers are selected, you can adjust the dimensions of the complete template.

If a layer is selected, you can adjust the dimensions, properties, and conditional cases tied to that layer.

<!--Add all dimensions icons as images in a table (similar to info pane Spectrum Analyzer)-->