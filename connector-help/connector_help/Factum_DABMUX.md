---
uid: Connector_help_Factum_DABMUX
---

# Factum DABMUX

The **DABMUX** connector displays information related to the **DABMUX** multiplexer device.

## About

This connector uses an **SNMP** interface to communicate with the **DABMUX** device.

## Installation and configuration

### Creation

This device uses an SNMP connection and requires the following user information:

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *private*.

## Usage

### General Page

This page contains general information about the device, such as:

- System Contact
- System Name
- Agent Version
- System Location

### Channel Status Page

This page displays a table with the status of the alarms of the device.
