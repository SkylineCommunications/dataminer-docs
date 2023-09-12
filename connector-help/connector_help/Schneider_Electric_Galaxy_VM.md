---
uid: Connector_help_Schneider_Electric_Galaxy_VM
---

# Schneider Electric Galaxy VM

The Schneider Electric Galaxy VM is a 3-phase **UPS** (Uninterruptible Power Supply) that integrates into the electrical, physical, and monitoring environments of data centers and industrial or facility applications.

This connector uses Modbus serial communication to retrieve information from the device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | UPS Firmware v4.8.0.4  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Connection - Main

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **Type of port**: TCP/IP.
- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device (configurable on the device).

## How to Use

This element consists of the following pages:

- **General**: Displays system information.
- **Battery**: Displays the battery status of the device.
- **Input**: Displays information and statuses for the input lines.
- **Output**: Displays information and statuses for the output lines.
- **Bypass**: Displays information and statuses for the bypass lines.
- **Alarms**: Displays the alarms captured by the device.
