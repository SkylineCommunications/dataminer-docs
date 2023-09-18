---
uid: Connector_help_Barrowa_Sundial
---

# Barrowa Sundial

The **Barrowa Sundial** is an EPG management system.

## About

This connector uses an SNMP connection to retrieve data from a **Barrowa Sundial** device.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 6.8.5                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## How to Use

The element created with this connector has the following data pages:

- **General**: Displays product and server information.
- **Cluster**: Displays the main and backup connection status and the **Region Connections** table.
- **Alarms**: Lists the current alarms in the **Alarms Table.** The **Alarms Counters** button open a new page listing the number of alarms for each type.
