---
uid: DashboardTimeline
---

# Timeline

Available from DataMiner 10.4.1/10.5.0 onwards<!--RN 37812-->.

The timeline component is a versatile tool tailored for managing bookings, events, and other time-bound data. It is not only useful as an overview of time-sensitive items, but also allows for near-unlimited customization.

![Timeline](~/dataminer/images/Timeline.png)<br>*Timeline component in DataMiner 10.4.5*

with this component, you can:

- See your time-bound data [organized by resource, assignee, or any other common attribute](#grouping-items-in-a-timeline).

- Enjoy timeline items that reflect their context visually and let you interact with them intuitively.

## Supported data types

The timeline component is used to display the results of queries in a timeline format. It should therefore **always be configured with [query data input](xref:Query_Data)**.

Each row in a query corresponds to an item on your timeline.

## Grouping items in a timeline

You can group items on a timeline to **organize them by a common attribute**, such as category, resource, or assignee. This allows you to quickly see which items belong together and makes it easier to compare groups side by side.

To group items on the timeline based on one of the columns in your data<!--35638-->:

1. Hover over the component and click the ![Groups](~/dataminer/images/NewRD_Groups.png) icon.

   After you click this icon, compatible data will be marked with the ![available groups](~/dataminer/images/Group_Icon.png) icon in the *Data* pane.

1. Drag compatible data onto the component.

   All groups are now displayed in a gray column to the left of the timeline<!--RN 33694-->. The timeline items are displayed next to the group they are part of.

   ![Timeline groups](~/dataminer/images/Groups_Timeline.png)

   > [!NOTE]
   > If a group is empty (i.e. there is no start and end time), it is still displayed in the timeline component<!--RN 35600-->.

## Timeline layout

In the *Layout* pane, you can find the default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

Additionally, the following layout options are also available:

| Section | Option | Description |
|--|--|--|
| Filtering & Highlighting | Highlight | Available from DataMiner 10.1.11/10.2.0 onwards<!--RN 33276-->. Toggle the switch to determine whether the items that match the criteria specified in a query filter will be highlighted. Enabled by default. For more information, see [Highlighting filtered results](#highlighting-filtered-results). |
| Filtering & Highlighting | Opacity | Available from DataMiner 10.1.11/10.2.0 onwards<!--RN 33276-->. Set the level of transparency of the items that do not match the criteria specified in a query filter. This option is only available when *Highlight* is enabled. For more information, see [Highlighting filtered results](#highlighting-filtered-results). |
| Advanced | Empty result message | Available from 10.3.11/10.4.0 onwards<!-- RN 37173 -->. Specify a custom message that is displayed when a query returns no results. See also: [Displaying a custom empty component message](xref:Tutorial_Dashboards_Displaying_a_custom_empty_component_message). |
| Style | Grouping by | Toggle the switch to determine whether the name of the column the data was grouped by (optionally) is shown. Disabled by default. |
| Style | Segment lines | Toggle the switch to determine whether segment lines are displayed in the timeline component. Enabled by default. |
| Style | Lock timeline to now | Select the checkbox to set a "now" indicator at a fixed position on the timeline. When this option is enabled, users can zoom in and out on the timeline, but are restricted from panning past the indicator. Disabled by default. |
| Item templates | Browse templates *or*<br>Reuse template (prior to DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4) | Reuse a saved template from another component in the same dashboard or low-code app. This option is only available if a template is already in use<!--RN 42226-->. |
| Item templates | Edit | Open the Template Editor<!--RN 34761--> to customize the appearance of timeline items and configure actions, such as opening a panel when a cell is selected. For more information, refer to [Customize grid items](#customizing-grid-items). |

     - To reuse saved templates for components in the same dashboard or low-code app, click *Browse templates* next to the ![Browse templates](~/dataminer/images/Browse_Templates.png) button<!--RN 42226-->. Prior to DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4, click *Reuse template* next to the ![reuse template](~/dataminer/images/Reuse_Template.png) button instead<!--RN 34948-->.

       > [!NOTE]
       > Prior to DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4, the option to reuse a template is only available when another timeline component in the dashboard or low-code app is configured with a custom template.

### Highlighting filtered results

<!--There may be two ways to highlight filtered results. Research this and add both under this section.-->

![Filtering & Highlighting](~/dataminer/images/Filtering_Highlighting.png)<br/>*Query filter and timeline components in DataMiner 10.4.1*

### Customizing timeline items

Using the Template Editor, you can fully **customize the appearance** of each timeline item. Additionally, [conditional cases](xref:Template_Editor#adding-conditional-cases-to-a-layer) allow you not only to modify how items look **when certain conditions are met**, but also to update their underlying data simultaneously.

To access the Template Editor:

1. In the *Layout* pane, navigate to the *Item templates* section.

   This section shows a preview of the template currently applied to the timeline component.

1. Click *Edit* to open the Template Editor.

1. Make your changes as described under [Using the Template Editor](xref:Template_Editor).

Some **real-life examples**:

- In this example, the Template Editor was used to add an icon in the lower-left corner of each timeline item, indicating whether a task is not started, on hold, or active (represented by an hourglass, pause, or play icon, respectively).

  ![Timeline - Change state](~/dataminer/images/TimelineChangeState.gif)<br>*Timeline component in DataMiner 10.5.4*

  Beyond changing the visual appearance, actions were configured on the icon layer so that clicking it opens a context menu. This menu allows users to manually update the icon and, at the same time, modify the underlying task status via an Automation script.

- In this example, the timeline component is used as an interactive TV schedule, styled with customized colors, icons, and more. A conditional case ensures that when a program has been recorded, a red dot appears in the top-right corner of the item.

  ![Timeline - TV schedule](~/dataminer/images/TimelineTVSchedule.png)<br>*Timeline component in DataMiner 10.4.1*

## Timeline settings

## Configuring the component


   1. If you want to display the name of the column the data was grouped by, make sure the *Advanced > Style > Grouping by* setting is enabled in the *Layout* pane.

1. Optionally, customize the following component options:

   - *WebSocket settings*: Determines whether the websocket settings configured in the page/panel settings should be applied to this component. Enabled by default.

   - *General > Timeline*: Allows you to configure the start and end times of the timeline component. When you add a new timeline component, this is automatically configured<!--RN 33657-->.

   - *General > Override dynamic units*: Disables parameter units from changing dynamically based on their value and protocol definition. Disabled by default.

   - *General > Use dynamic units*: When the *Override dynamic units* option is enabled, this option will allow you to determine whether parameter units will change dynamically based on their value and protocol definition.

   - *General > Default time range*: Allows you to select an option with a particular time to zoom to this time on the timeline, e.g. *Today*, *Last 7 days*, *Next hour*, etc. The options are divided into the following categories: *Still busy*, *In the past*, *Near future*, *Recently*, *Long run*, *Starting from now*, and *Distant future*. Set to *Still busy, This week* by default<!--RN 33287-->.

     If you select *Custom*, you can set a custom start and end time.

     ![Custom time range](~/dataminer/images/Default_Time_Range.png)<br/>*Settings timeline component in DataMiner 10.4.1*

     > [!NOTE]
     > The component has a minimum time range of 5 milliseconds and a maximum of 10 years<!--RN 35620-->.

     To synchronize the time range of the timeline with that of another component in the dashboard or low-code app, click the ![Link to data](~/dataminer/images/Link_to_Data.png) icon next to *Link time range* (Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12<!--RN 41141-->: *Link time range to feed*) and select the component from the dropdown list, such as a time range component.

     Modifying the default time frame for this component will automatically synchronize the time range for any linked timeline component as well. The timeline will dynamically adjust to the selected time range of the linked component. For example, if you switch the time range in the linked component to *This week*, the timeline will automatically update to display the corresponding time frame.

     From DataMiner 10.4.0 [CU10]/10.5.0/10.5.1 onwards<!--RN 41251-->, a timeline linked to other data can be identified by the ![Unlink](~/dataminer/images/Unlink.png) icon displayed next to *Link time range*. To unlink the timeline, click this icon and select *Unlink*.

     > [!NOTE]
     > To add a [time range component](xref:DashboardTimeRange) to the dashboard or low-code app that displays the time range configured for the timeline component<!--RN 33287-->:
     >
     > 1. Select *Timeline > Viewport > Timespans* in the *Components* section of the *Data* pane. Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12, this data source can be found in the *Feeds* section of the *Data* pane.
     > 1. Drag it onto an empty section of the dashboard or low-code app page.
     >
     > When you manually adjust the time range by zooming in or out, or by moving across the timeline component, the time range displayed in the time range component will automatically be adjusted.
     >
     > Note that modifying the time range displayed in the time range component will not update the time range displayed in the timeline component, unless it has been linked to that time range component in the *Default time range* settings.

   - *Data retrieval > Update data*: Allows the component to be updated in real time, if the data supports this (see [Query updates](xref:Query_updates)). Disabled by default.

     > [!NOTE]
     > If you enable this setting, real-time updates will only be applied for the data sources and operators listed on the [Query updates](xref:Query_updates) page. Prior to DataMiner 10.4.0/10.4.3<!-- RN 37372 -->, data will only be updated every 30 seconds, and this will only be applied for GQI queries using the [Get parameter table by ID](xref:Get_parameter_table_by_ID) data source.

   - *Events*: See [Configuring events and actions](#configuring-events-and-actions).

   - *Highlight range > Use highlighting*: Determines whether a configured time range in the timeline component is highlighted. When this option is enabled, the section of the timeline that falls within the set time range receives a different background color determined by the [dashboard theme](xref:Configuring_the_dashboard_layout#customizing-the-dashboard-theme) or the [low-code app theme](xref:LowCodeApps_Layout#customizing-the-theme-for-a-low-code-app-page). Events that (partially) occur within this set time range are displayed with normal opacity, while those outside the time range are displayed with lowered opacity. Disabled by default<!--RN 33639-->.

     ![Highlight](~/dataminer/images/Timeline_Highlight.png)<br/>*Timeline component in DataMiner 10.4.1*

     To link the time range of another component in the dashboard or low-code app to the timeline component, click the ![Link to data](~/dataminer/images/Link_to_Data.png) icon next to the *Time range* dropdown box, and select the desired component from the dropdown list. Adjusting the highlight time range of this chosen component will automatically synchronize the time range for the linked timeline component as well.

     From DataMiner 10.4.0 [CU10]/10.5.0/10.5.1 onwards<!--RN 41251-->, a timeline linked to other data can be identified by the ![Unlink](~/dataminer/images/Unlink.png) icon displayed next to the *Time range* dropdown box. To unlink the timeline, click this icon and select *Unlink*.



## Using the timeline component in read mode

- In read mode, you can manipulate the timeline component to navigate through the scheduled events, bookings, or time-bound data.

  - Adjusting the **displayed time range**:

    - From DataMiner 10.4.0 [CU10]/10.5.1 onwards<!--RN 41387-->, the zooming method depends on the *Advanced* > *Hold Ctrl to zoom* setting in the *Settings* pane:

      - When this setting is enabled: Hold the Ctrl key while scrolling up or down to zoom in or out.

      - When this setting is disabled: Scroll up or down to zoom in or out. This is the default option.

    - Prior to DataMiner 10.4.0 [CU10]/10.5.1:

      - To **zoom in** on the timeline component, press Ctrl while scrolling up.

      - To **zoom out**, press Ctrl while scrolling down.

    - When you are using a mobile device<!--RN 35619-->, you can zoom in on the component by placing two fingers together on the screen and moving them apart. To zoom out, use a pinching motion, starting with your fingers apart and bringing them together.

    > [!NOTE]
    > The component has a minimum time range of 5 milliseconds and a maximum of 10 years, setting the zoom limit<!--RN 35620-->.

  - To **move left or right** across the timeline component, click the timeline and drag the mouse. When you are using a mobile device<!--RN 35619-->, you can move left or right by sliding one finger across the component.

    > [!NOTE]
    > If you have enabled the *Lock timeline to now* setting, you will be unable to pan past the "now" indicator.

  - If the number of items exceeds the size of the component, a scrollbar appears when you hover over the component, allowing you to **navigate up or down** through the items.

- From DataMiner 10.4.0 [CU13]/10.5.0 [CU1]/10.5.4 onwards<!--RN 42322-->, when you **select an item in the timeline**, it will by default be highlighted with a blue border and a light-blue background. This can for instance be useful when the timeline's [component data](xref:Component_Data) (i.e. *Components* > *Timeline* > *Selected groups* / *Selected time ranges*) is used in a linked component, clearly indicating which data is driving the content in the linked component.

## Configuring events and actions

From DataMiner 10.3.0 CU14/10.4.0 CU2/10.4.5 onwards<!-- RN 39254 -->, in the component options for a timeline component in a low-code app, you can configure the following **events** to trigger actions:

- *On Range select*: Triggered when a section of the timeline is selected using the right mouse button.

- *On item resize*: Triggered when an item on the timeline is resized.

- *On item move*: Triggered when the time slot of an item on the timeline is changed.

- *On group change*: Triggered when an item on the timeline is moved to another group.

![Events](~/dataminer/images/Events_Setting.png)<br/>*Events setting in DataMiner 10.4.5*

> [!NOTE]
>
> - These events can only be triggered when they have actions configured. For example, an item will only be resized when at least one action has been configured for the *Item resize* event.
> - While the *On range select* event is timeline-based, other events can have a different configuration for each query on the timeline. For example, if there are multiple queries on the timeline, and you move an item belonging to a certain query, the timeline will look at the configuration of actions for the *On move* event of that specific query to decide which actions to execute.

You can configure the following **[component actions](xref:LowCodeApps_event_config#executing-a-component-action)** to be triggered by these events:

- *Fetch the data*: Fetches the data for the component. This action is already available as from DataMiner 10.2.10/10.3.0 for all components using query data as input.

- *Highlight time range*: Highlights a range on the timeline component. The highlighted section will expose data in the form of a *Timespan* object. If multiple sections are highlighted, the data will contain an array of *Timespan* objects.

- *Clear highlights*: Clears all highlights set by *Highlight time range* actions.

- *Set viewport*: Sets the viewport of the timeline to a certain time range<!-- RN 39254 -->.

> [!NOTE]
> Prior to DataMiner 10.3.0 CU14/10.4.0 CU2/10.4.5, highlights can be configured using the *Highlight range* setting. This setting is still available in later DataMiner versions and can be used in combination with highlights set by actions. Its behavior remains the same: a highlight set by the *Highlight range* setting will not expose data and it will not be cleared by the *Clear highlights* action.

The value of input for events can be configured to be **linked to data**. From DataMiner 10.3.0 CU14/10.4.0 CU2/10.4.5, you can also **link the input to information provided by the event** itself. All timeline events expose information relevant to the event in question. The following information is provided for each event:

- *Range select*: Provides a *from* and a *to* property, both of type *Timespan*.

- *Item resize*: Provides an old and a new *Timespan* pair, indicating the start and the end of the item before and after the resize event. It also provides information about the resized item in the form of a *Query row* object.

- *Item move*: Provides the same information as the *Item resize* event.

- *Group change*: Provides information about the current state of the item and the new state, both as *Query row* objects.

![Event info](~/dataminer/images/Event_Info_Configured.png)<br/>*Event editor in DataMiner 10.4.5*

> [!TIP]
> When interacting with the timeline, from DataMiner 10.3.0 CU14/10.4.0 CU2/10.4.5 onwards<!-- RN 39254 -->, you can use the following keys:
>
> - *ESCAPE*: When you press this key while interacting with an item on the timeline, you will cancel the interaction and move the item back to its original place.
> - *SHIFT*: When you keep this key pressed while moving an item on the timeline, the movement will be more precise.
> - *CONTROL*: When you move an item horizontally, a larger movement is needed to also make it move vertically (and vice versa). If you want to override this default behavior and move the item with precision, both vertically and horizontally, keep this key pressed.

## Enabling the component in soft launch

From DataMiner 10.1.10 onwards, the timeline component is available in soft launch, if the soft-launch option *ReportsAndDashboardsScheduler* is enabled. For more information, see [Soft-launch options](xref:SoftLaunchOptions).

If you use the preview version of the timeline component, its functionality may be different from what is described on this page.
