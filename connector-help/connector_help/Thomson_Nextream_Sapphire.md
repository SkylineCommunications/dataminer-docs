---
uid: Connector_help_Thomson_Nextream_Sapphire
---

# Thomson Nextream Sapphire

This connector is used to configure and monitor a **Thomson Nextream Sapphire** device.

## About

The Thomson Nextream Sapphire is an MPEG video server. Communication to the device goes through **SNMP** and **HTTP** (SOAP interface) protocols.

## Configuration and Installation

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and an HTTP connection. It requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

**SERIAL CONNECTION (HTTP SOAP interface)**:

- **IP address/host**: The polling IP or URL of the destination, e.g. *10.11.12.13.*
- **IP port**: The port of the destination, by default *8080.*

## Usage

### General page

This page displays general information about the device

### Boards page

This page displays information about the ASI and IP interfaces on the device.

### Input Overview page

This page displays a table containing all inputs, with status and last error.

### Output Overview page

This page displays a table containing all outputs, with status and last error.

### Playout Overview page

This page displays a table containing current playout streams, with status and last error.

### Record Overview page

This page displays a table containing current record streams, with status and last error.

### Function List page

This page displays a table with the defined functions on the device. A function is used to record a stream for a specific channel.

### Segment List page

This page displays a list with all programmed segments. A segment is basically a recording that will be executed on the defined start time for the given duration.

You can also add or remove segments on this page.
