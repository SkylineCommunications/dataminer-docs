---
uid: Connector_help_Maxbert_PDU
---

# Maxbert PDU

This is an SNMP driver that monitors a Maxbert power distribution unit with monitoring capacity for 6 sockets.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2019.02.04 (MAX9 EN)   |

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
- **IP port**: Default:*161*.

SNMP Settings:

- **Get community string**: Default: *public.*
- **Set community string**: Default: *private.*

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver has one **General** data page, which contains:

- On the left, general system information parameters such as System Description, Name and Location.
- On the right, the measured current for each socket and all phase states for each phase. If a temperature sensor is available, the temperature is also displayed.
