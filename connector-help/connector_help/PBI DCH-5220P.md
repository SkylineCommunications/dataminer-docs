---
uid: Connector_help_PBI_DCH-5220P
---

# PBI DCH-5220P

The PBI DCH-5220P is an IRD. It has several options, the most important being the type of tuner (DVB-C, DVB-T/T2, DVB-C, DTMB, etc.).

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 5220PR2001             |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The driver uses **SNMP** commands to communicate with the device. The driver layout generally corresponds with that of the web interface of the device.

The first part of a page corresponds with the top level of the web interface (Status, Configuration, System). The second part corresponds with the relevant subsection (E.g. Status - Decoder, Configuration - DVB-S2 Tuner, System - Device).

Note: The settings for the different types of tuner are only displayed when that particular type of tuner is installed. For example, if a **DVB-C tuner** is available instead of a DVB-S2 Tuner, the page for the tuner that will be shown is **Configuration - DVB-C Tuner**.
