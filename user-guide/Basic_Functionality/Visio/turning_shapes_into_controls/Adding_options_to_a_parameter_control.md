---
uid: Adding_options_to_a_parameter_control
---

# Adding options to a parameter control

If you used a shape data field of type **ParameterControl** to turn a shape into a parameter control, then you can use an additional shape data field of type **ParameterControlOptions** to configure the control settings.

> [!TIP]
>
> - See also: [Turning a shape into a parameter control](xref:Turning_a_shape_into_a_parameter_control)
> - For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[controls > PARAM]* page.

## Configuring the shape data field

Add a shape data field of type **ParameterControlOptions** to the shape, and set its value to:

```txt
Option|Option|...
```

## Options

Possible options:

- [Checkbox](#checkbox)
- [ClientSidePollingInterval](#clientsidepollinginterval)
- [ClientSideRowFilter](#clientsiderowfilter)
- [ColumnWidths](#columnwidths)
- [CustomColors](#customcolors)
- [CustomTextBoxInfo:\[Text\]](#customtextboxinfotext)
- [CustomTitle:\[Text\]](#customtitletext)
- [DisableSetVarOnParameterUpdate](#disablesetvaronparameterupdate)
- [DisableWritePids](#disablewritepids)
- [DoubleClickAction](#doubleclickaction)
- [Filter](#filter)
- [HideSlider](#hideslider)
- [HideTableIndex](#hidetableindex)
- [IncludeWrite](#includewrite)
- [IncludedPids and TableRowFilter](#includedpids-and-tablerowfilter)
- [LedBar](#ledbar)
- [Lite](#lite)
- [MultipleValueSep](#multiplevaluesep)
- [Oscilloscope](#oscilloscope)
- [Refresh](#refresh)
- [ShowTableName=true](#showtablenametrue)
- [SingleSelection](#singleselection)
- [Sort](#sort)
- [Table](#table)
- [TitleFont](#titlefont)
- [UpdateSelectionOnLinkedVariables](#updateselectiononlinkedvariables)
- [ValueFont](#valuefont)

### Checkbox

If certain types of parameters are displayed as a "Lite" parameter, you can use this option to display a checkbox. This is the case for toggle button parameters that represent a boolean value (i.e. 0 and 1) and for hybrid parameters:

- For a toggle button parameter, the parameter will be displayed as a checkbox in Visual Overview. If the parameter does not yet have a value, the checkbox will be displayed as unchecked.
- For a hybrid parameter, a checkbox will be displayed in Visual Overview that can be cleared to set the parameter to the exception value, or selected to set the parameter to any normal value.

  > [!NOTE]
  > The behavior of a hybrid parameter checkbox configured with this option is the opposite as the behavior for hybrid parameter checkboxes in Data Display.

In order to specify this option, set **ParameterControlOptions** to the following value:

```txt
IncludeWrite|Lite|CheckBox
```

> [!TIP]
> See also:
>
> - [IncludeWrite](#includewrite)
> - [Lite](#lite)

### ClientSidePollingInterval

Available from DataMiner 10.0.9 onwards. When you have turned a shape into a table control that displays a direct view table, you can use this option to have the table refreshed at regular intervals.

| Shape data field | Value                                |
| ---------------- | ------------------------------------ |
| ParameterControlOptions | ClientSidePollingInterval:\<interval><br>For example: To configure a polling interval of 1 minute, specify *ClientSidePollingInterval:00:01:00*. |

### ClientSideRowFilter

When displaying a table parameter in Visio, use this option to specify a client-side row filter.

Use the same syntax as in a filter box (e.g. in the top-right corner of a card).

If, for example, you set **ParameterControlOptions** to "ClientSideRowFilter:Name:abc", the table will only display rows of which the "Name" column contains "abc".

> [!NOTE]
> Since DataMiner 9.6.4, table column names in DataMiner Cube no longer display the name of the table as a suffix in parentheses. As such, from DataMiner 9.6.8 onwards, *ClientSideRowFilter* supports both the table name with and without this suffix. For example, a column with parameter description "Value (Table1)" will match both the filter *Value:5* and *Value (Table1):5*.

### ColumnWidths

When displaying a table parameter in Visio, use this option to control the width of the table columns.

Set **ParameterControlOptions** to "ColumnWidths:", followed by a comma-separated list of widths (in pixels).

Example:

```txt
ColumnWidths:100,50,100,250
```

If you want a column to automatically adjust its width according to its contents, replace the pixel size by a character "a" (referring to "autosize"):

```txt
ColumnWidths:100,50,100,a
```

> [!NOTE]
>
> - The width of an "autosize" column will not be recalculated when cell content changes, nor when the user scrolls the list (in order to avoid flickering). However, it will be recalculated when rows are added or removed.
> - The autosize behavior of a column will be disabled if that column is resized manually. To re-enable the autosize behavior, the user has to double-click the column resize icon.

### CustomColors

When you turn a shape into a parameter control of type "Lite" (see below), you can use the "CustomColors" option to customize the colors of that parameter control.

Example:

```txt
IncludeWrite|Lite|CustomColors:text=#0000FF,text.disabled=#8888FF,text.titlesuffix=#FF0000,bg.hover=#FFFF00,bg.hovereditor=#66FF66,bg.pressededitor=#4cc74c
```

| Color definition | Description                                                                                                          |
| ---------------- | -------------------------------------------------------------------------------------------------------------------- |
| text             | The color of the default text.                                                                                       |
| text.disabled    | The color of the text when the value is "not initialized".                                                           |
| text.titlesuffix | The color of the table index suffix in the title.                                                                    |
| bg.hover         | The color of the background when hovering the mouse cursor over the control.                                         |
| bg.hovereditor   | The color of the background when hovering the mouse cursor over the editor part of the control.                      |
| bg.pressededitor | As of DataMiner 10.3.9/10.4.0<!-- RN 36779 -->, the color of the background when the left mouse button is pressed within the editor part of the control. |

> [!NOTE]
>
> - If no custom color is defined, the control will take the default color depending on the current Cube theme (white/black).
> - Colors can be specified in one of the following hexadecimal formats: #RRGGBB, #AARRGGBB, RRGGBB, AARRGGBB. Values can be separated with a comma or a semicolon.

### CustomTextBoxInfo:\[Text\]

See [Adding a filter box to a table control](xref:Turning_a_shape_into_a_parameter_control#adding-a-filter-box-to-a-table-control).

### CustomTitle:\[Text\]

When you turn a shape into a parameter control of type "Lite", you can use the "CustomTitle" option to specify a custom label.

> [!NOTE]
> Up to DataMiner version 9.0.0 CU6/9.0.4, a custom label configured with this option is always displayed in upper case. However, from that version onwards, the casing displayed in Visual Overview is the same as is configured in Visio.

> [!TIP]
> See also: [Lite](#lite)

### DisableSetVarOnParameterUpdate

When the cells of one or more selected rows are changed in a table update, by default, the values of selection session variables are set again. From DataMiner 9.6.1 onwards, this behavior can be disabled with the "DisableSetVarOnParameterUpdate" option. If this option is specified, table updates will no longer set any session variables.

For example:

| Shape data              | Value                          |
| ----------------------- | ------------------------------ |
| Element                 | 123/4                          |
| ParameterControl        | 500                            |
| ParameterControlOptions | DisableSetVarOnParameterUpdate |

### DisableWritePids

When displaying a dynamic table on a Visio page using a shape data field of type **ParameterControl**, it is possible to specify which columns should be displayed as read-only.

Add a shape data field of type **ParameterControlOptions** to the shape, and set its value to "DisableWritePids:", followed by a comma-separated list of parameters to be disabled.

In the following example, the write parameters 1005, 1007 and 1009 have been disabled:

```txt
DisableWritePids:1005,1007,1009
```

### DoubleClickAction

From DataMiner 9.5.12 onwards, it is possible to override the default double-click action for an embedded table parameter control, so that double-clicking a table cell does not display parameter information, but instead opens a visual overview in an undocked window.

To do so, add the following shape data to the shape with the **ParameterControl** shape data:

| Shape data field | Description                    |
| ---------------- | ------------------------------ |
| ParameterControlOptions | Set this field to *DoubleClickAction=OpenPage*. |
| LinkOptions | The width and height of the undocked window that will be opened when the shape is double-clicked, in the format *Width=**x**\|Height=**x***. See [Configuring the size of the window](xref:Making_a_shape_display_a_particular_page_of_the_current_Visio_drawing#configuring-the-size-of-the-window). |
| VdxPage | Set this field to ***MyPage**\|Window*, where *MyPage* is a page name of the visual overview of the element containing the table. |

For example:

| Shape data field        | Value                      |
| ----------------------- | -------------------------- |
| Element                 | 17/10                      |
| ParameterControl        | 200                        |
| ParameterControlOptions | DoubleClickAction=OpenPage |
| LinkOptions             | Width=1200\|Height=800     |
| VdxPage                 | ContentPage\|Window        |

### Filter

See [Adding a filter box to a table control](xref:Turning_a_shape_into_a_parameter_control#adding-a-filter-box-to-a-table-control).

### HideSlider

If you specify this option on numeric write parameters, the slider will be removed from the parameter control.

### HideTableIndex

If you specify this option, the index part of table parameters will not be displayed.

### IncludeWrite

If, in the shape data field of type **ParameterControl**, you have specified a read parameter, then you can add the "IncludeWrite" option to allow users to change the parameter value via the associated write parameter.

If, in the shape data field of type **ParameterControl**, you have specified a write parameter, there is no need to specify this "IncludeWrite" option.

### IncludedPids and TableRowFilter

Using the "IncludedPids" and "TableRowFilter" options in **ParameterControlOptions**, you can filter out specific columns and rows when **ParameterControl** refers to a dynamic table.

- Use the "IncludedPids" option to specify the IDs of the columns to be displayed.
- Use the "TableRowFilter" option to filter out specific rows. This is a server-side filter that accepts a semicolon-separated list of PID=value pairs. From DataMiner 10.2.0/10.1.3 onwards, fullfilter syntax is supported for this option (see [Dynamic table filter syntax](xref:Dynamic_table_filter_syntax)).

Examples:

```txt
IncludedPids:111,114|TableRowFilter:114=6*;111=row*
```

- Column filter: Display only the columns with the IDs 111 and 114

- Row filter: Display only the rows for which column 114 has a value starting with 6 and column 111 has a value starting with "row".

```txt
TableRowFilter:106=sl*
```

- Row filter: Display only the rows for which column 106 has a value starting with "sl".

```txt
TableRowFilter:42002 in_range 1/5
```

- Row filter: Display only rows where parameter 42002 has a value between 1 and 5. For this example, advanced dynamic table filter syntax is used. For more information, see [Dynamic table filter syntax](xref:Dynamic_table_filter_syntax).

```txt
TableRowFilter:FULLFILTER=(PK == 0) OR (DK == 1)
```

- Fullfilter syntax (supported from DataMiner 10.1.3 onwards): Display rows for which the primary key is 0 or the display key is 1.

> [!NOTE]
>
> - As "TableRowFilter" is a server-side filter, for discrete parameters you should use the raw values instead of the display values in the filter.
> - In the "TableRowFilter" and "IncludedPIDs" options, you can use placeholders like "\[Param:...\]", "\[Var:...\]", etc. See [Placeholders for variables in shape data values](xref:Placeholders_for_variables_in_shape_data_values).
> - To specify a client-side filter for a table parameter, use the "ClientSideRowFilter" option instead: [ClientSideRowFilter](#clientsiderowfilter).
> - From DataMiner 9.0.3 onwards, strings in table row value filters should be enclosed in single quotes to ensure correct parsing.
> - Note that semicolons are not supported in the fullfilter syntax unless you specify that a different separator than a semicolon applies for the filter (see [About using separator characters](xref:Linking_a_shape_to_a_SET_command#about-using-separator-characters)). E.g. "\[sep:;£\]TableRowFilter:FULLFILTER=(PK == a;b) OR (DK == 1)"

### LedBar

Parameter controls that display analog parameters can be displayed either as a LED bar or as an oscilloscope. The user can switch between the two display modes via the context menu. Specify "LedBar" in the **ParameterControlOptions** to make sure the parameter control is initially displayed as a LED bar.

### Lite

Specify this option if you want to use the "Lite" version of a parameter control. These types of controls occupy less space on the screen as they combine the read and write parameters on a single line.

At present, "Lite" versions are only available for the following types of controls: string, password, numeric, discreet, togglebutton and button.

If you specify this option, you can also add additional options to customize the way the Lite parameter control is displayed:

- [CustomTitle:\[Text\]](#customtitletext)
- [TitleFont](#titlefont)
- [ValueFont](#valuefont)

### MultipleValueSep

In a DataMiner protocol, a column can be linked to a Visio session variable, so that session variables are set upon selection of a table row. In that case, when multiple rows are selected, the default separator is a pipe character ("\|"). With the "MultipleValueSep" option, you can specify a different separator. To do so, add the separator of your choice after "MultipleValueSep=".

For example, to use a semicolon as separator, specify the following:

```txt
MultipleValueSep=;
```

> [!NOTE]
> For more information on how this is configured in the protocol, refer to the "SelectionSetVar" option in the [Developer documentation](https://aka.dataminer.services/DeveloperDocumentation).

### Oscilloscope

Parameter controls that display analog parameters can be displayed either as a LED bar or as an oscilloscope. The user can switch between the two display modes via the context menu. Specify "Oscilloscope" in the **ParameterControlOptions** to make sure the parameter control is initially displayed as an oscilloscope.

### Refresh

See [Adding a Refresh and/or Sort button to a table control](xref:Turning_a_shape_into_a_parameter_control##adding-a-refresh-andor-sort-button-to-a-table-control).

### ShowTableName=true

If the parameter control is based on a table parameter, from DataMiner version 10.0.0 up to 10.0.9, by default the table name is also displayed. This is no longer the case from DataMiner 10.0.10 onwards. To still have the table name displayed from this DataMiner version onwards, add the parameter control option "ShowTableName=true".

### SingleSelection

In a DataMiner protocol, a column can be linked to a Visio session variable, so that session variables are set upon selection of a table row. In that case, you can use this option on the table parameter control to make sure that only a single row can be selected.

> [!NOTE]
> For more information on how this is configured in the protocol, refer to the "SelectionSetVar" option in the [Developer documentation](https://aka.dataminer.services/DeveloperDocumentation).

### Sort

See [Adding a Refresh and/or Sort button to a table control](xref:Turning_a_shape_into_a_parameter_control##adding-a-refresh-andor-sort-button-to-a-table-control).

### Table

See [Adding a filter box to a table control](xref:Turning_a_shape_into_a_parameter_control#adding-a-filter-box-to-a-table-control).

### TitleFont

When you turn a shape into a parameter control of type "Lite", from DataMiner 9.5.4 onwards, you can use the "TitleFont" option to customize the font of the parameter label.

To do so, specify "TitleFont:", followed by one or more of the following font options (default separator: semicolon):

| Option             | Description                                                                        |
| ------------------ | ---------------------------------------------------------------------------------- |
| Family=            | Name of the font (e.g. "Arial")                                                    |
| Size=              | Pixel size of the font (e.g. "18")                                                 |
| Stretch=           | "Normal", "Condensed", or "Expanded"                                               |
| Weight=            | Weight of the font (e.g. "Bold")                                                   |
| Style=             | Style of the font (e.g. "Italic", "Oblique")                                       |
| Underline          | Text is underlined                                                                 |
| BaseLine           | Text is underlined, but the line is closer to the text than when using "Underline" |
| StrikeThrough      | Text has a line drawn through it                                                   |
| Overline           | Text has a line drawn above it                                                     |
| TextFormattingMode | Formatting mode (e.g. "Ideal", "Display")                                          |
| TextRenderingMode  | Rendering mode (e.g. "Auto", "Aliased", "Grayscale", "ClearType")                  |

Example:

| Shape data              | Value                                                                                                                       |
| ----------------------- | --------------------------------------------------------------------------------------------------------------------------- |
| ParameterControlOptions | Lite\|TitleFont:Family=Calibri;Size=32;Stretch=Condensed;Weight=Bold;Style=Italic;Underline\|ValueFont:Family=Arial;Size=14 |

### UpdateSelectionOnLinkedVariables

In a DataMiner protocol, a column can be linked to a Visio session variable, so that session variables are set upon selection of a table row. In that case, you can use this option on the table parameter control to make sure the linked session variables are monitored, and the selected row is updated.

> [!NOTE]
> For more information on how this is configured in the protocol, refer to the "SelectionSetVar" option in the [Developer documentation](https://aka.dataminer.services/DeveloperDocumentation).

### ValueFont

When you turn a shape into a parameter control of type "Lite", from DataMiner 9.5.4 onwards, you can use the "ValueFont" option to customize the font used for the parameter value.

To do so, specify "ValueFont:", followed by one or more of the following font options (default separator: semicolon):

| Option             | Description                                                                        |
| ------------------ | ---------------------------------------------------------------------------------- |
| Family=            | Name of the font (e.g. "Arial")                                                    |
| Size=              | Pixel size of the font (e.g. "18")                                                 |
| Stretch=           | "Normal", "Condensed", or "Expanded"                                               |
| Weight=            | Weight of the font (e.g. "Bold")                                                   |
| Style=             | Style of the font (e.g. "Italic", "Oblique")                                       |
| Underline          | Text is underlined                                                                 |
| BaseLine           | Text is underlined, but the line is closer to the text than when using "Underline" |
| StrikeThrough      | Text has a line drawn through it                                                   |
| Overline           | Text has a line drawn above it                                                     |
| TextFormattingMode | Formatting mode (e.g. "Ideal", "Display")                                          |
| TextRenderingMode  | Rendering mode (e.g. "Auto", "Aliased", "Grayscale", "ClearType")                  |

Example:

| Shape data              | Value                                                                                                                       |
| ----------------------- | --------------------------------------------------------------------------------------------------------------------------- |
| ParameterControlOptions | Lite\|TitleFont:Family=Calibri;Size=32;Stretch=Condensed;Weight=Bold;Style=Italic;Underline\|ValueFont:Family=Arial;Size=14 |
