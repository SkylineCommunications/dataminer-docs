---
uid: RichTextInput
---

# Rich text input

Available from DataMiner 10.5.0 [CU15]/10.6.0 [CU3]/10.6.6 onwards<!--RN 45097-->.

The rich text input component allows you to **enter and edit formatted text** in a dashboard or low-code app. The entered content is stored as HTML.

![Example of rich text input component](~/dataminer/images/RichTextInput.png)<br>*Rich text input component in DataMiner 10.6.6*

With this component, you can:

- Add structured notes, comments, or instructions.

- Highlight important information with [formatting](#formatting-options) such as bold text, colors, or links.

- Maintain separate notes linked to selected items in an app (see example above).

## TO DO

![Example of rich text input component](~/dataminer/images/RichTextInput.gif)<br>*Low-Code Apps module in DataMiner 10.6.6*

In the example above, users can select a movie and store formatted notes for that specific item.

How to do this --> WIP

## Formatting options

The toolbar provides the following formatting options, from left to right:

| Icon | Option | Description |
|--|--|--|
| ![Headings](~/dataminer/images/RTI_Heading.png) | Headings | Apply headings from level 1 to level 4. |
| ![Lists](~/dataminer/images/RTI_Lists.png) | Lists | Create bulleted or numbered lists. |
| ![Blockquote](~/dataminer/images/RTI_Blockquote.png) | Blockquote | Format the selected text as a block quote. |
| ![Code block](~/dataminer/images/RTI_CodeBlock.png) | Code block | Format the selected text as a code block. |
| ![Font color](~/dataminer/images/RTI_FontColor.png) | Font color | Specify a custom text color, either by specifying the color in RGB format, by entering the hex value or HTML color name, or by using the color picker box. The most recently used template colors and the theme colors are always displayed. |
| ![Bold](~/dataminer/images/RTI_Bold.png) | Bold | Make the selected text bold (Ctrl+B). |
| ![Italic](~/dataminer/images/RTI_Italics.png) | Italic | Make the selected text italic (Ctrl+I). |
| ![Underline](~/dataminer/images/RTI_Underline.png) | Underline | Underline the selected text (Ctrl+U). |
| ![Strikethrough](~/dataminer/images/RTI_Strikethrough.png) | Strikethrough | Apply strikethrough formatting to the selected text. |
| ![Hyperlinks](~/dataminer/images/RTI_Hyperlink.png) | Hyperlinks | Insert, edit, or remove hyperlinks. |
| ![Undo](~/dataminer/images/RTI_Undo.png) | Undo | Undo the last action (Ctrl+Z). |
| ![Redo](~/dataminer/images/RTI_Redo.png) | Redo | Redo the last undone action (Ctrl+Y). |

## Configuration options

### Rich text input layout

In the *Layout* pane, you can find the default options for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

### Rich text input settings

| Section | Option | Description |
|--|--|--|
| General | Emit value on | Determine when the value in the box becomes available as data. This can be when the focus is no longer on the box ("Focus lost"), or when the value in the box changes ("Value change"). |
| General | Default value | Specify the default value that will be entered into the input box when the dashboard or low-code app is opened. HTML text formatting is supported. |

## Text input component actions

Component actions are operations that can be executed on a component when an event is triggered.

When you select the [*Execute component action option*](xref:LowCodeApps_event_config#executing-a-component-action), you can choose from a list of components in the app and the specific actions available for each of them.

For the rich text input component, the following component action is available:

- *Set value*: Sets the current value of the component to either a static or dynamic value.
