---
uid: Connector_help_Papouch_TME
---

# Papouch TME

With this connector it is possible to gather and view information from the device **Papouch TME.**

## About

This is an SNMP protocol that is used to monitor the **Papouch TME** device.

**Alarming** and **trending** are enabled for parameters in the protocol.

## Installation and configuration

### Creation

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *10.64.31.16.*

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays general information about the device, such as:

- **System Description**
- **Up Time**
- **Contact**
- **Temperature**

### Interfaces Page

This page displays information about the status of the device's interfaces.

It also allows the user to change the status of an interface.

### Web Interface Page

This page displays the web interface of the device.
