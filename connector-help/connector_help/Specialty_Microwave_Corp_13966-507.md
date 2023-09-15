---
uid: Connector_help_Specialty_Microwave_Corp_13966-507
---

# Specialty Microwave Corp 13966-507

The TLT RF Switching Panel, Part No. 13966-507 consists of a logic panel used in satellite communications earth stations. The TLT RF Switching Panel provides localindication and commands and using a serial interface provides remote indication and commands of four RF switches.

## About

The Specialty Microwave Corp connector allows for quick monitoring of front panel information and configuration of switch position.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | Yes                     |

### Product Info

| **Range**     | **Device Firmware Version** |
|----------------------|-----------------------------|
| 1.0.0.x \[SLC Main\] | 2.30                        |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device. The default value is 49, with a range of 33 to 126,

## Usage

### General

Here you can configure the **Switch Position.** Status parameters such as the **Power Supply Status 1** and **2**, **Local** **Indicator,** and **TLT Fail Status** are also displayed.
