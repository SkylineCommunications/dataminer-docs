---
uid: Connector_help_Apple_OSX_Platform
---

# Apple OSX Platform

With this connector, it is possible to monitor Apple OSX platforms with **SNMP**.

## About

The Apple OSX Platform connector retrieves basic information about the system.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays general system information.

### System Stats

This page contains information related to **CPU** usage and available **Memory**.

### Disk Information

This page displays different tables that have information related to the **Disk**, such as **Disk Storage**, **Partition** and **Disk IO**.

### Interfaces

This page contains a table listing the available **Interfaces** of the device, which displays information such as the **Description, Alias, Tx and Rx Bit Rate, Sent Data, Received Data** and **Bandwidth**.

### Processes

This page displays a list of the processes running on the Apple OSX platform that are configured via the snmpd.conf file. The **Extensible Commands** and **Load Average** tables are also available on this page.

### Software

This page contains information related to the **Installed** and the **Running Software**.

### Storage

This page contains the **Storage** table, which displays the **Logical Storage Areas** of the platform. The following information is included in this table: **Type, Description, Allocation Units, Size, Amount Used** and **Allocation Failures**.

The **File System** table is also available on this page.
