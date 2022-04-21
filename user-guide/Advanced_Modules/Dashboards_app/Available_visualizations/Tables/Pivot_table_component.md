---
uid: DashboardPivotTable
---

# Pivot table

This component displays a status report for a number of parameters of the elements using the selected protocol and protocol version.

From DataMiner 9.6.13 onwards, it is possible to export this status report to CSV. To do so, click the ... icon in the top-right corner of the component and select *Export to CSV*. The CSV file will then be generated in the background. To ensure that it is generated correctly, do not change the configuration of the component until the CSV export is completed.

> [!NOTE]
> - EPM data and discrete values are only supported in this component from DataMiner 9.6.13 onwards. Mediation protocols are only supported from DataMiner 10.0.6 onwards.
> - The separator used in CSV exports is based on the *CSV separator* setting in Cube. If this setting cannot be retrieved, the local browser settings are used instead.

To configure the component, from DataMiner 9.6.12 onwards:

1. Apply a data feed. See [Applying a data feed](xref:Configuring_dashboard_components#applying-a-data-feed).

   This component requires a parameter feed based on *Protocol* or *Element*, or a group of parameters from a *Parameter* feed component.

   - In case a protocol parameter feed is used, you can add an additional element or view feed as a filter.

   - In case an element parameter feed is used, you can add an additional view feed as a filter.

   - If a table parameter feed is used, you can an additional indices feed as a filter.

1. In the *Settings* tab, you can fine-tune the component:

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

1. Optionally, fine-tune the component layout. See [Customizing the component layout](xref:Configuring_dashboard_components#customizing-the-component-layout).

To configure the component, up to DataMiner 9.6.11:

1. Apply a data feed. See [Applying a data feed](xref:Configuring_dashboard_components#applying-a-data-feed).

   This component requires a parameter feed based on *Protocol* or *Element*.

1. If you add a table parameter, also add the table indices. To do so:

   1. Hover the mouse over the component and click the groups icon ( ![Groups icon](~/user-guide/images/NewRD_Groups.png) ).

   2. Drag the *indices* group from the *Data* tab to the component.

1. In the *Settings* tab, apply the following settings if necessary:

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

1. Optionally, fine-tune the component layout. See [Customizing the component layout](xref:Configuring_dashboard_components#customizing-the-component-layout).
