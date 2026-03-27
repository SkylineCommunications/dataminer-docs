---
uid: IpNetworkExplorer_UI_overview
---

# IP Network Explorer UI overview

## Topology

The **Topology** page provides an overview of your network's status, based on real-time alarm data from your DataMiner System.

Both network devices and connections are color-coded to reflect their status.

Click any [device](#device-details) or [connection](#connection-details) to view more details.

![Topology page](~/solutions/images/NS_manual_topology.png)

### Topology selection

A topology selector is available in the middle of the header bar. Use this dropdown to choose which topology to display.

Topologies make it possible to:

- Visualize the same network segments in different ways.
- Focus on specific parts of the network.
- Create clearer overviews for different operational needs.
- Separate logical, geographical, or functional network structures.

When a topology is selected, the view updates immediately to reflect the chosen configuration.

### Metric selection

When hovering over a connection, you can use the dot in the upper-right corner of the details window to choose which metric is displayed and used to color the lines.

![Topology connection details shown when hovering over a connection](~/solutions/images/NS_manual_topology_hover.png)

You can select either interface operational status or interface output utilization.

![Topology connection analytics](~/solutions/images/NS_manual_topology_analytics.png)

### Device Details

The **Device Details** pane gives an overview of the device's overall health.

![Device details pane](~/solutions/images/NS_manual_device-details.png)

### Connection Details

The **Connection Details** pane provides detailed insights into a connection.

The **Bitrate** and **SFP** buttons at the top allow you to access interactive trend graphs.

![Connection details pane](~/solutions/images/NS_manual_connection-details.png)

## Ports

The **Ports** page shows an overview of all ports for the selected network device.

To switch devices, use the **dropdown box** in the upper-right corner.

![Ports page](~/solutions/images/NS_manual_ports.png)

With the *Compare* button in the header bar, you can view the ports of two devices side by side for easier analysis.

![Side-by-side comparison of the ports of two devices](~/solutions/images/NS_manual_ports_compare.png)

## Flows

The **Flows** page is similar to the **Topology** page but is specifically used to track multicast traffic in the network.

Use the **filter box** on the left side of the page to find a multicast flow.

You can filter by:

- Source IP address
- Multicast IP address
- Both, using the format `source-ip/multicast-ip`. For example: `10.14.1.104/239.10.20.106`.

![Flows](~/solutions/images/NS_manual_flows.png)

## Application settings

To open the application settings, click the cogwheel button at the bottom of the sidebar on the left.

In the application settings window, you can manage the different topologies, update the default IP scan range and adjust the automatic removal behavior for removed connections.

![Application settings window](~/solutions/images/NS_manual_settings.png)

### Topology settings

With the *ADD* button in the upper-right corner of the application settings window, you can [create a new topology](#creating-a-topology).

In the overview list of the topologies, you can use the pencil icon to edit an existing topology or the garbage can icon to delete a topology.

![Topology settings within the application settings window](~/solutions/images/NS_topology_settings.png)

### Creating a topology

When you have clicked the *ADD* button in the application settings window, you will need to specify the following information to create a new topology:

- **Name**: Each topology must have a **unique name**. This name will be shown in the topology selection dropdown.

- **View filter**: You must select a view. The selected view determines which network elements are displayed in the topology.

  Only elements that are present in the selected view or in its subviews will be included in the topology. This allows you to create filtered and purpose-driven network visualizations based on your existing view structure.

Changes take effect immediately after you click *Save* and will be reflected in the topology selector.

![Pop-up window to create a topology](~/solutions/images/NS_manual_add_topology.png)
