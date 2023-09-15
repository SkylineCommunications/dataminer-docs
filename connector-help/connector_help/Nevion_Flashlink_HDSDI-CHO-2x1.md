---
uid: Connector_help_Nevion_Flashlink_HDSDI-CHO-2x1
---

# Nevion Flashlink HDSDI-CHO-2x1

The Flashlink HDSDI-CHO-2x1 is a serial digital video 2x1 changeover module, which provides high-performance line protection for various signal formats from 1 Mbps up to 1485 Mbps. The unit can be configured to perform cable equalizing and re-clocking of SMPTE 292M, SMPTE 259M and DVB-ASI signal formats. The switching criteria can be selected to be based on loss of input signal or loss of lock (re-clocker). The switch can either be latching or non-latching (in loss of lock mode, only the latching switch is available). It is also possible to control the switch with GPI inputs, with the GYDA system controller and with the open protocol RS422 interface.

## About

The Nevion Flashlink HDSDI-CHO-2x1 connector is used for monitor these kinds of devices using the SNMP protocol.

### Version Info

| **Range** | **Description**                    | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version.                   | No                  | Yes                     |
| 1.0.1.x          | New range with DCF implementation. | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.0.1.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Required address of the device. Should be in the following range: *0.1-7.10*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains general information about the device, such as the **Module Type**, **Polling IP Address**, **Slot Number**, **Selected Input**, etc.

### Main View

This page displays technical information about the device, such as information on the input and output signals, and on the configuration of the reclocker.

### Equalizer

This page contains information about the cable equalizers, such as the current configuration of these equalizers and the status of the signal detectors.

### Reclocker

This page displays reclocker information, such as the reclocker configuration, bitrate and signal status.

## DataMiner Connectivity Framework

The **1.0.1.x** connector range of the Nevion Flashlink HDSDI-CHO-2x1 protocol supports the usage of DCF and can only be used on a DMA with **8.5.8.5** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **Input 1 Signal**: Interface of type "**in**", created for parameter PID **7001**.
- **Input 2 Signal**: Interface of type "**in**", created for parameter PID **7201**.
- **Output Signal:** Interface of type "**out**", created for parameter PID **7401**.

### Connections

#### Internal Connections

**Output Selection** (PID 7402) defines which input is connected to the output.

- Output Selection value is "Input 1": **\[Input 1 Signal-\>** **Output** **Signal\].**
- Output Selection value is "Input 2": **\[Input 2 Signal -\> Output Signal\].**
