---
uid: Connector_help_Specialty_Microwave_Corp_4360A-xxx
---

# Specialty Microwave Corp 4360A-xxx

This device is a 1:1 protection switch for HPA switching. It is a manual and automatic controller for a 1:1 high-power waveguide switching mechanism used in satellite communication earth stations.

## About

This connector use a serial connection to communicate with the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | --                          |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600.*
  - **Databits**: Databits specified in the manual of the device, e.g. *7.*
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1.*
  - **Parity**: Parity specified in the manual of the device*.*
  - **FlowControl**: FlowControl specified in the manual of the device*.*

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device. Default value: *49*. Range: *33* to *127*.

## Usage

### General

This page displays general device parameters, such as:

- **Switch** **Position**
- **Switch** **Mode**
- **Remote** **Mode**
- **Summary** **Fail** **1Status**
- **Summary** **Fail** **2Status**
- **Power** **Supply** **1** **Status**
- **Power Supply** **2** **Status**
