---
uid: Connector_help_Ateme_DR8400
---

# Ateme DR8400

This SNMP driver can be used to monitor and control the Ateme DR8400. Alarm monitoring and trending can be enabled on many important parameters. The driver communicates with the Ateme DR8400 decoder using SNMP.

## About

### Version Info

| **Range**            | **Key Features**             | **Based on** | **System Impact** |
|----------------------|------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.             | \-           | \-                |
| 1.0.1.x              | New firmware version 2.0.0.x | \-           | \-                |
| 1.1.0.x \[SLC Main\] | New firmware version.        | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**   |
|-----------|--------------------------|
| 1.0.0.x   | 1.1.0.2/1.0.0.4(@162938) |
| 1.0.1.x   | 2.0.0.x                  |
| 1.1.0.x   | N/A                      |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.1.0.x   | No                  | No                      | \-                    | \-                      |

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

The element created with this driver consists of the following data pages:

- **General**: Displays general information about the device, such as the Software Version, Temperature, Power Supply Status, etc.
- **Input**: Displays the input values for Satellite, IP and ASI. Via page buttons, you can configure parameters related to IP, SMM and Failover.
- **Decoder**: Displays decoding settings. The **Services** page button displays all incoming services. Several other page buttons are available that open subpages with **CA** (Conditional Access), **Data**, **Audio,** and **Video** settings.
- **Video/Audio Output**: Allows you to configure audio and video output settings, so that you can define what the output should look like. Several page buttons are available that open subpages with additional settings: **Emulation**, **Downscale**, **Mapping**, **IP Output**, **Forward,** and **Genlock**.
- **Configuration**: Contains a table listing configurations. In addition, **Management Load** and **Management Store** controls are available.
