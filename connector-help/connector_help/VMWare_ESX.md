---
uid: Connector_help_VMWare_ESX
---

# VMWare ESX

This connector can be used to monitor any VMWare ESX device. No device configuration is currently implemented.

The connector uses SNMPv1 to retrieve information from the device.

## About

### Version Info

| **Range**            | **Key Features**       | **Based on** | **System Impact** |
|----------------------|------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.       | \-           | \-                |
| 1.0.1.x \[SLC Main\] | DCF integration added. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | ESXi 6.x               |
| 1.0.1.x   | ESXi 6.x               |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*. This will currently have no impact, as no write parameters have been implemented.

## Usage

### General

This page contains general information about the device, such as the **Product Name**. It also displays information about the memory, the CPU number, and the host bus adapter installed on the device.

For more information about the different host bus adapters found in the system, click the **Adapter Info** page button.

### Interfaces

This page contains information about each of the interfaces of the device, such as the speed, description, input/output octets, input/output frames, MTU, and interface type.

### Virtual Machine Info

This page contains a list of all the virtual machines installed on the device, along with information about these VMs: **Configuration File**, **Memory Size**, etc.

### Host Bus Adapter Info

This page contains a list of the host bus adapters for all virtual machines listed on the Virtual Machine Info page.

### Virtual Disks Info

This page contains a list of the virtual disks for all virtual machines listed on the Virtual Machine Info page.

### Network Adapters Info

This page contains a list of the network adapters for all virtual machines listed on the Virtual Machine Info page.

### Floppy Drives Info

This page contains a list of the floppy drives for all virtual machines listed on the Virtual Machine Info page.

### DVD/CD-ROM Info

This page contains a list of the DVD or CD-ROM drives for all virtual machines listed on the Virtual Machine Info page.
