---
uid: Connector_help_TDF_Jbus_PLC
---

# TDF Jbus PLC

The TDF Jbus PLC is a driver built for the TDF Short Wave project in order to interact with PLC devices.

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

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.
  - **Bus address**: The device bus address.

## How to use

The element created with this driver has the following data pages:

- **General**: Allows you to configure which device the element should poll, as well as other polling settings.
- **Device Data**: Displays a table with the data from the device. A subpage is available for the set commands.
