---
uid: Connector_help_Evertz_3480TSM
---

# Evertz 3480TSM

This connector is used to monitor the Evertz 3480TSM transport stream monitor.

## About

This connector uses an **SNMP** connection to collect traps from the device. The status information of the monitored parameters is updated based on the collected traps, and the traps information is stored in a local database.

### Version Info

| **Range** | **Description**                           | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version for traps implementation. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### Traps

This page contains the general **Traps Table** as well as a number of parameters related to this table. There is also a button that can be used to **enable or disable** **storing the traps** in the local database, and a configurable parameter with the IP from which traps are obtained.

### Traps Advanced Search

This page can be used for the advanced search of traps stored in the local database. It allows you to configure a number of filters to limit the search results.

### Ethernet Link

This page contains the **Ethernet Link Faults** table, with information about the status of the Ethernet interfaces.

### Power Supply

This table contains the **Power Supply Status** table, with information about the status of the power supplies.

### Input Faults

This page contains the **Input Faults** table, with information about the status of all the parameters related to the differents inputs.
