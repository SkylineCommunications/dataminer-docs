---
uid: Connector_help_RF_Design_FlexLink_K7
---

# RF Design FlexLink K7

This connector is used to manage RF Design FlexLink K7 family switches.

## About

The RF Design FlexLink K7 is a scalable L-Band switch matrix system in a 6RU/19" rack mount design, supporting extended L-Band frequency range (850 to 2450 MHz) and Ka-Band and HTS applications. It allows various switch/routing configurations from 8:8 to 256:256 (in increments of 8) with multiple outputs per input and one input per output.

### Version Info

| **Range**     | **Description**                                                                                                     | **DCF Integration** | **Cassandra Compliant** |
|----------------------|---------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version                                                                                                     | Yes                 | Yes                     |
| 1.0.1.x \[SLC Main\] | MatrixHelper class updated. Alarm Status and Threshold Alarm traps implemented. Changes in parameters descriptions. | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.0.1.x          | Unknown                     |

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

This page displays information about the device hardware, the **Unit** **Status**, the **PSU Alarms**, the **Fan Alarms** and the **Input**/**Output** configuration.

### Input

This page contains the **Inputs** table, with the name of each input and related info, e.g. **RF Power**, **Gain**, Failure Alarms, Thresholds, etc.

### Output

This page contains the **Outputs** table, with the **Input Selected** for each output as well as the **Name** of each output. It also displays **RF** **Power**, **Failure** **Alarms**, **Locked**, **Backup Rule Status** and **Backup Input Selected**.

### Matrix

This page displays a matrix with the size determined in the input/output configuration.

In this **Matrix**, you can select crosspoints to define which input is connected to which output. You can also change the name of inputs and outputs by renaming the labels of the matrix.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
