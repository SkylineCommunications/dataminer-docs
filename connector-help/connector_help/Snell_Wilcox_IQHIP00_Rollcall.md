---
uid: Connector_help_Snell_Wilcox_IQHIP00_Rollcall
---

# Snell Wilcox IQHIP00 Rollcall

This is a Rollcall-based connector that allows you to monitor and configure the Snell Wilcox IQHIP00 video server device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3.7                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device, e.g. *192.168.56.201*.
  - **IP port**: The IP port of the device, e.g. *2050*.
  - **Bus address**: Fill in the unit address and the unit port, e.g. *10.0D* for unit address *0x10* and unit port *0x0D*.

### Web interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the pages detailed below. For each page, you can **enable or disable polling**.

- **General**: Displays general information about the device, e.g. Hardware and Software Versions, System Uptime, etc.
- **Black/Blackish**: Allows you to configure the black and blackish levels.
- **Freeze**: Allows you to monitor and configure the freeze and stillish state.
- **Video Monitor**: Contains information related to the video state.
- **Closed Captions**: Contains information related to the closed captions state.
- **Ancillary Data**: Contains information about the ancillary data.
- **WSS/VI AFD**: Contains information about the WSS state and VI state.
- **Audio Data**: Contains information about the audio data type and audio data bit depth.
- **Audio Level Detectors**: Contains information about the audio state.
- **Audio Level Indicators**: Contains information about the embedded and audio channel levels.
- **Audio Likeness**: Contains information about the audio likeness.
- **Audio State**: Contains information about the audio state.
- **Input**: Contains information about the input.
- **Configuration Info**: Contains information about the status and details of the connection, as well as variable timer settings.
