---
uid: Connector_help_Advantech_AMT_Monitor_and_Control_Panel
---

# Advantech AMT Monitor and Control Panel

This is an SNMP connector that shows the status of the different parameters of an Advantech AMT Monitor and Control Panel.

The Advantech AMT Monitor and Control Panel consists of a control panel and several modules (SSPAs, Transceiver).

The connector shows all information in table format, the same way as it is stored in SNMP. This is also the case even if a table only consists of one row. There is no web interface to control the device.

## About

### Version Info

| **Range**            | **Description**                           | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-------------------------------------------|---------------------|-------------------------|
| 1.0.1.x              | Initial version.                          | No                  | Yes                     |
| 1.0.2.x              | DVE integration.                          | No                  | Yes                     |
| 1.1.0.x \[Obsolete\] | Removed parameters that were not working. | No                  | Yes                     |
| 1.2.0.x \[SLC Main\] | New MIBs OIDs change; parameters removed. | No                  | Yes                     |

### Product Info

| **Range** | **Supported Firmware**          |
|-----------|---------------------------------|
| 1.0.2.x   | Unknown                         |
| 1.1.0.x   | Unknown                         |
| 1.2.0.x   | Software version V0000 (180613) |

### Exported Connectors

| **Exported Connector**                                                                                                       | **Description**                               |
|------------------------------------------------------------------------------------------------------------------------------|-----------------------------------------------|
| [Advantech AMT Monitor and Control Panel Unit](xref:Connector_help_Advantech_AMT_Monitor_and_Control_Panel_Unit) | SSPAs, Transceiver. Not in the 1.2.0.x range. |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## How to Use

### General

This page contains general configuration information for the interfaces of the device: the **Unit Serial Number**, **PS Voltages**, **Shroud Temperature**, and **Port and** **MAC** information of the **Defined Units**.

There is also a **Reset Control Panel** option.

### Units

This page contains information about the connected units. It also allows you to configure the creation of DVEs and the names of the exported elements.

### Switches (No Longer available for range 1.2.0.x)

This page contains the status of the switches connected to the device.

### Network

This page contains network information including **IP**, **UDP**, and **Interfaces**.
