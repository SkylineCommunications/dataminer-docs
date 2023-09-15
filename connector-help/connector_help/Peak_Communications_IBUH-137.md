---
uid: Connector_help_Peak_Communications_IBUH-137
---

# Peak Communications IBUH-137

The IBUH-137 belongs to a series of upconverters. It is a high-grade unit that can be applied to many situations where good stability and phase noise are required, designed to operate in a static 19-inch rack system.

This connector can be used to display and set information when this device is configured to remote mode. The connector uses serial commands to retrieve the data from the Peak Communications IBUH-137 controller every 10 seconds.

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
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600.*
  - **Databits**: Databits specified in the manual of the device, e.g. *7.*
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1.*
  - **Parity**: Parity specified in the manual of the device, e.g. *No.*
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No*.

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device (*1 - 255*). For this particular device, the documentation indicates the value *32*.

## How to use

The element has the following data pages:

- **General**: Displays general information about the unit and a summary alarm status.
- **Status**: Displays a more detailed status overview.
- **Redundancy**: Displays the redundancy parameters.
