---
uid: Connector_help_Synology_RS820RP+
---

# Synology RS820RP+

Synology RS820RP+ is a 1U rackmount 4-bay network-attached storage solution designed for effective and centralized data management. It is equipped with a 4-core processor and 2 GB DDR4 memory, expandable up to 18 GB. The PCIe 3.0 slot supports an optional 10 GbE add-in network interface card, or an M2D18 M.2 SSD adapter card4, where the M.2 NVMe/SATA SSD cache can be used to boost system random IOPS.

This connector uses SNMP to poll data from Synology RS820RP+ based on its web interface layout.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | DSM 6.2-25426          |

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

The layout of the connector is similar to that of the web interface of the Synology RS820RP+. It also provides the same monitoring and configuration features.
