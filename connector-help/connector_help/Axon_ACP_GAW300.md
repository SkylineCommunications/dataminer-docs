---
uid: Connector_help_Axon_ACP_GAW300
---

# Axon ACP GAW300

The GAW300 is an embedded domain audio watermarking embedder for Audience measurement (NexTrackerT), Second Screen applications (SyncNowr) or SNAP, or a combination of these services.

The Axon ACP GAW300 driver is used to monitor the GAW300 card.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1917, 2018             |

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

#### Serial IP Connection - Events

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

- **General:** Displays information about the identity of the card, along with other general information: Card Name, Card Description, SW Revision, HW Revision, etc.
- **License Management:** Displays the Kantar Media, SNAP and NexTracker license and license expiration date information.
- **System Configuration:** This page contains system configuration parameters such as Encoder Mode, Loudness Normalization, etc.
- **Time Management:** This page contains time information such as the automatic and manual synchronization time.
- **Video Options:** This page contains video input/output, phase and delay information.
- **Watermark Channels 1-4 ~ 13-16:** These pages contain information about the watermark channels 1-16, such as the audio source, the actual source channel, the kind of audio in specific audio pairs, the gain and the input status.
- **Embedder A ~ D:** These pages contain information about embedder A-D such as the embedder mode, embedder audio groups, embedder audio channels sources, the actual audio channel, the kind of audio in specific audio pairs, the gain phase and the delay of the outputs.
- **SDI In/Out Status:** This page displays SDI input and output status information. The **Embedded Audio Input/Output** subpages display the corresponding status information.
- **Embedder/AddOn Status:** This page displays Embedder Channels and Quad Speed Add On Input Status information.
- **Monitoring:** This page displays status information of the monitoring parameters.
- **Debug:** This page contains debug information.
- **Alarm Priority:** Displays the event messages of the card, i.e. special messages generated asynchronously on the card.

Note: If the setting of a parameter depends on another parameter, when you try to set the first of these parameters before the other parameter is set, a message box is displayed that explains what to do first. Follow the instructions in the message box and set the required parameter before you set the other parameter.

## DataMiner Connectivity Framework

The **1.0.0.x** driver range of the Axon ACP GAW300 protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **GAW300 SDI Input 1:** A single fixed interface of type **in**.
- **GAW300 SDI Input 2:** A single fixed interface of type **in**.
- **GAW300 SDI Output 1:** A single fixed interface of type **out**.
- **GAW300 SDI Output 2:** A single fixed interface of type **out**.

### Connections

#### Internal Connections

- **SDI Input 1 -\> SDI Output 1**
- **SDI Input 1 -\> SDI Output 2**
- **SDI Input 2 -\> SDI Output 1**
- **SDI Input 2 -\> SDI Output 2**
