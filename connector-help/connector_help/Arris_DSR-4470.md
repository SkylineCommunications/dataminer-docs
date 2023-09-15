---
uid: Connector_help_Arris_DSR-4470
---

# Arris DSR-4470

The Arris DSR-4470 is an integrated receiver and decoder that incorporates the latest HEVC decoder technology with additional support for MPEG-4 and MPEG-2 video decoding. This connector displays relevant information about this device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |

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

The element made using this connector has the following data pages:

- **General**: Displays information about the status of the device, including the Signal Status, Authorized Status and IRD Status.
- **Interfaces**: Displays the **Network Interface Table**, where you can configure the IP Address, Subnet Mask and Gateway of the available network interfaces.
- **Signal Status**: Contains the Signal Status Table, which displays information about the input signals, such as the Acquisition State, Eb/No and Signal Power.
