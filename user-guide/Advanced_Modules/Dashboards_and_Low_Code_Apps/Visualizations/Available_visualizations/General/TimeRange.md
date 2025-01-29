---
uid: DashboardTimeRange
---

# Time range

This component allows the user to specify a time range. You can either select a **quick pick button** or a **preset**, or manually set a **custom time range**.

This time range can be used as a filter for compatible components, such as the [line & area chart](xref:LineAndAreaChart). When you modify the time range in the component, the time span displayed in the filtered component will update accordingly.

> [!NOTE]
> From DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11 onwards<!--RN 40622-->, when you set a custom time range, the data of the component is only updated after you click the *Apply* button. If you have not yet clicked this button, you can revert any changes to the custom time range by clicking *Cancel*. In previous versions, changing the custom time range automatically updates the component data.

![Time range](~/user-guide/images/Time_Range.png)<br>*Time range component in DataMiner 10.4.11*

## Configuring the component

To configure the component:

1. Optionally, customize the following component options in the *Component* > *Settings* pane:

   - *Default range*: The default range selected in the component. By default set to *Today so far*.

   - *Allow refresh*: Determines whether the component includes a refresh timer. By default disabled.

   - *Refresh rate*: If *Allow refresh* is selected, this setting determines after how many seconds the data is refreshed. By default set to 10 seconds.

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

   ![Time range](~/user-guide/images/TimeRange.png)<br>*Time range component in DataMiner 10.4.11*

## Component actions

From DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11 onwards<!--RN 40569-->, when you have added a time range component to a low-code app, you can configure the following [component action](xref:LowCodeApps_event_config#executing-a-component-action) in your low-code app to interact with the component:

- *Set value*: Allows you to set the current value of the component to a preset or custom time range.

  ![Example](~/user-guide/images/Set_Value_Time_Range.gif)<br>*Time range, button, and line & area chart components in DataMiner 10.4.11*
