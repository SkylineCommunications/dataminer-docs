---
uid: Connector_help_Axon_ACP_SVD10
---

# Axon ACP SVD10

The Axon SVD10 is a frame synchronizer, with auto phaser and video delay of 24 frames.

This driver allows you to monitor status information and configure control parameters of the Axon SVD10 card.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 0707                   |

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

- **IP address/host**: The polling IP or URL of the destination. Specify "any".
  - **IP port**: The IP port of the destination (fixed value: *2071*).
  - **Bus address**: The bus address or slot number/position of the card in the frame.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element has the following pages:

- **General**: This page displays general information about the card: Card Name, Card Description, SW Revision, HW Revision, etc.
- **I/O**: This page contains input/output control parameters that are used to configure the I/O settings of the card.
- **Settings**: This page contains control parameters other than I/O parameters, such as synchronization or delay mode of the card, and settings related to video freeze.
- **Status**: This page contains status parameters.
- **Alarm Priority**: This page displays the event messages of the card, i.e. special messages generated asynchronously on the card.

## DataMiner Connectivity Framework

The **1.0.0.x** driver range of the Axon ACP SVD10 protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner Third Party protocols (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **SVD10 SDI Input:** A single fixed interface of type **in**.
- **SVD10 SDI Output 1:** A single fixed interface of type **out**.
- **SVD10 SDI Output 2:** A single fixed interface of type **out**.
- **SVD10 SDI Reclocked Output 1:** A single fixed interface of type **out**.
- **SVD10 G/Y/CVBS Output:** A single fixed interface of type **out**.
- **SVD10 B/Pb/Y Output:** A single fixed interface of type **out**.
- **SVD10 R/Pr/C Output:** A single fixed interface of type **out**.

### Connections

#### Internal Connections

- **SDI Input -\> SDI Output 1**
- **SDI Input -\> SDI Output 2**
- **SDI Input -\> SDI Reclocked Output 1**
- **SDI Input -\> G/Y/CVBS Output**
- **SDI Input -\> B/Pb/Y Output**
- **SDI Input -\> R/Pr/C Output**
