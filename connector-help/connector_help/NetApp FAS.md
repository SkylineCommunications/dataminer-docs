---
uid: Connector_help_NetApp_FAS
---

# NetApp FAS

NetApp Fabric-Attached Storage (FAS) can serve storage over a network using file-based protocols such as NFS, CIFS, FTP, TFTP and HTTP. NetApp Filers can also serve data over block-based protocols such as Fibre Channel (FC), Fibre Channel over Ethernet (FCoE) and iSCSI.NetApp Filers implement their physical storage in large disk arrays.

This driver allows you to monitor this device via SOAP calls. SNMP traps can also be retrieved if this is enabled on the device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 9.3                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default*161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## How to Use

This driver requests data from the device: network, system status, file system, RAID, storage, etc. SOAP calls are used to retrieve the device information. SNMP traps can be retrieved when this is enabled on the device. SNMP traps are implemented to update the status in the Interfaces table.

## Notes

The Logical Interfaces Table is polled using the bulk:10 method instead of multiplegetnext, because the group goes in timeout if multiplegetnext is used.
