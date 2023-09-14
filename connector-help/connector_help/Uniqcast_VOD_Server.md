---
uid: Connector_help_Uniqcast_VOD_Server
---

# Uniqcast VOD Server

With this connector, you can monitor a Video-on-Demand (VOD) server solution from Uniqcast.

## About

This connector uses **SNMP** in order to monitor a VOD server.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | MIB Version v1.1            |

## Installation and creation

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General Page

This page displays general system information.

Note that the **Total Processor Load** is only available if **Poll Task Manager** is enabled (on the Task Manager page).

### VOD Info

This page displays general information about the VOD server.

### Task Manager

On this page, you can enable **Poll Task Manager** in order to retrieve all the data from the **Task Manager Table**. This table displays all the processes running on the Linux OS hosting the cluster suite.

### Network Info

This page displays all interfaces and data metrics.

### Memory Info

This page displays the memory info from the Linux OS hosting the cluster suite. This information is displayed in the **Storage Table**.

### Devices Info

This page displays a list of all devices contained in the cluster.

The following page buttons are available:

- **Disk IO**: Displays disk IO information.
- **File System**: Displays file system information.
- **Partitions**: Displays partition information.
- **Processor Load**: Displays information about processor load.

### HP

This page displays general **HP server**-related information.

The following page buttons allow access to additional **HP** info:

- **Fan**
- **Power Supply**
- **Temperature**
- **Memory**
- **CPU**
- **Disk**
