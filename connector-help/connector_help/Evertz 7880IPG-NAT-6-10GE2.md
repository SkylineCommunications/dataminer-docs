---
uid: Connector_help_Evertz_7880IPG-NAT-6-10GE2
---

# Evertz 7880IPG-NAT-6-10GE2

The 7880IPG-NAT-6-10GE2 is a high-density, multi-port, multi-flow hardware Network Address Translation (NAT) engine. It is conceptually organized as 6 WAN-side ports + 6 LAN-side ports, with a packet processing core between each WAN-LAN pair. A given processing core can sustain up to 256 data flows, configurable based on multicasts or VLAN Tags. This results in an exceptional product density of 12x10GE ports, with 1536 multicast/VLAN flows.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                                                               | **Based on** | **System Impact**                                                                     |
|----------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|---------------------------------------------------------------------------------------|
| 1.0.0.1              | Initial version                                                                                                                                                                                | \-           | \-                                                                                    |
| 1.0.1.1 \[SLC Main\] | \- Changed the polling method to subtable for all cores.- Added a Visio file to display the data of the Visio Events Table when the output bitrate is greater than 5 Mbps.- Implemented traps. | 1.0.0.1      | New range approved to the re-structured protocol for the new subtable polling method. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.1   | 2.9.2.r1.588           |
| 1.0.1.1   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.1   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.1   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Port number:** The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

SNMP gets and sets are used to retrieve information from the device and display it in tables, as well as to modify values.

The table information in this driver is shown in the same format as the native user interface of the device.

- The **General** page shows the IP address of the device, with two buttons that allow you to perform a system reboot or a factory reset.
- The **Traffic Monitoring** page shows the total bitrate received by WAN and LAN ports and also reports the temperature on the FPGA of the card.
- A series of tables show information about the number of cores and their mode of operation, about the port configuration, and about the interfaces related to each port.
- Six tables, one per core, display information regarding the InputFlow Configuration and the Address Translation Configuration for WAN to LAN and LAN to WAN.
- The **SNMP Polling Table** can be used to adjust the polling frequency of each table. In case values have been changed, a default values button below the table allows you to set the table to the default values again.
