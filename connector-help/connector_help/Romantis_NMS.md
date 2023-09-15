---
uid: Connector_help_Romantis_NMS
---

# Romantis NMS (Deprecated)

**This connector is deprecated as the vendor name has changed. It is now available under the name [UHP Networks NMS](xref:Connector_help_UHP_Networks_NMS).**

The **Romantis NMS** DataMiner connector can be used to retrieve information from a Romantis Network Monitoring System.

## About

This connector makes it possible to monitor the Romantis NMS, hubs and remote modems. This connector uses the **HTTP** protocol as a primary connection to retrieve data from the remote platform API.

All data in the element is read-only. It is not posible to configure the Romantis NMS via DataMiner.

### Version Info

| **Range** | **Description**                                                                                                                                                                                                                       | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                                                                                                                                                                                       | No                  | Yes                     |
| 1.0.1.x          | Added secondary HTTP connection to allow polling of a redundant system. There is no way to determine which NMS is online, so switching must be done manually.                                                                         | No                  | Yes                     |
| 1.0.2.x          | Removed secondary HTTP connection. Creation of DVEs for each controller and station. Added a hidden SNMP connection to populate the DVEs with additional parameters from controllers and stations when the Management IP is selected. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 3.2.0                       |
| 1.0.1.x          | 3.2.0                       |
| 1.0.2.x          | 3.2.0                       |

### Exported connectors

| **Exported Connector**                                                            | **Description**                                                 |
|----------------------------------------------------------------------------------|-----------------------------------------------------------------|
| [Romantis NMS - Controller](xref:Connector_help_Romantis_NMS_-_Controller) | Retrieves information on a controller connected to the NMS.     |
| [Romantis NMS - Station](xref:Connector_help_Romantis_NMS_-_Station)       | Retrieves information on a remote station connected to the NMS. |

## Installation and configuration

### Creation

#### HTTP Primary

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

#### HTTP NMS2 connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

#### SNMP

This connector only uses this SNMP connection when the Management IP is selected for controllers and stations. This connection does not require any input during element creation.

### Configuration

On the configuration page, **the API token** can be specified. By default, this token is an empty string.

## Usage

### Networks

This page displays all networks that are defined in the NMS, with the **number of remotes** in the network, **C/N of stations and controllers**, and **Rx and Tx traffic** **rates**.

### Controllers

This page contains a table listing the controllers, with their state, type, IP address, position, number of packets and faults.

Via the **Controllers** and the **Routes** page buttons, you can access the following subpages:

- **Controller Routes**: Displays a table with all defined IP packet routes on all controllers. The **Management IP** for each controller can be defined in this table.
- **Controller Enable/Disable**: Displays a table where you can **enable/disable DVE creation** for each controller.

### Stations

This page contains a table listing the stations, with the following information: state, serial number, location, IP address, DHCP, TFTP, multicast, contact info, last fault and last recovery, Rx and Tx traffic rates, C/N on station and controller, ACM channel and TDMA requests.

Via the **Remotes** and the **Routes** page buttons, you can access the following subpages:

- **Station Routes**: Displays a table with all defined IP packet routes on all stations. The **Management IP** for each station can be defined in this table.
- **Remotes Enable/Disable**: Displays a table where you can **enable/disable DVE creation** for each remote station.

### Exported Data

This page contains four tables with all the data that is exported to the DVEs.

### Configuration

On this page, the **API token** can be configured. By default, the API accepts an empty string.

In the 1.0.1.x range of the connector only, there is also the possibility to switch between the main and backup NMS. As it is not possible to automatically determine which NMS is online, switching must be done manually.

### Web Interface

This page displays the web interface of the NMS. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
