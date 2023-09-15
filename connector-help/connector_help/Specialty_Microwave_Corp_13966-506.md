---
uid: Connector_help_Specialty_Microwave_Corp_13966-506
---

# Specialty Microwave Corp 13966-506

The TLT Coaxial Switching Panel, Part No. 13966-506 consists of a logic panel used in satellite communications earth stations. The TLT Coaxial Switching Panel provides local indication and commands and using a serial interface provides remote indication and commands of four coaxial switches.

## About

The Specialty Microwave Corp connector allows for quick monitoring of front panel information and configuration of switch position through the use of a serial connection.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | Yes                 | Yes                     |

### Product Info

| **Range**     | **Device Firmware Version** |
|----------------------|-----------------------------|
| 1.0.0.x \[SLC Main\] | Unknown                     |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600.*
  - **Databits**: Databits specified in the manual of the device, e.g. *7.*
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1.*
  - **Parity**: Parity specified in the manual of the device, e.g. *No.*
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No.*

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device. The default value is 49, with a range of 33 to 126.

## Usage

### General

Here you can configure the device's two **Switch Positions.** Status parameters such as the **Power Supply Status 1** and **2**, **Local** **Indicator,** and **TLT Fail Status** are also displayed.
