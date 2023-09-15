---
uid: Connector_help_GatesAir_Flexiva_M3FM-TX_1P1
---

# GatesAir Flexiva M3FM-TX 1P1

The GatesAir Flexiva M3FM-TX is an FM transmission system.

This connector is used to monitor the GatesAir Flexiva M3FM-TX 1P1. It uses **SNMP** to retrieve and configure the data.

## About

### Version Info

| **Range**            | **Key Features**                           | **Based on** | **System Impact** |
|----------------------|--------------------------------------------|--------------|-------------------|
| 1.0.1.x \[SLC Main\] | Polling on group changed from hour to min. | 1.0.1.3      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.1.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.
- **Device address**: Not used.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The element has the following data pages:

- **General**: This page displays basic SNMP information. It has two subpages, **General Events** and **DVE Control**. The latter contains the **Transmitter DVE Table**, with the controls for the transmitter DVE.
- **Transmitter**: Displays a table with the transmitter information and status.
- **Configuration**: Contains the Transmitter Configuration Table, with information about the transmitter status.
- **Events**: Displays Transmitter Events Table, with information about events regarding the transmitter.
- **System**: Contains system information related to the transmitter.
