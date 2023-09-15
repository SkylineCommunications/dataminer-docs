---
uid: Connector_help_RF_Design_FlexLink_S2
---

# RF Design FlexLink S2

This connector is used to manage RF Design FlexLink S2 family switches.

## About

This connector supports switches from the RF Design FlexLink S2 family and is capable of managing a matrix of up to 256x256 crosspoints with **multiple outputs per input and one input per output**.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |
| 2.0.0.x          | Initial version | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 2.0.0.x          | Unknown                     |

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

### Input

This page contains the **Inputs** table, with the **Name** of each input.

### Output

This page contains the **Outputs** table, with the **Input Selection** for each output as well as the **Name** of each output.

### Matrix (2.0.0.5)

This page displays a matrix with the size determined in the input/output configuration.

In this matrix, you can select crosspoints to define which input is connected to which output. You can also change the name of inputs and outputs by renaming the labels of the matrix.

### Traps

This page displays the received traps in the **Traps** table, as well as the total **Trap Count**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
