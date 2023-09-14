---
uid: Connector_help_Miteq_DN1_Translators
---

# Miteq DN1 Translators

The **Miteq DN1 Translators** equipment is designed for satellite communication applications where frequency translation is needed with a minimum of amplitude and group delay distortion.

## About

The connector retrieves data via **serial communication TCP/IP** and monitors the Miteq DN1 Translators device.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | D163995V2.066.25            |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device: *19200.*
  - **Databits**: Databits specified in the manual of the device: *8*.
  - **Stopbits**: Stopbits specified in the manual of the device: *1*.
  - **Parity**: Parity specified in the manual of the device: *No*.
  - **FlowControl**: FlowControl specified in the manual of the device: *No*.

- Interface connection:

  - **IP address/host**: The polling IP of the device: *10.80.120.50*.
  - **IP port**: The IP port of the device. Default value: *4006*.
  - **Bus address**: The bus address of the device. Range: *64 - 95*.

## Usage

The connector contains 5 pages.

### General

This page displays device-specific parameters, such as **Firmware version**, **Calendar/Clock**, **Device Name,** **Mute/Unmute, Voltage, Remote Access, Mute Indicator** and **Temperature**.

### Status and System

This page displays the system status, with amongst others the following parameters: **Local Oscillator** **Frequency**, **Input/Output Frequency Indicator** and **Input/Output Frequency Range**. The configuration of the different units is displayed: **Unit Event Log**, **Unit Attenuation, Unit Frequency Configuration** and **Unit Alarm.**

### Logger

On this page, the table with the followings columns/parameters represents the Unit Event Log: **Index**, **Entry** **Queried**, **Event Desciption** and **Date/Time.**

If the entry 00 is queried, the unit returns the number of log entries currently in the log. Otherwise, the unit responds with the date, time and a code indicating the event which has occurred.

### Memory Register

This page displays the **Memory Register Table**, which contains the following columns: **Memory ID**, **Band**, **Frequency**, **Attenuation** and **IF**.

The query command requires the memory register to recall and return the contents of that register. The set command stores band or frequency and attenuation into a selected memory register. A fourth parameter for IF frequency may be added as well.

### Network Configuration

This page displays a number of configurable parameters, **Ethernet IPv4 address**, **Ethernet IPv4 Gateway address, Ethernet IPv4 Subnet Address**, as well as the **Addressing Mode**, which can be *Static* or *Dynamic IP*.
