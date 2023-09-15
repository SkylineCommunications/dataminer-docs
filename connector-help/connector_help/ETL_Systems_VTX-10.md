---
uid: Connector_help_ETL_Systems_VTX-10
---

# ETL Systems VTX-10

This connector is made for devices such as **ETL Systems VTX-10**. ETL Systems VTX-10 is a device that makes it possible to connect outputs to inputs in a **matrix** format. In addition to that, this connector also allows you to monitor **status** info.

## About

This connector makes it possible to connect the inputs of a device to certain outputs in a matrix. Labels and locks can also be assigned to each input or output. Aside from the input and output information, status information can also be monitored, such as fan speeds or temperature.

## Installation and configuration

### Creation

#### SNMP connection (1.x.x.x version)

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.19.93.5*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

#### Serial connection (2.x.x.x version)

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.19.93.5*.
- **IP port**: The IP port of the device., e.g. 4000.

### Configuration

This connector supports redundant polling. If an SNMP request times out, a redundant connection will be used for a retry.

## Usage

### Matrix

On this page, the matrix is displayed, with all its inputs and outputs.

You can **connect one input to multiple outputs** by clicking crosspoints.

### Matrix Configuration

On this page, all info of the matrix is displayed in table format.

Here you can **synchronize labels** **between the DMA and the device**.

Note: the DMA labels are synchronized with the matrix.

### Matrix Cards

On this page, Input gain and RF levels are displayed in a table.

To view information from the table more clearly, click the **Matrix Card** page button.

### Status

In version 1.x.x.x, this page displays a table with the status of every chassis that is connected: **Temperature**, **Fan Speeds**, etc.

In version 2.x.x.x, this page displays an overview with general alarms for every matrix card. You can retrieve detailed information by selecting a module and a card number, via the page buttons at the bottom of the page.
