---
uid: Connector_help_Sandar_SA-1100
---

# Sandar SA-1100

This connector can be used to gather and view information from the device **Sandar SA-1100**.

## About

This connector uses **SNMP** to monitor the Sandar SA-1100 device.

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.17.255.67*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays general information about the device, such as **System Description**, **Active Input** and **Contact**.

### Interfaces Page

This page displays a table with status information and statistics for the interfaces.

### Switch Status Page

This page displays a table with the available inputs and their status. You can also change the active input and the input name here.

### Web Interface Page

This page shows the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it may not be possible to open the web interface.
