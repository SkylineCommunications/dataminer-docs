---
uid: Connector_help_EVS_Live_Production_Server
---

# EVS Live Production Server

The EVS Live Production Server is designed to monitor a wide range of EVS live production server products (e.g. EVS XT Via, XS Via, XT-Go, etc.).

These live production servers provide precise control over live broadcast production scenarios, integrating formats and protocols from HD to 8K, SDR to HDR, and SDI to IP.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 20.00.17               |

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

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The element consists of the following data pages:

- **General**: Displays general parameters such as name, contact, system uptime, and state. Via page buttons, you can also see information related to hardware, product management, and traps.
- **Channels**: Displays information related to the channels, such as base, port channels, and control settings.
- **Network**: Displays network-related information. Via page buttons, you can access a table with all monitored interfaces.
- **Server Configuration**: Displays configuration parameters related to the EVS server.
- **Server Monitoring**: Mainly displays the modules table, with information about errors and channels per module.
- **Server Administration**: Displays administrative data that can be used for alarm monitoring.
- **Server State**: Displays information about the current state of the server with respect to tasks and processes.
- **Storage**: Displays storage information, i.e. mainly capacity and capacity warning values. Via page buttons, you can get a detailed overview of the current state of all disks, the RAID configuration, and enclosures information.
