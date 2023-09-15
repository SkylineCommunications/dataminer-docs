---
uid: Connector_help_Novel_Supertv_EPG
---

# Novel Supertv EPG

With the **Novel Supertv EPG** (Electronic Program Guide) connector, it is possible to monitor and manage Novel SuperTV's Electronic Program Guide software.

## About

The connector retrieves information via **SNMP** and displays it in the element on two pages:

- The **General** page contains CPU and memory usage information, as well as information concerning the operating system, the application and the database.
- The **Alarms** page contains information about alarms that occurred on the server.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          |                             |

## Installation and configuration

### Creation

SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not used.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *supertv*.
- **Set community string**: The community string in order to set to the device. The default value is *supertv.*

## Usage

### General

This page contains information about CPU usage and memory usage, as well as information about the operating system, the application used and the hardware.

Two extra pages are available:

- **Alarm Management**: On this page, you can change the alarm settings of the CPU usage and/or the memory usage. In other words, here you can change when the device generates an alarm entry.
- **Configuration**: On this page, you can see which modules are or are not configured.

### Alarms

On this page, an overview is displayed of the alarms that have occurred.

This page contains a subpage:

- **SNMP Traps**: On this page, you can configure the necessary settings to receive SNMP Traps.
