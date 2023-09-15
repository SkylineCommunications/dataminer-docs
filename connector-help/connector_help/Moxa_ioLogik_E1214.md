---
uid: Connector_help_Moxa_ioLogik_E1214
---

# Moxa ioLogik E1214

This connector allows you to monitor a configured Moxa ioLogik E1214 device via SNMP. It displays basic information about the device, as well as the status of the existing DI and DO channels. For each DI/DO channel, some settings can also be configured

## About

### Version Info

| **Range** | **Key Features**                 | **Based on** | **System Impact** |
|-----------|----------------------------------|--------------|-------------------|
| 1.0.0.x   | Monitoring of DI and DO channels | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | v3.0                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### General Page

This page displays **system information**: the total number of channels, server model, system uptime and firmware version.

### I/O Status Page

On this page, you can find the **DI channel monitor table** and **DO channel monitor table**. These tables allow you to monitor all available DI channels and DO channels. For the DI channels, you can also configure parameters for each channel such as mode, filter, trigger and counter. For the DO channels, you can configure parameters such as type, status, signal pulse ON width, signal pulse OFF width and signal pulse start/stop.

Both tables allow you configure a custom name for each channel. Greyed out entries in the tables are disabled and cannot be set.
