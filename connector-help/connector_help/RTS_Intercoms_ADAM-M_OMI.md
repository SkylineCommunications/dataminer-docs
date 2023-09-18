---
uid: Connector_help_RTS_Intercoms_ADAM-M_OMI
---

# RTS Intercoms ADAM-M OMI

This connector is designed to monitor and configure the ADAM-M OMI card. This card is available in configurations up to 64 bidirectional ports in increments of 16 ports on a single card. The OMI card can be expanded from the base configuration of 16 ports through software upgrades. In addition to the standard RJ45 Ethernet connection, fiber connectivity is also supported with the addition of optimal single mode or multimode modules. A single ADAM-M frame can support up to 512 OMNEO ports, providing a highly compact single-frame solution for many system installs.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

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
