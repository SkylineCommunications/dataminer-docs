---
uid: Connector_help_Grass_Valley_Alchemist_Live
---

# Grass Valley Alchemist Live

Alchemist Live offers motion-compensated frame rate conversion for Live IP and SDI media streams. It supports SD, HD, 1080p, UHD, 4K and HDR formats. It offers native support for a single channel of UHD/4K, or up to three channels of 1080p.

This driver is used to manage, monitor and configure Alchemist Live devices. It uses the proprietary Rollcall communication protocol.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.4.2.0                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *2050*).
  - **Bus address**: The bus address of the device. The format is *NNNN.UU.PP* (all hex values), where NNNN is the network route/address, UU is the unit address and PP is the port address of the unit.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver consists of the data pages detailed below.

### General

This page displays the name of the card/unit and the unit address. With the **Force Poll** parameter, you can activate force polling.

### Connection Info

This page contains session information and displays the status of the network.

### Status

This page contains status information for the unit, the input and the output. This includes video and audio sources, the configured output video and audio formats and standards and the number of audio channels.

### Input

This page allows you to configure the input. In the drop-down list of the **Input Select** parameter, different inputs are available depending on the **I/O Configuration** setting (see "Setup" below):

- If I/O Configuration is set to *SDI Interface Only*, only SDI inputs are available.
- If I/O Configuration is set to *RTP Interface Only*, only RTP inputs are available.
- If I/O Configuration is set to *RTP and SDI*, both SDI and RTP inputs are available.

For **SDI Inputs**, the formats **SD**, **HD** and **3G** are supported. When the applied input is **UHD** or **4K**, the appropriate setting is either **SDI Quad Square** or **SDI Quad 2SI**.

The Input Video and Audio Flow parameters are only available for RTP inputs.

### Secondary Input

This page contains RTP secondary input video and audio flow information. These parameters are only available for RTP inputs.

### Output

The output format can be selected in the **Output Select** field. In the drop-down box, different outputs are available depending on the **I/O Configuration** setting (see "Setup" below):

- If I/O Configuration is set to *SDI Interface Only*, only SDI outputs are available.
- If I/O Configuration is set to *RTP Interface Only*, only RTP outputs are available.
- If I/O Configuration is set to *RTP and SDI*, both SDI and RTP outputs are available.

Note: Alchemist Live SDI supports SDI outputs. Alchemist Live IP supports RTP output transport streams.

When the required output is SD, HD or 3G, **SDI Output** should be selected. If the output is configured to be 3G, the output by default is 3G Level A. You can configure 3G Level B by enabling the **Output 3G Level B** parameter.

UHD/4K SDI outputs can be configured to be either **SDI Quad Link (UHD/4K)** or **SDI 2SI (UHD/4K)**.

### Secondary Output

This page contains RTP secondary output video and audio flow information. These parameters are only available for RTP outputs.

### Conversion

Alchemist Live relies on automatic standards detection of the incoming source signal. The **Scan Type** parameter reports the detected input video format.

- When Progressive inputs are detected, the *Progressive* scan type will be selected and the *Interlaced* and *Segmented Frame* types cannot be selected.
- When an interlaced input is detected, the driver will assume that the incoming signal is true high frame rate, and the *Interlaced* type will be selected.
- If the input is actually **psf**, the option **Segmented Frame (psf)** has to be selected.

In the **Video Output** section of this page, the output video format can be defined in terms of **Resolution**, **Frame/Scan Rate** and **Scan Type**. Note that when the output is configured to be **UHD/4K**, the options *Interlaced* and *PsF* cannot be selected.

It is also possible to set the conversion mode, aperture, clean cut and other conversion parameters on this page.

### Utilities

On this page, the Luma, Chroma, Color Space, HDR, SDR Conversion and RGB Legalizer parameters can be set.

In order to set the **HDR Conversion** parameters, the **Conversion Status** has to be **enabled**.

### Audio

The SDI version of Alchemist Live supports 16 channels of audio. In the **Channel Routing** section of this page, you can set the routing of any input audio channel to any output audio channel. You can also configure tones with various frequencies and levels.

In the **Channel Gain** section of the page, you can configure each output audio channel with a specific audio gain.

### Reference

On this page, reference parameters can be set and the status of the external reference is displayed (if selected).

### Logging

On this page, log fields can be enabled or disabled.

### Setup

This page allows you to edit the name of the Alchemist Live unit. The Agent can also be stopped using the **Stop Agent** button. Below this, the software version, start time, processing ID CPU mask and current log server information are displayed.

In the Hardware Configuration section of this page, you can select the supported input and output interfaces using the **I/O Configuration** parameter. The selection of the supported interface(s) will affect the available input and output selections on the Input and Output pages.

## DataMiner Connectivity Framework

The **1.0.0.x** driver range (since version 1.0.0.2) of the **Grass Valley Alchemist Live** protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

Physical fixed interfaces:

- **SDI Input 1**: A single fixed interface of type **in**.
- **SDI Input 2**: A single fixed interface of type **in**.
- **SDI Input 3**: A single fixed interface of type **in**.
- **SDI Input 4**: A single fixed interface of type **in.**
- **IP Input:** A single fixed interface of type **in**.
- **SDI Output 1**: A single fixed interface of type **out**.
- **SDI Output 2**: A single fixed interface of type **out**.
- **SDI Output 3**: A single fixed interface of type **out**.
- **SDI Output 4**: A single fixed interface of type **out.**
- **IP Output:** A single fixed interface of type **out**.

### Connections

Internal Connections

- **IP Input -\> IP Output**
- **IP Input -\> SDI Output 1**
- **IP Input -\> SDI Output 2**
- **IP Input -\> SDI Output 3**
- **IP Input -\> SDI Output 4**
- **SDI Input 1 -\> SDI Output 1**
- **SDI Input 2 -\> SDI Output 2**
- **SDI Input 3 -\> SDI Output 3**
- **SDI Input 4 -\> SDI Output 4**
- **SDI Input 1 -\> IP Output**
- **SDI Input 2 -\> IP Output**
- **SDI Input 3 -\> IP Output**
- **SDI Input 4 -\> IP Output**

## Notes

For parameters that display strings, the number of characters per parameter is limited to 19 characters. As such, in some cases, part of the string may be missing. For example, for parameters that display date and time, the year information is missing.
