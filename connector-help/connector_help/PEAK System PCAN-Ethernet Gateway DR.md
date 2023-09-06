---
uid: Connector_help_PEAK_System_PCAN-Ethernet_Gateway_DR
---

# PEAK System PCAN-Ethernet Gateway DR

The PCAN-Ethernet Gateway DR allows the connection of different CAN buses over IP networks. CAN frames are wrapped in TCP or UDP message packets and then forwarded via the IP network from one device to another. The PCAN-Ethernet Gateway DR features one LAN connection, two high-speed CAN interfaces, DIN rail casing, and support for an extended temperature range.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.0                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver consists of the following data pages:

- **General:** Contains general parameters such as the Product Name, Serial Number, Name and Description. Also contains **Interface Count** information, and displays the available Hardware, Software, Website and JSON Interface Versions.

- **Status:** This page the contains the CAN and LAN Interfaces Tables and also the Defined Routes Table.

- The **CAN Interfaces Table** contains status information such as State, Bit Rate, Bit Rate Pre Scaler, Phase Segment, Sample Point and RX/TX Errors for each available CAN interface.
  - The **LAN Interfaces Table** contains information such as DHCP, IPv4 related and MAC for each available LAN interface.
  - The **Defined Routes Table** contains information such as the IP Address, Port, Packets, Errors and TCP Delay for each defined route.
