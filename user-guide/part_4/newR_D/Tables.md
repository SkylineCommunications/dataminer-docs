## Tables

This category contains the following visualizations:

- [Alarm table](#alarm-table)

- [Parameter table](#parameter-table)

- [Pivot table](#pivot-table)

- [Table](#table)

### Alarm table

> [!WARNING]
> This feature is in preview until DataMiner 10.1.5. If you use the preview version of the feature, its functionality may be different from what is described below. For more information, see [Soft-launch options](https://community.dataminer.services/documentation/soft-launch-options/).

This component is available in soft launch from DataMiner 9.6.8 onwards, if the soft-launch option *ReportsAndDashboardsAlarmList* is enabled. From DataMiner 10.2.0/10.1.5 onwards, it is available without the soft-launch option.

The component displays a list of alarms or information events, which can be filtered in multiple ways.

To configure the component:

1. In the *Settings* tab, configure which type of alarms should be displayed and how:

    - To customize the polling interval for this component, expand the *Settings* \> *Websocket settings* section, clear the checkbox in this section, and specify the custom polling interval.

    - In the *Show* box, select whether active alarms, masked alarms, history alarms, alarms in a sliding window or information events should be displayed in the list.

        In case you select history alarms, the start time and end time will also need to be specified. In case you select alarms in a sliding window, the sliding window size and refresh time will need to be configured.

    - Optionally, specify a filter for the list with the *Filters* boxes. You can either configure a filter of your own, or select *Saved filter* to use an existing shared alarm filter from the DMS. If you select to use a *Parameter index* filter, you can use “?” and “\*” as wildcards (see [Searching with wildcard characters](../../part_1/GettingStarted/Searching_in_DataMiner_Cube.md#searching-with-wildcard-characters)).

    - Optionally, specify the *Default sorting column*, *Default sorting order* and *Initial number of alarms to load*.

        > [!NOTE]
        > If an initial number of alarms to load is specified, no grouping is applied.

    - Below *Columns*, you can select one or more columns in order to have only those columns displayed in the alarm list. For each column, arrow buttons will be displayed that allow you to customize the column order.

    - In the *Group by* box, you can select the column by which the alarms or information events should be grouped.

    - Under *Match parameter index data filter when*, you can fine-tune how a parameter index data filter will be applied. With the default *Equals* setting, the index will need to match the filter exactly. Select *Contains* if the index should instead only contain the filter. <br>This only applies to index data filters added from the data pane, not to filters configured in the *Settings* tab.

2. Optionally, fine-tune the component layout. In the *Component* > *Layout* tab, the following options are available:

    - The default options available for all components. See [Customizing the component layout](Configuring_dashboard_components.md#customizing-the-component-layout).

    - *Expand on hover*: If this option is selected, and not all data within the component can be shown in the available space, the component will expand across other dashboard components when you hover the mouse pointer over it in order to show as much data as possible.

3. Optionally, apply a data filter. Element, parameter, index, service and view data can be used as a filter. Various feed components, such as a parameter feed and time range feed, can also be used as a filter. <br>See [Applying a data feed](Configuring_dashboard_components.md#applying-a-data-feed).

### Parameter table

Displays a data table of an element.

To configure the component:

1. Apply a table parameter data feed. See [Applying a data feed](Configuring_dashboard_components.md#applying-a-data-feed).

2. Optionally, hover the mouse over the component, click the filter icon, and then add a filter feed from the *indices* section of the data pane. You can repeat this several times in order to filter on several indices.

3. Optionally, customize the following component options in the *Component* > *Settings* tab:

    - *WebSocket settings*: Allows you to customize the polling interval for this component. To do so, clear the checkbox in this section and specify the custom polling interval.

    - *Filter*: To limit the displayed data, specify an advanced table filter in this box. For more information on the supported filter syntax, see [Dynamic table filter syntax](../../part_2/visio/Dynamic_table_filter_syntax.md).

4. Optionally, fine-tune the component layout. In the *Component* > *Layout* tab, the following options are available:

    - The default options available for all components. See [Customizing the component layout](Configuring_dashboard_components.md#customizing-the-component-layout).

    - *Expand on hover*: If this option is selected, and not all data within the component can be shown in the available space, the component will expand across other dashboard components when you hover the mouse pointer over it in order to show as much data as possible.

### Pivot table

This component displays a status report for a number of parameters of the elements using the selected protocol and protocol version.

From DataMiner 9.6.13 onwards, it is possible to export this status report to CSV. To do so, click the ... icon in the top-right corner of the component and select *Export to CSV*. The CSV file will then be generated in the background. To ensure that it is generated correctly, do not change the configuration of the component until the CSV export is completed.

> [!NOTE]
> - EPM data and discrete values are only supported in this component from DataMiner 9.6.13 onwards. Mediation protocols are only supported from DataMiner 10.0.6 onwards.
> - The separator used in CSV exports is based on the *CSV separator* setting in Cube. If this setting cannot be retrieved, the local browser settings are used instead.

To configure the component, from DataMiner 9.6.12 onwards:

1. Apply a data feed. See [Applying a data feed](Configuring_dashboard_components.md#applying-a-data-feed).

    This component requires a parameter feed based on *Protocol* or *Element*, or a group of parameters from a *Parameter* feed component.

    - In case a protocol parameter feed is used, you can add an additional element or view feed as a filter.

    - In case an element parameter feed is used, you can add an additional view feed as a filter.

    - If a table parameter feed is used, you can an additional indices feed as a filter.

2. In the *Settings* tab, you can fine-tune the component:

    - *Auto-expand rows*: Depending on the added data, the pivot table can consist of rows that can be expanded to view all data related to that row. If this option is selected, these rows will be expanded automatically.

    - *Items to include*: Allows you to configure which information should be included in the table and where it should be displayed.

    - *Add trend statistics*: Adds trend statistics (minimum, average and maximum values) to the component, if trending is enabled for the selected parameters.

        If this option is selected, a trend statistics row is included in the *Items to include* section, allowing you to determine where the statistics are displayed. In addition, a *Trend span* option will be displayed, allowing you to select a different time span for which statistics are displayed.

        > [!NOTE]
        > A pivot table that displays trend statistics can use a time range feed as a filter.

    - *Limit*: Determines how many rows (i.e. indices) or elements can be displayed. If a particular number “X” is specified, only the X first rows or elements that are retrieved from the server will be displayed.

    - *Filter*: In case a table column parameter feed is used, this box allows you to specify a table row filer. To combine multiple filters, use a semicolon, e.g. *SLA\*;SLP\**.

    - *Conditions*: Allows you to add conditions, so that for example an element is only displayed if a particular parameter has a particular value.

    - *Sort*: Available from DataMiner 10.0.13 onwards. Allows you to select a protocol (if the pivot table contains multiple protocols) and parameter by which the table should be sorted.

    - *Sort* > *Sort ascending*: Available from DataMiner 10.0.13 onwards. Determines the order in which the pivot table is sorted. If you clear this checkbox, it is sorted in descending order.

        > [!NOTE]
        > Using the sort settings in conjunction with the *Limit* setting, you can create a top X or bottom X list.

3. Optionally, fine-tune the component layout. See [Customizing the component layout](Configuring_dashboard_components.md#customizing-the-component-layout).

To configure the component, up to DataMiner 9.6.11:

1. Apply a data feed. See [Applying a data feed](Configuring_dashboard_components.md#applying-a-data-feed).

    This component requires a parameter feed based on *Protocol* or *Element*.

2. If you add a table parameter, also add the table indices. To do so:

    1. Hover the mouse over the component and click the groups icon ( ![](../../images/NewRD_Groups.png) ).

    2. Drag the *indices* group from the *Data* tab to the component.

3. In the *Settings* tab, apply the following settings if necessary:

    - *Auto-expand rows*: In case a table parameter has been added to the component, the table will consist of the various rows in the table, which can be expanded to show each of the elements matching the input data. If this option is selected, the rows will be expanded automatically.

    - In the *Advanced* section, if a table parameter was added, you can limit the displayed number of indices with the following settings:

        - *Row filter*: Allows you to specify a filter mask so that only certain rows are displayed. For example, if you specify “*SL\**” Only rows starting with “*SL*” will be displayed.

        - *Limit*: Determines how many rows can be displayed. If a particular number “X” is specified, only the X first rows will be displayed.

        - *Conditions*: Allows you to add conditions, so that for example a row is only displayed if a particular parameter has a particular value.

    - In the *Advanced* section, below *Limit number elements*, you can limit the displayed number of elements with the following settings:

        - *Limit*: Determines how many elements can be displayed. If a particular number “X” is specified, only the X first elements that are retrieved from the server will be displayed.

        - *Conditions*: Allows you to add conditions, so that for example an element is only displayed if a particular parameter has a particular value.

    > [!NOTE]
    > For each added parameter, a “real-time” indication is also added in the *Settings* pane. This is not a configurable option, but only an indication that the component displays real-time information.

4. Optionally, fine-tune the component layout. See [Customizing the component layout](Configuring_dashboard_components.md#customizing-the-component-layout).

### Table

This component is introduced in DataMiner 10.0.13 with the purpose of displaying the results of queries in table format. It should always be configured with *Queries* data input. See [Using Queries data input](Configuring_dashboard_components.md#using-queries-data-input).

It displays the different possible data sources of queries as follows:

- Elements are represented with a row for each element, with each column detailing different information for that element.

- Services are displayed in the same way as elements.

- Table parameters are displayed as they are, as determined by the applied operators.

- If parameters are retrieved by protocol or profile definition, each row will represent a matching element, and for each parameter a column will show the corresponding values.

In the *Layout* tab for this component, the *Column filters* option is available, which allows you to highlight cells based on a condition. You can configure this option as follows:

- If the column you want to use for highlighting contains values for which a specific range can be specified, select the column, indicate the range to be highlighted, select the range and then click the color icon on the right to specify a highlight color. Multiple ranges can be indicated for one column, each with a color of its own.

- Alternatively, from DataMiner 10.20/10.1.8 onwards, you can filter on specific text instead. To do so, select the column you want to use for highlighting, specify the text, and select the highlight color. By default, the cell value will need to be equal to the specified text to be highlighted. However, you can change this by clicking *equal* above the text box and selecting *contain* or *match regex* instead, depending on the type of filtering you want to apply. You can also apply a negative filter by clicking *does*, which will make this field switch to *does not* instead.

- Multiple filters can be applied on the same value. In that case, the filters will be applied from the top of the list to the bottom. Positive filters will get priority over negative filters.

- You can remove a column filter again by selecting *No color* instead of a specific color.

You can resize the columns of the table by dragging the column edges. Clicking on a column header will sort the table by that column. To toggle between ascending and descending order, click the column header again. To sort by multiple columns, keep the Ctrl key pressed while clicking the column headers. The first column will then be used for the initial sorting, the next one to sort equal values of the first column, and so on. From DataMiner 10.2.0/10.1.8 onwards, you can also change the order of the columns by dragging the column headers to a different position.

From DataMiner 10.2.0/10.1.3 onwards, you can export the content of the table via the ... button in the top-right corner of the component. If nothing is selected in the table, the entire table will be exported; otherwise only the selected rows will be exported. The export file will be named “Query XXX” (XXX being the name of the query, as configured in the data pane). The first line of the CSV file will contain the names of the columns. The subsequent lines will contain the data, each line being a row of the query result. This data will contain the display values, not the raw values. This means that units will be included for the parameter values and that discrete values will be replaced by their corresponding display values.

> [!NOTE]
> To only export specific columns, first apply a filter by dragging the columns onto the table component before you export the component.
>
