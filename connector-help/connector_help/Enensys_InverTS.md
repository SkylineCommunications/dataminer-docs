---
uid: Connector_help_Enensys_InverTS
---

# Enensys InverTS

This driver retrieves and monitors data from the device. The **Enensys InverTS** is a DVB-T2 Gateway reverse function designed to receive up to two T2-MI streams over satellite, ASI or IP, containing either a single PLP or multiple PLP, and capable of de-encapsulating the T2-MI streams into one or several MPEG-2 TS over ASI and IP.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | SNMP connection  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.1.2                  |

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

The driver allows you to configure general parameters such as **Date Time**, **Device Name, Device Location**, **Network Interfaces** and **Alarms.**

It is also possible to configure the **Network Interfaces**. Specifically, you can update parameters like the **Speed**, **Duplex** mode, **IPv4 Address**, **Netmask** and **Gateway**.

In the **Current** **Alarms** table, you can find the **Component**, **Root Time**, **Severity** and a brief **Description** of each alarm.

On separate pages, you can find the configuration of **Inputs** and **Outputs** for both T2-MI streams.

- For the inputs, you can configure the **Piping**, **Main/Backup Input** and **BISS**. You can also find information about the **ASI** and **SAT** bitrates.
- For the outputs, you can configure the following parameters: **Extraction**, **ASI Out State**, **ASI Out Optimize**, **ASI Out Bitrate**, **ASI Out Mirrored State**.
