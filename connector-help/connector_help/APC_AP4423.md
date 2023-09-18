---
uid: Connector_help_APC_AP4423
---

# APC AP4423

The APC AP4423 is a rack-mount automatic transfer switch. This connector allows you to monitor and configure this device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 4.1.9                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector retrieves information from the device via SNMP. When you create an element, specify the following information:

SNMP Connection:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string needed to read from the device. The default value is *public*.
- **Set community string**: The community string needed to set to the device. The default value is *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the following data pages:

- **Overview**: Contains general information such as the load status, software version, serial number, etc.
- **ATS Status**: Displays status information for the automatic transfer switch, such as the communication status and the selected source.
- **Configuration**: Allows you to configure device settings such as the Voltage Sensitivity, Current Limit, Preferred Source and Front Panel Lockout.
- **Input/Output Status**: Displays the input sources and output banks with their load.
- **Calibration**: Displays the input phase calibration factor and the power supply calibration factors.
