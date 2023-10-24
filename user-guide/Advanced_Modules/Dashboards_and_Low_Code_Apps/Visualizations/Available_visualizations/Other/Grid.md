---
uid: DashboardGrid
---

# Grid

> [!IMPORTANT]
> At present, this component is only available in preview, if the [ReportsAndDashboardsDynamicVisuals](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsdynamicvisuals) soft-launch option is enabled. For more information, see [Soft-launch options](xref:SoftLaunchOptions).

This component allows you to visualize data as a grid.

To configure the component:

1. Apply a data feed. See [Applying a data feed](xref:Configuring_dashboard_components#applying-a-data-feed).

1. Optionally, customize the following component options:

   - *WebSocket settings*: Allows you to customize the polling interval for this component. To do so, clear the checkbox in this section and specify the custom polling interval.

   - *Override dynamic units*:

   - *Use dynamic units*: Determines whether parameter units will change dynamically based on their value and protocol definition.

   - *Data retrieval > Update data*: Allows updates to be enabled or disabled. This setting will enable updates for all queries executed by the selected component.

   - *Initial Selection*: Allows you to specify a default value. This is the value that will be applied in the feed when the dashboard is opened, unless a custom URL is used specifying a different value.

1. Fine-tune the component layout. In the *Component* > *Layout* tab, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Configuring_dashboard_components#customizing-the-component-layout).

   - *Filters & Highlighting*: Allows you to configure a number of filtering and highlighting options. However, note that the filtering options require the [*Query filter* component](xref:DashboardQueryFilterFeed), available from DataMiner 10.3.9/10.4.0 onwards.

     - *Highlight*: When this option is enabled, the nodes that match the filter will be highlighted. Default: Enabled

     - *Opacity*: When the *Highlight* option is enabled, this option will allow you to set the level of transparency of the nodes and edges that do not match the filter.

       > [!NOTE]
       > When you disable the *Highlight* option, the nodes that do not match the filter will no longer be displayed and the remaining nodes will be reorganized.

   - *Advanced > Empty Result message*: Available from 10.3.11/10.4.0 onwards<!-- RN 37173 -->. Allows you to specify a custom message that is displayed when a query returns no results.

     > [!TIP]
     > See also: [Displaying a custom empty component message](xref:Tutorial_Dashboards_Displaying_a_custom_empty_component_message).

   - *Advanced > Grid template*: Allows you to customize the number of columns and rows displayed in the grid component, along with scaling options.

     - By default, the columns and rows are set to *Auto*. To modify the displayed columns and rows, select *Auto* and enter your desired number. To reset to *Auto*, delete the number.

     - By default, the scaling is set to *Scaled to fit (fixed)*. To switch to *Scaled to fit (scaling)*, select the corresponding checkbox. Click the expand icon ![expand icon](~/user-guide/images/Expand_Grid_Template.png) to switch back to *Scaled to fit (fixed)*.
