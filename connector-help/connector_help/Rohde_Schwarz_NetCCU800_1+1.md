---
uid: Connector_help_Rohde_Schwarz_NetCCU800_1+1
---

# Rohde Schwarz NetCCU800 1+1

This connector is developed for devices such as the **Rohde Schwarz NetCCU800 1+1**. It polls general and transmitter-specific parameters.

## About

This connector polls information about the **Rohde Schwarz NetCCU800 1+1** in general and about its transmitters. For each transmitter, a DVE is created.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 2.0.0.x \[SLC Main\] | Connector review   | Yes                 | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 2.0.0.x          | Unknown                     |

### Exported connectors

| **Exported Connector**                                                                          | **Description**                                     |
|------------------------------------------------------------------------------------------------|-----------------------------------------------------|
| [Rohde Schwarz NetCCU800 1+1 TxA](xref:Connector_help_Rohde_Schwarz_NetCCU800_1%2B1_TxA) | Exported connector containing info about transmitter A |
| [Rohde Schwarz NetCCU800 1+1 TxB](xref:Connector_help_Rohde_Schwarz_NetCCU800_1%2B1_TxB) | Exported connector containing info about transmitter B |

## Installation and configuration

### Creation

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.17.250.16*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage - Main elements

### General

This page contains general device and trap information.

### DVB N+1

This page displays general DVB-specific parameters. It also contains an overview of all primary transmitters (A transmitters).

### NSU and Tx Events

This page contains two tables with events concerning NSU and concerning the transmitters.

### Transmitter Overview

This page displays a table with all the transmitters, including the reserve transmitter.

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it may not be possible to open the web interface.

## Usage - Dynamic Virtual Elements

For each DVE, five pages are displayed, as detailed below.

### Exciter Input Table

This page displays a table with all channels.

### Exciter Status

This page displays RF and SFN information.

### Summary Info

On this page, you can monitor summary status information for the transmitter.

### Transmitter Commands

On this page, you can configure settings of the transmitter.

### Transmitter Status

This page displays more detailed transmitter status information.

## DataMiner Connectivity Framework

The **2.0.0.15** range of the Rohde Schwarz NetCCU800 1+1 connector supports the usage of DCF and can only be used on a DMA with **9.0.3** as the minimum version.

Connectivity for all exported connectors is managed by this connector.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **Management** **Port**: input type

#### Dynamic Interfaces

Physical dynamic interfaces:

For each transmitter A (DVE) in the **Summary Info Tx Table A**, the following interfaces are created:

- **ASI 1**: input type
- **ASI 2**: input type
- **1PPS Ref**: input type
- **10MHz Ref**: input type
- **Inout**: inout type
- **Output**: output type

For each transmitter B (DVE) in the **Summary Info Tx Table B**, the following interface is created.

- **Inout**: inout type

### Connections

#### Internal Connections

- For each transmitter A, either the **ASI 1 input** or the **ASI 2 input** is connected to the **inout** of the transmitter A.
- The **inout** interface is connected to the **output** of the corresponding transmitter A.

#### External Connections

- If the transmitter A is in redundancy switchover, the **ASI 1 input** or **ASI 2 input** is connected to the **inout** of transmitter B.
- This **inout** is connected to the **output** of the corresponding transmitter A.
