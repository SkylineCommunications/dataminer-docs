---
uid: Connector_help_Riedo_Networks_E3Meter
---

# Riedo Networks E3Meter

The E3METERr Data Concentrator aggregates data from E3METERr Intelligent Power Strips (IPS), implements logging functionality, and makes data available on its Fast Ethernet interface via Web, SNMP, CSV, and PDF.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 6.1.1 (2019-04-18)     |

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

After an element is created using the correct IP/port config, data should be polled, and parameters should display the correct information.

On the **General** and **System** page, you can find information related to the system. The **IPS**, **IPS Meter**, and **IPS Sensor** pages contain data related to the Intelligent Power Strips.
