---
uid: Connector_help_HP_3PAR_StoreServ
---

# HP 3PAR StoreServ

The **HP 3PAR StoreServ** connector monitors a unit using SNMP and an HTTP connection.

## About

The **HP 3PAR StoreServ** connector updates an alarm table every 5 seconds, receives traps from the device and displays them in three tables.
It also monitors several parameters and tables using an HTTP connection.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.1.x          | Initial version | Yes                 | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.1.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: *161*
- **Get community string**: *dataminer*
- **Set community string**: *dataminer*

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: *5988*.
- **Device address**: The device address, by default *ByPassProxy*.

## Usage

### General Page

This page displays the **System Description**, **Object ID**, **Up Time**, **Contact**, **Name**, **Location**, **Services**, **OR Table** and **Last Change**, as well as **Authentication Failure Traps**, **SNMP Silent Drops** and **Proxy Drops**.

### Disk Page

This page displays the **Disk Table**, with disk information for this particular device.

### Alarms Page

This page displays the **Alert Table**, listing all the alarms for this particular device.

### Controller Node

This page displays the **Controller Table**, with information about the **System Nodes** for this particular device.

### Storage System

This page displays the **Storage System Table**, with information about the **Licenses** of the storage system.

### Fibre Channel Ports

This page displays the **Fibre Channel Table**, with information about the **Fibre Channel Ports**.

### SAS Ports

This page displays the **SAS Ports Table**, with information about the SAS ports, i.e. the **WWN**, **State**, **Mode**, **Rate**, **Connected Device Type**, **Connected Device** and **Topology**.

### Fans

This page displays the **Fans Table**, with information about the **Fans Ports**, i.e. the **Device ID**, **Element Name**, **State** and **Speed**.

### Power Supply

This page displays the **Power Supply Table**, with information about the **Power Supply Ports**, i.e. the **ID**, **Model**, **Manufacturer**, **Model Name**, **ACState, DC State** and **State**.

### Admin

On this page, you can specify the **Username** and **Password**.
