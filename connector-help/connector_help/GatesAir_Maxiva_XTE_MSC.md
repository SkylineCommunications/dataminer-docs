---
uid: Connector_help_GatesAir_Maxiva_XTE_MSC
---

# GatesAir Maxiva XTE MSC

The **GatesAir Maxiva XTE MSC** is a frame for transmitters and exciters that power over-the-air delivery across the UHF television spectrum.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                      |
|-----------|-------------------------------------------------------------|
| 1.0.0.x   | 06.00.0034 (PCM software version) 01.00.0685 (SNMP version) |

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
- **IP port**: The IP port of the destination.

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

With this connector, it is possible to monitor and configure the MSC frame itself. In addition, it is also possible to enable trap notifications and define their priorities.
The communication protocol that is used to get and set the values is SNMP.
