---
uid: Connector_help_Kronback_Tracers_B16
---

# Kronback Tracers B16

The Kronback Tracers B16 is capable of measuring up to 256 return path signals (5 - 65 MHz), and allows the spectrum to be viewed by an unlimited number of concurrent users. For small-sized headends, the B16 can be delivered with a buy-per-input license.

## About

This connector displays the spectrum analyzer UI for the Kronback Tracers B16.

### Version Info

| **Range** | **Description**                             | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                             | No                  | No                      |
| 1.0.1.x          | Several adjustments and added functionality | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.1.x          | Unknown                     |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device.
  - **Stopbits**: Stopbits specified in the manual of the device.
  - **Parity**: Parity specified in the manual of the device.
  - **FlowControl**: FlowControl specified in the manual of the device.
- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

## Usage

### Device Info

On this page, the parameter **SW Offset** can be used to specify a security level so that only users with a sufficiently high security level can set the spectrum parameters.

### Spectrum Analyzer

This page displays the spectrum trace according to the configured settings, i.e. the **Reference Level**, **Start Frequency**, **Stop Frequency**, **Frequency Span**, **Center Frequency**, **Input Attenuation** and **\# Trace Points**.
