---
uid: Connector_help_Alpha_Combi_UPS_AC_DC
---

# Alpha Combi UPS AC DC

The Alpha Combi UPS AC DC is an uninterruptible power supply.

This connector uses **SNMP** to poll information from the device.

## About

### Version Info

| **Range**            | **Key Features**                                                               | **Based on** | **System Impact** |
|----------------------|--------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | \- General system parameters - Network Interface Table - Rectifier system data | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | v6.20                  |

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

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No additional settings are required.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The general **system** and **controller** data can be found on the **General** page.

Data on the network interface and utilization can be found on the **Network** page.

All rectifier-related data can be found on the **Rectifier** page
