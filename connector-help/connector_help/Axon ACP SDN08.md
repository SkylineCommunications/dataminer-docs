---
uid: Connector_help_Axon_ACP_SDN08
---

# Axon ACP SDN08

The **Axon ACP SDN08** is a single-input, eight-output distribution amplifier.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 0800 0900              |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### IP Connection - Unicast

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device (by default *2071*).
  - **Bus address**: The bus address of the device.

#### IP Connection - Broadcast

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP of the device. Set this field to the value "*any*".
  - **IP port**: The IP port of the device, by default *2072*.
  - **Bus address**: Specify "*any*".

## How to Use

This driver is used to monitor the parameters of the Axon card.

The parameter "Input Detection" makes it possible to detect if there is an input.

## DataMiner Connectivity Framework

The **1.0.0.x** driver range of the Axon ACP SDN08 protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner Third Party protocols (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **SDN08 SDI Input** is a fixed interface of type **in.**
- **SDN08 SDI Output 1** is a fixed interface of type **out.**
- **SDN08 SDI Output 2** is a fixed interface of type **out.**
- **SDN08 SDI Output 3** is a fixed interface of type **out.**
- **SDN08 SDI Output 4** is a fixed interface of type **out.**
- **SDN08 SDI Output 5** is a fixed interface of type **out.**
- **SDN08 SDI Output 6** is a fixed interface of type **out.**
- **SDN08 SDI Output 7** is a fixed interface of type **out.**
- **SDN08 SDI Output 8** is a fixed interface of type **out.**
