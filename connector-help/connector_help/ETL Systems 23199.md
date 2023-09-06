---
uid: Connector_help_ETL_Systems_23199
---

# ETL Systems 23199

This connector uses **SNMP** to monitor and configure an ETL Systems 23199 device.

The ETL Systems 23199 is an RF switch that can connect one of 32 inputs to a single output.

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

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default value: *public)*.
- **Set community string**: The community string used when setting values on the device (default value: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

You can find all the information you need to monitor the device on the **General** page.
