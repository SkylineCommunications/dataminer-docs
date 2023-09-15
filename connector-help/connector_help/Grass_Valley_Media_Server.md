---
uid: Connector_help_Grass_Valley_Media_Server
---

# Grass Valley Media Server

The **Grass Valley Media Server** connector displays information related to the **Grass Valley Media Server** device.

## About

This connector uses an SNMP interface to communicate with the **Grass Valley Media Server** device.

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

### FSM Page

This page displays parameters related to the **File System Manager**.

### Media table Page

This page displays a table with the media drives and status.

### Transfer Statistics Page

This page displays transfer statistics retrieved from the device.

### Storage Bridge Page

This page displays two tables related to the storage bridge.

### Roles Page

This page displays a table with the roles.
