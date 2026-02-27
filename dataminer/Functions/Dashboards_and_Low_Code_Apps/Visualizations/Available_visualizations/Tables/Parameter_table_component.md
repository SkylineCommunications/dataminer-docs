---
uid: DashboardParameterTable
---

# Parameter table

This component displays a data table of an element.

![Parameter table](~/dataminer/images/Parameter_Table.png)<br>*Parameter table component in DataMiner 10.4.1*

To configure the component:

1. Apply table parameter data. See [Adding data to a component](xref:Adding_data_to_component).

1. Optionally, hover the mouse pointer over the component, click the filter icon, and then add a filter from the *indices* section of the *Data* pane. You can repeat this several times in order to filter on several indices.

1. Optionally, customize the following component options in the *Component* > *Settings* pane:

   - *WebSocket settings*: Allows you to customize the polling interval for this component. To do so, clear the checkbox in this section and specify the custom polling interval.

   - *Filter*: To limit the displayed data, specify an advanced table filter in this box. For more information on the supported filter syntax, see [Dynamic table filter syntax](xref:Dynamic_table_filter_syntax).

1. Optionally, fine-tune the component layout. In the *Component* > *Layout* pane, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

   - *Expand on hover*: If this option is selected, and not all data within the component can be shown in the available space, the component will expand across other components when you hover the mouse pointer over it in order to show as much data as possible.

> [!NOTE]
> From DataMiner 10.2.10/10.3.0 onwards, you can filter and sort a parameter table in the same way as a generic table component. See [Filtering table content](xref:Filtering_Table_Content). You can also resize the table by dragging the column edges, and you can drag and drop columns to change the column order.
