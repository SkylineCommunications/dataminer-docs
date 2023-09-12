---
uid: Connector_help_ETL_Systems_VTR-10
---

# ETL Systems VTR-10

The **ETL Systems VTR-10** driver is used to configure and display information of the ETL Systems VTR-10 device.

## About

This protocol can be used to monitor and control the **ETL Systems VTR-10** device. The driver supports one serial connection to communicate with the device.

**Alarming** and **trending** are enabled for parameters in the protocol.

## Installation and configuration

### Creation

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *172.27.64.111*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays general information about the device, such as:

- **Summary Alarm**
- **CPU Temperature**
- **Fan Status**
- Etc.

### Matrix Page

This page displays the matrix containing the connections present on the device.

The matrix interface allows the user to do the following actions:

- Set a new connection, by clicking on the desired connection. Note that setting a new connection can disconnect an existing connection.
- Edit the labels, by right-clicking in the matrix and selecting **Edit**. On the pop up page, the field description of the desired output or input should then be changed.

### Inputs Page

This page displays a table with the configuration and readings of the inputs.

### Outputs Page

This page displays a table with the configuration of the outputs.

### Trap Configurations Page

On this page, the user can configure the traps receiver.

### Configuration Page

On this page, the user can configure the matrix/device.

### Web Interface

This page displays the web interface of the device.
