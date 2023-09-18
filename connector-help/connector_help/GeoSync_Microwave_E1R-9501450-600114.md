---
uid: Connector_help_GeoSync_Microwave_E1R-9501450-600114
---

# GeoSync Microwave E1R-9501450-600114

This amplitude/slope equalizer system offers independent gain and slope adjustment in the L-band frequencies. This system is designed to compensate for long cable run loss and to provide system redundancy. The 1:1 redundant system provides automatic and manual switchover modes of operation.

## About

This **serial** connector is used to monitor and configure the **GeoSync Microwave E1R-9501450-600114** L-band conditioner.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | REV1.01B 6/18/12            |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device, by default *64*. Range: *95 - 64*.

## Usage

### General

This page contains system info parameters such as **Model Number**, **Serial Number** and **Software Version**. It also displays system alarms that can be triggered by the **Primary Unit** or the **Backup Unit**, as well as the selected **Switch Mode** (*Manual/Automatic*) and both the **Primary and Backup Unit Status** (*Online/Standby*).

### Primary

This page contains parameters specific to the primary unit, including its **Attenuation** (dB) and **Slope** (0-6 dB range) when the unit is either online or in standby, **Low and High Current** (A) **Limits** and **Power Supply Voltage** for both the +6 V (4.5 - 7.5 V range) and the +12 V (10.5 - 13.5 V range).

### Backup

This page contains parameters specific to the backup unit, including its **Attenuation** (dB) and **Slope** (0-6 dB range) when the unit is either online or in standby, **Low and High Current** (A) **Limits** and **Power Supply Voltage** for both the +6 V (4.5 - 7.5 V range) and the +12 V (10.5 - 13.5 V range).

### Misc

This page contains a variety of parameters, including:

- **Control**: Shows whether the device is in *Local* or *Remote* mode.
- **Switch Mode**: Allows you to toggle between *Manual* or *Automatic* mode.
- **Status**: Signals whether the primary unit is online and the backup unit is in standby or vice versa, and allows you to switch between these states.
- System alarms, such as the **Primary and Backup Unit Alarm**, **Transfer Switch Alarm**, and both the **Primary and Backup Power Supply Alarm**.
- **Date/Time**: Displayed at the bottom of the page. Can only be modified by users who have at least security level 3.

### Log

This page contains the log info table. You can have this table filled in by clicking the **Get Logs** button. A progress bar will then show the status of the process. The table displays the **Log Entry**, **Date/Time**, **Event Code** and **Event Code Description**.

### Settings

This page contains non-configurable serial communication parameters such as **Bus Address** (*64 - 95* range), **Baud Rate** (with *1200*, *2400*, *9600*, *14400*, *19200* and *38400* as possible values), **Parity Bit** (with *None*, *Odd* and *Even* as possible values), **Bus Format** (with *RS485 2-wire* and *RS422 4-wire* as possible values). It also contains Ethernet communication parameters such as **IP Address**, **Gateway Address**, and **Subnet Address**.

### Webpage

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Revision History

DATE VERSION AUTHOR COMMENTS
30/04/2018 1.0.0.1 RBL, Skyline Initial version
