---
uid: Connector_help_Imagine_Communications_DMDP6802+D
---

# Imagine Communications DMDP6802+D

The Imagine Communications DMDP6802+D is a data and metadata processing module, supporting 3G, HD, and SD-SDI signals. It converts GPI trigger bit inputs into VANC and/or GPI outputs from VANC. Additionally, it supports the insertion and extraction of metadata in one card and provides dual independent metadata processing channels. This driver can be used to monitor, trend, and control the DMDP6802+D.

## About

### Version Info

| **Range** | **Key Features**                                                             | **Based on** | **System Impact** |
|-----------|------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x   | Initial version. Full driver support for all features of this specific card. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**              |
|-----------|-------------------------------------|
| 1.0.0.x   | 1.0 \[Hardware\]1.0.74 \[Software\] |

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

- **IP address/host**: The polling IP of the device.
  - **Bus Address**: X.Y, where X = Frame Number and Y = slot number.

#### Serial IP Connection - PortDev Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP of the device.
  - **IP port**: "any", meaning the device will reply in broadcast mode.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The DMDP6802+ can simultaneously insert or extract the following metadata:

- ISC (Inter-Station Control)
- Time Code (ATC_LTC, ATC_VITC, D-VITC, LTC)
- Closed Captioning (CC608, CC708)
- Teletext (WST, OP47)
- SCTE104
- AFD (AFD, VI, WSS)

It can transmit three types of ANC packets to carry GPI information: ISC (Inter-Station Control), ATC, or SCTE104 (license keys are required for enabling ATC and SCTE104 capability). The DMDP6802+ module converts GPI trigger bits in the SDI signal to GPI signals, or it converts the GPI signals to trigger bits.

### General

The General page contains general information about the device, including the device serial number and license key.

### Alarms

The Alarms page contains the alarm configuration.

### Input Data pages

- Two independent serial digital SMPTE 259M/SMPTE 292M SDI inputs
- Four RS-232/422 serial inputs
- Up to sixteen GPI input ports (shared with GPI outputs)
- One linear time code input
- One Ethernet input port (shared with output)

### Output Data pages

- Two independent serial digital SMPTE 259M / SMPTE 292M SDI outputs
- Four RS-232/422 serial port outputs
- Up to sixteen GPI output ports (shared with GPI inputs)
- One linear time code output
- One Ethernet output port (shared with input)

### Supported features (present on many pages)

#### Video:

- Auto-detection of input video standard with 3G/HD/SD-SDI auto-sensing
- Signal presence monitoring on each video input
- SQM and thumbnail support

#### Metadata:

- AFD, WSS, and VI detection and insertion
- Inter-station control package detection and insertion
- LTC, D-VITC, ATC_LTC , and ATC_VITC detection and insertion
- Time code payload insertion and extraction among LTC, D-VITC, ATC_LTC, and ATC_VITC
- Support CC608 and CC708 extract, insert and bridge
- Support WST and OP47 extract, insert and bridge
- Support SCTE104 extract, insert and bridge

#### Control:

- Shadowed/restored parameter settings when switching video standards
- Card-edge control and monitoring
- Serial and Ethernet remote control and monitoring
- Support field upgrading, license and options

#### Extra:

- Auto-detects SDI input presence and format
- Supports signal quality monitoring (SQM)
- Supports Q-SEE compliant thumbnail and alarms
- Provides two independent RS-232/RS-422 serial ports with user-selectable baud rates
