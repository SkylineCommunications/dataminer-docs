---
uid: DashboardTimeRangeFeed
---

# Time range feed

This dashboard feed allows the user to specify a time range.

To configure the component:

1. Optionally, customize the following component options in the *Component* > *Settings* tab:

   - *Default range*: The default range selected in the component. By default set to *Today so far*.

   - *Allow refresh*: Determines whether the component includes a refresh timer. By default disabled.

   - *Refresh rate*: If *Allow refresh* is selected, this setting determines after how many seconds the data is refreshed. By default set to 10 seconds.

1. Optionally, fine-tune the component layout. In the *Component* > *Layout* tab, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

   - *Show refresh timer*: Determines whether an indication is displayed that the data will be refreshed.

   - *Presets*: Available from DataMiner 10.3.10/10.4.0 onwards<!--RN 37050-->. Allows you to customize the presets displayed when you select the component. The following presets are available: *Still busy*, *In the past*, *Recently*, *Long run*, *Starting from now*, *Near future*, and *Distant future*.

     > [!NOTE]
     > Prior to DataMiner 10.3.10/10.4.0, the default presets include *Still busy*, *In the past*, *Recently*, and *Long run*. These presets cannot be edited.

   - *Use quick picks*: Available from DataMiner 10.0.2 onwards. Determines whether the component includes quick pick buttons that allow users to enter a preset time range by clicking a single button.

   - *Pinning as quick pick*: Available from DataMiner 10.0.12 onwards, if *Use quick picks* is enabled. Displays a pin icon next to the time summary in the component, which can be used to add the current time selection as a custom quick pick button. If the current time selection matches the custom quick pick button, clicking the pin icon again will remove the button. You can also remove the button using the garbage can icon on the button itself.
