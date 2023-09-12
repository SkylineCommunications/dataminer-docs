---
uid: Connector_help_GatesAir_Maxiva_M2X
---

# GatesAir Maxiva M2X

The **GatesAir** **Maxiva M2X** is a standalone multimedia exciter for the FM transmission system.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*

### Initialization

No extra configuration is needed.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver consists of the following data pages:

- **General**: Displays basic SNMP information, such as **Description**, **Uptime**, **Contact**, **Name,** and **Location**. Also displays exciter-related parameters such as **Input 1 Status**, **Input 2 Status**, **Exciter** **Status**, etc.
- **System**: Allows you to set up traps and configure the **Exciter Frequency**, **Exciter** **Frequency** **Offset** and **Active** **Input**.
