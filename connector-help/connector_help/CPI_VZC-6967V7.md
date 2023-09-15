---
uid: Connector_help_CPI_VZC-6967V7
---

# CPI VZC-6967V7

The **CPI VZC-6967V7** connector is a serial connector used to monitor and configure the **CPI VZC-6967V7** device.

## About

The **CPI VZC-6967V7** is an amplifier. The connector uses serial communication to monitor and configure the device. This means that it sends commands to the device and receives a response for every command.

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **IP port**: The port of the connected device.
- **Bus address**: The bus address of the connected device. *(Between 48 and 111.)*

## Usage

### Main View Page

This page displays the general information about the device, e.g. the **Helix Voltage, Helix Current, RF Output Power...**

### General Control Page

This page displays information about the alarm thresholds. The thresholds are configurable.

### Control RF Output Page

This page displays information about the **RF Output**.

### Meter Query Page

This page displays information about the **Meter Query**.

### Linearizer Query Page

This page displays information about **Gain**, **Phase** and **Magnitude Offsets**.

### Configuration Page

This page displays information about the device configuration.

### Status Info Page

This page displays **Fault States**.

### Log Page

This page displays **Log Information**.

### Web interface

This page displays the web interface of the amplifier.
