---
uid: Connector_help_ETL_Systems_22522
---

# ETL Systems 22522

This connector can be used to monitor and configure the **ETL Systems 22522** L-Band combiner/splitter.

This connector is also compatible with the **ETL Systems 22532** combiner.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                            |
|-----------|-------------------------------------------------------------------|
| 1.0.0.x   | ETL Systems 22522, version 04.60 ETL Systems 22532, version 04.60 |

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
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The **General** page displays the device information and the IP Settings.

The **System** page displays all the settings of the modules embedded in this device.
