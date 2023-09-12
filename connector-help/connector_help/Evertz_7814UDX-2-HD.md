---
uid: Connector_help_Evertz_7814UDX-2-HD
---

# Evertz 7814UDX-2-HD

The 7814UDX-2-HD card is a dual-path broadcast-quality up-/down-/cross-converter that converts between common SD/SMPTE 259M and HD/SMPTE 292M video signals. "-3G" versions add support for common 3G/SMPTE 424M video signals.

This is a standalone connector for the 7814UDX-2-HD card of the Evertz 7800 General Platform. It supports the 2 paths for resources in SRM.

## About

### Version Info

| **Range**            | **Key Features**                                                  | **Based on** | **System Impact** |
|----------------------|-------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Audio Control, Audio Down Mix, Dolby Decoder and Encoder, Presets | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |

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
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

This is a straightforward SNMP connector. Make sure the IP, port, and community strings are correctly filled in during element creation.

Each page contains one table that shows information matching the page name.
