---
uid: Filtering_Table_Content
---

# Filtering table content

From DataMiner 10.2.7/10.3.0 onwards, you can filter the contents of a table component using one of the available three methods: the [general filter](#general-filter), the [column-based filter](#column-based-filter), or a [text string](#filter-based-on-text-string).

## General filter

To apply a general filter across the table, a **search box** is available:

1. Click the search icon in the top-right corner.

1. Specify the filter text (case-insensitive) in the search box.

   ![General filter](~/user-guide/images/General_Filter.gif)<br>*Table component in DataMiner 10.5.6*

   This will apply a client-side filter only. To apply a server-side filter, you need to use a filter operator when you [configure the query data source](xref:Creating_GQI_query).

> [!IMPORTANT]
> From DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11 onwards<!-- RN 40818-->, the search box is only available when the [*Show quick filter* setting](xref:DashboardTable#table-layout) is enabled.

## Column-based filter

To apply **a filter based on a specific column**:

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

   ![Column filtering](~/user-guide/images/Column_Filtering.gif)<br>*Table component in DataMiner 10.5.6*

> [!NOTE]
> If you apply several column filters or apply both the general filter and one or more column filters, values will only be shown if they match all filters (i.e. filters are combined using "AND").

## Filter based on text string

From DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11 onwards<!--RN 40793-->, you can **filter the table by passing it a text string**.

You can do this in several different ways, for example:

- Use a **text input** or **search input** component:

  1. Add a [text input](xref:DashboardTextInput) or [search input](xref:DashboardSearchInput) component to your dashboard or app.

  1. Hover over the table component, click the filter icon, and then add a filter from the *Components > Text input #/Search input # > Value > Texts* section of the *Data* pane. Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12<!--RN 41075 + 41141-->, add a filter from the *Feeds > Text input #/Search input # > Value > Strings* section of the *Data* pane.

  When you input text in the published version of the dashboard or app, the table component will automatically filter based on this input, and the value will appear in the table's search box.

  > [!NOTE]
  > If you do not want the search box to appear when using text or search input data as a filter, disable the [*Show quick filter* setting](xref:DashboardTable#table-layout) in the *Layout* pane.

  ![Text input](~/user-guide/images/Text_input_filter_table.gif)<br>*Text input and table components in DataMiner 10.4.11*

- Specify a **text string in the dashboard or app URL**:

  1. Hover over the component, click the filter icon, and then add a filter from the *URL > Text* section of the *Data* pane. Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12<!--RN 41075 + 41141-->, add a filter from the *Feeds > URL > Strings* section of the *Data* pane.

  1. Pass a string data object within the URL, as explained in [Specifying data input in a dashboard or app URL](xref:Specifying_data_input_in_a_URL).

     This URL will automatically display a filtered version of the table when the dashboard or app is opened.

     In the following example, the text string "test" is sent to the component with component ID 1:

     `https://<dma>/<app-id>?data={"components": [{"cid":1, "select":{"strings": ["test"]}}]`