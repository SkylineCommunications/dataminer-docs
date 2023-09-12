---
uid: Connector_help_TeamCast_Vyper_DVBSS2_SNMP
---

# TeamCast Vyper DVBS/S2 SNMP

This driver retrieves information from a **DVB-S/DSNG/S2** modulator via **SNMP** and makes it possible to configure certain parameters.

## About

With the **TeamCast Vyper DVBS/S2 SNMP** driver, you can retrieve status information from a **TeamCast Vyper DVBS/S2** modulator and set configuration parameters.

### Ranges of the driver

| **Driver Range** | **Description**                           | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                           | No                  | Yes                     |
| 1.1.0.x          | New firmware based on 1.0.0.x (see below) | No                  | Yes                     |
| 1.2.0.1          | New firmware (see below)                  | No                  | Yes                     |
| 1.3.0.x          | New firmware (see below)                  | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | S200                        |
| 1.1.0.x          | S100, S110                  |
| 1.2.0.x          | S120                        |
| 1.3.0.x          | S132                        |

## Installation and configuration

### Creation

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The IP address of the device, e.g. *194.206.71.180.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, e.g. *public.*
- **Set community string**: The community string used when setting values on the device, e.g. *private.*

## Usage

### General

This page displays important information such as the device **temperature**, the selected **reference clock** and the **modulation type**.

There are also several page buttons that allow you to configure the device, retrieve software and hardware information, view the current state of a **firmware** update, and review and configure the **network configuration** of the control and data ports.

### Modulator

This page displays status information regarding the modulator: **frequency**, **output power**, **alarm mute status**, **bit rate**, **DVB-S2** and **DVB-S** configuration, etc. Several of these parameters can be edited.

### Status

This page displays global state information by indicating when **alarms** occur, etc.

### DVB-S2 Stream Configuration

On this page, you can configure the **input stream type**, as well as settings related to the chosen input stream type (single stream or multi stream).
