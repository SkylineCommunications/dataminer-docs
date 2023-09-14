---
uid: Connector_help_Vertex_DTR
---

# Vertex DTR

The **Vertex DTR** is a tracking receiver developed for satellite tracking and uplink power control applications. This connector can be used to monitor and control any Vertex DTR device.

## About

A **TCP/IP connection** is used to retrieve data from the device. The connector uses the "Remote Monitor and Control (M&C)" protocol as described in the user manual.

### Version Info

| **Range** | **Description**  | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------|---------------------|-------------------------|
| 3.1.0.X          | Firmware version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 3.1.0.x          | V5.13.00_6                  |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device (required).

## Usage

### General

This page displays the version numbers of the different components of the device.

The following page buttons are available:

- **Interface**: Front panel UI settings.
- **Serial**: Serial port settings.
- **Date/Time**: The current date and time on the device.
- **Calibration**: System parameters that are calibrated in the factory and NOT changed by the user in normal circumstances.
- **Date/Time**: The date and time of the device.
- **Faults**: All the possible faults that are registered by the device.

### Receiver

This page displays the status of the receiver part of the device and allows you to configure certain parameters.

The following buttons are available:

- **DAC1** page button: Allows setup of DAC1, which provides an analog DC voltage proportional to signal level on pins 1 and 14 (+OUT, -OUT) of I/O interface \#1 on the back panel.

- **DAC2** page button: Allows setup of DAC2, which provides an analog DC voltage proportional to signal level on pins 3 and 16 (+AUX, -AUX) of I/O interface \#1 on the back panel.

- **Store beacons** buttons: Store the current values of the following parameters as a beacon state:

- Frequency
  - Polarization
  - Attenuation
  - Filter
  - Input attenuation
  - Slope
  - Voltage Range
  - Minimum Power Reference Level

- **Restore beacons** buttons: Restore values that were previously stored as a beacon state.

### I/O Status

This page displays the temperatures of LBFE and SPU, as well as the PLL voltages.
