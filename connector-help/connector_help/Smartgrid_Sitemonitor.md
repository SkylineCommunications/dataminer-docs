---
uid: Connector_help_Smartgrid_Sitemonitor
---

# Smartgrid Sitemonitor

With this connector, it is possible to gather and view information from the device **Smartgrid Sitemonitor**.

## About

This connector uses **SNMP** to monitor the Smartgrid Sitemonitor device. It also receives and processes **traps** from the device.

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.18.23.17*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *public*.

## Usage

### General Page

This page displays general information about the device, such as **Description**, **Up Time** and **Contact**.

### Interfaces Page

This page displays a table with status information and statistics for the interfaces.

### State Page

This page displays the device state, including **Indoor Temperature**, **Voltage A** and **Signal Quality.**

### Alarms Page

This page shows the status of the alarms present on the device.

### Parameters Page

This page allows you to configure the device, with parameters such as **Burglar Alarm Sticky Duration** and **Outdoor Temperature Threshold**.

### PDU Page

This page displays a table with the outlet information.

### Web Interface Page

This page shows the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
