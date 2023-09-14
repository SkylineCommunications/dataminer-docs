---
uid: Connector_help_ETL_Systems_22302
---

# ETL Systems 22302

L-band splitter. Modular system chassis for matrix systems that holds up to 32 hot-swap splitter modules and also benefits from dual redundant power supplies and CPU module.

## About

This connector requests **System**, **CPU**, **PSU** and **Module** information from the device. It is possible to configure the traps and **RF Detector** Settings.

## Installation and configuration

### Creation

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string used when reading values from the device, i.e. *public*.
- **Set community string**: The community string used when setting values on the device, i.e. *private*.

## Usage

### General

This page contains **System** and **CPU** parameters and a **PSU** **Readings** table.

### Module Info

This page contains a **Module Info** table. For every module in the chassis, there is a row in the table that contains more detailed information, such as **Summary info, Firmware info, status for PSUs and Amplifiers** ...

### Configuration

This page contains **Configuration** data for traps and for the **RF Detector**.

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
