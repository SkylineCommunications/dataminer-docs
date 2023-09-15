---
uid: Connector_help_Digidia_EasySplice
---

# Digidia EasySplice

This connector uses an SNMP connection to monitor and control the Digidia EasySplice equipment.

The EasySPLICE system runs on the software platform. It automatically inserts local adverts into a DVB TS stream and uses an IP input.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 144                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection - Main

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default value: *snmpuser*).
- **Set community string**: The community string used when setting values on the device (default value: *snmpuser*).

### Initialization

No extra configuration is needed.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

### General

The General page contains the basic version, system, and equipment information. There are two subpages: **Communication** and **SNMP Trap Settings**. These allow you to view and update the interface info, NTP server information, and trap settings.

### Alarms

The Alarms page contains the alarm statuses of all the hardware and software inputs of the EasySplice equipment.

### Polling Configuration

The Polling Configuration page allows you to define the polling intervals for the following groups of parameters:

- **General - Version Info**
- **General - System Info**
- **SNMP Trap Settings**
- **Communication - Ethernet 1**
- **Communication - Ethernet 2**
- **Communication - NTP Server**
- **Alarms - Alarm Status**
- **Alarms - MUX Status**

By default, polling is enabled for these groups.

In the **Polling Table**, you can configure the intervals in the **Time** column, enable or disable the polling in the **State** column, and poll a specific group on demand in the **Refresh on Demand** column.
