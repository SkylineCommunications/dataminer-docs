---
uid: Connector_help_Axon_ACP_HXT150
---

# Axon ACP HXT150

The HXT150 dual output up-/down-/cross-converter is a transmission tool optimized to have a second channel running on a medium long offset delay that will improve statistical multiplexing efficiency.

The **Axon ACP HXT150** connector is used to configure and monitor the HXT150 Axon card.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 8163                   |

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

#### Serial Broadcast Connection

This connector uses a smart-serial connection and requires the following input during element creation:

SMART SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination. Specify "*any*".
  - **IP port**: The IP port of the destination (fixed value: *2071*).
  - **Bus address**: The bus address or slot number/position of the card in the frame.

Note: The configuration of the element can also be performed via the Axon ACP Frame Manager. The Frame Manager will auto-populate the elements in the system if the card connectors are available.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element has the following data pages:

- **General**: Displays information about the identity of the card and other general information: **Card Name**, **Card Description**, **SW Revision**, **HW Revision**, etc.
- **I/O:** Contains the input and output settings.
- **Up Conversion**: Allows you to configure the settings for the channels when in the up-conversion mode.
- **Down Conversion:** Allows you to configure the settings for the channels when in the down-conversion mode.
- **Cross Conversion:** Allows you to configure the settings for the channels when in the cross-conversion mode.
- **Transparent:** Allows you to configure the settings for the channels when in transparent mode. In transparent mode (no conversion), the card is not transparent for horizontal and vertical blanking, except for selected ANC data handling.
- **Inserter:** Contains parameters used to insert data values in the VBI of the outputs.
- **Video Processing:** Contains parameters used to configure the **Gain** and **Black** of the video of the channels.
- **Audio Processing:** Contains the audio parameters of the channels.
- **Embedder:** Contains the settings for the **Audio Embedder Groups.**
- **GPI:** Contains parameters used to configure the GPI contacts and pools.
- **Network:** Contains the **IP Configuration** and **Network Status** information.
- **Status:** Contains status information of the card.
- **Alarm Priority:** Displays the event messages of the card, i.e. special messages generated asynchronously on the card**.**

## DataMiner Connectivity Framework

The **1.0.0.x** connector range of the Axon ACP HXT150 protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance, a manager).

### Interfaces

Physical fixed interfaces:

- **SDI Input 1**: A single fixed interface of type **input**.
- **SDI Input 2**: A single fixed interface of type **input**.
- **SDI Output A1**: A single fixed interface of type **output**.
- **SDI Output A2**: A single fixed interface of type **output**.
- **SDI Output B1**: A single fixed interface of type **output**.
- **SDI Output B2**: A single fixed interface of type **output**.

#### Connections

#### Internal Connections

- **SDI Input 1 -\> SDI Output A1**
- **SDI Input 1 -\> SDI Output A2**
- **SDI Input 1 -\> SDI Output B1**
- **SDI Input 1 -\> SDI Output B2**
- **SDI Input 2 -\> SDI Output A1**
- **SDI Input 2 -\> SDI Output A2**
- **SDI Input 2 -\> SDI Output B1**
- **SDI Input 3 -\> SDI Output B2**
