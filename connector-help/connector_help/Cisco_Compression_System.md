---
uid: Connector_help_Cisco_Compression_System
---

# Cisco Compression System

The **Cisco Compression System** connector is an SNMP connector displaying some generic parameters of the Copernicus Server and also capturing specific traps that are being sent out by the device.

## About

The SNMP Agent Task Driver for Copernicus NMS (Network Management System) allows integrating the Copernicus NMS server and the devices managed and controlled by these servers in an SNMP management system. The SNMP Agent task sends traps referring to events on the Copernicus NMS server to managing clients on the network and allows full or partial control of particular devices connected to the Copernicus NMS server.

Ranges of the connector

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 4.0.0                       |

## Installation and configuration

### Creation

#### Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.150.3.3*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *public*.

## Usage

The connector contains 3 pages.

### General

This page displays general information about the Copernicus Server: **Product Version, File Version, Operations Status, Host Name** and **Startup Delay**. It also displays a message table which is filled in with the corresponding binding information of the following traps: **copMsgNew**, **copMsgAck**, **copMsgDel** and **copMsgClr**.

### Heartbeat Configuration

The page contains 3 parameters: **Alive Trap Period, Heartbeat** and **Compression System Status.**

The **copStatusAlive** trap is repeatedly generated to signal that the Copernicus network management system is active and running thus, if the trap not comes within the user-defined period of time, the Compression System Status parameter displays "not running".

### Resource Info

This page displays an SNMP table containing ID, name, location and type of the resources present on the Copernicus. The table is updated with the bindings of the following traps: **copResourceAdded**, **copResourceRemoved**, **copResourceRespondingStatusChanged** and **copResourceAlarmStatusChanged**.
