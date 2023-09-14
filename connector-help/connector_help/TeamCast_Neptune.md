---
uid: Connector_help_TeamCast_Neptune
---

# TeamCast Neptune

NEPTUNE is a 1RU DVB-S2X satellite demodulator that supports all advanced DVB-S2X modes. Specifically, NEPTUNE can demodulate signals ranging from QPSK to 256 APSK and from 0.1 to 500 MBaud, offering high operational flexibility.

## About

This connector for the **TeamCast Neptune** displays the demodulator configuration and outputs for inputs, outputs and channels.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 100                         |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection to communicate with the device, and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The IP of the TeamCast device.
- **IP port:** The IP port of the destination, by default *161*.

## Usage

### General

This page displays generic device information, as well as the status of the **Startup, Hardware, Software, Loading Process, Internal Com, Fault LED, Ready LED, Software Compatibility, System Clock, Power Supplies** and **Fans.**

In the upper right corner, you can find the **Temperature** of the device.

Via page buttons, you can access the following subpages:

- **Network**: Allows you to configure and monitor the **Ethernet Control** and **Data** interfaces.
- **SNMP**: Allows you to configure SNMP settings.
- **Time Config**: Allows you to configure the time zone and NTP information.
- **Firmware Update**: Displays the status of the current firmware update.
- **Profiles**: Allows you to configure and set profiles.
- **Licenses**: Displays license status information and allows you to set license keys.

### Inputs

This page displays the **Input RF** and **Input ASI** configuration and status tables.

### Outputs

This page displays the **Output ASI,** **Output TSOIP,** **Output GSE** and **Output MPE** configuration and status tables.

### Process

This page displays information on the channels in the **Channels** and **Channel Status** tables.

The **Probes Status** table displays the probes for the channels and the values for the probes.

### Status

This page displays the system alarm status parameters in the sections **System Status, Input Status, Output Status** and **Process Status**.

Via page buttons, you can configure the trap generation and the severity of the status parameters.

### TSOIP Tx

This page displays the **TSOIP Tx** and **TSOIP Tx Status** table, which can be used to configure the TSOIP transmit.

### Log

On this page, the **Trap Logs** table displays a log of the traps received from the device. Via the available buttons and page button, you can manipulate the table.

### Web Interface Page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

This connector supports the usage of DCF and can only be used on a DMA with **8.5.8.5** as the minimum version.
