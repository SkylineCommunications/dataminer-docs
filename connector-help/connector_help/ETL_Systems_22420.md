---
uid: Connector_help_ETL_Systems_22420
---

# ETL Systems 22420

The ETL Dextra series covers 4-way (single & dual), 8-way (single & dual) and 16-way, active splitters and combiners. They are designed for use in signal distribution systems in the L-Band range 850-2450MHz.

## About

This is an **SNMP** connector that allows two basic functions:

- Monitoring: Polling the device for its current hardware status, including the temperature, voltage and current configuration.
- Configuration: Allowing the configuration of some of the splitter's parameters, namely the IP and the way it works (several modes, paths, etc.).

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.5 e351                    |

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

### General

This page contains the main information and status of the splitter, such as its **Name**, **Location**, **Temperature.**

It also contains a **Reboot** button. Clicking it will trigger a confirmation message which, if accepted, will force the device to restart. This will cause the device to be temporarily unavailable.

### Status

This page displays table containing the **Power Supply Status** and **Amplifier Status**, as well as their individual values.

### Configuration

This page contains several configuration options related to the splitter, including **IP Settings**, **Trap Settings**, **LNB Setting**s and **Splitter Mode Settings**.

It is important to note the following regarding the way the IP settings work:

1. The IP configurations entered by the user will only be assumed by the machine once the DHCP option is off.

1. Once the settings have been saved, the machine will reboot.

### Web Interface

This page displays the webpage of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

This connector uses the DataMiner Connectivity Framework, or DCF, to allow this element to connect its inputs and outputs to other elements. This is only available on DMA version 8.5.8.5 or higher.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance ask a manager).
