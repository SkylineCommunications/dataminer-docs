---
uid: Connector_help_Spectracom_Epsilon_Clock_EC31M
---

# Spectracom Epsilon Clock EC31M

The **Spectracom Epsilon Clock EC31M** connector displays information related to the **Spectracom Epsilon Clock EC31M** clock distribution device.

## About

This connector uses an **SNMP** interface to communicate with the Spectracom Epsilon Clock EC31M device.

### Version Info

| **Range**     | **Description**                                                                                          | **DCF Integration** | **Cassandra Compliant** |
|----------------------|----------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version                                                                                          | Yes                 | Yes                     |
| 1.0.1.x \[SLC Main\] | Based on 1.0.0.6. HTTP connection support implemented to support polling of data not available via SNMP. | Yes                 | Yes                     |

## Installation and configuration

### Creation

#### SNMP connection

This connector uses an SNMP connection and requires the following input during element creation:

SNMP Connection:

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

#### HTTP connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device
- **IP port**: The IP port of the destination, by default 80.

## Usage

### General Page

This page displays the main status of the device.

### GPS Page

This page displays the GPS status of the device.

### Configurations Page

On this page, it is possible to configure certain settings for the device, such as the **NTP server** settings and **Alarm Limits**.

### Web Interface Page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
