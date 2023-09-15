---
uid: Connector_help_iXsystems_FreeNAS
---

# iXsystems FreeNAS

With this connector, you can monitor FreeNAS platforms with SNMP.

## About

This connector uses **SNMP** in order to monitor a FreeNAS platform. FreeNAS is a network-attached storage (NAS) software based on FreeBSD and the OpenZFS file system.

FreeNAS provides a way to create a centralized and easily accessible place for your data, and can be used by both private individuals and small and large companies.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | FreeNAS-9.10.1              |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General Page

This page displays general information regarding the FreeNAS, such as **Device info**, **Total Processor Load**, **Memory usage**, etc.

### Task Manager

On this page, you can enable **Poll Task Manager** in order to retrieve all the data from the **Task Manager Table**.

To automatically clear inactive processes, enable **Auto Clear Task Manager**.

### Network Info

This page displays all interfaces and data rates.

### Memory Info

This page displays the memory info in the **Storage Table**.

The following page buttons are available:

- **Memory**: Displays additional memory information.

### Software Info

This page displays a list of all installed software.

### ZFS

This page displays general information regarding the ZFS file system.

### ZFS Pools

This page displays a list of all ZFS Pools in the system.

### ZFS Datasets

This page displays a list of all ZFS Datasets in the system.
