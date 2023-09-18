---
uid: Connector_help_Edgeware_Orbit
---

# Edgeware Orbit

The **Edgeware Orbit** is a Video Server Platform that can dramatically increase the profitability of services.

This connector polls an **Edgeware Orbit** device, which is basically a Linux Server. The connector supports most Linux OS versions.

The connector shows the full status of the server.

## About

### Version Info

| **Range** | **Description**                          | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------------------|---------------------|-------------------------|
| 2.0.0.x          | Initial version                          | No                  |                         |
| 2.1.0.x          | Adapted to firmware esb2001-2.18 release | No                  | Yes                     |
| 2.1.1.x          | SNMPV3 version                           | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 2.1.0.x          | esb2001-2.18 release        |
| 2.1.1.x          | esb2001-2.18 release        |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP Address**: The device IP.

SNMP Settings:

- **IP port**: The IP port of the device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.
- **Security level and protocol**: Only applicable from version **1.1.1.x** onwards.
- **User name**: Only applicable from version **1.1.1.x** onwards.
- **Authentication password**: Only applicable from version **1.1.1.x** onwards and if 'Security level and protocol' is not *noAuthNoPriv.*
- **Encryption password**: Only applicable from version **1.1.1.x** onwards and if 'Security level and protocol' is not *authPriv.*
- **Authentication algorithm**: Only applicable from version **1.1.1.x** onwards and if 'Security level and protocol' is not *noAuthNoPriv.*
- **Encryption algorithm**: Only applicable from version **1.1.1.x** onwards and if 'Security level and protocol' is not *authPriv.*

#### Serial SSH Connection

This connector uses an SSH serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP Address**: The device IP.
- **Port**: The SSH Port, by default *22*.
- **Timeout of a single command**: *15000* (ms)
- **Number of retries**: *0*

### Configuration

To make sure the connector works properly, after creation of the element, go to the **General** page, click the **Security** page button, and fill in the correct credentials.

## Usage

### General

Among others, this page displays both the **Connection** and the **Logon State**.

It also has two page buttons:

- **Configuration**: Allows you to download the configuration to a location on your computer.
- **Security**: Allows you to fill in your login credentials. This is necessary for the connector to work properly (cf. 'Configuration' section of this help).

### System Information

This page provides an overview of all system information, including **HW serials, firmware, routes, pluggable transceivers** and general system information.

### Hardware Status

This page provides information about the **power supplies, voltages, fans** and **temperatures.**

### CPU and Memory Information

This page displays CPU key values and **load averages**, as well as information about every **DIMM** **slot** and about how the memory is used.

### Processes Information

This page displays information about all the running processes, in the **Process List Table**.

### Storage

This page displays information about the **hard disks**, such as how much space is used, which file system is used, etc.

### Interfaces

This page displays information about the **interfaces** the server is using and about the **Network Ports.**

### Streams

On this page, you can poll for **ls-media -lj**, which returns every stream the server is using. As this response can be very large, there is an option to enable or disable this functionality.

### Statistics

This page contains statistics on **Input** and **Output** of the server.

### Services

On this page, you can see all licenses and services of the server.

### Custom CLI Commands

On this page, you can configure custom commands to send to the device. There are two ways to add a command: either by using the parameters **New CLI Command Name** and **New CLI Command**, or by importing a .csv file.

## Notes

For the configuration of custom CLI commands, please note the following:

- The .csv file used to import custom CLI commands should have the following format: *Polling Interval,Result Type,Command Name,Command*.
  E.g. *10,string,Uname,uname -a*

- The field 'Command Name' in the .csv file must not contain commas.
