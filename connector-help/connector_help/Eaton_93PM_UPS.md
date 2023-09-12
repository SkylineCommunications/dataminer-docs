---
uid: Connector_help_Eaton_93PM_UPS
---

# EATON 93PM UPS

This connector provides information about the EATON 93PM UPS, such as the input and output current and voltages.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**  |
|-----------|-------------------------|
| 1.0.0.x   | INV:1.48.0006 NET:2.6.5 |

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
- **IP port**: 161

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

If you want to use the traps in DataMiner, you will have to enable this on the device and fill in the IP of the DataMiner server.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The connector will work immedialty after startup.
It's possible to change the settings for the trap table to clean up so that the table can not became to large.
