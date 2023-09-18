---
uid: Connector_help_IneoQuest_iVMS
---

# IneoQuest iVMS

The IneoQuest iVMS shows all the current alarms from the different probes in the iVMS system and makes it possible to represent each probe separately in a DataMiner System.

It will send a **SOAP** command every minute to receive a list with available probes and their statuses in the iVMS system. For each new probe in that list, a **Dynamic Virtual Element (DVE)** will automatically be created for separate monitoring. The user can decide afterwards whether they want to keep the DVE or remove it.

The **SNMP** interface is used to receive L4 traps from the iVMS system and to back up the trap tables in case a trap was not received (e.g. because of network problems, the element that is not active, etc.).

## About

### Version Info

| **Range**            | **Description**                                                | **DCF Integration** | **Cassandra Compliant** |
|----------------------|----------------------------------------------------------------|---------------------|-------------------------|
| 4.0.0.x              | Current version                                                | No                  | Yes                     |
| 4.0.1.x \[SLC Main\] | Connector revision with fixed format name of virtual elements. | No                  | Yes                     |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 4.0.0.x   | ó 5.11                 |
| 4.0.1.x   | ó 5.11                 |

### Exported connectors

| **Exported Connector**                                                 | **Description**                                                |
|------------------------------------------------------------------------|----------------------------------------------------------------|
| [IneoQuest iVMS Probe](xref:Connector_help_IneoQuest_iVMS_Probe)   | DVE connector for IneoQuest iVMS Probe \[exported by 4.0.0.x\] |
| [IneoQuest iVMS - Probe](xref:Connector_help_IneoQuest_iVMS_Probe) | DVE connector for IneoQuest iVMS Probe \[exported by 4.0.1.x\] |

## Configuration

### Connections

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

#### SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

#### SNMP Settings:

- **Port number**: The port of the connected device, by default ***8001***.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

#### HTTP connection

This connector uses an HTTP connection and requires the following input during element creation:

#### HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP Port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

## Usage

The **IneoQuest iVMS** connector can be used to create two types of DataMiner elements: a **main element** representing the main controller, and a **dynamic virtual element** for each probe.

For each probe in the iVMS system, a DVE is automatically created with a specific name (the main element name followed by a dot and then the name of the probe, for instance: *iVMS SLC.mcp-DVAMDD*).

### General

This page contains two tables, as well as a number of parameters:

- The **API Path** parameter allows you to configure where all commands will be sent.
- The **Probes Overview** table displays an overview of the probes in the iVMS system and allows you to specify if a DVE will be created/deleted for a specific probe in the iVMS system.
- The **Heartbeat** table shows the heartbeat of the iVMS system.
- The **Firmware Version** parameter can be used to configure the URL when the firmware version is updated.
- The **Suffix Unavailable Probe** parameter adds the suffix for the DVE elements that are in the "deleted" state
- The **Auto Delete Switch** parameter allows you to configure the automatic deletion of DVEs.

### Flows

This page displays information related to the flows defined by the iVMS. Two tables are displayed:

- The **Flow Status Table** contains the status of all the flows defined in the iVMS for each probe.
- The **Flow Table Aggregation** contains statistics for each flow defined in the iVMS.

### Programs

This page displays information related to the programs defined by the iVMS. Two tables are displayed:

- The **Program Status Table** contains the status of all the programs defined in the iVMS for each probe and flow.
- The **Program Table Aggregation** contains statistics for each program defined in the iVMS. The **IDX** for the Program Table Aggregation can be changed using a drop-down box.

### Alarm

This page contains a table for every type of alarm (**System Alarm Table**, **Program Alarm Table**, and **Transport Alarm Table**). You can delete one alarm entry from a table or delete all entries in the table.

### Main View

This page displays information related to the status of the probes.
