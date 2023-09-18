---
uid: Connector_help_Trilogy_Gemini
---

# Trilogy Gemini

The **Trilogy Gemini** frame can be fitted with up to 32 local ports for panels, analogue and digital audio interfaces, and telephony.

## About

The connector provides an overview of general states as well as the panel status of 32 panels.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device
- **Device address**: not required

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

### Status

This page contains general status parameters: **Local Audio State**, **Network Audio State**, **PSU Status**, etc.

There is also a page button **Panel Status**, which displays the status of the 32 panels.

### Trap Configuration

On this page, you can enable and disable trap generation and configure the IP addresses where traps are sent.

### Web interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
