---
uid: Connector_help_Cavena_STU
---

# Cavena STU

This connector is used to monitor the **Cavena STU** (Subtitle Transmission Unit).

## About

The Cavena STU is a subtitle encoder and renderer. One STU is used per channel. It can be used standalone for offline encoding or as part of a playout system, where the STU is controlled by a Subtitle Transmission Controller (STC).

The STU is based on a Windows software platform for playout of subtitles in various transmission formats. It is designed for use in an automated playout environment, and can also be controlled by an operator at any time. One STC can control up to 24 STU units, with automatic failover to extra STUs in the network, without any need for configuration or wiring (except for certain serial and ASI interfaces).

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *172.32.65.38.*

SNMP Settings:

- **Port number**: The UDP port, by default *161.*
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### Products

This page contains the **Product table**, which displays the Product Name, Type, Version and Serial Number.

### Hardware

This page contains the **Hardware table**, which displays the Hardware Name, Type, Version, Serial Number, Driver Version and Firmware Version.

### Status

This page displays seven tables:

- **Timecode Table**
- **Port Table**
- **Current Event Table**
- **License Table**
- **Incoming Table**
- **Input Channel Language Table**
- **Current Event Language Table**

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
