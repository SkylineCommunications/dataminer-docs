---
uid: Connector_help_GlobeSat_ACU9220S
---

# GlobeSat ACU9220S

The 9220S antenna control unit (ACU) is suitable for the automatic control for C or Ku band satellite communications earth stations and satellite television receiving only stations with two axes AC motorized control.

## About

This driver is intended to communicate with 9220S Antenna Control System devices using serial commands as described in the device manual.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.1          | Initial version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.1          | Not specified.              |

## Installation and configuration

### Creation

***Serial Main connection***
This driver uses a Serial connection and needs the following user information:

SERIAL CONNECTION:

Interface connection:

- IP address/host: \[The polling IP of the device\]
- IP port: \[The IP port of the device. Indicate if required or not. If so, specify default value and range.\]
- Bus address: \[The bus address of the device. Indicate if required or not. If so, specify default value, range and format.\]

## Usage

### General

This page displays the **Azimuth**, **Elevation**, **Polarization**, **AGC**, **Operation** **Mode**, and **ADU** **Status**. The **Error Message** remain "not initialized" Until there is an Error in the system.

### Rotation

This page displays an overview of **Azimuth CW/CCW**, **Elevation UP/Down**, and **Polarization CW/CCW Rotation.**

### Limit

This page displays an overview of **Azimuth CW/CCW**, **Elevation UP/Down**, and **Polarization CW/CCW Limit.**

### Soft Limit

This page displays an overview of **Azimuth CW/CCW**, **Elevation UP/Down**, and **Polarization CW/CCW Soft Limit.**
