---
uid: Connector_help_Bard_MC4000_Series
---

# Bard MC4000 Series

The MC4002 Air conditioner unit is for use with units with or without economizers, can be configured for use with heat pumps, and has a dehumidification control feature if an optional humidity controller is connected. Dehumidification control cannot be used with heat pump.

## About

The **Bard MC4000 Series** connector monitors the temperatures and status of the air conditioner unit.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial Version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.01                        |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

System information is displayed on this page, including the **Models** and **Serial Numbers**.

The **Local Room, Remote Sensor 1 and 2 Temperatures** are also displayed.

### System Status

The state of the system's **Generator, Alarm Board, Comfort Mode, Controller, HVACs, Fans,** and **Cooling and Heating Stages** are all displayed on this page.

The status of the system alarms are also displayed.

### Setpoints

The **Cooling, Heating, High Temperature Alarm**, and **Low Temperature Alarm Setpoints** are all available on this page.

### Traps

It is possible to configure the IPv4 and IPv6 trap receivers on this page using the **IPv4 Traps** and **IPv6 Traps** tables.

### Web Interface Page

This page displays the web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
