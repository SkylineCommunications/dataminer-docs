---
uid: Connector_help_Bard_MC5000_Series
---

# Bard MC5000 Series

This connector is intended to integrate the functionalities of a Modbus device. It monitors the holding registers, input registers, and alarms.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | MCS5000.1.0.8          |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Connection - Main

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.
  - **Type of Port:** Default: TCP/IP

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector has the following data pages:

- **Holding Registers**: This is the default page. Here you can see and configure device set points. Click on a set point to view its value. You can then edit it and save changes as needed.
- **Input Registers**: This page shows read-only input registers of the device.
- **Alarms**: This page displays read-only discrete Inputs, allowing you to observe active alarms or device conditions.
