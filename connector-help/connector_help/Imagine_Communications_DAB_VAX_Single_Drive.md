---
uid: Connector_help_Imagine_Communications_DAB_VAX_Single_Drive
---

# Imagine Communications DAB VAX Single Drive

The Imagine Communications VAX is a DAB digital radio and VHF TV solid-state transmitter built on Harris Broadcast PowerSmart 3D architecture, featuring a full broadband, single-amplifier design.

## About

With this connector, it is possible to monitor and configure the transmitter itself, as well as to enable the trap notifications and their priorities.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | a1160                       |

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

This page includes general information from the standard MIB-2, such as the device location, contact information, system name, uptime, etc..

### Transmitter

On this page, you can configure transmitter behavior, such as the operation mode or the input. You can also monitor the state of the transmitter, e.g. the state of the inputs, and check for the presence of alarms and warnings.

### Event Settings

On this page, you can enable or disable the **traps**.

### Event priority

This page allows you to configure the priority of the notifications.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

Note that there are 8 possible notifications that this connector can receive via **traps** (if enabled). When these **traps** are received, the corresponding parameters are **polled again** so their state can be updated.
