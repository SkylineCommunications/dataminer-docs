---
uid: DashboardTable
---

# Table

This component is used to display the results of queries in table format. It should always be configured with *Queries* data input. See [Creating a GQI query](xref:Creating_GQI_query). Available from DataMiner 10.0.13 onwards.

It displays the different possible data sources of queries as follows:

- Elements are represented with a row for each element, with each column detailing different information for that element.

- Services are displayed in the same way as elements.

- Table parameters are displayed as they are, as determined by the applied operators.

- If parameters are retrieved by protocol or profile definition, each row will represent a matching element, and for each parameter a column will show the corresponding values.

> [!NOTE]
>
> - From DataMiner 10.2.7/10.3.0 onwards, users can copy a cell, a column, a row, or the entire table via the right-click menu of the component. Unless a single cell is copied, the copy is in CSV format. If an entire column or single cell is copied, the values will not be encapsulated in double quotes. Copying an entire row or table will encapsulate all values in accordance with CSV formatting. If a value contains a double quote, this will be escaped when it is copied.
> - Prior to DataMiner 10.3.7/10.4.0, if the data in the table is fetched again by means of a [trigger component](xref:DashboardTriggerFeed) or a [component action](xref:LowCodeApps_event_config) while data is selected in the table, this selection is lost. From DataMiner 10.3.7/10.4.0 onwards, the component will try to reapply the selection. This means that the table will keep fetching more data until all previously selected rows are found. When a previously selected row is missing, the table will fetch all data looking for it. Reapplying the previous selection will take precedence over selecting the first row when the *Initial Selection* setting is enabled. The table will also update its feeds to reflect the new selection. <!-- RN 36372 -->

## Configuring the layout

In the *Layout* tab for this component, the *Column filters* option is available, which allows you to highlight cells based on a condition. You can configure this option as follows:

- If the column you want to use for highlighting contains values for which a specific range can be specified, select the column, indicate the range to be highlighted, select the range and then click the color icon on the right to specify a highlight color. Multiple ranges can be indicated for one column, each with a color of its own.

- Alternatively, from DataMiner 10.2.0/10.1.8 onwards, you can filter on specific text instead. To do so, select the column you want to use for highlighting, specify the text, and select the highlight color. By default, the cell value will need to be equal to the specified text to be highlighted. However, you can change this by clicking *equal* above the text box and selecting *contain* or *match regex* instead, depending on the type of filtering you want to apply. You can also apply a negative filter by clicking *does*, which will make this field switch to *does not* instead.

- Multiple filters can be applied on the same value. In that case, the filters will be applied from the top of the list to the bottom. Positive filters will get priority over negative filters.

- You can remove a column filter again by selecting *No color* instead of a specific color.

You can **resize the columns** of the table by dragging the column edges. From DataMiner 10.2.0/10.1.8 onwards, you can also change the order of the columns by dragging the column headers to a different position.

## Adding actions to a table

If you add a table component to a custom app using the [DataMiner Low-Code Apps](xref:Application_framework), you can also configure actions for the component. This feature is not available in the Dashboards app. <!-- RN 29394 -->

To configure actions:

1. In the *Component* \> *Settings* pane, expand the *Actions* section.

1. Click *Add action*.

1. To specify how the action is triggered, at the top of the action configuration section, click the icon for text hyperlink, row double-click, or cell button.

1. In the *Label* box, specify a label for the action.

1. In the *Icon* box, select an icon for the action.

1. In the *Action* box, select the action that should be executed. You can for instance use this to add an update action to the table, or to allow users to select an item or clear their selection. See [Configuring low-code app events](xref:LowCodeApps_event_config).

## Configuring other component settings

In the *Settings* tab for this component, you can customize its behavior to suit your requirements.

- If you want the data in the table to be refreshed automatically, Set *Update data* to *On* (available from DataMiner 10.2.0/10.2.1 onwards<!-- RN 31450 -->).

