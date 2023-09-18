---
uid: Connector_help_Bry_Air_FFB_Series
---

# Bry Air FFB Series

**DEPRECATED**: Use model-specific connector instead.

Bry-Air FFB series dehumidifiers offer solutions to humidity control problems and can maintain RH as low as 1% or even lower at a constant level, regardless of ambient conditions.

This connector uses **MODBUS** communication to monitor the dehumidifiers.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | FFB-170-2000           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Modbus Communication

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600* (default: *19200*).
  - **Databits**: Databits specified in the manual of the device, e.g. *7* (default: *8*).
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1* (default: *2*).
  - **Parity**: Parity specified in the manual of the device, e.g. *No* (default: *no*).
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No*.

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.
  - **Bus address**: The bus address of the device (default: *1*).

### Initialization

No additional configuration of parameters is necessary in a newly created element.

### Redundancy

There is no redundancy defined.

## How to use

You can find all the information you need to monitor the device on the **General** data page.
