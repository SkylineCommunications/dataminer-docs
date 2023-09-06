---
uid: Connector_help_Telos_Systems_Omnia.9sg
---

# Telos Systems Omnia.9sg

The Omnia.9sg is based on the same limiter, clipper, and stereo generator technology incorporated in the Omnia.9 and is ideal for applications where the final limiter and stereo generator must be separate from the main audio processor.

This driver monitors specific Omnia parameters as well as general status parameters via **HTTP**. **SNMP** **traps** can be retrieved when this is enabled on the device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

## Configuration

### Connections

#### HTTP connection

This driver uses an HTTP connection to receive traps and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Port number**: The port of the device.

#### SNMP connection

This driver uses a Simple Network Management Protocol (SNMP) connection to receive traps and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, i.e. *public*.
- **Set community string**: The community string used when setting values on the device, i.e. *private*.

## How to use

The element consists of the data pages detailed below.

### General

Contains parameters related to the stereo generator.

### System

Provides information related to the performance and configuration of 9sg, including CPU data, software versions, network information, the Monitor Out status and a list of current alarms.

The **System Configuration** page button displays the current 9sg software and NfRemote client version. With the **Reinstall** button, you can reinstall the currently loaded software version. The **Save Configuration to USB** button saves the current configuration to USB.

### Audio Info

Displays information about the digital and analog input signals.

### MPX

Displays general MPX parameters and parameters related to MPX1 and MPX2.

### RDS

Displays parameters related to RDS.