- If you want the first row to be selected by default, in the *Settings* tab, under *Initial Selection*, set the toggle button to *On* (available from DataMiner 10.3.6/10.4.0 onwards<!-- RN 35984 -->). This way, the first row will be automatically selected whenever the component is loaded or when the data in the table is refreshed.

## Exporting the table

From DataMiner 10.2.0/10.1.3 onwards, you can export the content of the table by clicking the ... button in the top-right corner of the component and selecting *Export to CSV*. What happens next depends on your DataMiner version:

- Prior to DataMiner 10.3.8/10.4.0, if nothing is selected in the table, the entire table will be exported; otherwise only the selected rows will be exported. The data will contain the display values, not the raw values. This means that units will be included for the parameter values and that discrete values will be replaced by their corresponding display values.

- From DataMiner 10.3.8/10.4.0 onwards, a pop-up window will open where you can select whether the raw values or the display values from the table should be exported. Exporting the display values will result in a CSV file that contains all the values as they are seen in the table, formatted and with units. If you export the raw values, no formatting will be applied to them. The only exception are discrete values, for which the corresponding display values will always be exported. If no rows are selected in the table, the entire table will be exported; otherwise only the selected rows will be exported.

The export file will be named “Query XXX” (XXX being the name of the query, as configured in the data pane). The first line of the CSV file will contain the names of the columns. The subsequent lines will contain the data, each line being a row of the query result.

> [!NOTE]
> To only export specific columns, first apply a filter by dragging the columns onto the table component before you export the component.

## Filtering and sorting the table

From DataMiner 10.2.7/10.3.0 onwards, users can filter and sort the contents of a table component in a dashboard.

> [!TIP]
> If you have made changes to the way a table is displayed, and you want to quickly reset your changes and return to the initial table view, click the eye icon in the top-right corner of the component (available from DataMiner 10.2.11/10.3.0 onwards).

To apply a **general filter** across the table, a search box is available:

1. Hover over the table component and click the search icon in the lower right corner.

1. Specify the filter text (case-insensitive) in the search box.

   This will apply a client-side filter only. To apply a server-side filter, you need to use a filter operator when you [configure the query data source](xref:Creating_GQI_query).

To apply a **filter based on a specific column**:

1. Right-click the column header and select *Filter*.

1. Configure the different fields of the filter, depending on the type of value in the column.

   - For string values or GUIDs:

     - To switch between a positive or negative filter, click *does* or *does not*.

     - To switch to a different type of filter, click the second filter field. This will toggle between *contain*, *equal*, and *match regex*.

     - In the third field of the filter, specify a filter value.

   - For numeric or datetime values, specify the range that a value should be in.

   - For booleans, specify whether the value should be true or false.

   - For discrete values, from DataMiner 10.2.10/10.3.0 onwards, select the relevant checkboxes.

   > [!NOTE]
   > Prior to DataMiner 10.2.9/10.3.0, it is possible to specify multiple conditions by clicking the + icon. As soon as one of the specified conditions applies, a value will be shown (i.e. conditions are combined using "OR"). DataMiner 10.2.9/10.3.0 switches to more efficient server-side filtering, which greatly improves the filter performance but does not allow multiple conditions in the same filter.

1. Click *Apply filter*.

> [!NOTE]
> If you apply several column filters or apply both the general filter and one or more column filters, values will only be shown if they match all filters (i.e. filters are combined using "AND").

To **sort the table**, you can click a column header.

- To toggle between ascending and descending order, click the column header again.

- To apply additional sorting, press Ctrl while clicking one or more additional headers. The first column will then be used for the initial sorting, the next one to sort equal values of the first column, and so on.

- Alternatively, you can also select one of the available sorting options in the column header right-click menu.

To **group by a specific table column**, right-click the column header and click *Group*. To stop grouping, right-click the header again and select *Stop grouping*.
