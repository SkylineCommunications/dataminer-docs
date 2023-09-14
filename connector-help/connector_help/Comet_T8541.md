---
uid: Connector_help_Comet_T8541
---

# Comet T8541

This connector can be used to display information related to the **T8541** temperature sensor.

## About

This connector uses an **SNMP** interface to communicate with the T8541 device.

## Installation and Configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.145.1.12*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *private*.

## Usage

### General Page

This page contains general information about the device such as:

- **System name**
- The **temperatures** for channels 1 to 4
- The **alarm status** of channels 1 to 4

### History Table Page

This page displays a table with history information regarding the temperatures.

### Web Interface

This page displays native web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
