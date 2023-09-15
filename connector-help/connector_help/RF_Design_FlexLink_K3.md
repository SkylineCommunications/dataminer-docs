---
uid: Connector_help_RF_Design_FlexLink_K3
---

# RF Design FlexLink K3

The FlexLink K3 features a professional and flexible L-Band switch matrix system designed as a modular 6RU/19" master/slave chassis concept. The FlexLink K3 performs as an L-Band routing platform where any input can be routed to any or all outputs.

## About

This connector is used to manage RF Design FlexLink K3 family switches.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | Yes                 | Yes                     |

### Product Info

| **Range**     | **Device Firmware Version** |
|----------------------|-----------------------------|
| 1.0.0.x \[SLC Main\] | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: The device address.
- **Bus address**: Not required.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays information about the device hardware, the **Unit** **Status**, the **PSU Status** and the **Input**/**Output** configuration.

### Input

This page contains the **Inputs** table, with the name of each input and related info, e.g. **RF Power**, **Gain**, Failure Alarms, Thresholds, etc.

### Output

This page contains the **Outputs** table, with the **Input Selected** for each output as well as the **Name** of each output.

### Matrix

This page displays a matrix with the size determined in the input/output configuration.

In this **Matrix**, you can select crosspoints to define which input is connected to which output. You can also change the name of inputs and outputs by renaming the labels of the matrix.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
