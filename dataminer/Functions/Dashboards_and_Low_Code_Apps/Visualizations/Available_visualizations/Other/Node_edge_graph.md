---
uid: DashboardNodeEdgeGraph
---

# Node edge graph

The node edge graph component allows you to **visualize any type of objects (i.e. "nodes") and the connections between them (i.e. "edges")**. By linking parameters and properties to those nodes and edges, you can turn a node edge graph into a full-fledged analytical tool that shows real-time alarm statuses and KPI data.

![Node edge graph](~/dataminer/images/Node_Edge_Graph.gif)<br>*Node edge graph component in DataMiner 10.4.9*

## Supported data types

The data necessary to create a node edge graph can be provided by means of GQI queries. Node queries provide data that will be visualized as nodes (i.e. objects), whereas edge queries provide data that will be visualized as edges (i.e. connections between objects).

The node edge graph component should therefore **always be configured with [query data input](xref:Query_Data)**.

## Interacting with the node edge graph

Clicking items in the node edge graph also makes these available as data for other components. Keeping the Ctrl key pressed while you click them allows you to select multiple items at the same time.

When edges are closely grouped together, edge labels may become minimized. If you hover the mouse pointer over the edge, the label becomes visible again. From DataMiner 10.3.0 [CU4]/10.4.0 [CU2]/10.4.5 onwards<!--RN 38974-->, you can press Ctrl+Space to display all labels in the node edge graph.

### Zooming and panning

