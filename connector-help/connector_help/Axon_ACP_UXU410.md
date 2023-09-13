---
uid: Connector_help_Axon_ACP_UXU410
---

# Axon ACP UXU410

The **UXU410** is a high-end up-/down-/cross-converter. The card allows you to simulcast any output standard in any format from any source standard. The embedded audio is carried over to the SD, HD or 3 Gb/s domain.

The Axon ACP UXU410 driver is used to manage UXU410 Axon cards.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1720 1925              |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (fixed value: *2071*).
  - **Bus address**: The bus address or slot number/position of the card in the frame.

#### Serial IP Connection - Events Connection

This driver uses a smart-serial connection and requires the following input during element creation:

SMART-SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (fixed value: *2071*).
  - **Bus address**: The bus address or slot number/position of the card in the frame.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The setting of some parameters depends on other parameters' current value. For example, on the Network page, in order to set the Preferred IP Address, you need to make sure the IP Configuration is set to *Manual* mode. When such a parameter is not set to the correct value, a message box will be displayed. Follow the instructions in the message box and set the required parameter to the appropriate value before setting the other parameter.

## DataMiner Connectivity Framework

The **1.0.0.x** driver range of the Axon ACP UXU410 protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **SDI Input 1**: A single fixed interface of type **in**.
- **SDI Input 2**: A single fixed interface of type **in**.
- **SDI Input 3**: A single fixed interface of type **in**.
- **SDI Input 4**: A single fixed interface of type **in**.
- **SDI Output 1**: A single fixed interface of type **out**.
- **SDI Output 2**: A single fixed interface of type **out**.
- **SDI Output 3**: A single fixed interface of type **out**.
- **SDI Output 4**: A single fixed interface of type **out**.

### Connections

#### Internal Connections

- **SDI Input 1 -\> SDI Output 1.**
- **SDI Input 1 -\> SDI Output 2.**
- **SDI Input 1 -\> SDI Output 3.**
- **SDI Input 1 -\> SDI Output 4.**
- **SDI Input 2 -\> SDI Output 1.**
- **SDI Input 2 -\> SDI Output 2.**
- **SDI Input 2 -\> SDI Output 3.**
- **SDI Input 2 -\> SDI Output 4.**
- **SDI Input 3 -\> SDI Output 1.**
- **SDI Input 3 -\> SDI Output 2.**
- **SDI Input 3 -\> SDI Output 3.**
- **SDI Input 3 -\> SDI Output 4.**
- **SDI Input 4 -\> SDI Output 1.**
- **SDI Input 4 -\> SDI Output 2.**
- **SDI Input 4 -\> SDI Output 3.**
- **SDI Input 4 -\> SDI Output 4.**

## Notes

This driver is best combined with the Axon ACP Frame Manager driver, but it can be used as a standalone driver as well.
