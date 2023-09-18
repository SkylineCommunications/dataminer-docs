---
uid: Connector_help_Riedel_Communications_Artist_SNMP
---

# Riedel Communications Artist SNMP

The Riedel Artist is a true network infrastructure based on highly modular **matrix mainframes**. The individual Artist matrix mainframes can be equipped exactly as needed.

This connector communicates with Riedel Artist SNMP Agent and retrieves its alarms via SNMP communication.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 8.1.NM1                |

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
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

## How to use

The element has the following data pages:

- **General**: Contains general parameters such as Version, Main IP Address Type, Main IP Address, Node Count and Client Card Count.
- **Alarms**: Contains the **Alarms Table**, which lists all alarms present in the system. Its index is the creation time as a Unix timestamp/path.
