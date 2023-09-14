---
uid: Connector_help_FOR-A_FA-9500
---

# FOR-A FA-9500

This is an SNMP-based protocol for the FOR-A FA-9500. The FA-9500 is a single-channel multipurpose signal processor intended for a variety of applications including master control, mobile production, post-production services, live production and more.

## About

This connector was designed to work only with model **FA-9500**. It allows the user to monitor the state of the fans and power supplies. The status of the many inputs and outputs of this equipment can also be monitored. In addition, certain parameters of the video conversion can be configured. SNMPv2 **Get** commands are used to read information from the device. SNMPv2 **Set** commands are used to write information to the device.

### Version Info

| **Range** | **Description**                                                                                 | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                                                 | No                  | Yes                     |
| 1.1.0.x          | Version compatible with firmware 8.10 (parameters added in correspondence with the MIB update). | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 8.00                        |
| 1.1.0.x          | 8.10                        |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains general information, such as **System Description** and **System Uptime**.

Several page buttons provide access to more information about **Interfaces**, as well as **IP**, **ICMP**, **TCP**, **UDP** and **SNMP** **statistics**.

### Unit

This page displays information related to the device itself, such as its **Serial Number** and **Software Version**.

It also allows you to check the optional **SW** and **HW** **modules** installed in this unit.

### Status

This page provides information about the operational status of the **fans**, **power supplies**, **inputs** and **outputs**.

### Video

This page allows you to configure the video processing settings for the two **Frame Synchronizers** included in this device, and allows you to perform up/down/cross conversion of the video signal.

### Audio

On this page, you can configure the mapping of **audio channels** from any input to any output. You can also mute or unmute the output sound with the **Audio Master Mute** parameter.

### System

This page allows you to **bypass** the input signals directly to the output. It also allows you to send video and audio **test signals** to the output.

### Web Interface

This page provides access to the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
