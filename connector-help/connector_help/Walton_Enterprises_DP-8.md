---
uid: Connector_help_Walton_Enterprises_DP-8
---

# Walton Enterprises DP-8

This driver is used to monitor and configure a **Walton Enterprises DP-8** device.

The DP-8 is a remote control unit that communicates with a Local Control Power Distribution Panel (DS-15) that can be deployed near an antenna.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.2                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  -**IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device. Range: 0-31.

## How to Use

This element created with this driver consists of the following data pages:

- **General**: Displays general information about the system, including the **Device Type** and **Revision Level.**
- **Advanced**: Displays more advanced information about both the DP-8 and the connected DS-15.
- **Heater Status**: Displays a table listing the heaters available on the device.
