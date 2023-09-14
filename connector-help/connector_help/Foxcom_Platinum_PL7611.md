---
uid: Connector_help_Foxcom_Platinum_PL7611
---

# Foxcom Platinum PL7611

With this connector, you can monitor a **Foxcom Platinum PL7611** device with SNMP.

## About

The **Foxcom Platinum PL7611** will monitor and configure a Foxcom Platinum PL7611 switch.

## Installation and configuration

### Creation

The **Foxcom Platinum PL7611** is an SNMP connector. The IP needs to be configured during creation of the element.

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the main device, e.g. *10.11.12.13.*
- **Device Address**: The slot of the chassis that contains the device. The default value is *1*.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General Page

This page displays general information on both devices:

- System info
- Software Version
- Hardware Version

### Switch Page

This page displays parameters specific to the switch.

### Alarm Page

This page contains the device alarms.

### Web Interface page

On this page, the web interface of the device can be viewed.
