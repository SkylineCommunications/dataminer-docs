---
uid: Connector_help_Axon_ACP_2TG100
---

# Axon ACP 2TG100

The **2TG100** is a dual channel test pattern generator. Locked to a black & burst or tri-level sync, it can generate two fully independent test patterns in either 3Gb/s, HD or SD.

The **Axon ACP** **2TG100** driver can be used to display and configure information related to this device.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1109 0807              |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

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
  - **Bus address**: The bus address of the device is the slot number/position of the card in the frame

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to Use

The element has the following data pages:

- **General**: This page displays general information about the card: **Card Name**, **Card Description**, **SW Revision**, **HW Revision**, etc.
- **Video Generator**: This page contains the following subpages: **Audio Embedder A** and **Audio Embedder B**.
- **Embedder S2020**
- **ANC Inserter**
- **Options**
- **Lip Sync**
- **Audio Generator:** This page contains the following subpages: **Embedder A**, **Embedder B**, **Embedder C** and **Embedder D**.
- **Config**
- **Monitoring**
- **Network**
- **Alarm Priority**


