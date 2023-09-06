---
uid: Connector_help_SeaChange_Stagis
---

# SeaChange Stagis

This driver can be used for basic KPI monitoring for **SeaChange Stagis** devices:interfaces, storage, software and more generic info.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

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

This driver contains four main data pages to monitor Stagis devices:

- **General**: Displays general information about the server and the system. Contains the following page buttons:

- **Network Services**: Displays a table listing the service entries installed on the server.
  - **LAN Manager**: Displays detailed information such as **software versions**, **general counters of bytes sent/received**, **network I/O operations**, etc.
  - **Device Info**: Displays the **Memory Size**, the amount of physical read-write main memory and the **Processor Table**, which lists the processors contained by the host.

- **Interface**: Contains the Interface table, displaying detailed information on each interface entry, such as **MTU**, **I/O Bit Rates**, **Admin and Operational Status**, etc.

- **Storage**: Contains three tables with detailed data about **Logical Storage**, **Disk Storage** and the different **Disks Partitions**.

- **Software**: Contains two detailed tables with the **installed and running software** of the system.
