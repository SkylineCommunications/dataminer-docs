---
uid: Connector_help_Tandberg_MA5400
---

# Tandberg MA5400

This device is an IP Video Gateway that enables transmission of real-time video over Internet Protocol (IP) networks.

## About

This connector is used to monitor and configure the transmission ports.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device e.g. *10.11.12.13*

**SNMP Settings**:

- **Port number**: The port of the connected device, default *161*
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

### Main View

**General Info** displays general parameters, e.g. **IP Address, Subnet Mask, Router, MAC, name**, .

**Alarm Status** displays the status of all possible alarms.

### IP TX

On this page, the transmission statistics and used configurations are displayed; however, the input state must be set to *Enable* for this*.*

It is also possible to configure these inputs.

The page contains a page button, **VLAN**, which displays the Virtual LAN settings for this device.

### Web Interface

This page opens the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Note

From version 1.0.0.2 of this connector onwards, if the alarm table is empty, all alarm parameters on the **Main View** page will display *OK*.
