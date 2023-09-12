---
uid: Connector_help_Enensys_GigaCasterII
---

# Enensys GigaCasterII

The Enensys GigaCasterII is an IP video gateway that supports IP-to-ASI and ASI-to-IP streams. It is capable of delivering MPEG content one-to-one or one-to-many.

This connector allows not only the complete monitoring of the device, but also the control and configuration of its every aspect. In addition, it allows you to configure alarm monitoring and trending for all points of interest.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |
| 1.0.1.x   | DCF added        | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.4.9                  |
| 1.0.1.x   | 1.4.9                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the data pages detailed below.

### System

This page contains **general system information**, such as the Name, Type, Location, Serial Number, Firmware Version, System Date and Time, Last Update Time and Update Address. It also displays the device **Temperature** and the **GPS Status**, and provides access to the **Network Interface** config table, general **Options** table, and **Date and Time** configuration, which includes NTP servers.

The page also contains a set of control buttons:

- **Blink LED**: Identifies the device by blinking the front LED.
- **Reboot**: Reboots the device.
- **Factory Reset**: Resets the entire device to the factory state.

### General

This page contains the **Product Mode table** and several **DistriGuard** parameters, and allows monitoring and configuration of both.

### IP to ASI

This page contains two tables, one allowing you to **monitor** the existing streams and the other allowing the general **configuration** of those **streams**.

### ASI to IP

This page contains the same type of content as the IP to ASI page, allowing both **monitoring** and **configuration** of the existing streams, but in the opposite direction.

### Alarms

This page contains the **Current Alarms** table and allows access to the **Alarms Configuration** table and **Log Table**.

## DataMiner Connectivity Framework

The **1.0.1.x** driver range of the protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

### Interfaces

#### Dynamic Interfaces

Physical dynamic interfaces:

- A physical dynamic interface of type **inout** is created for **Network Interfaces**.
