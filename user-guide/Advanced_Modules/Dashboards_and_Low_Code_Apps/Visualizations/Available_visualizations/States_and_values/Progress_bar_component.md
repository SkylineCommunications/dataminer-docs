---
uid: DashboardProgressBar
---

# Progress bar

This component shows the value of one or more analog parameters with a progress bar. It is available from DataMiner 10.2.0/10.1.7 onwards.

To configure the component:

1. Apply a parameter data feed. See [Applying a data feed](xref:Configuring_dashboard_components#applying-a-data-feed).

1. Optionally, customize the following component options:

   - To customize the polling interval for this component, expand the *Settings* \> *WebSocket settings* section, clear the checkbox in this section, and specify the custom polling interval.

   - In case the component displays more than one item, in the *Settings* tab, select how the items should be grouped: by parameter, by element, by table index (if relevant) or by all the above together.

   - To customize the value range of the component, in the *Settings* tab, select *Fixed minimum* and/or *Fixed maximum* and specify the custom minimum and/or maximum.

1. Fine-tune the component layout. In the *Component* > *Layout*, tab the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Configuring_dashboard_components#customizing-the-component-layout).

   - *Labels*: In this section, you can select whether the parameter name, the element name, the index (for a table parameter) and/or the value should be displayed in the component.

   - *Show minimum*: Select this option to show the minimum value of the value range. Note that this value can be customized in the component settings.

   - *Show maximum*: Select this option to show the maximum value of the value range. Note that this value can be customized in the component settings.

   - *Design*: Determines whether the text is displayed in a small or large font size.

   - *Layout flow*: If the component displays multiple parameters, this option determines whether the different parameters are displayed in rows or columns. If they are displayed in rows, they will be displayed next to each other until there is no more space and a new row is started. If they are displayed as columns, they will be displayed below each other until there is no more space and a new column is started.
