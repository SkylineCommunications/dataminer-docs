---
uid: Connector_help_Specialty_Microwave_Corp_13056-501
---

# Specialty Microwave Corp 13056-501

**HPA 1:2 Protection Switch**

The 1:2 Protection Switch, Part No. 13056-501 consists of a logic panel used in satellite communications earth stations.

## About

The system mechanism operates waveguide and coaxial switches to operator desired positions on assembly 13056-101. The mechanisms provide switching and combining operations for the radio frequency (RF) outputs of high power amplifiers (HPA) in an automatic (unattended) or manual (local and or remote) mode.

The 1000-600 Series of Serial to Digital I/O Interface Boards (SIB) provides three serial interfaces. The first Serial Communication Interface (SCI0) is jumper selectable for RS-232C, RS-422 or RS-485 selectable while the second Serial Communication Interface (SCI1) is only RS-422 or RS-485.

The third serial interface is a virtual Serial Communications Interface (SCI2) delivered over TCP/IP using the embedded RJ-45 Ethernet Interface.

Up to 6 virtual SCI2 connections can be established simultaneously.

SCI0 and SCI2 control and read 8 to 256 user selectable input and output positions and allow for the management of all user configurable settings.

SCI1 can be configured for a pass-through connection allowing multiple SIBs to be connected in a daisy-chain manner, a connection to an HPA or a Mirror control link to another SIB.

At power-up the unit configures itself for serial protocol, byte width, input/output assignment and initial output levels.

The Ethernet port is configured with the necessary IP addresses and net masks as defined by the user, and if a Mirror control link is defined, SCI1 attempts to establish communications with its connected SIB .

These items are stored in nonvolatile EEPROM memory, which can be configured by the user.

The unit can communicate over SCI0 or 1 operating between 300 and 19200 baud, and over the Ethernet interface at 10 or 100 Mbps and either Half or Full Duplex.

| **Version** | **Description** |
|-------------|-----------------|
| 1.0.0.1     | Initial Version |

## Installation and configuration

### Creation

This connector uses a **Serial Protocol** connection and needs following user information:

### Serial Connection:

\- Type of Port: TCP/IP

\- IP address/host: the polling IP of the device, e.g. 10.11.12.13

\- IP Port: The port designated to be used on serial communication

\- Bus address: A value between 0x21 (33) to 0x7F (127)

## Usage

### Device Information

The **Device Information** displays the device identification as:

> \- firmware version,
>
> \- management of front panel customer configuration data options,
>
> \- management of parallel interface data,
>
> \- management of actual state of pins as initial value,
>
> \- management of the mask into the EEPROM to apply or ignore bit(s) in command responses by the Upstream Mirror SIB,
>
> \- management of the mask that determines which bits are assigned as input or output,
>
> \- IP Link Statistics
>
> \- Internal Control Commands as stop or initiate monitoring of front panel, status poll, remote reset, save and read EEPROM from flash and restart Ethernet without boot.

### SCI Information

The **SCI Information** displays the relative information relative to SCI0, SCI1 and SCI2 serial interfaces.

### Bit Change Output Operations

The **Bit Change Output Operations** displays the relative information about operations to modify the communication data:

\- Change Bit High / Low by giving position,

\- Establish Pulse Width,

\- Pulse Bit Operations to change a single output bit data on transitions of hi-lo-hi or lo-hi-lo,

\- Pulse Bit Operations to change 16 bit data on transitions hi-lo-hi or lo-hi-lo,

\- Pulse Bit Operation to change all the bits on transitions hi-lo-hi or lo-hi-lo.
