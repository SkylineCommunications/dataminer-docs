---
uid: Connector_help_Quantum_ActiveScale_P100
---

# Quantum ActiveScale P100

This DataMiner connector can be used to retrieve information and monitor data from a modular object storage system via SNMP.

## About

### Version Info

| Range            | Key Features | Based on | System Impact |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x [SLC Main] | Initial version. | -           | -                |

### Product Info

| Range | Supported Firmware |
|-----------|------------------------|
| 1.0.0.x   | -                     |

### System Info

| Range | DCF Integration | Cassandra Compliant | Linked Components | Exported Components |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | -                    | -                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

## How to Use

### General

The **General** page displays the device information, capacity data, network traffic data as well as metrics data.
An extra **Metrics** page might be displayed depending on the value of the **Poll Metrics** toggle button.

### Resources

The **Resources** page displays the CPU and Memory data in tables.

### Events

The **Events** page displays a table containing all the incoming traps.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.
