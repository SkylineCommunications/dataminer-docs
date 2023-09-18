---
uid: Connector_help_CPI_VZU-6995VX
---

# CPI VZU-6995VX

The CPI VZU-6995VX is a 500 W TWT medium-power amplifier. This connector uses serial communication to communicate with this device.

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

#### Serial connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Bus address**: The bus address of the device.

### Initialization

No further configuration is required. If the connection has been correctly configured, the connector will start polling the device as soon as the element is created.

## How to Use

On the **General Control** page of this connector, you can change the date/time configuration and configure everything related to switches, such as **W/G Switch Controller** mode, **Preset** and the **Switch 1 to 4** positions.
