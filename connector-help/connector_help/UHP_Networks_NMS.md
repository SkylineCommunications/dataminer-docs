---
uid: Connector_help_UHP_Networks_NMS
---

# UHP Networks NMS

The **UHP Networks NMS** DataMiner connector can be used to retrieve information from a UHP Networks Network Monitoring System.

## About

This connector makes it possible to monitor the UHP Networks NMS, hubs and remote modems. The connector uses the **HTTP** protocol as a primary connection to retrieve data from the remote platform API.

All data in the element is read-only. It is not possible to configure the UHP Networks NMS via DataMiner.

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3.2.0                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                                                                                                                                                                                                              |
|-----------|---------------------|-------------------------|-----------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | [UHP Networks NMS - Controller](xref:Connector_help_UHP_Networks_NMS_-_Controller)<br>[UHP Networks NMS - Station](xref:Connector_help_UHP_Networks_NMS_-_Station)<br>[UHP Networks NMS - Network](xref:Connector_help_UHP_Networks_NMS_-_Network) |

## Configuration

### Connections

#### HTTP Primary connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

#### SNMP connection

The connector only uses this SNMP connection when the Management IP is selected for controllers and stations. This connection requires no input during element creation.

### Initialization

On the configuration page, **the API token** can be specified. By default, this token is an empty string.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector consists of the data pages described below.

### General

This page displays all **Networks** that are defined in the NMS, with the **number of remotes** in the network, **C/N of stations and controllers**, and **Rx and Tx traffic** **rates**.

Via the Networks page button, you can access the **Networks Enable/Disable** subpage, where you can enable or disable DVEs for the available networks in the NMS.
It also features a toggle button that allows you to enable or disable the automatic creation of DVEs.

### Controllers

This page contains a table listing the controllers, with their state, type, IP address, position, and number of packets and faults.

Via the **Controllers** and the **Routes** page buttons, you can access the following subpages:

- **Controller Routes**: Displays a table with all defined IP packet routes on all controllers. The **Management IP** for each controller can be defined in this table.

- **Controller Enable/Disable**: Displays a table where you can **enable/disable DVE creation** for each controller. The following settings are also available:

- **Auto Enable Controllers**: When this is enabled, if the connector detects a new controller, a new DVE element will automatically be created.
  - **Auto Delete Controller DVEs**: When this is enabled, if the controller is removed from the UHP NMS, the DVE element will automatically be deleted in DataMiner. When this is disabled, you can delete the DVE manually by clicking the **Disable** toggle button in the DVE.
  - **Auto Delete Controller Delay:** Specifies the amount of time a DVE stays enabled after it is removed from the NMS.
  - **Create DVE for Deactivated Remotes**: When this is disabled, controllers that are not enabled are treated the same way as removed controllers: no DVE element will be created if the **Auto Enable Controllers** option is enabled. Enable this setting if you also want an element for controllers that are not enabled.

### Stations

This page contains a table listing the stations, with the following information: state, serial number, location, IP address, DHCP, TFTP, multicast, contact info, last fault and last recovery, Rx and Tx traffic rates, C/N on station and controller, ACM channel and TDMA requests.

Via the **Remotes** and the **Routes** page buttons, you can access the following subpages:

- **Station Routes**: Displays a table with all defined IP packet routes on all stations. The **Management IP** for each station can be defined in this table.
- **Remotes Enable/Disable**: Displays a table where you can **enable/disable DVE creation** for each remote station. The following settings are also available:
  - **Auto Enable Remotes**: When this is enabled, if the connector detects a new remote, a new DVE element will automatically be created.
  - **Auto Delete Remote DVEs**: When this is enabled, if the remote is removed from the UHP NMS, the DVE element will automatically be deleted in DataMiner. When this is disabled, you can delete the DVE manually by clicking the **Disable** toggle button in the DVE.
  - **Auto Delete Remote Delay:** Specifies the amount of time a DVE stays enabled after it is removed from the NMS.
  - **Create DVE for Deactivated Remotes:** When this is disabled, Remotes that have the state "Down" are treated the same way as removed remotes: no DVE element will be created if the **Auto Enable Controllers** option is enabled. Enable this setting if you also want an element for remotes that have the state "Down".

### Exported Data

This page contains four tables with all the data that is exported to the DVEs.

### Ping Function

This page displays information about the ping queries, such as **Ping Status**, **Average Success**, **Average RTT**, **Availability** and **Percentage of Packet Loss**. It also contains a toggle button to enable or disable ping queries, as well as other editable properties of the queries, such as **Cycle**, **Timeout**, **Requests per Cycle** and **Requests History**.

This page also contains a page button **DVE Pings**, that displays the export table for every DVE that has the **Management IP** defined.

### Configuration

On this page, the **API token** can be configured. By default, the API accepts an empty string.

### Web Interface

This page displays the web interface of the NMS. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
