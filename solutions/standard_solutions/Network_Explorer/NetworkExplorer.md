---
uid: NetworkExplorer
---

# Network Explorer

The Network Explorer allows you to monitor your IP network as efficiently as possible.

## Supported Infrastructure

Network Explorer supports all equipment that can be monitored using the following protocols:

- Arista Manager  
- Cisco Nexus  
- Cisco Manager  

## Getting Started

When opening the app, you will see a topology overview of the network switches managed by your DataMiner system.  
If you don’t see any network switches or only a partial topology, you can scan your network to detect supported network switches and update connectivity information.

![Topology](~/images/NS_manual_topology.png)

To start a scan, press the **Scan** button in the upper right-hand corner of the topology page.  

- The first time you run a scan, the system will ask you to define a **default IP scan range**.  
- Future scans will automatically use this range.  
- You can update the default IP scan range at any time in the **Application Settings**.  

![Scan the network](~/images/NS_manual_scan-network.png)

![Set the default scan range](~/images/NS_manual_default-scan-range.png)

If you want to run a **one-time custom scan**, click the arrow next to the **Scan** button and choose **Custom Scan**.

![Custom scan](~/images/NS_manual_custom-scan.png)

Once the scan starts, Network Explorer will:

1. Identify supported network devices in your network.  
2. Create an element for each discovered device.  
3. Analyze the LLDP (Link Layer Discovery Protocol) information on the devices.  
4. Create the required DCF connections in DataMiner.  

If you want to refresh the connections between network devices without scanning for new devices, you can use the **Update Connections** button.
The system will analyze the existing LLDP data from known devices and update the connection information where applicable.

By default, removed connections will not be automatically deleted. This behavior can be adjusted in the application settings.

## Topology View

The **Topology View** provides an overview of your network's status, based on real-time alarm data from your DataMiner system.  
Both network devices and connections are color-coded to reflect their status.

Click on any **device** or **connection** to view more details.

### Device Details

The **Device Details** page gives an overview of the device's overall health.

![Device details](~/images/NS_manual_device-details.png)

### Connection Details

The **Connection Details** page provides detailed insights into a connection.  
The **Bitrate** and **SFP** buttons at the top allow you to access interactive trend graphs.

![Connection details](~/images/NS_manual_connection-details.png)

## Ports View

The **Ports** page shows an overview of all ports for the selected network device.  
To switch devices, use the **drop-down box** in the upper right-hand corner.

![Ports](~/images/NS_manual_ports.png)

## Flow View

The **Flow View** is similar to the **Topology View** but is specifically used to track multicast traffic in your network.  
Use the **filter box** in the upper right-hand corner to find a multicast flow.

You can filter by:

- **Source IP address**
- **Multicast IP address**
- **Both**, using the format `source-ip/multicast-ip`.  

Example: `10.14.1.104/239.10.20.106`

![Flows](~/images/NS_manual_flows.png)
