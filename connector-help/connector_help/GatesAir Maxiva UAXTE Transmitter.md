---
uid: Connector_help_GatesAir_Maxiva_UAXTE_Transmitter
---

# GatesAir Maxiva UAXTE Transmitter

This connector monitors information from the GatesAir Maxiva UAXTE Transmitter. This is a compact, air-cooled **TV transmitter** that provides over-the-air delivery in the UHF spectrum and retrieves information regarding different aspects of the system.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 04.13.0016             |

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

You can find more information about the main data pages of the connector below.

### General

This page contains general information about the device. This is similar to other GetsAir connectors.

This page contains two subpages with information related to **System Control** and **Trap Configuration**.

### Input Status

This page contains information about the inputs present on the device. On the **Input Settings** subpage, you can manage the input properties.

### ATSC3 Modulator

This page contains information about ATSC3. Subpages are available with more specific information about **L1**, **Network**, and **Configuration**.
