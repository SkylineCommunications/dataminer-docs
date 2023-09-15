---
uid: Connector_help_Palo_Alto_Networks_PA-5050
---

# Palo Alto Networks PA-5050

The **Palo Alto Networks PA-5050** is a firewall platform.

## About

With the **Palo Alto Networks PA-5050** connector, you can monitor and control the device with SNMP.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General page

This page displays general information about the device, together with the **System Resources**.

### Interfaces

This page displays an overview of all the interfaces.

### Physical Sensors

This page displays the **Physical Sensor table**, which contains a list of all the sensors with their measured values.

### System, Chassis and Session

This page displays additional information about the device.
