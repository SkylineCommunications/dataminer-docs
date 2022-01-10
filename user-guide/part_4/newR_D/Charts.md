## Charts

This category contains the following visualizations:

- [Column & Bar chart](#column--bar-chart)

- [Bar chart (horizontal)](#bar-chart-horizontal)

- [Line & area chart](#line--area-chart)

- [Pie & donut chart](#pie--donut-chart)

### Column & Bar chart

This chart can be used to display the elements or services in a view that caused the most or the least alarms in a selected time range and were in an alarm state for the longest or the shortest period of time. From DataMiner 10.0.13 onwards, it can also be used to represent any data based on a data query in the form of a bar chart. In that case the bars can represent any number of variables for any set of categories.

> [!NOTE]
> Negative values are only supported in bar chart components from DataMiner 10.1.0/10.1.3 onwards.

To configure the component:

1. Apply a view data feed. See [Applying a data feed](Configuring_dashboard_components.md#applying-a-data-feed).

    From DataMiner 10.0.13 onwards, this component also supports queries as data input. See [Using Queries data input](Configuring_dashboard_components.md#using-queries-data-input).

2. Optionally, you can add a parameter filter, so that the displayed data are limited to that parameter only. to do so, hover the mouse over the component, click the filter icon, and then add a filter feed from the *parameters* section of the data pane.

3. Optionally, customize the following component options in the *Settings* tab:

    - *WebSocket settings*: Allows you to customize the polling interval for this component. To do so, clear the checkbox in this section and specify the custom polling interval.

    - *General* \> *Source*: Determines whether elements or services are displayed.

    - *General* \> *Type*: Determines whether the bar chart is based on the number of alarm events or on the duration of alarm states.

    - *General* \> *Select*: Determines whether the top items (i.e. the items that had the most alarms or were in an alarm state for the longest time) or the bottom items (i.e. the items that had the least alarms or were in an alarm state for the shortest time) are displayed.

    - *General* \> *Limit*: Determines how many elements or services are included in the chart.

    - *General* \> *Time span*: Determines the time range for which the information is retrieved.

    From DataMiner 10.0.13 onwards, if query data input is used, the following settings are available instead:

    - *Label*: Allows you to select which data should be used as a label. Depending on how many different variables are displayed in the chart, several labels can be selected.

    - *Segment size*: Allows you to select which data should determine the size of segments in the chart.

4. Optionally, fine-tune the component layout. In the *Component* > *Layout* tab, the following options are available if the chart is not used with queries data input:

    - The default options available for all components. See [Customizing the component layout](Configuring_dashboard_components.md#customizing-the-component-layout).

    - *Advanced* \> *Include severities*: Allows you to exclude certain severity levels by clearing the checkboxes for those levels.

    - *Chart* > *Reverse data*: By default, the graph displays the number of alarm events or the alarm duration per element. This option allows you to instead display the number of alarm events or the alarm duration per alarm state.

    - *Chart* > *Stack bars*: Determines whether the bars for one particular element or service are stacked in the chart.

    - *Chart* > *Legend*: Determines whether a legend can be displayed. If this option is selected, an arrow icon is displayed in the top right corner of the chart. Clicking this icon will display the legend.

    - *Table* > *Show*: Determines whether a table with detailed information is displayed below the chart.

    - *Table* > *Add totals*: Determines whether a column is displayed within the table with the total number of alarm events or the total alarm duration for each element or service. This option is only available if the *Table* > *Show* option is selected.

    - *Table* > *Add total info*: Determines whether the *Total* column includes the information “alarm events” or “% of time in alarm state”. This option is only available if the *Table* > *Add totals* option is selected.

    The following options are available if the chart is used with queries data input:

    - The default options available for all components. See [Customizing the component layout](Configuring_dashboard_components.md#customizing-the-component-layout).

    - *Advanced \> Chart layout*: Available from DataMiner 10.0.13 onwards. Allows you to choose how the dimensions of the bars are determined. Possible values:

        - *Absolute*: The dimension of each bar is shown as an absolute numeric value.

        - *Relative per category*: The dimension of each bar is shown as a relative percentage compared to other bars representing the different variables for each separate category. (Available from DataMiner 10.1.0/10.1.2 onwards.)

        - *Relative per variable:* The dimension of each bar is shown as a relative percentage compared to other bars representing this variable.

        - *Relative total*: The dimension of each bar is shown as a percentage of the sum of all values. (Available from DataMiner 10.1.0/10.1.2 onwards.)

    - *Advanced \> Chart orientation*: Available from DataMiner 10.0.13 onwards. Determines how the chart is displayed, i.e. from left to right, from right to left, from top to bottom or from bottom to top.

    - *Advanced* \> *Stack bars:* Available from DataMiner 10.1.0/10.1.2 onwards. Stacks the bars on top of each other instead of showing them side by side. This can be especially useful when combined with the *Relative per category* layout.

    - *Legend \> Show Legend*: Available from DataMiner 10.0.13 onwards. Determines whether the legend is displayed.

    - *Legend \> Position*: Available from DataMiner 10.0.13 onwards. If the legend is set to be displayed, this option determines whether it is displayed on the left, on the right, at the top or at the bottom of the visualization.

    - *Tooltips* > *Show Tooltips*: Available from DataMiner 10.0.13 onwards. Determines whether tooltips are displayed.

    - *Tooltips* > *Include label*: Available from DataMiner 10.0.13 onwards. Determines whether the label is included in tooltips.

    - *Tooltips* > *Include dimension*: Available from DataMiner 10.0.13 onwards. Determines whether the dimensions are indicated in tooltips.

    - *Tooltips* > *Include value*: Available from DataMiner 10.0.13 onwards. Determines whether values are indicated in tooltips.

### Bar chart (horizontal)

This chart is the same as the regular bar chart, except that the bars are displayed horizontally.

Aside from the option to stack the bars, which is not available for the horizontal bar chart, it features the same options as the vertical bar chart.

However, note that any features that have been added to the regular bar chart component since DataMiner 10.0.13 are not included in this component. As it is possible to display the regular bar chart component with horizontal bars from that DataMiner version onwards, the Bar chart (horizontal) component will become obsolete.

For more information, see [Column & Bar chart](#column--bar-chart).

### Line & area chart

This component can be used to display a trend graph.

From DataMiner 9.6.13 onwards, it is possible to export the trend data to CSV. To do so, click the ... icon in the top-right corner of the component and select *Export to CSV*. The CSV file will then be generated in the background. To ensure that it is generated correctly, do not change the configuration of the component until the CSV export is completed.

> [!NOTE]
> -  The separator used in CSV exports is based on the *CSV separator* setting in Cube. If this setting cannot be retrieved, the local browser settings are used instead.
> -  From DataMiner 10.0.11 onwards, if a line chart component is added to a dashboard, the time span displayed by the component is available as feed in the data pane, so that this can be applied to other components.

To configure the component:

1. Apply one or more parameter data feeds. See [Applying a data feed](Configuring_dashboard_components.md#applying-a-data-feed).

2. Optionally, apply a filter feed:

    - in case a parameter data feed included a parameter based on a protocol, a filter feed can be used to filter on a specific element.

    - For a table parameter, an *indices* filter feed is supported.

    - From DataMiner 10.0.2 onwards, in a system using Service & Resource Management, you can add resources as a feed to make the graph display the resource capacity parameters as a stacked trend chart. If you then click the chart and select a point in time, the legend lists all bookings for that specific point in time. See [Service and Resource Management](../SRM/SRM.md#service-and-resource-management).

    - From DataMiner 10.2.0/10.1.3 onwards, a parameter table filter feed is supported if the URL option showAdvancedSettings=true is used. This type of filter supports both VALUE and FULLFILTER syntax. For more information on this syntax, see [Dynamic table filter syntax](../../part_2/visio/Dynamic_table_filter_syntax.md).

        > [!NOTE]
        > When you update a filter that is already used in the component, re-add the filter in order to update it in the component.

3. Optionally, customize the following component options in the *Component* > *Settings* tab:

    - *WebSocket settings*: Allows you to customize the polling interval for this component. To do so, clear the checkbox in this section and specify the custom polling interval.

    - *Trend span*: Allows you to customize the time span for which trending is displayed. You can either select a predefined time span or select *Custom* and specify a start and end time.

    - *Value range* > *Fixed minimum*/*Fixed Maximum*: Available from DataMiner 10.0.13 onwards. These settings allow you to configure a minimum and/or maximum range for the chart, so that no values outside this range are displayed. The configured range will apply to all lines in the chart, regardless of any particular axis or displayed parameter. By default, no limits are applied.

    - *Minimum visible gap size*: Allows you to specify the minimum duration a gap must have before it is displayed in the graph. By default, this is set to 0.

    - *Show real-time trend data*: If real-time trending is available, this box allows you to set the chart to display real-time trending instead of average trending.

    - *Show average*: Available from DataMiner 10.0.13 onwards, if *Show real-time trend data* is not selected. Displays the average trend data. By default, this is enabled.

    - *Show minimum*: Available from DataMiner 10.0.13 onwards, if *Show real-time trend data*/Stack trend lines is not selected. Displays the minimum trend data. By default, this is disabled.

    - *Show maximum*: Available from DataMiner 10.0.13 onwards, if *Show real-time trend data*/Stack trend lines is not selected. Displays the maximum trend data. By default, this is disabled.

    - *Group by*: In case the component displays trending for multiple parameters, this box allows you to specify how the graphs should be grouped. One graph will be displayed per group.

    - *Use percentage based values*: This option is only displayed if the component displays resource capacity information. If you select this option, the chart will display percentage values instead of absolute values.

4. Optionally, fine-tune the component layout. In the *Component* > *Layout* tab, the following options are available:

    - The default options available for all components. See [Customizing the component layout](Configuring_dashboard_components.md#customizing-the-component-layout).

    - *Layout*: In case the component will display multiple trend charts, this section allows you to configure how these charts are displayed:

        - *Type*: Determines whether the different charts are displayed next to each other or below each other. However, note that when the dashboard is used on a small screen, they will always be displayed below each other.

        - *Maximum rows per page*: Determines how many charts can at most be displayed below each other on a single page.

        - *Maximum columns per page*: Determines how many charts can at most be displayed next to each other on a single page.

        - *Chart limit*: Determines how many parameters can at most be displayed in one chart. By default, this is set to 16 parameters.

        - *Chart limit behavior*: Available from DataMiner 10.0.13 onwards. Determines what happens when the number of parameters in the chart exceeds the defined chart limit:

            - *Disable parameters in legend*: The excess parameters are disabled in the chart but remain available in the chart legend, so that they can be enabled again manually. This option is selected by default, and is also the default behavior prior to DataMiner 10.0.13.

            - *Create additional charts*: Additional charts are displayed that include the parameters that exceed the limit. If necessary, multiple additional charts will be displayed, each respecting the configured limit.

    - *Styling and Information* > *Show range selector*: Determines whether a preview graph is displayed below the main graph, allowing you to easily select a different range.

    - *Styling and Information* > *Line thickness*: Allows you to specify the thickness of the data line in the chart (in pixels).

    - *Styling and Information* > *Highlight lines on hover*: Available from DataMiner 10.2.0/10.1.1 onwards. Determines whether a trend line is highlighted when you hover over the line in the graph or over the corresponding parameter in the trend legend. When a line is highlighted, it gets the thickness determined by the *Highlight line thickness* setting, which becomes available when this option is selected.



        > [!NOTE]
        > If you hover over a parameter in the trend legend, lines on different charts with this same parameter name will also be highlighted. This can be useful to easily compare related lines in different charts.



    - *Styling and Information* > *Enable legend*: Allows you to disable the legend for the line chart. This is especially used for line charts within Group components, in order to avoid duplicate legends.

    - *Styling and Information* > *Expand legend initially*: Select this option to immediately show the trend legend in the component. Otherwise, the legend section is initially collapsed and you can display it using the arrow icon next to the graph.

    - *Styling and Information* > *Hide parameters without trend data in the legend*: Available from DataMiner 10.0.9 onwards. Determines whether parameters are shown in the legend of the graph if they have no trend data available. By default, this option is selected, so that these parameters are hidden.

    - *Fill graph*: Available from DataMiner 10.2.0/10.1.6 onwards. Select this option to have the space underneath the line filled with the line color.

    - *Stack trend lines*: Available from DataMiner 10.2.0/10.1.6 onwards. Select this option to stack the lines in the graph on top of each other. This option is not compatible with the *Show min/max shading*, *Show minimum* and *Show maximum* options. When you select the *Stack trend lines* option, those options will therefore be disabled and hidden.

    - *Styling and Information* > *Show min/max shading*: Select this option to display a semi-transparent shade above and below the trend line, showing the minimum and maximum trend values. This option can only be used for parameters with average trending and only in case the Y-axis has no discrete values.

    - *Additional lines* > *Line thickness*: If you select to show any additional lines with the options below, this option becomes available, allowing you to customize the thickness of these lines (in pixels).

    - *Additional lines* > *Show percentile*: Displays a percentile line on the graph. When you select this option, two additional options become available that allow you to configure this percentile line: *Percentile*, which allows you to indicate which percentile should be displayed, and *Percentile line color*.



        > [!NOTE]
        > From DataMiner 10.2.0/10.1.1 onwards, the percentile calculation takes into account how long the parameter had a specific value. This means that if a particular value is present for a longer time than other values, it will get more weight in the calculation. For discrete parameters or graphs showing multiple parameters, no percentile is calculated.



    - *Additional lines* > *Show boundary lines*: Allows you to display one or more boundary lines. You can configure where a line should be displayed by adding a Y-axis value in the *Boundary value* box. The color of a boundary line can be customized in the *Boundary line color* box. The *Add boundary line* option below this allows you to add additional boundary lines. To remove a boundary line, click the x to the right of the line name.

### Pie & donut chart

This component is introduced in DataMiner 10.0.13 with the purpose of displaying the results of queries in a chart shaped like a pie or donut.

To configure the component:

1. Apply a query data feed. See [Using Queries data input](Configuring_dashboard_components.md#using-queries-data-input).

2. Optionally, customize the following component options in the *Component* > *Settings* tab:

    - *Label*: Allows you to select which data should be used as a label.

    - *Segment size*: Allows you to select which data should determine the size of segments in the chart.

3. Optionally, fine-tune the component layout. In the *Component* > *Layout* tab, the following options are available:

    - *Chart shape*: Can be set to *Pie* or *Donut*.

    - *Legend \> Show Legend*: Available from DataMiner 10.0.13 onwards. Determines whether the legend is displayed.

    - *Legend \> Show Legend*: Available from DataMiner 10.0.13 onwards. If the legend is set to be displayed, this option determines whether it is displayed on the left, on the right, at the top or at the bottom of the visualization.

    - *Tooltips* > *Show Tooltips*: Available from DataMiner 10.0.13 onwards. Determines whether tooltips are displayed.

    - *Tooltips* > *Include label*: Available from DataMiner 10.0.13 onwards. Determines whether the label is included in tooltips.

    - *Tooltips* > *Include dimension*: Available from DataMiner 10.0.13 onwards. Determines whether the dimensions are indicated in tooltips.

    - *Tooltips* > *Include value*: Available from DataMiner 10.0.13 onwards. Determines whether values are indicated in tooltips.

    - *Tooltips* > *Include percentages*: Available from DataMiner 10.0.13 onwards. Determines whether percentages are indicated in tooltips.
