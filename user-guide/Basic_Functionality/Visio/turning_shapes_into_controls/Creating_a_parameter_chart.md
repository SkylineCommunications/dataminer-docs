---
uid: Creating_a_parameter_chart
---

# Creating a parameter chart

Using **Parameters** and **ParametersOptions** shape data fields, you can make a shape or a group of shapes visualize one or more parameters in a chart.

With the **Parameters** shape data field, you specify which parameters should be included, and with the **ParametersOptions** shape data field, you determine how the information for these parameters is displayed.

> [!NOTE]
>
> - This feature only works in DataMiner Cube.
> - Up to DataMiner 8.5, the number of parameters that can be displayed in a Visio chart is limited to 10. From DataMiner 9.0.1/9.0.0 CU2 onwards, the maximum number of parameters has increased to 15.
> - Alternatively, you can link a shape to a trend component instead. See [Linking a shape to a trend component](xref:Linking_a_shape_to_a_trend_component).
> - For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[controls > PIE/BAR CHART]* page.

## Configuring the shape data fields

The chart can consist of one single shape or of several shapes that are grouped together. In the latter case, usually a different shape is used for the title component, the chart component and the legend component.

> [!TIP]
> See also: [Grouping shapes](xref:Grouping_shapes)

To configure the shapes:

1. If there is only one shape, add a shape data field of type **Parameters** to it.

   If there are several shapes that are grouped, add a shape data field of type **Parameters** to the group.

1. Set the value of the **Parameters** shape data field to the parameters you wish to display, using the following syntax:

   ```txt
   DmaID:ElementID:ParameterID|...|...
   ```

   For table parameters, you can add a table row filter as follows:

   ```txt
   DmaID:ElementID:ParameterID:TableRowFilter|...|...
   ```

   For example, to display a chart showing the CPU load percentages of all processes of which the name starts with "sl" (i.e. all DataMiner processes) from "Microsoft Platform" element 20838 on DMA ID 17, specify the following:

   ```txt
   17:20838:107:SL*
   ```

   If you specify multiple parameter IDs, separate them by means of pipe characters ("\|").

   > [!NOTE]
   >
   > - In the value of the shape data field, you can use placeholders to refer to e.g. session variables. For example: "219:341:114:\[Var:MyVariable\]\|219:341:114:\[Var:MyOtherVariable\]".
   > - From DataMiner 9.0.3 onwards, strings in table row value filters should be enclosed in single quotes to ensure correct parsing.
   > - From DataMiner 9.6.8 onwards, this syntax allows the use of element names, \[this element\] placeholders and keys containing forward slashes (e.g. dmaID/elementID).

1. If there is only one shape, add a shape data field of type **ParametersOptions** to it.

   If there are several shapes that are grouped, add a shape data field of type **ParametersOptions** to the group.

