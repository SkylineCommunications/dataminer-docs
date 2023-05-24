---
uid: DashboardNodeEdgeGraph
---

# Node edge graph

> [!WARNING]
> This feature is in preview until DataMiner 10.1.5. If you use the preview version of the feature, its functionality may be different from what is described below. For more information, see [Soft-launch options](xref:SoftLaunchOptions).

Available from DataMiner 10.2.0/10.1.5 onwards. Prior to this, the component is available in soft launch from DataMiner 10.0.4 onwards, if the soft-launch option *ReportsAndDashboardsPTP* is enabled.

This component allows you to visualize any type of objects (i.e. “nodes”) and the connections between them (i.e. “edges”). By linking parameters and properties to those nodes and edges, you can turn a node edge graph into a full-fledged analytical tool that shows real-time alarm statuses and KPI data

The data necessary to create a node edge graph can be provided by means of GQI queries. Node queries provide data that will be visualized as nodes (i.e. objects), whereas edge queries provide data that will be visualized as edges (i.e. connections between objects). Clicking items in the node edge graph also makes these available as a feed for other components. Keeping the Ctrl key pressed while you click them allows you to select multiple items at the same time.

The component uses dynamic coloring, which can be adjusted according to preference. When you hover the mouse pointer over a node or edge, a tooltip is displayed with detailed info. Click the circle in the top-right corner of the tooltip to switch between different coloring modes for all the nodes or edges of this type:

- *Static*: Edges have no color, nodes have the color from the node settings.

- *Analytical*: If you select this mode, further below in the tooltip you can select any of the columns that have a color filter applied (cf. configuration below) to make this the dominant column. This column is then indicated in bold and determines which color is used in the graph. The value of this column is also displayed under the nodes or edges. If WebSocket communication is enabled, the colors and values will be updated in real time to match parameter value updates.

- *Alarm*: Nodes and edges are colored according to the highest severity of the parameters in the tooltip.

## Basic component configuration

1. Add the query data feeds that will represent the nodes and edges.

1. In the *Settings* pane, assign the queries as nodes or edges:

   1. In the box representing each query, click either *Set as node* or *Set as edge*.

      - If a query is set as node, it will move to the nodes section. If a query is set as edge, it will move to the edges section.

      - Once a query has been set to be a node or edge, you can still change this setting by clicking the node or edge icon in the top-right corner of the query box.

   1. Configure the nodes as follows:

      1. Next to *Node ID column*, select the column from the query that represents the node ID.

      1. Optionally, expand the *Base node* section to configure the node further. The following options are available:

         - *Node name*: This name is not displayed in the component itself, and is only intended to clarify the configuration.

         - *Weight*: A number indicating the relative importance of the node. The higher the number, the more important the node, which determines where it is displayed in the graph (depending on the layout settings).

         - *Shapes*: Select a different shape in the drop-down box to customize the node shape. By default, no shape is used. You can also select *Custom* in the drop-down box in order to get additional options that allow you to create a fully customized shape instead of one of the available presets. Click the circle to the right of the drop-down box to select a custom color for the shape.

         - *Icon*: Select a different icon in the drop-down box to customize the icon shown within the node shape. Click the circle to the right of the box to select a custom color.

         - *Label*: Select the column to use as the label for the node.

         - *Size*: Select whether the node should be small, medium-sized or large.

      1. If you want to visualize some nodes differently for the same query, under *Override nodes*, click *Add override*, specify a filter, and configure the nodes as detailed above.

   1. Configure the edges as follows:

      1. In the *Source* box, select the column from the query that represents the source of the connection. To the right of the drop-down list, click the icon representing the source node.

      1. In the *Destination* box, select the column from the query that represents the destination of the connection. To the right of the drop-down list, click the icon representing the destination nodes.

      1. Optionally, expand the *bidirectional configuration* section (available from DataMiner 10.1.11/10.2.0 onwards) to configure how multiple edges between two nodes should be mapped.

      1. Optionally, next to *Style*, select a different style for the connection lines.

      1. Optionally, next to *Weight*, specify a number to indicate the relative importance of the edge. This will determine the thickness of the connection line.

1. From DataMiner 10.2.4/10.3.0 onwards, optionally, you can make the edges show a direction. To do so, in the *Settings* tab, activate the *Visualize directions* toggle button, and select how the direction should be shown:

   - *Flow*: The direction is visualized by means of animated edges. This is the default option.

   - *Arrows*: The direction is visualized by means of arrows drawn on the edges. If you select this option, you can also specify the exact position of the arrows on the edges.

