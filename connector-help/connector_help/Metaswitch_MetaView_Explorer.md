---
uid: Connector_help_Metaswitch_MetaView_Explorer
---

# Metaswitch MetaView Explorer

The Metaswitch MetaView Explorer is a network management application that monitors a variety of Metaswitch components and products providing voice telephony services in a network. This connector retrieves specific MetaView Explorer statistics and displays all active alarms on the MetaView Explorer system based on incoming SNMP traps.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 5.0                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device. This value is disabled by default because no values are set on the device.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

- When the **SNMP Settings** are filled in, the connector is ready to poll the data from the device. No extra configuration is needed.
- It is possible to limit the size of the **Trap** table, by configuring the maximum number of rows or configuring the maximum age of the traps via **Alarms** \> **Trap Config**.
- The **Server Statistics** and **MetaSwitch Statistics Table** contain column headers indicating the **maximum** value for that column.
  All other tables containing column headers are configured to show the **sum** of the column values.
