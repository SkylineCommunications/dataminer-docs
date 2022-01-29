---
uid: Feeds
---

# Feeds

Feeds can be added to a dashboard to allow a user to select a DataMiner object for which information can be displayed in other components.

The following types of feeds are available:

- [CPE feed](#cpe-feed)

- [Drop-down](#drop-down)

- [List](#list)

- [Parameter feed](#parameter-feed)

- [Time range](#time-range)

- [Tree](#tree)

- [Trigger](#trigger)

> [!NOTE]
> Feeds can be preconfigured in dashboard URLs. See [Specifying data input in a dashboard URL](xref:Specifying_data_input_in_a_dashboard_URL).

> [!TIP]
> See also:
> [Using dashboard feeds](xref:Using_dashboard_feeds)

## CPE feed

This feed allows the user to make a filter selection for a particular EPM element (formerly known as CPE Manager) and EPM chain. It can be used as a filter feed for the parameter feed, so that this feed can in turn be used to display info on EPM parameters.

To configure the component:

- From DataMiner 10.0.5 onwards:

    1. Add an element data feed. This can also be a feed from another feed component.

    2. In the *Settings* tab of the component, select the chain that should be filtered by the component and the chain filters that should be available.

    3. Optionally, fine-tune the component layout. In the *Component* > *Layout* tab, the following options are available:

        - The default options available for all components. See [Customizing the component layout](xref:Configuring_dashboard_components#customizing-the-component-layout).

        - *Show label*: Determines whether the names of the chain filters are displayed next to the selection boxes in the component.

- Prior to DataMiner 10.0.5:

    1. When the component is selected, go to the *Settings* tab in the pane on the right.

    2. In the *Element* box, select the EPM element.

    3. In the *CPE Chain* box, select the chain that should be filtered by the component

    4. Select the chain filters that should be available in the component.

    5. Optionally, fine-tune the component layout. In the *Component* > *Layout* tab, the following options are available:

        - The default options available for all components. See [Customizing the component layout](xref:Configuring_dashboard_components#customizing-the-component-layout).

        - *Show label*: Determines whether the names of the chain filters are displayed next to the selection boxes in the component.

## Drop-down

This feed allows the user to select an item in a drop-down list. The selectable items can be based on any data feed.

To configure the component:

1. Apply the necessary data feeds. See [Applying a data feed](xref:Configuring_dashboard_components#applying-a-data-feed).

2. Optionally, fine-tune the component layout. In the *Component* > *Layout* tab, the following options are available:

    - The default options available for all components. See [Customizing the component layout](xref:Configuring_dashboard_components#customizing-the-component-layout).

    - *Label*: Allows you to specify text that should be displayed next to the drop-down box.

3. Optionally, customize the following component options in the *Component* > *Settings* tab:

    - *WebSocket settings*: Allows you to customize the polling interval for this component. To do so, clear the checkbox in this section and specify the custom polling interval.

    - *Feed defaults*: Allows you to specify a default value. This is the value that will be applied in the feed when the dashboard is opened, unless a custom URL is used specifying a different value.

## List

This feed allows the user to select one or more items in a list. The selectable items can be based on any data feed.

To configure the component:

1. Apply the necessary data feeds. See [Applying a data feed](xref:Configuring_dashboard_components#applying-a-data-feed).

2. Optionally, fine-tune the component layout. See [Customizing the component layout](xref:Configuring_dashboard_components#customizing-the-component-layout).

3. Optionally, customize the following component options in the *Component* > *Settings* tab:

    - *WebSocket settings*: Allows you to customize the polling interval for this component. To do so, clear the checkbox in this section and specify the custom polling interval.

    - *Feed defaults*: Allows you to specify a default value. This is the value that will be applied in the feed when the dashboard is opened, unless a custom URL is used specifying a different value.

## Parameter feed

This feed allows the user to select multiple parameters from a predefined list. At the top of the list, a box is available that allows the user to select or deselect all items in the list at once. A *Selected only* toggle button is also available, which can be used to show or hide items that are not selected.

To configure this component:

1. Apply the necessary data feeds. See [Applying a data feed](xref:Configuring_dashboard_components#applying-a-data-feed).

    The component supports element and parameter data feeds. In case a table parameter is added, an indices filter can be specified. In case all parameters or all elements are added, a protocol or view feed can be used as an additional filter.     From DataMiner 10.0.0/10.0.2 onwards, multiple view filters can be applied to a parameter feed. Parameters in those views will then be included as soon as they are included in one of the view filters.

2. Optionally, customize the following component options in the *Component* > *Settings* tab:

    - *WebSocket settings*: Allows you to customize the polling interval for this component. To do so, clear the checkbox in this section and specify the custom polling interval.

    - *Feed defaults*: Allows you to specify a default value. This is the value that will be applied in the feed when the dashboard is opened, unless a custom URL is used specifying a different value.

    - *Auto-select number of indices*: Available up to DataMiner 10.0.12. To automatically include a specific number of indices when at least one element and one parameter have been selected in the component, specify the number in this box. If the number of indices specified is greater than the number of indices that are being displayed, the indices that are not shown will be selected in memory.

    - *Auto-select all indices*: Available up to DataMiner 10.0.12. Select this option to automatically include all indices when at least one element and one parameter have been selected in the component.

    - *Auto-select all*: Available from DataMiner 10.0.13 onwards. Replaced the previous auto-select options. When this option is selected, all items will be selected according to the “Select all behavior” settings below.

    - *Select all behavior* > *Select all items*: Available from 10.0.13 onwards. If this option is selected, "Select all" will select all items. For a partial table, only the items from the first page will be selected.

    - *Select all behavior* > *Select specific number of items*: Available from 10.0.13 onwards. If you select this option, a box is displayed below it. In this box, you should specify how many items “Select all” should select. For a partial table, these items will be selected across different pages.

    - *Auto-expand parameters*: Select this option to expand all tables and groups in the component by default.

    - To customize the default way the content of components based on the selector is grouped, in the *Default grouping* drop-down list, select if grouping should be done by element, parameter, parameter group, etc.

    - If a filtered list of indices is retrieved, you can specify the separator to use for this. For this you must make sure advanced dashboard settings are displayed. To do so, add the parameter *showAdvancedSettings=true* to the URL. You can then specify the separator in the *Index filter separator* box (available from DataMiner 10.0.9 onwards). For example, if only the indices with a primary key equal to "X" have to be retrieved and you set the index filter separator to “Y”, the indices will be retrieved using the filter PK == X OR PK == \*YXY\*.

    - To group parameters in the selector, under *Parameter groups*, click *Add parameter* group. Then specify a group name and select the parameters that should be in the group. Repeat this for every parameter group you want to configure.

3. Optionally, fine-tune the component layout. In the *Component* > *Layout* tab, the following options are available:

    - The default options available for all components. See [Customizing the component layout](xref:Configuring_dashboard_components#customizing-the-component-layout).

    - *Column order*: Click the up or down arrow next to a column name to change the order in which the columns of the component are displayed. Available from DataMiner 9.6.13 onwards.

## Time range

This feed allows the user to specify a time range.

To configure the component:

1. Optionally, customize the following component options in the *Component* > *Settings* tab:

    - *Default range*: The default range selected in the component. By default set to *Today so far*.

    - *Allow refresh*: Determines whether the component includes a refresh timer. By default disabled.

    - *Refresh rate*: If *Allow refresh* is selected, this setting determines after how many seconds the data is refreshed. By default set to 10 seconds.

2. Optionally, fine-tune the component layout. In the *Component* > *Layout* tab, the following options are available:

    - The default options available for all components. See [Customizing the component layout](xref:Configuring_dashboard_components#customizing-the-component-layout).

    - *Show refresh timer*: Determines whether an indication is displayed that the data will be refreshed.

    - *Use quick picks*: Available from DataMiner 10.0.2 onwards. Determines whether the component includes quick pick buttons that allow users to enter a preset time range by clicking a single button.

    - *Pinning as quick pick*: Available from DataMiner 10.0.12 onwards, if *Use quick picks* is enabled. Displays a pin icon next to the time summary in the component, which can be used to add the current time selection as a custom quick pick button. If the current time selection matches the custom quick pick button, clicking the pin icon again will remove the button. You can also remove the button using the garbage can icon on the button itself.

## Tree

This feed allows the user to select one or more items in a tree view. The selectable items can be based on any data feed.

To configure the component:

1. Apply the necessary data feeds. See [Applying a data feed](xref:Configuring_dashboard_components#applying-a-data-feed).

2. Optionally, fine-tune the component layout. See [Customizing the component layout](xref:Configuring_dashboard_components#customizing-the-component-layout).

3. Optionally, customize the following component options in the *Component* > *Settings* tab:

    - *WebSocket settings*: Allows you to customize the polling interval for this component. To do so, clear the checkbox in this section and specify the custom polling interval.

    - *Feed defaults*: Allows you to specify a default value. This is the value that will be applied in the feed when the dashboard is opened, unless a custom URL is used specifying a different value.

## Trigger

Available from DataMiner 10.2.0/10.1.1 onwards. This feed allows you to trigger other components either manually or automatically.

At present, this feed can only be used as a filter feed for a component using a query feed. It will function as a refresh trigger for that component.

To configure the trigger feed:

1. Optionally, customize the following component options in the *Component* > *Settings* tab:

    - *Trigger timer*: Determines whether a countdown bar will be displayed to the next time the trigger goes off.

    - *Time*: If *Trigger Timer* is selected, this setting determines after how many seconds the data is refreshed. By default, this is set to 60 seconds.

2. Optionally, fine-tune the component layout. In the *Component* > *Layout* tab, the following options are available:

    - The default options available for all components. See [Customizing the component layout](xref:Configuring_dashboard_components#customizing-the-component-layout).

    - *Label*: Allows you to specify text that should be displayed on the trigger button.

    - *Icon*: Allows you to select which icon will be displayed on the trigger button.

    - *Show when the last trigger happened*: Select this option to have the component display when the trigger last went off.

    - *Time description format*: If *Show when the last trigger happened* is selected, in this box you can customize the format in which the time when the trigger last went off is displayed. The following placeholders are supported in this format:

        | Placeholder | Description                                                                        |
        |---------------|------------------------------------------------------------------------------------|
        | {duration}    | The approximate time since the trigger last went off.<br> Example: “2 minutes ago” |
        | {time}        | The exact time when the trigger last went off.<br> Example: “Nov 20, 2020, 12:33”  |

    - *Align*: Determines whether the label and icon are displayed on the left side, in the middle or on the right side of the component.
