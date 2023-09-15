---
uid: Connector_help_Telsis_Ocean_SNMP_Alarms_Proxy
---

# Telsis Ocean SNMP Alarms Proxy

With this connector, traps can be received from **Telsis Ocean** devices.

## About

The **Telsis Ocean SNMP Alarms Proxy** will receive traps from the **Telsis Ocean SNMP Proxy server** and display the received information in a table.

Note that this connector collects the alarm information from multiple Telsis servers. Since version 1.0.0.6, the alarms can be sorted in trunk groups.

### Version Info

| **Range** | **Description**                     | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                     | No                  | Yes                     |
| 1.0.1.x          | Added naming and Display Key column | No                  | Yes                     |

## Installation and configuration

### Creation

SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number**: The port of the connected device. The default value is *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays a table with alarm details, such as:

- **Title**
- **Trunkgroup**
- **Shelf**
- **Severity**
- **Alarm Active**
- **Root Date**
- **Display Key**

You can clear the inactive alarms by pressing the button **Clear Inactive**. Only the **inactive** alarms that are **not** listed in the **Traps Rows not to be Deleted** table are cleared.

You can also define the maximum number of rows in the table. When this maximum is reached, the inactive traps will automatically be cleared. By default, the maximum is 1000.

### Permanent Records Page

On this page, you can import and export records in a file. The path of this file must be specified in **File Location**.

The file has to contain a header with "alarm" or with "alarm;trunkgroup". The order of the header or file can be inverted.
