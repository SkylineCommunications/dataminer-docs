---
uid: Connector_help_Axon_ACP_HVD10
---

# Axon ACP HVD10

The Axon ACP HVD10 is an HD-SDI video offset delay of up to 32 frames.

This driver allows you to monitor status information and configure control parameters of the HVD10 Axon card.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 06081315               |

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

The element has the following pages:

- **General**:This page displays general information about the card: Card Name, Card Description, SW Revision, HW Revision, etc.
- **Status**:This page contains status parameters.
- **I/O**:This page contains input/output control parameters that are used to configure the I/O settings of the card.
- **Video**:This page contains control parameters used to configure the video settings of the card.
- **Audio**:This page contains audio status information for each individual channel, as well as control parameters to configure the audio settings of the card.
- **Alarm Priority**:This page displays the event messages of the card, i.e. special messages generated asynchronously on the card.

## DataMiner Connectivity Framework

The **1.0.0.x** driver range of the Axon ACP HVD10 protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner Third Party protocols (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **HVD10 SDI Input**: A single fixed interface of type **in**.
- **HVD10 SDI Output 1**: A single fixed interface of type **out**.
- **HVD10 SDI Output 2**: A single fixed interface of type **out**.
- **HVD10 SDI Reclocked Output**: A single fixed interface of type **out**.

### Connections

#### Internal Connections

- **SDI Input -\> SDI Output 1**
- **SDI Input -\> SDI Output 2**
- **SDI Input -\> SDI Reclocked Output**
