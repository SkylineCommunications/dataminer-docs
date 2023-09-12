---
uid: Connector_help_Spectracom_SAS-36E
---

# Spectracom SAS-36E

With this connector, you can gather and view information from the device Spectracom SAS-36E and configure and receive traps from the device.

## About

### Version Info

| **Range**            | **Key Features**                                            | **Based on** | **System Impact** |
|----------------------|-------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. Supports DCF from version 1.0.0.8 onwards. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

## Configuration

### Connections

#### SNMP Connection - Main

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection:

- **IP Address/host**: The polling IP of the device, e.g. *10.64.7.11*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

### General

This page displays general information about the device, such as the **System Description**, **Up Timen**, and **Location**.

### Interfaces

This page displays a table with the interface statistics. In addition, you can also change the interface state here.

### Status

This page displays the status of the device, with parameters such as **Urgent Alarm Status**, **Selected Channel**, and **AC Power Status**.

### Security

On this page, you can configure the device using parameters such as **Network Channel Selection** and **Trap Control**.

### Polling Configuration

From version 1.0.0.12 onwards, a **Polling Configuration** page is available that allows you to define the polling intervals for the following groups of parameters:

- **General**
- **Interfaces**
- **Status**
- **Configuration**

By default, polling for these groups is enabled, and the polling intervals for these groups are the same as in previous versions: 1 second for fast parameters, 1 minute for normal parameters, and 1 hour for slow parameters.

In the **Polling Table**, you can configure the intervals in the **Time** column, enable or disable the polling in the **State** column, and poll a specific group on demand in the **Refresh on Demand** column.
