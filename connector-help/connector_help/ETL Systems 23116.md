---
uid: Connector_help_ETL_Systems_23116
---

# ETL Systems 23116

This driver is used to monitor an ETL Systems 23116 device using the **SNMP** interface.

The ETL Systems 23116 is a device operating with signals in the L-band range of frequencies of 850-2150 MHz and is designed to provide automatic main/standby switching functions, typically for 2:1 redundancy switching

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Software: E115, v1.8   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

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

The **RF Settings** **Limits** can be configured on the **RF** page for both main and standby signals. The **RF Limits Status** parameters on the same page will show if the signals are actually within the configured limits.
