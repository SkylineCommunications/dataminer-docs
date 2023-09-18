---
uid: Connector_help_Alcatel_Manager
---

# Alcatel Manager

The **Alcatel Manager controller** is mainly used as a platform to monitor relevant information from the device.

## About

### Version Info

| **Range**            | **Key Features**                            | **Based on** | **System Impact**                                                     |
|----------------------|---------------------------------------------|--------------|-----------------------------------------------------------------------|
| 1.0.1.x \[SLC Main\] | Overall update to match current guidelines. | 1.0.0.7      | Layout, internal logic, and PID changed, and many parameters deleted. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.1.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device. (default: *public*)
- **Set community string**: The community string used when setting values on the device. (default: *private*)

## How to use

This connector is mainly used as a monitoring platform. It allows you to check different parameters related to the interfaces, different kinds of statistics (IP, TCP/UDP, ICMP), BGP, and LDP.

On the **General** \> **Configuration** subpage, you can configure whether the **LLDP** page should be displayed.
