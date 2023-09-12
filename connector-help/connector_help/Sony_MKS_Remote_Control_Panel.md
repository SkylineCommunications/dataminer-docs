---
uid: Connector_help_Sony_MKS_Remote_Control_Panel
---

# Sony MKS Remote Control Panel

This is an SNMP connector that is used to monitor and configure the **Sony MKS-R3210**, **MKS-R1620**, and **MKS-R1630** equipment.

## About

### Version Info

| **Range**            | **Key Features**  | **Based on** | **System Impact** |
|----------------------|-------------------|--------------|-------------------|
| 1.0.0.x              | Initial version   | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Added DCF support | 1.0.0.4      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.10                   |
| 1.0.1.x   | 1.10                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |

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

### General

This page displays the **System Information**, including the **System Time**, **System Description**, **System Location**, **System Contact**, **System Up Time**, and other general parameters.

### Network

This page displays the **Interfaces** table. This table displays the operational status of the interfaces available in the workstation. This operational status can also change based on incoming traps.

### Product Information

This page displays the **Product Information**, **Module**, and **Remote Maintenance** tables.

### Traps

This page displays the **Traps Destination** table.

### Alarms

This page displays the **Error Status** table. This table is cleared when a "Coldstart" trap is received.
