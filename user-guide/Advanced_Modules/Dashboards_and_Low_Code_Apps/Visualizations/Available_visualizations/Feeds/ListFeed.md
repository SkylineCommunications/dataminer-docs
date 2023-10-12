---
uid: DashboardListFeed
---

# List feed

This dashboard feed allows the user to select one or more items in a list. The selectable items can be based on any data feed.

To configure the component:

1. Apply the necessary data feeds. See [Applying a data feed](xref:Configuring_dashboard_components#applying-a-data-feed).

1. Optionally, fine-tune the component layout. See [Customizing the component layout](xref:Configuring_dashboard_components#customizing-the-component-layout).

1. Optionally, customize the following component options in the *Component* > *Settings* tab:

   - *WebSocket settings*: Allows you to customize the polling interval for this component. To do so, clear the checkbox in this section and specify the custom polling interval.

   - *Initial Selection*: Allows you to specify a default value. This is the value that will be applied in the feed when the dashboard is opened, unless a custom URL is used specifying a different value.

     > [!NOTE]
     > Prior to DataMiner 10.3.6/10.4.0<!--  RN 35984 -->, this setting is called *Feed Defaults* instead.
