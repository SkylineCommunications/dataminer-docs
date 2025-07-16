---
uid: Overview_of_user_interface_component_properties
---

# Overview of user interface component properties

Below, you can find the properties of each of the user interface components, as well as the additional optional property groups that can be added to components.

## Extra grid properties

When one of the below-mentioned controls is placed inside a grid, it will have four extra grid properties:

| Property   | Description                                                       |
|------------|-------------------------------------------------------------------|
| Row        | The 0-based number of the row in which the control is located.    |
| RowSpan    | The number of rows over which the control spans.                  |
| Column     | The 0-based number of the column in which the control is located. |
| ColumnSpan | The number of columns over which the control spans.               |

## Properties per component

### Border

None

> [!TIP]
> See also: [Extra grid properties](#extra-grid-properties)

### Label

| Property | Description |
|--|--|
| Name | The text of the label. |
| TextAlignment | The alignment of the text: Left, Right, Center, or Justify. |
| TextWrapping  | Whether or not text will wrap when it reaches the edge of the label box:<br> -  Wrap: Text will always wrap when it reaches the edge of the label box.<br> -  WrapWithOverflow: Text will always wrap when it reaches the edge of the label box, except in case of long words.<br> -  NoWrap: No line wrapping is performed.              |
| TextTrimming  | The way in which text is trimmed when it overflows the edge of the label box.<br> -  None: Text is not trimmed.<br> -  CharacterEllipsis: Text is trimmed after a character. An ellipsis (”...”) will replace the remaining text.<br> -  WordEllipsis: Text is trimmed after a word. An ellipsis (”...”) will replace the remaining text. |
| FontFamily | The text font. |
| FontSize | The text font size (in points). |
| FontWeight | The font weight: Normal, Bold, or Light |
| FontStyle | The font style: Normal, Italic, or Oblique |
| Foreground | The text color. |

> [!TIP]
> See also: [Extra grid properties](#extra-grid-properties)

### Grid

| Property | Description |
|--|--|
| Rows | The number of rows in the grid. |
| Height | The height of the row.<br> The number of *Height* properties is equal to the number of rows specified in the *Rows* property. |
| Columns  | The number of columns in the grid. |
| Width | The width of the column.<br> The number of *Width* properties is equal to the number of columns specified in the *Columns* property. |

> [!TIP]
> See also: [Extra grid properties](#extra-grid-properties)

### TabControl

Consists of TabPage components. These have one customizable property, the tab page name, which can have multiple lines. To enter a new line while customizing the tab page name, simply press Enter.

> [!TIP]
> See also:
>
> - [Extra grid properties](#extra-grid-properties)
> - [Creating a dynamic tab page](xref:Creating_a_dynamic_tab_page)

### TogglePanel

| Property      | Description                                          |
|---------------|------------------------------------------------------|
| Enable label  | The text displayed on the panel when it is disabled. |
| Disable label | The text displayed on the panel when it is enabled.  |

> [!TIP]
> See also: [Extra grid properties](#extra-grid-properties)

### ExpandingPanel

| Property        | Description                                                                      |
|-----------------|----------------------------------------------------------------------------------|
| Name            | The name of the expanding panel.                                                 |
| ExpandDirection | The direction in which the panel will expand/collapse: Down, Up, Left, or Right. |

> [!TIP]
> See also: [Extra grid properties](#extra-grid-properties)

### I/O

| Property | Description |
|--|--|
| Description | The text displayed in the input/output box. |
| Input | The matrix input linked with this box. Choose -1 to turn the input into the “park input”, i.e. the input to which an output will automatically be connected when it is disconnected from its earlier input. |
| Include port number in description | Determines whether the port number is included in the description or not (e.g. “input 5” or “output 3”). |
| Output | The matrix output linked with this box. |

> [!NOTE]
> To display extra information on IO buttons, based on other columns in the IO tables, use a placeholder {p:pid} in the button description, where “pid” is the parameter ID. For example: “This is input {p:1001}”.

> [!TIP]
> See also: [Extra grid properties](#extra-grid-properties)

### Action

| Property | Description |
|--|--|
| Label | The text displayed on the button. |
| Type | The action that will be executed when the button is clicked: Connect, Disconnect, Lock/Unlock, or Undo. You can also select a “Custom” type (using the *Customize* option), for which the actions are specified in the *Options* box. |
| Options | For Custom type actions, add one action per line in this box, using the same syntax as when using an *Execute* shape data field in Visio. See [Overview of DataMiner shape data fields](xref:Overview_of_DataMiner_shape_data_fields). |

> [!NOTE]
> The Undo action allows you to undo the latest connect or disconnect action. As the option can only be applied to undo one action, after *Undo* is clicked, the button is disabled until another action has been done. Optionally, you can select the *Display confirmation* option for the Undo action type, so a confirmation window is displayed whenever the button is used.

> [!TIP]
> See also: [Extra grid properties](#extra-grid-properties)

### InfoPanel

| Property | Description |
|--|--|
| Type | The type of information panel: Selected Input, Selected Output, Routed Outputs. |
| Options | If Type is “Routed Outputs”, then in the Options property you can specify the connections that you do not want users to see.<br> Example: One of the inputs is not connected to a real video source. Instead, it has a terminator pin attached to it, and shows a black screen. If an output is connected to this input, it is in fact not in use (i.e. blacked out). Although it is a matrix crosspoint, it does not represent a routed video signal and should therefore not be displayed.<br> Syntax: Inputs and outputs must be specified with their numeric index, and can be separated by either commas or semicolons.<br> - ignore-input:1,2,3<br> - ignore-output:11,12,13 |

> [!TIP]
> See also: [Extra grid properties](#extra-grid-properties)

### Timer

| Property | Description                                                                              |
|----------|------------------------------------------------------------------------------------------|
| Duration | The number of hours, minutes and seconds from which to count down.<br> Default: 00:01:00 |

> [!TIP]
> See also: [Extra grid properties](#extra-grid-properties)

### Visio

| Property     | Description                                                   |
|--------------|---------------------------------------------------------------|
| Link to view | The name of a DataMiner view that contains the Visio drawing. |

> [!TIP]
> See also: [Extra grid properties](#extra-grid-properties)

## Optional property groups

To each of the components mentioned above, additional property groups can be added by means of the *Add* button in the lower left corner of the properties pane. These property groups can also be removed again, by clicking the *x* in the top-right corner of the optional block of properties.

The following optional property groups are available:

- Font options

  | Property | Description                                |
  |------------|--------------------------------------------|
  | FontFamily | The text font.                             |
  | FontSize   | The text font size (in points).            |
  | FontWeight | The font weight: Normal, Bold, or Light    |
  | FontStyle  | The font style: Normal, Italic, or Oblique |
  | Foreground | The text color.                            |

  > [!NOTE]
  > The *Font* property group is by default available for the *Label* component.

- Layout options

  | Property  | Description |
  |-----------|-------------|
  | Height    | The height of the component. |
  | MinHeight | The minimum height of the component. |
  | MaxHeight | The maximum height of the component. This overrides the *Height* property. |
  | Width     | The width of the component. |
  | MinWidth  | The minimum width of the component. |
  | MaxWidth  | The maximum width of the component. |
  | Margin    | The four margins of the component, separated by commas, in the following order: left, top, right, bottom. |
  | HorizontalAlignment | The horizontal alignment, which can be *Left*, *Center*, *Right* or *Stretch*. |
  | VerticalAlignment   | The vertical alignment, which can be *Left*, *Center*, *Right* or *Stretch*.   |

- Custom options
