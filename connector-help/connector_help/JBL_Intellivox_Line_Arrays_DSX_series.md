---
uid: Connector_help_JBL_Intellivox_Line_Arrays_DSX_series
---

# JBL Intellivox Line Arrays DSX series

The JBL Intellivox DSX products are loudspeakers suited for highly reverberant spaces where improved speech intelligibility is required.

The protocol is used to monitor the status of the device. It reads the status information of the device and sets some parameters.

## About

The connector reads the device properties in bytes. The properties of the device are organized in pages. Each page contains 32 properties. Each property contains 1 byte of information. Each byte of information is mapped into the corresponding properties according to the mapping available in the WinControl Software help file.

The device is accessible through Moxa Terminal server by configuring the Moxa as TCP Server.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 4.40                        |

## Installation and configuration

### Creation

#### Serial connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: 19200
  - **Databits**: 8
  - **Stopbits**: 1
  - **Parity**: None
  - **FlowControl**: RTS/CTS

- Interface connection:

  - **IP address/host**: 10.218.128.200 (Moxa Terminal Server)
  - **IP port**: 4001
  - **Bus address**: Not required

## Usage

### General

The **General** page contains information related to the ID, address and firmware version of the device.

### Failure

The **Failure** page shows an overview of failure related information of the of the device. Detailed information of the cause for the general failure is found in the subsequent sub pages (**Communication**, **Loads**, **Amplifiers**, **DSP**). Individual communication, loads, amplifiers and DSP related failures are reported in the corresponding sub pages.

### Status

The **Status** page shows an overview of status related information of the of the device.

### Extra

The **Extra** page contains some extra status information of the device.

### Output Channel

The **Output Channel** page contains information related to the output channel mute status. The user can mute/unmute individual channels.

### Control Parameters

In the **Control Parameters** page, the **Volume**, **Ducking**, **Front LED**, **Autogain** and **Preset Index** parameters can be controlled. The values of these parameters are displayed and the user can change these values according to the need. The **Zones** sub page contains the zones that can be used to reduce the net overhead when issuing commands that write to a large number of units. The parameters are read/write and hence the user can change the zones.
