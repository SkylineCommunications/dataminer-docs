---
uid: DashboardGroup
---

# Group

> [!CAUTION]
>
> - The group component is being retired. See [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles). ![EOL](~/dataminer/images/EOL_Duo.png)
> - From DataMiner 10.5.0 [CU10]/10.6.1 onwards<!--RN 44128-->, the group will only appear in the list of available visualizations if the `showAdvancedSettings=true` URL option is used.

This component can be used to display a group of other components. This is especially used in order to repeat the same components for each data item in a group, for example for each parameter in a group of parameters.

As soon as more than one data item is displayed by the group component, the component will display a legend on the right-hand side, listing the included items. You can show and hide data items by clicking them in this legend. Next to each item in the legend, the color is displayed that is associated with it in the group. If you click an item in the group, all related information in parameter state, line chart and pivot table components within the group will be highlighted with this color.

To configure this component:

1. Add one or more sources of data. See [Adding data to a component](xref:Adding_data_to_component).

   The component accepts elements, parameters, redundancy groups, services and views as data.

1. Drag additional visualizations to the placeholder boxes on the component.

   Once a visualization has been added, you can delete it again using a delete icon. You can also replace an added visualization by a different one by dragging that other visualization to the same location. By clicking a visualization within the group, you can gain access to its specific layout options and settings.

1. Optionally, in the *Component* > *Layout* pane, configure the following options:

   - *Page Layout* \> *Layout*: Determines whether the different items are displayed next to each other or below each other. However, note that when the dashboard is used on a small screen, they will always be displayed below each other.

   - *Page Layout* \> *Maximum rows per page*: Determines how many items can at most be displayed below each other on a single page.

   - *Page Layout* \> *Maximum columns per page*: Determines how many items can at most be displayed next to each other on a single page.

   - *Group Layout* \> *Number of components*: Determines how many child components can be displayed within the group

   - *Group Layout* \> *Layout*: Determines the size and position of the different child components within the group.

   - *Expand legend initially*: Select this option to immediately show the group legend in the component. Otherwise, the legend section is initially collapsed, and you can display it using the arrow icon in the top-right corner of the component.

1. Optionally, in the *Component* > *Settings* pane, configure the following options:

   - *WebSocket settings*: Allows you to customize the polling interval for this component. To do so, clear the checkbox in this section and specify the custom polling interval.

   - *Data limit*: Determine the maximum number of items for which the component can display data.
