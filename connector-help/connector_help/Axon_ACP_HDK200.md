---
uid: Connector_help_Axon_ACP_HDK200
---

# Axon ACP HDK200

The HDK200 is an advanced keyer platform for use in transmission applications. The device is responsible for video processing, in particular graphics insertion and keying.

The **Axon ACP HDK200** driver can be used to display and configure information related to this device.

## About

There are different possibilities available for **alarm monitoring** and **trending**.

### Ranges of the driver

| **Driver Range**     | **Description** | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | Yes                 | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | 0915                        |

## Installation and configuration

### Creation

This element is automatically created by the element using the **Axon ACP Frame Manager** driver, but can be used as standalone driver.

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **Bus address**: The bus address of the device.

#### Serial Broadcast Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **Bus address**: The bus address of the device.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## Usage

This element has the following data pages:

- **General**: This page displays general information about the card: **Card Name**, **Card Description**, **SW Revision**, **HW Revision**, etc.
- **Network**
- **DVE Settings**
- **Mixer Options**
- **Audio**
- **Audio Proc Amplifier**
- **Keyer**
- **Embedder**
- **De-Embedder**
- **GPI Mode**
- **Alarm Priority**: This page displays the event messages of the card, i.e. special messages generated asynchronously on the card.

## DataMiner Connectivity Framework

The Axon ACP driver supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

Connectivity for this driver is managed by the driver itself, but creation can be done by the parent driver Axon ACP Frame Manager.

## Notes

It is recommended to use this driver in combination with the **Axon ACP Frame Manager** driver for optimal coverage of information.
