---
uid: Template_Editor
---

# Using the Template Editor

> [!IMPORTANT]
> The Template Editor is in preview until DataMiner 10.4.1/10.5.0. If you use the preview version of the feature, its functionality may be different from what is described below. For more information, see [Soft-launch options](xref:SoftLaunchOptions).

Available from DataMiner 10.4.1/10.5.0. Prior to this, the Template Editor is available in soft launch from DataMiner 102.12 onwards, if the soft-launch options *ReportsAndDashboardsDynamicVisuals* and *ReportsAndDashboardsScheduler* are enabled.

Currently only supported for specific components, such as the grid, timeline, and table component.

To access the Template Editor:

- For the grid and timeline components:

  1. Select the component and go to the *Layout* tab on the right.

  1. In the *Item templates* section, click *Edit*.

     > [!NOTE]
     > A preview of the template currently used for this component is displayed in the *Item templates* section.

- For the table component:

  1. Select the component and go to the *Layout* tab on the right.

  1. In the *Column appearance* section, click the downward arrow next to *Select a column* and select the column you want to create a template for.

  1. Click the ellipsis button ("...") in the top-right corner and select *Customize preset*.

The Template Editor UI consists of the following main components<!--RN 34858-->:

- Side pane:

  - The *Layers* tab (1A)

  - The *Tools* tab (1B)

- Preview (2)

- *Settings* pane (3)

![Template Editor](~/user-guide/images/Template_Editor.png)<br/>*The Template Editor in DataMiner 10.4.1*

> [!IMPORTANT]
> Any changes made in the Template Editor are only saved once you click the *Save* button in the lower right corner. When you close the Template Editor by clicking the "X" in the top-right corner or the *Cancel* button in the lower right corner, you will be alerted of any unsaved changes that may be lost if you close the editor prematurely.

## Working with layers

In the side pane of the Template Editor, the *Layers* tab offers an overview of all layers. Layers are used in the Template Editor to make non-destructive edits by stacking icons, text, rectangles, and ellipses one on top of the other without compromising the pixels of individual elements.

The benefits of working with layers:

- You can add elements on top of each other without removing data.

