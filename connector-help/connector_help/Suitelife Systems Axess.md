---
uid: Connector_help_Suitelife_Systems_Axess
---

# Suitelife Systems Axess

Axess is a flexible network-based management application used by broadcasters, content originators, Telco networks, building management teams and infrastructure facilities operators.

The Suitelife Systems Axess driver polls status and analog tables from the Axess application.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial driver   | \-           | \-                |

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
- **Bus address**: The bus address of the device (default: *ByPassProxy*).

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

The element created with this driver consists of the following data pages:

- **General**: Displays the **Status Table**, with the Channel Numbers, States, Name, and Values, as well as the **Analog Table**,with the Channel Numbers, States, Name, and Values.
- **Debug**: Contains parameters that can be used to debug the driver.

## Notes

The driver polls the tables using a 30-second timer.
