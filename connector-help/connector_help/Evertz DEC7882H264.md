---
uid: Connector_help_Evertz_DEC7882H264
---

# Evertz DEC7882H264

The 7882 Decoder H264 is a platform capable of HD/SD-SDI/H.264/MPEG-2 dual decoding and offers decoding support for both MPEG-2 and H.264/AVC, optionally up to 4:2:2 10-bit.

The 7882 Decoder H264 features:

- 2x H.264/MPEG-2 video decoder up to 4:2:2 10-bit
- 2x ASI and IP inputs
- 4x HD/SD-SDI outputs
- Baseband outputs with embedded audio an ancillary data

This driver uses **SNMP** to poll data from the Evertz DEC7882H264 based on the decoder web interface layout.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | V102B20210304-1148     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver consists of the following data pages:

- **General**: Contains general system information.
- **System**: Allows you to configure and monitor several system-related tables and parameters, including SysLog configuration and temperature parameters. Also includes tables with data port settings and information.
- **Product Features**: Displays the card type, alias and product license, as well as the Product Features Supported Table.
- **Decoder Input Control**: Contains extensive settings and information related to the decoder input port. This includes switchover control parameters such as the User Redundancy Mode, video control, input program control, manual PID control, and more.
- **Decoder Monitor**: Allows you to monitor the Input Bitrate and Packet Framing, as well as various video information and program data. Also includes information on video and audio continuity errors.
- **Decoder Audio Monitor**: Contains audio information such as the Bitrate, Audio Type, Sampling Rate and Number of Channels.
- **Decoder Output Control**: Allows you to configure video, audio and private data outputs, as well as the MPE data PID and its output.
- **Decoder ANC Control**: Allows you to configure CC, AFD, VBI, SCTE104, WSS, WST, OP47, Timecode and VANC settings.
- **Decoder ANC Monitor**: This page displays the ANC Source and CC Type and the status of WST, WSS, AFD, VBI, SCTE104 and OP47.
- **SFP-ASI Transmit Control**: Allows you to select the BNC outputs.
- **SMPTE 2110 Output**: Allows you to control the SMPTE 2110-20 and SMPTE 2110-40 video outputs, audio groups, RTP payload and PTP.
- **FEC-Hitless Control**: Allows you to configure settings such as the Playout Delay and FEC Mode. Also contains link statistics and FEC stream statistics such as the packet count.
- **FrameSync Control**: This page contains Genlock monitoring and control parameters.
- **Inband Control**: Allows you to configure various settings such as the Time Source, Boot Image Number, Timezone Offset, etc.
- **CDP**: Allows you to configure service options such as Wide Aspect, Easy Reader, Language and Info Insert.
- **Faults**: Lists the Input, PCR , CC, Memory and Data Port Faults that may be present.
