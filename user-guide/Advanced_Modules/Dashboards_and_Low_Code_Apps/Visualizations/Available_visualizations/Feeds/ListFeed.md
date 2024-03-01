---
uid: DashboardListFeed
---

# List feed

This dashboard feed allows the user to select one or more items in a list. The selectable items can be based on any data feed.

To configure the component:

1. Apply the necessary data feeds. See [Applying a data feed](xref:Apply_Data_Feed).

1. Optionally, fine-tune the component layout. See [Customizing the component layout](xref:Customize_Component_Layout).

1. Optionally, customize the following component options in the *Component* > *Settings* tab:

   - *WebSocket settings*: Allows you to customize the polling interval for this component. To do so, clear the checkbox in this section and specify the custom polling interval.

   - *Initial Selection > Select first item by default*: Available from DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 onwards<!--RN 38775-->. Sets the first item as the value that will be applied in the feed when the dashboard is opened, unless a custom URL is used specifying a different value. This setting is enabled by default.

   - *Initial Selection > Select item by default*: Available from DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 onwards<!--RN 38775-->. Allows you to specify a default value. This is the value that will be applied in the feed when the dashboard is opened, unless a custom URL is used specifying a different value. This setting is only available when the *Select first item by default* setting is disabled.
