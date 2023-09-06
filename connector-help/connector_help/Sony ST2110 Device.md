---
uid: Connector_help_Sony_ST2110_Device
---

# Sony ST2110 Device

The NXLK-IP50Y SDI-IP Converter Board has eight 1.5/3G-SDI bi-directional ports plus dual SFP28 (25Gb Ethernet) ports for network connection redundancy. It is compatible with ST 2110-20/30/40 streaming formats and allows very low latency signal conversion, making it ideal for integration in real-time IP Live production environments.

## About

### Version Info

| **Range**            | **Key Features**                                                                      | **Based on** | **System Impact** |
|----------------------|---------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Supports monitoring of standard Sony MIBsSupports monitoring of Sony Pro IP Live MIBs | \-           | \-                |
| 1.0.2.x \[SLC Main\] | Added DCF support                                                                     | 1.0.1.3      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.10                   |
| 1.0.2.x   | 1.10                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector has the following data pages:

- **General**: This page displays system information, including the **System Time**, **System Description**, **System Location**, **System Contact**, **System Up Time**, and other general parameters.

- **Network**: This page displays the **Interfaces** table. This table displays the operational status of the interfaces available in the workstation. This operational status can change based on incoming traps.

- **Product Information**: This page displays the **Product Information**, **Modules**, and **Remote Maintenance** tables.

- **Traps**: This page displays the **Traps Destination** table.

- **Alarms**: This page displays the **Error Status** table. This table is both polled and updated based on traps. The table is cleared when a "Coldstart" trap is received.

- IP Live LSM: The KPIs related to the LSM connection.
  - IP Live NMOS: The KPIs related to the NMOS status.
  - IP Live ST2059: The network information related to ST2059.
  - Video Streams: The KPIs related to the Tx and Rx of the video streams.
  - Audio Streams: The KPIs related to the Tx and Rx of the audio streams.
  - Metastreams: The KPIs related to the Tx and Rx of the metastreams.
  - Network Interfaces/Network Statistics: KPIs related to the IP Live network interfaces.

## Notes

In the Sony LEO solution, all the elements running this connector can be monitored by the other elements that run the connectors Sony Signal Processing Unit, Sony PWS-4500, and Sony PWS-110SC1.This is done using the monitors class library.
