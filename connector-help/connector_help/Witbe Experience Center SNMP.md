---
uid: Connector_help_Witbe_Experience_Center_SNMP
---

# Witbe Experience Center SNMP

This driver is intended to catch traps from the Witbe Experience Center and list them in a history table.

## About

### Version Info

| **Range**            | **Key Features**                                | **Based on** | **System Impact** |
|----------------------|-------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version.Collects traps in Alarms table. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

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

Traps will be automatically captured from any OID and placed in the Alarms table on the General page.

## Notes

Important: The driver is designed to have a fixed number of bindings. If a trap doesn't have the correct number of bindings, the trap will be discarded.

The driver will only take traps from the IP configured in the element configuration.
