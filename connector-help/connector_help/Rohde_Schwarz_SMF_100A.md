---
uid: Connector_help_Rohde_Schwarz_SMF_100A
---

# Rohde Schwarz SMF 100A

This connector is designed to configure a Rohde Schwarz SMF 100A signal generator.

The frequency and output power of the generated signal can be configured using this connector.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**        |
|-----------|-------------------------------|
| 1.0.0.x   | Firmware 3.0.12.3-2.20.232.16 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device. Default: *5025.*

## How to Use

The element created with this connector has the following data pages:

- **General**: Displays general information about the device, such as the **Firmware** **Version**, **Model**, etc.
- **Frequency**: Displays all the available frequency parameters.
- **Power**: Displays all the available power parameters.
- **Errors**: Displays a table listing the errors that occurred on the device.
