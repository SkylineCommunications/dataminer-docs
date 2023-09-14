---
uid: Connector_help_ETL_Systems_22452
---

# ETL Systems 22452

The **ETL Systems 22452** is a connector designed for the Dextra Series, based on the 8-way splitter.

The connector is used for monitoring and configuration purposes, as an alternative to the HTTP page.

## About

This is an **SNMP** connector that allows two basic functions:

- Monitoring: Polling the device for its current hardware status, including the temperature, voltage and current configuration.
- Configuration: Allowing the configuration of some of the splitter's parameters, namely the IP and the way it works (several modes, paths, etc.).

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

#### SNMP Device connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General Page

This page contains the main information and status of the splitter, such as its **Name**, **Location**, **Temperature**, and the **Amplifier Status** and **Power Supply Status**.

It also contains a **Reboot** button. Clicking it will trigger a confirmation message which, if accepted, will force the device to restart. This will cause the device to be temporarily unavailable.

### Configuration Page

This page contains several configuration options related to the splitter, including **IP Settings**, **Trap Settings**, **LNB Setting**s and **Splitter Mode Settings**.

It is important to note the following regarding the way the IP settings work:

1. The IP configurations entered by the user will only be assumed by the machine once the DHCP option is off.

1. Once the settings have been saved, the machine will reboot.

### Webpage

This page displays the webpage of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
