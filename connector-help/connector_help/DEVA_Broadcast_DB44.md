---
uid: Connector_help_DEVA_Broadcast_DB44
---

# DEVA Broadcast DB44

The **DEVA Broadcast DB44** connector displays information related to the **DEVA Broadcast DB44** Receiver device.

## About

This connector uses an SNMP connection to communicate with the **DEVA Broadcast DB44** device.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## Usage

### General Page

This page displays status parameters such as the **Device ID**, **IP Address**, etc.

### Setup Page

This page displays the configurable setup parameters for HTTP, SNMP, etc.

### Management Setup Page

This page displays a table with extra configurable parameters for each channel.

### Alarm Page

This page displays a table with the active alarms of the device.
