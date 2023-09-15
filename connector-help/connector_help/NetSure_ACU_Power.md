---
uid: Connector_help_NetSure_ACU_Power
---

# NetSure ACU Power

With this connector, the **NetSure ACU Power** can be monitored using SNMP.

## About

The NetSure ACU Power connector monitors the alarms, temperatures, current and voltages of the **NetSure ACU Power**.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays general information regarding the NetSure ACU Power:

- System description
- Current
- Voltage
- Communication State
- Battery State
- .

### Alarm Page

This page displays a table with the active alarms of the device. The table contains the:

- Alarm time
- Severity
- Description
- Alarm type
