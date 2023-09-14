---
uid: Connector_help_Tektronix_WFM
---

# Tektronix WFM

This protocol is used to interact with Tektronix waveform monitoring devices via SNMP. It allows you to both retrieve information from a device and configure the settings of the device in a similar way as on the device itself.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.8.6                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default, *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the data pages detailed below.

### General

This page displays general information of the device, such as the device name and version. General setting can also be configured here.

Four page buttons are available, leading to subpages with **Screen Saver** settings, **Gamut** parameters, **Timing** settings, and the settings available on the **Front** **Panel** of the device.

### Picture

This page allows you to configure the different **Safe Area** setting, such as **Width**, **Height** and **Horizontal/Vertical Offset**.

Two page buttons are available:

- **Picture** **Display**: Contains a **Picture Table** with various safe area and picture settings.
- **Display** **Mode**: Contains a table that allows you to configure the different display modes.

### Input

This page allows you to configure input settings, such as **Input Source**, **Input Format**, **Line Select**, **Ground** **Closure** **Settings,** **etc.**

Six page buttons are available, which lead to subpages with additional settings:

- **Ctl** **299** **Groups**: Enabling/disabling of the different Ctl 299 groups.
- **Ctl** **272** **Groups**: Enabling/disabling of the different Ctl 272 groups.
- **Services** **Required** **A**: Enabling/disabling of settings such as **HD**, **SD**, **Analog** and **Mobile**.
- **Services** **Required** **B**: Enabling/disabling of different **Texts** and **CCs**.
- **Closed** **Captions**: Closed captions settings.
- **Timecode**: Time code settings.

### Waveform Mode

This page contains a table with the waveform monitor settings.

### SDI Status

This page reads out various SDI parameters during a video session.

### Eye Cal

This page allows you to check and configure various Eye parameters for SD, HD and 3G.

### Options

This page contains of four rows of page buttons:

- **PHY3**:

- **Jitter**: Displays a table with jitter information
  - **SDI** **Eye** **Status**: Allows you to check and configure various EYE settings, such as EYE Fall/Rise Time, EYE Amplitude, etc.

- **EYE**:

- **Eye Display Mode**: Contains the configuration of Eye Trace Type, Eye Equalizer Bypass and Eye Output.

- **DPE**:

- **Dolby** **Settings**
  - **Analog** **Audio**
  - **Audio** **I/O**: Input and output settings for audio, such as input formats and output loudness parameters.
  - **Audio**: Displays the Audio Table.
  - **Audio** **Disp**: Displays settings for audio.

- **CPS**:

- **Cable**: Displays cable parameters such as Cable Length and Cable Loss.
