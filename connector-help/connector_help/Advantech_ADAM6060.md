---
uid: Connector_help_Advantech_ADAM6060
---

# Advantech ADAM6060

This device can monitor and control 6 digital inputs and 6 digital outputs through a serial TCP/IP connection.

## About

This connector displays information on the 6 digital inputs and 6 digital outputs. The information is requested using the Modbus protocol.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.1.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.1.0.x          | Unknown                     |

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
  - **Bus address**: The bus address of the device. (Default: *false*)

## Usage

### Main View

This page displays the following information for the 6 **inputs** and 6 **outputs**: **Real state**, **User value** and **Inversion mode**.

### General

This page provides the same information as the Main View page, but also allows you to edit the **User value** for outputs and the **Inversion mode** for both inputs and outputs.
