---
uid: Connector_help_Sofia_Digital_Guide_Manager
---

# Sofia Digital Guide Manager

With this driver, you can monitor the Sofia Digital Guide Manager and view events and informations about the available serversand channels.

## About

This driver uses **SNMP** in order to monitor a Sofia Digital Guide Manager. The **SNMP** is used to retrieve system specific informations.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | 3.16.7                      |

## Installation and configuration

### Creation

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

General Page

This page displays general information regarding the Sofia Digital Management. Examples are **Version**, **Description** and **Contact**.

Server

This page displays all information of the servers. Examples are **Name**, **Status** and **Type**.

Channels

This page displays all information of the channels. Examples are **Name**, **Status**, **Code** and **Update**.

Webinterface

This page displays the web interface of the device, from where it is possible to perform other actions.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
