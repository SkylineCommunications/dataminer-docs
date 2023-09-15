---
uid: Connector_help_Aurora_Network_CX3001
---

# Aurora Network CX3001

The Aurora Network CX3001 connector allows the monitoring and management of multiple **Aurora Network Node NC 4000 Single DT transceivers**. Depending on the model number of the transceiver, the connector creates **Dynamic Virtual Elements type REV A or REV B** for each transceiver found in the Rev A table and Rev B table (on the Digital Transceivers page). It can also create Dynamic Virtual Elements of **type High Power EDFA** based on the High Power EDFA Table.

## About

The main element displays various information on several pages:

- The **Inventory** page contains a list of the slots that are currently being used.
- The **Communications Module** page contains information regarding the status, configuration and alarms of the communication modules.
- The **Power Supplies** page contains information regarding the power supplies and power supplies alarm monitoring of the device.
- The **Digital Transceivers** page contains tables with the different types of transceivers.
- The **Analog Transmitter** page contains a table with information about different types of transmitters.
- The **Shelf** page contains overall settings to enable or disable alarms and to verify AT/OS associations.
- The **High Power EDFA** page contains the high power EDFA slots.

### Version Info

| **Range**         | **Description**     | **DCF Integration** | **Cassandra Compliant** |
|--------------------------|---------------------|---------------------|-------------------------|
| 1.0.0.x **\[Obsolete\]** | Initial version     | No                  | No                      |
| 2.0.0.x                  | Update based on MIB | No                  | No                      |
| 2.0.1.x                  | DVE Names changed   | No                  | Yes                     |

### Exported connectors

| **Exported Connector**                                                                                                                    | **Description**                                                                    |
|------------------------------------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------|
| [Aurora Network Node NC 4000 Single DT REV A](xref:Connector_help_Aurora_Networks_Node_NC4000_Single_DT_REV_A)             | DVE for Aurora Network Node NC 4000 Single DT Rev A (Prior to version 2.0.1.x)     |
| [Aurora Network Node NC 4000 Single DT REV B](xref:Connector_help_Aurora_Networks_Node_NC_4000_Single_DT_REV_B)          | DVE for Aurora Network Node NC 4000 Single DT Rev B (Prior to version 2.0.1.x)     |
| [Aurora Network Node FA3527](xref:Connector_help_Aurora_Network_Node_FA3527)                                                       | DVE for Aurora Network Node FA3527 (Prior to version 2.0.1.x)                      |
| [Aurora Network AT3554](xref:Connector_help_Aurora_Network_AT3554)                                                                   | DVE for Aurora Network AT3554A Analog Transmitter (Prior to version 2.0.1.x)       |
| [Aurora Network CX3001 - AT3554](xref:Connector_help_Aurora_Network_CX3001_-_AT3554)                                             | DVE for Aurora Network CX3001 - AT3554 (Starting version 2.0.1.x)                  |
| [Aurora Network CX3001 - FA3527](xref:Connector_help_Aurora_Network_CX3001_-_FA3527)                                             | DVE for Aurora Network CX3001 - FA3527 (Starting version 2.0.1.x)                  |
| [Aurora Network CX3001 - NC 4000 Single DT REV A](xref:Connector_help_Aurora_Network_CX3001_-_NC_4000_Single_DT_REV_A) | DVE for Aurora Network CX3001 - NC 4000 Single DT Rev A (Starting version 2.0.1.x) |
| [Aurora Network CX3001 - NC 4000 Single DT REV B](xref:Connector_help_Aurora_Network_CX3001_-_NC_4000_Single_DT_REV_B) | DVE for Aurora Network CX3001 - NC 4000 Single DT Rev B (Starting version 2.0.1.x) |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.
- **Device address**: Not used.

SNMP Settings:

- **Port number**: The port of the connected device. The default value is *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General

This page contains information related to the slots that are currently being used. With the **Clear History** button, you can clear the history for all the virtual elements.

The inventory page contains three subpages:

- **SAP Status**: This page contains extra information related to the slots that are currently being used. This feature has been added on request, though the device does not contain this information. Polling of this table is disabled by default.
- **Slot Upgrade Status**: On this page, you can monitor upgrade actions of the slots that are currently being used. This feature has been added on request, though the device does not contain this information. Polling of this table is disabled by default.
- **Slot SFP Status**: This feature has been added on request, though no such table exists at this point. Polling of this table is disabled by default.

### Communications Module

This page contains a number of tables:

- The **CX Status** table shows the status of the communication modules.
- The **CX Config** table contains information regarding the communication module management configuration entries.
- The **CX Module Alarms Status** table contains detailed alarm information for the communication module.
- The **CX Card Alarm** **Status** table contains detailed alarms regarding the environment and voltage usage.

In order to commit all the changes made in the CX Config Table to the device, you must press the **Commit** button.

### Power Supplies

This page contains two tables:

- The **Power Supplies Units** table contains information regarding the current and statistical values for the power supply modules.
- The **Power Supplies Units Alarm Status** table shows the status of the individual alarm properties.

### Digital Transceivers

This page contains the **Rev A** table and **Rev B** table. These tables display the transceivers for which the connector should create Rev A and Rev B Dynamic Virtual Elements, respectively.

This page also has two subpages, which you can access through page buttons:

- **Module**: Displays the table **Module Nodes**, containing a list of module information for the nodes.
- **Alarms**: Displays the **Normalized Alarms** table, containing the values of the normalized alarms.

### Analog Transmitter

This page contains a table with information about the **slots** in use. This feature has been added on request, though the device does not contain this information. Polling of this table is disabled by default.

A page button to information on the **AT3554A transmitter** is also available. It displays the available AT3554A transmitters and can be used to create the Dynamic Virtual Elements for each AT3554A transmitter.

### Shelf

This page mainly contains alarm settings and information about **alarms**. The possibility to control the display has also been added, though this is not supported by the device at this point. There are buttons with which you can refresh data, save the configuration, reload the saved configuration and clear the history of all existing modules/cards.

This page also contains a subpage, **At-Os Associations**, which displays a table with information regarding the AT-OS associations. The configuration of these settings can be saved here. Polling of this table is disabled by default, because at this point no such information can be found on the device.

### High Power EDFA

This page contains the **High Power EDFA** table. This table contains the High Power EDFA slot, model FA3527M, with its details.

### Web Interface

This page displays the web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
