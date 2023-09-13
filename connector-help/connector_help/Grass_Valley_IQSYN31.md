---
uid: Connector_help_Grass_Valley_IQSYN31
---

# Grass Valley IQSYN31

The IQSYN31 provides frame synchronization for HD-SDI at 3 Gbit/s or 1.5 Gbit/s, or SD-SDI 270 Mbit/s with 16-channel embedded audio processing. This protocol allows you to manage this device using a smart-serial connection.

The Grass Valley IQSYN31 protocol is able to retrieve, set, and monitor information regarding inputs, standards, output, genlock, video and audio delays.

## About

### Version Info

| **Range** | **Key Features**             | **Based on** | **System Impact** |
|-----------|------------------------------|--------------|-------------------|
| 1.0.0.x   | Initial version \[SLC Main\] | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**           |
|-----------|----------------------------------|
| 1.0.0.x   | Device firmware version V5.18.14 |

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

  - **IP address/host**: The polling IP of the device, e.g. *192.168.56.201*.
  - **IP port**: The IP port of the device, e.g. *161*.
  - **Bus address**: The bus address of the device.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver has the following data pages:

- **General**: This page shows the basic information about the device and licenses, and the information on default settings.
- **Video and Audio pages:** Allows you to enable/disable input standards, and check and change the audio pairs, the video input resolutions, and the audio and video configuration.
- **Genlock**: Allows you to configure the genlock adjustment for timing any SDI signal.
- **Misc. Logging**: Displays the current log information about the unit's basic parameters.
- **Audio/Video Input and Output Logging pages**: Information about several parameters can be made available to a logging device that is connected to the network.
- **Procamps:** More video settings for each channel.
- **Pattern and Caption**: These settings allow you to specify a caption, turn the caption on and off, and specify and enable pattern generation. The controls are duplicated for Process 1 and Process 2.
- **Embedder pages**: These pages allow you to verify and change the processing for 16 channels of embedded audio present on each incoming SDI stream. The embedded audio may be passed unchanged, processed, or blanked. For each of the two processing groups (1 and 2), there are four embedder groups. Each embedder group comprises two stereo audio pairs, each of which has a left and right channel.
