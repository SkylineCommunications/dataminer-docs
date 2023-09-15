---
uid: Connector_help_GlobeSat_ACU9220S
---

# GlobeSat ACU9220S

The 9220S antenna control unit (ACU) is suitable for the automatic control for C or Ku band satellite communications earth stations and satellite television receiving only stations with two axes AC motorized control.

## About

This connector is intended to communicate with 9220S Antenna Control System devices using serial commands as described in the device manual.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Not specified.              |

## Installation and configuration

### Creation

#### Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - IP address/host: The polling IP of the device.
  - IP port: The IP port of the device.
  - Bus address: The bus address of the device.

## Usage

### General

This page displays the **Azimuth**, **Elevation**, **Polarization**, **AGC**, **Operation** **Mode**, and **ADU** **Status**. The **Error Message** remain "not initialized" Until there is an Error in the system.

### Rotation

This page displays an overview of **Azimuth CW/CCW**, **Elevation UP/Down**, and **Polarization CW/CCW Rotation.**

### Limit

This page displays an overview of **Azimuth CW/CCW**, **Elevation UP/Down**, and **Polarization CW/CCW Limit.**

### Soft Limit

This page displays an overview of **Azimuth CW/CCW**, **Elevation UP/Down**, and **Polarization CW/CCW Soft Limit.**
