---
uid: Connector_help_Schneider_Electric_Generic_UPS
---

# Schneider Electric Generic UPS

The Schneider Electric Generic UPS connector can be used to configure and monitor an uninterruptable power supply.

This connector retrieves and sets data via **SNMP**. If this is enabled on the device, **SNMP traps** can also be retrieved.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |
| 1.1.0.x   | \-               | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | JB.GDENA8S300IC303     |
| 1.1.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The IP address of the device, e.g. *192.168.3.12*.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

### General

This is the default page. It displays general information about the identity of the device, such as the **manufacturer**, **model**, **software version**, **name, revision level, firmware version, User ID, Installation Date, and Serial Number.**

### Alarm Overview

This page contains the **number of alarms**, and an **alarm table**, where you can see the **state** of the alarms.

### Input

This page contains the input status as well as an **input** **table**, which contains information on all the inputs of the device, including the **frequency**, **voltage**, **current**, and **power**.

### Output

This page contains the output status parameters as well as an **output** **table**, which contains information on the outputs of the device, including the **voltage**, **current**, **power**, and **percent load**.

### Battery

This page contains information about the **battery**, such as the **battery level**, **remaining time**, **temperature**, etc.

### Configurations

This page can be used to configure several parameters, such as the **low battery run time, deep discharge protection, mains setting,** etc.

### Receptacles

This page contains two tables, one that shows the **status of the receptacles**, and another one that can be used to **configure the receptacles**,

### Devices

This page contains a table with information about the devices connected to the UPS, including the **VA rating, identification**, etc.

### Environment

This page contains only the information on **ambient** **temperature**.

### Control

This page can be used to **control the receptacles,** including the **outlet type** and **command**.

### Test

This page contains the information and control of **testing** the **battery**, such as **battery test time, battery test day**, and **automatic battery test interval**.
