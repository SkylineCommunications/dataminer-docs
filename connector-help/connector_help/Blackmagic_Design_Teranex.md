---
uid: Connector_help_Blackmagic_Design_Teranex
---

# Blackmagic Design Teranex

Built with professional A/V installations and live events in mind, the Blackmagic Design Teranex allows 1089 up, down, cross, and standards conversions for formats ranging from NTSC and PAL to 2K and UHD 4K video.
Regardless of conversion, all processing is done in real time with minimal latency of approximately two frames.

## About

### Version Info

| **Range**            | **Key Features**             | **Based On** | **System Impact** |
|----------------------|------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version - Teranex AV | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                       |
|-----------|--------------------------------------------------------------|
| 1.0.0.x   | This driver only supports Teranex AV Protocol Preamble: 3.22 |

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

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the device. Default value: *9800*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to Use

This connector is fairly straightforward. After the element has been created, it will display the values retrieved from the device.
