---
uid: Connector_help_Evertz_7703PA
---

# Evertz 7703PA

With this connector, you can monitor **Evertz 7703PA** devices with SNMP.

## About

The **Evertz 7703PA** can be used to monitor the Evertz 7703PA amplifier device.

### Product Info

| **Range** | **Device Revision** |
|------------------|---------------------|
| 1.0.0.x          | Unknown             |

## Installation and configuration

### Creation

SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays the following card information tables:

- **Monitor Table**
- **Management Monitor Table**

These provide information about the gain, RF power, card type and firmware version.

### Fault Page

This page displays the following fault information tables:

- **Management Fault Table**
- **Misc Fault Table**

These provide information about the faults and shows whether they are currently active.

### Control Page

This page displays the following control tables:

- **Control Table**
- **Management Control Table**

It also allows the user to control the RF high and low threshold, gain, AGC Output level, Slope Correction and 22KHz Tone.
