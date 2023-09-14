---
uid: Connector_help_Apac_UG40
---

# Apac UG40

## About

This protocol has been made for an air conditioning Apac Airco UG40. The protocol implements a serial communications with the devices.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial Version | No                  | False                   |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: \[The IP port of the device.\]
  - **Bus address**: \[The bus address of the device. Default value is 01.01 and the range is from 0 to 256\]

## Usage

### Digital Variables (Coils)

On this page is displayed the device digital information, such as, System Fan State, Compressor State, Dehumidification State, etc.

### Analog Variables (Holding or Input Registers)

On this page is displayed the device analog information, such as, Temperature, Humidity, Pressure, etc.

### Integer Variables (Holding or Input Registers)

In this page is displayed the device configuration and state, such as, Device Run Hours, Electronic Valve Position, Number of LAN Units, High Humidification Alarm Threshold, etc.

Revision History

