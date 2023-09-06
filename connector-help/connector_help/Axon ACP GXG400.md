---
uid: Connector_help_Axon_ACP_GXG400
---

# Axon ACP GXG400

The GXG400 is a high end Up/Down/Cross converter.

The **Axon ACP GXG400** driver can be used to display and configure information related to this device.

## About

### Version Info

| **Range** | **Key Features**             | **Based on** | **System Impact** |
|-----------|------------------------------|--------------|-------------------|
| 1.0.0.x   | Initial Version \[SLC Main\] | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 0606 2426              |

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
  - **IP port**: The IP port of the destination. (fixed value: *2071*)
  - **Bus address**: The bus address of the device, being the slot number of the card.

#### Serial Broadcast Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination. (fixed value: *2071*)
  - **Bus address**: The bus address of the device, being the slot number of the card.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element has the following data pages:

- **General**: This page displays general information about the card: **Card Name**, **Card Description**, **SW Revision**, **HW Revision**, etc.

- **SFP**

- **Add-On**

- **Status**

- **I/O Status**

- **I/O**

- **GPI/O**

- **Video: This page displays settings for video configuration and contains multiple subpages:**

- **Up Converter: Allows to configure and set Up Converter Presets;**
  - **Down C**onverter**: Allows to configure and set Down Converter Presets;**
  - **Cross Converter: Allows to configure and set Cross Converter Presets;**
  - ****Transparent**: Allows to configure and set Transparent pass Presets (with ARC function);**
  - ****Inserter**: Allows to configure and set simultaneous Vi, WSS, and AFD (S2016) insertion Presets;
    **

- **Audio**

- **Settings**

- **Embedder**

- **Embedder 01/04**

- **Embedder 05/08**

- **Embedder 09/12**

- **Embedder 13/16**

- **Network**

- **Alarm** **Priority**: This page displays the event messages of the card, i.e. special messages generated asynchronously on the card.



## Dataminer Connectivity Framework

The **1.0.0.x** driver range of the Axon ACP GXG400 protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner Third Party protocols (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **SDI Input 1**: A single fixed interface of type **input**.
- **SDI Input 2**: A single fixed interface of type **input**.
- **SDI Input 3**: A single fixed interface of type **input**.
- **SDI Input 4**: A single fixed interface of type **input**.
- **SDI Output 1**: A single fixed interface of type **output**.
- **SDI Output 2**: A single fixed interface of type **output**.
- **SDI Output 3**: A single fixed interface of type **output**.
- **SDI Output 4**: A single fixed interface of type **output**.

### Connections

#### Internal Connections

Depending on the state of the **Input Selection A**, the following connections are established:

- **SDI-1**: Between **SDI Input 1** and **SDI Output 1.**
- **SDI-2**: Between **SDI Input 2** and **SDI Output 1.**
- **SDI-3**: Between **SDI Input 3** and **SDI Output 1.**
- **SDI-4**: Between **SDI Input 4** and **SDI Output 1**.