## Component actions configuration

If you add a node edge graph to a custom app using the [DataMiner Low-Code Apps](xref:Application_framework), you can also configure actions for the component. This feature is not available in the Dashboards app.

To configure actions:

1. In the *Component* \> *Settings* pane, under the nodes or edges you want to configure actions for, expand the *Actions* section.

1. Click *Add action*.

1. To specify how the action is triggered, at the top of the action configuration section, click the icon for click, double-click, or button in tooltip.

1. In the *Label* box, specify a label for the action.

1. In the *Icon* box, select an icon for the action.

1. In the *Action* box, select the action that should be executed. See [Configuring low-code app events](xref:LowCodeApps_event_config).

> [!NOTE]
> You can also override the default action for a node or edge using the *Add override* option.

## Layout configuration

You can fine-tune the layout of the component with the following settings in the *Layout* tab:

- *Column filters*: Only available up to DataMiner 10.1.10. Optionally, you can specify color filters for specific columns, so that these can be used for highlighting in case analytical coloring is used. Users can switch to this coloring mode via the tooltip of a node or edge. To configure a color filter:

  - If the column you want to use for highlighting contains values for which a specific range can be specified, select the column, indicate the range to be highlighted, select the range and then click the color icon on the right to specify a highlight color. Multiple ranges can be indicated for one column, each with a color of its own.

  - Alternatively, from DataMiner 10.20/10.1.8 onwards, you can filter on specific text instead. To do so, select the column you want to use for highlighting, specify the text, and select the highlight color. By default, the value will need to be equal to the specified text to be highlighted. However, you can change this by clicking *equal* above the text box and selecting *contain* or *match regex* instead, depending on the type of filtering you want to apply. You can also apply a negative filter by clicking *does*, which will make this field switch to *does not* instead.

  - Multiple filters can be applied on the same value. In that case, the filters will be applied from the top of the list to the bottom. Positive filters will get priority over negative filters.

  - You can remove a column filter again by selecting *No color* instead of a specific color.

- *Filters & Highlighting*: Available from DataMiner 10.1.11/10.2.0 onwards. Allows you to configure a number of filtering and highlighting options. However, note that the filtering options require the *Query filter* component, which is currently still in [soft launch](xref:SoftLaunchOptions).

  - *Conditional coloring*: (Replaces the *Column filters* option from prior to 10.1.11.) This option allows you to specify color filters for specific columns, so that these can be used for highlighting in case analytical coloring is used. Users can switch to this coloring mode via the tooltip of a node or edge. To configure a color filter:

    - If the column you want to use for highlighting contains discrete values, click the color icon next to a value and then specify a highlight color for that value. If there are too many values to easily list them, you will first need to specify a filter in order to select a value.

    - If the column you want to use for highlighting contains values for which a specific range can be specified, select the column, indicate the range to be highlighted, select the range and then click the color icon on the right to specify a highlight color. Multiple ranges can be indicated for one column, each with a color of its own.

  - *Highlight*: When this option is enabled, the nodes that match the filter will be highlighted. Default: Enabled

  - *Opacity*: When the *Highlight* option is enabled, this option will allow you to set the level of transparency of the nodes and edges that do not match the filter.

    > [!NOTE]
    > When you disable the *Highlight* option, the nodes that do not match the filter will no longer be displayed and the remaining nodes will be reorganized.

  - *Highlight/Show entire path*: When this option is enabled, not only the nodes matching the filter will be highlighted, but also the entire tree structure they are a part of (from root to leaves).

- *Node positions*: By default, this is set to *Layered*, which means nodes are displayed in different layers. Set this to *Custom* if you want to allow users with editing permission to drag and drop the nodes to a custom position. In that case, it is also possible to select a group of nodes by keeping the Ctrl key pressed while clicking them, and then move them together.

- Direction: Determines how different nodes are displayed depending on their importance, as indicated by their configured weight:

  - *Backwards*: Nodes are displayed from right to left in order of importance.

  - *Downwards*: Nodes are displayed from top to bottom in order of importance.

  - *Forwards*: Nodes are displayed from left to right in order of importance;

  - *Upwards*: Nodes are displayed from bottom to top in order of importance

- *Zooming*: Select whether users should be able to zoom in on the component or not. When this option is enabled, you can use the scroll wheel of the mouse to zoom in or out. Alternatively, you can right-click and drag across an area of the graph to zoom in on that area. Enabling this option also makes it possible to pan the graph by dragging it while keeping the left mouse button pressed.

- *Edge style*: Select whether the connections should be displayed as curly or straight lines.
