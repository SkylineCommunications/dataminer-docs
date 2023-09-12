---
uid: Connector_help_ETL_Systems_23198_-_e278
---

# ETL Systems 23198 - e278

This driver can be used to monitor an ETL Systems 23198 switch device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

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

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default value: *public*).
- **Set community string**: The community string used when setting values on the device (default value: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

No extra configuration is needed.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The driver uses the **SNMP** protocol to retrieve data from the device.

The **General** page displays configuration parameters, the current **Channel** and the 2 **PSU Status.**

The **Switch Counters** page displays the position counters.
