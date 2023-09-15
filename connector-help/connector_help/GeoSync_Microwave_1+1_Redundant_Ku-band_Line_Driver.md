---
uid: Connector_help_GeoSync_Microwave_1+1_Redundant_Ku-band_Line_Driver
---

# GeoSync Microwave 1+1 Redundant Ku-band Line Driver

This connector is used to monitor and control a GeoSync Microwave Redundant Ku-band Amplifier.

## About

This connector monitors the inputs and outputs of a GeoSync Microwave Redundant Ku-band amplifier.

It retrieves various kinds of information from the device: Output Level, Alarm Status, etc.

Data is polled from the device via a serial protocol.

## Installation and Configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP of the device e.g. *10.11.12.13*.
- **IP port**: The IP port of the device.
- **Bus address**: The address used by the serial interface. The default bus address is 64, the range is \[64-95\].

## Usage

This connector contains 5 pages.

### General

This page displays general information about the connector (**Firmware**, **Model** **Number**, etc.). It also allows the operator to switch between manual and automatic control.

### Primary Unit

Displays different settings for the primary unit. The operator can control the limits of the output power, the attenuation or the current.

### Backup Unit

Displays different settings for the backup unit. The operator can control the limits of the output power, the attenuation or the current.

### Power Supply

Displays different settings for the two redundant power supply units.

### LOG

This page contains a table that displays all log entries recorded by the device. This table is polled at a low frequency. A **Refresh** button is available to allow the user to poll the table on demand. A **Clear** button is also available.

