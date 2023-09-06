---
uid: Connector_help_Delta_Electronics_HEC_1004
---

# Delta Electronics HEC 1004

The **Delta Electronics HEC 1004** is a transponder.

## About

This driver monitors the **Delta Electronics HEC 1004** device via **SNMP**.

## Installation and configuration

### Creation

This driver uses a Simple Network Management Protocol (SNMP) connection and needs the following user information:

SNMP CONNECTION:

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## Usage

### General Page

The **General** page displays a table with the following nodes information:

- **Name**
- **MAC Address**
- **Downstream**
- **Burstmode**
- **ICS**
- **Status**
