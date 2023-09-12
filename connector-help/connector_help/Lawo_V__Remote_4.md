---
uid: Connector_help_Lawo_V__Remote_4
---

# Lawo V\_\_Remote 4

This connector displays information related to the V\_\_Remote 4 device. This information, including audio/video input and output, bandwidth statistics, and PTP info, is available on different pages. Alarm monitoring and trending are possible for some of the parameters, e.g. the bitrate.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | SW 1.4.0.104           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

Serial connection

This connector uses serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Port:** 9000

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

This connector has the following pages:

- **General**: Contains general information regarding the device, such as the **Version**, **Serial Number**, **Company**, etc. There is also a **reboot** button to reboot the device here.
- **Status**: Contains subpages with temperature information and preference settings.
- **Audio In**: Contains tables regarding the audio input and settings: **Input Audio Channels**, **MADI Input**, and **Ravenna In**.
- **Audio Out**: Contains tables regarding the audio output and settings: **Output Audio Channels**, **MADI Output**, and **Ravenna Out.**
- **Audio Matrix**: Shows the audio matrix.
- **Audio Interfaces**: Shows the connection output of audio input interfaces.
- **Video In**: Contains tables regarding the **video input and settings**.
- **Video Out**: Contains tables regarding the **video output and settings**. This includes video settings related to **Dolby**, **Insertion**, **YUV correction**, and **RGB Correction**.
- **Video Matrix**: Shows the video matrix.
- **Video Interfaces**: Shows the connection output of video input interfaces.
- **Quad**: Contains the Quad table and its settings, as well as the quad audio matrix and quad video matrix. Also allows you to configure numerous settings, such as **UMD Position**, **Time Code**, and **LAMP colors**.
- **RX Ethernet**: Displays the bitrates for RX Ethernet.
- **RX Streams**: Shows information for **RX Sessions and RX Streams for video and Ravenna**.
- **TX Ethernet**: Displays the bitrates for TX Ethernet.
- **TX Streams**: Displays the bitrates for **TX Sessions and TX Streams for Raw, J2K, Ravenna**.
- **IGMP**: Displays the IGMP table.
- **PTP**: Displays details regarding PTP, including **Master IP**, **Port State**, **Locking Policy**, etc.
- **Web Interface**: Displays the device webpage.
