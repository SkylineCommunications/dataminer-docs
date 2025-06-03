---
uid: IpNetworkExplorer_UI_overview
---

# IP Network Explorer UI overview

## Topology

The **Topology** view provides an overview of your network's status, based on real-time alarm data from your DataMiner System.

Both network devices and connections are color-coded to reflect their status.

Click any [device](#device-details) or [connection](#connection-details) to view more details.

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

Use the **filter box** in the top-right corner to find a multicast flow.

You can filter by:

- Source IP address
- Multicast IP address
- Both, using the format `source-ip/multicast-ip`. For example: `10.14.1.104/239.10.20.106`.

![Flows](~/solutions/images/NS_manual_flows.png)

## Application settings

In the application settings window, you can update the default IP scan range and adjust the automatic removal behavior for removed connections.

To access the application settings, click the *About* button in the top-right corner and then click the *Settings* button at the top of window.
