---
uid: DashboardDropdownFeed
---

# Drop-down feed

This feed allows the user to select an item in a drop-down list. The selectable items can be based on any data feed.

To configure the component:

1. Apply the necessary data feeds. See [Applying a data feed](xref:Configuring_dashboard_components#applying-a-data-feed).

1. Optionally, fine-tune the component layout. In the *Component* > *Layout* tab, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Configuring_dashboard_components#customizing-the-component-layout).

   - *Label*: Allows you to specify text that should be displayed next to the drop-down box.

1. Optionally, customize the following component options in the *Component* > *Settings* tab:

   - *WebSocket settings*: Allows you to customize the polling interval for this component. To do so, clear the checkbox in this section and specify the custom polling interval.

   - *Initial Selection*: Allows you to specify a default value. This is the value that will be applied in the feed when the dashboard is opened, unless a custom URL is used specifying a different value.

  > [!NOTE]
  > Up to DataMiner 10.3.6.0, this setting is called *Feed Defaults*.
