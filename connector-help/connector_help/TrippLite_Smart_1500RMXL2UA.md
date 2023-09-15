---
uid: Connector_help_TrippLite_Smart_1500RMXL2UA
---

# TrippLite Smart 1500RMXL2UA

The TrippLite Smart UPS with LCD interface offers power protection for critical server, network, and telecommunications equipment. The UPS with built-in Auto-Voltage Regulation (AVR) actively corrects brownouts and overvoltages back to usable levels while maintaining a full battery charge in case of power failure.

This connector is a monitoring tool to check all relevant parameters of the device and take actions when necessary.

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
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Redundancy

There is no redundancy defined.

## How to use

This connector is intended for monitoring purposes. In each table, some parameters can be modified when necessary. For example, in the Devices Table, you can modify the name of a specific row, as well as its location, ID, or region, to it make easier to identify it.
