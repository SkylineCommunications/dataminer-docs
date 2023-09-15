---
uid: Connector_help_Grass_Valley_Jupiter_VM3000
---

# Grass Valley Jupiter VM3000

The Jupiter VM 3000 system controller is a (matrix) control system from Grass Valley that supports a range of distribution switching systems, machine control and remote control panels.

## About

This connector polls data from the device using a serial connection. It imports two files with the list of inputs and outputs. The maximum size of the matrix is 1000x1000.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 7.4                         |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device.
  - **Stopbits**: Stopbits specified in the manual of the device.
  - **Parity**: Parity specified in the manual of the device.
  - **FlowControl**: FlowControl specified in the manual of the device.
- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

## Usage

### General

On this page, you can configure a path with the **File Directory** parameter in order to select the **Inputs File** (\*.ist) and **Outputs File** (\*.ost). The **Import Files** button will enter the data into the **Inputs** and **Outputs** tables and will start polling data from the device. The **Outputs** table contains the columns **Lock State** and **Lock Instance**. If the **Lock State** is "Not Locked", then the **Lock Instance** is "Not Available".

The **Matrix Labels** and **Matrix Locks** page buttons display information about the labels of the inputs and outputs and about the enabled or disabled locks.

The **Communication** parameter displays the state of the communication with the device.

The **Advanced** page button displays the parameter **Input Names** with a list of the input names, separated by semicolons.

### Main View

This page displays the crosspoints of the **Matrix** and allows you to set new crosspoints and lock inputs or outputs.

## DataMiner Connectivity Framework

The **1.0.0.x** connector range of the Jupiter VM 3000 protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party protocols (for instance a manager).

### Interfaces

#### Dynamic Interfaces

Physical dynamic interfaces:

- **Matrix** is the created physical dynamic interface and the interface type is **inout**.

### Connections

#### Internal Connections

- Between the **Matrix** inputs and outputs, an internal connection is created.
