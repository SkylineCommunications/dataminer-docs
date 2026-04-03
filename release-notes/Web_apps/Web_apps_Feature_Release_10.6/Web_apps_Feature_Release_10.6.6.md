---
uid: Web_apps_Feature_Release_10.6.6
---

# DataMiner web apps Feature Release 10.6.6 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.6.0 [CU3].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.6](xref:General_Feature_Release_10.6.6).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.6](xref:Cube_Feature_Release_10.6.6).

## Highlights

*No highlights have been selected yet.*

## New features

#### Dashboards/Low-Code Apps: New 'Rich text input' component [ID 45097] [ID 45180]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

A new basic control named *Rich text input* now allows you to enter rich text that will be exposed as HTML.

Its toolbar offers the following formatting options:

- Headings: Levels 1 to 4
- Lists: Bulleted list and Numbered list
- Blockquote
- Code block
- Font color
- Inline text formatting: Bold (Ctrl+B), Italic (Ctrl+I), Underline (Ctrl+U), and Strikethrough
- Hyperlinks: Insert, Edit, and Remove
- History: Undo (Ctrl+Z) and Redo (Ctrl+Y)

In the *Settings* pane for this component, you can configure the following settings:

| Section | Option | Description |
|--|--|--|
| General | Emit value on | Determine when the value in the box becomes available as data. This can be when the focus is no longer on the box ("Focus lost"), or when the value in the box changes ("Value change").<br>If you select *Focus lost*, the value will also become available when the user presses Enter. |
| General | Default value | Specify the default value that will be entered into the input box when the dashboard or low-code app is opened. |

Similar to all other basic controls, this new control also supports the *Set Value* component action, which sets the current value of the component to either a static or dynamic value.

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### Dashboards/Low-Code Apps: Problem when themes were being migrated when the DMA was offline [ID 45020]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

When themes were being migrated, in some cases, an exception could be thrown when the DataMiner Agent was offline.

#### GQI DxM unavailable because of missing Newtonsoft.Json assembly [ID 45146]

<!-- MR 10.5.0 [CU15] / 10.6.0 [CU3] - FR 10.6.6 -->

After an upgrade from DataMiner web 10.5.0 CU0, 10.5.2, or 10.5.3 to a higher version, the GQI DxM would be unavailable in the DataMiner web apps. Also, the GQI logging would contain a message stating `Could not load file or assembly 'Newtonsoft.Json'`.
