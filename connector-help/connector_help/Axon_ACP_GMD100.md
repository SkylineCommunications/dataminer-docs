---
uid: Connector_help_Axon_ACP_GMD100
---

# Axon ACP GMD100

The **GMD100** is a medium-time 3 Gb/s, HD and SD-SDI uncompressed baseband video delay. It can store and delay SDI video. It can store and delay up to 8 seconds in 3 Gb/s, 16 seconds in HD and 64 seconds in SD.

The Axon ACP GMD100 connector is used to manage GMD100 cards.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 0307                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (fixed value: *2071*).
  - **Bus address**: The bus address or slot number/position of the card in the frame.

#### Serial IP Connection - Events Connection

This connector uses a smart-serial connection and requires the following input during element creation:

SMART-SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination. Specify "any".
  - **IP port**: The IP port of the destination (fixed value: *2071*).
  - **Bus address**: The bus address or slot number/position of the card in the frame.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

## DataMiner Connectivity Framework

The **1.0.0.x** connector range of the Axon ACP UXU410 protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **SDI Input 1**: A single fixed interface of type **in**.
- **SDI Input 2**: A single fixed interface of type **in**.
- **SDI Input 3**: A single fixed interface of type **in**.
- **SDI Input 4**: A single fixed interface of type **in**.
- **SDI Output A**: A single fixed interface of type **out**.
- **SDI Output B**: A single fixed interface of type **out**.

### Connections

#### Internal Connections

- **SDI Input 1 -\> SDI Output A.**
- **SDI Input 1 -\> SDI Output B.**
- **SDI Input 2 -\> SDI Output A.**
- **SDI Input 2 -\> SDI Output B.**
- **SDI Input 3 -\> SDI Output A.**
- **SDI Input 3 -\> SDI Output B.**
- **SDI Input 4 -\> SDI Output A.**
- **SDI Input 4 -\> SDI Output B.**

## Notes

This connector is best combined with the Axon ACP Frame Manager connector, but can be used as a standalone connector as well.
