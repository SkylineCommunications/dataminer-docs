---
uid: Connector_help_Axon_ACP_GEE200
---

# Axon ACP GEE200

The **Axon GEE200** is an embedded domain Dolby E/D/D+ to Dolby E processor. It is based on the Dolby's Cat. No. 1100 submodule, and capable of decoding Dolby E, Dolby Digital and Dolby Digital Plus, and encoding to Dolby E.

This driver allows you to monitor and configure this card.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 0807                   |

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

SMART SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination. Specify "any".
  - **IP port**: The IP port of the destination (fixed value: *2071*).
  - **Bus address**: The bus address or slot number/position of the card in the frame.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this driver consists of the following data pages:

- **General**: Displays information about the identity of the card and other general information: Card Name, Card Description, SW Revision, HW Revision, etc. Via the **Dolby CAT1100** page button, you can access more information about the Dolby CAT1100 submodule.
- **Video**: Allows you to configure and monitor the input and output parameters.
- **Delay**: Allows you to configure and monitor delay parameters.
- **Dolby Decoder**: Allows you to configure and monitor parameters related to the Dolby decoder. Also contains the **Dolby D+ Decoder** and **Add-on Input** page buttons.
- **Dolby Encoder**: Allows you to configure the Dolby encoder inputs source and specific channels.
- **Embedder Input**: Displays in which line the first package (Start-of-Frame) of non-PCM audio and data in the corresponding audio pair is detected. Also contains the embedder inputs format.
- **Embedder Audio Output**: Contains embedder audio output settings. These allow you to select where the audio channels of embedder 1 come from. Also contains the **Embedder Gain** and **Embedder Delay** page buttons.
- **Embedder Output**: Displays the status of the embedder output channels and the format of the outputs of the embedder.
- **Metadata Config**: Contains metadata configuration parameters.
- **Metadata Program**: Contains the audio program metadata configuration parameters.
- **Metadata Status**: Displays the status of metadata parameters.
- **MISC**
- **S2020**: Displays S2020 parameters.

## DataMiner Connectivity Framework

The **1.0.0.x** driver range of the Axon ACP GEE200 protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **SDI Input 1**: A single fixed interface of type **in**.
- **SDI Input 2**: A single fixed interface of type **in**.
- **SDI Output 1**: A single fixed interface of type **out**.
- **SDI Output 2**: A single fixed interface of type **out**.

### Connections

#### Internal Connections

- **SDI Input 1 -\> SDI Output 1**.
- **SDI Input 1 -\> SDI Output 2**.
- **SDI Input 2 -\> SDI Output 1**.
- **SDI Input 2 -\> SDI Output 2**.
