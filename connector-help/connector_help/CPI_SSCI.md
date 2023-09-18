---
uid: Connector_help_CPI_SSCI
---

# CPI SSCI

The CPI SSCI is a C-Band Solid State Power Amplifier (SSPA) designed for satellite communication earth stations, SNGs and flyaway applications.

## About

This connector uses a single **serial** connection, with a maximum response time of 200 ms.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 01.00.16                    |

## Installation and configuration

### Creation

#### Serial main connection

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
  - **Bus address**: The bus address of the device (ASCII value). (Default: A = 65)

## Usage

### General

This page displays general information about the device and some simple status parameters.

### Power Amplifier

This page contains parameters related to the power amplifier itself. The page contains several settings, and allows you among others to turn the **HPA**, **ALC** and **Mute on/off**.

### Alarms

This page displays the alarms and faults of the device.

### Calibration

This page displays **Attenuator** and **RF Calibration Settings**.

### Settings

This page contains all settings for alarms, faults, etc.

## DataMiner Connectivity Framework

The **1.0.0.1** connector range of the CPI SSCI protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

Fixed interfaces

Virtual fixed interfaces:

- **Input** and **Output** interfaces.

Connections

Internal Connections

- Between **Input** and **Output**, an internal connection is created with no properties.
