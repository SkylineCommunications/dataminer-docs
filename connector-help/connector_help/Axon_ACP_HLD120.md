---
uid: Connector_help_Axon_ACP_HLD120
---

# Axon ACP HLD120

The **HLD120** card is a long-time HD-SDI JPEG2000 compressed video delay. It can store and delay HD material, including all blanking, as RAW data. It adds a bug inserter for channel ident applications but also as an emergency overlay with its full frame capability.

The Axon ACP HLD120 connector is used to monitor and configure **HLD120** cards.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1515 1920 2019         |

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

  - **IP address/host**: The polling IP or URL of the destination/frame.
  - **IP port**: The IP port of the destination (fixed value: *2071*).
  - **Bus address**: The bus address or slot number/position of the card in the frame.

#### Serial Broadcast Connection

This connector uses a smart serial connection and requires the following input during element creation:

SMART SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination/frame
  - **IP port**: The IP port of the destination (fixed value: *2071*)
  - **Bus address**: The bus address or slot number/position of the card in the frame.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

This element has the following data pages:

- **General**: Displays general information about the card: Card Name, Card Description, SW Revision, HW Revision, etc.
- **SSD** Contains status information related to the two SSD disks.
- **GPIO**: Contains the GPI input and output status information.
- **Status**: Contains signal input and output status information. Also displays the CPU and FPGA temperatures.
- **Logo**: Contains the logo setting parameters for the processed output. The presets will have an instant effect on the output.
- **Marker**: Contains the marker preset settings and status parameters.
- **Settings**: Contains different configuration parameters.
- **Network**: Displays network settings and status parameters.
- **Alarm Priority**: Displays the event messages of the card, i.e. special messages generated asynchronously on the card.

## DataMiner Connectivity Framework

The **1.0.0.x** connector range of the Axon ACP HLD120 protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

Physical fixed interfaces:

- **SDI Input 1**: A single fixed interface of type **input**.
- **SDI Input 2**: A single fixed interface of type **input**.
- **SDI Output 1**: A single fixed interface of type **output**.
- **SDI Output 2**: A single fixed interface of type **output**

### Connections

Internal Connections

- **SDI Input 1 -\> SDI Output 1**
- **SDI Input 1 -\> SDI Output 2**
- **SDI Input 2 -\> SDI Output 1**
- **SDI Input 2 -\> SDI Output 2**
