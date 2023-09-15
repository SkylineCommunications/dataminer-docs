---
uid: Connector_help_Foxcom_Platinum_PL700_Manager
---

# Foxcom Platinum PL700 Manager

This connector can be used to manage and control fiberoptic cards, redundancy switches, power supplies and communication cards. It uses an SNMP connection to communicate with the device.

The connector supports alarm logging, including transmitter and receiver RF and optical faults. Monitoring features include ambient temperature and RF/optical input and output power, as well as all the usual general parameters available for this type of hardware, such as the part and device number.

This connector exports several other connectors based on the information retrieved from the hardware. The list of exported connectors can be found in the "Exported components" section of this page.

## About

### Version Info

| **Range**            | **Description**                                                                                       | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                                                                                      | Yes                 | Yes                     |
| 1.0.1.x \[Obsolete\] | Support for Unicode. **Impact:** Element data and trend data need to be removed entirely.             | Yes                 | Yes                     |
| 1.0.2.x \[SLC Main\] | Support for additional modules. **Impact:** Duplicate description of 2 parameters, very small impact. | Yes                 | Yes                     |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3.08.29                |
| 1.0.1.x   | 3.08.29                |

### Exported components

| **Exported Connector**                                                                                                 | **Description**   |
|------------------------------------------------------------------------------------------------------------------------|-------------------|
| [Foxcom Platinum PL700 Manager - PL7011](xref:Connector_help_Foxcom_Platinum_PL700_Manager_-_PL7011)         | Power supply      |
| [Foxcom Platinum PL700 Manager - PL7220T](xref:Connector_help_Foxcom_Platinum_PL700_Manager_-_PL7220T)       | Transmission card |
| [Foxcom Platinum PL700 Manager - PL7220R](xref:Connector_help_Foxcom_Platinum_PL700_Manager_-_PL7220R)       | Receiving card    |
| [Foxcom Platinum PL700 Manager - PL7230T](xref:Connector_help_Foxcom_Platinum_PL700_Manager_-_PL7230T)       | Transmission card |
| [Foxcom Platinum PL700 Manager - PL7230R](xref:Connector_help_Foxcom_Platinum_PL700_Manager_-_PL7230R)       | Receiving card    |
| [Foxcom Platinum PL700 Manager - PL7611](xref:Connector_help_Foxcom_Platinum_PL700_Manager_-_PL7611)         | Power supply      |
| [Foxcom Platinum PL700 Manager - PL7240T](xref:Connector_help_Foxcom_Platinum_PL700_Manager_-_PL7240T)       | Transmission card |
| [Foxcom Platinum PL700 Manager - PL7240R](xref:Connector_help_Foxcom_Platinum_PL700_Manager_-_PL7240R)       | Receiving card    |
| [Foxcom Platinum PL700 Manager - PL2 7220R](xref:Connector_help_Foxcom_Platinum_PL700_Manager_-_PL2_7220R) | Receiving card    |
| [Foxcom Platinum PL700 Manager - PL2 7220T](xref:Connector_help_Foxcom_Platinum_PL700_Manager_-_PL2_7220T) | Transmitting card |

## Configuration

### Connections

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: By default *1610*.
- **Get community string**: *public.*
- **Set community string**: *private*.

## Usage

### General Information

This is the default page of the connector. It is used for two main purposes: viewing general information about the hardware and controlling the DVE creation process.

To **create DVE** elements, click the buttons for the corresponding cards. You can also create all the viable DVEs with the **Create** button on the **Modules** page. For any card that does not have a DVE connector, no element will be created.

### DVE Pages

Each type of DVE card can be managed on a specific subpage.

### System

This page contains parameters related to the **Main Control Processor**, such as status, temperature, hardware and software revision.

### Foxcom General

This page contains parameters related to files and commands, such as IP address, download status, progress and device slot. This information is not exported to the child elements and is only available here. The page contains both the general status and the configuration of system management.

### Slots

This page contains all the status and configuration tables for each slot. You can reset the modules on this page. You can also handle the time configuration for the cards and check their **running temperatures**, different channel statuses, **voltages**, and input/output **power**.

### PSU

This page contains power supply information, specifically the **alarm status** for all the power supplies in the system. You can also check the output information here, specifically the **Voltage**, **Current**, and **Power** output of the system's power supplies.

### Modules

This page contains the tables used to export the DVEs.

## DataMiner Connectivity Framework

The 1.0.0.1 range of the Platinum PL700 Manager connector supports the usage of DCF and can only be used on a DMA with **9.0.0** as the minimum version.

Connectivity for all exported connectors is managed by this connector.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Virtual fixed interfaces:

- **Input** interface, type **in**.
- **Output** interface, type **out**.

### Connections

#### Internal Connections

- Between **Input** and **Output** interfaces, an internal connection is created.
