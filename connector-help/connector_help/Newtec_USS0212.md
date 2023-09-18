---
uid: Connector_help_Newtec_USS0212
---

# Newtec USS0212

The **Newtec USS0212** connector is an **SNMP** connector used to monitor and control the Newtec USS0212.

## About

The connector uses **SNMP** to retrieve data from the **redundancy switch**. It is also possible to configure some of these parameters using this connector.

**DCF** has also been implemented and will create an internal connection between the active input and the output.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.1.8                       |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains general information on this unit along with the available **Network Interfaces**.

### Configuration

This page contains the **configuration** **parameters** for the unit. These are mainly used to configure the **switching** **triggers** and **actions** for the redundancy switch.

### Operations

This page displays information about the operation of the device.

### Alarms

This page contains the **Alarms** table with the state of each of the possible alarms.

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

DCF has been implemented since the initial version of this connector. Note that DataMiner version **8.5.4** is the minimum required version to support DCF.

Below, you can find an overview of the DCF implementation in the connector itself. Note that DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **RF Input Main** (in): the main RF input
- **RF Input Backup** (in): the backup RF input
- **RF Output** (out): the RF output

### Connections

#### Internal Connections

- Between **RF Input Main** and **RF Output**, an internal connection is made when **System State** is *Normal* or *Normal* *Degraded.*
- Between **RF Input Backup** and **RF Output**, an internal connection is made when **System State** is *Redundant* or *Redundant* *Degraded.*
