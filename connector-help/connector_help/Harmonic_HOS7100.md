---
uid: Connector_help_Harmonic_HOS7100
---

# Harmonic HOS7100

This is a connector for an optical switch, also described as a protection switch.

## About

This switch always has 2 inputs and 1 output. The inputs and their thresholds are monitored, but only the thresholds can be configured. The switch itself can be configured as well. The layout is based on the web interface.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General Page

This page displays standard parameters, as well as the device temperature. It also contains the firmware and hardware versions of both the chassis and the switch.

### Configuration Page

This page allows the user to configure the switch.

The **Select Wavelength** parameter has a range between *1290*-*1330nm* and *1525-1610nm*. These values are respected even though the possible input values are between *1290-1610nm.*

### Optical Power Page

On this page, the **Optical Power-RX**\# of both inputs can be monitored, and its thresholds can be configured.

### Web Interface

This page refers to the web interface of the device.
