---
uid: Connector_help_Generic_MIB-II
---

# Generic MIB-II

This connector contains the core SNMP parameters from generic MIBs such as RFC1213 and RFC1317.

It is intended to be used with generic SNMP devices. SNMP is used to communicate with the devices.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                                                                | **Based on** | **System Impact** |
|----------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version                                                                                                                                                                                 | \-           | \-                |
| 2.0.0.x \[SLC Main\] | \- Implemented support for RS232 Port information. - Alarm monitoring and trending is now possible for all table parameters. - Tables now use naming to make the connector Cassandra-compliant. | 1.0.0.x      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 2.0.0.x   | 1.2 build 15041515     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |

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

### General

This page contains general information about the device, such as **System Contact**, **System Name**, and **System Locations**.

### Interfaces

This page contains a table with key information about the interfaces, such as **Type**, **Speed**, and **Operational Status**.

### Address Translations

This page contains a table with key information related to address translations, such as **Physical Address** and **Net Address**.

### TCP/IP/UDP/SNMP/ICMP Statistics

These pages contain various statistics related to TCP, IP, UDP, SNMP, and ICMP, respectively.

### RS232 (range 2.0.0.x)

This page contains information about the **RS232 Port** section of the device. The page has several page buttons that allow you to navigate to different subpages with information about **Async Port, Sync Port, Input Signal**, and **Output Signal.**
