---
uid: Connector_help_Axon_ACP_HFS010
---

# Axon ACP HFS010

The HFS010 is a 3 Gb/s, HD, SD basic frame synchronizer.

The **Axon ACP HFS010** driver can be used to display and configure information related to this device.

## About

The driver can be connected to the **Axon ACP Frame Manager**.

There are different possibilities available for **alarm monitoring** and **trending**.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 6034, 6040             |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Installation and configuration

### Creation

The element using this driver can be automatically created by the parent element using the **Axon ACP Frame Manager** driver, but it can also be a standalone element.

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address**: The polling IP of the destination, containing four digits.
  - **Bus address**: The bus address of the device, being the slot number of the card.

#### Serial Broadcast Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address**: The polling IP of the destination, containing four digits.
  - **Bus address**: The bus address of the device.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element has the following data pages:

- **General**: This page displays general information about the card: **Card Name**, **Card Description**, **SW Revision**, **HW Revision**, etc.
- **Status**
- **I/O**
- **GPI**
- **Video**
- **Inserter**
- **Options**
- **Embedder A/B**
- **Embedder C/D**
- **Network**
- **Alarm Priority**: This page displays the event messages of the card, i.e. special messages generated asynchronously on the card.

## DataMiner Connectivity Framework

The Axon ACP protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner Third Party protocols (for instance a manager).

### Interfaces

#### Physical Interfaces

- **SDI Input**: A single fixed interface of type **input**.
- **REF Input 1**: A single fixed interface of type **input**.
- **REF Input 2**: A single fixed interface of type **input**.
- **SDI Output 1**: A single fixed interface of type **output**.
- **SDI Output 2**: A single fixed interface of type **output**.
- **SDI Output 3**: A single fixed interface of type **output**.
- **SDI Output 4**: A single fixed interface of type **output**.