- You can apply conditions to only one layer of the template. See [Adding conditional cases to a layer](#adding-conditional-cases-to-a-layer).

- You can discard any unsatisfactory layers without affecting the entire template.

- You can mask layers so that they are temporarily hidden without the need to delete them.

- ...

If one layer is positioned higher than another, the higher layer will appear in front of the lower one. To **change the order of layers**, click the ![*Drag-and-drop*](~/user-guide/images/drag-and-drop.png) button and drag the layer up or down in the *Layers* tab. Release the mouse button when you reach the position where you want to place the selected layer.

![Change order layers](~/user-guide/images/Change_Order_Layers.gif)<br/>*The Template Editor in DataMiner 10.4.1*

To **mask a layer**, hover the mouse pointer over the layer and click the *eye* icon in the lower right corner. The layer is now no longer visible in the template's end result. Clicking the *eye* icon once more makes the layer visible again. Alternatively, you can mask the layer by adjusting its properties in the *Settings* pane. See [Specifying layer properties](#specifying-layer-properties).

> [!NOTE]
> In cases where you have masked a layer in both the *Layer* tab and the layer properties, undoing the masking in only one of these locations will result in the layer remaining invisible. Ensure that you reverse the masking in both places to render the layer visible again.

To **delete a layer**, hover the mouse pointer over the layer and click the *delete* button in the top-right corner. Alternatively, select the associated tool (i.e. icon, text, rectangle, or ellipse) in the preview and press the *Delete* button on your keyboard.

To **add a new layer**, [add a new tool](#adding-new-tools) in the *Tools* tab.

In the lower left corner of each layer, an icon denotes the layer type: an *icon*, *text*, *rectangle*, or *ellipse* layer.

## Adding new tools

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

## Changing template settings

With the *Settings* pane to the right side of the preview, you can change the settings for the entire template and the different layers. The preview is then immediately updated according to the changes.

- To modify the **template settings**, make sure no layers are selected. In the *Settings* pane, you can specify a number of pixels to which the width and/or height of the template will be fixed.

- To modify the **layer settings**, make sure a layer is selected. In the *Settings* pane, you can adjust the following layer settings in three collapsible sections:

  - [Dimensions](#specifying-layer-dimensions)

  - [Properties](#specifying-layer-properties)

  - [Conditional cases](#adding-conditional-cases-to-a-layer)

### Specifying layer dimensions

The table below describes the dimension settings available for template layers<!--RN 37476-->.

| Icon | Setting | Description |
|--|--|--|
| ![Width](~/user-guide/images/Dimensions_Width.png) | Width | Specify a number of pixels to which the width of the layer will be fixed. This value should be lower than or equal to the width of the overall template. |
| ![Height](~/user-guide/images/Dimensions_Height.png) | Height | Specify a number of pixels to which the height of the layer will be fixed. This value should be lower than or equal to the height of the overall template. |
| ![Top](~/user-guide/images/Dimensions_Top.png) | Top | Specify a number of pixels to which the top of the layer will be fixed. This value should be lower than the height of the overall template. |
| ![Bottom](~/user-guide/images/Dimensions_Bottom.png) | Bottom | Specify a number of pixels to which the bottom of the layer will be fixed. This value should be lower than the height of the overall template. |
| ![Left](~/user-guide/images/Dimensions_Left.png) | Left | Specify a number of pixels to which the left of the layer will be fixed. This value should be lower than the width of the overall template. |
| ![Right](~/user-guide/images/Dimensions_Right.png) | Right | Specify a number of pixels to which the right of the layer will be fixed. This value should be lower than the width of the overall template. |

> [!NOTE]
>
> - In the preview, when you use the drag-and-drop functionality to move a layer, or when you resize a layer by dragging the frame edges, the dimension settings in the *Settings* pane will automatically adjust.
> - You can change the unit to percentages by clicking *px* next to the dimension values.
> - You can use the lock functionality to enhance the security of your design, locking one or multiple dimension settings of a layer by clicking the ![*Lock*](~/user-guide/images/Dimensions_Lock.png) button next to the chosen setting. Once locked, any attempt to override this specified dimension will be restricted, including moving or resizing that layer in the preview and resizing the component in the dashboard or low-code app edit mode (e.g. changing the size of a table column). The locked dimensions will ensure the template remains in its designated position. If you cannot lock a dimension setting because of the locking of other settings, it will appear grayed out.
> - For some layers, the width and height is determined by the left and right position and can therefore not be modified.
> - When resizing a layer in the preview, do not release the mouse button if one or more dimension settings are surrounded by a red frame, signaling that they no longer meet the minimum required pixel count. Releasing the mouse button in this state may result in the deletion of your layer.

### Specifying layer properties

Depending on the type of layer, you can specify different layer properties in the *Settings* pane.

- For *Icon* layers, you can specify the following properties:

  - *Show icon*: Allows you to mask the layer, rendering it temporarily invisible. If disabled, the layer is still visible in the preview with lowered opacity, but will not be visible in the template's end result.

  - *Color*: Allows you to specify a custom icon color, either by specifying the color in RGB format or by using the color picker box on the right.

  - *Icon*: Allows you to select any of the available icons from the dropdown list, or search for a specific icon using the search bar functionality.

  - *Configure actions*: Allows you to configure actions that are executed when a user clicks the icon. Only available for DataMiner Low-Code Apps<!--RN 34761-->.

    > [!TIP]
    > For more information on how to configure these actions, see [Configuring low-code app events](xref:LowCodeApps_event_config).

- For *Text* layers, you can specify the following properties:

  - *Show text*: Allows you to mask the layer, rendering it temporarily invisible. If disabled, the layer is still visible in the preview with lowered opacity, but will not be visible in the template's end result.

  - *Text box*: Allows you to enter a custom text. You can add formatting to your text using HTML text formatting. To insert the corresponding cell value inside your text, enter the column name surrounded by curly brackets, i.e. `{column name}`.

    ![HTML text formatting](~/user-guide/images/HTML_Text_Formatting.png)<br/>*Template Editor in DataMiner 10.4.1*

    > [!TIP]
    > For more information on formatting elements designed to display special types of text, see [HTML Text Formatting](https://www.w3schools.com/html/html_formatting.asp).

  - The table below describes the remaining settings available for *Text* layers:

    | Icon | Setting | Description |
    |--|--|--|
    | ![Font size](~/user-guide/images/Text_Font_Size.png) | Font size | Specify the size (in pixels) of the text. |
    | ![Color](~/user-guide/images/Text_Color.png) | Color | Specify a custom text color, either by specifying the color in RGB format or by using the color picker box on the right. |
    | ![Border radius](~/user-guide/images/Text_Roundness.png) | Border radius | Specify the roundness (in pixels) of the background color that can be displayed behind the text (optionally). |
    | ![Background color](~/user-guide/images/Text_Background_Color.png) | Background color | Specify a custom background color, either by specifying the color in RGB format or by using the color picker box on the right. |
    | ![Horizontal padding](~/user-guide/images/Text_Horizontal_Padding.png) | Horizontal padding | Specify the amount of space (in pixels) that should be left free above the text. |
    | ![Vertical padding](~/user-guide/images/Text_Vertical_Padding.png) | Vertical padding | Specify the amount of space (in pixels) that should be left free underneath the text. |
    | ![Horizontal alignment](~/user-guide/images/Text_Horizontal_Alignment.png) | Horizontal alignment | Left, center, right, or justify. |
    | ![Vertical alignment](~/user-guide/images/Text_Vertical_Alignment.png) | Vertical alignment | Top, center, or bottom. |

- For *Rectangle* layers, you can specify the following properties:

  - *Show rectangle*: Allows you to mask the layer, rendering it temporarily invisible. If disabled, the layer is still visible in the preview with lowered opacity, but will not be visible in the template's end result.

  - *Color*: Allows you to specify a custom color for the rectangle, either by specifying the color in RGB format or by using the color picker box on the right.

  - *Border radius*: Allows you to specify the roundness (in pixels) of the rectangle edges.

  - *Link width to*: Allows you to link the width of this column to that of another column, selected from the dropdown list. Only available for table and grid components.
  
  - *Link height to*: Allows you to link the height of this column to that of another column, selected from the dropdown list. Only available for table and grid components.

  - *Configure actions*: Allows you to configure actions that are executed when a user clicks the rectangle. Only available for DataMiner Low-Code Apps<!--RN 34761-->.

    > [!TIP]
    > For more information on how to configure these actions, see [Configuring low-code app events](xref:LowCodeApps_event_config).

- For *Ellipse* layers, you can specify the following properties:

  - *Show ellipse*: Allows you to mask the layer, rendering it temporarily invisible. If disabled, the layer is still visible in the preview with lowered opacity, but will not be visible in the template's end result.

  - *Color*: Allows you to specify a custom color for the ellipse, either by specifying the color in RGB format or by using the color picker box on the right.

  - *Configure actions*: Allows you to configure actions that are executed when a user clicks the ellipse. Only available for DataMiner Low-Code Apps<!--RN 34761-->.

    > [!TIP]
    > For more information on how to configure these actions, see [Configuring low-code app events](xref:LowCodeApps_event_config).

> [!NOTE]
> When you change the color of a layer, the most recently used template colors and the theme colors are always displayed<!--RN 34876-->.

### Adding conditional cases to a layer

For each layer, you can add one or multiple conditional cases in the *Conditional cases* section of the *Settings* pane, making certain actions dependent on one or more conditions.

A conditional case consists of two sections: A first section that contains one or more conditions combined with "and", and a second section that contains actions that exclusively execute when the conditions are met.

To add a condition:

1. Click *Add case*.

1. Choose a state or column from the dropdown list.

   The available states:

   - *Is selected*: The action will be executed when a user selects the tool<!--RN 34761-->.

   - *Is busy*: The action will be executed when the component is busy.

   - *Hovering*: The action will be executed when a user hovers the mouse pointer over the tool<!--RN 34761-->.

   - *Is loading*: The action will be executed when the component is loading<!--RN 34859-->. Only available for grid components.

1. When you have chosen a state, select *Yes* or *No*.

   - Yes: The action executes only when the element is in the specified state.

   - No: The action executes only when the element is not in the specified state.

1. When you have chosen a column, provide the necessary details based on the column type.

   Some examples:

   - Element name: The action executes only when the element name matches this entry.

   - Parameter description: The action executes only when the parameter description matches this entry.

   - Root time: The action executes only when the current time aligns with the specified timestamp.

     - `= dd/MM/yyyy hh:mm`: The root time matches the specified timestamp.

     - `> dd/MM/yyyy hh:mm`: The root time occurs after the specified lower bound.

     - `≥ dd/MM/yyyy hh:mm`: The root time occurs at or after the specified lower bound.

     - `< dd/MM/yyyy hh:mm`: The root time occurs before the specified upper bound.

     - `≤ dd/MM/yyyy hh:mm`: The root time occurs at or before the specified upper bound.

1. Enable or disable the toggle button next to `Show [tool-type]`. If enabled, the selected tool is shown if the conditions are met. If disabled, the selected tool is hidden if the conditions are met.

1. If you chose to show the tool in the previous step, optionally change the look of the tool when the conditions are met. Depending on the type of layer and the type of component, the following options may be available:

   - *Icon* layer:

     - *Color*: Allows you to select a color for the tool, either by specifying the color in RGB format or by using the color picker box on the right.

     - *Icon*: Allows you to select a new icon from the dropdown list, or search for a specific icon using the search bar functionality.

   - *Text* layer:

     - *Text*: Allows you to enter a custom text. You can add formatting to your text using HTML text formatting.

       > [!TIP]
       > For more information on formatting elements designed to display special types of text, see [HTML Text Formatting](https://www.w3schools.com/html/html_formatting.asp).

     - *Font size*: Allows you to set the font size.

     - *Text color*: Allows you to select a text color, either by specifying the color in RGB format or by using the color picker box on the right.

     - *Border radius*: Allows you to specify the roundness (in pixels) of the background color that can be displayed behind the text (optionally).

     - *Background*: Allows you to specify a custom background color, either by specifying the color in RGB format or by using the color picker box on the right.

     - *Horizontal padding*: Allows you to specify the amount of space (in pixels) that should be left free above the text.

     - *Vertical padding*: Allows you to specify the amount of space (in pixels) that should be left free underneath the text.

     - *Text alignment*: Allows you to choose between the available horizontal alignment options (Left, center, right, or justify).

     - *Vertical alignment*: Allows you to choose between the available vertical alignment options (Top, center, or bottom).

   - *Rectangle* layer:

     - *Color*: Allows you to select a color for the tool, either by specifying the color in RGB format or by using the color picker box on the right.

     - *Border radius*: Allows you to specify the roundness (in pixels) of the background color that can be displayed behind the text (optionally).

     - *Link width to*: Allows you to link the width of this tool to that of another column, selected from the dropdown list.

     - *Link height to*: Allows you to link the height of this tool to that of another column, selected from the dropdown list.

   - *Ellipse* layer:

     - *Color*: Allows you to select a color for the tool, either by specifying the color in RGB format or by using the color picker box on the right.

   > [!NOTE]
   > Any visual changes made when configuring a conditional case will not show up in the preview.

1. Optionally, in a low-code app, you can configure actions that are executed when a user clicks the tool. Only available for *Icon*, *Rectangle*, and *Ellipse* layers<!--RN 34761-->.

   > [!TIP]
   > For more information on how to configure these actions, see [Configuring low-code app events](xref:LowCodeApps_event_config).

1. If you want to add another condition, go back to step 1 and repeat the steps until you are finished.

Example:

If you configure the following conditional case:

![Conditional case](~/user-guide/images/Conditional_Case.png)<br/>*Template Editor in DataMiner 10.4.1*

The end result behavior will be:

![Conditional case behavior](~/user-guide/images/Conditional_Case.gif)<br/>*Template Editor in DataMiner 10.4.1*

## Reusing a template

You can reuse a template if you have already configured a template for a component of the same type in the same dashboard or low-code app you are working on<!--RN 34948-->.

1. Navigate to *Layout > Item templates* and click *Reuse template*.

1. Click *Filter* and select a template from the dropdown list.

   A preview of the template you have selected will appear.

1. Select *Reuse*.
