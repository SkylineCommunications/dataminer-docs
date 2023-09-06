---
uid: Connector_help_Sony_NMI_Device
---

# Sony NMI Device

This is an SNMP connector that is used to monitor and configure the **Sony NMI interface** equipment.

The information on the parameters is retrieved via **SNMP** communication.

## About

### Version Info

| **Range**            | **Key Features**               | **Based on** | **System Impact** |
|----------------------|--------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.               | \-           | \-                |
| 1.0.1.x              | Correction to discrete values. | 1.0.0.5      | External sets.    |
| 1.0.2.x \[SLC Main\] | Added DCF support.             | 1.0.1.3      | \-                |

### Product Info

| **Range** | **Supported Firmware**  |
|-----------|-------------------------|
| 1.0.0.x   | 2.01 (NMI-LSI-Firmware) |
| 1.0.1.x   | 2.01 (NMI-LSI-Firmware) |
| 1.0.2.x   | 2.01 (NMI-LSI-Firmware) |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | Yes                 | Yes                     | \-                    | \-                      |

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

The element created with this connector has the following data pages:

- **General**: This page displays system information, including the **System Time**, **System Description**, **System Location**, **System Contact**, **System Up Time**, and other general parameters.
- **Network**: This page displays the **Interfaces** table. This table displays the operational status of the interfaces available in the workstation. This operational status can change based on incoming traps.
- **Product Information**: This page displays the **Product Information**, **Modules**, and **Remote Maintenance** tables.
- **Traps**: This page displays the **Traps Destination** table.
- **Alarms**: This page displays the **Error Status** table. This table is both polled and updated based on traps. The table is cleared when a "Coldstart" trap is received.
- **NMI**: This page contains specific NMI interface data such as **Protocol Version**, **System ID**, **Control Point ID**, **IP Checksum Errors**, **UDP Checksum Errors**, **TCP Checksum Errors**, **NMI Discard Packets**, and **NMI Checksum Last Change**. It also contains page buttons that provide access to additional NMI data.
