---
uid: Parameter_Table_Filters
---

# Parameter table filters

Only available when the URL option `showAdvancedSettings=true` is used.

Parameter table filters allow you to define a custom data subset from a parameter table, based on filtering criteria. This filtered data can then be used in supported components like line & area charts or parameter pickers.

You can write filter expressions using a dedicated syntax. For more information and examples, see [Dynamic table filter syntax](xref:Dynamic_table_filter_syntax).

To add a parameter table filter:

1. In edit mode, go to the *Data* pane on the right, expand the *Parameter table filters* item, and click the + icon.

   This will add a new parameter filter.

1. Give your filter a name.

1. Define the filter expression using the [supported syntax](xref:Dynamic_table_filter_syntax).

1. Apply the filter to one of the supported components:

   - [Line & area chart](xref:LineAndAreaChart)

   - [Parameter picker](xref:DashboardParameterPicker) (from DataMiner 10.2.3/10.3.0 onwards)

> [!NOTE]
>
> - When you update a filter that is already used in a component, re-add the filter in order to update it in the component.
> - From DataMiner 10.3.0 [CU15]/10.4.0 [CU3]/10.4.6 onwards<!--RN 39335-->, you can use data found either on the same low-code app page/panel or on another page/panel. Prior to DataMiner 10.3.0 [CU15]/10.4.0 [CU3]/10.4.6, you can only use data found on the same low-code app page/panel.
