---
uid: Connector_help_Evertz_ev6-FC
---

# Evertz ev6-FC

The ev6-FR's architecture enables modules with advanced functionality because of their significantly larger size compared to any other multi-frame platform. All modules in the ev 6RU series and legacy 3000 series of Evertz products occupy the full vertical height of the 6RU frame and can be mixed and matched within each frame to build complex signal processing chains.

## About

### Version Info

| **Range**            | **Key Features**        | **Based on** | **System Impact**                     |
|----------------------|-------------------------|--------------|---------------------------------------|
| 1.0.0.x \[Obsolete\] | Initial version.        | \-           | \-                                    |
| 1.0.1.x \[SLC Main\] | Adds redundant polling. | \-           | Adds interface for redundant polling. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |
| 1.0.1.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

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

The element created with this connector has the following pages:

- **General**: Contains general information, including the system description, uptime, contact, location and more.
- **Notify Faults**: Contains a table listing each fault name with each status, detailing whether it was sent as a trap or not.
- **Traps**: Displays the received traps with a meaningful name as a description. It is possible to define the maximum number of traps that can be shown.
