---
uid: Connector_help_FOR-A_FRC-8000
---

# FOR-A FRC-8000

This connector is used to monitor a FOR-A FRC-8000 frame rate converter.

## About

The connector uses an **SNMP connection** to communicate with a FOR-A FRC-8000 device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.42                        |

## Installation and configuration

### Creation

#### SNMPv1 connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*

## Usage (1.0.0.x)

### General

This page displays general information about the device:

- **General Info**: System information.
- **Power Supply**: Status, temperature.
- **Options**: Installed options.
- **SNMP Info**: Packets information, etc.

### Audio

This page displays the audio statuses of all the SDI and ASI inputs and outputs, as well as the decoder and encoder statuses.

### Video

This page displays the Video Standard, Clock Frequency, Reference Standard, Genlock Detect and Video I/O Sync.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access to the device, as otherwise it will not be possible to open the web interface.