When the [*Zooming* layout option](#node-edge-graph-layout) is enabled, there are several ways to **zoom in or out** on a node edge graph component:

- Press Ctrl while scrolling up or down.

- Right-click and select an area of the graph to zoom in on that selected area.

- Prior to DataMiner 10.3.0 [CU18]/10.4.0 [CU6]/10.4.9<!--RN 40017-->: Scroll up or down.

To **move left or right across the component**, click the graph and drag your mouse. Note that panning is only possible when zooming is enabled.

## Using dynamic coloring

The component uses dynamic coloring, which can be adjusted according to preference. When you hover the mouse pointer over a node or edge, a tooltip is displayed with detailed info. Click the circle in the top-right corner of the tooltip to switch between different coloring modes for all the nodes or edges of this type:

- *Static*: Edges have no color, nodes have the color from the node settings.

- *Analytical*: If you select this mode, further below in the tooltip you can select any of the columns that have a color filter applied (cf. configuration below) to make this the dominant column. This column is then indicated in bold and determines which color is used in the graph. The value of this column is also displayed under the nodes or edges. If WebSocket communication is enabled, the colors and values will be updated in real time to match parameter value updates.

- *Alarm*: Nodes and edges are colored according to the highest severity of the parameters in the tooltip.

## Highlighting specific nodes

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
| Advanced | Empty result message | Available from 10.3.11/10.4.0 onwards<!-- RN 37173 -->. Specify a custom message that is displayed when a query returns no results. See also: [Displaying a custom empty component message](xref:Tutorial_Dashboards_Displaying_a_custom_empty_component_message). |
| Advanced | Node positions | Change how the nodes are positioned within the component. See [Node position options](#node-position-options). |
| Advanced | Direction | Available when the *Node positions* option is set to *Layered* (default). Determine how different nodes are displayed depending on their importance, as indicated by their configured weight. See [Node position options](#node-position-options). |
| Advanced | Zooming | Toggle the switch to determine whether users should be able to zoom in on the component or not. See [Zooming and panning](#zooming-and-panning) |
| Advanced | Edge style | Select whether the connections should be displayed as curly (default) or straight lines. |

#### Conditional coloring

This option allows you to specify color filters for specific columns, so that these can be used for highlighting in case analytical coloring is used. Users can switch to this coloring mode via the tooltip of a node or edge. To configure a color filter:

    - If the column you want to use for highlighting contains discrete values, click the color icon next to a value and then specify a highlight color for that value. If there are too many values to easily list them, you will first need to specify a filter in order to select a value.

    - If the column you want to use for highlighting contains values for which a specific range can be specified, select the column, indicate the range to be highlighted, select the range and then click the color icon on the right to specify a highlight color. Multiple ranges can be indicated for one column, each with a color of its own.

#### Node position options

The following options are available:

- *Layered*: Nodes are displayed in different layers. This is the default option.

  When this option is enabled, you can then determine how different nodes are displayed depending on their importance, as indicated by their configured weight.

  - *Backwards*: Nodes are displayed from right to left in order of importance.

  - *Downwards*: Nodes are displayed from top to bottom in order of importance.

  - *Forwards*: Nodes are displayed from left to right in order of importance;

  - *Upwards*: Nodes are displayed from bottom to top in order of importance

- *Custom*: Allows users with editing permission to drag and drop the nodes to a custom position. In that case, it is also possible to select a group of nodes by keeping the Ctrl key pressed while clicking them, and then move them together.

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
| Data retrieval | Update data | Toggle the switch to determine whether the data should be refreshed automatically (provided this is supported by the data source). See [Query updates](xref:Query_updates)<!--RN 37269-->. Disabled by default. |
| Advanced | Hold Ctrl to zoom | Available from DataMiner 10.4.0 [CU10]/10.5.1 onwards<!--RN 41387-->, when the [*Zooming* layout option](#node-edge-graph-layout) is enabled. Select the checkbox to make the scroll wheel zoom only when you hold the Ctrl key. |

The node edge graph component supports showing multiple layers. The following *Identifiers* settings are available for each query added to the component:

| Section | Subsection | Option | Description |
|--|--|--|--|
| N/A | Nodes/Edges | ![marker](~/dataminer/images/Maps_Circle_icon.png) or ![line](~/dataminer/images/Maps_Line_icon.png) | In the box representing each query, click either *Set as node* or *Set as edge*. If a query is set as node, it will move to the nodes section. If a query is set as edge, it will move to the edges section. Once a query has been set to be a node or edge, you can still change this setting by clicking the node or edge icon in the top-right corner of the query box. |
| Nodes | `<query name>` | Node ID column | Select the column from the query that represents the node ID. |
| Nodes |`<query name>` | X/Y | Only available when the *Node positions* layout option is set to *Linked as data*. Select the column from the query that contains the X and Y positions respectively. |
| Nodes | Base node | Node name | This name is not displayed in the component itself, and is only intended to clarify the configuration. |
| Nodes | Base node | Label | Select the column to use as the label for the node. |
| Nodes | Base node | Shape | Select a different shape in the dropdown box to customize the node shape. By default, no shape is used. You can also select *Custom* in the dropdown box in order to get additional options that allow you to create a fully customized shape instead of one of the available presets. Click the circle to the right of the dropdown box to select a custom color for the shape. |
| Nodes | Base node | Visual | Available from DataMiner 10.3.0 [CU15]/10.4.0 [CU3]/10.4.6 onwards<!--RN 39417-->. Choose whether to show an icon or custom image within the node shape. |
| Nodes | Base node | Icon | Select a different icon from the dropdown box to customize the icon shown within the node shape. Click the circle to the right of the box to select a custom color. From DataMiner 10.3.0 [CU15]/10.4.0 [CU3]/10.4.6 onwards<!--RN 39417-->, this setting is only available if the *Visual* setting is set to *Icon*. |
| Nodes | Base node | Image | Only available if the *Visual* setting is set to *Image*. Enter a custom image link. |
| Nodes | Base node | Size | From DataMiner 10.3.0 [CU15]/10.4.0 [CU3]/10.4.6 onwards<!--RN 39417-->, use the slider to adjust the size of the node, with a minimum of 1 px and a maximum of 100 px (default: 48 px). Prior to DataMiner 10.3.0 [CU15]/10.4.0 [CU3]/10.4.6, select whether the node should be small, medium-sized, or large. |
| Nodes | Base node | Weight | A number indicating the relative importance of the node. The higher the number, the more important the node, which determines where it is displayed in the graph (depending on the layout settings). |
| Nodes | Base node | Enable tooltip | Available from DataMiner 10.3.0 [CU15]/10.4.0 [CU3]/10.4.6 onwards<!--RN 39417-->. This setting is only available when the parameter *showAdvancedSettings=true* is added to the URL. When this option is enabled, a tooltip is shown when the mouse pointer hovers over a node. This setting is enabled by default. |
| Nodes | Base node | Show metric | Available from DataMiner 10.3.0 [CU15]/10.4.0 [CU3]/10.4.6 onwards<!--RN 39417-->. This setting is only available when the parameter *showAdvancedSettings=true* is added to the URL. When this option is enabled, the metric that determines the conditional color of the node will not be displayed underneath the node. |
| Nodes | Override nodes | Add override | If you want to visualize some nodes differently for the same query, click *Add override*, specify a filter, and configure the nodes as detailed above. |
| Edges | `<query name>` | Source | Select the column from the query that represents the source of the connection. To the right of the dropdown list, click the icon representing the source node. |
| Edges | `<query name>` | Destination | Select the column from the query that represents the destination of the connection. To the right of the dropdown list, click the icon representing the destination nodes. |
| Edges | `<query name>` | Bidirectional configuration section | Optionally, configure how multiple edges between two nodes should be mapped. |
| Edges | Actions | Style | Optionally, select a different style for the connection lines. |
| Edges | Actions | Weight | Optionally, specify a number to indicate the relative importance of the edge. This will determine the thickness of the connection line. |
| Edges | Actions | Enable tooltip | Available from DataMiner 10.3.0 [CU15]/10.4.0 [CU3]/10.4.6 onwards<!--RN 39417-->. This setting is only available when the parameter *showAdvancedSettings=true* is added to the URL. When this option is enabled, a tooltip is shown when the mouse pointer hovers over an edge. This setting is enabled by default. |
| Edges | Actions | Show metric | Available from DataMiner 10.3.0 [CU15]/10.4.0 [CU3]/10.4.6 onwards<!--RN 39417-->. This setting is only available when the parameter *showAdvancedSettings=true* is added to the URL. When this option is enabled, the metric that determines the conditional color of the edge will not be displayed underneath the edge. |
| Edges | Actions | Visualize directions | Available from DataMiner 10.2.4/10.3.0 onwards. Toggle the switch to specify whether the edges should display a direction. |
| Edges | Action | How | Only available when *Visualize directions* is enabled. Choose how the direction should be displayed. Select *Flow* to visualize the direction using animated edges (default), or *Arrows* to show arrows drawn on the edges. You can also specify the exact arrow position. |
| Nodes | Actions | Add override | If you want to visualize some edges differently for the same query, click *Add override*, specify a filter, and configure the edges as detailed above. |

## Component actions configuration

If you add a node edge graph to a custom app using the [DataMiner Low-Code Apps](xref:Application_framework), you can also configure actions for the component. This feature is not available in the Dashboards app.

To configure actions:

1. In the *Component* \> *Settings* pane, under the nodes or edges you want to configure actions for, expand the *Actions* section.

1. Click *Add action*.

1. To specify how the action is triggered, at the top of the action configuration section, click the icon for click, double-click, or button in tooltip.

1. In the *Label* box, specify a label for the action.

1. In the *Icon* box, select an icon for the action.

1. In the *Action* box, select the action that should be executed. See [Configuring app events](xref:LowCodeApps_event_config).

You can configure the following [**component actions**](xref:LowCodeApps_event_config#executing-a-component-action):

- *Fetch the data*: Fetches the data for the component. Available from DataMiner 10.2.10/10.3.0 onwards.

- *Clear selection*: Clear the data status of the component. Available from DataMiner 10.3.0 [CU14]/10.4.0 [CU2]/10.4.5 onwards<!--RN 38974-->.

> [!NOTE]
> You can also override the default action for a node or edge using the *Add override* option.
