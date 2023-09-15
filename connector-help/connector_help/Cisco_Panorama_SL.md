---
uid: Connector_help_Cisco_Panorama_SL
---

# Cisco Panorama SL

This connector is used to display information related to the **Cisco Panorama SL** device.

## About

This connector uses SNMP to communicate with the **Cisco Panorama SL** device.

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

This page displays Service Layer rates, such as the **Total HTTP Sessions Rate**, **Total Bytes Sent Rate**, etc.

### Traps Page

This page displays a table with the traps received from the device.
