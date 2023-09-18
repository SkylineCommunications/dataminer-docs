---
uid: Connector_help_Eltek_Inverter_Candis
---

# Eltek Inverter Candis

This connector can be used to display information related to the Eltek Inverter Candis converter device.

## About

This connector uses an **SNMP** interface to communicate with the Eltek Inverter Candis device.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[Obsolete\] | Initial version  | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Removed DVEs     | 1.0.0.6      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.1.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | No                      | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection:

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

### Initialization

When you have created the element, you then need to select the mode you want to use with respect to the Lite functionality. To enable or disable this functionality, go to the **Network Settings** page, and select the mode.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The current connector has two different kinds of behavior:

- **Default mode**: Polls all data continuously.
- **Lite mode**: Polls specific data only, reducing the volume of data polled.

To use the **Lite functionality** of this connector, you need to enable the parameter **LITE PROTOCOL** on the **Network Settings** page.

The connector consists of the following pages:

- **General Page:** Displays status parameters, such as the **Software Version** and **Serial Number**.
- **Module Page:** Contains a table showing the different values related to the TSI modules such as voltages, current, status, and much more.
- **Phase Page:** Contains a table with information regarding the power phases.
- **Groups Page:** Contains two tables with information regarding the AC and DC Groups.
- **Configuration Page:** Contains a table with configuration information.
- **Alarms Page:** Contains a table with alarm descriptions.
- **Events Page:** Contains a table with event descriptions.
