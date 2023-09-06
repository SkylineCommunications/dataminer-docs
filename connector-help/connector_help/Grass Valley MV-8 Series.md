---
uid: Connector_help_Grass_Valley_MV-8_Series
---

# Grass Valley MV-8 Series

The MV-8 Series Core Multiviewer is the core multiviewer "engine" within the Grass Valley MV-8x0/8x1/825 Multiviewer product range. Various video input and video wall output signal types are supported by the product range.

This connector displays information regarding the alarms present in the multiviewer.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *161*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Redundancy

There is no redundancy defined.

## How to use

On the **General** page, you can find information about the multiviewer.

The **Alarms** page displays information about the **Temperature**, **PSU**,and **Fan** **Alarms**.

The **Input Alarms** page contains information about the input alarms, and the **Wall Layout** page shows information about the wall layout.
