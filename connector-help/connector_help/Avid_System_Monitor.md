---
uid: Connector_help_Avid_System_Monitor
---

# Avid System Monitor

With this connector, you can gather and view information from the device **Avid System Monitor**, as well as configure the device.

## About

This connector uses SNMP to monitor the **Avid System Monitor** device.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *172.27.64.111*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays general information about the device, such as the **System Description**, **Up Time** and **Location**.

### Interfaces Page

This page displays a table with information on the interfaces of the device, such as the **Interface Description**, **Interface Type** and **Interface Status**.

### Performance Page

This page displays performance measurements from the device, such as the **Megabytes per Second**, **Open Files** and **Active Client Count**.

### Usage Page

This page displays usage measurements from the device, such as the **Highest Disk Used Percentage**, **Total Used Size** and **File Count**.

### Web Interface Page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
