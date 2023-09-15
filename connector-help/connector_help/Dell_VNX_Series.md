---
uid: Connector_help_Dell_VNX_Series
---

# Dell VNX Series

The **Dell VNX Series** connector is used to retrieve information from the Dell VNX disk management system. The connector communicates with the Dell VNX using the Navisphere command line interface.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Agent Revision: 7.33.9 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

The connector communicates with the server using the Navisphere command line interface. For this purpose, the Navisphere executable must be present on the DMA running the connector.

On the **General** page, the absolute path to the executable must be specified in the **NaviSECCli Executable** parameter. On this same page, the **IP Address**, **User** and **Password** for the device must also be filled in.

## How to use

The element created with this connector consists of the data pages detailed below.

### General

This page contains the configuration parameters of the device (see "Initialization" section above). It also displays device information (**Serial Number**, **Model**, etc.).

The **Statistics** button enables or disables the computation of statistics by the device. If this is disabled, some columns in the **Disks** table will not be filled in. As enabling statistics can have a performance impact on the system, this is disabled by default.

### Storage

This page displays information about the disk management: **Raid Groups,** **Logical Units**, etc.

### Disks

The Disks table displays information about all the disks in the system. Statistics related to the disks are also displayed: **Idle Time**, **Busy Time**, **Reads Count**, **Writes Count**, etc. These statistics will only be filled in if the **Statistics** parameter on the **General** page is set to *Enabled*.
