---
uid: Connector_help_Xicom_Technology_XTC-114_VPC
---

# Xicom Technology XTC-114 VPC

This connector allows you to monitor Xicom's high power amplifier model XTC-114. These amplifiers are typically used in antennas for satellite communication. The connector displays information on the unit itself, the status of its main systems, and a basic VPC configuration.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1                      |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device (default: *9600*).
  - **Databits**: Databits specified in the manual of the device (default: *8*).
  - **Stopbits**: Stopbits specified in the manual of the device (default: *1*).
  - **Parity**: Parity specified in the manual of the device (default: *No*).
  - **FlowControl**: FlowControl specified in the manual of the device.
- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

## How to use

The element consists of the following data pages:

- **General**: Displays general information about the device, including its model number, firmware version and firmware revision level.
- **Status**: Displays the status of the HPAs, PSUs, amplifiers and other smaller elements.
- **VPC**: Contains the controls for the Variable Position Combined element of the system.
