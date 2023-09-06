---
uid: Connector_help_Sonifex_RB-SD1IP
---

# Sonifex RB-SD1IP

The **Sonifex RB-SD1IP** silence detection unit is an upgraded version of the existing RB-SD1.

The unit is a 1U rack mount device used to monitor an unattended stereo studio feed. In the event of the signal going "quiet", after a given period the unit will switch to an alternative stereo audio signal.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | v1_19                  |

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
- **Device address**: This is not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default: *public)*.
- **Set community string**: The community string used when setting values on the device (default: *private)*.

## Usage

### General

This page displays the **Firmware Version**, **GPI States**, **Output Left/Right Sources** and **Input Alarm States**. There are also page buttons for **Signal Levels** and **Silence Levels**.

### Configuration

This page displays the **Source Select, Mode Select, Restore, Global Silence Detect of Two Minutes** and **Force Output**.

### Web Interface

This page provides access to the web interface of the Sonifex RB-SD1IP unit. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
