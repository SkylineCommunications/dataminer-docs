---
uid: Connector_help_Alpha_Cordex_CXC_HP
---

# Alpha Cordex CXC HP

The **CXC HP controller** provides total energy system management and **single point of control** and **monitoring** of various power generation and storage devices in **critical power applications**.

## About

### Version Info

| **Range**            | **Key Features**                                                                         | **Based on** | **System Impact** |
|----------------------|------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Monitors the Line Power System, Line Power System Module, Inverter System and DC System. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | v2.20 and v6.20        |

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
- **IP port**: 161

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

The systems are displayed separately from each other.

The configured name in the components table is used as the name in the data tables from the modules.
