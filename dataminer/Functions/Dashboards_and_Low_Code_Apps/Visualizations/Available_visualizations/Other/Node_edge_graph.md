---
uid: DashboardNodeEdgeGraph
---

# Node edge graph

The node edge graph component allows you to **visualize any type of objects (i.e. "nodes") and the connections between them (i.e. "edges")**. By linking parameters and properties to those nodes and edges, you can turn the graph into a full-fledged analytical tool that shows real-time alarm statuses and KPI data.

![Node edge graph](~/dataminer/images/Node_Edge_Graph.gif)<br>*Node edge graph component in DataMiner 10.4.9*

## Supported data types

The data necessary to create a node edge graph can be provided by means of GQI queries. Node queries provide data that will be visualized as nodes (i.e. objects), whereas edge queries provide data that will be visualized as edges (i.e. connections between objects).

The component should therefore **always be configured with [query data input](xref:Query_Data)**.

## Interacting with the node edge graph

What you see in the node edge graph depends on the provided data and your [component configuration](#configuration-options).

> [!NOTE]
> When edges are closely grouped together, edge labels may become minimized. If you hover the mouse pointer over the edge, the label becomes visible again. From DataMiner 10.3.0 [CU4]/10.4.0 [CU2]/10.4.5 onwards<!--RN 38974-->, you can press Ctrl+Space to display all labels at once.

### Available interactions

You can interact with the node edge graph in several ways:

- **Selecting an item**: Click an item to select it. You can select multiple items at the same time by keeping the Ctrl key pressed while clicking nodes. You can select all items at once, by pressing Ctrl + A.

  When you select one or multiple items in the node edge graph, the selected data becomes available under *All available data* > *Components* > *[Page name]* > *Node edge graph* > *Tables*.

  Thanks to this exposed data, you can use the node edge graph component as a dynamic selector, i.e. a component whose selection determines behavior or data elsewhere in your dashboard or app. A common use case is showing additional details when a node is selected.

  > [!NOTE]
  > Prior to DataMiner 10.5.0 [CU12]/10.6.3<!--RN 44015-->, the exact path to the exposed data may differ. For example, in versions prior to DataMiner [CU21]/10.3.0 [CU9]/10.4.12<!--RN 41141-->, component data is found under the *Feeds* data category.

- **Moving a node**: You can select and drag a node to a new position. You can move multiple nodes at the same time by keeping the Ctrl key pressed while selecting several nodes and then moving them together. You can move all nodes at once by pressing Ctrl + A and dragging them together.

  The conditions for repositioning nodes depend on your DataMiner version:

  - From DataMiner 10.5.0 [CU10]/10.6.1 onwards<!--RN 44144-->:

    - In the *Settings* pane, *Default mode* must be set to *Edit*.

    - Ensure that node moves update the underlying data and do not remain purely visual:

      - When *Advanced* > *Node positions* is set to *Layered* in the *Layout* pane, node positions are stored automatically when the user has editor permissions<!--RN 44154-->. See [Configuring security for a dashboard](xref:Configuring_dashboard_security) and [Configuring app security](xref:LowCodeApps_security_config).

      - When *Advanced* > *Node positions* is set to *Linked to data*, node positions are only stored if a node-move event is configured that triggers a *Launch a script* action. This Automation script should update the original data objects with the modified ones exposed by the event. For more information, see [Configuring node movement events](#configuring-node-movement-events).

  - Up to DataMiner 10.5.0 [CU9]/10.5.12:

    - In the *Layout* pane, *Advanced* > *Node positions* must be set to *Custom*.

    - The user must have the appropriate permissions to edit the dashboard/low-code app. See [Configuring security for a dashboard](xref:Configuring_dashboard_security) and [Configuring app security](xref:LowCodeApps_security_config).

### Zooming and panning

When the [*Zooming* option](#node-edge-graph-layout) is enabled, you can **zoom in or out** in two ways:

- Scroll up or down. Depending on your DataMiner version<!--RN 40017--> and the [*Hold Ctrl to zoom* option](#node-edge-graph-settings), you may need to hold the Ctrl key while scrolling.

- Right-click, drag to select an area, and zoom into it.

To **move left or right across the component**, click the graph and drag your mouse. Note that panning is only possible when zooming is enabled.

## Using dynamic coloring

The component uses dynamic coloring, which can be adjusted according to preference. When you hover the mouse pointer over a node or edge, a tooltip is displayed with detailed info. Click the circle in the top-right corner of the tooltip to switch between different coloring modes for all the nodes or edges of this type:

- *Static*: Edges have no color, nodes have the color from the node settings.

- *Analytical*: If you select this mode, further below in the tooltip you can select any of the columns that have a color filter applied (cf. configuration below) to make this the dominant column. This column is then indicated in bold and determines which color is used in the graph. The value of this column is also displayed under the nodes or edges. If WebSocket communication is enabled, the colors and values will be updated in real time to match parameter value updates and other real-time updates.

- *Alarm*: Nodes and edges are colored according to the highest severity of the parameters in the tooltip.

## Highlighting specific nodes

When you highlight items based on a query filter, only the items that match the filter are emphasized. Items outside the filter criteria remain visible, but with lowered opacity. The level of transparency can be adjusted.

To highlight items with a query filter:

1. In the *Layout* pane, make sure the *Filtering & Highlighting* > *Highlight* option is enabled.

1. Set your preferred opacity, for example `20 %`. This determines how clearly you will see the items that do not meet the criteria specified in the query filter.

   ![Highlight](~/dataminer/images/NodeEdgeGraph_Highlight.png)<br>*Node edge graph layout settings in DataMiner 10.6.1*

1. Add a query filter visualization to your app or dashboard.

1. Apply the same query data to the query filter that is used by the node edge graph.

1. From DataMiner 10.5.0 [CU12]/10.6.3 onwards<!--RN 44015-->, navigate to *All available data* > *Components* > *[Page name]* > *Query filter* in the *Data* pane, and drag the *Query columns* data item onto your node edge graph component.

   Note that in older DataMiner versions, the exact path may be different. For example, in versions prior to DataMiner [CU21]/10.3.0 [CU9]/10.4.12<!--RN 41141-->, component data is found under the *Feeds* data category.

   You can now use the query filter component to filter and refine the data displayed in the node edge graph component. Items that do not meet the specified criteria will be shown with lowered opacity.

> [!NOTE]
> When you disable the *Highlight* option, the nodes that do not match the filter will no longer be displayed and the remaining nodes will be reorganized.

## Configuration options

### Node edge graph layout

In the *Layout* pane, you can find the default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

Additionally, the following layout options are also available:

| Section | Option | Description |
|--|--|--|
| Filtering & Highlighting | Conditional coloring | Highlight certain columns in a tooltip based on a condition. For more information, refer to [Conditional coloring](#conditional-coloring). |
| Filtering & Highlighting | Highlight | Toggle the switch to determine whether the items that match the criteria specified in a query filter will be highlighted. Enabled by default. For more information, see [Highlighting specific nodes](#highlighting-specific-nodes). |
| Filtering & Highlighting | Opacity | Set the level of transparency of the nodes and edges that do not match the criteria specified in a query filter. This option is only available when *Highlight* is enabled. |
| Filtering & Highlighting | Highlight/Show entire path | Toggle the switch to determine whether only the nodes matching the filter are highlighted, or whether the entire tree structure they are a part of (from root to leaves) is highlighted as well. |
| Advanced | Empty result message | Available from 10.3.11/10.4.0 onwards<!-- RN 37173 -->. Specify a custom message that is displayed when a query returns no results. From DataMiner 10.5.0 [CU12]/10.6.3 onwards<!-- RN 44472 -->, this setting can be left empty, in which case no message is displayed and the component remains empty. See also: [Displaying a custom empty component message](xref:Tutorial_Dashboards_Displaying_a_custom_empty_component_message). |
| Advanced | Node positions | Change how the nodes are positioned within the component. See [Node position options](#node-position-options). |
| Advanced | Direction | Available when the *Node positions* option is set to *Layered* (default). Determine how different nodes are displayed depending on their importance, as indicated by their configured weight. See [Node position options](#node-position-options). |
| Advanced | Zooming | Toggle the switch to determine whether users should be able to zoom in on the component or not. See [Zooming and panning](#zooming-and-panning) |
| Advanced | Edge style | Select whether the connections should be displayed as curly (default) or straight lines. |

#### Conditional coloring

In the *Layout* pane, under *Conditional coloring*, you can configure color filters for specific columns so that these can be used for highlighting in case analytical coloring is used. You can switch to this coloring mode via the tooltip of a node or edge. See [Using dynamic coloring](#using-dynamic-coloring).

To configure a color filter:

- If the column you want to use for highlighting contains **discrete values**, click the color icon next to a value and then specify a highlight color for that value. If there are too many values to easily list them, you will first need to specify a filter in order to select a value.

- If the column you want to use for highlighting contains **values for which a specific range can be specified**, select the column, indicate the range to be highlighted, select the range and then click the color icon on the right to specify a highlight color. Multiple ranges can be indicated for one column, each with a color of its own.

#### Node position options

The node position settings determine how the graph arranges nodes visually. Depending on your dataset and use case, different positioning modes may be more suitable.

The following options are available:

- *Layered* (default): Nodes are displayed in different layers. The component will automatically arrange nodes and edges in the most logical way.

  When this option is enabled, you can then determine how different nodes are displayed depending on their importance, as indicated by their configured weight.

  - *Backwards*: Nodes are displayed from right to left in order of importance.

  - *Downwards*: Nodes are displayed from top to bottom in order of importance.

  - *Forwards*: Nodes are displayed from left to right in order of importance;

  - *Upwards*: Nodes are displayed from bottom to top in order of importance

- *Custom*: Available up to DataMiner 10.5.0 [CU9]/10.5.12<!--RN 44078-->. Allows users with editing permission to drag and drop the nodes to a custom position. In that case, it is also possible to select a group of nodes by keeping the Ctrl key pressed while clicking them, and then move them together.

- *Linked to data*: Available from DataMiner 10.3.0 [CU15]/10.4.0 [CU3]/10.4.6 onwards<!--RN 39417-->. Location information from your data is used to determine the node positions. To use this feature, your data must include at least two numeric columns representing the X and Y positions of each node's center. You can configure these columns in the *Identifiers* > *Nodes* section of the [*Settings* pane](#node-edge-graph-settings).

  > [!NOTE]
  > If the location info is missing for certain nodes, the *Settings* pane header will have an orange font.
  >
  > ![Location info missing](~/dataminer/images/Location_Info_Missing.png)

  Configure the initial viewport:

  - *Auto*: Automatically determine the viewport to fit all nodes. This is the default option.

  - *Custom*: Specify the *Center X*, *Center Y*, *Width*, and *Height* of your custom viewport.

### Node edge graph settings

In the *Settings* pane for this component, you can customize its behavior to suit your requirements.

| Section | Option | Description |
|--|--|--|
| WebSocket settings | Inherit WebSocket settings from page/panel | Clear the checkbox to use a custom polling interval for this component. When cleared, you can specify a different polling interval (in seconds). |
| General | Override dynamic units | Clear the checkbox to prevent parameter units from changing dynamically based on their value and protocol definition. Disabled by default. |
| General | Default mode | Available from DataMiner 10.5.0 [CU10]/10.6.1 onwards<!--RN 44078-->. Select whether the component should open in *Read* or *Edit* mode. Only in *Edit* mode can [nodes be repositioned](#available-interactions). |
| Data retrieval | Update data | Toggle the switch to determine whether the data should be refreshed automatically (provided this is supported by the data source). See [Query updates](xref:Query_updates)<!--RN 37269-->. Disabled by default. |
| Events | On node move | Available from DataMiner 10.5.0 [CU10]/10.6.1 onwards<!--RN 44144-->. Select *Configure actions* to configure events that will be triggered when a node belonging to the query is moved. See [Configuring node movement events](#configuring-node-movement-events). |
| Advanced | Hold Ctrl to zoom | Available from DataMiner 10.4.0 [CU10]/10.5.1 onwards<!--RN 41387-->, when the [*Zooming* layout option](#node-edge-graph-layout) is enabled. Select the checkbox to make the scroll wheel zoom only when you hold the Ctrl key. |

The node edge graph component supports showing multiple layers. The following *Identifiers* settings are available for each query added to the component:

| Section | Subsection | Option | Description |
|--|--|--|--|
| N/A | `<query name>` | ![marker](~/dataminer/images/Maps_Circle_icon.png) or ![line](~/dataminer/images/Maps_Line_icon.png) | In the box representing each query, click either *Set as node* or *Set as edge*. If a query is set as node, it will move to the nodes section. If a query is set as edge, it will move to the edges section. Once a query has been set to be a node or edge, you can still change this setting by clicking the node or edge icon in the top-right corner of the query box. |
| Nodes | `<query name>` | Node ID column | Select the column from the query that represents the node ID. |
| Nodes | `<query name>` | X/Y | Only available when the *Node positions* layout option is set to *Linked as data*. Select the column from the query that contains the X and Y positions respectively. |
| Nodes | Base node | Node name | This name is not displayed in the component itself, and is only intended to clarify the configuration. |
| Nodes | Base node | Label | Select the column to use as the label for the node. |
| Nodes | Base node | Shape | Select a different shape in the dropdown box to customize the node shape. By default, no shape is used. You can also select *Custom* in the dropdown box in order to get additional options that allow you to create a fully customized shape instead of one of the available presets. Click the circle to the right of the dropdown box to select a custom color for the shape. |
| Nodes | Base node | Visual | Available from DataMiner 10.3.0 [CU15]/10.4.0 [CU3]/10.4.6 onwards<!--RN 39417-->. Choose whether to show an icon or custom image within the node shape. |
| Nodes | Base node | Icon | Select a different icon from the dropdown box to customize the icon shown within the node shape. Click the circle to the right of the box to select a custom color. From DataMiner 10.3.0 [CU15]/10.4.0 [CU3]/10.4.6 onwards<!--RN 39417-->, this setting is only available if the *Visual* setting is set to *Icon*. |
| Nodes | Base node | Image | Only available if the *Visual* setting is set to *Image*. Enter a custom image link. |
| Nodes | Base node | Size | From DataMiner 10.3.0 [CU15]/10.4.0 [CU3]/10.4.6 onwards<!--RN 39417-->, use the slider to adjust the size of the node, with a minimum of 1 px and a maximum of 100 px (default: 48 px). Prior to DataMiner 10.3.0 [CU15]/10.4.0 [CU3]/10.4.6, select whether the node should be small, medium-sized, or large. |
| Nodes | Base node | Weight | A number indicating the relative importance of the node. The higher the number, the more important the node, which determines where it is displayed in the graph (depending on the layout settings). |
| Nodes | Base node | Enable tooltip | Available from DataMiner 10.3.0 [CU15]/10.4.0 [CU3]/10.4.6 onwards<!--RN 39417-->. This setting is only available when the parameter *showAdvancedSettings=true* is added to the URL. When this option is enabled, a tooltip is shown when the mouse pointer hovers over a node. This setting is enabled by default. |
| Nodes | Base node | Metric | Available from DataMiner 10.5.0 [CU11]/10.6.2 onwards<!--RN 44218-->. Configure how the node label is displayed. You can hide the label, derive it from conditional coloring, or select a custom column to display as the label. See [Configuring node and edge labels](#configuring-node-and-edge-labels). |
| Nodes | Base node | Show metric | Available from DataMiner 10.3.0 [CU15]/10.4.0 [CU3]/10.4.6<!--RN 39417--> up to DataMiner 10.5.0 [CU10]/10.6.1<!--RN 44218-->, when the parameter *showAdvancedSettings=true* is added to the URL. When this option is enabled, the metric that determines the conditional color of the node will not be displayed underneath the node. |
| Nodes | Base node | Actions | Select *Add action* to configure an action that is executed when a node is clicked or double-clicked, or when an icon is clicked in the tooltip. See [Adding actions to a node edge graph](#adding-actions-to-a-node-edge-graph). |
| Nodes | Override nodes | Add override | If you want to visualize some nodes differently for the same query, click *Add override*, specify a filter, and configure the nodes as detailed above. |
| Edges | `<query name>` | Source | Select the column from the query that represents the source of the connection. To the right of the dropdown list, click the icon representing the source node. |
| Edges | `<query name>` | Destination | Select the column from the query that represents the destination of the connection. To the right of the dropdown list, click the icon representing the destination nodes. |
| Edges | `<query name>` | Bidirectional configuration section | Optionally, configure how multiple edges between two nodes should be mapped. |
| Edges | `<query name>` | Actions | Select *Add action* to configure an action that is executed when an edge is clicked or double-clicked, or when an icon is clicked in the tooltip. See [Adding actions to a node edge graph](#adding-actions-to-a-node-edge-graph). |
| Edges | Actions | Style | Optionally, select a different style for the connection lines. |
| Edges | Actions | Weight | Optionally, specify a number to indicate the relative importance of the edge. This will determine the thickness of the connection line. |
| Edges | Actions | Enable tooltip | Available from DataMiner 10.3.0 [CU15]/10.4.0 [CU3]/10.4.6 onwards<!--RN 39417-->. This setting is only available when the parameter *showAdvancedSettings=true* is added to the URL. When this option is enabled, a tooltip is shown when the mouse pointer hovers over an edge. This setting is enabled by default. |
| Edges | Actions | Metric | Available from DataMiner 10.5.0 [CU11]/10.6.2 onwards<!--RN 44218-->. Configure how the node label is displayed. You can hide the label, derive it from conditional coloring, or select a custom column to display as the label. See [Configuring node and edge labels](#configuring-node-and-edge-labels). |
| Edges | Actions | Show metric | Available from DataMiner 10.3.0 [CU15]/10.4.0 [CU3]/10.4.6<!--RN 39417--> up to DataMiner 10.5.0 [CU10]/10.6.1<!--RN 44218-->, when the parameter *showAdvancedSettings=true* is added to the URL. When this option is enabled, the metric that determines the conditional color of the edge will not be displayed underneath the edge. |
| Edges | Actions | Visualize directions | Available from DataMiner 10.2.4/10.3.0 onwards. Toggle the switch to specify whether the edges should display a direction. |
| Edges | Action | How | Only available when *Visualize directions* is enabled. Choose how the direction should be displayed. Select *Flow* to visualize the direction using animated edges (default), or *Arrows* to show arrows drawn on the edges. You can also specify the exact arrow position. |
| Nodes | Actions | Add override | If you want to visualize some edges differently for the same query, click *Add override*, specify a filter, and configure the edges as detailed above. |

#### Configuring node and edge labels

From DataMiner 10.5.0 [CU11]/10.6.2 onwards<!--RN 44218-->, you can configure how labels are displayed for nodes and edges independently of [conditional coloring](#conditional-coloring). This configuration makes it possible to control label visibility and content separately from analytical coloring.

For each node query and edge query, and for any configured node or edge override, you can choose one of the following label options:

- **None**: No label is displayed, even if conditional coloring is configured for the selected column.

- **From coloring**: The label visibility is determined by the conditional coloring configuration.

- **Custom**: Allows you to select a specific column to use as the label. The label is shown even if the node or edge itself does not have conditional coloring.

  When you select *Custom*, the background color of edges is determined as follows:

  - If the selected column has conditional coloring, that color is used.

  - If the selected column does not have conditional coloring, but the edge does, the edge color is used.

  - If neither has conditional coloring, the default background color of the node edge graph component is used.

## Adding actions to a node edge graph

When you add a node edge graph to a low-code app, you can configure actions that are executed when a node or edge is clicked or double-clicked, or when an icon is selected in the tooltip that appears when you hover over the node or edge.

To configure actions:

1. In the *Component* > *Settings* pane, under the nodes or edges you want to configure actions for, expand the *Actions* section.

1. Click *Add action*.

1. At the top of the action configuration section, specify how the action is triggered:

   - ![On click](~/dataminer/images/NodeEdgeGraph_Onclick.png): The action is triggered when the node or edge is clicked.

   - ![On double-click](~/dataminer/images/NodeEdgeGraph_Ondouble-click.png): The action is triggered when the node or edge is double-clicked.

   - ![On icon click](~/dataminer/images/NodeEdgeGraph_Tooltipicon.png): The action is triggered when the icon in the tooltip is selected.

1. In the *Label* box, specify a label for the action.

1. In the *Icon* box, select an icon for the action.

1. In the *Action* box, select the action that should be executed. See [Configuring app events](xref:LowCodeApps_event_config).

### Configuring node movement events

From DataMiner 10.5.0 [CU10]/10.6.1 onwards<!--RN 44144-->, you can configure actions that are executed when a node belonging to a specific node query is moved in the node edge graph.

To configure these events:

1. In the *Settings* pane, expand the *Events* section.

1. Next to *On node move*, click *Configure actions*.

1. Configure any of the available actions, as detailed under [Configuring app events](xref:LowCodeApps_event_config#navigating-to-a-url).

When a user moves a node in the node edge graph, the event provides detailed information about what changed. This allows you to keep the graph and the underlying data in sync.

A *node move* event provides the following parameters:

- The row data of the node that was moved.

- The old position of the node: {x,y}

- The new position of the node: {x,y}

You can use this information to update your data source. For example, you can configure a *Launch a script* action that updates the original data objects with the modified values provided by the event.

If your data source does not support real-time updates, also configure an *Execute component action* to refetch the data.

### Node edge graph component actions

Component actions are operations that can be executed on a component when an event is triggered.

When you select the [*Execute component action* option](xref:LowCodeApps_event_config#executing-a-component-action), you can choose from a list of components in the app and the specific actions available for each of them.

For the node edge graph component, the following actions are available:

- *Fetch the data*: This action fetches the data for the component again. Available from DataMiner 10.2.10/10.3.0 onwards.

- *Clear selection*: This action clears the data status of the component. Available from DataMiner 10.3.0 [CU14]/10.4.0 [CU2]/10.4.5 onwards<!--RN 38974-->.

- *Set interaction mode*: Available from DataMiner 10.5.0 [CU10]/10.6.1 onwards<!--RN 44078-->. This action resets the component's default mode. Options:

  - *Edit*: Enables editing interactions such as repositioning nodes.

  - *Read*: Opens the component in view-only mode.

  - *Toggle*: Switches between *Edit* and *Read* modes.

> [!NOTE]
> You can also override the default action for a node or edge using the *Add override* option.
