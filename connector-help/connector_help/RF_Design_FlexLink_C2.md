---
uid: Connector_help_RF_Design_FlexLink_C2
---

# RF Design FlexLink C2

This connector is used to manage the RF Design "FlexLink C2" series for non-redundant operations. The "FlexLink C2" series is available with 2:1, 4:1, 8:1, 16:1, 32:1 and 64:1 switching configurations.

## About

This connector supports switches from the RF Design "FlexLink C2" series and is capable of managing a matrix of up to 64x1 crosspoints with **multiple outputs per input and one input per output**.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.3.25.D15.S26.H19.21.11.4  |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: The device address.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays information about the device hardware, the device **Status**, the **PSU** **Status** and the **Input**/**Output** configuration.

### Input/Output

This page contains the **Inputs** table, with the name of each input, and the **Outputs** table, with the **Input Selection** for each output as well as the name of each output.

### Matrix

This page displays a **Matrix** with the size determined in the input/output configuration.

In this matrix, you can select crosspoints to define which input is connected to which output. You can also change the name of inputs and outputs by renaming the labels of the matrix.

### Traps

This page displays the received traps in the **Traps** table, as well as the total **Trap Count**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
