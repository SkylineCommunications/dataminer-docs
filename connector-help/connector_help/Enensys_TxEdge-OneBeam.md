---
uid: Connector_help_Enensys_TxEdge-OneBeam
---

# Enensys TxEdge-OneBeam

TxEdge-OneBeam is an ENENSYS solution designed to reduce satellite OPEX costs by delivering Direct-To-Home (DTH) TV and Digital Terrestrial TV (DTT) distribution over one satellite feed that supports DVB-T/T2 and DVB-S/S2 standards.

This connector uses SNMP to poll information from the TxEdge-OneBeam device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 4.1.3                  |

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
- **Bus address**: The bus address of the device.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

On the **General** page, you can find status and configuration parameters related to the device.

On the **Network** page, several tables are available:

- The **Network Interfaces Table** allows you to configure the IP addresses and contains different settings related to each interface.
- The **IP** **Configuration Table** allows you to select the state, ports, destination IPs etc. for each IP input/output.
- The **IP Statistics Table** displays information about the bit rate, jitter, etc.

The **TS Display** page contains transport stream and service information.

The **Satellite** page contains input 1 and 2 status parameters such as RF Level, BER and Symbol Rate. You can also configure parameters such as DVB Mode, Satellite Frequency, LNB Frequency, etc.

The **Headend** page contains status parameters related to ASI 1, 2 and 4, such as the bit rates. It also displays bit rates related to layer 1 to 7. Finally, it also allows you to configure the Product Mode, Main Source and Backup Source for the input.
