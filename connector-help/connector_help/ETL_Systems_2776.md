---
uid: Connector_help_ETL_Systems_2776
---

# ETL Systems 2776

The ETL Systems 2776 is a DC-LNB power supply.

## About

This is an **SNMP** driver that can be used to poll the device for its current hardware status, including the temperature and the status of the power supply and LNB power supply.

### Ranges of the driver

| **Driver Range**     | **Description** | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | Yes                 | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | 1.2 e131                    |

## Installation and configuration

### Creation

#### SNMP Device connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains the main information and status of the device, i.e. its **Name**, current **Uptime** and **Temperature**.

### Power Supply

This page contains a table with status information for each of the power supplies. The table lists the name, **Status** and **Actual Voltage** of each PSU.

### LNB Power Supply

This page contains a table with status information for each of the LNB power supplies. For each LNB PSU, the table lists the name, **Status**, **Actual Voltage** and **Actual Current**, and allows you to **set the voltage** (*high*, *low* or *off*) **and tone** (*on* or *off*).

### Web Interface

This page displays the webpage of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
