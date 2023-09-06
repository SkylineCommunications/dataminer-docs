---
uid: Connector_help_Axon_ACP_DDP24
---

# Axon ACP DDP24

The DDP24 is a quad-speed multi-channel Dolby Digital (plus) encoder.

The **Axon ACP DDP24** driver can be used to display and configure information related to this device.

## About

The driver can be connected to the **Axon ACP Frame Manager**.

There are different possibilities available for **alarm monitoring** and **trending**.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 0605                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Installation and configuration

### Creation

The element using this driver can be automatically created by the parent element using the **Axon ACP Frame Manager** driver, but it can also be a standalone element.

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address**: The polling IP of the destination, containing four digits.
  - **Bus address**: The bus address of the device, being the slot number of the card.

#### Serial Broadcast Connection

This driver uses a serial connection and requires the following input during element creation:

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
- **Audio**
- **I/O**
- **Channel 1/8**
- **Channel 9/16**
- **Voice Over**
- **Encoder**
- **Metadata**
- **Dolby Digital Metadata**
- **Pro Logic II**
- **Dolby Stream Muxing**
- **Add-On**
- **Alarm Priority**: This page displays the event messages of the card, i.e. special messages generated asynchronously on the card.
