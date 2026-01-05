---
uid: LineAndAreaChart
---

# Line & area chart

This component displays a line graph that can for example be based on DataMiner trending or on a GQI query.

![Line & area chart](~/dataminer/images/Line_Area_Chart.png)<br>*Line & area chart component in DataMiner 10.4.5*

> [!NOTE]
>
> - If this type of component is added, the time span displayed by the component is available as an output in the *Data* pane, so that this can be applied to other components.
> - From DataMiner 10.2.0 [CU10]/10.3.1 onwards, this component also supports line graphs for string parameters.
> - From DataMiner 10.4.0 [CU11]/10.5.2 onwards<!--RN 41777-->, only the first 1000 items in a line & area chart are shown.

## Configuring the component

To configure the component:

1. [Add data to the component](xref:Adding_data_to_component).

   > [!NOTE]
   >
   > - If a query is used as data, additional configuration is required. See [Configuration with query data](#configuration-with-query-data).
   > - Prior to DataMiner 10.2.0 [CU10]/10.3.1, you can use a table component to pass a line chart by linking *Parameters* and *Indices* data, available in the *Data* pane. From DataMiner 10.2.0 [CU10]/10.3.1 onwards, you only need to link the *Parameters* data of the table to the line chart in order to see the data, similar to when you use a [parameter picker component](xref:DashboardParameterPicker).

1. Optionally, apply a filter:

   - In case parameter data included a parameter based on a protocol, a filter can be used to filter on a specific element.

   - For a table parameter, an *indices* filter is supported.

   - In a system using [Service and Resource Management](xref:About_SRM), you can add resources as data to make the graph display the resource capacity parameters as a stacked trend chart. If you then click the chart and select a point in time, the legend lists all bookings for that specific point in time.

   - From DataMiner 10.2.0/10.1.3 onwards, a [parameter table filter](xref:Parameter_Table_Filters) is supported if the URL option showAdvancedSettings=true is used. This type of filter supports both VALUE and FULLFILTER syntax. For more information on this syntax, see [Dynamic table filter syntax](xref:Dynamic_table_filter_syntax).

   - From DataMiner 10.2.0/10.1.4 onwards, you can select view parameters as a data source to view trending for aggregation rules on specific views. To select these, in the dropdown box for the parameter data source, select *View*.

1. Optionally, customize the following component options in the *Component* > *Settings* pane:

   - *WebSocket settings*: Allows you to customize the polling interval for this component. To do so, clear the checkbox in this section and specify the custom polling interval.

   - *Trend span*: Allows you to customize the time span for which trending is displayed. You can either select a predefined time span or select *Custom* and specify a start and end time.

   - *Value range* > *Fixed minimum*/*Fixed Maximum*: These settings allow you to configure a minimum and/or maximum range for the chart, so that no values outside this range are displayed. The configured range will apply to all lines in the chart, regardless of any particular axis or displayed parameter. By default, no limits are applied.

   - *Minimum visible gap size*: Allows you to specify the minimum duration a gap must have before it is displayed in the graph. By default, this is set to 0.

   - *Trend points*: Available from DataMiner 10.2.0/10.2.3 onwards. Determines which type of trend data points are added to the graph: *Average (changes only)*, *Average (fixed interval)*, or *Real-time*. By default, *Average (changes only)* is selected. This setting will also be taken into account when you export the chart to CSV.

   - *Trend points interval*: Available from DataMiner 10.3.5/10.4.0 onwards, but only if *Trend points* is set to an average type. Determines how much time there is between each trend point that is being tracked or analyzed. This interval is also used when exporting the data. You can set this to *Auto* (i.e. an interval relative to the specified trend span), *Five minutes*, *One hour*, or *One day*.

   - *Show real-time trend data*: If real-time trending is available, this box allows you to set the chart to display real-time trending instead of average trending.

   - *Show average*: Available if *Show real-time trend data* is not selected. Displays the average trend data. By default, this is enabled.

   - *Show minimum*: Available if *Show real-time trend data*/Stack trend lines is not selected. Displays the minimum trend data. By default, this is disabled.

   - *Show maximum*: Available if *Show real-time trend data*/Stack trend lines is not selected. Displays the maximum trend data. By default, this is disabled.

   - *Group by*: In case the component displays trending for multiple parameters, this box allows you to specify how the graphs should be grouped. One graph will be displayed per group. The default setting (from DataMiner 10.3.2/10.4.0 onwards<!-- RN 35160 -->) is *All together*.

     > [!NOTE]
     > View parameters can only be grouped together with other parameters with the option *All together*, otherwise they are placed in a separate group.

   - *Use percentage based values*: This option is only displayed if the component displays resource capacity information. If you select this option, the chart will display percentage values instead of absolute values.

   - *Advanced* > *Hold Ctrl to zoom*: Available from DataMiner 10.4.0 [CU10]/10.5.1 onwards<!--RN 41387-->. Determines whether pressing the Ctrl key is required to zoom in or out.

     - Enabled: Hold Ctrl while scrolling up or down.

     - Disabled: Scroll up or down.

     This setting is disabled by default. See also: [Zooming and panning](#zooming-and-panning).

1. Optionally, fine-tune the component layout. In the *Component* > *Layout* pane, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

   - *Layout*: In case the component will display multiple trend charts, this section allows you to configure how these charts are displayed:

     - *Type*: Determines whether the different charts are displayed next to each other or below each other. However, note that when the charts are viewed on a small screen, they will always be displayed below each other.

     - *Maximum rows per page*: Determines how many charts can at most be displayed below each other on a single page.

     - *Maximum columns per page*: Determines how many charts can at most be displayed next to each other on a single page.

     - *Chart limit*: Determines how many parameters can at most be displayed in one chart. By default, this is set to 16 parameters. From DataMiner 10.4.0 [CU11]/10.5.2 onwards<!--RN 41777-->, regardless of this setting, only the first 1000 parameters can be rendered in a single chart.

     - *Chart limit behavior*: Determines what happens when the number of parameters in the chart exceeds the defined chart limit:

       - *Disable parameters in legend*: The excess parameters are disabled in the chart but remain available in the chart legend, so that they can be enabled again manually. This option is selected by default.

       - *Create additional charts*: Additional charts are displayed that include the parameters that exceed the limit. If necessary, multiple additional charts will be displayed, each respecting the configured limit.

   - *Styling and Information* > *Show title*: Available from DataMiner 10.3.0 [CU19]/10.4.0 [CU7]/10.4.10 onwards<!--RN 40504-->. Determines whether the automatically generated chart title is displayed above the graph. This setting does not override any title that may be configured via the *General* > *Title* setting. Instead, if both settings are enabled, two titles will be shown above the graph. By default, this setting is enabled.

   - *Styling and Information* > *Show range selector*: Determines whether a preview graph is displayed below the main graph, allowing you to easily select a different range.

   - *Styling and Information* > *Line thickness*: Allows you to specify the thickness of the data line in the chart (in pixels).

   - *Styling and Information* > *Highlight lines on hover*: Available from DataMiner 10.2.0/10.1.1 onwards. Determines whether a trend line is highlighted when you hover over the line in the graph or over the corresponding parameter in the trend legend. When a line is highlighted, it gets the thickness determined by the *Highlight line thickness* setting, which becomes available when this option is selected.

     > [!NOTE]
     > If you hover over a parameter in the trend legend, lines on different charts with this same parameter name will also be highlighted. This can be useful to easily compare related lines in different charts.

   - *Styling and Information* > *Enable legend*: Allows you to disable the legend for the line chart. This is especially used for line charts within Group components, in order to avoid duplicate legends.

   - *Styling and Information* > *Expand legend initially*: Select this option to immediately show the trend legend in the component. Otherwise, the legend section is initially collapsed, and you can display it using the arrow icon next to the graph.

   - *Styling and Information* > *Hide non-trended parameters*: Determines whether parameters are shown in the legend of the graph if they have no trend data available. If the option is selected, these parameters are hidden. This option is enabled by default. However, note that it is disabled by default from DataMiner 10.3.9/10.4.0 up to DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4.<!--RN 36869 + 42532--> Prior to DataMiner 10.3.0/10.2.12, this option is named *Hide parameters without trend data in the legend*.

     > [!NOTE]
     > Prior to DataMiner 10.3.9/10.4.0, when a line chart component used element table column parameters as data and indices as filter, it would cross-match indices across the unique elements associated with the table column parameters. This behavior is prevented by disabling the *Hide non-trended parameters* option, enhancing the performance of these visualizations.

   - *Fill graph*: Available from DataMiner 10.2.0/10.1.6 onwards. Select this option to have the space underneath the line filled with the line color.

   - *Stack trend lines*: Available from DataMiner 10.2.0/10.1.6 onwards. Select this option to stack the lines in the graph on top of each other. This option is not compatible with the *Show min/max shading*, *Show minimum* and *Show maximum* options. When you select the *Stack trend lines* option, those options will therefore be disabled and hidden.

   - *Styling and Information* > *Show min/max shading*: Select this option to display a semi-transparent shade above and below the trend line, showing the minimum and maximum trend values. This option can only be used for parameters with average trending and only in case the Y-axis has no discrete values.

   - *Styling and Information* > *Show time range buttons*: Available from DataMiner 10.3.4/10.4.0 onwards. Enables a number of time range buttons that allow you to select one of the preset time ranges: 1 day (last 24 hours), 1 week (last 7 days), 1 month (last 30 days), 1 year (last year), and 5 years (last 5 years). By default, this setting is disabled. <!-- RN 35595 -->

   - *Additional lines* > *Line thickness*: If you select to show any additional lines with the options below, this option becomes available, allowing you to customize the thickness of these lines (in pixels).

   - *Additional lines* > *Show percentile*: Displays a percentile line on the graph. When you select this option, two additional options become available that allow you to configure this percentile line: *Percentile*, which allows you to indicate which percentile should be displayed, and *Percentile line color*.

     > [!NOTE]
     > From DataMiner 10.2.0/10.1.1 onwards, the percentile calculation takes into account how long the parameter had a specific value. This means that if a particular value is present for a longer time than other values, it will get more weight in the calculation. For discrete parameters or graphs showing multiple parameters, no percentile is calculated.

   - *Additional lines* > *Show boundary lines*: Allows you to display one or more boundary lines. You can configure where a line should be displayed by adding a Y-axis value in the *Boundary value* box. The color of a boundary line can be customized in the *Boundary line color* box. The *Add boundary line* option below this allows you to add additional boundary lines. To remove a boundary line, click the x to the right of the line name.

   - *Advanced* \> *Empty Result message*: Available from 10.3.11/10.4.0 onwards<!-- RN 37173 -->. Allows you to specify a custom message that is displayed when a query returns no results.

     > [!TIP]
     > See also: [Displaying a custom empty component message](xref:Tutorial_Dashboards_Displaying_a_custom_empty_component_message).

## Configuration with query data

Query results are supported as data for this component from DataMiner 10.2.9/10.3.0 onwards. To configure the component to use a GQI query as its data:

### [From DataMiner 10.3.0 [CU15]/10.4.0 [CU3]/ 10.4.6 onwards](#tab/tabid-1)

<!--RN 39509-->

1. Create query data. See [Creating a GQI query](xref:Creating_GQI_query).

1. In the *Component* > *Layout* pane, configure the following fields in the *Lines* section:

   - *X-axis column*: The numeric column that should be used for the X-axis data.

   - *Y-axis column*: The numeric column that should be used for the Y-axis data.

   - *Y-axis*: The Y-axis that is used to plot the line.

   > [!NOTE]
   >
   > - Data points are connected by a line in the order they appear in the query result. If you want to create a trend line, make sure the query results are sorted on the desired axis column.
   > - From DataMiner 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7 onwards<!--RN 39586-->, when a chart has data but does not have lines configured, the component will add one line on the default X-axis and Y-axis. The columns are chosen based on the column type and the column name. For example, a column with the name "X" will be chosen for the X value.

1. Optionally, in the *Lines* section, select *+ Add line* to add additional lines to the chart. A maximum of 20 lines can be added to a chart.

   > [!NOTE]
   >
   > - To change the order in which the lines are displayed on the chart and in the tooltip, click the ![*Drag-and-drop*](~/dataminer/images/drag-and-drop.png) button and drag the entry up or down in the *Lines* section.
   > - The lines inherit the colors specified in the data colors or, in versions prior to DataMiner 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7<!--RN 39739-->, the color palette of the component or theme. When all colors are used, the first ones will be assigned again. From DataMiner 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7 onwards<!--RN 39739-->, lines displaying the same data as other components will inherit the same data color by default, instead of using the next color in the theme's data colors.

1. Optionally, configure the following layout settings:

   - *X-axis*: Allows you to rename the default X-axis. This name will be used as the X label in the tooltips.

   - *Y-axis*: Allows you to add and rename Y-axes, with a limit of 10 Y-axes per line & area chart component. This name will be used as the Y label in the tooltips.

     > [!NOTE]
     > To change the order in which the Y-axes are added to the chart, click the ![*Drag-and-drop*](~/dataminer/images/drag-and-drop.png) button and drag the entry up or down in the *Y-axis* section.

   - *Tooltip*: Enables a tooltip that is displayed when you hover the mouse pointer over the chart. The tooltip shows the Y value(s) for the closest X value of any line on the chart. If multiple lines share an X value, both will be shown. The values shown in the tooltip are indicated on the chart with colored dots.

     If the *Tooltip* setting is enabled, you can configure what the tooltip will display:

     - *Tooltip* > *Include x labels* (1): Allows you to include the X-axis labels (i.e. the X-axis names).

     - *Tooltip* > *Include y labels* (2): Allows you to include the Y-axis labels (i.e. the name of the column containing the Y values).

     - *Tooltip* > *Include colors* (3): Allows you to include a small indicator in front of the tooltip that indicates the color of the line.

       ![Tooltip line & area chart](~/dataminer/images/Tooltip_LineAreaChart.png)<br>*Line & area chart component in DataMiner 10.4.6*

### [Prior to DataMiner 10.3.0 [CU15]/10.4.0 [CU3]/ 10.4.6](#tab/tabid-2)

1. Create query data. See [Creating a GQI query](xref:Creating_GQI_query).

1. In the *Component* > *Settings* pane, configure the following fields in the *Dimensions* section:

   - *Query*: The query data you want to use.

   - *X axis*: The column that should be used for the X-axis data.

   - *Y axis*: The column that should be used for the Y-axis data.

   > [!NOTE]
   > Data points are connected by a line in the order they appear in the query result. If you want to create a trend line, make sure the query results are sorted on the desired axis column.

1. Fine-tune the component layout and settings like for a regular line and area chart. See [Configuration](#configuring-the-component).

***

## Export to CSV

It is possible to export the trend data to CSV. To do so, click the ... icon in the top-right corner of the component and select *Export to CSV*. The CSV file will then be generated in the background. To ensure that it is generated correctly, do not change the configuration of the component until the CSV export is completed.

> [!NOTE]
>
> - The separator used in CSV exports is based on the *CSV separator* setting in Cube. If this setting cannot be retrieved, the local browser settings are used instead.
> - From DataMiner 10.3.3/10.4.0 onwards, the *Show average*, *Show minimum*, and *Show maximum* settings are also taken into account when you export a chart to CSV. In addition, if the *Show min/max shading* option is enabled, minimum and maximum values will always be taken into account in the export. <!-- RN 35311 -->
> - Prior to DataMiner 10.5.0 [CU10]/10.6.1<!--RN 43939-->, creating a CSV export of an aggregation parameter is not supported.

## Zooming and panning

From DataMiner 10.3.0 [CU15]/10.4.0 [CU3]/ 10.4.6 onwards<!--RN 39509-->, zooming and panning functionalities are available for the line & area chart component.

### Zooming

- From DataMiner 10.4.0 [CU10]/10.5.1 onwards<!--RN 41387-->, the zooming method depends on the [*Advanced* > *Hold Ctrl to zoom* setting](#configuring-the-component):

  - When this setting is enabled: Hold the Ctrl key while scrolling up or down (up to 10,000 times) to zoom in or out.

  - When this setting is disabled: Scroll up or down (up to 10,000 times) to zoom in or out. This is the default option.

- In versions prior to DataMiner 10.4.0 [CU10]/10.5.1, hold the Ctrl key while scrolling up or down (up to 10,000 times) to zoom in or out.

- When visualized on a mobile device<!--RN 39586-->: Zoom in on the component by placing your thumb and index finger tips together on the screen and moving them apart. To zoom out, use a pinching motion, starting with your fingers apart and bringing them together.

> [!NOTE]
> From DataMiner 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7 onwards<!--RN 39586-->, when you zoom in on a chart [using query data](#configuration-with-query-data), the Y-axis range is dynamically adjusted. As a result, the minimum and maximum Y values change depending on the visible data.

### Panning

- To move left or right across the component, right-click the chart and drag your mouse.

  > [!NOTE]
  > Panning is only possible when the chart is zoomed in, as the default viewport shows all available data.

- When visualized on a mobile device<!--RN 39586-->: Move left or right by sliding one finger across the component.

## Examples

### Trend graph showing DMA KPIs

To add a component to a dashboard to show a basic trend graph with several DMA KPIs:

1. In edit mode, drag the *Line & area chart* visualization to the dashboard.

1. Click the ![Data icon](~/dataminer/images/dashboards_data.png) icon to filter the available data in the *Data* pane.

1. Expand the *Parameters* section in the *Data* pane and specify the element representing the DMA in the *Element* box.

1. Select a parameter you want to display in the graph, and drag it to the graph. Repeat this for each parameter that should be displayed in the graph.

   > [!TIP]
   > Select the *Trended* checkbox at the top of the *Parameters* section to only view parameters for which trending is enabled. Depending on your DataMiner version, you may need to select the filter icon first.
   >
   > ![Parameters section with filter](~/dataminer/images/dashboard_parameter_filter_icon.png)<br>*Parameters section with filter in DataMiner 10.3.11*

1. In the *Settings* pane, in the *Group by* box, select *Element*. This way all KPIs will be shown in the same graph.

![Example of a trend graph shown with a Line & area chart component](~/dataminer/images/dashboard_example_linechart1.png)

### Trend graph showing DMA trend data using profile parameters

To add a component to a dashboard to show a basic trend graph using profile parameters:

1. In edit mode, drag the *Line & area chart* visualization to the dashboard.

1. Click the ![Data icon](~/dataminer/images/dashboards_data.png) icon to filter the available data in the *Data* pane.

1. Expand the *Profile parameters* section in the *Data* pane.

   If you have configured it correctly in DataMiner Cube, there should be a profile parameter linked with a protocol and a trended parameter of the data you want to see.

1. Select the profile parameter you want to display in the graph, and drag it to the graph.

1. Expand the *Elements* section in the *Data* pane, select the element you want to display in the graph, and drag it to the graph.

![Example of a trend graph shown with a Line & area chart component](~/dataminer/images/dashboard_example_linechart2.png)
