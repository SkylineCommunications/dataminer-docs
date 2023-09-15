---
uid: Connector_help_Walton_Enterprises_DP-9
---

# Walton Enterprises DP-9

The **DP-9** serial connector has been developed to provide a local point for control and monitoring of the DS-16 de-icing controller and attached de-icing system.

## About

This connector contains different pages with information about the device. More detailed information on these can be found in the **Usage** section of this document.

The connector uses the **serial** protocol to communicate with the device.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Revision 1.1                |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device, by default *18000*.
  - **Bus address**: Used to choose which output of the device is needed. For more information, refer to the **Notes** section below.

## Usage

### General

This page contains general information about the system. Here you can find the **Device Type** and the **Revision Levels.**

### Device Status

This page contains general information about the device status. Here you can for example find **M&C Rain Blower**, **Antenna Wet**, **Fuel Level**, **De-Ice**, ...

### Heater Status

This page contains general information about the heater status. There are 6 heaters available. Here you can for example find **Heater 1**, **Heater** **1: Fail**, **Heater 1: Call For Heat**, **Heater 1: Blower**, ...

## Notes

The bus address is used in order to choose which output of the device is needed. This ranges from 1 to 31. '1' being 31 Hex and '31' being 4F Hex.
