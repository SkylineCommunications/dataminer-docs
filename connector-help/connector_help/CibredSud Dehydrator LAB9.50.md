---
uid: Connector_help_CibredSud_Dehydrator_LAB9.50
---

# CibredSud Dehydrator LAB9.50

This driver monitors the activity of the CibredSud Dehydrator LAB9.50 device.

## About

The LAB9.50 dehydrator is designed for continuous operation and automatic duty. It supplies dry air up to 1000 l/h with dew point better than -45 øC.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Installation and configuration

### Creation

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device. (default: public)
- **Set community string**: The community string used when setting values on the device. (default: private)

## How to Use

### General

This page displays the **System**, **Status** and **Settings** parameters.

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
