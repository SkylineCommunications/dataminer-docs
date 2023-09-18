---
uid: Connector_help_AVT_Magic_AE4_DAB+_Encoder
---

# AVT Magic AE4 DAB+ Encoder

The AVT Magic AE4 DAB+ Encoder is a standard DAB/DAB+ hardware encoder.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection - Main

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: This is not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.\]
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Initialization

No additional configuration is needed during creation of an element.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

On the **General** page of this connector, all hardware and software general information is provided.

The other pages describe the functionality of the connector and device and contain data that can be monitored.

## DataMiner Connectivity Framework

The **1.0.0.x** range of the AVT Magic AE4 DAB+ Encoder connector supports the usage of DCF and can only be used on a DMA with DataMiner version **8.5.4** or higher.

DCF can also be implemented through the DataMiner DCF user interface and through third-party DataMiner connectors (e.g. a manager).

### Interfaces

#### Dynamic Interfaces

Physical dynamic interfaces:

- The parameter table **Encoders** is a collection of all available encoders with the interface **type inout**.
