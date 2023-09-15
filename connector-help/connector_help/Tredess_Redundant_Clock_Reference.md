---
uid: Connector_help_Tredess_Redundant_Clock_Reference
---

# Tredess Redundant Clock Reference

The Tredess redundant clock reference provides high-stability frequency and time reference signals. This unit manages, integrated into the same chassis, two synchronization modules with a built-in OCXO and GNSS receiver with 1+1 redundancy.

The Tredess redundant clock reference connector shows status information of the device and can be used to configure the device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 01.V01                 |

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

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

## How to use

On the **General** page of this connector, you can configure the datetime settings and view the control board temperature.

The pages **Network Interfaces**, **SNMP Settings**, **SNMP Traps**, **I/O Interface**, **Event Configuration**, **Device Info**, **PTP Master** and **Power Supply** all contain information about the device.

The pages **Synchronization Modules**, **PTP Slaves**, **OCXO**, **GNSS Receivers**, **GNSS Antenna Jamming**, **Constellations**, **Satellites** and **Satellites Details** all contain information about the synchronization modules.

The **Switching** page allows you to configure the settings for switching between the two synchronization modules.

The **Status** page contains a list of alarms used by the device itself.
