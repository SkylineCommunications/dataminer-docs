---
uid: Connector_help_Snell_Wilcox_Nucleus
---

# Snell Wilcox Nucleus

The Snell Wilcox Nucleus is a router controller that maps the physical inputs and outputs of the router to the software inputs (sources) and outputs (destinations).

This protocol is used to set the input/output connections of the router. It also polls and displays the input/output port information and PSU and fan fault status.

## About

The connector first retrieves the destination-specific information, which includes which output ports are connected to which input ports. It then fills in and displays the connection information in the matrix. When a new connection is set by the user, the protocol updates the destination-specific information table and and displays the new connection information in the Matrix.

### Version Info

| **Range** | **Description**                                                                                                               | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                                                                               | No                  | Yes                     |
| 2.0.0.x          | Based on 1.0.0.1. Changed the matrix size to 1024x1024. Added redundant polling. Improved the delay when setting crosspoints. | No                  | Yes                     |

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

- **IP address/host**: The polling IP of the main device/controller.
- **Device address**: When the matrix is partitioned into different levels, the level of the matrix has to be set as the device address (required in order to get/set crosspoints). The default value is *1*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public.*
- **Set community string**: The community string used when setting values on the device, by default *private*.

#### SNMP Redundant Connection

This connector supports **redundant polling** and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the redundant device/controller.
- **Device address**: When the matrix is partitioned into different levels, the level of the matrix has to be set as the device address (required in order to get/set crosspoints). The default value is *1*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

Note: If there is no redundant device, you can simply fill in the same settings as for the main device.

## Usage

### General

This page contains general information on the device, such as the **Name**, **Model**, **IP** address, **Subnet** Mask, **Gateway**, etc.

The **Matrix Size** page button allows you to customize the number of inputs and outputs of the matrix. The **Maximum Number of Inputs/Outputs** parameters are read from the device, while the **Number of Inputs/Outputs Visible** are custom settings that allow you to overrule the **Maximum Number of Inputs/Outputs**.

### Main Matrix View

This page displays the **Matrix**, where you can view and set the input/output crosspoint connections.

### Matrix Table

This page contains the destination-specific information table, which contains the input/output connection information. The input/output crosspoint connection can also be set from the table.

### Faults

This page contains the **PSU** and **Fan** fault statuses.

### I/O Status

This page contains the **input/output port** information in the Digital Video Input/Output and Installed Input/Output Ports tables.
