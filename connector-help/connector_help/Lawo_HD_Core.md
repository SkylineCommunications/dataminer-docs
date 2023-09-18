---
uid: Connector_help_Lawo_HD_Core
---

# Lawo HD Core

With this connector you can retrieve information and modify settings from the Lawo HD Core.

## About

The Lawo HD Core is the core component of the products **Nova73 HD** and **mc2 series HD**.

### Version Info

| **Range** | **Description**                | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                | No                  | Yes                     |
| 1.0.1.x          | Changed primary keys of table. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.0.1.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains a module table with information regarding each module.

### Router

This page contains a table with router-related information.

### GPIO States

This page contains a general-purpose input and output table of states.

### Control Ports

This page contains a table with information regarding the configured ports and their status.

### Dallis

This page provides information about the **Digital Audio Line Level Interface System**, which is a flexible I/O system that provides a broad range of plug-in cards.

### Web Interface

This page provides access to the web interface of the device from within DataMiner.

Note that the client machine must be able to access the device, as otherwise it will not be possible to open the web interface. This means that port 80 must be opened/allowed on all Ethernet switches/firewalls on the network path.
