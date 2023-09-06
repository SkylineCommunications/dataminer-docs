---
uid: Connector_help_RF_Design_FlexLink_K2
---

# RF Design FlexLink K2

The RF Design FlexLink K2 is a series of switch matrices that handle the switching and routing of inputs and outputs.

This driver supports switches from the RF Design FlexLink K2 family and is capable of managing a matrix of up to 256 x 256 crosspoints with **multiple outputs per input and one input per output**.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: The device address.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the data pages detailed below.

### General

This page displays information about the device hardware, the device **Status**, the **PSU** **Status** and the **Input**/**Output** configuration.

### Input

This page contains the **Inputs** table. In this table, you can configure the **Name** of each input.

In version 1.0.0.2, the **Advanced** page button displays a semicolon-separated list of the input names.

### Output

This page contains the **Outputs** table, with the **Input Selection** for each output as well as the **Name** of each output.

With the **Revert** button, you can set a crosspoint back to the previous input.

### Matrix

This page displays a matrix with the size determined in the input/output configuration.

In this matrix, you can select crosspoints to define which input is connected to which output. You can also change the name of inputs and outputs by renaming the labels of the matrix.

### Traps

This page displays the received traps in the **Traps** table, as well as the total **Trap Count**.

Via the **Manage Traps** page button, you can change how traps are managed and removed in the **Traps** table.
