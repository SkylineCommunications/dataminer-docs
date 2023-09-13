---
uid: Connector_help_Leitch_Matrix_SNMP
---

# Leitch Matrix SNMP

This driver can be used to monitor and control Leitch Matrix SNMP equipment. It allows you to monitor the existing matrix connections and the status of each input and output, and also to alter the connections, lock the outputs and label the inputs and outputs.

For short-term monitoring, the driver polls the status of the inputs and the outputs every 30 seconds. For medium to long-term monitoring, it polls every minute, 10 minutes, and hour. The driver uses SNMP to poll and control the current matrix connections, the physical state of the inputs and outputs, the labels assigned to the inputs and outputs, and the lock status of the outputs.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.1.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.1.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.1.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device (default: *1;* range: *0* - *16*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver consists of the data pages detailed below.

### Main View

The matrix control on this page allows you to monitor and change the crosspoints of the matrix.

### Table View

On this page, the Output table lists the output and input numbers. In addition, three buttons are available that allow you to change the layout to Table, Matrix or Table & Matrix.

The **Advanced** page button opens a subpage where you can set crosspoints.

### Status

This page contains general and status information about the device. This includes the Hardware Slots Table, which contains information about cards detected in the different slots.

Several page buttons are available:

- **IP Addresses**: Displays the Device IP Setting Table.
- **PSU Status**: Displays the Device PSU Setting Table.
- **Sync Status**: Displays the Device Sync Setting Table.
- **Fan Status**: Displays the Device Fans Setting Table.
- **Polling**: Allows you to enable or disable polling for different parameters.
- **Normalized Values**: Displays a table with the normalized values for the Hardware Slots Table.

### Matrix Configuration

This page displays the Physical Matrix Input and Output Table. It also displays the Maximum Number of Inputs and Outputs and allows you to configure the Number of Inputs and Output Visible.

The following page buttons are available:

- **Polling**: Allows you to enable or disable polling for different parameters.
- **Normalized Values**: Displays two tables with the normalized values for the Input and Output table.
- **Advanced Labels**: Allows you to adjust the labels of the matrix.

### Monitoring Outputs

At the top of this page, you can set the Monitoring Output Level and ID. Below this, the Monitoring Output Table provides an overview of the Monitoring Level, Output and Input.

## DataMiner Connectivity Framework

The **1.1.0.x** driver range of the Leitch Matrix SNMP protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Dynamic interfaces

Physical dynamic interfaces:

- Description of the interface: the physical dynamic interface is created for the **Matrix** parameter and is of the type **inout**.
