---
uid: Connector_help_Evertz_XRF-6L
---

# Evertz XRF-6L

This is an SNMP-based protocol for the **Evertz XRF-6L**. The XRF-6L is a modular RF signal matrix for routing and monitoring L-band, IF and other signals within a satellite communication facility.

## About

This connector was designed to work with the **Evertz XRF-6L**. With it, you can monitor and control the video router, for example connecting an output to an input. **SNMP** **Get** commands are used to read information from the device. **SNMP** **Set** commands are used to write information to the device.

### Version Info

| **Range** | **Description**                                   | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version.                                  | No                  | Yes                     |
| 2.0.0.x          | Incremental improvements to connector.            | No                  | Yes                     |
| 2.0.1.x          | Implemented DCF. Changed displayColumn to naming. | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.02 Build 41               |
| 2.0.0.x          | 1.02 Build 41               |
| 2.0.1.x          | 1.02 Build 41               |

## Installation and configuration

### Creation

This connector uses two Simple Network Management Protocol (SNMP) connections, a Main and a Secondary:

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

#### SNMP Secondary connection

This connection will be used for redundant polling, i.e. if the Main connection is not responding (timeout), the connector will automatically switch to the Secondary connection. The following input is required during element creation:

SECONDARY SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

Once created, the element can be used immediately. There are 6 pages available in the connector, showing the different parameters from the device grouped by function.

### Main View

This page displays a graphical matrix with all the inputs and outputs configured in the router. The connections between inputs and outputs are marked in black.

It is possible to control the router from this graphical matrix. To do so, simply click any of the crosspoints and the corresponding output will automatically be connected to the selected input.

### General

This page displays general information regarding the device, such as the **Connection IPs** and their **Connection Status** and the **Firmware Version**, as well as more detailed **Device Info**, **Advanced** **configuration**, **PSU Alarms**, and **Trap Config**.

### Input

This page shows the **Maximum Number of Inputs** installed and a table with the status of each input.

The **Input Control** page button opens a page where each of the inputs can be configured.

### Output

This page shows the **Maximum Number of Outputs** installed and a table with all the outputs.

In the **Output Control Table**, you can change the mapping of the matrix in the router, by selecting which input each output is connected to.

### General Purpose Register

This page displays the **Number of General Purpose Registers** and a table with all the registers.

### Router Salvos

On this page, you can save up to eight programmable commands to be executed on demand.

## DataMiner Connectivity Framework

The **2.0.1.x** connector range of the Evertz XRF-6L protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner Third-Party protocols (for instance a manager).

### Interfaces

#### Dynamic Interfaces

Physical dynamic interfaces:

- **Inputs**: Inputs are created as determined by the **Input Status Table (ID:900).**
- **Outputs:** Outputs are created as determined by the **Output Control Table (ID:200).**

### Connections

#### Internal Connections

- Between each **Input** and the connected **Output**, as determined by the parameter **Input (Output) (ID:204)**, an internal connection is created.
