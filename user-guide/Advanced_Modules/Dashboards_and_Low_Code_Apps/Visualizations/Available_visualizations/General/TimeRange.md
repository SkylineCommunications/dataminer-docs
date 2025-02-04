---
uid: DashboardTimeRange
---

# Time range

The time range component allows you to specify a time range, which can then be used as a filter for compatible components such as the [line & area chart](xref:LineAndAreaChart). You can either select a **quick pick button** or a **preset**, or manually set a **custom time range**.

The time range passed to a filtered component is always consistent with the one shown in the time range component itself. When you modify the time range in this component, the data displayed in any filtered component is updated accordingly. For example, selecting the *Last 24 hours* preset will display data for the last 24 hours and update the filtered components to match that time range.

> [!NOTE]
>
> - Prior to DataMiner 10.4.0 [CU12]/10.5.3<!--RN 42082-->, if you use a sliding window preset like *Last 24 hours* and filter another component, the data will dynamically update. As a result, the time range shown in the time range component may not match the one used in the linked component, unless the *Allow refresh* setting is enabled and the refresh rate is set to at least once per minute.
> - From DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11 onwards<!--RN 40622-->, when you set a custom time range, the data of the component is only updated after you click the *Apply* button. If you have not yet clicked this button, you can revert any changes to the custom time range by clicking *Cancel*. In previous versions, changing the custom time range automatically updates the component data.

![Time range](~/user-guide/images/Time_Range.png)<br>*Time range component in DataMiner 10.5.3*

## Configuring the component

To configure the component:

1. Optionally, customize the following component options in the *Component* > *Settings* pane:

   - *Default range*: The default range selected in the component. By default set to *Today so far*.

   - *Allow refresh*: Available up to DataMiner 10.4.0 [CU11]/10.5.2<!--RN 42082-->. Determines whether the component includes a refresh timer. By default disabled.

     From DataMiner 10.4.0 [CU11]/10.5.2 onwards, you can use a [trigger component](xref:DashboardTrigger) to refresh data instead.

   - *Refresh rate*: If *Allow refresh* is selected, this setting determines after how many seconds the data is refreshed. By default set to 10 seconds.

     Prior to DataMiner 10.4.0 [CU12]/10.5.3<!--RN 42082-->, if you are using a sliding window preset and filtering another component with it, the refresh rate should be set between 5 to 60 seconds to prevent any mismatch between the time range displayed and the actual time range used in the filtered component.

1. Optionally, fine-tune the component layout. In the *Component* > *Layout* pane, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

   - *Layout & Alignment* > *Horizontal alignment*: Determines the horizontal alignment of the quick picks (left, center, or right).

   - *Layout & Alignment* > *Align current time position*: Determines the horizontal alignment of the current time range (left, center, or right). This option is only visible when the *Show current range* setting is enabled.

   - *Show refresh timer*: Determines whether an indication is displayed that the data will be refreshed.

   - *Presets*: Available from DataMiner 10.3.10/10.4.0 onwards<!--RN 37050-->. Allows you to customize the presets displayed when you select the component (1). The following presets are available: *Still busy*, *In the past*, *Recently*, *Long run*, *Starting from now*, *Near future*, and *Distant future*.

     > [!NOTE]
     > Prior to DataMiner 10.3.10/10.4.0, the default presets include *Still busy*, *In the past*, *Recently*, and *Long run*. These presets cannot be edited.

   - *Use quick picks*: Determines whether the component includes quick pick buttons (2) that allow users to enter a preset time range by clicking a single button.

   - *Pinning as quick pick*: Available if *Use quick picks* is enabled. Displays a pin icon (3) next to the time summary in the component, which can be used to add the current time selection as a custom quick pick button. If the current time selection matches the custom quick pick button, clicking the pin icon again will remove the button. You can also remove the button using the garbage can icon on the button itself.

   - *Show current range*: Determines whether the current time range is displayed at the top of the component (4).

   ![Time range](~/user-guide/images/TimeRange.png)<br>*Time range component in DataMiner 10.5.3*

## Component actions

From DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11 onwards<!--RN 40569-->, when you have added a time range component to a low-code app, you can configure the following [component action](xref:LowCodeApps_event_config#executing-a-component-action) in your low-code app to interact with the component:

- *Set value*: Allows you to set the current value of the component to a preset or custom time range.

  ![Example](~/user-guide/images/Set_Value_Time_Range.gif)<br>*Time range, button, and line & area chart components in DataMiner 10.5.3*
