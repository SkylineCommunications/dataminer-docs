## States and values

This category contains the following visualizations:

- [State](#state)

- [Progress bar](#progress-bar)

- [Gauge](#gauge)

- [Ring](#ring)

- [State timeline](#state-timeline)

### State

This component displays the state, name and, if applicable, the value of a DataMiner object. This can be an element, a view, a parameter, etc.

To configure the component:

1. Apply a data feed. See [Applying a data feed](Configuring_dashboard_components.md#applying-a-data-feed).

    In case a parameter data feed included a parameter based on a protocol, a filter feed can be used to filter on a specific element. Note that column parameter feeds are supported from DataMiner 10.0.12 onwards.

    > [!NOTE]
    > From DataMiner 10.2.0/10.1.6 onwards, once this component has been configured with data input, the component is available in the *feeds* section of the data pane so that it can be used as a feed for other components. This way, if the input for this component changes, it will also change for all other components using this component as their feed. However, note that this is only supported for query data input from DataMiner 10.1.7 onwards.

2. Optionally, customize the following component options:

    - To customize the polling interval for this component, expand the *Settings *\> *WebSocket settings* section, clear the checkbox in this section, and specify the custom polling interval.

    - If the component shows a parameter with a unit, but you do not want the unit to be displayed, in the *Settings* tab, clear the *Show units* option (available from DataMiner 10.1.9/10.2.0 onwards).

    - In case the component displays more than one item, in the *Settings* tab, select how the items should be grouped: by parameter, by element, by table index (if relevant) or by all of the above together.

3. Fine-tune the component layout. In the *Component* > *Layout*, tab the following options are available:

    - The default options available for all components. See [Customizing the component layout](Configuring_dashboard_components.md#customizing-the-component-layout).

    - In case the component displays more than one item, in the *Advanced* > *Layout* section, you can adjust the way the different items are displayed:

        - *Layout*: Determines whether the different items are displayed next to each other or below each other. However, note that when the dashboard is used on a small screen, they will always be displayed below each other.

        - *Maximum rows per page*: Determines how many items can at most be displayed below each other on a single page.

        - *Maximum columns per page*: Determines how many items can at most be displayed next to each other on a single page.

        > [!NOTE]
        > These options are only available for parameters, and only prior to DataMiner 10.0.10. In later DataMiner versions, these are replaced by the *Layout flow* option.

    - In the *Style *section, the following options are available:

        From DataMiner 10.0.9 onwards, if the component uses a parameter feed, or from DataMiner 10.0.10 onwards regardless of the type of feed:

        - *Design*: Allows you to select one of the following options:

            - *Small:* The component displays a single line containing a label and value.

            - *Large*: The component displays multiple lines with one value and up to three labels.

            - *Auto size*: Similar to the *Large* option, but automatically adjusts the content to fill the entire component.

        - *Alarm state coloring*: Allows you to select one of the following options to determine how alarm coloring is displayed:

            - *LED*: The alarm color is displayed by a circular LED to the left of the first label.

            - *Line*: The alarm color is displayed by a bar along the left side of the component.

            - *Text*: The text color of the value matches the alarm color.

            - *Background*: The background of the component displays the alarm color. If this option is selected, an additional option, *Automatically adjust text color to alarm color*, can be selected to make sure the text color is adapted if necessary.

            - *None*: No alarm color is displayed.

        - *Layout flow*: Allows you to select whether the different states should be displayed in rows or columns. If they are displayed in rows, they will be displayed next to each other until there is no more space and a new row is started. If they are displayed as columns, they will be displayed below each other until there is no more space and a new column is started.

        - Alignment: Available from DataMiner 10.1.0/10.1.3 onwards. Only displayed if *Design* is set to *Large* or *Auto Size*. Allows you to align the contents of the components to the left, in the center or to the right.

        Prior to DataMiner 10.0.9, or prior to DataMiner 10.0.10 if the component does not use a parameter feed:

        - *Use available space*: If this option is selected, the text displayed in the component is rescaled when the component is resized, so that it is always displayed as large as possible.

        - *Align font sizes*: Only available if the *Use available space* option is selected, in which case this option is also selected by default. This option causes the font size to be aligned with the font size of other “State” components using this option.

        - *Show progress*: Only available if the component displays an analog parameter. In that case, a darker color within the bar indicating the alarm color of the parameter will indicate the current parameter value.

        - *LED position*: Determines whether the bar indicating the alarm color of the parameter is displayed on the left side of the component or at the bottom.

        - *Show icon*: Determines whether an icon is displayed for the parameter. You can select which icon is displayed in a drop-down list.

            For trended parameters, by default a trend icon is displayed. Clicking this icon will open the corresponding trend graph in the Monitoring app.

    - If a parameter was added as a feed, in the *Labels* section, you can select whether the parameter name, element name or index should be displayed in the component.

### Progress bar

This component shows the value of one or more analog parameters with a progress bar. It is available from DataMiner 10.2.0/10.1.7 onwards.

To configure the component:

1. Apply a parameter data feed. See [Applying a data feed](Configuring_dashboard_components.md#applying-a-data-feed).

2. Optionally, customize the following component options:

    - To customize the polling interval for this component, expand the *Settings *\> *WebSocket settings* section, clear the checkbox in this section, and specify the custom polling interval.

    - In case the component displays more than one item, in the *Settings* tab, select how the items should be grouped: by parameter, by element, by table index (if relevant) or by all of the above together.

    - To customize the value range of the component, in the *Settings* tab, select *Fixed minimum* and/or *Fixed maximum* and specify the custom minimum and/or maximum.

3. Fine-tune the component layout. In the *Component* > *Layout*, tab the following options are available:

    - The default options available for all components. See [Customizing the component layout](Configuring_dashboard_components.md#customizing-the-component-layout).

    - *Labels*: In this section, you can select whether the parameter name, the element name, the index (for a table parameter) and/or the value should be displayed in the component.

    - *Show minimum*: Select this option to show the minimum value of the value range. Note that this value can be customized in the component settings.

    - *Show maximum*: Select this option to show the maximum value of the value range. Note that this value can be customized in the component settings.

    - *Design*: Determines whether the text is displayed in a small or large font size.

    - *Layout flow*: If the component displays multiple parameters, this option determines whether the different parameters are displayed in rows or columns. If they are displayed in rows, they will be displayed next to each other until there is no more space and a new row is started. If they are displayed as columns, they will be displayed below each other until there is no more space and a new column is started.

### Gauge

This component displays a numeric parameter value as a gauge.

To configure the component:

1. Apply a data feed. See [Applying a data feed](Configuring_dashboard_components.md#applying-a-data-feed).

    In case a parameter data feed included a parameter based on a protocol, a filter feed can be used to filter on a specific element.

    > [!NOTE]
    > From DataMiner 10.2.0/10.1.6 onwards, once this component has been configured with data input, the component is available in the *feeds* section of the data pane so that it can be used as a feed for other components. This way, if the input for this component changes, it will also change for all other components using this component as their feed. However, note that this is only supported for query data input from DataMiner 10.1.7 onwards.

2. Optionally, customize the following component options:

    - To customize the polling interval for this component, expand the *Settings *\> *WebSocket settings* section, clear the checkbox in this section, and specify the custom polling interval.

    - In case the component displays more than one item, in the *Settings* tab, select how the items should be grouped: by parameter, by element, by table index (if relevant) or by all of the above together.

    - To customize the value range of the component, in the *Settings* tab, select *Fixed minimum* and/or *Fixed maximum* and specify the custom minimum and/or maximum. This option is available from DataMiner 10.2.0/10.1.6 onwards.

3. Fine-tune the component layout. In the *Component* > *Layout*, tab the following options are available:

    - The default options available for all components. See [Customizing the component layout](Configuring_dashboard_components.md#customizing-the-component-layout).

    - If parameter data input is used, in the *Labels* section, you can select whether the parameter name, the element name, the index (for a table parameter) or the value should be displayed in the component.

    - In case the component displays more than one parameter, in the *Advanced* > *Layout* section, you can adjust the way the different items are displayed:

        - *Layout flow*: Determines whether the different items are displayed next to each other or below each other. However, note that when the dashboard is used on a small screen, they will always be displayed below each other.

        - *Maximum rows per page*: Determines how many items can at most be displayed below each other on a single page.

        - *Maximum columns per page*: Determines how many items can at most be displayed next to each other on a single page.

        > [!NOTE]
        > Prior to DataMiner 10.0.10, the component does not support feeds with multiple elements, services, views or redundancy groups. From that DataMiner version onwards, these are supported, but they have a fixed scroll configuration that cannot be adjusted in the *Layout* tab.

    - In the *Style *section, the following options are available:

        - *Align font sizes*: Only available if *Design* is set to *Auto Size*. This option causes the font size to be aligned with the font size of other components using this option. If the option is not selected, the text is simply displayed as large as possible within the component.

        - *Show progress*: Available from DataMiner 10.2.0/10.1.6 onwards. Only available if the component displays an analog parameter. In that case, a darker color within the gauge will indicate the current parameter value.

        - *Show minimum*: Available from DataMiner 10.2.0/10.1.6 onwards. Select this option to show the minimum value of the value range below the gauge. Note that this value can be customized in the component settings.

        - *Show maximum*: Available from DataMiner 10.2.0/10.1.6 onwards. Select this option to show the maximum value of the value range below the gauge. Note that this value can be customized in the component settings.

        - *Show icon*: Determines whether an icon is displayed for the parameter. You can select which icon is displayed in a drop-down list.

            For trended parameters, by default a trend icon is displayed. Clicking this icon will open the corresponding trend graph in the Monitoring app.

        - *Design*: Available from DataMiner 10.2.0/10.1.6 onwards. Determines how the text in the component is displayed. The options *Small* and *Large* show the text in a small and large font size, respectively. If you select *Auto size*, the font size will automatically be adjusted to fit in the available space.

        - *Gauge/Vertical alignment*: Only available up to DataMiner 10.1.5. Determines whether the gauge should be aligned at the top or the center of the component.

        - Alignment: Available from DataMiner 10.2.0/10.1.6 onwards. Only displayed if *Design* is set to *Small *or *Large*. Allows you to align the contents of the components to the left, in the center or to the right.

### Ring

This component displays the name and, if applicable, the value of a DataMiner object within a colored ring matching the state of the object. This can be an element, a view, a parameter, etc.

To configure the component:

1. Apply a data feed. See [Applying a data feed](Configuring_dashboard_components.md#applying-a-data-feed).

    In case a parameter data feed included a parameter based on a protocol, a filter feed can be used to filter on a specific element.

    > [!NOTE]
    > From DataMiner 10.2.0/10.1.6 onwards, once this component has been configured with data input, the component is available in the *feeds* section of the data pane so that it can be used as a feed for other components. This way, if the input for this component changes, it will also change for all other components using this component as their feed. However, note that this is only supported for query data input from DataMiner 10.1.7 onwards.

2. Optionally, customize the following component options:

    - To customize the polling interval for this component, expand the *Settings *\> *WebSocket settings* section, clear the checkbox in this section, and specify the custom polling interval.

    - In case the component displays more than one item, in the *Settings* tab, select how the items should be grouped: by parameter, by element, by table index (if relevant) or by all of the above together.

    - To customize the value range of the component, in the *Settings* tab, select *Fixed minimum* and/or *Fixed maximum* and specify the custom minimum and/or maximum. This option is available from DataMiner 10.2.0/10.1.6 onwards.

3. Fine-tune the component layout. In the *Component* > *Layout*, tab the following options are available:

    - The default options available for all components. See [Customizing the component layout](Configuring_dashboard_components.md#customizing-the-component-layout).

    - If parameter data input is used, in the *Labels* section, you can select whether the parameter name, the element name, the index (for a table parameter) or the value should be displayed in the component.

    - In case the component displays more than one parameter, in the *Advanced* > *Layout* section, you can adjust the way the different items are displayed:

        - *Layout flow*: Determines whether the different items are displayed next to each other or below each other. However, note that when the dashboard is used on a small screen, they will always be displayed below each other.

        - *Maximum rows per page*: Determines how many items can at most be displayed below each other on a single page.

        - *Maximum columns per page*: Determines how many items can at most be displayed next to each other on a single page.

        > [!NOTE]
        > Prior to DataMiner 10.0.10, the component does not support feeds with multiple elements, services, views or redundancy groups. From that DataMiner version onwards, these are supported, but they have a fixed scroll configuration that cannot be adjusted in the *Layout* tab.

    - The *Style *section, the following options are available:

        - *Align font sizes*: Only available if *Design* is set to *Auto Size*. This option causes the font size to be aligned with the font size of other components using this option. If the option is not selected, the text is simply displayed as large as possible within the component.

        - *Show progress*: Only available if the component displays an analog parameter. In that case, a darker color within the ring will indicate the current parameter value.

        - *Show minimum*: Available from DataMiner 10.2.0/10.1.6 onwards. Select this option to show the minimum value of the value range below the ring. Note that this value can be customized in the component settings.

        - *Show maximum*: Available from DataMiner 10.2.0/10.1.6 onwards.Select this option to show the maximum value of the value range below the ring. Note that this value can be customized in the component settings.

        - *Show icon*: Determines whether an icon is displayed for the parameter. You can select which icon is displayed in a drop-down list.

            For trended parameters, by default a trend icon is displayed. Clicking this icon will open the corresponding trend graph in the Monitoring app.

        - *Design*: Available from DataMiner 10.2.0/10.1.6 onwards. Determines how the text in the component is displayed. The options *Small* and *Large* show the text in a small and large font size, respectively. If you select *Auto size*, the font size will automatically be adjusted to fit in the available space.

        - Alignment: Available from DataMiner 10.2.0/10.1.6 onwards. Only displayed if *Design* is set to *Small *or *Large*. Allows you to align the contents of the components to the left, in the center or to the right.

### State timeline

This component visualizes the alarm state changes over time of a parameter, element or service. By default, it shows a timeline for the last 24 hours, but a time range feed can be added to set the component to a different time range. Available from DataMiner 10.1.0/10.0.10 onwards.

To configure the component:

1. Apply an element, service, or protocol/element parameter data feed.

2. Add a filter if necessary:

    - If the component uses a protocol parameter data feed, add an element filter feed.

    - If the component uses a table or column parameter data feed, add an index filter feed.

3. Optionally, add a *Time range* component to the dashboard and configure the state timeline component to use it as a filter feed.
