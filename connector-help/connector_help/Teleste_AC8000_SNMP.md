---
uid: Connector_help_Teleste_AC8000_SNMP
---

# Teleste AC8000 SNMP

The Teleste AC8000 is an optical node.

## About

This connector uses an **SNMP** connection to poll data from the AC8000 device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the AC8000 device.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains general parameters such as **System Name**, **System Description**, **System Uptime** and **Fan Status**.

Two page buttons are available that provide access to additional information about **Modules** and **Module Details**.

### Power Supply

This page displays information about the voltages of the power supply.

### Ingress

On this page, you can configure the ingress switches of the device.

### Level

This page contains a table with gain and slope control entries. It also allows you to configure the **Level Control Start Alignment** and the **Level Control Button Mode.**

In addition, a page button provides access to the **Signal Monitor** page, which contains information about **Level Detectors.**

### Forward Path

This page contains settings related to the **optical receivers**.

### Return Path

This page contains settings related to the **return transmitters**.

### Spectrum

This page contains the **Spectrum Analyzer Table** and related information.

### Transponder

This page contains information and settings related to the transponder.

### Web Interface

This page provides access to the original web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
