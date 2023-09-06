---
uid: Connector_help_Eaton_PDU
---

# Eaton PDU

The Eaton PDU driver is used to monitor the **Eaton Power Distribution Unit**

## About

### Version Info

| **Range**            | **Key Features**                               | **Based on** | **System Impact** |
|----------------------|------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version.Monitors the EATON PDU system. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | v2.24                  |

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

- **Get community string**: Default: *public-community.*
- **Set community string**: Default: *private-community.*

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

On the **PDU** page of the element, you can find:

- PDU general information.
- The Breakers table and Panel table.

The **Tree** page contains a tree control for the panels and breakers.
