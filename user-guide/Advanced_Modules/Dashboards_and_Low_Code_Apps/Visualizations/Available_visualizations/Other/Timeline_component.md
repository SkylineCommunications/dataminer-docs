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

1. To add item selection and group selection to the timeline component simultaneously<!--35638-->:

   1. Hover the mouse pointer over the component and click the ![Groups](~/user-guide/images/NewRD_Groups.png) icon.

      In the data pane on the right, any data feeds that cannot be added will become unavailable. Data feeds that are compatible will be marked with the following icon: ![available groups](~/user-guide/images/Group_Icon.png)

   1. Drag the compatible data feed onto the component.

      > [!NOTE]
      > If you add a query column to the timeline component that contains data where the start and end time are empty, these empty groups are still displayed<!--RN 35600-->.

   1. Add a feed from the *Feeds > Timeline # > Selected groups > Query rows* section of the data pane.

1. Optionally, customize the following component options:

   - *WebSocket settings*: Determines whether the websocket settings configured in the page/panel settings should be applied to this component. Enabled by default.

   - *General > Timeline*: Allows you to configure the start and end of the timeline component. You can choose between the following options: *Start*, *End*, and *Discount*.

   - *General > Override dynamic units*: Disables parameter units from changing dynamically based on their value and protocol definition. Disabled by default.

   - *General > Use dynamic units*: When the *Override dynamic units* option is enabled, this option will allow you to determine whether parameter units will change dynamically based on their value and protocol definition.

   - *General > Default time range*: Allows you to select an option with a particular time to zoom to this time on the timeline, e.g. Today, Last 7 days, Next hour, etc. The options are divided in the following categories: *Still busy*, *In the past*, *Near future*, *Recently*, *Long run*, *Starting from now*, and *Distant future*. Set to *Still busy, This week* by default<!--RN 33287-->.

     If you select *Custom*, you can set a custom start and end time.

     ![Custom time range](~/user-guide/images/Default_Time_Range.png)<br/>*Settings timeline component in DataMiner 10.4.1*

     > [!NOTE]
     > The component has a minimum time range of 5 milliseconds and a maximum of 10 years<!--RN 35620-->.

     To use the default time range configured for another timeline component in the dashboard or low-code app, click the ![Link to feed](~/user-guide/images/Link_to_Feed.png) icon next to *Link time range to feed* and select the component from the dropdown list. Modifying the default time frame for this component will automatically synchronize the time range for any linked components as well.

     > [!NOTE]
     > Optionally, you can use a [time range component](xref:DashboardTimeRangeFeed) to adjust and/or display the time range configured for the timeline component<!--RN 33287-->.
     > To do so:
     >
     > 1. Select *Timeline # > Viewport > Timespans* in the *Feeds* section of the *Data* tab.
     > 1. Drag it onto an empty section of the dashboard or low-code app page.
     >
     > When you manually adjust the time range by zooming in or out, or by moving across the timeline component, the time range displayed in the time range component will automatically be adjusted.

   - *Data retrieval > Update data*: Allows updates to be enabled or disabled. This setting will enable real-time updates for all queries executed by the selected component. Disabled by default.

   - *Highlight range > Use highlighting*: Determines whether an event in the timeline component is highlighted when it falls within the configured time range. When an event is highlighted, it receives a blue background color. Events that do not fall within the set time range are still visible with lowered opacity. Disabled by default<!--RN 33639-->.

     ![Highlight](~/user-guide/images/Timeline_Highlight.png)<br/>*Timeline component in DataMiner 10.4.1*

     To use the time range configured for another component in the dashboard or low-code app, click the ![Link to feed](~/user-guide/images/Link_to_Feed.png) icon next to the *Time range* dropdown box, and select the component from the dropdown list. Modifying the highlight time frame for this component will automatically synchronize the time range for any linked components as well.

1. Fine-tune the component layout. In the *Component* > *Layout* tab, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

   - *Filtering & Highlighting*: Available from DataMiner 10.1.11/10.2.0 onwards<!--RN 33276-->. Allows you to configure a number of filtering and highlighting options. However, note that the filtering options require the [Query filter component](xref:DashboardQueryFilterFeed), available from DataMiner 10.3.9/10.4.0 onwards.

     - *Highlight*: When this option is enabled, the nodes that match the filter will be highlighted. Enabled by default.

     - *Opacity*: When the *Highlight* option is enabled, this option will allow you to set the level of transparency of the nodes and edges that do not match the filter.

       > [!NOTE]
       > When you disable the *Highlight* option, the nodes that do not match the filter will no longer be displayed and the remaining nodes will be reorganized.

   - *Advanced > Empty result message*: Available from 10.3.11/10.4.0 onwards<!-- RN 37173 -->. Allows you to specify a custom message that is displayed when a query returns no results.

     > [!TIP]
     > See also: [Displaying a custom empty component message](xref:Tutorial_Dashboards_Displaying_a_custom_empty_component_message).

   - *Advanced > Style*: Allows you to edit the style of the timeline component. The following options are available:

     - *Grouping by*: Determines whether groupings are displayed in the timeline component. Disabled by default.

     - *Segment lines*: Determines whether segment lines are displayed in the timeline component. Enabled by default.

     - *Lock timeline to now*: Determines whether users are allowed to navigate past the current timestamp in read mode. Disabled by default.

   - *Item templates*: Allows you to freely customize the appearance of the timeline component items using the Template Editor<!--RN 33311-->.

     - To access the Template Editor, click *Edit* next to the pencil icon.

       > [!TIP]
       > For more information on how to use the Template Editor to customize the appearance of component items, see [Using the Template Editor](xref:Template_Editor).

     - To reuse previously saved templates for components in the same dashboard or low-code app, click *Reuse template* next to the ![reuse template](~/user-guide/images/Reuse_Template.png) button<!--RN 34948-->.

       > [!NOTE]
       > This option is only visible when another timeline component in the dashboard or low-code app is configured with a custom template.

## Zooming and panning

In read mode, you can manipulate the timeline component to navigate through the scheduled events.

- Adjusting the displayed time range:

  - To **zoom in** on the timeline component, press CTRL while scrolling up.

  - To **zoom out**, press CTRL while scrolling down.

  > [!NOTE]
  > The component has a minimum time range of 5 milliseconds and a maximum of 10 years, setting the zoom limit<!--RN 35620-->.

- To **move left or right** across the timeline component, click the timeline and drag your mouse.

- If the number of events exceeds the size of the component, a scrollbar appears when you hover over the component, allowing you to **navigate up or down** through the events.

> [!NOTE]
> When visualized on a mobile device<!--RN 35619-->:
>
> - You can zoom in on the component by placing your thumb and index finger tips together on the screen and moving them apart. To zoom out, use a pinching motion, starting with your fingers apart and bringing them together.
> - You can move left or right by sliding one finger across the component.
