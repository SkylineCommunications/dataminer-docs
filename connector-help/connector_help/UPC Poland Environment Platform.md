---
uid: Connector_help_UPC_Poland_Environment_Platform
---

# UPC Poland Environment Platform

This is an SNMP-based driver used to gather and display available data from the UPC Poland Environment Platform.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

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

On the **General** page, you can find general information such as **High Fuel level** and **Coolant Level**, as well as general settings for the circuit breaker and parameter settings.

The **Configuration** page displays circuit breaker and parameters information for each network block.

On the **Output** page, you can find information about the Circuit Breaker Output 1 and 2.

On the **Additional Parameters** page, you can find additional information about the device such as **Air Temperature, Dew Point, Air Relative Humidity**, etc. This page also displays a block of reserved parameters and shows the status of the main QS3 circuit.
