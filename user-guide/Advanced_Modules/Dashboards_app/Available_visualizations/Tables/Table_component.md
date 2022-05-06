---
uid: DashboardTable
---

# Table

This component is used to display the results of queries in table format. It should always be configured with *Queries* data input. See [Configuring query (GQI) data feeds](xref:Configuring_GQI_feeds). Available from DataMiner 10.0.13 onwards.

It displays the different possible data sources of queries as follows:

- Elements are represented with a row for each element, with each column detailing different information for that element.

- Services are displayed in the same way as elements.

- Table parameters are displayed as they are, as determined by the applied operators.

- If parameters are retrieved by protocol or profile definition, each row will represent a matching element, and for each parameter a column will show the corresponding values.

## Layout configuration

In the *Layout* tab for this component, the *Column filters* option is available, which allows you to highlight cells based on a condition. You can configure this option as follows:

- If the column you want to use for highlighting contains values for which a specific range can be specified, select the column, indicate the range to be highlighted, select the range and then click the color icon on the right to specify a highlight color. Multiple ranges can be indicated for one column, each with a color of its own.

- Alternatively, from DataMiner 10.2.0/10.1.8 onwards, you can filter on specific text instead. To do so, select the column you want to use for highlighting, specify the text, and select the highlight color. By default, the cell value will need to be equal to the specified text to be highlighted. However, you can change this by clicking *equal* above the text box and selecting *contain* or *match regex* instead, depending on the type of filtering you want to apply. You can also apply a negative filter by clicking *does*, which will make this field switch to *does not* instead.

- Multiple filters can be applied on the same value. In that case, the filters will be applied from the top of the list to the bottom. Positive filters will get priority over negative filters.

- You can remove a column filter again by selecting *No color* instead of a specific color.

You can **resize the columns** of the table by dragging the column edges. Clicking on a column header will sort the table by that column. To toggle between ascending and descending order, click the column header again. To sort by multiple columns, keep the Ctrl key pressed while clicking the column headers. The first column will then be used for the initial sorting, the next one to sort equal values of the first column, and so on. From DataMiner 10.2.0/10.1.8 onwards, you can also change the order of the columns by dragging the column headers to a different position.

## Adding actions to a table

If you add a table component to a custom app using the DataMiner Application Framework, you can also configure actions for the component. This feature is not available in the Dashboards app.

To configure actions:

1. In the *Component* \> *Settings* pane, expand the *Actions* section.

1. Click *Add action*.

1. To specify how the action is triggered, at the top of the action configuration section, click the icon for text hyperlink, row double-click, or cell button.

1. In the *Label* box, specify a label for the action.

1. In the *Icon* box, select an icon for the action.

1. In the *Action* box, select the action that should be executed. You can for instance use this to add an update action to the table, or to allow users to select an item or clear their selection. See [Configuring custom app events](xref:Configuring_custom_apps#configuring-custom-app-events).

## Exporting the table

From DataMiner 10.2.0/10.1.3 onwards, you can export the content of the table via the ... button in the top-right corner of the component. If nothing is selected in the table, the entire table will be exported; otherwise only the selected rows will be exported.

The export file will be named “Query XXX” (XXX being the name of the query, as configured in the data pane). The first line of the CSV file will contain the names of the columns. The subsequent lines will contain the data, each line being a row of the query result. This data will contain the display values, not the raw values. This means that units will be included for the parameter values and that discrete values will be replaced by their corresponding display values.

> [!NOTE]
> To only export specific columns, first apply a filter by dragging the columns onto the table component before you export the component.
