---
uid: Connector_help_Generic_MIB_II
---

# Generic MIB-II

This connector contains the core SNMP parameters from generic MIBs such as RFC1213 and RFC1317.

It is intended to be used with generic SNMP devices. SNMP is used to communicate with the devices.

## About

### Version Info

| **Range** | **Key Features**       | **Based on** | **System Impact** |
|-----------|------------------------|--------------|-------------------|
| 1.0.0.x   | Initial version        | \-           | \-                |
| 1.0.1.x   | Fully reviewed version | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |
| 1.0.1.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device (default: public).
- **Set community string**: The community string used when setting values on the device (default: private).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

Various pages with statistics are available, including **TCP, IP, UDP, SNMP and ICMP statistics**.

On the **Address Translations** page, you can find a table with key information such as the physical address and net address. Similarly, the **Interfaces** page contains key information related to interfaces.

The **RS232** page provides access to several subpages with more detailed RS232-related information.
