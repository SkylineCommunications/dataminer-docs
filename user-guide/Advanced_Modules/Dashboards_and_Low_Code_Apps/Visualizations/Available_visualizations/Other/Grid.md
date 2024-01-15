---
uid: DashboardGrid
---

# Grid

> [!IMPORTANT]
> The grid component is in preview until DataMiner 10.4.1/10.5.0. If you use the preview version of the feature, its functionality may be different from what is described below. For more information, see [Soft-launch options](xref:SoftLaunchOptions).

Available from DataMiner 10.4.1/10.5.0 onwards<!--RN 34761-->. Prior to this, the component is available in soft launch from DataMiner 10.2.12 onwards, if the soft-launch option *ReportsAndDashboardsDynamicVisuals* is enabled.

This component allows you to visualize data as a grid.

To configure the component:

1. Apply a data feed. See [Applying a data feed](xref:Apply_Data_Feed).

1. Optionally, hover the mouse pointer over the component, click the filter icon, and then add a filter feed from the *Feeds > URL > Query columns* section of the data pane. You can repeat this several times in order to filter on several query columns<!--RN 34761-->.

1. Optionally, customize the following component options:

   - *WebSocket settings*: Allows you to customize the polling interval for this component. To do so, clear the checkbox in this section and specify the custom polling interval.

   - *General > Override dynamic units*: Disables parameter units from changing dynamically based on their value and protocol definition. Disabled by default.

   - *General > Use dynamic units*: When the *Override dynamic units* option is enabled, this option will allow you to determine whether parameter units will change dynamically based on their value and protocol definition.

   - *Data retrieval > Update data*: Allows updates to be enabled or disabled. This setting will enable real-time updates for all queries executed by the selected component<!--RN 37269-->.

   - *Initial Selection*: If enabled, the first item is selected by default. This is the value that will be applied in the grid when the dashboard is opened, unless a custom URL is used specifying a different value. Disabled by default.

1. Fine-tune the component layout. In the *Component* > *Layout* tab, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

   - *Filtering & Highlighting > Highlight*: When this option is enabled, the nodes that match the filter will be highlighted. Default: Enabled

   - *Filtering & Highlighting > Opacity*: When the *Highlight* option is enabled, this option will allow you to set the level of transparency of the nodes and edges that do not match the filter.

     > [!NOTE]
     > When you disable the *Highlight* option, the nodes that do not match the filter will no longer be displayed and the remaining nodes will be reorganized.

   - *Advanced > Empty result message*: Available from 10.3.11/10.4.0 onwards<!-- RN 37173 -->. Allows you to specify a custom message that is displayed when a query returns no results.

     > [!TIP]
     > See also: [Displaying a custom empty component message](xref:Tutorial_Dashboards_Displaying_a_custom_empty_component_message).

   - *Advanced > Grid template*: Allows you to customize the number of columns and rows displayed in the grid component, along with scaling options<!--RN 34761 + 34781-->.

     - By default, the number of displayed columns and rows is set to *Auto* (i.e. all columns and/or rows are displayed). To modify the number of displayed columns and rows, clear the checkbox in this section and specify the desired number. To revert to *Auto*, delete the entry.

     - To switch between scaling options, select one of the following buttons:

       - ![Scaled to fit (fixed)](~/user-guide/images/Fixed.png) : The scaling of the cells in the columns and/or rows is adjusted dynamically to fit within the boundaries of the grid component.

       - ![Scaled to fit (scaling)](~/user-guide/images/Scaling.png) : The scaling of the cells in the columns and/or rows is set to a fixed size. This is the default setting.

     > [!NOTE]
     >
     > - The number of items that can be displayed in a grid component is limited to 1000<!--RN 37699-->.
     > - If the number of items to be displayed exceeds the number of cells displayed in the component, navigation buttons are available to navigate through the data<!--RN 34761-->.
     > - When the scaling of the cells is set to a fixed size and there are too many columns and/or rows to show them at once in the component, in read mode, it is possible to scroll through them with a scrollbar that becomes visible when you hover over the component<!--RN 37699-->.

   - *Item templates*: Allows you to freely customize the appearance of the grid component items using the Template Editor<!--RN 34761-->.

     - To access the Template Editor, click *Edit* next to the pencil icon.

       > [!TIP]
       > For more information on how to use the Template Editor to customize the appearance of component items, see [Using the Template Editor](xref:Template_Editor).

     - To reuse previously saved templates for components in the same dashboard or low-code app, click *Reuse template* next to the ![reuse template](~/user-guide/images/Reuse_Template.png) button<!--RN 34948-->.

       > [!NOTE]
       > This option is only visible when another grid component in the dashboard or low-code app is configured with a custom template.

## Navigating through the grid component

In read mode, you can manipulate the grid component to navigate through the columns and rows:

- If the number of items exceeds the size of the component, a scrollbar appears when you hover over the component, allowing you to navigate through the items.

- From DataMiner 10.3.0 [CU11]/10.4.2 onwards<!--RN 38191-->, when you are using on a mobile device:

  - You can move the grid left or right and up or down by sliding one finger across the component.

  - You can select grid items by tapping them.
