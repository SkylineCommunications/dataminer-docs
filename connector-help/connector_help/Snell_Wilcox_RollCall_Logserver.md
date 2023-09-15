---
uid: Connector_help_Snell_Wilcox_RollCall_Logserver
---

# Snell Wilcox RollCall Logserver

This connector will collect and parse logs, filling in a table with the parameters found in those logs.

## About

This is a **smart-serial** connector, which will receive log entries from a log server. The connector will parse those logs, creating DVEs for each different device referred to in the log entries.

This connector will export different connectors based on the retrieved data. Refer to the section "Exported connectors" below for more information.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Not available.              |

### Exported connectors

| **Exported Connector**                                                                                                | **Description**                               |
|----------------------------------------------------------------------------------------------------------------------|-----------------------------------------------|
| [Snell Wilcox RollCall Logserver - Element](xref:Connector_help_Snell_Wilcox_RollCall_Logserver_-_Element) | Represents a device monitored by this connector. |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.

## Usage

### General Page

This page contains a table listing the devices. Whenever a log referring to a new device is received, a new entry will be added.

You can remove an entry by clicking the **Remove** button or by selecting the entry, right-clicking and selecting **Delete Selected DVE(s)** in the context menu.

### Devices Page

This page displays the available devices, as well as their slots and parameters. You can also manage the DVEs on this page.

### Configuration Page

On this page, you can configure the units present in the log entries. The connector will then search for these, and if they are present, the corresponding parameters will have the configured units.

It is also possible to discard parameters from the log entries. To improve performance, it is advised to discard unused parameters in large systems. Discarding the "TIME" parameter, for example, can result in a large performance increase.

## Note

Be careful when enabling this connector on elements for large log servers: this could cause a large number of messages to be sent to DataMiner (especially during element startup; this can even go up to over half a million messages).
This can lead to increased memory usage and slow behavior of the DataMiner system. A correct configuration of the **Parameters to Discard Table** is essential to avoid this.
