---
uid: Connector_help_Sonifex_RB-FSx2
---

# Sonifex RB-FSx2

The Sonifex RB-FSx2 driver can be used to monitor and configure 2 different **Sonifex** audio failover switch devices:

- The **RB-FS42** audio switch: 4 IO channels and 2 standby channels.
- The **RB-FS82** audio switch: 8 IO channels and 2 standby channels.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | V1.06                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the destination.
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

This element created with this driver consists of the following data pages:

- **General**: Displays the **Device Version** and the **PSUs** status.
- **Channels**: Displays the status of the input, output and standby channels.
- **Configuration**: Allows you to change the settings of the channels.
