---
uid: DashboardDropdown
---

# Dropdown

This basic control allows the user to select an item in a dropdown list. The selectable items can be based on any data feed.

> [!NOTE]
> Prior to DataMiner 10.3.5/10.4.0<!--  RN 35902 -->, this component is available under *Feeds*.

To configure the component:

1. Apply the necessary data feeds. See [Applying a data feed](xref:Apply_Data_Feed).

1. Optionally, fine-tune the component layout. In the *Component* > *Layout* tab, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

   - *Label*: Allows you to specify text that should be displayed next to the dropdown box.

1. Optionally, customize the following component options in the *Component* > *Settings* tab:

   - *WebSocket settings*: Allows you to customize the polling interval for this component. To do so, clear the checkbox in this section and specify the custom polling interval.

   - *Initial Selection > Select first item by default*: Available from DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 onwards<!--RN 38775-->. Sets the first item as the value that will be applied in the feed when the dashboard is opened, unless a custom URL is used specifying a different value. This setting is enabled by default.

   - *Initial Selection > Select item by default*: Allows you to specify a default value. This is the value that will be applied in the feed when the dashboard is opened, unless a custom URL is used specifying a different value. From DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 onwards<!--RN 38775-->, this setting is only available when the *Select first item by default* setting is disabled.

     > [!NOTE]
     >
     > - Prior to DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4<!--RN 38775-->, this setting is called *Initial Selection* instead.
     > - Prior to DataMiner 10.3.6/10.4.0<!--  RN 35984 -->, this setting is called *Feed Defaults* instead.

   - *Clear selection*: Available from DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 onwards<!--RN 38758-->. Allows you to clear the selected values in the component by clicking the X button in the top-right corner of the filter box. This setting is disabled by default.
