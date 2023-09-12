---
uid: Connector_help_Evertz_7881IRD2-ATSC
---

# Evertz 7881IRD2-ATSC

This connector allows you to manage the Evertz 7881IRD2-ATSC card. It communicates using SNMP and has filter polling per card using subtables.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

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
- **IP port**: The IP port of the destination, by default *161*.
- **Device Address:** The slot number of the card in the frame.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Important Note

Full functionality of this connector, with frame status parameters such as temperature and power supply, also requires the Evertz 7X00 Frame Controller connector.

## How to use

The element consists of the following pages:

- **General**: This page consists of parameters such as **Card Type**, **Product Features**, **Alias**, and **Proxy Mode**.
- **Setup**: This page consists of various tables and parameters, including the **Data Port** and **Product Features Supported** tables, the **Product** **Serial Number**, and the **License File** configurable parameter.
- **Input**: This page contains the **RF Tune** table as well as various input-related configurable parameters.
- **TS** **Path**: This page contains the **ASI Configuration**/**TS Input Mapping and Status** tables.
- **TS** **Output** **and** **Filter** **Control**: This page contains various tables including **TS Output Status**, **IP Output Control**, and **SDL Data Control.**
- **Decode**: This page contains the **Decoder**, **Decoder** **Audio**, **Continuity Counter Errors**, and **Video Monitor** tables.
- **Video**: This page contains the **Video Data Control** and **Video Data Monitor** tables.
- **Audio**: This page contains audio related tables including **Audio Decode**, **Audio Mapping**, and **Audio Monitor.**
- **Alarms**: This page contains alarms tables: **Decoder Alarms**, **Continuity Counter Alarms**, and **Demodulator Alarms.**
- **Traps**: This page contains the **Traps** table and trap-related configurable parameters.
