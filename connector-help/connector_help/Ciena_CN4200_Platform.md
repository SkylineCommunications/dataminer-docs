---
uid: Connector_help_Ciena_CN4200_Platform
---

# Ciena CN4200 Platform

This is the Ciena CN4200 Chassis.

## About

This is a WDM based device, that can hold multiple modules, used for optical transport.

## Installation and configuration

### Creation

***SNMP connection***
This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- IP address/host: The polling IP of the device

SNMP Settings:

- Port number: The port of the connected device (default: 161)
- Get community string: The community string used when reading values from the device (default value : public).
  Set community string: The community string used when setting values on the device (default value : private).

## Usage

### General

This includes general information about the device, such as **System Name,** **Software Release,** **CLEI Code, Primary State, Serial Number**, etc.

There are page buttons which lead to subpages : **Optical, Memory and SNMP.

The **Optical Degree Table** lists information about the Amplification, such as **Fiber Length**, **Nominal per Channel Output Power,** etc.

The **Memory** subpage lists information in a table form about the **Memory Information Type, Version number, Backup Time,** etc.

The **SNMP Trap Server Table** lists the SNMP settings for sending traps.

### Configuration

This includes configuration settings about the device, such as **Node ID,** **Optical Power Control, Default Route Provisioning,** etc.

There is also a **Port Table**, that includes information about the ports, such as **Port Type**, **OSPF Routing**, etc.

### Equipment

This page shows 4 tables : **Power Module**, **Fan Module, IO Module and Alarm Module**.

The **Power Module Table** holds information about the Power Modules, such as : **Power Module Type, Power Module CLEI Code.**

The **Fan Module Table** contains information about the Fan Modules, such as **Fan Module Type, Fan Module CLEI Code.**

The **IO Module Table** contains information about the IO Modules, such as **IO Module Type, IO Module CLEI Code**.

The **Alarm Module Table** holds information about the Alarm Modules, such as **Alarm Module Type, Alarm Module CLEI Code.**

### Interfaces

This shows information about the Network and IO Interfaces that are attached to the chassis.

The information is listed in a Table, and contains parameters such as **Interface Type, Interface Speed, Interface In Octets,** etc.

### Protection

This shows information about the Protection Groups (redundancy).

It shows information such as the **Switch Type**, Whether or not the protection group is **Revertable**, etc.

### Web Interface

This shows the native web interface of the device. This page is only available if the client has access to the device.
