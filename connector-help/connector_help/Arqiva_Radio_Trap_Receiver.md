---
uid: Connector_help_Arqiva_Radio_Trap_Receiver
---

# Arqiva Radio Trap Receiver

The **Arqiva Radio Trap Receiver** is used to capture and display the Arqiva Radio alarm traps for the related IP address.

## About

The **Arqiva Radio Trap Receiver** connector captures the **SNMP** alarm traps from the Arqiva Radio device and displays them in the Alarm Trap Table, in order to visualize the current active alarms.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.150.3.3*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

### General

This page contains the **Alarm Traps** table, which displays all alarms that came in through traps. The **ID**, **Timestamp**, **Source** **IP**, **OID**, **Radio** **link**, **Alarm** **condition**, **Alarm** **state** and **ECAM** **cct** **number** of the trap are displayed in the different columns.

With the **Clear Table** button above the table, you can delete all rows from the table.
