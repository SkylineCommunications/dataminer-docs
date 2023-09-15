---
uid: Connector_help_Lantronix_ETS32
---

# Lantronix ETS32

This is an **SNMP**-based connector that is used to monitor and configure the **Lantronix ETS32**.

## About

The **Lantronix ETS32** is a multi-port device server providing shared network access to terminals, devices, console ports and printers for a variety of network protocols and operating systems.

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### Ports Page

This page displays all the ports configured on the Lantronix ETS32 (**Physical** and **Virtual**).

The table shows information about each port. Each port can also be configured and **reset** here.

### Sessions Page

This page displays all current sessions with some information and the possibility to **kill** **a session**.

### Web interface

This page displays the web interface of the Lantronix ETS32. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
