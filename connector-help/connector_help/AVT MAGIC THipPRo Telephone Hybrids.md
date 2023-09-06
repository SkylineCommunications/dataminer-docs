---
uid: Connector_help_AVT_MAGIC_THipPRo_Telephone_Hybrids
---

# AVT MAGIC THipPRo Telephone Hybrids

The MAGIC THipPro is an IP telephone hybrid system with 8 or 16 caller lines. With this connector, you can monitor and configure this system.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3.800                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** |
|-----------|---------------------|-------------------------|-----------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    |

## Configuration

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) version 2 connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## How to Use

On the **General** page, managed node information is displayed. There is also a page button to a subpage with the **System ORs** table.

On the **System** page, system information is displayed.

The connector also displays tables with information on the **LAN Interfaces**, **Control Interfaces,** and **AES/EBU Interfaces** pages, as well as **Alarms** and **Notifications** information tables.
