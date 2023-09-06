---
uid: Connector_help_Cisco_VDS-TV_Manager
---

# Cisco VDS-TV Manager

The **Cisco VDS-TV Manager** is used to manage a VDS-TV network. This driver allows the user to **monitor** and **configure** the Cisco VDS-TV Manager.

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

In addition to the normal monitoring procedure, the **Server Settings** page allows you to **configure** general settings such as:

- Server source **address** and **address type**
- Enable **jumbo frames**
- **Offload** settings
- **Cache** settings

The **Services** page displays the state of the services of the Cisco VDS-TV Manager, including:

- **CDSM Web** server
- **DB** server
- **SNMP** server
- **System Manager**
