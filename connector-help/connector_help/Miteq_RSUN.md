---
uid: Connector_help_Miteq_RSUN
---

# Miteq RSUN

The Redundancy Switching Unit (RSU) monitors the status of up to eight on-line frequency
converters and the standby converter.

## About

Serial connector for the **Miteq RSUN** to totally control and monitor from a system controller over a remote communications bus.

All front panel controls and indications (except DC Voltage Monitor and Remote bus data format) are available to a controller over the remote bus.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device.
  - **Stopbits**: Stopbits specified in the manual of the device.
  - **Parity**: Parity specified in the manual of the device. (Possible values: even, odd)
  - **FlowControl**: FlowControl specified in the manual of the device.
- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device. (Range: 95 - 64)

## Usage

### General

The **General** page displays parameters such as:

- **PSU Status**
- **Control Mode**
- **Backup Converter Status** etc.

### Settings

The **RSU** page displays parameters for 8 converters such as:

- **Converter Status**
- **Converter Frequency**
- **Converter Gain** etc.
