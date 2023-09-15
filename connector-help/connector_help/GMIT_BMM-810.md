---
uid: Connector_help_GMIT_BMM-810
---

# GMIT BMM-810

The BMM-810 is a multiviewer and content monitoring solution for broadcast network and streaming platform operators.

## About

This connector allows the total monitoring of the sources and inputs of generic GMIT BMM-810 devices. It provides not only a general overview of the entire system, but also a detailed visualization of all video and audio parameters for every existing input.

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

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *private*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

#### HTTP HTTPConnection Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Device address**: The device address, by default *ByPassProxy*.

## Usage

### General

This page contains the main general parameters, such as the **Description**, **OID**, **Uptime**, **Contact**, **Location** and **System Date**.

### Sources

This page contains a table listing every **source** and its current **status**.

### Inputs

This page displays a **tree control view** containing the detailed general information for each **input** and its respective **video** and **audio** **modes**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
