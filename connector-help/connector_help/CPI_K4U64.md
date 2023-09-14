---
uid: Connector_help_CPI_K4U64
---

# CPI K4U64

With this connector, you can monitor a **CPI K4U64** amplifier.

## About

The **CPI K4U64** connector uses a serial connection in order to monitor and configure a **CPI K4U64** 1:2 LNA protection switch.

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **IP port**: The port of the connected device.
- **Bus address**: The bus address of the connected device's relay processor, ranging from *33* up to and including *126*.

## Usage

### General Page

This page displays general information regarding the device:

- Device Time and Date
- Software Versions

### Configurations Page

This page displays configurable parameters, like the transmit mode or the RF Inhibitor state.

### Faults Page

This page displays fault statuses of the device.

### Status Page

This page displays the current, voltage and temperature alarm status.

### Measurements Page

This page displays the values for the current, voltage, humidity and temperature.
