---
uid: DashboardTable
---

# Table

The table component is a highly flexible visualization designed to display the results of queries in a structured, row-column format, similar to a spreadsheet. It is ideal for working with **large sets of information**. The table visualization comes with functionalities such as sorting and filtering, but also offers endless customization options.

![Table component](~/user-guide/images/Table_Component.png)<br>*Table component in DataMiner 10.5.6*

With this component, you can:

- [Sort](#sorting-columns) and [filter data](#filtering-table-content) to quickly find the information you need.

- Apply **conditional formatting** to highlight key values.

- Use the **Template Editor** to customize the column appearance and draw attention to what matters most.

- [Copy](#copying-table-data) or [export data](#exporting-the-table) to CSV for reporting or further analysis.

- Configure **actions on rows and cells** to trigger specific workflow steps.

These capabilities make the table component a powerful tool for data exploration and interaction.

<div style="display: flex; align-items: center; justify-content: space-between; margin: 0 auto; max-width: 100%;">
  <div style="border: 1px solid #ccc; border-radius: 10px; padding: 10px; flex-grow: 1; background-color: #DEF7FF; margin-right: 20px; color: #000000;">
    <b>💡 TIPS TO TAKE FLIGHT</b><br>
    Want to learn how to style your table with custom columns, conditional coloring, icons, hyperlinks, and even a context menu? Check out the <a href="xref:Installing_DM_using_the_DM_installer" style="color: #657AB7;"><i>Styling a table component</i> tutorial></a> for a hands-on walkthrough in a low-code app, using real data.
  </div>
  <img src="~/images/Skye.svg" alt="Skye" style="width: 100px; flex-shrink: 0;">
</div>

## Supported data types

The table component is used to display the results of queries in table format. It should therefore always be configured with [query data input](xref:Query_Data).

It displays the different possible data sources of queries as follows:

- Elements are represented with a row for each element, with each column detailing different information for that element.

- Services are displayed in the same way as elements.

- Table parameters are displayed as they are, as determined by the applied operators.

- If parameters are retrieved by protocol or profile definition, each row will represent a matching element, and for each parameter a column will show the corresponding values.

> [!TIP]
> For an example of how to configure a GQI query that can be used as data input for a table component, see [Tutorial: Creating a custom parameter table connected to an element feed](xref:Creating_a_parameter_table_connected_to_an_element_feed).

## Filtering table content

From DataMiner 10.2.7/10.3.0 onwards, you can filter the contents of a table component using one of three available methods:

- Use the [search box](#general-filter) to filter the entire table based on the entered value.

  ![General filter](~/user-guide/images/General_Filter.gif)<br>*Table component in DataMiner 10.5.6*

- Momentarily change how column data is displayed using [column filtering](#column-based-filter). For example, you can show or hide specific values.

  ![Column filtering](~/user-guide/images/Column_Filtering.gif)<br>*Table component in DataMiner 10.5.6*

- Pass a [text string](#filter-based-on-text-string) to the table, for example by using a text input component.

  ![Text string filter](~/user-guide/images/Text_String_Filter.gif)<br>*Table component in DataMiner 10.5.6*

> [!TIP]
> If you have made changes to the way a table is displayed, and you want to quickly reset your changes and return to the initial table view, click the eye icon in the top-right corner of the component (available from DataMiner 10.2.11/10.3.0 onwards).

### General filter

To apply a general filter across the table, a search box is available:

1. Hover over the table component and click the search icon.

1. Specify the filter text (case-insensitive) in the search box.

   This will apply a client-side filter only. To apply a server-side filter, you need to use a filter operator when you [configure the query data source](xref:Creating_GQI_query).

> [!IMPORTANT]
> From DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11 onwards<!-- RN 40818-->, the search box is only available when the [*Show quick filter* setting](#filtering--highlighting) is enabled.

### Column-based filter

To apply a filter based on a specific column:

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

### Filter based on text string

From DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11 onwards<!--RN 40793-->, you can filter the table by passing it a text string.

You can do this in several different ways, for example:

- Use a **text input** or **search input** component:

  1. Add a [text input](xref:DashboardTextInput) or [search input](xref:DashboardSearchInput) component to your dashboard or app.

  1. Hover over the table component, click the filter icon, and then add a filter from the *Components > Text input #/Search input # > Value > Texts* section of the *Data* pane. Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12<!--RN 41075 + 41141-->, add a filter from the *Feeds > Text input #/Search input # > Value > Strings* section of the *Data* pane.

  When you input text in the published version of the dashboard or app, the table component will automatically filter based on this input, and the value will appear in the table's search box.

  > [!NOTE]
  > If you do not want the search box to appear when using text or search input data as a filter, disable the [*Show quick filter* setting](#filtering--highlighting) in the *Layout* pane.

  ![Text input](~/user-guide/images/Text_input_filter_table.gif)<br>*Text input and table components in DataMiner 10.4.11*

- Specify a **text string in the dashboard or app URL**:

  1. Hover over the component, click the filter icon, and then add a filter from the *URL > Text* section of the *Data* pane. Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12<!--RN 41075 + 41141-->, add a filter from the *Feeds > URL > Strings* section of the *Data* pane.

  1. Pass a string data object within the URL, as explained in [Specifying data input in a dashboard or app URL](xref:Specifying_data_input_in_a_URL).

     This URL will automatically display a filtered version of the table when the dashboard or app is opened.

     In the following example, the text string "test" is sent to the component with component ID 1:

     `https://<dma>/<app-id>?data={"components": [{"cid":1, "select":{"strings": ["test"]}}]`

## Resizing the table columns

You can **resize the columns** of the table by dragging the edges of the column headers. From DataMiner 10.1.8/10.2.0 onwards, you can also change the order of the columns by dragging the column headers to a different position.

> [!TIP]
> From DataMiner 10.4.1/10.5.0 onwards<!--RN 37522-->, you can adjust the default column width by accessing the [Template Editor](xref:Template_Editor) through *Layout > Column appearance*.

![Resizing and moving columns](~/user-guide/images/Resizing.gif)<br>*Table component in DataMiner 10.5.6*

## Configuration options

### Table layout

In the *Layout* pane, you can (...)

| Option | Description |
|--|--|

### Table settings

## Sorting columns

To sort the table, you can **click a column header**. To toggle between ascending and descending order, click the column header again.

![Column sorting](~/user-guide/images/Column_Sorting.png)<br>*Table component in DataMiner 10.5.6*

To apply **additional sorting**, press **Ctrl** while clicking one or more additional headers. The first column will then be used for the initial sorting, the next one to sort equal values of the first column, and so on.

Alternatively, you can also select one of the available sorting options in the **column header right-click menu**.

To **group** by a specific table column, right-click the column header and click *Group*. To stop grouping, right-click the header again and select *Stop grouping*.

## Copying table data

From DataMiner 10.2.7/10.3.0 onwards, you can copy a cell, a column, a row, or the entire table via the right-click menu of the component.

Unless a single cell is copied, the copy is in CSV format. If an entire column or single cell is copied, the values will not be encapsulated in double quotes. Copying an entire row or table will encapsulate all values in accordance with CSV formatting. If a value contains a double quote, this will be escaped when it is copied.

## Exporting the table

From DataMiner 10.1.3/10.2.0 onwards, you can export the content of the table by clicking the ... button in the top-right corner of the component and selecting *Export to CSV*. What happens next depends on your DataMiner version:

- Prior to DataMiner 10.3.8/10.4.0, if nothing is selected in the table, the entire table will be exported; otherwise only the selected rows will be exported. The data will contain the display values, not the raw values. This means that units will be included for the parameter values and that discrete values will be replaced by their corresponding display values.

- From DataMiner 10.3.8/10.4.0 onwards, a pop-up window will open where you can select whether the raw values or the display values from the table should be exported. Exporting the display values will result in a CSV file that contains all the values as they are seen in the table, formatted and with units. If you export the raw values, no formatting will be applied to them. The only exception are discrete values, for which the corresponding display values will always be exported. If no rows are selected in the table, the entire table will be exported; otherwise only the selected rows will be exported.

The export file will be named “Query XXX” (XXX being the name of the query, as configured in the *Data* pane). The first line of the CSV file will contain the names of the columns. The subsequent lines will contain the data, each line being a row of the query result.

> [!NOTE]
> To only export specific columns, first apply a filter by dragging the columns onto the table component before you export the component.
