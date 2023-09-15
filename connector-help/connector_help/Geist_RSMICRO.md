---
uid: Connector_help_Geist_RSMICRO
---

# Geist RSMICRO

The **Geist RSMICRO** is a monitoring platform that can incorporate various sensors. Each sensor will produce information according to its sensor type (climate sensors, for example, will detect temperature, humidity, etc.)

## About

This connector uses SNMP to poll data from the device and display it accordingly. Traps receivers are also implemented for the purpose of alarm monitoring.

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

### General Page

This page displays the general system parameters like the **System Description**, **System Uptime**, etc. It also contains additional device parameters like the **Version**, **MAC Address**, configured **IP/URL**, etc.

A page button labelled **Sensor Modules** opens a subpage where you can find a list and a counter of all sensor modules installed on the device.

### Climate Sensor Page

On this page, the **Climate Sensor Table** is displayed. This table shows the data collected by the installed climate sensors. Each entry represents an individual climate sensor module.

### Web Interface Page

This page displays the web interface of the device. It can be used to access the device through the DataMiner client instead of a regular web browser.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

Currently only the Climate module table is polled from the device.
