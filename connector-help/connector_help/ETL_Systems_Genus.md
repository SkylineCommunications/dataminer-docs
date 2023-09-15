---
uid: Connector_help_ETL_Systems_Genus
---

# ETL Systems Genus

The GENUS series is a set of modular chassis that can be fitted with a variety of modules ranging in functionality. This allows the construction of complex systems with a minimal hardware footprint.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                                                                                                                                                                                                                                                                                                              |
|-----------|---------------------|-------------------------|-----------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \- [ETL Systems Genus - CPU](/Driver%20Help/ETL%20Systems%20Genus%20-%20CPU.aspx) - [ETL Systems Genus - PSU](/Driver%20Help/ETL%20Systems%20Genus%20-%20PSU.aspx) - [ETL Systems Genus - Splitter-Combiner](/Driver%20Help/ETL%20Systems%20Genus%20-%20Splitter-Combiner.aspx) - [ETL Systems Genus - 22544](xref:Connector_help_ETL_Systems_Genus_-_22544) |

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

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector consists of the following data pages:

- **General**: Displays the current status of the **System Summary Alarm**, and contains a table listing the device **Modules**.
- **DVE**: Allows you to enable or disable the **DVE Automatic Removal** feature. The tables of the supported modules are also displayed on this page: **CPU Modules**, **PSU Modules,** **Splitter/Combiner Modules** and the **Hybrid 22544 Modules.**
