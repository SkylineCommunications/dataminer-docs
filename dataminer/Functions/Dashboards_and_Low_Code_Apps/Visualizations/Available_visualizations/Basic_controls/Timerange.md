---
uid: TimeRange
---

# Time range

The time range component allows you to specify a time range, which can then for example be used as a filter for compatible components such as the [line & area chart](xref:LineAndAreaChart). You can either select a **preset** or a **quick pick button**, or manually set a **custom time range**. When you modify the time range in this component, the data displayed in any linked component is updated accordingly.

> [!NOTE]
> Prior to DataMiner 10.4.0 [CU12]/10.5.3<!--RN 41934-->, this component is available under *General*.

![Time range](~/dataminer/images/Time_Range.png)<br>*Time range component in DataMiner 10.5.3*

- Presets (1): Presets are predefined time selections that allow you to quickly adjust the displayed time range without manually specifying start and end times. Examples include *Last 2 days*, *Last 5 minutes*, and *Last year*. You can access a list of presets by clicking the ![Calendar](~/dataminer/images/Calendar_Icon.png) icon or the ![Clock](~/dataminer/images/Clock_Icon.png) icon (depending on your DataMiner version<!--RN 42082-->). From DataMiner 10.4.0 [CU12]/10.5.3 onwards<!--RN 42082-->, you can filter this list using the search box.

  > [!NOTE]
  > Prior to DataMiner 10.4.0 [CU12]/10.5.3<!--RN 42082-->, if you use a sliding window preset like *Last 15 minutes* and filter another component, the data will dynamically update. As a result, the time range shown in the time range component may not match the one used in the linked component, unless the *Allow refresh* setting is enabled and the refresh rate is set to at least once per minute.

- Quick picks (2): Quick pick buttons are presets that can be added as fixed buttons to the time range component for quick access to frequently used time ranges. You can enable the *Use quick picks* option in the *Layout* pane, where you can also configure which buttons to include.

- Custom time range (3): You can manually set a custom time range by specifying a start and end time. If the *Pinning as quick pick* option is enabled in the *Layout* pane, you can save the time selection as a custom quick pick button.

  - From DataMiner 10.4.0 [CU12]/10.5.3 onwards<!--RN 42082-->, you can either enter a custom start and end time in the input box (in `DD/MM/YYYY HH:MM` or `DD/MM/YYYY` format, depending on the level of granularity) or click the ![Calendar](~/dataminer/images/Calendar_Icon.png) icon to open the *Calendar* pane, where you can select the start and end time using the calendar interface.

  - Prior to DataMiner 10.4.0 [CU12]/10.5.3, click the ![Clock](~/dataminer/images/Clock_Icon.png) icon and specify the start and end time manually.

When you select a preset or quick pick, the time range will be updated immediately. If the time range is used as a filter, the component data will also update immediately. When you manually enter a custom time range in the input box, the data will be updated based on the *Emit value on* setting (*Enter*, *Focus lost*, or *Value change*). When you set a custom time range using the calendar interface or the custom time range editor (prior to DataMiner 10.4.0 [CU12]/10.5.3<!--RN 42082-->), the data will only be updated after you click the *Apply* button. If you have not yet clicked this button, you can revert any changes by clicking *Cancel*. Prior to DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11<!--RN 40622-->, the data is always updated immediately after the time range is changed.

## Configuring the component

To configure the component:

