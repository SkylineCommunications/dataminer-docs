---
uid: Connector_help_CPI_KHPA_Gen_IV_Series
---

# CPI KHPA Gen IV Series

The CPI KHPA Gen IV connector uses a **serial** connection to communicate with the CPI KHPA Gen IV amplifier and monitor it.

This connector is designed to communicate with the KHPA device via a terminal server proxy (serial to Ethernet (IP) converter).

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Gen 4                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Connection

This connector uses a serial connection over TCP/IP and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The terminal server that the KHPA device is connected to, e.g. 10.10.11.1.
- **IP port**: The corresponding port on the terminal server configured to relay messages to the TMS4 device, e.g. 4003.
- **Bus address**: This field is used to specify the "Address Byte" configured on the KHPA device. The KHPA device supports values 48 to 111 (base 10) corresponding to a printable ASCII character (e.g. 53).

## How to Use

The element created with this connector will display data on the following pages:

### General

This page displays general status information about the device.

### System

This page displays all software versions of software components as well as the time value.

### Measurements/Inhibit

This page displays information related to the meter readings/measurements of the device (e.g. current, voltage, and other power information) and inhibit states.

### Trip Points

On this page, alarm/fault trip points can be set.

### Miscellaneous

This page contains a variety of configuration settings.

## Notes

This connector currently only supports the following:

- Printable ASCII as header and ending bytes. STX/ETX not yet supported.
- Checksum as check byte. Longitudinal parity not yet supported.

The parameter "RF Limits" does not represent the actual value because it is not possible to retrieve this from the device. The value is determined by the last RF Limits set command executed by a DataMiner user.
