---
uid: Connector_help_Huawei_OceanStor_5500
---

# Huawei OceanStor 5500

This connector is used to monitor the Huawei OceanStor 5500 Storage System.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | V500R007C60 Kunpeng    |

System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the storage system.

SNMP Settings:

- **Port Number**: The IP port of the storage system. e.g. *161.*
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

All data available is retrieved using the **SNMP** interface of the Huawei OceanStor 5500.

The **General** and **System** page contain all data related to the **Enclosure**, **Controller Enclosure**, and **Disk Enclosure**.

The **Performance** page contains tables with the performance-related information.

All other pages in the connector contain dedicated information about the **storage**.
