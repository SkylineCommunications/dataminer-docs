---
uid: IpNetworkExplorer_getting_started
---

# Getting started with IP Network Explorer

When you open the IP Network Explorer app, you will see a topology overview of the network switches managed by your DataMiner System.

![Topology](~/solutions/images/NS_manual_topology.png)

## Scanning the network

If you do not see any network switches or only a partial topology, you can **scan your network** to detect supported network switches and update connectivity information:

1. Click the **Scan** button in the top-right corner of the *Topology* page.

   ![Scan the network](~/solutions/images/NS_manual_scan-network.png)

1. If this is the first time you run a scan, define a **default IP scan range**.

   Future scans will automatically use this range. You can update the default IP scan range at any time in the [application settings](xref:IpNetworkExplorer_UI_overview#application-settings).

   ![Set the default scan range](~/solutions/images/NS_manual_default-scan-range.png)

If you want to run a **one-time custom scan**, click the arrow next to the **Scan** button and select **Custom scan**.

![Custom scan](~/solutions/images/NS_manual_custom-scan.png)

Once the scan starts, Network Explorer will:

1. Identify supported network devices in your network.

1. Create an element for each discovered device.

1. Analyze the LLDP (Link Layer Discovery Protocol) information on the devices.

1. Analyze the CDP (Cisco Discovery Protocol) information on the Cisco IOS and NX OS devices.

1. Create the required DCF connections in DataMiner.

## Refreshing the connections

If you want to refresh the connections between network devices without scanning for new devices, use the **Update Connections** button.

The system will analyze the existing LLDP & CDP data from known devices and update the connection information where applicable.

By default, removed connections will not be automatically deleted. You can adjust this behavior in the [application settings](xref:IpNetworkExplorer_UI_overview#application-settings).
