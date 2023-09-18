---
uid: Connector_help_Peak_Communications_PTR50
---

# Peak Communications PTR50

The PTR50 is an L-band Tracking Receiver designed by Peak Communications. The PTR50 has been designed specifically to track and measure CW beacons from commercial satellites.

## About

This connector uses **SNMP** commands to get information from or set information to the device.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.25                        |

## Installation and configuration

### Creation

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: (Not used)

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General

On this page, you can find:

- Device information, including: **Unit Type**, **Serial Number**, **Software Version**, **Unit Online** and **Unit External Ref**.
- General alarm information: **Summary Alarm**, **Faults Module Type**, **Faults Type**, **Summary Fault** and **OK Since**.
- A **Unit Reset** button to reset the device.

Trending is possible for the following parameters: **Faults Type, Summary Alarm, Summary Fault, Unit External Ref, Unit Online.**

### Unit

On this page all the Unit parameters are available. Most of them are configurable, including: **Local/Remote**, **Center Frequency**, **Span**, **Reference Level**, **Bandwidth Resolution**, **Pad 10 dB**, **Frequency** and **Gain**.

Some other parameters that can be configured are: **Sweep Rate**, **Sweep Width**, **Log dB/Volts**, **Log Offset** and **ASB**.

**DC Output** and **Rx Level** are not configurable. They are displayed as analog LED bars.

Trending is possible for all parameters.

### Channels

On this page, the **UPC CTable** is available. In this table, you can see and configure the parameters for the different UPCs. Important parameters to configure are **Upc CType**, **Upc Cmode**, **Upc CComp Ratio** and **Upc COffset**.

### UPC

This page provides access to all the UPC parameters and their configuration. Some of the important available parameters are **Upc Clear Sky Calibrated**, **Upc Mode**, **Upc Clear Sky Beacon Level** and **Sampled Beacon Level**, **Upc Step Size** and **UPC Slew Rate**, **Upc Sample Period**, etc.

In addition, the **Channel State**, **Channel Number**, **Channel Mode**, **Channel Attenuation** and **Channel Comp Range** are also available.

Trending is possible for all parameters except the following: **Channel State**, **Channel Mode**, **Upc Sample Period** and **Upc OKSince**.

### Redundancy

On this page, you can configure the device redundancy. The parameters **Online Status** and **Coax Switch Position** are available. Among the other configurable parameters are **Type** (with possible values *1:1*, *1:2* and *1:N*), **Mode**, **Identifier**, **Priority**, **Online Unit** and **System Number**.

Trending is only possible for the parameter **System Number**.

### Network

On this page, all communication configuration can be done.

The following parameters are available: SNMP **Trap Address**, TCP/IP **Port Number** and **Socket TimeOut** and Ethernet **DHCP**, **IPv4 Address**, **Subnet Mask**, **Gateway** and **Update Settings**.
