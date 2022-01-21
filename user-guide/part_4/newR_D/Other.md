---
uid: Other
---

## Other

This category contains the following visualizations:

- [Node edge graph](#node-edge-graph)

- [Parameter page](#parameter-page)

- [Service definition](#service-definition)

- [Spectrum analyzer](#spectrum-analyzer)

- [Trend statistics](#trend-statistics)

- [Visual overview](#visual-overview)

### Node edge graph

> [!WARNING]
> This feature is in preview until DataMiner 10.1.5. If you use the preview version of the feature, its functionality may be different from what is described below. For more information, see [Soft-launch options](https://community.dataminer.services/documentation/soft-launch-options/).

This component is available in soft launch from DataMiner 10.0.4 onwards, if the soft-launch option *ReportsAndDashboardsPTP* is enabled. From DataMiner 10.2.0/10.1.5 onwards, it is available without the soft-launch option.

This component allows you to visualize any type of objects (i.e. “nodes”) and the connections between them (i.e. “edges”). By linking parameters and properties to those nodes and edges, you can turn a node edge graph into a full-fledged analytical tool that shows real-time alarm statuses and KPI data

The data necessary to create a node edge graph can be provided by means of GQI queries. Node queries provide data that will be visualized as nodes (i.e. objects), whereas edge queries provide data that will be visualized as edges (i.e. connections between objects). Clicking items in the node edge graph also makes these available as a feed for other components. Keeping the Ctrl key pressed while you click them allows you to select multiple items at the same time.

The component uses dynamic coloring, which can be adjusted according to preference. When you hover the mouse pointer over a node or edge, a tooltip is displayed with detailed info. Click the circle in the top-right corner of the tooltip to switch between different coloring modes for all the nodes or edges of this type:

- *Static*: Edges have no color, nodes have the color from the node settings.

- *Analytical*: If you select this mode, further below in the tooltip you can select any of the columns that have a color filter applied (cf. configuration below) to make this the dominant column. This column is then indicated in bold and determines which color is used in the graph. The value of this column is also displayed under the nodes or edges. If WebSocket communication is enabled, the colors and values will be updated in real time to match parameter value updates.

- *Alarm*: Nodes and edges are colored according to the highest severity of the parameters in the tooltip.

To configure the component:

1. Add the query data feeds that will represent the nodes and edges.

2. In the *Settings* pane, assign the queries as nodes or edges:

    1. In the box representing each query, click either *Set as node* or *Set as edge*.

        - If a query is set as node, it will move to the nodes section. If a query is set as edge, it will move to the edges section.

        - Once a query has been set to be a node or edge, you can still change this setting by clicking the node or edge icon in the top-right corner of the query box.

    2. Configure the nodes as follows:

        1. Next to *Node ID column*, select the column from the query that represents the node ID.

        2. Optionally, expand the *Base node* section to configure the node further. The following options are available:

            - *Node name*: This name is not displayed in the component itself, and is only intended to clarify the configuration.

            - *Weight*: A number indicating the relative importance of the node. The higher the number, the more important the node, which determines where it is displayed in the graph (depending on the layout settings).

            - *Shapes*: Select a different shape in the drop-down box to customize the node shape. By default, no shape is used. You can also select *Custom* in the drop-down box in order to get additional options that allow you to create a fully customized shape instead of one of the available presets. Click the circle to the right of the drop-down box to select a custom color for the shape.

            - *Icon*: Select a different icon in the drop-down box to customize the icon shown within the node shape. Click the circle to the right of the box to select a custom color.

            - *Label*: Select the column to use as the label for the node.

            - *Size*: Select whether the node should be small, medium-sized or large.

        3. If you want to visualize some nodes differently for the same query, under *Override nodes*, click *Add override*, specify a filter, and configure the nodes as detailed above.

    3. Configure the edges as follows:

        1. In the *Source* box, select the column from the query that represents the source of the connection. To the right of the drop-down list, click the icon representing the source node.

        2. In the *Destination* box, select the column from the query that represents the destination of the connection. To the right of the drop-down list, click the icon representing the destination nodes.

        3. Optionally, expand the *bidirectional configuration* section (available from DataMiner 10.1.11/10.2.0 onwards) to configure how multiple edges between two nodes should be mapped.

        4. Optionally, next to *Style*, select a different style for the connection lines.

        5. Optionally, next to *Weight*, specify a number to indicate the relative importance of the edge. This will determine the thickness of the connection line.

3. Optionally, fine-tune the layout of the component with the following settings in the *Layout* tab:

    - *Column filters*: Only available up to DataMiner 10.1.10. Optionally, you can specify color filters for specific columns, so that these can be used for highlighting in case analytical coloring is used. Users can switch to this coloring mode via the tooltip of a node or edge. To configure a color filter:

        - If the column you want to use for highlighting contains values for which a specific range can be specified, select the column, indicate the range to be highlighted, select the range and then click the color icon on the right to specify a highlight color. Multiple ranges can be indicated for one column, each with a color of its own.

        - Alternatively, from DataMiner 10.20/10.1.8 onwards, you can filter on specific text instead. To do so, select the column you want to use for highlighting, specify the text, and select the highlight color. By default, the value will need to be equal to the specified text to be highlighted. However, you can change this by clicking *equal* above the text box and selecting *contain* or *match regex* instead, depending on the type of filtering you want to apply. You can also apply a negative filter by clicking *does*, which will make this field switch to *does not* instead.

        - Multiple filters can be applied on the same value. In that case, the filters will be applied from the top of the list to the bottom. Positive filters will get priority over negative filters.

        - You can remove a column filter again by selecting *No color* instead of a specific color.

    - *Filters & Highlighting*: Available from DataMiner 10.1.11/10.2.0 onwards. Allows you to configure a number of filtering and highlighting options. However, note that the filtering options require the *Query filter* component, which is currently still in [soft launch](https://community.dataminer.services/documentation/soft-launch-options/).

        - *Conditional coloring*: (Replaces the *Column filters* option from prior to 10.1.11.) This option allows you to specify color filters for specific columns, so that these can be used for highlighting in case analytical coloring is used. Users can switch to this coloring mode via the tooltip of a node or edge. To configure a color filter:

            - If the column you want to use for highlighting contains discrete values, click the color icon next to a value and then specify a highlight color for that value. If there are too many values to easily list them, you will first need to specify a filter in order to select a value.

            - If the column you want to use for highlighting contains values for which a specific range can be specified, select the column, indicate the range to be highlighted, select the range and then click the color icon on the right to specify a highlight color. Multiple ranges can be indicated for one column, each with a color of its own.

        - *Highlight*: When this option is enabled, the nodes that match the filter will be highlighted. Default: Enabled

        - *Opacity*: When the *Highlight* option is enabled, this option will allow you to set the level of transparency of the nodes and edges that do not match the filter.

            > [!NOTE]
            > When you disable the *Highlight* option, the nodes that do not match the filter will no longer be displayed and the remaining nodes will be reorganized.

        - *Highlight/Show entire path*: When this option is enabled, not only the nodes matching the filter will be highlighted, but also the entire tree structure they are a part of (from root to leaves).

    - *Node positions*: By default, this is set to *Layered*, which means nodes are displayed in different layers. Set this to *Custom* if you want to allow users with dashboard editing permission to drag and drop the nodes to a custom position. In that case, it is also possible to select a group of nodes by keeping the Ctrl key pressed while clicking them, and then move them together.

    - Direction: Determines how different nodes are displayed depending on their importance, as indicated by their configured weight:

        - *Backwards*: Nodes are displayed from right to left in order of importance.

        - *Downwards*: Nodes are displayed from top to bottom in order of importance.

        - *Forwards*: Nodes are displayed from left to right in order of importance;

        - *Upwards*: Nodes are displayed from bottom to top in order of importance

    - *Zooming*: Select whether users should be able to zoom in on the component or not. When this option is enabled, you can use the scroll wheel of the mouse to zoom in or out. Alternatively, you can right-click and drag across an area of the graph to zoom in on that area. Enabling this option also makes it possible to pan the graph by dragging it while keeping the left mouse button pressed.

    - *Edge style*: Select whether the connections should be displayed as curly or straight lines.

### Parameter page

This component displays a particular data page of an element.

To configure the component:

1. Prior to DataMiner 10.0.9: Add an element data feed.

    From DataMiner 10.0.9 onwards: Add an element data feed or a data page feed (recommended). For a data page feed, filter the *Parameters* item in the data pane either by element or by protocol.

2. If you used an element data feed: Click the filter button in the quick menu below the component and add a data page filter feed from the *Parameters* category.

    If you used a data page feed based on element, no additional filter is needed.     If you used a data page feed based on protocol, an additional element filter feed is needed. You can either directly add this feed from the *Elements* section in the data pane, or use a feed component. See [Applying a data feed](Configuring_dashboard_components.md#applying-a-data-feed).

3. Optionally, to customize the polling interval for this component, expand the *Settings* \> *WebSocket settings* section, clear the checkbox in this section, and specify the custom polling interval.

### Service definition

Available from DataMiner 10.0.5 onwards. This component displays a service definition as a node edge graph. It can display the graph based on a service definition feed or a booking feed. Any nodes that are linked to a particular resource will display alarm and element info in the graph. The alarm state will be displayed with a colored border at the top of the node, and in the node icon in case the default icon is shown. In addition, a link icon in the node will open the corresponding element card in the Monitoring app when clicked.

To configure the component:

1. Add an input for the data:

    - Add a service definition feed, or

    - Add a booking feed, or

    - Add a service feed (supported from DataMiner 10.2.0/10.1.3 onwards), or

    - Add a feed based on a feed component, which can use a bookings feed filtered by a service definition feed.

    > [!NOTE]
    > If you use a service feed, in addition to the service definition, by default, the current booking will be displayed. To display bookings for a different time range, add a time range filter.

2. Optionally, configure one or more actions for nodes of the service definition. An action is a script that is executed when a user clicks a specific icon in the component.

    1. In the *Settings* pane, click the + icon below *Actions* to add an action.

    2. In the *Script* box, specify the script that should be executed by the action.

    3. In the *Icon* box, specify the icon that should be displayed for this action in the component.

    4. If necessary, specify dummies and/or parameters for the script.

        > [!NOTE]
        > The booking ID or service definition ID used in the component and the node ID of the node for which the icon was clicked will automatically be passed to the script as parameter ID 1 and parameter ID 2, respectively.

    5. In the tree view below *Add action to*, select the nodes for which the action should be available.

    6. Repeat from step a for each new action you want to add.

    If you want to reorder the configured actions, hover the mouse pointer over an action, and click the up or down arrow at the top of the action. Similarly, to delete a configured action, hover the mouse pointer over the action and click the red garbage can icon.

3. Optionally, fine-tune the way the component is displayed with the following settings in the *Layout* tab:

    - *Show ID*: Determines whether node IDs are displayed.

    - *Show interfaces*: Determines whether the interfaces of the nodes are displayed.

    - *Show nodes without a resource assigned*: Available from DataMiner 10.0.7 onwards. Determines whether nodes that have no resource assigned are displayed. By default, this option is not selected, so these nodes are not displayed.

    - *Visible nodes*: Available from DataMiner 10.0.7 onwards. Allows you to select which nodes should be displayed. Below this option, a tree view is displayed, showing the nodes in the service definition. Only the selected nodes will be displayed in the component.

    - *Enable zooming*: Determines whether users will be able to zoom in and out on the graph.

    - *Edge style*: Determines whether curly or straight edges are used in the graph.

### Spectrum analyzer

This component can be used to display a spectrum graph. Available from DataMiner 10.0.10 onwards.

To configure the component:

1. Add a spectrum element feed or (from DataMiner 10.0.11 onwards) a spectrum buffer feed. You can also link to a feed component where a user can select the element feed or buffer feed.

2. Optionally, you can also add a spectrum preset as a filter. If no preset filter is specified, the component will display the graph for the most recently closed spectrum session of the current user for the selected spectrum element.

Please note the following regarding this component.

- The displayed trace colors and grid colors depend on the preset and cannot be changed in the dashboard configuration. The same goes for the background color and text color of the spectrum graph, and for the show/hide settings for the grid and for axis labels.

- You can let the dashboard user select the spectrum preset by adding a drop-down feed component as a data source for the spectrum analyzer component. Use the *Spectrum presets* group as a data source for the feed component and then add a protocol filter to configure it.

- To add a spectrum buffer to a feed component, you can either add an individual spectrum buffer, or add the spectrum buffers group and then add a spectrum element filter.

- If a spectrum analyzer component uses a spectrum buffer feed, it is possible to color the threshold lines from the preset based on the state of a spectrum monitor parameter. For this purpose, the spectrum monitor must use a script containing variables that refer to the threshold lines. Each threshold line has a threshold ID, which is an index ranging from 1 to the total number of thresholds in the preset. To refer to the first threshold, the script variable should be *$threshold1*, for the second threshold, it should be *$threshold2*, etc. This format is case-sensitive. When you configure the spectrum monitor parameters, you can then select these variables to create a parameter with alarm monitoring (see [Configuring spectrum monitors](../SpectrumAnalysis/Working_with_spectrum_monitors.md#configuring-spectrum-monitors)).

- To allow users to visualize and switch between measurement points for a spectrum session (supported from DataMiner 10.0.11 onwards):

    1. Ad a spectrum analyzer component and use a spectrum analyzer element as its data input.

    2. Optionally, add a spectrum preset filter.

    3. Add a list feed to the dashboard (see [List](Feeds.md#list)) and add the spectrum session feed from your spectrum analyzer as its input.

    The dashboard will then show a list of all the available measurement points, with a colored LED. This LED will be a filled circle for the active measurement point and an empty circle for other measurement points. If measurement points are selected in the list, this will update the spectrum session, so that the spectrum analyzer visualization shows those measurement points.

- In DataMiner 10.0.10 only, it was possible to configure a trigger action on a spectrum analyzer component, so that clicking the component opened another dashboard. However, this feature is no longer available from DataMiner 10.0.11 onwards.

### Trend statistics

This component displays the minimum, average and maximum value of one or more trended parameters. Available from DataMiner 9.6.13 onwards;

To configure the component:

1. Add a (multiple) parameter data feed.

    > [!NOTE]
    > Column parameters from tables that use advanced naming are supported from DataMiner 10.0.9 onwards.

2. In case a table parameter has been added, optionally add an index filter.

3. Optionally, customize the following component options in the *Component* > *Settings* tab:

    - *WebSocket settings*: Allows you to customize the polling interval for this component. To do so, clear the checkbox in this section and specify the custom polling interval.

    - *Trend span*: Allows you to customize the time span for which trend statistics are displayed. You can either select a predefined time span or select *Custom* and specify a start and end time.

    - *Group by*: In case the component displays trend statistics for multiple parameters, this box allows you to specify how the statistics should be grouped.

4. Optionally, fine-tune the component layout. In the *Component* > *Layout* tab, the following options are available:

    - The default options available for all components. See [Customizing the component layout](Configuring_dashboard_components.md#customizing-the-component-layout).

    - *Layout*: In case trend statistics are displayed for multiple parameters, this setting determines whether the blocks of statistics are displayed next to each other or below each other. However, note that when the dashboard is used on a small screen, they will always be displayed below each other.

    - *Maximum rows per page*: Determines the maximum number of parameters for which statistics can be displayed below each other on a single page.

    - *Maximum columns per page*: Determines the maximum number of parameters for which statistics can be displayed next to each other on a single page.

### Visual overview

This component displays a Visio file linked to an element.

To configure this component:

1. In the *Data* tab, select the element for which the visual overview should be displayed and drag it to the component.

2. Optionally, customize the following component options in the *Settings* tab:

    - *WebSocket settings*: Allows you to customize the polling interval for this component. To do so, clear the checkbox in this section and specify the custom polling interval.

    - *Page selection*: In case the Visio drawing consists of several pages, select this checkbox to display a page selection drop-down list at the top of the component.

    - *Default page*: In case the Visio drawing consists of several pages, select the page that should be displayed by default in this drop-down list. Keep in mind that if *Page selection* is not selected, this is the only page the user of the dashboard will be able to see.

3. Optionally, fine-tune the component layout. See [Customizing the component layout](Configuring_dashboard_components.md#customizing-the-component-layout).

> [!NOTE]
> - Spectrum components are currently not yet supported in visual overviews within dashboards.
> - Quick filters are supported for table parameters in visual overview components from DataMiner 10.0.12 onwards. See [Using quick filters](../../part_1/GettingStarted/Using_quick_filters.md).
>
