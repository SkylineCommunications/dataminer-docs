---
uid: DashboardTimeline
---

# Timeline

> [!IMPORTANT]
> The timeline component is in preview until DataMiner 10.4.1/10.5.0. If you use the preview version of the feature, its functionality may be different from what is described below. For more information, see [Soft-launch options](xref:SoftLaunchOptions).

Available from DataMiner 10.4.1/10.5.0 onwards<!--RN 37812-->. Prior to this, the component is available in soft launch from DataMiner 10.1.10 onwards, if the soft-launch option *ReportsAndDashboardsScheduler* is enabled.

This component provides you an overview of scheduled tasks.

To configure the component:

1. Apply a data feed. See [Applying a data feed](xref:Apply_Data_Feed).

1. Optionally, hover the mouse pointer over the component, click the filter icon, and then add a filter feed from the *Feeds > URL > Query columns* section of the data pane. You can repeat this several times in order to filter on several query columns.

1. Optionally, customize the following component options:

   - *WebSocket settings*: Determines whether the websocket settings configured in the page/panel settings should be applied to this component. Enabled by default.

   - *General > Timeline*: Allows you to configure the start and end of the timeline component. You can choose between the following options: *Start*, *End*, and *Discount*.

   - *General > Override dynamic units*: Disables parameter units from changing dynamically based on their value and protocol definition. Disabled by default.

   - *General > Use dynamic units*: When the *Override dynamic units* option is enabled, this option will allow you to determine whether parameter units will change dynamically based on their value and protocol definition.

   - *General > Default time range*: Allows you to select an option with a particular time to zoom to this time on the timeline, e.g. Today, Last 7 days, Next hour, etc. The options are divided in the following categories: *Still busy*, *In the past*, *Near future*, *Recently*, *Long run*, *Starting from now*, and *Distant future*. Set to *Still busy, This week* by default.

     If you select *Custom*, you can set a custom start and end time.

     ![Custom time range](~/user-guide/images/Default_Time_Range.png)<br/>*Settings timeline component in DataMiner 10.4.1*

     To use the default time range configured for another timeline component in the dashboard or low-code app, click the ![Link to feed](~/user-guide/images/Link_to_Feed.png) icon next to *Link time range to feed* and select the component from the dropdown list. Modifying the default time frame for this component will automatically synchronize the time range for any linked components as well.

   - *Data retrieval > Update data*: Allows updates to be enabled or disabled. This setting will enable real-time updates for all queries executed by the selected component. Disabled by default.

   - *Highlight range > Use highlighting*: Determines whether an event in the timeline component is highlighted when it falls within the configured time range. When an event is highlighted, it receives a blue background color. Events that do not fall within the set time range are still visible with lowered opacity. Disabled by default.

     ![Highlight](~/user-guide/images/Timeline_Highlight.png)<br/>*Timeline component in DataMiner 10.4.1*

     To use the highlight time range configured for another timeline component in the dashboard or low-code app, click the ![Link to feed](~/user-guide/images/Link_to_Feed.png) icon next to the *Time range* dropdown box, and select the component from the dropdown list. Modifying the highlight time frame for this component will automatically synchronize the time range for any linked components as well.

1. Fine-tune the component layout. In the *Component* > *Layout* tab, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

   - *Filtering & Highlighting > Highlight*: When this option is enabled, the nodes that match the filter will be highlighted. Enabled by default.

   - *Filtering & Highlighting > Opacity*: When the *Highlight* option is enabled, this option will allow you to set the level of transparency of the nodes and edges that do not match the filter.

     > [!NOTE]
     > When you disable the *Highlight* option, the nodes that do not match the filter will no longer be displayed and the remaining nodes will be reorganized.

   - *Advanced > Empty result message*: Available from 10.3.11/10.4.0 onwards<!-- RN 37173 -->. Allows you to specify a custom message that is displayed when a query returns no results.

     > [!TIP]
     > See also: [Displaying a custom empty component message](xref:Tutorial_Dashboards_Displaying_a_custom_empty_component_message).

   - *Advanced > Style*: Allows you to edit the style of the timeline component. The following options are available:

     - *Grouping by*: Determines whether groupings are displayed in the timeline component. Disabled by default.

     - *Segment lines*: Determines whether segment lines are displayed in the timeline component. Enabled by default.

     - *Lock timeline to now*: Determines whether users are allowed to navigate past the current timestamp in read mode. Disabled by default.

   - *Item templates*: Allows you to freely customize the appearance of the timeline component items using the Template Editor<!--RN 34761-->.

     - To access the Template Editor, click *Edit* next to the pencil icon.

       > [!TIP]
       > For more information on how to use the Template Editor to customize the appearance of component items, see [Using the Template Editor](xref:Template_Editor).

     - To reuse previously saved templates for components in the same dashboard or low-code app, click *Reuse template* next to the ![reuse template](~/user-guide/images/Reuse_Template.png) button<!--RN 34948-->.

       > [!NOTE]
       > This option is only visible when another timeline component in the dashboard or low-code app is configured with a custom template.
