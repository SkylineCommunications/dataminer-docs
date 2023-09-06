---
uid: Connector_help_APC_PDPM227H
---

# APC PDPM227H

This driver can be used to monitor the APC Modular Remote Power Panel solution. It uses SNMP to retrieve data from the device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3.6.1                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device (default: public).
- **Set community string**: The community string used when setting values on the device (default: private).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The element consists of the pages detailed below.

### General

This page displays general information regarding the monitored system. It also contains a table with information about the modular distribution metering equipment.

### Modules

This page displays the following tables:

- **Module Info Table:** basic information about the distribution modules installed in the system.
- **Module Breaker Table:** operational information about the distribution modules.
- **Module Output Table:** information and settings related to the load equipment fed by the distribution modules.

### System Voltage

This page displays general information about the system voltage and allows you to set voltage and alarm thresholds.

It also contains a table with more information about the system output voltage.

### System Current

This page displays general information about the system current and allows you to set current and alarm thresholds.

It also contains a table that displays the total system phase current information.

### System Power

This page displays general information about the system power. It also allows you to reset the total kWh usage shown.

The page also a table that displays the total system phase power information.

### PDU

This page displays general information regarding the modular PDU.

### Environmental Monitor

This page displays information regarding the integrated environmental monitor.

### Local Display

This page displays information regarding the local display. It also allows you to configure parameters such as the **Beeper Volume**, the **Key Click**, the **Contrast** of the local display, etc.

### Config Traps

This page displays a table listing the trap receivers.
