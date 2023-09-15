---
uid: Connector_help_Socomec_Diris_A40-A41
---

# Socomec Diris A40-A41

The Socomec Diris A40-A41 is a multi-meter for electric values in single-phase, two-phase and three-phase LV and HV networks.

## About

The Socomec Diris A40-A41 protocol is a serial-based protocol. The commands are sent to an Ethernet module that is directly attached to the device.

The connector itself is used to monitor the device.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not used.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *502.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General page

On the **General** page, there are different blocks of data:

- Current
- Power
- Power Consumption
- Phase To Neutral Voltage
- Phase to Phase Voltage
- Temperatures

Each of these blocks displays information of the parameters related to the block.

There are three page buttons on this page that each lead to a pop-up page with additional information. In addition, there is one button available, **Reset**, that will perform a reset.

### Webpage

This page displays the webpage associated with the device.
