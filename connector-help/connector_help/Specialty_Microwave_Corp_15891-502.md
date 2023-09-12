---
uid: Connector_help_Specialty_Microwave_Corp_15891-502
---

# Specialty Microwave Corp 15891-502

The serial-to-digital I/O interfaces provide a RS-232C/RS-422 serial interface to control and read 96 input and output positions.

Configuration data can be retrieved by serial, Telnet, or SNMP.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 03.7D                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *161*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The **General** page displays the device status, as well as the status of the power supplies and HPAs.

The **Switch Positions** page displays all connected switches (depending on the data length) and their current position (POS 1/POS 2).

Note: Changing the switch position (HPAs) is only possible if the operation mode is set to the Remote mode.
