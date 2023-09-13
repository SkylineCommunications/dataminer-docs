---
uid: Connector_help_Axon_ACP_HIX100
---

# Axon ACP HIX100

The **HIx100** is a dual-channel high-performance 3 Gb/s, HD and SD SDI video and embedded audio probe (signal integrity monitor) with a clean video switch-over function.

The **Axon ACP HIX100** driver can be used to display and configure information related to this device.

## About

### Version Info

| **Range** | **Key Features**             | **Based on** | **System Impact** |
|-----------|------------------------------|--------------|-------------------|
| 1.0.0.1   | Initial version \[SLC Main\] | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1925                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Creation

The element using this driver can be automatically created by the parent element using the **Axon ACP Frame Manager** driver, but it can also be a standalone element.

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection

- **IP address/host**: The polling IP or URL of the destination
  - **Bus address**: The bus address of the device is the slot number/position of the card in the frame.

#### Serial IP Connection - Broadcast Connection

This driver uses a smart-serial connection and requires the following input during element creation:

SMART-SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: any
  - **Bus address**: The bus address of the device is the slot number/position of the card in the frame.

## Usage

The element has the following data pages:

- **General**: This page displays general information about the card: **Card Name**, **Card Description**, **SW Revision**, **HW Revision**, etc.
- **SFP**
- **Add-On**
- **Status**
- **I/O Status**
- **LUT**
- **I/O**
- **GPI/O**
- **Video**
- **Audio**
- **Settings**
- **Embedder**
- **Embedder 01/04**
- **Embedder 05/08**
- **Embedder 09/12**
- **Embedder 13/16**
- **Network**
- **Alarm Priority**: This page displays the event messages of the card, i.e. special messages generated asynchronously on the card.

## DataMiner Connectivity Framework

The **1.0.0.x** driver range of the Axon ACP HIX100 protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Physical Interfaces

- **SDI Input 1**: A single fixed interface of type **input**.
- **SDI Input 2**: A single fixed interface of type **input**.
- **SDI Input 3**: A single fixed interface of type **input**.
- **SDI Input 4**: A single fixed interface of type **input**.
- **SDI Output A1**: A single fixed interface of type **output**.
- **SDI Output A2**: A single fixed interface of type **output**.
- **SDI Output B1**: A single fixed interface of type **output**.
- **SDI Output B2**: A single fixed interface of type **output**.
