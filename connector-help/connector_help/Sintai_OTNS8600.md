---
uid: Connector_help_Sintai_OTNS8600
---

# Sintai OTNS8600

The OTNS8600 is a 2U chassis that works with optical cards to enable the operation of an optical transmission network system.

The Sintai OTNS8600 SNMP connector can be used to monitor the transmission power, currents, voltages, etc.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                | **Based on** | **System Impact** |
|----------------------|-------------------------------------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | \- Monitoring of the optical line protection system. - Monitoring of the NCP Ethernet and fiber ports. - Monitoring of the OTDS Ethernet ports. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.0.18                 |

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

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector consists of the data pages detailed below.

### General

This page contains general information about the device, such as the **Description**, **Contact** and **System Up time**. It also contains information about the **Modules**, **Fans** and **Power**.

### Line Protection

This page contains the **OLP** table, where you can monitor parameters such as the R1 Power, R2 Power and Tx Power.

### Network Management

This page contains the **NCP Ethernet Ports** and the **NCP Fiber Ports** table. In these tables, you can monitor the **Link Status** and **Mode** of the ports.

### OTDS

This page contains the **OTDS Ethernet Ports** table, which allows you to monitor the **Power**, **Voltage** and **Current** of the ports.
