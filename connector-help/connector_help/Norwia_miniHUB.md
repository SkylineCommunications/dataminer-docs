---
uid: Connector_help_Norwia_miniHUB
---

# Norwia miniHUB

This is a DataMiner driver for the **Norwia miniHUB**, a frame that houses pluggable cards for optical video distribution.

## About

This SNMP driver is used to monitor and configure the **Norwia miniHUB**.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Software Revision 31   |

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

The element using this driver consists of the following data pages:

- **General**: Allows you to monitor and configure basic information about the device, e.g. **System Description**, **Firmware Version**.
- **Hardware**: Allows you to monitor hardware information, e.g. **Fan Speed**, **Power Supply Voltage**.
- **GPIO**: Allows you to monitor GPIO information.
- **Cards**: Allows you to monitor card information, e.g. **Software Revision**, **DIP switches position**.
