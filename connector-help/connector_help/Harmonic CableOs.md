---
uid: Connector_help_Harmonic_CableOs
---

# Harmonic CableOs

**Harmonic CableOs** is a distributed CMTS system that splits the processing from the RF capabilities. This connector monitors the different interfaces, mainly upstream and downstream channels.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                      | **Based on** | **System Impact** |
|----------------------|---------------------------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Upstream and downstream channels monitoring.                                                                                          | \-           | \-                |
| 1.0.1.x              | Every bitrate shown as Mbps.New pages added (RF Port, RPD, Out of Band, Video Channels, Memory), and new tables added on those pages. | 1.0.0.5      | \-                |
| 1.0.2.x \[SLC Main\] | Parameter and layout adaptation.                                                                                                      | 1.0.0.5      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.8.12.0-1             |
| 1.0.1.x   | 1.8.12.0-1             |
| 1.0.2.x   | 1.8.12.0-1             |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |

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

## How to use

It is possible to configure several parameters in the connector, such as the **Interface Alias**, **Admin Status**,and **Upstream/Downstream frequency values** (MHz).

The connector also provides extra information for the **Downstream Channels**, including **Interface Utilization**, **CM Total**, **CM Online**, **CM Registered**,and **CM Offline**. This last parameter is calculated by subtracting the **CM Online** from the **CM Total**.

For the **Upstream Channels**, the table displays the same information as for the **Downstream Channels**, with in addition the **Signal Noise Ratio**.

At the top of some of the columns of the tables, a value is displayed. For most columns, this is the sum of the row values, except for the Signal Noise Ratio column, where it is the average.

The **1.0.1.x** range also shows information about **RF Ports, RPD, Out of Band, Video Channels, CPU**,and **Memory**.

- The Out of Band page contains two tables: **OBB NDF Configuration** and **OBB NDR Configuration**.
- The CPU page contains the **CPU Utilization Status Table** and a page button that leads to the **CPU Total Table**.
