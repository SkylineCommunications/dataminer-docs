---
uid: Connector_help_Grass_Valley_Summit_Server
---

# Grass Valley Summit Server

The **Grass Valley Summit Server** connector displays information related to the **Grass Valley Summit Server** device.

## About

This connector uses an SNMP interface to communicate with the **Grass Valley Summit Server** device.

## Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## Usage

### General Page

This page displays generic parameters, such as:

- Element Name
- Software Revision
- Element Type
- ...

### Connections Page

This page displays a table with the Input Output connections.

### Disk Recorders Page

This page displays four tables with information related to the disk recorders.
