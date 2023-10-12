---
uid: DashboardGroup
---

# Group

This component can be used to display a group of other components. This is especially used in order to repeat the same components for each data item in a group feed, for example for each parameter in a group of parameters. Available from DataMiner 9.6.12 onwards.

As soon as more than one data item is displayed by the group component, the component will display a legend on the right-hand side, listing the included items. You can show and hide data items by clicking them in this legend. Next to each item in the legend, the color is displayed that is associated with it in the group. If you click an item in the group, all related information in parameter state, line chart and pivot table components within the group will be highlighted with this color.

To configure this component:

1. Add one or more data feeds. See [Applying a data feed](xref:Configuring_dashboard_components#applying-a-data-feed).

   The component accepts elements, parameters, redundancy groups, services and views as data feeds.

1. Drag additional visualizations to the placeholder boxes on the component.

   Once a visualization has been added, you can delete it again using a delete icon. You can also replace an added visualization by a different one by dragging that other visualization to the same location. By clicking a visualization within the group, you can gain access to its specific layout options and settings.

1. Optionally, in the *Component* > *Layout* tab, configure the following options:

   - *Page Layout* \> *Layout*: Determines whether the different items are displayed next to each other or below each other. However, note that when the dashboard is used on a small screen, they will always be displayed below each other.

   - *Page Layout* \> *Maximum rows per page*: Determines how many items can at most be displayed below each other on a single page.

   - *Page Layout* \> *Maximum columns per page*: Determines how many items can at most be displayed next to each other on a single page.

   - *Group Layout* \> *Number of components*: Determines how many child components can be displayed within the group

   - *Group Layout* \> *Layout*: Determines the size and position of the different child components within the group.

   - *Expand legend initially*: Available from DataMiner 10.0.0/10.0.2 onwards. Select this option to immediately show the group legend in the component. Otherwise, the legend section is initially collapsed, and you can display it using the arrow icon in the top-right corner of the component.

1. Optionally, in the *Component* > *Settings* tab, configure the following options:

   - *WebSocket settings*: Allows you to customize the polling interval for this component. To do so, clear the checkbox in this section and specify the custom polling interval.

   - *Data limit*: Determine the maximum number of items for which the component can display data.
