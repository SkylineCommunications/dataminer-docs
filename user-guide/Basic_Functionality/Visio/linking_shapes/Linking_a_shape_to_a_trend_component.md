---
uid: Linking_a_shape_to_a_trend_component
---

# Linking a shape to a trend component

Using a shape data field of type **Component**, you can configure a Visio shape to display a trend component.

> [!NOTE]
>
> - It is also possible to turn a shape into a parameter chart instead of linking it to a trend component. See [Creating a parameter chart](xref:Creating_a_parameter_chart).
> - In a Visio trend component, the alarm timeline along the X-axis is only displayed if the graph initially shows only one parameter, and only as long as that parameter is displayed.
> - For examples of use, refer to the view "Linking Shapes" on the [Ziine Demo System](xref:ZiineDemoSystem). The examples can be found on the Visual page _linking > TREND1, TR2_ and _TR3_.
> - In the Monitoring and Dashboards apps, trend components in a visual overview are only supported from DataMiner 10.0.12 onwards.

In this section:

- [Basic shape data configuration](#basic-shape-data-configuration)

- [Configuring session variables to be set from trace points](#configuring-session-variables-to-be-set-from-trace-points)

- [Configuring session variables to be updated with the graph’s time range](#configuring-session-variables-to-be-updated-with-the-graphs-time-range)

- [Creating a trend component with command control](#creating-a-trend-component-with-command-control)

- [Limiting the displayed values to the top/bottom X](#limiting-the-displayed-values-to-the-topbottom-x)

- [Filtering the trend legend](#filtering-the-trend-legend)

## Basic shape data configuration

Add the following shape data fields to the shape:

- **Component**: Set the value of this shape data field to “_Trending_”.

- **Parameters**: Configure this shape data field as follows:

  - For a single trend component, configure the value as follows:

    ```txt
    DmaID:ElementID:ParameterID|...|...
    ```

    To include a table row, configure the value as follows:

    ```txt
    DmaID:ElementID:ParameterID:TableRow|...|...
    ```

    > [!NOTE]
    >
    > - Instead of specifying the DMA ID/Element ID in the **Parameters** shape data field, you can also specify an **Element** shape data field and set it to the element name, and then only list the parameters in the **Parameters** shape data field, separated by pipe characters.
    > - You can use element wildcards, e.g. “_\*:1010:0_” for index 0 on parameter 1010 of a table.
    > - By default no more than 10 results can be displayed if a wildcard is used. If more results are available than this default limit, a notification will be displayed.
    > - From DataMiner 9.5.1 onwards, you can also use a wildcard for the parameter index.
    > - From DataMiner 9.6.8 onwards, this syntax allows the use of element names, \[this element\] placeholders and keys containing forward slashes (e.g. dmaID/elementID).

  - For trend groups, either set the field to “_TrendGroup=username:groupname_” for a private trend group, where username is the name of the user that created the group, or to “_TrendGroup=sharedusersettings:groupname_” for a shared trend group or a read-only group. Set the field to “_\|_” to display an empty trend component.

- **ParametersOptions**: Set the following possible options as the value for this shape data field, using a pipe character (“_\|_”) to separate the options:

  | Option             | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                |
  | ------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
  | CollapseLegend:_X_ | Available from DataMiner 10.0.2 onwards. Determines whether the legend below the trend graph is collapsed by default. “X” can be _true_ or _false_.                                                                                                                                                                                                                                                                                                                                                                                        |
  | Limit:_X_          | While up to DataMiner 9.6.4, at most 10 results can be displayed when a wildcard is used in the _Parameters_ field, from DataMiner 9.6.5 onwards, you can customize this limit using this option, where “X” is the number of values to be shown. For example, if _Limit:2_ is specified, only two values matching the wildcard in the _Parameters_ field will be displayed. <br> However, note that if not all results can be displayed, a notification will only be displayed if more results are available than the default limit of 10. |
  | MinChartHeight=_X_ | Available from DataMiner 10.0.3 onwards.<br> Determines the minimum height of the chart area. By default, the minimum height is always 200 px. To make sure this height is reached, the legend of the trend component will become smaller when necessary, or it may even be hidden. “X” should be set to the number of pixels, e.g. _MinChartHeight=400_.                                                                                                                                                                                  |
  | NavigatorChart:_X_ | Determines if the bottom navigator chart is displayed. “X” can be _true_ or _false_.                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
  | NoWildcard         | Available from DataMiner 9.5.11 onwards. If this option is specified, this will force DataMiner to load the specified index, instead of a filtered set of indexes. <br> This can particularly be of use for cases where an index is not considered to be trended, even though trend data is available, e.g. an index that has trend data in the past but is no longer trended now.                                                                                                                                                         |
  | Range:_X_          | Determines the trend range. “X” can be _Day_, _Week_, _Month_ or _Year_.<br> From DataMiner 10.0.13 onwards, you can configure a custom range in the format _Range:Start=\<dateTimeTextA>,End=\<dateTimeTextB>_. Note that you do not have to specify two time values. You can specify a start time, an end time or both (separated by a comma). The datetime text strings need to be formatted according to the current or invariant culture.                                                                                             |
  | ShowLegend:_X_     | Determines if the bottom legend is displayed, which allows the user to add parameters. “X” can be _true_ or _false_.                                                                                                                                                                                                                                                                                                                                                                                                                       |
  | ShowGroups:_X_     | Determines if the trend groups panel on the left-hand side is displayed. “X” can be _true_ or _false_.                                                                                                                                                                                                                                                                                                                                                                                                                                     |

Example:

| Shape data field  | Value                                                              |
| ----------------- | ------------------------------------------------------------------ |
| Component         | Trending                                                           |
| Parameters        | 221:50670:350                                                      |
| ParametersOptions | Range:Day\|NavigatorChart:false\|ShowLegend:true\|ShowGroups:false |

## Configuring session variables to be set from trace points

From DataMiner 9.5.12 onwards, it is possible to configure a trend component so that a session variable is populated with a trace value when the mouse pointer hovers over a graph.

To configure this, specify the following shape data:

- Add a shape data item of type **SetVar** to the trend component, and set its value to "_ValueTrace:_", "_MinTrace:_", "_MaxTrace:_", or "_TimeTrace:_", followed by the name of the session variable.

- Optionally, to limit the scope of the variable, add a shape data field of type **Options**, and set it to the appropriate scope. For more information, see [Indicating the scope of the variable](xref:Turning_a_shape_into_a_control_to_update_a_session_variable#indicating-the-scope-of-the-variable).

- In case the trend component shows multiple parameters, add a shape data field of type **SetVarOptions** and set it to “_MultipleValueSep=_” followed by a separator of your choice. For more information, see [Creating a multiple checkbox control](xref:Adding_options_to_a_session_variable_control#creating-a-multiple-checkbox-control).

  The session variable will contain a list of trace values, one for each parameter displayed in the trend component, separated by the separator you specified. If you want to display one of those values in another location, you can refer to it using its 0-based index. For example, if you have the minimum trace values stored in the “MinimumValue” session variable, you can use "MinimumValue\[1\]" to refer to the minimum trace value of the second parameter in the trend component legend.

Example of the configuration:

| Shape data field  | Value                                                      |
| ----------------- | ---------------------------------------------------------- |
| Component         | Trending                                                   |
| ParametersOptions | ShowLegend:true                                            |
| Parameters        | \|                                                         |
| SetVar            | ValueTrace:Avg\|MinTrace:Min\|MaxTrace:Max\|TimeTrace:Time |
| Options           | PageVariable                                               |

## Configuring session variables to be updated with the graph’s time range

From DataMiner 10.0.13 onwards, it is possible to configure a trend component so that a session variable is populated with the time range displayed in the graph (i.e. the start time and end time).

To configure this, add a shape data field of type **SetVar**, and set its value to _RangeStart:\<VariableA>\|RangeEnd:\<VariableB>_

Example:

| Shape data field | Value                                        |
| ---------------- | -------------------------------------------- |
| SetVar           | RangeStart:MyRangeVar1\|RangeEnd:MyRangeVar1 |

> [!NOTE]
> The values set in the session variables will be datetime text strings formatted according to the current culture.

## Creating a trend component with command control

From DataMiner 9.5.3 onwards, you can create a special kind of trend component that incorporates a command control. Depending on the configuration, the command control can be used to manipulate one particular component or several components, which can be on the same page, on the same card or anywhere in Cube.

1. Add the following shape data fields to the component shape:

   | Shape data    | Value                                                                                                                                                                                                                   |
   | ------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
   | Component     | Name of the Visio component: _Trending_.                                                                                                                                                                                |
   | CommandPrefix | Optional prefix added to the command name (in the shape containing the command, see below) in case multiple identical commands have to be configured for different instances of the same component (e.g. “\_Left\_\_”). |

2. Add the following shape data fields to the command control shape:

   | Shape data       | Value                                                                                                                                                                                                                                                                                                                                                                              |
   | ---------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
   | Command          | Name of the command to be executed when the shape is clicked. Only one command is possible with a trending component: _SetTrendRange_<br> Optionally, you can include the command prefix specified in the shape of the trending component, e.g. “_Left_SetTrendRange_”.                                                                                                            |
   | CommandParameter | Optional parameters for the command. For the SetTrendRange command, you can specify the following trend ranges:<br> - _Range:Day_ <br> - _Range:Week_ <br> - _Range:Month_ <br> - _Range:Year_                                                                                                                                                                                     |
   | Options          | To turn the shape into a button, specify: _Control=Button_                                                                                                                                                                                                                                                                                                                         |
   | Scope            | The scope of the command:<br> - _Page_ (default): All components that can execute the configured command on the same Visio page.<br> - _Card_: All components that can execute the configured command on all pages of the current Visio file.<br> - _Application_: All components that can execute the configured command anywhere in the client application (e.g. DataMiner Cube) |

### Example

In the following example, the range of the leftmost trend graph component found on the same Visio page as the command shape will be set to “Week” when the command shape is clicked:

- Visio component shape:

  | Shape data    | Value    |
  | ------------- | -------- |
  | Component     | Trending |
  | CommandPrefix | Left\_   |

- Command shape:

  | Shape data       | Value              |
  | ---------------- | ------------------ |
  | Command          | Left_SetTrendRange |
  | CommandParameter | Range:Week         |
  | Options          | Control=Button     |
  | Scope            | Page               |

## Limiting the displayed values to the top/bottom X

From DataMiner 9.6.5 onwards, it is possible to specify that only the top or bottom number of current values of a parameter should be displayed.

To do so, add the **Sort** shape data field, and set it to the following value:

| Value                     | Description                                                                          |
| ------------------------- | ------------------------------------------------------------------------------------ |
| _\[SortOrder\]_,limit:_X_ | \- SortOrder is either _ASC_ or _DESC_.<br> - X is the number of values to be shown. |

To apply both a top and bottom limit at the same time, separate the two values with a pipe (“\|”) character.

For example:

| Shape data field  | Value                      |
| ----------------- | -------------------------- |
| Component         | Trending                   |
| Parameters        | 520/3:270:\*\|520/3:203:\* |
| ParametersOptions | ShowLegend:true            |
| Sort              | ASC,limit:2\|DESC,limit:1  |

## Filtering the trend legend

From DataMiner 10.0.2 onwards, it is possible to filter the available elements in the trending legend based on the value of a property.

To do so, add the **Filter** shape data field, and set it to the following value:

```txt
Property:PropertyName=PropertyValue
```

For example, with the configuration below, the legend will only contain elements that have the property "Class" set to the value "Gold".

| Shape data field  | Value               |
| ----------------- | ------------------- |
| Component         | Trending            |
| Parameters        | \*:100:SLNet\*      |
| ParametersOptions | ShowLegend:true     |
| Filter            | Property:Class=Gold |
