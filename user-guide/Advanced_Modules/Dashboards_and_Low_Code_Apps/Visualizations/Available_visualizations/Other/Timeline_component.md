---
uid: DashboardTimeline
---

# Timeline

> [!IMPORTANT]
> The timeline component is in preview until DataMiner 10.4.1/10.5.0. If you use the preview version of the feature, its functionality may be different from what is described below. For more information, see [Soft-launch options](xref:SoftLaunchOptions).

Available from DataMiner 10.4.1/10.5.0 onwards<!--RN 37812-->. Prior to this, the component is available in soft launch from DataMiner 10.1.10 onwards, if the soft-launch option *ReportsAndDashboardsScheduler* is enabled.

This component allows you to visualize and manage bookings, events, and other time-bound data (e.g. appointments and project timelines).

To configure the component:

1. Apply a data feed. See [Applying a data feed](xref:Apply_Data_Feed).

1. Optionally, hover the mouse pointer over the component and click the ![filter](~/user-guide/images/DashboardsX_filter.png) icon. In the data pane on the right, any data feeds that cannot be added will become unavailable. Data feeds that are compatible will be marked with the following icon: ![available filters](~/user-guide/images/Available_Filters.png)

1. Optionally, add groups to the timeline component, so that you can group items on the timeline based on one of the columns in your data feed<!--35638-->:

   1. Hover the mouse pointer over the component and click the ![Groups](~/user-guide/images/NewRD_Groups.png) icon.

      In the data pane on the right, any data feeds that cannot be added will become unavailable. Data feeds that are compatible will be marked with the following icon: ![available groups](~/user-guide/images/Group_Icon.png)

      ![groups](~/user-guide/images/Example_Groups.png)<br/>*Data tab in DataMiner 10.4.1*

   1. Drag a compatible data feed onto the component.

      All groups are now displayed in a gray column to the left of the timeline<!--RN 33694-->. The timeline items are displayed next to the group they are part of.

      ![Timeline groups](~/user-guide/images/Groups_Timeline.png)

      > [!NOTE]
      > If a group is empty (i.e. there is no start and end time), it is still displayed in the timeline component<!--RN 35600-->.

   1. To make sure users can see which group is selected, you can add a table component displaying the selected group:

      1. Go to *Feeds > Timeline # > Selected groups > Query rows* in the *Data* tab, and drag it onto an empty section of the dashboard or low-code app page.

      1. Hover the mouse pointer over the component and click the ![visualization](~/user-guide/images/DashboardsX_visualizations00095.png) icon.

      1. Select the table visualization.

   1. To make sure users can see which item is selected, you can add a table component displaying the selected item:

      1. Go to *Feeds > Timeline # > Selected items > Query rows* in the *Data* tab, and drag it onto an empty section of the dashboard or low-code app page.

      1. Hover the mouse pointer over the component and click the ![visualization](~/user-guide/images/DashboardsX_visualizations00095.png) icon.

      1. Select the table visualization.

      ![Selected group and item](~/user-guide/images/Selected_Items_Groups.png)<br/>*Timeline and table components in DataMiner 10.4.1*

   1. If you want to display the name of the column the data was grouped by, make sure the *Advanced > Style > Grouping by* setting is enabled in the *Layout* tab.

