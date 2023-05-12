---
uid: DashboardState
---

# State

This component displays the state, name and, if applicable, the value of a DataMiner object. This can be an element, a view, a parameter, etc.

> [!NOTE]
> From DataMiner 10.3.6/10.4.0 onwards, if an item in this component is selected, you can clear the selection by clicking it while keeping the Ctrl key pressed. If you are using the State component as a feed for other components, this will also clear the data shown in those components. <!-- RN 36056 -->

To configure the component:

1. Apply a data feed. See [Applying a data feed](xref:Configuring_dashboard_components#applying-a-data-feed).

   - In case a parameter data feed included a parameter based on a protocol, a filter feed can be used to filter on a specific element.

   - Column parameter feeds are supported from DataMiner 10.0.12 onwards.

   - From DataMiner 10.2.0/10.1.4 onwards, you can select view parameters as a data source to view the alarm state for aggregation rules on specific views. To select these, in the drop-down box for the parameter data source, select *View*.

   > [!NOTE]
   > From DataMiner 10.2.0/10.1.6 onwards, once this component has been configured with data input, the component is available in the *feeds* section of the data pane so that it can be used as a feed for other components. This way, if the input for this component changes, it will also change for all other components using this component as their feed. However, note that this is only supported for query data input from DataMiner 10.1.7 onwards.

1. Optionally, customize the following component options:

   - To customize the polling interval for this component, expand the *Settings* \> *WebSocket settings* section, clear the checkbox in this section, and specify the custom polling interval.

   - If the component shows a parameter with a unit, but you do not want the unit to be displayed, in the *Settings* tab, clear the *Show units* option (available from DataMiner 10.1.9/10.2.0 onwards).

   - In case the component displays more than one item, in the *Settings* tab, select how the items should be grouped: by parameter, by element, by table index (if relevant) or by all the above together. Note that view parameters can only be grouped together with other parameters with the option *All together*, otherwise they are placed in a separate group.

   - In case the component displays a query source and you want the data to be refreshed automatically, Set *Update data* to *On* (available from DataMiner 10.2.0/10.2.1 onwards<!-- RN 31450 -->).

   - If you want the first item in the component to be selected by default, in the *Settings* tab, under *Initial Selection*, set the toggle button to *On* (available from DataMiner 10.3.6/10.4.0 onwards<!-- RN 35984 -->). This way, the first item will be automatically selected whenever the component is loaded or when the data is refreshed.

1. Fine-tune the component layout. In the *Component* > *Layout*, tab the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Configuring_dashboard_components#customizing-the-component-layout).

   - In case the component displays more than one item, in the *Advanced* > *Layout* section, you can adjust the way the different items are displayed:

     - *Layout*: Determines whether the different items are displayed next to each other or below each other. However, note that when the items are viewed on a small screen, they will always be displayed below each other.

     - *Maximum rows per page*: Determines how many items can at most be displayed below each other on a single page.

     - *Maximum columns per page*: Determines how many items can at most be displayed next to each other on a single page.

     > [!NOTE]
     > These options are only available for parameters, and only prior to DataMiner 10.0.10. In later DataMiner versions, these are replaced by the *Layout flow* option.

   - In the *Style* section, the following options are available:

     From DataMiner 10.0.9 onwards, if the component uses a parameter feed, or from DataMiner 10.0.10 onwards regardless of the type of feed:

     - *Design*: Allows you to select one of the following options:

       - *Small:* The component displays a single line containing a label and value.

       - *Large*: The component displays multiple lines with one value and up to three labels.

       - *Auto size*: Similar to the *Large* option, but automatically adjusts the content to fill the entire component.

     - *Alarm state coloring*: Allows you to select one of the following options to determine how alarm coloring is displayed:

       - *LED*: The alarm color is displayed by a circular LED to the left of the first label.

       - *Line*: The alarm color is displayed by a bar along the left side of the component.

       - *Text*: The text color of the value matches the alarm color.

       - *Background*: The background of the component displays the alarm color. If this option is selected, an additional option, *Automatically adjust text color to alarm color*, can be selected to make sure the text color is adapted if necessary.

       - *None*: No alarm color is displayed.

     - *Layout flow*: Allows you to select whether the different states should be displayed in rows or columns. If they are displayed in rows, they will be displayed next to each other until there is no more space and a new row is started. If they are displayed as columns, they will be displayed below each other until there is no more space and a new column is started.

     - Alignment: Available from DataMiner 10.1.0/10.1.3 onwards. Only displayed if *Design* is set to *Large* or *Auto Size*. Allows you to align the contents of the components to the left, in the center or to the right.

     Prior to DataMiner 10.0.9, or prior to DataMiner 10.0.10 if the component does not use a parameter feed:

     - *Use available space*: If this option is selected, the text displayed in the component is rescaled when the component is resized, so that it is always displayed as large as possible.

     - *Align font sizes*: Only available if the *Use available space* option is selected, in which case this option is also selected by default. This option causes the font size to be aligned with the font size of other “State” components using this option.

     - *Show progress*: Only available if the component displays an analog parameter. In that case, a darker color within the bar indicating the alarm color of the parameter will indicate the current parameter value.

     - *LED position*: Determines whether the bar indicating the alarm color of the parameter is displayed on the left side of the component or at the bottom.

     - *Show icon*: Determines whether an icon is displayed for the parameter. You can select which icon is displayed in a drop-down list.

        For trended parameters, by default a trend icon is displayed. Clicking this icon will open the corresponding trend graph in the Monitoring app.

   - If a parameter was added as a feed, in the *Labels* section, you can select whether the parameter name, element name or index should be displayed in the component.
