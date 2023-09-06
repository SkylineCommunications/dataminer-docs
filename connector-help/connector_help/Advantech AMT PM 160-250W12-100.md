---
uid: Connector_help_Advantech_AMT_PM_160-250W12-100
---

# Advantech AMT PM 160-250W12-100

The Advantech AMT PM 160-250W12-100 connector is used for **single high-power SSPAs**, monitoring the status of one unit and providing control over the SSPA.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

- **Baudrate**: 9600 (specified in the device manual).
  - **Databits**: 8 (specified in the device manual).
  - **Stopbits**: 1 (specified in the device manual).
  - **Parity**: No (specified in the device manual).
  - **FlowControl**: No (specified in the device manual).

- Interface connection:

- **IP address/host**: The IP address of the device.
  - **IP port**: The IP port of the device.

### Initialization

No extra configuration is needed.

## How to use

The **General** page shows basic information about the control panel. Via the **Unit Port Config** page button, you can view information about the port configuration.

On the **SSPA Unit A and B** pages, you can find information about the SSPA Unit A and B such as the **Transmission Status**, **Transmission Power**, **Shutdown Status**, etc.
