---
uid: Connector_help_CTE_FMTX1
---

# CTE FMTX1

The **FMTX1** connector displays information related to the **1kW Transmitter** device.

## About

This connector uses an **SNMP** interface to communicate with the FMTX1 device. It displays the parameters in a manner similar to the web interface of the device.

## Installation and configuration

### Creation

This connector uses an SNMP connection and requires the following input during element creation:

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## Usage

### System Parameters Page

This page contains general information about the device, such as:

- Stand-By status
- Frequency Output
- Temperature
- System Date/Time
- ...

### Network Parameters Page

This page displays generic network parameters, such as:

- IP Address
- Netmask
- Trap Destination
- TFTP Server IP Address

### Real Time Alarms Page

This page displays the device alarm parameters, such as:

- Excessive SWR
- Power Amplitude Overheat
- Power Supply Overload

### Web Interface Page

This page displays the web interface of the device.
