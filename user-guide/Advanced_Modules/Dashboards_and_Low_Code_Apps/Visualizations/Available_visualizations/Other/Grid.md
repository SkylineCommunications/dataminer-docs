---
uid: DashboardGrid
---

# Grid

> [!IMPORTANT]
> At present, this component is only available in preview, if the [ReportsAndDashboardsDynamicVisuals](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsdynamicvisuals) soft-launch option is enabled. For more information, see [Soft-launch options](xref:SoftLaunchOptions).

Available from DataMiner 10.4.1/10.5.0<!--RN 34761-->. This component allows you to visualize data as a grid.

To configure the component:

1. Apply a data feed. See [Applying a data feed](xref:Apply_Data_Feed).

1. Optionally, hover the mouse over the component, click the filter icon, and then add a filter feed from the *queries* section of the data pane. You can repeat this several times in order to filter on several queries<!--RN 34761-->.

1. Optionally, customize the following component options:

   - *WebSocket settings*: Allows you to customize the polling interval for this component. To do so, clear the checkbox in this section and specify the custom polling interval.

   - *General > Override dynamic units*: Disables parameter units from changing dynamically based on their value and protocol definition.

   - *Data retrieval > Update data*: Allows updates to be enabled or disabled. This setting will enable real-time updates for all queries executed by the selected component<!--RN 37269-->.

   - *Initial Selection*: Allows you to specify a default value. This is the value that will be applied in the feed when the dashboard is opened, unless a custom URL is used specifying a different value.

1. Fine-tune the component layout. In the *Component* > *Layout* tab, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

   - *Filtering & Highlighting > Highlight*: When this option is enabled, the nodes that match the filter will be highlighted. Default: Enabled

   - *Filtering & Highlighting > Opacity*: When the *Highlight* option is enabled, this option will allow you to set the level of transparency of the nodes and edges that do not match the filter.

     > [!NOTE]
     > When you disable the *Highlight* option, the nodes that do not match the filter will no longer be displayed and the remaining nodes will be reorganized.

   - *Advanced > Empty Result message*: Available from 10.3.11/10.4.0 onwards<!-- RN 37173 -->. Allows you to specify a custom message that is displayed when a query returns no results.

     > [!TIP]
     > See also: [Displaying a custom empty component message](xref:Tutorial_Dashboards_Displaying_a_custom_empty_component_message).

   - *Advanced > Grid template*: Allows you to customize the number of columns and rows displayed in the grid component, along with scaling options<!--RN 34761 + 34781-->.

     - By default, the number of displayed columns and rows is set to *Auto*. To modify this number, clear the checkbox in this section and specify the desired amount. To revert to *Auto*, delete the entry.

     - To switch between scaling options, select one of the following buttons:

       - ![Scaled to fit (scaling)](~/user-guide/images/Scaling.png) : All columns and/or rows are displayed. This is the default setting.

       - ![Scaled to fit (fixed)](~/user-guide/images/Fixed.png) : All columns and/or rows are displayed using the fixed scaling.

     > [!NOTE]
     >
     > - The number of items that can be displayed in a grid component is limited to 1000<!--RN 37699-->.
     > - If the number of items to be displayed exceeds the number of cells displayed in the component, navigation buttons are available to navigate through the data<!--RN 34761-->.
     > - When the scaling is set to *fixed* and there are too many columns and/or rows to show them at once in the component, in read mode, it is possible to scroll through them with a scrollbar that becomes visible when you hover over the component<!--RN 37699-->.

   - *Item templates > Alarms*: Allows you to freely customize the appearance of the grid component using templates<!--RN 34761-->.

     - To access the Template Editor, click the pencil icon.

     - To reuse previously saved templates for components in the same dashboard or low-code app, click the ![reuse template](~/user-guide/images/Reuse_Template.png) button<!--RN 34948-->.

       > [!NOTE]
       > This button is only visible when a component in the dashboard or low-code app is configured with a custom template.
