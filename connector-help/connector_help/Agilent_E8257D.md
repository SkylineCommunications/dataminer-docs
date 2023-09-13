---
uid: Connector_help_Agilent_E8257D
---

# Agilent E8257D

This connector is designed to configure an Agilent E8257D signal generator. It allows you to configure the frequency and output power of the generated signal.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Firmware C.04.56       |

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

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

This connector consists of the following pages:

- **General**: Displays general information about the device, such as the **Firmware** **Version**, **Model**, etc.
- **Frequency**: Displays all the available frequency parameters.
- **Power**: Displays all the available power parameters.
- **Errors**: Displays a table listing the errors that occurred on the device.
