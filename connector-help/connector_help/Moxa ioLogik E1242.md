---
uid: Connector_help_Moxa_ioLogik_E1242
---

# Moxa ioLogik E1242

This connector allows you to manage the Moxa ioLogik E1242 card. It communicates using SNMP and has filter polling per card using subtables.

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

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination. Default: *161*.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the following pages:

- **General**: Displays the names of the recorded channels captured by the device.
- **I/O Settings**: Includes the DI, DO, and AI channels tables.
- **Traps:** Includes the trap table and Auto Clear subpage, which allows you to specify max number of traps and the maximum age of traps before they are cleared from the table.
