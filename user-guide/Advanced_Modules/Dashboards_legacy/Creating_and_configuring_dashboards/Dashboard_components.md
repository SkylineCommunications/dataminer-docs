---
uid: Dashboard_components
---

# Dashboard components

The available dashboard components are divided in seven groups, according to what they represent.

## Aggregation components

This group consists of the following components:

- [Aggregation](#aggregation)

- [Aggregation bar graph](#aggregation-bar-graph)

- [Aggregation pie graph](#aggregation-pie-graph)

- [Aggregation trend graph](#aggregation-trend-graph)

- [Aggregation graph filters](#aggregation-graph-filters)

> [!NOTE]
> The Aggregation components can only be used when the DMA is licensed for Correlation.

> [!TIP]
> See also:
> [Working with aggregation rules](xref:Working_with_aggregation_rules)

### Aggregation

Overview of data for one or more aggregation rules in one or more views.

Component-specific options:

- *View*: A view feed for the dashboard, which makes it possible to dynamically set a view from the feed selector on the dashboard page or in the URL.

- *Highlight important values*: Select this option to give important values a colored background in the overview.

### Aggregation bar graph

Bar graph representing the aggregated values for one or more aggregation rules in one or more views. Optionally, a filter can be specified for any of the rules. For more information on these filters, see [Aggregation graph filters](#aggregation-graph-filters).

Component-specific options:

- *Group by*: Select one of the different available grouping options: by *View*, *Protocol*, *Property* or *Table Column*.

- *Views*: Select one or more views to apply a view filter to the bar graph.

- *Feed view*: A view feed for the dashboard, which makes it possible to dynamically set a view from the feed selector on the dashboard page or in the URL.

- *Include sub-views*: Select this option to also include child views of the selected views.

- *Show legend*: Select this option to display a legend explaining which colors match which aggregation rules.

- *Stacked bars*: Select this option to allow the bars to stack on top of each other.

- *Shadow*: Select this option to display a shadow effect.

- *Show point labels*: Select this option to show labels at the top of each bar.

- *Show mouseover labels*: Select this option to show labels when the mouse pointer passes over a bar.

- *Orientation*: Select whether the bars should be displayed horizontally or vertically.

- *Bar margin*, *Bar width*, and *X-axis labels angle*: Adjust these settings to fine-tune the layout of the graph.

- *Background color*: Click the ellipsis button to choose a different background color for the graph.

### Aggregation pie graph

Pie chart representing the aggregated values for one or more aggregation rules in one or more views. Optionally, a filter can be specified for any of the rules. For more information on these filters, see [Aggregation graph filters](#aggregation-graph-filters).

Component-specific options:

- *Views*: Select one or more views to apply a view filter to the pie graph. This option is no longer available from DataMiner 9.5.2 onwards. Instead, a view feed can be added to select a single view.

- *Feed view*: A view feed for the dashboard, which makes it possible to dynamically set a view from the feed selector on the dashboard page or in the URL.

- *Include sub-views*: Select this option to also include child views of the selected views. This option is no longer available from DataMiner 9.5.2 onwards.

- *Show legend*: Select this option to display a legend explaining which colors match which aggregation rules.

- *Show data labels*: Select this option to show labels on the slices.

- *Shadow*: Select this option to display a shadow effect.

- *Fill slices*: Select this option to fill each slice; otherwise only the outline of the slice will be colored.

- *Slice margin*, *Line width*, *Data label threshold*, and *Data label position factor*: Adjust these settings to fine-tune the layout of the pie chart.

- *Background color*: Click the ellipsis button to choose a different background color for the graph.

### Aggregation trend graph

Trend graph representing one or more aggregation rules in one or more views. The feed for this component consists of one or more groups of aggregation rules. The groups can be given a custom range. Optionally, a filter can be specified for any of the rules. For more information on these filters, see [Aggregation graph filters](#aggregation-graph-filters).

Component-specific options for each added aggregation rule:

- *Graph style*: Select one of the available styles in the drop-down list to change what kind of graph line is used.

- *Graph color*: Click the ellipsis button to choose a different color for the graph.

- *Graph width*: Enter a different value to adjust the graph width.

- *Graph fill*: Select this option to fill the area underneath the graph.

    > [!NOTE]
    > The *Graph fill* option cannot be used together with the *Error bars* option.

- *Initially visible*: Clear this option in order to not show the graph immediately. Instead a legend will be shown where the graph can be enabled.

Other component-specific options:

- *Views*: Select one or more views to apply a view filter to the graph.

- *Include sub-views*: Select this option to also include child views of the selected views.

- *Trend range*: Select the time range of the trend graph in the drop-down list. If you select *Custom*, an additional box will appear where you can fill in the number of hours that should be represented in the trend graph.

- *Type of trend data*: Select either average or real-time trending.

- *Show range selection*: To allow the user to set the range of the graph, select either *Show Range* or *Show Custom Date Picker*. The former will display drop-down list where the user can select different time ranges, the latter will allow the user to enter a custom range.

- *Plotter*: Select how the graph should be plotted in the drop-down list. You can choose a regular graph, or a stacked graph, multi-column bars or stacked bars.

- *Show parameter checkboxes*: Select this option to display a *Parameters* button above the graph that allows the user to select what aggregation rules are displayed. The checkboxes also allow the user to display the average and apply linear regression to the graph.

- *Show legend*: Select this option to display a legend explaining what color matches what view.

- *Show min, max, avg in legend*: If you have selected to display a legend, select this option to also display the minimum, maximum and average values in the legend.

- *Show save icon*: Select this option to display a save icon above the graph that allows the user to download the graph as an image file.

- *Step plot*: Select this option to display a step graph.

- *Error bars*: Select this option to display error bars for each point between the minimum and maximum value. (Only available if the default plotter is used.)

- *Fill graphs*: Select this option to fill the area underneath the graph line. This option is not compatible with the *Error Bars* option above.

- *Bottom chart*: Select this option to display a preview graph underneath the main graph, which provides the same functionality as the preview graph in the *Trending* module.

- *Always show date on X-axis*: Select this option to show the date next to the values on the X-axis.

- *Legend separate lines*: Select this option to put new lines between the labels in the legend.

- *Legend always visible*: If this option is enabled, the legend will remain displayed even when the mouse pointer does not hover over the graph. In that case, the legend just presents the parameter name without a value. This can be useful to allow the user to scroll to a particular parameter in the legend, in order to then view the value for this parameter when hovering the mouse pointer over the graph.

- *Show legend upon mouseover*: In the drop-down list, select where the legend should be displayed when the mouse pointer passes over the graph: as an overlay over the graph, next to the graph, or below the graph.

- *Average history duration*: Enter a unit for the number of trend ranges to take in account for the calculation of the average history trend. The average history trend line will then be displayed as a dotted line on the graph. If “0” is entered, this option is disabled.

- *Overlay legend width*, *Minimum visible gap size, Y-axis label width*, *Axis label font size*, etc.: Adjust these settings to fine-tune the layout of the trend graph.

- *Background color*: Click the ellipsis button to choose a different background color for the graph.

### Aggregation graph filters

In all aggregation graph components, filters can be specified, similar to the filters that can be used throughout DataMiner Cube to get data from a table.

These filters can be specified in two ways:

- You can enter any value, for example “myvalue”. DataMiner will automatically translate this to a filter of the type “value=PK == myvalue\*”.

- You can specify a column filter directly, for example “value=4010 == myvalue\*”, where 4010 is the column parameter ID of the table.

  For aggregation, the following column value IDs can be used:

  - *4010* = property value (when grouping by property)

  - *4009* = protocol value (when grouping by protocol)

  - *4005* = value

  - *4004* = remote pk

  - *4003* = view ID

  - *4002* = rule ID

  - *4001* = PK (= ruleID.viewID\[.protocol\]\[.property\].remote pk - with \[\] being optional depending on the rule configuration.)

## Alarms components

This group consists of the following components:

- [Alarm count element](#alarm-count-element-alarms)

- [Alarm count service](#alarm-count-service-alarms)

- [Alarm list](#alarm-list-alarms)

- [Alarm state element](#alarm-state-element-alarms)

- [Alarm state service](#alarm-state-service-alarms)

### Alarm count element (alarms)

Pie chart showing the number of alarms for an element during the last 24 hours.

Component-specific options:

- *Show legend*: Select this option to display a legend with the alarm severities.

- *Show data labels*: Select this option to show labels on the slices.

- *Shadow*: Select this option to display a shadow effect.

- *Fill slices*: Select this option to fill each slice; otherwise only the outline of the slice will be colored.

- *Slice margin*, *Line width*, *Data label threshold*, and *Data label position factor*: Adjust these settings to fine-tune the layout of the pie chart.

- *Background color*: Click the ellipsis button to choose a different background color for the graph.

### Alarm count service (alarms)

Pie chart showing the number of alarms for a service during the last 24 hours. This component has the same component-specific options as the *Alarm count element* component described above.

### Alarm list (alarms)

Overview of active alarms or alarms in a recent fixed or sliding window.

Component-specific options:

- *Mode*: Select the mode for the alarm list in the drop-down list. You can choose to display active alarms, or history alarms in different time ranges.

- *Highlight time*: Enter the number of seconds you want new alarms to be highlighted.

- *History tracking*: Select this option to show only the most recent alarm of an alarm’s life cycle. To show the alarm history as separate alarm records in the list instead, clear the selection.

- *Group by element*: Select this option to group the alarms by element.

- *Group by service*: Select this option to group the alarms by service.

- *Minimal alarm level*: In the drop-down list, select the minimum alarm level of alarms displayed in the list.

- *Advanced filter*: In this box, you can enter an alarm filter to limit what alarms are shown in the list. For more information on alarm filters, see [Alarm filters](xref:Alarm_filters).

    For example, for an alarm filter called “Major”, which is a shared filter, enter the following:

    ```xml
    <Major (shared filter)>
    ```

    It is also possible to combine multiple filters using “or”. For example

    ```xml
    <Major (shared filter)> or <open alarms (shared filter)>
    ```

- *Feed filter*: In this box, enter a parameter, element, service, view or protocol feed to limit the alarms shown in the list.

    The filter feed can also be used when the alarm list is part of a dynamic list type dashboard. In that case, the feed filter will be combined with the selection for the current row. This allows e.g. a dynamic list dashboard to iterate over elements and to show an element-limited dashboard for each of the elements.

    > [!TIP]
    > See also:
    > [Creating a dashboard with a dynamic list layout](xref:Creating_a_dashboard_with_a_dynamic_list_layout)

- *Column Order*: Use the arrows next to each column to change the order in which the columns will appear. It is also possible to add additional columns, e.g. the *Active time*, which is the time since the alarm has been generated.

- *Appearance*: In the drop-down list, select the type of list you want to display.

- *Toggle buttons*: Add or remove different options to have these displayed as buttons above the component, which the user can click to change the mode of the alarm list.

### Alarm state element (alarms)

Pie chart displaying the percentage of time an element has been in each alarm state during the last 24 hours. This component has the same component-specific options as the *Alarm count element* component described above.

### Alarm state service (alarms)

Pie chart displaying the percentage of time a service has been in each alarm state during the last 24 hours. This component has the same component-specific options as the *Alarm count element* component described above.

## DataMiner Agent components

### DataMiner time

Displays the current DMA time.

Component-specific options:

- *Text*: Enter text in this box in order to have it displayed in front of the DataMiner time.

### Visual overview view

Displays the Visual Overview for a particular view, which depends on a view feed.

Component-specific options:

- *Interactive*: Select this option to enable interactive components in the Visual Overview.

- *Show page selector*: Select this option to display a selection box above the component that can be used to navigate to different pages of the Visual Overview.

- *Automatically refresh*: Enter the refresh rate for the Visual Overview in this box. By default, this is set to 60 seconds. To disable the automatic refresh, set the rate to 0.

## DataMiner element components

This group consists of the following components:

- [Alarm count element](#alarm-count-element-element)

- [Alarm state element](#alarm-state-element-element)

- [Alarm state service](#alarm-state-service-element)

- [All monitored parameters](#all-monitored-parameters-element)

- [Data Display page](#data-display-page-element)

- [Element state LED](#element-state-led-element)

- [Reporter severity legend](#reporter-severity-legend-element)

- [Visual overview element](#visual-overview-element-element)

> [!NOTE]
> From DataMiner 9.5.1 onwards, not only elements can be used in the feeds for these components, but also enhanced services, i.e. services that use a service protocol.

### Alarm count element (element)

Pie chart showing the number of alarms for an element during the last 24 hours.

Component-specific options:

- *Show legend*: Select this option to display a legend with the alarm severities.

- *Show data labels*: Select this option to show labels on the slices.

- *Shadow*: Select this option to display a shadow effect.

- *Fill slices*: Select this option to fill each slice; otherwise only the outline of the slice will be colored.

- *Slice margin*, *Line width*, *Data label threshold*, and *Data label position factor*: Adjust these settings to fine-tune the layout of the pie chart.

- *Background color*: Click the ellipsis button to choose a different background color for the graph.

### Alarm state element (element)

Pie chart displaying the percentage of time an element has been in each alarm state during the last 24 hours. This component has the same component-specific options as the *Alarm count element* component described above.

### Alarm state service (element)

Pie chart displaying the percentage of time a service has been in each alarm state during the last 24 hours. This component has the same component-specific options as the *Alarm count element* component described above.

### All monitored parameters (element)

Displays an alarm status indicator for each of the monitored parameters of an element.

Component-specific options:

- *More performance / less graphical*: select this option to use objects that require less resources in order to optimize performance.

### Data Display page (element)

Includes a Data Display page for a particular element in a dashboard. Different layout options are available, and parameter controls can be enabled or disabled.

Component-specific options:

- *Appearance*: Select the style of the data display page in the drop-down list.

- *Display 'Set parameter' controls*: Select this option to enable users to set the value of write parameters.

### Element state LED (element)

Displays a LED with the color of the element’s alarm severity.

Component-specific options:

- *Display element name*: Select this option to display the element name in the component.

- *GUI style*: Select *More performance* to use objects that require less resources, or *More graphical* if performance is not an issue.

- *Limit to parent service*: If the dashboard is service-specific, select this option to limit the displayed element state to the part of the element integrated in the service, instead of showing the overall element state.

### Reporter severity legend (element)

A legend for reporter graphs.

### Visual overview element (element)

Displays the Visual Overview for a particular element, which depends on an element feed.

Component-specific options:

- *Interactive*: Select this option to enable interactive components in the Visual Overview.

- *Show page selector*: Select this option to display a selection box above the component that can be used to navigate to different pages of the Visual Overview.

- *Automatically refresh*: Enter the refresh rate for the Visual Overview in this box. By default this is set to 60 seconds. To disable the automatic refresh, set the rate to 0.

> [!NOTE]
> The Visual Overview settings of the Administrator account are applied. See [Visual Overview settings](xref:User_settings#visual-overview-settings).

## DataMiner parameter components

This group consists of the following components:

- [All monitored parameters](#all-monitored-parameters-parameter)

- [Data Display page](#data-display-page-parameter)

- [Generic real-time parameter](#generic-real-time-parameter-parameter)

- [Generic real-time parameter](#generic-real-time-parameter-parameter)

- [Histogram](#histogram-parameter)

- [Parameter state LED](#parameter-state-led-parameter)

- [Set parameter](#set-parameter-parameter)

- [Spectrum thumbnail](#spectrum-thumbnail-parameter)

- [Table column bar graph](#table-column-bar-graph-parameter)

- [Trend histogram parameter](#trend-histogram-parameter-parameter)

- [Trend parameter](#trend-parameter-parameter)

- [Trend parameter with history](#trend-parameter-with-history-parameter)

- [Trend parameter with reference value](#trend-parameter-with-reference-value-parameter)

- [Trend sparkline](#trend-sparkline-parameter)

- [Trend statistics](#trend-statistics-parameter)

### All monitored parameters (parameter)

Displays an alarm status indicator for each of the monitored parameters of a given element.

Component-specific options:

- *More performance / less graphical*: select this option to use objects that require less resources in order to optimize performance.

### Data Display page (parameter)

Includes a Data Display page for a particular element in a dashboard. Different layout options are available, and parameter controls can be enabled or disabled.

Component-specific options:

- *Appearance*: In the drop-down list, you can select several layout options, such as gridlines or alternating background color.

- *Display 'Set parameter' controls*: Select this option to allow users to view and set parameter values.

### Generic real-time parameter (parameter)

Displays a parameter, optionally with the parameter name, the parameter value, or the parameter set control.

For a table parameter, you can select one or more columns in order to show only these, and apply a row filter if necessary, e.g. *SL\**. In the dashboard, it will then be possible to sort the columns by clicking the column header. You can also link the Parameter index to another, existing *Generic real-time parameter* component in the dashboard, by selecting *\<Link to \[name other component\]\>* in the *IDX* drop-down list.

Component-specific options:

- *Display parameter name*: Enable this option to display the parameter name.

- *Show parameter IDX part*: For table parameters, enable this option to show the parameter index.

- *Show parameter table name part*: Enable this option to display the table name part of a column parameter name.

- *Display parameter value*: Enable this option to display the current parameter value on the component.

- *Display table quick filter*: Select this option to have a filter box shown above a table parameter.

- *Slider style*: In the drop-down list, choose a style for the slider, depending on whether you need to optimize performance or not.

- *Display 'Set parameter' control*: Select this option to allow users to view and set parameter values.

- *Display range*: Select this option to display the parameter range on the slider.

- *Custom slider width*: Adjust this value to change the width of the slider.

### Histogram (parameter)

A histogram visualizing parameter values. You can set a custom range and interval amount, as well as several options for the appearance of the histogram.

Component-specific options:

- *Histogram range*: If you do not want the range to be automatically selected, select *Manual* in the drop-down list, and then enter the minimum and maximum of the histogram range.

- *Histogram interval amount*: Enter the number of histogram class intervals in this box. By default, this is set to 20.

- *Stacked bars*: Select this option to allow the bars to stack on top of each other.

- *Show percentages*: Select this option to show values as percentages instead of absolute values.

- *Shadow*: Select this option to display a shadow effect.

- *Show point labels*: Select this option to show labels at the top of each bar.

- *Show mouseover labels*: Select this option to show labels when the mouse pointer passes over a bar.

- *Legend*: Select this option to display a legend next to the histogram.

- *Orientation*: Select whether the bars should be displayed horizontally or vertically.

- *Bar margin*, *Bar width*, and *X-axis labels angle*: Adjust these settings to fine-tune the layout of the histogram.

- *Background color*: Click the ellipsis button to choose a different background color for the histogram.

### Parameter state LED (parameter)

Displays a LED with the color of the parameter’s alarm severity.

Component-specific options:

- *Linked dashboard*: Specify a dashboard in the *Feed* box to create a link to this dashboard.

- *Display element name*: Enable this option to display the element name.

- *Display parameter name*: Enable this option to display the parameter name.

- *Show parameter IDX part*: For table parameters, enable this option to show the parameter index.

- *Show parameter table name part*: Enable this option to display the table name part of a column parameter name.

- *GUI style*: In the drop-down list, choose a style for the component, depending on whether you need to optimize performance or not.

### Set parameter (parameter)

Allows dashboard users to change the value of a parameter.

Component-specific options:

- *Display parameter name*: Enable this option to display the parameter name.

- *Show parameter IDX part*: For table parameters, enable this option to show the parameter index.

- *Display element name*: Enable this option to display the element name.

### Spectrum thumbnail (parameter)

Displays the most recent measurement for a spectrum monitor buffer.

Component-specific options:

- *Buffer to display*: If available, you can select a buffer in the drop-down list for it to be displayed in the thumbnail.

### Table column bar graph (parameter)

Displays the data of selected table column parameters in either a vertical or horizontal bar graph. The table column parameters must be part of one single table in one single element.

Component-specific options for each added table column parameter:

- *Graph color*: Click the ellipsis button to choose a different color for the graph.

- *Visible*: Clear the selection from this option to make the table column parameter hidden.

- *Sort*: Sorts the graph by this table column parameter. This option can also be applied on a hidden table column parameter.

    > [!NOTE]
    > The *Sort* option should only be selected for one column parameter, as otherwise it wil not work.

Component-specific options:

- *Sort*: Determines whether sorting happens in ascending or descending order.

- *Limit amount of values*: Allows you to limit the number of rows that are taken into account for the graph. This can for instance be used in combination with sorting in order to only show the “top x” or “bottom x” of a particular table column. (Available from DataMiner 9.5.13 onwards.)

- *Range*: If you do not want the range to be automatically selected, select *Manual* in the drop-down list, and then enter the minimum and maximum of the bar graph range.

- *Stacked bars*: Select this option to allow the bars to stack on top of each other.

- *Shadow*: Select this option to display a shadow effect.

- *Show point labels*: Select this option to show labels at the top of each bar.

- *Show mouseover labels*: Select this option to show labels when the mouse pointer passes over a bar.

- *Legend*: Select this option to display a legend explaining which colors match which table columns.

- *Bar margin*, *Bar width*, and *X-axis labels angle*: Adjust these settings to fine-tune the layout of the graph.

- *Background color*: Click the ellipsis button to choose a different background color for the graph.

- *Orientation*: Select whether the bars should be displayed horizontally or vertically.

### Trend histogram parameter (parameter)

A histogram representing trend data for one or more parameters.

Component-specific options for each added parameter:

- *Graph style*: Select one of the available styles in the drop-down list to change what kind of graph line is used.

- *Graph color*: Click the ellipsis button to choose a different color for the graph.

- *Graph width*: Enter a different value to adjust the graph width.

- *Graph fill*: Select this option to fill the area underneath the graph.

    > [!NOTE]
    > The *Graph fill* option cannot be used together with the *Error bars* option.

- *Initially visible*: Clear this option in order to not show the graph immediately. Instead a legend will be shown where the graph can be enabled.

Other component-specific options:

- *Trend range*: Select the time range of the trend graph in the drop-down list. If you select *Custom*, an additional box will appear where you can fill in the number of hours that should be represented in the trend graph.

- *Type of trend data*: Select either average or real-time trending.

- *Show range selection*: To allow the user to set the range of the histogram, select either *Show range* or *Show custom date picker*. The former will display a drop-down list where the user can select different time ranges, the latter will allow the user to enter a custom range.

- *Plotter*: Select how the graph should be plotted in the drop-down list. You can choose a regular graph, or a stacked graph, multi-column bars or stacked bars.

- *Histogram range*: If you do not want the range to be automatically selected, select *Manual* in the drop-down list, and then enter the minimum and maximum of the histogram range.

- *Histogram interval amount*: Enter the number of histogram class intervals in this box. By default, this is set to 20.

- *Show percentages*: Select this option to show values as percentages instead of absolute values.

- *Show parameter checkboxes*: Select this option to display a *Parameters* button above the histogram that allows the user to select which parameters are displayed. The checkboxes also allow the user to display the average and apply linear regression to the graph.

- *Show legend*: Select this option to display a legend next to the histogram.

- *Show parameter IDX part*: For table parameters, enable this option to show the parameter index.

- *Show parameter table name part*: Enable this option to display the table name part of a column parameter name.

- *Show min, max, avg in legend*: If you have selected to display a legend, select this option to also display the minimum, maximum and average values in the legend.

- *Show save icon*: Select this option to display a save icon above the histogram that allows the user to download the histogram as an image file.

- *Fill graphs*: Select this option to fill the area underneath the graph.

- *Bottom chart*: Select this option to display a preview graph underneath the histogram.

- *Legend separate lines*: Select this option to put new lines between the labels in the legend.

- *Legend always visible*: If this option is enabled, the legend will remain displayed even when the mouse pointer does not hover over the graph. In that case, the legend just presents the parameter name without a value. This can be useful to allow the user to scroll to a particular parameter in the legend, in order to then view the value for this parameter when hovering the mouse pointer over the graph.

- *Show legend upon mouseover*: In the drop-down list, select where the legend should be displayed when the mouse pointer passes over the histogram: as an overlay over the histogram, next to the histogram, or below the histogram.

- *Overlay legend width*, *Y-axis label width*, *Axis label font size*, etc.: Adjust these settings to fine-tune the layout of the histogram.

- *Background color*, *Axis line color*, and *Axis label color*: Click the ellipsis buttons to choose different colors for the components of the histogram.

### Trend parameter (parameter)

A custom trend graph for one or more parameters.

Component-specific options for each added parameter:

- *Graph style*: Select one of the available styles in the drop-down list to change what kind of graph line is used.

- *Graph color*: Click the ellipsis button to choose a different color for the graph.

- *Graph width*: Enter a different value to adjust the graph width.

- *Graph fill*: Select this option to fill the area underneath the graph.

    > [!NOTE]
    > The *Graph fill* option cannot be used together with the *Error bars* option.

- *Initially visible*: Clear this option in order to not show the graph immediately. Instead a legend will be shown where the graph can be enabled.

Other component-specific options:

- *Trend range*: Select the time range of the trend graph in the drop-down list. If you select *Custom*, an additional box will appear where you can fill in the number of hours that should be represented in the trend graph.

- *Type of trend data*: Select either average or real-time trending.

- *Show range selection*: To allow the user to set the range of the trend graph, select either *Show range* or *Show custom date picker*. The former will display a drop-down list where the user can select different time ranges, the latter will allow the user to enter a custom range.

- *Plotter*: Select how the graph should be plotted in the drop-down list. You can choose a regular graph, or a stacked graph, multi-column bars or stacked bars.

- *Show parameter checkboxes*: Select this option to display a *Parameters* button above the graph that allows the user to select which parameters are displayed. The checkboxes also allow the user to display the average and apply linear regression to the graph.

- *Show legend*: Select this option to display a legend below the trend graph.

- *Show parameter IDX part*: For table parameters, enable this option to show the parameter index.

- *Show parameter table name part*: Enable this option to display the table name part of a column parameter name.

- *Show min, max, avg in legend*: If you have selected to display a legend, select this option to also display the minimum, maximum and average values in the legend.

- *Show save icon*: Select this option to display a save icon above the graph that allows the user to download the graph as an image file.

- *Error bars*: Select this option to display error bars for each point between the minimum and maximum value. (Only available if the default plotter is used.)

- *Fill graphs*: Select this option to fill the area underneath the graph. This option is not compatible with the *Error Bars* option above.

- *Bottom chart*: Select this option to display a preview graph underneath the main graph, which provides the same functionality as the preview graph in the *Trending* module.

- *Always show date on X-axis*: Select this option to show the date next to the values on the X-axis.

- *Legend separate lines*: Select this option to put new lines between the labels in the legend.

- *Legend always visible*: If this option is enabled, the legend will remain displayed even when the mouse pointer does not hover over the graph. In that case, the legend just presents the parameter name without a value. This can be useful to allow the user to scroll to a particular parameter in the legend, in order to then view the value for this parameter when hovering the mouse pointer over the graph.

- *Show legend upon mouseover*: In the drop-down list, select where the legend should be displayed when the mouse pointer passes over the graph: as an overlay over the graph, next to the graph, or below the graph.

- *Average history duration*: Enter a unit for the number of trend ranges to take in account for the calculation of the average history trend. The average history trend line will then be displayed as a dotted line on the graph. If “0” is entered, this option is disabled.

- *Minimum visible gap size, Overlay legend width*, *Y-axis label width*, *Axis label font size*, etc.: Adjust these settings to fine-tune the layout of the graph.

- *Background color*, *Axis line color*, and *Axis label color*: Click the ellipsis buttons to choose different colors for the components of the graph.

> [!NOTE]
> If there are exception values in a trend graph, these are displayed below the trend graph, while in the graph itself gaps will be displayed.

### Trend parameter with history (parameter)

A custom trend graph for one parameter, with additional history information.

This component has the same options as the *Trend parameter* component above, with a few additional options as to the colors used in the graph. Different line colors are available, as well as fill colors when the value is higher or lower than the reference and fill colors for exceptions.

### Trend parameter with reference value (parameter)

A custom trend graph for two parameters, where one of the two is used as a reference.

This component has the same options as the *Trend parameter with history* component above, with the following additional options:

- *Reference value source*: In the drop-down list, select whether another parameter should be used as reference, or a fixed value. If you choose the latter, enter the fixed value in the *Fixed reference value* box below.

- *Step plot*: Select this option to display a step graph.

### Trend sparkline (parameter)

A simplified trend graph, which shows trend data for a parameter in a particular time range as a simple image.

Component-specific options:

- *Trending type*: Select the trend range in the drop-down list.

- *Graph height*: Enter the height of the graph in pixels. By default this is set to 40.

- *Fill graph*: Select this option to fill the area below the graph.

- *Graph color*: Click the ellipsis button to choose a different color for the graph.

### Trend statistics (parameter)

Displays the min/max/avg value for a trended parameter over the specified time.

## DataMiner service components

This group consists of the following components:

- [Alarm count service](#alarm-count-service-service)

- [All monitored service parameters](#all-monitored-service-parameters-service)

- [Generic real-time service parameter](#generic-real-time-service-parameter-service)

- [Reporter severity legend](#reporter-severity-legend-service)

- [Service parameter state LED](#service-parameter-state-led-service)

- [Service parameter trend sparkline](#service-parameter-trend-sparkline-service)

- [Service parameter trend statistics](#service-parameter-trend-statistics-service)

- [Service state LED](#service-state-led-service)

- [Service trend parameter](#service-trend-parameter-service)

- [Set service parameter](#set-service-parameter-service)

- [Visual overview service](#visual-overview-service-service)

### Alarm count service (service)

Pie graph showing the number of alarms for a service during the last 24 hours.

Component-specific options:

- *Show legend*: Select this option to display a legend with the alarm severities.

- *Show data labels*: Select this option to show labels on the slices.

- *Shadow*: Select this option to display a shadow effect.

- *Fill slices*: Select this option to fill each slice; otherwise only the outline of the slice will be colored.

- *Slice margin*, *Line width*, *Data label threshold*, and *Data label position factor*: Adjust these settings to fine-tune the layout of the pie chart.

- *Background color*: Click the ellipsis button to choose a different background color for the graph.

### All monitored service parameters (service)

Displays an alarm status indicator for each of the monitored parameters of a service.

Component-specific options:

- *More performance / less graphical*: select this option to use objects that require less resources in order to optimize performance.

### Generic real-time service parameter (service)

Displays a parameter, optionally with the parameter name, the parameter value, or the parameter set control.

Component-specific options:

- *Parameter name*: In this box, enter a wildcard through which the service parameter can be found.

- *Parameter index*: In case of a table parameter, enter the display key of the row in this box.

- *Display parameter name*: Enable this option to display the parameter name.

- *Show parameter IDX part*: For table parameters, enable this option to show the parameter index.

- *Display parameter value*: Enable this option to display the current parameter value on the component.

- *Slider style*: In the drop-down list, choose a style for the slider, depending on whether you need to optimize performance or not.

- *Display 'Set parameter' control*: Select this option to allow users to view and set parameter values.

### Reporter severity legend (service)

A legend for reporter graphs.

### Service parameter state LED (service)

Displays a LED with the color of the alarm severity of a service parameter.

Component-specific options:

- *Linked dashboard*: Specify a dashboard in the *Feed* box to create a link to this dashboard. Placeholders like \[this service\] and \[param:dmaid/eid:pid:dispidx\] are allowed in the configuration.

- *Parameter name*: In this box, enter a wildcard through which the service parameter can be found.

- *Parameter index*: In case of a table parameter, enter the display key of the row in this box.

- *Display element name*: Select this option to display the element name in the component.

- *Display parameter name*: Enable this option to display the parameter name.

- *Show parameter IDX part*: For table parameters, enable this option to show the parameter index.

- *GUI style*: Select *More performance* to use objects that require less resources, or *More graphical* if performance is not an issue.

### Service parameter trend sparkline (service)

A simplified trend graph, which shows trend data for a service parameter in a particular time range as a simple image.

Component-specific options:

- *Parameter name*: In this box, enter a wildcard through which the service parameter can be found.

- *Parameter index*: In case of a table parameter, enter the display key of the row in this box.

- *Trending type*: Select the trend range in the drop-down list.

- *Graph height*: Enter the height of the graph in pixels. By default, this is set to 40.

- *Fill graph*: Select this option to fill the area below the graph.

- *Graph color*: Click the ellipsis button to choose a different color for the graph.

### Service parameter trend statistics (service)

Displays the min/max/avg value for a trended parameter over the specified time.

Component-specific options:

- *Parameter name*: In this box, enter a wildcard through which the service parameter can be found.

- *Parameter index*: In case of a table parameter, enter the display key of the row in this box.

### Service state LED (service)

Displays a LED with the color of the service’s alarm severity.

Component-specific options:

- *Linked dashboard*: Specify a dashboard in the *Feed* box to create a link to this dashboard. Placeholders like \[this service\] and \[param:dmaid/eid:pid:dispidx\] are allowed in the configuration.

- *Display element name*: Select this option to display the service name in the component.

- *GUI style*: Select *More performance* to use objects that require less resources, or *More graphical* if performance is not an issue.

### Service trend parameter (service)

A trend graph for a service parameter.

Component-specific options:

- *Parameter name*: In this box, enter a wildcard through which the service parameter can be found.

- *Parameter index*: In case of a table parameter, enter the display key of the row in this box.

- *Trend range*: Select the trend range in the drop-down list. If you select *Custom*, an additional box will appear where you can fill in the number of hours that should be represented in the trend graph.

- *Graph only*: Select this option to hide the X- and Y-axis, and only show the graph itself.

- *Graph color*: Click the ellipsis button to choose a different color for the graph.

- *Graph aspect ratio*: Enter a different value in the box to change the width-to-height ratio of the graph.

### Set service parameter (service)

Allows dashboard users to change the value of a service parameter.

Component-specific options:

- *Parameter name*: In this box, enter a wildcard through which the service parameter can be found.

- *Parameter index*: In case of a table parameter, enter the display key of the row in this box.

- *Display parameter name*: Enable this option to display the parameter name.

- *Show parameter IDX part*: For table parameters, enable this option to show the parameter index.

- *Display element name*: Select this option to display the element name in the component.

### Visual overview service (service)

Displays the Visual Overview for a particular service, optionally with interactive functionality and page selector.

Component-specific options:

- *Interactive*: Select this option to enable interactive components in the Visual Overview.

- *Show page selector*: Select this option to display a selection box above the component that can be used to navigate to different pages of the Visual Overview.

- *Automatically refresh*: Enter the refresh rate for the Visual Overview in this box. By default this is set to 60 seconds. To disable the automatic refresh, set the rate to 0.

> [!NOTE]
> The Visual Overview settings of the Administrator account are applied. See [Visual Overview settings](xref:User_settings#visual-overview-settings).

## Other components

This group consists of the following components:

- [DataMiner map](#dataminer-map)

- [Feed info](#feed-info)

- [Feed selector](#feed-selector)

- [Generic text part](#generic-text-part)

- [Google gadget](#google-gadget)

- [Group](#group)

- [Image component](#image-component)

- [Inline frame](#inline-frame)

- [Video](#video)

### DataMiner map

Displays a DataMiner map. See [Displaying a DataMiner Map in a DataMiner dashboard](xref:Displaying_a_DataMiner_Map_in_a_DataMiner_dashboard).

### Feed info

Displays information about the dashboard feed.

Component-specific options:

- *Type*: In the drop-down list, select the type of information to be displayed (e.g. Current selection, Element name, Protocol name, ...)

- *Style*: In the drop-down list, select whether to display the feed info as normal text or as a title.

### Feed selector

Adds a drop-down list allowing the dashboard user to change the feed directly on the dashboard page.

### Generic text part

Displays custom text.

Component-specific options:

- *Text size*: Enter a number to determine the size of the font.

- *Bold*: Select this option to make the text bold.

- *Underlined*: Select this option to underline the text.

- *Text*: In this box, enter the text that is to be displayed in the component.

### Google gadget

This component was used in older versions of DataMiner to add a Google Gadget to the dashboard.

However, from November 2013 onwards, iGoogle Gadgets are no longer available. For this reason, this component is also no longer available in the *Dashboards* app from DataMiner version 8.5.6 onwards.

### Group

Places a group of components within a custom layout. The group includes components currently used in the dashboard, which are then only shown in the group.

Component-specific options:

- *Width*: In this box, enter the width of the component in pixels. If you enter *-1*, the zone width will be used.

- *Height*: In this box, enter the height of the component in pixels.

- *Included Components*: In the drop-down list select the currently used components you want to include in the group. An included component will no longer be visible outside the group.

- *Regions*: Click the *Edit Regions* button to modify the location of the components included in the group.

### Image component

Displays an image on the dashboard.

Component-specific options:

- *Image*: Click the ellipsis button to browse to the image you want to display.

- *Alternate text*: In this box, enter the text that should be shown instead of the image in a browser that does not support images.

- *Image width*: In the box, fill in the width of the component in pixels.

- *Image height*: In the box, fill in the height of the component in pixels.

- *Image alignment*: In the drop-down list, select how the image should be aligned.

### Inline frame

Displays a website in an inline frame.

Optionally, a feed can be used with this component. This can for instance be of use to dynamically include the value of a parameter in the URL. To do so, select a parameter feed, and include *%parametervalue%* in the URL. This will then be replaced with the value of that parameter.

> [!NOTE]
>
> - If a table column parameter is included, and the dashboard also contains a *Generic real-time parameter* component that is configured with a table parameter, then it is possible to link the parameter index of the *Inline frame* component with that component. In that case, when a user clicks a row of that table, the *Inline frame* component will update the URL with the parameter value of the clicked row. For more information, see [Generic real-time parameter](#generic-real-time-parameter-parameter).
> - From DataMiner 9.5.5 onwards, webpages displayed in an *Inline frame* component automatically have an authentication ticket attached as a URL parameter, so that it is not necessary to log in again on web apps that run on the same DMA as the Dashboards app, including the DataMiner Monitoring & Control app, DataMiner Ticketing and DataMiner Maps.

Component-specific options:

- *URL*: In the box, fill in the URL of the website that should be displayed in the frame.

    > [!NOTE]
    > From DataMiner 9.5.5 onwards, the URL can contain the placeholder *%elementname%*. When the component is rendered, this placeholder will be resolved with the URL-encoded element name specified in the parameter feed, if any.

- *Custom height*: In the box, fill in the height of the component in pixels

- *Fixed width*: In the box, fill in the width of the component in pixels. If no value is filled in, the width will be adjusted automatically.

### Video

Displays a video stream, based on an image URL. The configuration of the thumbnail is similar to the configuration of video thumbnails in Visual Overview. For more information on supported formats, see [Linking a shape to a video thumbnail](xref:Linking_a_shape_to_a_video_thumbnail).

Optionally, a feed can be used with this component. This can for instance be of use to dynamically include the value of a parameter in the image URL. To do so, select a parameter feed, and include *%parametervalue%* in the URL. This will then be replaced with the value of that parameter.

> [!NOTE]
> If a table column parameter is included, and the dashboard also contains a *Generic real-time parameter* component that is configured with a table parameter, then it is possible to link the parameter index of the *Video* component with that component. In that case, when a user clicks a row of that table, the video component will update the URL with the parameter value of the clicked row, which makes it possible to show thumbnails of another video source. For more information, see [Generic real-time parameter](#generic-real-time-parameter-parameter).

Component-specific options:

- *Image URL*: In the box, fill in the URL of the video stream.

- *Frames per second*: In the box, specify how many times the image should update per second. By default, this is set to *20*.

- *Movie width*: In the box, fill in the width of the component in pixels.

> [!TIP]
> See also:
> [Linking a shape to a video thumbnail](xref:Linking_a_shape_to_a_video_thumbnail)
