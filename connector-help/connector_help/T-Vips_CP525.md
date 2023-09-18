---
uid: Connector_help_T-Vips_CP525
---

# T-Vips CP525

This connector is used for the CP525 multiplexer model from T-Vips and allows SNMP monitoring and configuration of this device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | SNMP monitoring  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**  |
|-----------|-------------------------|
| 1.0.0.x   | No version requirements |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

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

The connector contains parameters for monitoring **alarms**, **input**, **outputs**, and **transport streams** on the corresponding (sub)pages.

On the **Configuration** page, configuration files can be both uploaded and downloaded.
