---
uid: Connector_help_CTE_ACU1
---

# CTE ACU1

The **ACU1** connector displays information related to the **CTE ACU1** Change Over device.

## About

This connector uses an **SNMP** interface to communicate with the ACU1 device. It displays the parameters in a manner similar to the web interface of the device.

## Installation and configuration

### Creation

This connector uses an SNMP connection and requires the following input during element creation:

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *private*.

## Usage

### ACU Status Page

This page contains general information about the device, such as:

- Operating Mode
- Temperature
- Power Supply Voltages
- ...

### Tx Status Page

This page displays Tx A and Tx B status parameters.

### Configuration Page

This page displays the configurable parameters, such as:

- Safety Mode
- Failure Delay
- Auto Change Time
- ...

### Alarms Page

This page displays the device alarm status, with parameters such as:

- Power Supply Failure
- System Failure
- ...

### Event Table Page

This page displays a table that can be used to configure which parameter changes should generate a a trap or send an email.

### Web Interface Page

This page displays the web interface of the device.
