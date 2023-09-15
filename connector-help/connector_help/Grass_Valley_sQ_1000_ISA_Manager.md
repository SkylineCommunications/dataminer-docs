---
uid: Connector_help_Grass_Valley_sQ_1000_ISA_Manager
---

# Grass Valley sQ 1000 ISA Manager

The **Grass Valley sQ 1000 ISA Manager** connector is used to monitor the ISA System Component of a Grass Valley sQ 1000 Series Media Server.

## About

The Grass Valley sQ 1000 Series Media Servers are SD/HD/4K UHD media servers for news and sports editing, replay and playout. They provide an intelligent, scalable and media-optimized storage system, delivering sustained multi-year 24x7 operation for high-pressure, fast-turnaround workflows for news and sports.

This connector uses an SNMPv1 interface to communicate with a **Grass Valley sQ 1000 ISA Manager** device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection:

- **IP address/host**: The polling IP of the device, e.g. *10.145.1.12*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read values from the device. The default value is *public*.
- **Set community string**: The community string required to set values on the device. The default value is *public*.

## Usage

### General Page

This page displays generic **system information** and **status** parameters.

### Interfaces Page

This page displays a table containing **statistics** regarding the **system interfaces**.

### Configuration Page

This page displays four tables with configuration information related to the system **memory pools**, **servers**, **RAIDs** (Redundant Array of Independent Disks) and **databases**.

### Statistics Page

This page contains statistical information regarding system **network requests**, **cluster read/write counters** and **thread processing**.

The **Databases** and **Zones** page buttons at the bottom of the page provide access to **DB connection** and **production zone statistics**.

### Traps Page

On this page, the **Trap Events** table displays metadata related to the **most recent system trap events**.

Via the **Clean Up Config** page button, you can configure the automatic cleanup of the Trap Events table.

### Web Interface

This page can be used to access the device web user interface. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
