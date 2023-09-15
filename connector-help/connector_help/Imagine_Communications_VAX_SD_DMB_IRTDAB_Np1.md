---
uid: Connector_help_Imagine_Communications_VAX_SD_DMB_IRTDAB_Np1
---

# Imagine Communications VAX SD DMB IRTDAB Np1

This connector is used to monitor an Imagine Communications VAX SD DMB IRTDAB Np1 transmitter device.

## About

This connector retrieves 15 parameters from the device. Data is polled via **SNMP**. The connector supports traps: each parameter is associated with a trap and trap sending can be enabled/disabled for each parameter.

## Installation and Configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host:** The polling IP of the device, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number:** The port of the connected device, by default *161*.
- **Get community string:** The community string used when reading values from the device, by default *public*.
- **Set community string:** The community string used when setting values on the device, by default *private*.

## Usage

This connector contains 2 pages.

### General

This page displays 7 different groups of control parameters. Each group contains a main parameter, a parameter to enable/disable the corresponding traps and a priority parameter.

There are also three configuration parameters. **Event Counter Monitoring** is used to switch between the two kinds of traps monitoring:

- If this parameter is *enabled*: when a trap is received, the binding '*Event Counter*' is read. If two successive traps have an '*Event Counte*r' binding separated by more than **Event Counter Threshold**, all parameters are polled again.
- If this parameter is *disabled*: when a trap is received, the corresponding parameter is polled again.

The **Refresh** button is used to force the polling of the data.

### Faults

This page displays 8 different groups of monitoring parameters.
