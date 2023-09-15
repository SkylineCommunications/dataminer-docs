---
uid: Connector_help_Evertz_MVP_OV
---

# Evertz MVP OV

The MVP is a multi-image display and monitoring system. It provides a highly flexible, intuitive and comprehensive approach to virtual wall monitor applications. With the MVP, any input signal can be displayed on any output monitor without the need for DAs or upstream monitor routers.

## About

This connector is intended to work with the **Evertz MVP OV** card. It was designed to provide status monitoring and fault trigger parameters.

### Version Info

| **Range**     | **Description**                                                                                  | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | SNMP set not working.                                                                            | No                  | Yes                     |
| 2.0.0.x \[SLC Main\] | Now uses DVEs for each bus address instead of using the bus address to look at a single channel. | No                  | Yes                     |

### Supported Firmware Versions

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and Configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Range *1-8* (obsolete from version 2.0.0.1 onwards).

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### Input

On this page, you can monitor VistaLINK parameters, such as **Loss of Video Sync**, **EDH Errors**, **Picture** settings and **Loss of Audio**.

The page also displays the **Inputs Table**, with information about the different faults for each input. For the display key (IDX) of this table, two different formats can be selected using the **Inputs DisplayKey Format** toggle button.

This page also contains the **Input Settings Control** table.

### Notifications

This page displays two tables, the **Video** and **Audio Notifications Tables.**

### Video Fault

This page displays general parameters related to errors, such as **Error Duration Video**, **CC(1,2,3) Errors**, **Text Error** and **VITC Errors**.

### Audio Fault

This page displays the **Audio Definition** and **Audio Pair Definition Tables**.

### Hardware Control

This page contains general parameters such as the **System Status**, **Tag Selector**, **Input Tags (A and B)**, **Trap Tag** and **MVP IDs**. The Input + Bus name is used to create the DVE.

### Audio Loudness

On this page, you can configure the **Loudness Measure Audio Program** (1 to 8) and **Audio Loud** settings.

### Audio Notifications

This page displays the **Management Fault Audio 2** and **Management Audio 3 Tables**.

### Dolby E

This page displays the Dolby E Definition Table.

### Group 7 Notifications

This page displays the Group 7 Notifications Table.

### WST GPI

On this page, you can configure the WST GPI parameters.

### EIA 708

On this page, you can configure the EIA 708 fault definition parameters.

### Monitor Control

On this page, you can configure parameters related to the monitoring/reporting of faults such as **Start**, **Stop**, **Reset**, etc.

### RCTL GPI

On this page, you can configure the RCTL GPI Timecode parameters.

### SCTE 104 GPI

On this page, you can configure the SCTE 104 GPI error on time.
