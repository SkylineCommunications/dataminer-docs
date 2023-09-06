---
uid: Connector_help_NetInsight_Nimbra_414
---

# NetInsight Nimbra 414

The **NetInsight Nimbra 414 driver** allows you to monitor the main information retrieved from the corresponding device, which is media transport equipment that supports different input formats, resolutions, frame rates, etc.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

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

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device.

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

The element displays the main parameters and tables you need to know the state of the device and its connections. Some table columns, such as Operational Status, Admin Status, IDs, and different kinds of thresholds, are editable.

On the **Polling Control** subpage, you can **enable or disable the polling of every table**. By default, the polling of all tables is disabled, except for the **Video Interfaces Table**.
