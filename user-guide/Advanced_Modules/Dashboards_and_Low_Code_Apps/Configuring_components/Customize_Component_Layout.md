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

- *Settings* pane (3)

![Template Editor](~/user-guide/images/Template_Editor.png)<br/>*The Template Editor in DataMiner 10.4.1*

> [!IMPORTANT]
> Any changes made in the Template Editor are only saved once you click the *Save* button in the lower right corner. Closing the Template Editor by clicking the "X" in the top-right corner or the *Cancel* button in the lower right corner, will alert you of any unsaved changes that may be lost if you close the editor prematurely.

#### Working with layers

In the side pane of the Template Editor, the *Layers* tab offers an overview of all layers. Layers are used in the Template Editor to make non-destructive edits by stacking icons, text, rectangles, and ellipses one on top of the other without compromising the pixels of individual elements.

The benefits of working with layers:

- You can add elements on top of each other without removing data.

- You can apply conditions to only one layer of the template. See [Adding conditional cases to a layer](#adding-conditional-cases-to-a-layer).

- You can discard any unsatisfactory layers without affecting the entire template.

- You can mask layers so that they are temporarily hidden without the need to delete them.

- ...

If one layer is positioned higher than another, the higher layer will appear in front of the lower one. To **change the order of layers**, click the ![*Drag-and-drop*](~/user-guide/images/drag-and-drop.png) button and drag the layer up or down in the *Layers* tab. Release the mouse button when you reach the position where you want to place the selected layer.

![Change order layers](~/user-guide/images/Change_Order_Layers.gif)<br/>*The Template Editor in DataMiner 10.4.1*

To **mask a layer**, hover the mouse over the layer and click the *eye* icon in the lower right corner. The layer is now no longer visible in the template's end result. Clicking the *eye* icon once more makes the layer visible again. Alternatively, you can mask the layer by adjusting its properties in the *Settings* pane. See [Specifying layer properties](#specifying-layer-properties).

> [!NOTE]
> In cases where you have masked a layer in both the *Layer* tab and the layer properties, undoing the masking in only one of these locations will result in the layer remaining invisible. Ensure that you reverse the masking in both places to render the layer visible again.

To **delete a layer**, hover the mouse over the layer and click the *delete* button in the top-right corner. Alternatively, select the associated tool (i.e. icon, text, rectangle, or ellipse) in the preview and press the *Delete* button on your keyboard.

To **add a new layer**, [add a new tool](#adding-new-tools) in the *Tools* tab.

In the lower left corner of each layer, an icon denotes the layer type: an *icon*, *text*, *rectangle*, or *ellipse* layer.

#### Adding new tools

In the *Tools* tab, you can add new layers to the template. Each tool you add to the template equals a new layer. You can add the following tools:

- Icon

- Text

- Rectangle

- Ellipse

![*Tools* tab](~/user-guide/images/Tools_Tab.png)<br/>*The Template Editor in DataMiner 10.4.1*

1. To add a new tool to the template, click the *Icon*, *Text*, *Rectangle*, or *Ellipse* button.

   When you move your cursor to the preview, the cursor turns into a crosshair.

1. In the preview, press and hold down the left mouse button to select the designated area for your new tool. The tool appears, surrounded by dotted lines in a frame around the selected area. Release the mouse button once you are happy with the size and shape of the tool.

1. Optionally, you can resize the tool by dragging the frame edges or move the tool by dragging and dropping it with the left mouse button.

   > [!NOTE]
   > Alternatively, you can also adjust the size, shape, and position of the tool in the [*Dimensions* section](#specifying-layer-dimensions) of the *Settings* pane.

1. Optionally, you can add certain properties and/or conditional cases to the tool. See [Specifying layer properties](#specifying-layer-properties) and [Adding conditional cases to a layer](#adding-conditional-cases-to-a-layer).

#### Changing template settings

With the *Settings* pane to the right side of the preview, you can change the settings for the entire template and the different layers. The preview is then immediately updated according to the changes.

- To modify the **template settings**, make sure no layers are selected. In the *Settings* pane, you can specify a number of pixels to which the width and/or height of the template will be fixed.

- To modify the **layer settings**, make sure a layer is selected. In the *Settings* pane, you can adjust the following layer settings in three collapsible sections:

  - [Dimensions](#specifying-layer-dimensions)

  - [Properties](#specifying-layer-properties)

  - [Conditional cases](#adding-conditional-cases-to-a-layer)

##### Specifying layer dimensions

The table below describes the dimension settings available for template layers.

| Icon | Setting | Description |
|--|--|--|
| ![Width](~/user-guide/images/Dimensions_Width.png) | Width | Specify a number of pixels to which the width of the layer will be fixed. |
| ![Height](~/user-guide/images/Dimensions_Height.png) | Height | Specify a number of pixels to which the height of the layer will be fixed. |
| ![Top](~/user-guide/images/Dimensions_Top.png) | Top | Specify a number of pixels to which the top of the layer will be fixed. |
| ![Bottom](~/user-guide/images/Dimensions_Bottom.png) | Bottom | Specify a number of pixels to which the bottom of the layer will be fixed. |
| ![Left](~/user-guide/images/Dimensions_Left.png) | Left | Specify a number of pixels to which the left of the layer will be fixed. |
| ![Right](~/user-guide/images/Dimensions_Right.png) | Right | Specify a number of pixels to which the right of the layer will be fixed. |

> [!NOTE]
>
> - When you use the drag-and-drop functionality to move a layer in the preview, the dimension settings in the *Settings* pane will automatically adjust.
> - You can use the lock functionality to secure one or multiple dimension settings of a layer by clicking the ![*Lock*](~/user-guide/images/Dimensions_Lock.png) button next to the chosen setting. If you now move that layer in the preview, any attempt to override the specified locked dimension will be restricted.
> - For some *text* layers, the width and height is determined by the left and right position and can therefore not be modified.

##### Specifying layer properties

Depending on the type of layer, you can specify different layer properties in the *Settings* pane.

- For *Icon* layers, you can specify the following properties:

  - *Show icon*: Allows you to mask the layer, rendering it temporarily invisible. If disabled, the layer is still visible in the preview with lowered opacity, but will not be visible in the template's end result.

  - Color: Allows you to specify a custom icon color, either by specifying the color in RGB format or by using the color picker box on the right.

  - *Icon*: Allows you to select any of the available icons.

- For *Text* layers, you can specify the following properties:

  - *Show text*: Allows you to mask the layer, rendering it temporarily invisible. If disabled, the layer is still visible in the preview with lowered opacity, but will not be visible in the template's end result.

  - Text box: Allows you to enter a custom text.

  - The table below describes the remaining settings available for *Text* layers:

    | Icon | Setting | Description |
    |--|--|--|
    | ![Font size](~/user-guide/images/Text_Font_Size.png) | Font size | Specify the size (in pixels) of the text. |
    | ![Color](~/user-guide/images/Text_Color.png) | Color | Specify a custom text color, either by specifying the color in RGB format or by using the color picker box on the right. |
    | ![Roundness](~/user-guide/images/Text_Roundness.png) | Roundness | Specify the roundness (in pixels) of the background color that can be displayed behind the text (optionally). |
    | ![Background color](~/user-guide/images/Text_Background_Color.png) | Background color | Specify a custom background color, either by specifying the color in RGB format or by using the color picker box on the right. |
    | ![Horizontal padding](~/user-guide/images/Text_Horizontal_Padding.png) | Horizontal padding | Specify the amount of space (in pixels) that should be left free above the text. |
    | ![Vertical padding](~/user-guide/images/Text_Vertical_Padding.png) | Vertical padding | Specify the amount of space (in pixels) that should be left free underneath the text. |
    | ![Horizontal alignment](~/user-guide/images/Text_Horizontal_Alignment.png) | Horizontal alignment | Left, center, right, or justify. |
    | ![Vertical alignment](~/user-guide/images/Text_Vertical_Alignment.png) | Vertical alignment | Top, center, or bottom. |

- For *Rectangle* layers, you can specify the following properties:

  - *Show rectangle*: Allows you to mask the layer, rendering it temporarily invisible. If disabled, the layer is still visible in the preview with lowered opacity, but will not be visible in the template's end result.

  - Color: Allows you to specify a custom color for the rectangle, either by specifying the color in RGB format or by using the color picker box on the right.

  - Roundness: Allows you to specify the roundness (in pixels) of the rectangle edges.

- For *Ellipse* layers, you can specify the following properties:

  - *Show ellipse*: Allows you to mask the layer, rendering it temporarily invisible. If disabled, the layer is still visible in the preview with lowered opacity, but will not be visible in the template's end result.

  - Color: Allows you to specify a custom color for the ellipse, either by specifying the color in RGB format or by using the color picker box on the right.

##### Adding conditional cases to a layer

For each layer, you can add one or multiple conditional cases in the *Conditional cases* section of the *Settings* pane, making certain actions dependent on one or more conditions.

A conditional case consists of two sections: A first section that contains one or more conditions combined with "and", and a second section that contains actions that exclusively execute when the conditions are met.

To add a condition:

1. Click *Add case*.

1. Choose a state or column from the dropdown list.

1. When you have added a state, select *Yes* or *No*.

   - Yes: The action executes only when the element is in the specified state.

   - No: The action executes only when the element is not in the specified state.

1. When you have added a column, provide the necessary details based on the column type:

   - Element name: The action executes only when the element name matches this entry.

   - Parameter description: The action executes only when the parameter description matches this entry.

   - Root time: The action executes only when the current time aligns with the specified timestamp.

     - `= dd/MM/yyyy hh:mm`: The root time matches the specified timestamp.

     - `> dd/MM/yyyy hh:mm`: The root time occurs after the specified lower bound.

     - `≥ dd/MM/yyyy hh:mm`: The root time occurs at or after the specified lower bound.

     - `< dd/MM/yyyy hh:mm`: The root time occurs before the specified upper bound.

     - `≤ dd/MM/yyyy hh:mm`: The root time occurs at or before the specified upper bound.

   - Severity: The action executes only if the alarm severity matches the selected levels of alarm severity.

   - Alarm type: The action executes only if the alarm type matches this entry.

1. Enable or disable the toggle button next to `Show [tool-type]`. If enabled, the selected tool is shown if the conditions are met. If disabled, the selected tool is hidden if the conditions are met.

1. If you chose to show the tool in the previous step, optionally select a different color for the tool when the conditions are met, either by specifying the color in RGB format or by using the color picker box on the right.

1. Optionally, add another condition and follow the previous steps again until you are finished.

Example:

If you configure the following conditional case:

![Conditional case](~/user-guide/images/Conditional_Case.png)<br/>*Template Editor in DataMiner 10.4.1*

The end result behavior will be:

![Conditional case behavior](~/user-guide/images/Conditional_Case.gif)<br/>*Template Editor in DataMiner 10.4.1*

### Reusing a template

You can reuse a template if you have already configured a template for a component of the same type in the same dashboard or low-code app you are working on.

1. Navigate to *Layout > Item templates* and click *Reuse template*.

1. Click *Filter* and select a template from the dropdown list.

   A preview of the template you have selected will appear.

1. Select *Reuse*.
