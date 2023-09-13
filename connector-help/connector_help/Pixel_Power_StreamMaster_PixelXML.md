---
uid: Connector_help_Pixel_Power_StreamMaster_PixelXML
---

# Pixel Power StreamMaster PixelXML

**PixelXML** is the Pixel Power control protocol used for products based on the StreamMaster technology.

This driver allows you to monitor StreamMaster products.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                   |
|-----------|------------------------------------------|
| 1.0.0.x   | 1.6 (PixelXML Client and Server version) |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *10220*).

#### Serial IP Connection - Asynchronous Feedback Connection

This driver uses a smart serial connection and requires the following input during element creation:

SMART SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *10221*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this driver consists of the following data pages:

- **General**: Displays general information about the product, such as name, type, software version, PixelXML version, etc.
- **Media Player Status**: Displays information about the media player device, category, timecode and sub device number.
- **Player**: Contains the list of media players and related information. The **Detach Media** button on this page allows you to release/free up all media player resources.
- **Tracks**: Displays video and audio media information.
- **Layer State Status**: Displays information about the layer state device, category, timecode and sub device number.
- **Layers**: Contains the list of layers and related information. Also contains page buttons to the **Audio Channels Group** and **Audio Shuffle Mapping** subpages.
- **Event Log**: Contains the list of events with Error and Warning types.
- **System Health**: Contains the list of messages about the general health status of the system.
