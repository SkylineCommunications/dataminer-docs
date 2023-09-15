---
uid: Connector_help_ADVA_Optical_Networking_FSP3000
---

# ADVA Optical Networking FSP3000

The ADVA Optical Networking FSP3000 is an optical data transport solution.

## About

The purpose of this connector is to retrieve the entity table, using the SNMP protocol. The entity table contains a list of all instances of all cards in the chassis.

This is the main connector needed to retrieve information of the different cards in the chassis. Specific elements that are created separately for the different cards, use the information in this table to know the instance IDs of all entities.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | All firmware versions       |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default value: *public*).
- **Set community string**: The community string used when setting values on the device (default value: *private*).

### Configuration

No additional configuration is necessary in the element.

## Usage

### General

This page contains parameters with general information of the device: system name, description, contact and location.

Also, the entity table can be found on this page, with information of the different parts of the installed chassis slot cards.

### Embedded Web Server

Displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