1. Set the value of this **ParametersOptions** shape data field to the chart type, and add any applicable options, separated from the chart type and from each other by pipe characters.

   ```txt
   ChartType|Option|...
   ```

   For an overview of the different chart types you can specify, refer to [Chart types](#chart-types). For an overview of the different options you can specify, refer to [ChartType options](#charttype-options).

1. If the chart consists of a group of shapes, add a shape data field of type **ParametersOptions** to each of the individual shapes, and set its value to the appropriate chart component each time:

   | Value  | Description               |
   | ------ | ------------------------- |
   | TITLE  | The caption of the chart. |
   | CHART  | The chart itself.         |
   | LEGEND | The legend of the chart.  |

   > [!NOTE]
   >
   > - The title in the title component will only be automatically displayed if the option "Title:\<your title>" is specified in the **ParametersOptions** shape data field of the group, and an asterisk has been added in the title shape. Alternatively, you can also manually specify the title within the title shape.
   > - If the parameter description is the same for all displayed parameters in the chart, the legend will not mention the duplicate parameter descriptions.
   > - From DataMiner 9.5.13 onwards, this shape data field supports dynamic placeholders like \[Param:...\], \[Var:...\].

> [!NOTE]
> For more information on how the font of the chart or its components is determined, refer to [Determining the font used in the chart](#determining-the-font-used-in-the-chart).

## Chart types

| Chart type            | Description                                                                  |
| --------------------- | ---------------------------------------------------------------------------- |
| COLUMNCHART           | A chart displaying real-time values as vertical blocks.                      |
| BARCHART              | A chart displaying real-time values as horizontal blocks.                    |
| PIECHART              | A chart displaying real-time values as sections of a circle.                 |
| STACKEDAREACHART      | A chart displaying real-time values as areas stacked on top of each other.   |
| STACKEDAREACHARTAVG   | A chart displaying average values as areas stacked on top of each other.     |
| STACKEDBARCHART       | A chart displaying real-time values as bars stacked on top of each other.    |
| STACKEDBARCHARTAVG    | A chart displaying average values as bars stacked on top of each other.      |
| STACKEDCOLUMNCHART    | A chart displaying real-time values as columns stacked on top of each other. |
| STACKEDCOLUMNCHARTAVG | A chart displaying average values as columns stacked on top of each other.   |

Make sure that all parameters you specify in the **Parameters** shape data field have the kind of trending data that is required for the specified chart type. In particular, for any of the "stacked" chart types without the "AVG" suffix, real-time trending data must be available, and for the "stacked" chart types with the "AVG" suffix, average trending data must be available.

Visio charts of type "area" are updated automatically at regular intervals.

- The update interval is proportional to the range of the chart.

  Example: A chart showing the average trending of the last hour will have an update interval of 5 minutes. A chart showing the real-time trending of the last 5 minutes will have an update interval of 1 minute.

- The first update interval is different from the later update intervals, because the intervals are fixed chronometric increments.

## ChartType options

Below, you can find the options that can be specified in the **ParametersOptions** shape data field for a parameter chart (after the chart type).

- **CUSTOMONLY**:

  Use this option to have the numeric axis show only the aliases specified in the CUSTOMYAXIS option.

- **CUSTOMYAXIS**:

  Use this option to specify a list of aliases for numeric axis values.

  Syntax:

  ```txt
  CUSTOMYAXIS:doubleValue1;customValue1#doubleValue2;customValue2#…
  ```

  Example:

  ```txt
  CustomYAxis:0;NOTHING#20;SMALL#40;MEDIUM#60;LARGE#80;HUGE
  ```

- **DisableTableKeys**:

  Specify this option if you do not want the legend of the chart to show table keys of column parameters.

- **DisplayColumnID:ParameterID**

  Use this option for a parameter chart that displays data stored in a dynamic table, if you want the text of the chart labels to be retrieved from another column in that dynamic table than the index or display key column. This option is available from DataMiner 9.0.5 onwards.

  Example:

  ```txt
  COLUMNCHART|Range:Hour|DisplayColumnID:123
  ```

- **MAX:value**:

  Use this option to set the maximum value of the numeric axis.
  
  Examples:

  ```txt
  MAX:100
  Max:89.5
  max=75
  ```

- **MIN:value**:

  Use this option to set the minimum value of the numeric axis.
  
  Examples:

  ```txt
  MIN:0
  Min:10.5
  min=25
  ```

- **NoAxisLabels**:

  Specify this option if you do not want the chart to have axis labels.

  Example:

  ```txt
  STACKEDAREACHARTAVG|NoAxisLabels
  ```

- **Range**:

  The default range of a chart is

  - "5 minutes" (in case of real-time trending)
  - "Hour" (in case of average trending)

  If you want to override those default settings, use the "Range:" option to set the range to one of the following options:

  - Hour (real-time or average)
  - Day (real-time or average)
  - Week (average only)
  - Month (average only)

  Example:

  ```txt
  STACKEDAREACHARTAVG|Range:Week
  ```

  > [!CAUTION]
  > Be careful when you use the "Month" option.
  >
  > - The TimeSpan1DayRecords interval should be set in *MaintenanceSettings.xml* (which is not set by default). If this interval is not set, then the system will fall back to the TimeSpan1HourRecords interval. See [MaintenanceSettings.xml](xref:MaintenanceSettings_xml).
  > - Do not include multiple parameters of which the TimeSpan1DayRecords interval has not been set.

- **ThemeForeground**:

  To set a specific foreground color for a parameter chart, specify this option, followed by the color. The color can be specified as a color name or as a hexadecimal RGB value (#rgb, #rrggbb, #aarrggbb).

  Examples:

  ```txt
  ThemeForeground:White
  ThemeForeground:#FFFFFFFF
  ```

  > [!NOTE]
  > For more information on the possible color names, refer to the following website: <https://msdn.microsoft.com/en-us/library/system.windows.media.brushes_properties(v=vs.110).aspx>

- **Title:**

  Determines the title that will be displayed in the title component of the chart. In the title component shape, an asterisk ("\*") should be added to make sure the title will be displayed.

- **VisualizeExceptions**

  With this option, you can determine whether the display value of exception values in real-time charts is shown in a label. It can be set to "VisualizeExceptions=true" (default behavior) or "VisualizeExceptions=false". Available from DataMiner 10.2.0/10.1.6 onwards.

## Determining the font used in the chart

From DataMiner v8.5.8 onwards, parameter charts inherit the font properties of the shape by default. However, for this to be enabled, the shape must contain some text.

The following restrictions also apply:

- If the configured font is not installed on the DataMiner Cube client, the default font is used instead.
- The Monitoring app will use the font if it is installed on the server.
- All basic font properties are taken from the shape, including the color. However, the option "ThemeForeground" overrides the text color. See [ThemeForeground:](xref:Creating_a_parameter_chart).
- A shape can only use one single font. If multiple fonts are applied to different pieces of text in a particular shape, then that shape will use the first font that was applied to it.
