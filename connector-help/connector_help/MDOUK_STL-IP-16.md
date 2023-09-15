---
uid: Connector_help_MDOUK_STL-IP-16
---

# MDOUK STL-IP-16

With this connector, information can be gathered and viewed from the device **MDOUK SLT-IP-16.** The connector also allows the user to perform sets on the device.

## About

This connector is used to gather information from the **MDOUK SLT-IP-16** device.

The connector has several pages with general information, network status, audio, etc.

## Installation and configuration

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP address/host**: The polling IP of the device, e.g. 10.22.4.11.
- **Device address**: Not needed.

**SNMP Setting:**

- **Port number:** The port of the connected device, by default *161*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General

This page displays general information regarding the device, such as the system temperature, power supply status, system and case fan status, etc.

### Network Status

This page shows the network status of the device.

The page also includes a page button, **Jitter Buffer.** On this subpage, the user can find information regarding the device jitter buffer channels.

### Tx Status

This page displays the status of the Tx channels of the device.

### Rx Status

This page displays the status of the Rx channels of the device

### Audio

This page displays the audio status of the device. It also allows the user to reset the following:

- **Audio Overload**
- **Audio In Silent Detect**
- **Audio Out Silent Detect**
