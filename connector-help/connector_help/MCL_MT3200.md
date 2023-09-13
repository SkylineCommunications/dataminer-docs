---
uid: Connector_help_MCL_MT3200
---

# MCL MT3200

The **MT3200** is a medium power satellite amplifier designed for both mobile and earth station based applications.

The **MCL MT3200** driver is used to monitor MT3200 devices that use the CSP protocol.

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
  - **Bus address**: The bus address of the device.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

This driver consists of just one data page, where you can find information on the device and adjust several settings. Page buttons on this page open subpages with additional information and settings.
