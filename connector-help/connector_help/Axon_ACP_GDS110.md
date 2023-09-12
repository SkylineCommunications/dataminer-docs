---
uid: Connector_help_Axon_ACP_GDS110
---

# Axon ACP GDS110

The GDS110 is a 3 Gb/s, HD, SD down-converter/synchronizer with optional audio shuffler.

The Axon ACP GDS110 connector can be used to display and configure information related to this device. This connector **can be automatically generated** by the **Axon ACP** connector. There are different possibilities available for **alarm monitoring** and **trending**.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 6893, 7499,7817        |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

The element using this connector can be automatically created by the parent element using the **Axon ACP** connector, but it can also be a standalone element.

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **Bus address**: The bus address of the device, being the slot number of the card.

#### Serial Broadcast Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **Bus address**: The bus address of the device.

## Usage

This element has the following data pages:

- **General**: This page displays general information about the card: **Card Name**, **Card Description**, **SW Revision**, **HW Revision**, etc.
- **Status**
- **Input**
- **I/O**
- **GPI**
- **Settings**
- **Options**
- **Video**
- **Inserter**
- **Transparent**
- **Down Conversion**
- **Embedder**
- **Embedder A**
- **Embedder B**
- **Embedder C**
- **Embedder D**
- **De-Embedder**
- **Network**
- **Alarm Priority**: This page displays the event messages of the card, i.e. special messages generated asynchronously on the card.

## DataMiner Connectivity Framework

The Axon ACP connector supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Physical Interfaces

- **SDI Input 1**: A single fixed interface of type **input**.
- **SDI Input 2**: A single fixed interface of type **input**.
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
