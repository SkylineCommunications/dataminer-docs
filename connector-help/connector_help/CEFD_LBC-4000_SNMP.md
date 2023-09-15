---
uid: Connector_help_CEFD_LBC-4000_SNMP
---

# CEFD LBC-4000 SNMP

With this connector it is possible to monitor **CEFD LBC-4000** devices with **SNMP**.

## About

The **CEFD LBC-4000 SNMP** will monitor the **CEFD LBC-4000** device.

## Installation and configuration

### Creation

The **CEFD LBC-4000 SNMP** is an **SNMP** connector. The **IP** needs to be configured during creation of the **element**.

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*

**SNMP Settings**:

- **Port number**: the port of the connected device, default *161*
- **Get community string**: the community string in order to read from the device. The default value is *public*.
- **Set community string**: the community string in order to set to the device. The default value is *private.*

## Usage

### General Page

This page displays some general info of the device:

- Model Number
- Serial Number
- Software Revision
- ...

### Converters Page

In this page we display parameters from the A nad B converters.

### Event Log Page

In this page we display the Event Log table.

### Remote Control Page

In this page we display the values referent to Serial and SNMP interfaces.

### Redundancy Page

In this page we display the values referent to the Redundancy.

### Monitors Page

In this page we display the Voltages and temperatures of both converters.

### Summary Page

In this page we display the alarm statuses.

### Firmware Page

In this page we display a table with the firmware available on the device.

### Faults Page

In this page we display a table with the faults detected on the device.

### Web Interface Page

In this page we display the web interface of the device.
