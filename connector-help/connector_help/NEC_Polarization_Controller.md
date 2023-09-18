---
uid: Connector_help_NEC_Polarization_Controller
---

# NEC Polarization Controller

## About

A polarization controller comprises many devices connected in series to each other. Each device includes an optical channel waveguide which is common to the all the devices, and an electrode positioned on the optical channel waveguide and two electrodes positioned on both sides of the optical channel waveguide. These elements control the polarization of the light being sent through the optical media.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | True                    |

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
  - **Baudrate**: Baudrate specified in the manual of the device (default 9600).
  - **Databits**: Databits specified in the manual of the device. (default: 8)
  - **Stopbits**: Stopbits specified in the manual of the device. (default: 1)
  - **Parity**: Parity specified in the manual of the device. (default: even)
  - **FlowControl**: FlowControl specified in the manual of the device. (default: no)
- Interface connection (used only if the connection to the device is made through an IP to Serial converters):
  - **IP address/host**: The polling IP of the converter.
  - **IP port**: The IP port of the converter.

## Usage

### General

This page contains all the information. Here you can find information about the current **state** of the connector, the **polarization angle**, if there are **alarms**, and also information about the **control mode**.

This device does not have a web interface.
