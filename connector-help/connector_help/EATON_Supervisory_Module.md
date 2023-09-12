---
uid: Connector_help_EATON_Supervisory_Module
---

# EATON Supervisory Module

This connector provides support to monitor EATON Supervisory Modules, which are controllers for DC rectifiers.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | SNMP Monitoring  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                                                       |
|-----------|----------------------------------------------------------------------------------------------|
| 1.0.0.x   | SM45 Supervisory Module - ICP software version 2.04 - IOB software version 2.00 (and higher) |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **Bus address**: The bus address of the device.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The connector contains parameters for monitoring **alarms** and other **statistics** on the corresponding (sub)pages.