1. Optionally, customize the following component options in the *Component* > *Settings* pane:

   - *Default range*: The default range selected in the component. By default set to *Today so far*.

   - *Allow refresh*: Available up to DataMiner 10.4.0 [CU11]/10.5.2<!--RN 41931-->. Determines whether the component includes a refresh timer. By default disabled.

     From DataMiner 10.4.0 [CU11]/10.5.2 onwards, you can use a [trigger component](xref:DashboardTrigger) to refresh data instead.

   - *Refresh rate*: If *Allow refresh* is selected, this setting determines after how many seconds the data is refreshed. By default set to 10 seconds.

     Prior to DataMiner 10.4.0 [CU12]/10.5.3<!--RN 42082-->, if you are using a sliding window preset and filtering another component with it, the refresh rate should be set between 5 to 60 seconds to prevent any mismatch between the time range displayed and the actual time range used in the filtered component.

   - *Granularity*: Available from DataMiner 10.4.0 [CU12]/10.5.3 onwards<!--RN 42082-->. Determines the level of detail required when setting a time range:

     - *Date & time* (default): Both dates and times must be specified for the start and end times, e.g. `05/02/2025 12:05 to 06/02/2025 13:15`. The start and end times cannot be identical.

     - *Date*: Only the dates must be specified for the start and end times, e.g. `05/02/2025 to 06/02/2025`. If the same date  is entered for both the start and end time, the time range will cover the full 24 hours (from midnight to midnight).

   - *Emit value on*: Available from DataMiner 10.4.0 [CU12]/10.5.3 onwards<!--RN 42082-->. Determines when the time range entered in the input box becomes available as data. This can be when the user presses Enter ("Enter"), when the focus is no longer on the box ("Focus lost"), or when the value in the box changes ("Value change"). If you select *Focus lost*, the value will also become available when the user presses Enter.

   - *Edit using*: Available from DataMiner 10.4.0 [CU12]/10.5.3 onwards<!--RN 42082-->. Determines how the time range can be modified:

     - *Keyboard & calendar*: Allows you to enter a custom time range manually in the input box (format: `DD/MM/YYYY HH:MM`) or select one using the calender interface, which you can access by clicking the ![Calendar](~/dataminer/images/Calendar_Icon.png) icon.

     - *Calendar*: Allows you to set a custom time range only by clicking the ![Calendar](~/dataminer/images/Calendar_Icon.png) icon and selecting the dates in the calendar interface.

       > [!NOTE]
       > If your dashboard or low-code app contains time range components created before upgrading to DataMiner 10.4.0 [CU12]/10.5.3, they will default to *Calendar* to maintain the previous behavior of the component.

1. Optionally, fine-tune the component layout. In the *Component* > *Layout* pane, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

   - *Layout & Alignment* > *Quick pick alignment*: Determines the horizontal alignment of the quick picks (left, center, right, or justify).

     > [!NOTE]
     > Prior to DataMiner 10.4.0 [CU12]/10.5.3<!--RN 42082-->, this setting is called *Horizontal alignment* instead, and only *left*, *center*, and *right* are available.

   - *Layout & Alignment* > *Input alignment*: Determines the horizontal alignment of the current time range (left, center, or right). This option is only visible when the *Show current range* setting is enabled.

     > [!NOTE]
     > Prior to DataMiner 10.4.0 [CU12]/10.5.3<!--RN 42082-->, this setting is called *Align current time position* instead.

   - *Show refresh timer*: Available up to DataMiner 10.4.0 [CU11]/10.5.2<!--RN 41931-->. Determines whether an indication is displayed that the data will be refreshed.

   - *Presets*: Available from DataMiner 10.3.10/10.4.0 onwards<!--RN 37050-->. Allows you to customize the presets displayed when you select the component (1). The following presets are available: *Still busy*, *In the past*, *Recently*, *Long run*, *Starting from now*, *Near future*, and *Distant future*.

     > [!NOTE]
     > Prior to DataMiner 10.3.10/10.4.0, the default presets include *Still busy*, *In the past*, *Recently*, and *Long run*. These presets cannot be edited.

   - *Use quick picks*: Determines whether the component includes quick pick buttons (2) that allow users to enter a preset time range by clicking a single button.

   - *Pinning as quick pick*: Available if *Use quick picks* is enabled. Displays a pin icon (3) next to the time summary in the component, which can be used to add the current time selection as a custom quick pick button. If the current time selection matches the custom quick pick button, clicking the pin icon again will remove the button. You can also remove the button using the garbage can icon on the button itself.

   - *Show current range*: Determines whether the current time range is displayed at the top of the component (4).

   ![Time range](~/dataminer/images/TimeRange.png)<br>*Time range component in DataMiner 10.5.3*

## Component actions

From DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11 onwards<!--RN 40569-->, when you have added a time range component to a low-code app, you can configure the following [component action](xref:LowCodeApps_event_config#executing-a-component-action) in your low-code app to interact with the component:

- *Set value*: Allows you to set the current value of the component to a preset or custom time range.

  ![Example](~/dataminer/images/Set_Value_Time_Range.gif)<br>*Time range, button, and line & area chart components in DataMiner 10.5.3*
