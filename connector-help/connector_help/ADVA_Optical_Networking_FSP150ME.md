---
uid: Connector_help_ADVA_Optical_Networking_FSP150ME
---

# ADVA Optical Networking FSP150ME

## About

The **FSP150ME (Fiber Service Platform)** is an aggregation device, essentially a packet multiplexer, capable of aggregating multiple Ethernet streams into a single transport link. This connector monitors this device to check if everything goes well.

This connector uses an **SNMP** connection with the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | False                   |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | v2.3.0                      |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public.*
- **Set community string**: \[The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains some general information about the device, like **Hardware Revision**, **Serial Number**, ... It also contains the status of the **Fan**'s and the **PSU**'s.

### Interface Overview

This page contains the **Interfaces Overview** Table. Here you can find all the information about the interfaces.

### Webpage

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
