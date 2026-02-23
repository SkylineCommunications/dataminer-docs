---
uid: IpNetworkExplorer_UI_overview
---

# IP Network Explorer UI overview

## Topology

The **Topology** view provides an overview of your network's status, based on real-time alarm data from your DataMiner System.

Both network devices and connections are color-coded to reflect their status.

Click any [device](#device-details) or [connection](#connection-details) to view more details.

A topology selector is available in the upper right-hand corner of the Topology view.
This dropdown allows you to select one of the available topologies to display.
Topologies make it possible to:
- Visualize the same network segments in different ways
- Focus on specific parts of the network
- Create clearer overviews for different operational needs
- Separate logical, geographical, or functional network structures

When a topology is selected, the view updates immediately to reflect the chosen configuration.

![Topology](~/solutions/images/NS_manual_topology.png)

When hovering over a connection, you can use the dot in the upper-right corner of the details window to choose which metric is displayed and used to color the lines.

![Topology connection details](~/solutions/images/NS_manual_topology_hover.png)

You select either interface operational status or interface output utilization.

![Topology connection analytics](~/solutions/images/NS_manual_topology_analytics.png)

### Device Details

The **Device Details** page gives an overview of the device's overall health.

![Device details](~/solutions/images/NS_manual_device-details.png)

### Connection Details

The **Connection Details** page provides detailed insights into a connection.

The **Bitrate** and **SFP** buttons at the top allow you to access interactive trend graphs.

![Connection details](~/solutions/images/NS_manual_connection-details.png)

## Ports

The **Ports** page shows an overview of all ports for the selected network device.

To switch devices, use the **dropdown box** in the top-right corner.

![Ports](~/solutions/images/NS_manual_ports.png)

Using the Compare button in the menu bar, you can view the ports of two devices side by side for easier analysis.

![Compare Ports](~/solutions/images/NS_manual_ports_compare.png)

## Flows

The **Flows** page is similar to the **Topology** page but is specifically used to track multicast traffic in your network.

Use the **filter box** on the left-hand side to find a multicast flow.

You can filter by:

- Source IP address
- Multicast IP address
- Both, using the format `source-ip/multicast-ip`. For example: `10.14.1.104/239.10.20.106`.

![Flows](~/solutions/images/NS_manual_flows.png)

## Application settings

In the application settings window, you can manage the different topologies, update the default IP scan range and adjust the automatic removal behavior for removed connections.

To access the application settings, click the *About* button in the top-right corner and then click the *Settings* button at the top of window.

![Settings](~/solutions/images/NS_manual_settings.png)

### Topology settings

You can also use the ADD button in the upper right-hand corner of the application to create a new topology.
In the overview list of the topologies you can use the pencil icon to Edit an existing topology or the trashcan icon to Delete a topology.

#### Creating a Topology

When creating a new topology, the following information is required:

1. Unique Name

Each topology must have a unique name.
This name will appear in the topology selection dropdown.

1. View Selection

You must select a View.
The selected view determines which network elements are displayed in the topology.

Only elements that are:
- Present in the selected view
- Present in its subviews

will be included in the topology.

This allows you to create filtered and purpose-driven network visualizations based on your existing view structure.

Changes take effect immediately and will be reflected in the topology selector.

![ADD Topology](~/solutions/images/NS_manual_add_topology.png)