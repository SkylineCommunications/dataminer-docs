---
uid: Connector_help_Moxa_ioLogik_E2242
---

# Moxa ioLogic E2242

This is an **SNMP** connector for the **Moxa E2242 IO Contact Interface**. It is a basic connector that allows you to monitor the DI/DO channels and AI channels. You can also change a number of settings for each I/O port.

## About

This connector displays basic information about the device, as well as status information on the digital inputs and outputs in the DI/DO channels. For each digital input and output port, some settings can be configured.

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## Usage

### General Page

This page displays the total number of channels, the server model, the uptime of the device, the firmware version and other basic information.

### Digital Inputs

This page displays the status of the various digital input channels.

### Digital Outputs

This page displays the status of the various digital output channels.

### Analog Inputs

This page displays the status of the various analog input channels.

### Web interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

Traps related to digital input and output events are supported. A trap message receiver is also supported. This message will be reported as an information event.
