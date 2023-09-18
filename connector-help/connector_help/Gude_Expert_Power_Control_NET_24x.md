---
uid: Connector_help_Gude_Expert_Power_Control_NET_24x
---

# Gude Expert Power Control NET 24x

The Gude Expert Power Control Net 24x is a 24-fold remote power switch for TCP/IP networks.

## About

### Version Info

| **Range**            | **Key Features**                                   | **Based on** | **System Impact** |
|----------------------|----------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | \- Initial version. - Supports GUDEADS-EPC24X-MIB. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *161*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No additional configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

An SNMP connection is used to retrieve the device information. SNMP traps can be retrieved when this is enabled on the device.

The connector displays information on the EPC power ports, banks, and fuse status.

Traps configuration is also available.
