---
uid: Connector_help_Grass_Valley_RD2000
---

# Grass Valley RD2000

This connector is designed to support monitoring and configuration of a Grass Valley RD2000 multiformat MPEG-4 receiver. It allows you to select and configure the inputs, audio and video processors and decoders. In addition, a service hunt functionality is also available.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 6.6.1                  |

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

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The connector supports the following features:

- Input selection (ASI and DVB-S/S2) and configuration.

- Video and audio processors monitoring and configuration.

- Video and audio decoders monitoring and configuration.

- Dual (mirrored) SDI or HD-SDI video outputs.
  - Two audio decoders on dual units (some units have only one).

- Decrypt BISS encrypted transport streams (Mode 1 and Mode E).

- Closed caption (NTSC and DTVCC) overlays.

- Service hunt functionality.
