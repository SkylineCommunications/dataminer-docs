---
uid: Connector_help_Nevion_SDI_Router
---

# Nevion SDI Router

The Nevion SDI Router is a modular router that can vary in size depending on how many cards are installed.

## About

This connector is used to monitor the Nevion SDI Modular Router.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.6.27.10-nw1-svn24861      |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *172.32.65.38.*

SNMP Settings:

- **Port number**: The UDP port, by default *161.*
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string:** The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays system parameters and the **System OR Table**.

### Crosspoints

This page displays the **Crosspoint table**. It also contains three page buttons to the **Level Output** **Table**, **Level Input Table** and **Level Table**.

### Alarm

This page displays the **Alarm table**, which lists all alarms.

### Module

This page displays three tables: **Fan Table**, **Voltage Table** and **Temperature Table**. There are also four page buttons at the top of the page, which can be used to view the **Monitor Table**, **Reclocker Table**, **Cable EQ Table** and **Module Table.**

### Web Interface Page

On this page, you can access the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
