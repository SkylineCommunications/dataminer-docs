---
uid: Connector_help_CPI_KHPA_Gen_III_Series
---

# CPI KHPA Gen III Series

This connector uses a **serial** connection to communicate with and monitor the CPI KHPA Gen III amplifier.

The connector is designed to communicate with the KHPA device via a terminal server proxy (serial-to-Ethernet (IP) converter).

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Gen 3                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Connection

This connector uses a serial connection over TCP/IP and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The IP or hostname of the terminal server that the KHPA device is connected to, e.g. 10.10.11.1.
- **IP port**: The corresponding IP port on the terminal server configured to relay messages to the TMS4 device, e.g. 4003.
- **Bus address**: This field is used to specify the "Address Byte" configured on the KHPA device. The KHPA device supports values 48 through to 111 (base 10), corresponding to a printable-ASCII character (e.g. 53).

## How to Use

The element has the following data pages:

- **General**: Displays status information for the device.
- **Faults**: Displays alarms/faults present on the device.
- **Measurements**: Displays information related to the meter readings/measurements of the device (e.g. current, voltage, and other power information).

## Notes

This connector currently only supports:

- Printable ASCII as header and ending bytes. STX/ETX are not yet supported.
- Checksum as check byte. Longitudinal parity is not yet supported.
- A limited selection of query commands. Slow commands, KHPA commands, and interface commands are not yet supported
