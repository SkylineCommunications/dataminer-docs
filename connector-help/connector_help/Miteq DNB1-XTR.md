---
uid: Connector_help_Miteq_DNB1-XTR
---

# Miteq DNB1-XTR

This connector allows monitoring and control of the downconverter. The connector is compatible with the Miteq DNB1 and DNB2 models.

## About

### Version Info

| **Range**            | **Key Features**                                           | **Based on** | **System Impact** |
|----------------------|------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | \- Monitoring & control- Same UX as Miteq UPB1-XTR 2.0.0.x | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | D163995V2.121.25       |

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

No extra configurations are needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

No special actions are required to use this connector.