1. Optionally, customize the following component options:

   - *WebSocket settings*: Determines whether the websocket settings configured in the page/panel settings should be applied to this component. Enabled by default.

   - *General > Timeline*: Allows you to configure the start and end times of the timeline component. When you add a new timeline component, this is automatically configured<!--RN 33657-->.

   - *General > Override dynamic units*: Disables parameter units from changing dynamically based on their value and protocol definition. Disabled by default.

   - *General > Use dynamic units*: When the *Override dynamic units* option is enabled, this option will allow you to determine whether parameter units will change dynamically based on their value and protocol definition.

   - *General > Default time range*: Allows you to select an option with a particular time to zoom to this time on the timeline, e.g. *Today*, *Last 7 days*, *Next hour*, etc. The options are divided into the following categories: *Still busy*, *In the past*, *Near future*, *Recently*, *Long run*, *Starting from now*, and *Distant future*. Set to *Still busy, This week* by default<!--RN 33287-->.

     If you select *Custom*, you can set a custom start and end time.

     ![Custom time range](~/user-guide/images/Default_Time_Range.png)<br/>*Settings timeline component in DataMiner 10.4.1*

     > [!NOTE]
     > The component has a minimum time range of 5 milliseconds and a maximum of 10 years<!--RN 35620-->.

     To synchronize the time range of the timeline with that of another component in the dashboard or low-code app, click the ![Link to feed](~/user-guide/images/Link_to_Feed.png) icon next to *Link time range to feed* and select the component from the dropdown list, such as a time range component. Modifying the default time frame for this component will automatically synchronize the time range for any linked timeline component as well.

     If the timeline is linked to another component, the timeline will dynamically adjust to the selected time range of the linked component. For example, if you switch the time range in the linked component to *This week*, the timeline will automatically update to display the corresponding time frame.

     > [!NOTE]
     > To add a [time range component](xref:DashboardTimeRangeFeed) to the dashboard or low-code app that displays the time range configured for the timeline component<!--RN 33287-->:
     >
     > 1. Select *Timeline # > Viewport > Timespans* in the *Feeds* section of the *Data* tab.
     > 1. Drag it onto an empty section of the dashboard or low-code app page.
     >
     > When you manually adjust the time range by zooming in or out, or by moving across the timeline component, the time range displayed in the time range component will automatically be adjusted.
     >
     > Note that modifying the time range displayed in the time range component will not update the time range displayed in the timeline component, unless it has been linked to that time range component in the *Default time range* settings.

   - *Data retrieval > Update data*: Allows updates to be enabled or disabled. This setting will enable real-time updates for all queries executed by the selected component. Disabled by default.

   - *Highlight range > Use highlighting*: Determines whether a configured time range in the timeline component is highlighted. When this option is enabled, the section of the timeline that falls within the set time range receives a different background color determined by the [dashboard theme](xref:Configuring_the_dashboard_layout#customizing-the-dashboard-theme) or the [low-code app theme](xref:LowCodeApps_Layout#customizing-the-theme-for-a-low-code-app-page). Events that (partially) occur within this set time range are displayed with normal opacity, while those outside the time range are displayed with lowered opacity. Disabled by default<!--RN 33639-->.

     ![Highlight](~/user-guide/images/Timeline_Highlight.png)<br/>*Timeline component in DataMiner 10.4.1*

     To link the time range of another component in the dashboard or low-code app to the timeline component, click the ![Link to feed](~/user-guide/images/Link_to_Feed.png) icon next to the *Time range* dropdown box, and select the desired component from the dropdown list. Adjusting the highlight time range of this chosen component will automatically synchronize the time range for the linked timeline component as well.

1. Fine-tune the component layout. In the *Component* > *Layout* tab, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

   - *Filtering & Highlighting*: Available from DataMiner 10.1.11/10.2.0 onwards<!--RN 33276-->. Allows you to configure a number of filtering and highlighting options. However, note that the filtering options require the [Query filter component](xref:DashboardQueryFilterFeed), available from DataMiner 10.3.9/10.4.0 onwards.

     - *Highlight*: When this option is enabled, the items that match the filter will be highlighted. Enabled by default.

     - *Opacity*: When the *Highlight* option is enabled, this option will allow you to set the level of transparency of the items that do not match the filter.

       > [!NOTE]
       > When you disable the *Highlight* option, the items that do not match the filter will no longer be displayed and the remaining items will be reorganized.

     ![Filtering & Highlighting](~/user-guide/images/Filtering_Highlighting.png)<br/>*Query filter and timeline components in DataMiner 10.4.1*

   - *Advanced > Empty result message*: Available from 10.3.11/10.4.0 onwards<!-- RN 37173 -->. Allows you to specify a custom message that is displayed when a query returns no results.

     > [!TIP]
     > See also: [Displaying a custom empty component message](xref:Tutorial_Dashboards_Displaying_a_custom_empty_component_message).

   - *Advanced > Style*: Allows you to edit the style of the timeline component. The following options are available:

     - *Grouping by*: Determines whether the name of the column the data was grouped by (optionally) is displayed in the timeline component. Disabled by default.

     - *Segment lines*: Determines whether segment lines are displayed in the timeline component. Enabled by default.

     - *Lock timeline to now*: Determines whether a "now" indicator is set at a fixed position on the timeline. When this option is enabled, users can zoom in and out on the timeline, but are restricted from panning past the indicator. Disabled by default.

   - *Item templates*: Allows you to freely customize the appearance of the timeline component items using the Template Editor<!--RN 33311-->.

     - To access the Template Editor, click *Edit* next to the pencil icon.

       > [!TIP]
       > For more information on how to use the Template Editor to customize the appearance of component items, see [Using the Template Editor](xref:Template_Editor).

     - To reuse previously saved templates for components in the same dashboard or low-code app, click *Reuse template* next to the ![reuse template](~/user-guide/images/Reuse_Template.png) button<!--RN 34948-->.

       > [!NOTE]
       > This option is only visible when another timeline component in the dashboard or low-code app is configured with a custom template.

## Zooming and panning

In read mode, you can manipulate the timeline component to navigate through the scheduled events, bookings, or time-bound data.

- Adjusting the displayed time range:

  - To **zoom in** on the timeline component, press CTRL while scrolling up.

  - To **zoom out**, press CTRL while scrolling down.

  > [!NOTE]
  > The component has a minimum time range of 5 milliseconds and a maximum of 10 years, setting the zoom limit<!--RN 35620-->.

- To **move left or right** across the timeline component, click the timeline and drag your mouse.

  > [!NOTE]
  > If you have enabled the *Lock timeline to now* setting, you will be unable to pan past the "now" indicator.

- If the number of items exceeds the size of the component, a scrollbar appears when you hover over the component, allowing you to **navigate up or down** through the items.

> [!NOTE]
> When visualized on a mobile device<!--RN 35619-->:
>
> - You can zoom in on the component by placing your thumb and index finger tips together on the screen and moving them apart. To zoom out, use a pinching motion, starting with your fingers apart and bringing them together.
> - You can move left or right by sliding one finger across the component.
