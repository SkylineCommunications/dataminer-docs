---
uid: Connector_help_Cisco_VDS-TV_Vault
---

# Cisco VDS-TV Vault

The **Cisco VDS-TV Vault** is the main storage element in the Cisco VDS-TV system. This connector allows the user to **monitor** and **configure** the Cisco VDS-TV Vault.

## About

### Version Info

| **Range**            | **Key Features**    | **Based on** | **System Impact** |
|----------------------|---------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Monitor and control | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

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

## How to use

On the **Ingest Manager** page, you can **configure** general settings such as:

- **Host address** and **address type**
- Timeouts
- **Enable services**
- **Back Office** settings

The **Server Settings** page allows you to also **configure** general settings such as:

- Server source **address** and **address type**
- Enable **jumbo frames**
- **Offload** settings
- **Cache** settings

The remaining pages allow you to monitor the operation of the device.
