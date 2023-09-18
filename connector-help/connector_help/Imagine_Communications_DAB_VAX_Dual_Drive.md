---
uid: Connector_help_Imagine_Communications_DAB_VAX_Dual_Drive
---

# Imagine Communications DAB VAX Dual Drive

The Imagine Communications VAX is a DAB digital radio and VHF TV solid-state transmitter built on Harris Broadcast PowerSmart 3D architecture, featuring a full broadband, single-amplifier design. This model has two exciters.

## About

With this connector, it is possible to monitor and configure the transmitter itself, as well as to enable the trap notifications and their priorities.

### Version Info

| **Range** | **Description**                                                  | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                  | No                  | Yes                     |
| 1.0.0.10         | Support for the Extended SD Transmitter MIB (VAXEXTENDED-DD-MIB) | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 861-1150-012 F/01.01.0150   |
| 1.0.0.10         | 861-1150-012 F/01.01.0150   |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number:** The port of the connected device, by default *161.*
- **Get community string:** The community string used when reading values from the device, by default *public.*
- **Set community string:** The community string used when setting values on the device, by default *private*.

### Configuration of the LITE functionality

To configure the LITE functionality of the connector, on the **Network Settings** page, enable the parameter **LITE PROTOCOL**.

## Usage

### General

This page includes general information from the standard MIB-2, such as the device location, contact information, system name, uptime, etc.

### Transmitter

On this page, you can configure transmitter behavior, such as the operation mode or the input. You can also monitor the state of the transmitter, e.g. the state of the inputs, and check for the presence of alarms and warnings.

### Exciter A

On this page, you can configure the exciter A behavior, e.g. the input signal state. You can also monitor the state of the exciter, e.g. the state of the inputs, and check for the presence of alarms and warnings.

The value *Undefined* in any of the possible states is considered to be an **exception** and is grayed out.

### Exciter B

On this page, you can configure the exciter B behavior, e.g. the input signal state. You can also monitor the state of the exciter, e.g. the state of the inputs, and check for the presence of alarms and warnings.

The value *Undefined* in any of the possible states is considered to be an **exception** and is grayed out.

### Event Settings

On this page, you can enable or disable the **traps**.

### Event priority

This page allows you to configure the priority of the notifications. Only values from 1 to 5 are allowed.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

Note that there are 8 possible notifications that this connector can receive via **traps** (if enabled). When these **traps** are received, the corresponding parameters are **repolled** to update their state.
