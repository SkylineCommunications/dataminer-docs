---
uid: Connector_help_APC_ACRC103
---

# APC ACRC103

This connector is used to monitor the APC ACRC103, a water-chilled rack air conditioning (AC) unit released by APC. It is part of APC's half-rack (ACRC100) series for data centers.

Each unit can be integrated in a group of up to 12 AC units, in order to create a cooling group. It is then possible to configure some of the settings once and apply this to all the units contained in the group.

## About

This connector can be used to poll unit information, as well as group information in case the unit is integrated in a group of air conditioning units. It also allows the user to configure both the unit and the group.

SNMP polling is used to retrieve the device information.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 6.24.0                      |

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

This page contains basic information about the unit, as well as its **operational status**, which includes **cooling**, **water** **and air flow**, **temperatures** and **running time**.

### Unit Configuration

This page allows the configuration of several working parameters of the air conditioning unit, which include its **date/time**, **air filters**, **cooling capabilities**, **power**, **temperature thresholds**, **traps** and **boot configurations**.

### Alarms

This page displays a table with an overview of the unit's **alarm status**.

### Group

This page shows **status information** for the group containing the unit that is being polled.

### Group Configuration

On this page, you can configure the group's parameters, which will affect all units in the group. This includes the **type of setup**, the **cooling PID**, and some **temperature and fan settings**.

### Webpage

This page displays the webpage of the device, for direct configuration and monitoring. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
