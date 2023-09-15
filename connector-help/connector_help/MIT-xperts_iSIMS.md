---
uid: Connector_help_MIT-xperts_iSIMS
---

# MiT Xperts iSIMS

The **MIT-xperts iSIMS** is a single-rack unit server designed to play out all SI/PSI data.

## About

### Version Info

| **Range**            | **Key Features**                                                      | **Based on** | **System Impact** |
|----------------------|-----------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Possible to gather and view information from the **MIT-xperts iSIMS** | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
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

## How to use

This is a basic connector displaying general information about the device as well as several tables with more specific information.

There are no specific restrictions to the use of this connector.
