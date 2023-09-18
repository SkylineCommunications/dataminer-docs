---
uid: Connector_help_Axon_ACP_2GF100
---

# Axon ACP 2GF100

The 2GF100 is a dual-channel 3 Gb/s, HD, SD frame synchronizer with optional audio shuffler.

The **Axon ACP 2GF100** connector can be used to display and configure information related to this device.

## About

The connector can be connected to the **Axon ACP Frame Manager**.

There are different possibilities available for **alarm monitoring** and **trending**.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 6034, 6040, 6246       |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Installation and configuration

### Creation

The element using this connector can be automatically created by the parent element using the **Axon ACP Frame Manager** connector, but it can also be a standalone element.

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address**: The polling IP of the destination, containing four digits.
  - **Bus address**: The bus address of the device, being the slot number of the card.

#### Serial Broadcast Connection

This connector uses a serial connection and requires the following input during element creation:

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
- **Input Status**
- **Output Status**
- **I/O**
- **GPI**
- **Options**
- **Channel A**
- **Channel B**
- **Audio**
- **Shuffler**
- **Network**
- **Alarm Priority**: This page displays the event messages of the card, i.e. special messages generated asynchronously on the card.

## DataMiner Connectivity Framework

The Axon ACP protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Physical Interfaces

- **SDI Input 1**: A single fixed interface of type **input**.
- **SDI Input 2**: A single fixed interface of type **input**.
- **CVBS Input**: A single fixed interface of type **input**.
- **REF Input 1**: A single fixed interface of type **input**.
- **REF Input 2**: A single fixed interface of type **input**.
- **SDI Output A1**: A single fixed interface of type **output**.
- **SDI Output A2**: A single fixed interface of type **output**.
- **SDI Output B1**: A single fixed interface of type **output**.
- **SDI Output B2**: A single fixed interface of type **output**.

#### Virtual Interfaces

- **SYNAPSE Bus 1**: A single fixed interface of type **inout**.
- **SYNAPSE Bus 2**: A single fixed interface of type **inout**.
- **SYNAPSE Bus 3**: A single fixed interface of type **inout**.
- **SYNAPSE Bus 4**: A single fixed interface of type **inout**.
