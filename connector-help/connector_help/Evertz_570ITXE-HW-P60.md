---
uid: Connector_help_Evertz_570ITXE-HW-P60
---

# Evertz 570ITXE-HW-P60

The 570ITXE-HW-P60 is built with modern hardware technology. Leveraging experience in transport stream processing, MPEG and JPEG2000 codecs, the modular ingest encoder with 3G/HD/SD over SDI/IP or IP/ASI MPEG2/H264/J2K inputs enables the building of a content ingest platform for MSO, DTH, IPTV, broadcast and data centers. The device has three distinct processing stages. The input decoder stage supports IP or ASI inputs, with the capacity to decode MPEG2, H.264 or JPEG2000. The processing stage includes audio and video proc, up-/down-/cross-conversion, frame sync and A/V delay. The output encoder stage features H.264 4:2:0 8-bit, H.264 4:2:2 10-bit encoding and SMPTE 2110 input and output controls.

## About

The connector uses **SNMP** and **HTTP** to poll data from the Evertz 570ITXE-HW-P60.

### Version Info

| **Range** | **Description**       | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version       | No                  | Yes                     |
| 1.0.1.x          | HTTP connection added | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**               |
|------------------|-------------------------------------------|
| 1.0.0.x          | N: V303B20180202-764 S: V303B20180202-764 |
| 1.0.1.x          | Build number: 1163                        |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

#### HTTP Web API Connection

This connector uses a HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Device address**: The device address, by default *ByPassProxy*.

## Usage

### General

This page displays general information about the device: The **System Description**, **System Uptime**, **System Name**, **Product Serial Number**, **MAC Address** and **Temperature**, as well as the **System Fault** table. The page also contains a page button that provides access to the **Product Features** table.

### System

This page displays the **Data Port Status**, **Data Port Configuration**, **Control Port Configuration** and **Inbound Control** tables. It also contains parameters for the **Temperature** and **RPC Timeout**.

### Decoder

This page displays the **Decoder Status** parameter.

It also contains the following page buttons:

- **Input**: Displays a subpage with the following sections:

  - **Decoder Input Status**: Includes the Bit Rate, Packet Framing, Number of TS Packets per IP Packets and Decoder Input Source.
  - **Decoder Input IGMP Control**: Includes the IGMP Version 3 SSM Control table.
  - **Decoder Input IP Control** table.

- **Video**: Displays a subpage with the following sections:

  - **Decoder Video Status**: Includes statistics for the incoming PMT PID, PCR PID, Video PID, Video Compression Type, Video Chroma Format, Video Resolution and Video Frame Rate.
  - **Video Control**: Allows you to configure the Loss of Video Mode, Force Interlace and Video Delay.

- **Audio**: Displays the following tables:

  - **Decoder Audio Status** table: Contains statistics on each audio PID, i.e. the detected Audio PID, the audio codec type and the associated bitrate.
  - **Decoder Output Control** table: Allows you to configure the audio delay and the Dolby downmix mode. The Dolby downmix mode options include stereo downmix and full decode.
  - **Audio Decoder Output Mixer** table: Allows you to configure the mapping of decoded audio channels to the audio embedder.

- **ANC Data**: Displays a subpage with the following sections:

  - **ANC Data Status**: Allows you to monitor the VBI Status, Closed Captions Type, Time Code Status and AFD Status of ANC data services.
  - **VBI Control**: Allow you to toggle Monochrome VBI Data Embedding.
  - **Closed Caption Control**: Allows you to set the Closed Caption Selection and CC CEA-708 Insertion Line.
  - **Decoder Time Code Control**: Allows you to configure Embedding, SD Mode, D-VITC Insert Line 1 and D-VITC Insert Line 2.
  - **AFD Control**: Contains the SD Embedding, SD and HD Insertion Mode and Insertion Line parameters.
  - **SCTE 104 Control**: Allows you to configure Embedding, Insertion Line and Source.

- **Program Control**: Displays a subpage with the following sections:

  - **Program Control**: Allows you to set the Tuning Mode, Auto Program Select Mode and Program Select.
  - **Manual PID Control**: Allows you to configure the Video PID, PCR PID and VANC (SMPTE 2038) PID Control parameters, and displays the Auto PID table.

### UDX

This page displays the generic UDX parameters, such as **Input Video Source**, **Deinterlacer Operation Mode**, **Scaler Operation Mode**, **UpMix Detected Audio Input** and **UpMix Status**.

It also contains the following page buttons:

- **AFD**: Displays a subpage with the following sections:

  - **AFD Controls**: Includes the AFD Input, Loss of AFD Timeout, AFD Stamp Source, AFD Output SD Aspect Ratio, SMPTE 2016-1 Output, SMPTE 2016-1 Output Line and SMPTE 2016-1 Bar Output.
  - **AFD Faults**: Displays whether the AFD is in fault and allows you to enable or disable the AFD fault trap.
  - **AFD Status**: Displays the Input and Output of SMPTE 2016-1 Code Status.
  - **AFD ARC Control** table.

- **ANC Pass Thru**: The ANC PassThru feature allows you to define specific rules for passing ANC data from input to output. There are two modes of operation for ANC PassThru: **Direct ANC PassThru** and **Mapped ANC PassThru**. The Mapped ANC PassThru mode of operation routes up to 10 unique (DID, SDID) ANC packets frame-accurately from input to output. This mode of operation is designed for the use case when the input video standard and output video standard differ, or when only a subset of the ANC data on the input is to be passed through the module.

- **Audio:** Contains controls related to the core audio configuration (de-embedding, delay, and re-embedding) as well as basic monitoring information regarding the input audio sourced to the module:

  - **Audio Controls**: Includes the SRC Status and Mode, Audio Delay, C-Bit and Dolby E Auto Phaser Mode.
  - **Audio Control** table.
  - **Audio Faults** table.

- **Audio DownMix**: The UDX Audio DownMix processing module provides the ability to downmix 5.1 surround sound to 2-channel (stereo) sound or single-channel (mono) sound. The downmix audio processor can be configured to utilize common downmixing algorithms (Lo/Ro, Lt/Rt) and is also fully user-configurable. The Audio DownMix subpage has the following sections:

  - **DownMix Controls**: Includes the Output Scaling Mode, Output Gain, LFE Mixing, LFE Gain, Surround Phase and Output Type.
  - **Custom DownMix Coefficients** table.
  - **UDX DownMix Mixer** table.

- **Audio Proc**: Displays the Audio Input Correction and Audio Output Mixer tables.

- **Audio UpMix**: Displays a subpage with the following sections:

  - **UpMix Status**: Displays the Status and Detected Audio Input.
  - **UpMix Controls**: Allows you to configure the Mode, Auto Source, Centre Width, Surround Depth, Surround Delay, LFE Gain, Sound Direction Detect Rate, Soft Switch Duration and Detection Threshold.
  - **UpMix Mixer** table.

- **AVM Monitoring**: Displays a subpage with the following sections:

  - **AVM Processing Controls**: Allows you to toggle **Processing** and set the **Location**.
  - **Video Fault Controls**: Allows you to configure the Error Duration and Timeout, Black Duration and Timeout, Freeze Duration and Timeout and Noise Level.
  - **Video Level Input Controls**: Allows you to set the Error Quantity, Black and White Error Level, Black-White Level Error Duration and Timeout, Black and White Warning Levels and Black-White Warning Duration and Timeout.
  - **Audio Input Controls**: Allows you to configure the Audio Over Level, Duration and Timeout and Audio Silence Level, Duration and Timeout parameters.
  - **AVM Video Fault** table.
  - **AVM Audio Over Fault** table.
  - **AVM Audio Silence Fault** table.

- **Closed Captions**: Displays a subpage with the following sections:

  - **Closed Captions Status**: Displays the CDP 708 Demux and CDP Parser Status parameters.
  - **Closed Captions Controls**: Allows you to set the SD Source, Line 21 Output, CDP Output, CDP Output Line and Loss Timeout.
  - **CEA 708 Service Translation** table.
  - **Closed Captioning CEA 608 Faults** table.
  - **Closed Captioning CEA 708 Faults** table.

- **Deinterlacer**: Displays controls related to active picture deinterlacing. Deinterlacing is a functional part of the video conversion process that converts interlaced field content into progressive frames. The deinterlacer generates the missing lines that were removed during field capture. It performs interpolation in both the spatial and temporal directions to achieve the optimal estimation of the missing pixels from the original captured video frame. The deinterlacer also utilizes a cadence detection algorithm for the detection of well-known cadences that may be present in the interlaced input signal. If a valid cadence is detected, the original progressive video frame can be extracted from the interlaced input. This results in a perfectly interpolated video signal when producing the progressive output frame.

  It is recommended that all interlaced inputs are deinterlaced. This ensures the highest quality scaling when performing video conversion.

  The subpage displayed by this page button consists of the following sections:

  - **Deinterlacer Status and Controls**: Includes the Mode, Operating Mode, Inverse Telecine and Temporal Noise Reduction Level.
  - **Cadence Selection** table.

- **Dolby Decoder**: Displays the following **Dolby Decoder Controls**: Encoded Audio Source, Audio Source Switch Suppression, Decoder Delay Compensation, AC3 or Digital Plus Dynamic Range, E Stereo DownMix and AC3 or Digital Plus Stereo DownMix.

- **IntelliGain**: IntelliGainr is a technology developed by Evertz to control the loudness of audio programs on the fly. More specifically, it calculates the perceived loudness of the input audio and modifies the audio to ensure that the long-term average loudness level is at the target level. This subpage consists of the following sections:

  - **IntelliGain Global Controls**: Includes the Compander Attack Time and Release Time and Leveler Attack Mode and Release Mode.
  - **IntelliGain Mixer** table.
  - **IntelliGain Configuration** table.
  - **IntelliGain Program Control** table.
  - **IntelliGain Program Fault** **Controls** table.
  - **IntelliGain Fault** table.

- **Presets**: Displays a subpage with the following sections:

  - **Preset Control**: Contains the **Recall** and **Store Preset** parameters.
  - **User Presets** table.

- **Reference:** The 570ITXE supports fully independent timing on video processing. It can be configured to either lock to the input video timing, or the external reference signal timing. The subpage consists of the following sections:

  - **Reference Status and Control**: Includes the Type, Status, Select, Genlock Standard and External Genlock Source.
  - **Reference Faults:** Includes the Genlock, Trap, Changed Event and Auto Reference Trap parameters.
  - **Reference Failover**: Includes the Status, with a reset button, allows you to configure Failover, Valid Timeout and Invalid Timeout, and displays the Priority Reference table.

- **Scaler**: The 570ITXE uses high-performance multi-tap polyphase filters to perform scaling and aspect ratio conversion on the input video signal to produce a high-quality scaled output video signal. This subpage allows you to configure sharpness of vertical and horizontal edge transitions, set cut-off frequencies of the polyphase filters, set the RGB background color for unused areas in the output raster and define the default aspect ratio conversion and AFD output code. The subpage consists of the following sections:

  - **Scaler Status**: Displays the Scaler Operating Mode and the Input and Output H and V Start and Stop.
  - **Scaler Controls**: Allows you to configure the Aspect Ratio Conversion, AFD Stamp, H and V Slew Limits and Horizontal and Vertical Filter Cutoffs Frequency parameters.
  - **Background Color**: Allows you to set the Red, Green and Blue background color.

- **SD Aperture**: The precise definition of the active picture region for an SD video standard is often unclear, because SD signals have been defined differently in various standards. To support varying active picture regions for SD video standards, the 570ITXE module allows you to fully define both the production and clean aperture regions using the SD aperture feature. Both the SD Clean Aperture and the SD Production Aperture can be independently defined with an exact number of pixels and an exact number of lines.

  The SD Aperture subpage consists of the following sections:

  - **SD Aperture Controls**: Allows you to toggle the Aspect Ratio Source.
  - **SD Clean Aperture Controls**: Allows you to set the Clean Aperture of H and V Start and Stop.
  - **SD Production Aperture Controls**: Allows you to set the Production Aperture of H and V Start and Stop.

- **Time Code**: Allows you to fully configure all time code controls related to the specific video path. The 570ITXE can fully process D-VITC, ANC-VITC or ANC-LTC time code and perform any necessary conversion from the input video standard to the selected output video standard. This subpage consists of the following sections:

  - **Time Code Control:** Allows you to set the D-VITC Read Line, D-VITC Write Line and Loss of Time Code.
  - **Time Code** table.

- **User ARC**: Allows you to create custom aspect ratio conversions (ARC) that can be used either in the default aspect ratio conversion (Scaler subpage), or in input AFD code driven aspect ratio conversions (AFD subpage). You can also designate a name for each custom ARC that will be displayed in all aspect ratio conversion drop-down menus. Up to 10 user-defined custom aspect ratio conversions are supported, listed in the **User ARC Controls** table.

- **Video**: Displays a subpage with the following sections:

  - **Input Video Controls**: Allows you to set the Input Video Standard, Video Program Source, SD 525 Blanking and SD 625 Blanking.
  - **Output Video Controls**: Allows you to set the Output Video Standard, Vertical Phase Offset, Horizontal Phase Offset, Added Video Delay, Video Loss Mode and Force Freeze Frame.
  - **Video Status**: Displays the Input Video Source, Video Payload ID, Video Delay Status and Input Video Standard Status.
  - **Video Faults** table.

- **Video Proc**: Contains controls related to active picture video signal adjustment (gain/offset/hue/gamma):

  - **Video Proc Controls**:

    - **Hue**: Allows you to adjust the hue of the video signal, in a range from -180 to 180 degrees, using 0.1 degree increments.
    - **Reset Video Proc**: This button allows you to reset all video processing parameters on this subpage to their default value.
    - **RGB Clip**: Allows you to enable or disable the RGB clipping/color legalization process. When this is enabled, the module will clip any illegal levels of R, G, and B (individually) to their respective black and white Levels. When this is disabled, the illegal values are passed unmodified. Usually, the control is set to *Disabled* in order to allow Super Black or other test patterns to pass through the module.
    - **Gain Levels**: These are eight controls that can be used to set the gain of the video. They allow you to adjust the gain of the 3 components in either the YCbCr domain or the RGB domain, over a range of 50 % to 100 % in 0.1 % steps. Gain adjustments in the YCbCr domain are made first, followed by gain adjustments in the RGB domain. Illegal values are clipped after gain adjustments.
    - **DC Offsets**: These are six controls that set the DC offset of the video signal. They allow you to individually adjust the DC offset of Y, Cr and Cb with a range of +/- 200 quantization levels and to individually adjust the DC offset of R, G and B with a range of +/- 200 quantization levels. Offset adjustments in the YCbCr domain are made first, followed by offset adjustments in the RGB domain. Illegal values are clipped after offset adjustments.

  - **Gamma**:

    - The **Gamma Adjust** control enables and disables the gamma adjustment functionality of the 570ITXE module. When this is enabled, you will be able to adjust the gamma level. When this is disabled, the gamma levels are set to 0.
    - **Gamma Levels**: Allows you to adjust the overall gamma correction factor from -128 to +127 in increments of 1.

  - **Image Enhancement Controls**: Related to active picture image enhancement adjustments. Image enhancement provides the ability to enhance/sharpen the content within the active picture by applying video processing filters. The image enhancement controls allow you to tweak the image enhancement algorithm to the perceived acceptable level.

### Encoder

This page displays the **Encoder Time Reference Source** parameter.

It also contains the following page buttons:

- **Breakaway Audio**: Displays the **Breakaway Audio** table.

- **Contribution**: Displays a subpage with the following sections:

  - **Encoder 422 Output Configuration** (TTL, Rate Mode, Total TS Bitrate, DSCP, Encapsulation Type, Program Number, Audio Delay, Audio Buffer Level and Video Bitrate).
  - **Encoder 422 Output Port Control** (Output Port, Multicast IP Address and UDP Port).
  - **Encoder 422 Required PID Assignment** (PMT PID, Video PID, VANC (SMPTE 2038) PID State, VANC (SMPTE 2038) PID and PCR PID).
  - **Video Encoder Control** (GOP Size, Entropy Coding, IDR Pictures, Latency Mode, Encoding Profile, Deblocking and HES Mode).

- **General Control**: Displays a subpage with the following sections:

  - **Encoder Primary** (Input Port, IP Address, UDP Port and Switch Time Over Timeout).
  - **Encoder Backup** (Input Port, IP Address, UDP Port and Switch Time Over Timeout).
  - **Encoder Control** (GOP Lock).
  - **Bitrate Limitation** (Metadata Max Bitrates, Encoder STCE35 Data Max Bitrate, VANC Max Bitrate and Input Source).
  - **Encoder Time Reference** (Lock, User Redundancy Mode, Source, PCR PID Mode, Manual PCR PID, Detected PCR PID, PCR Presence, Jitter Tolerance, LTC Generation Mode, PCR PID, RTP, Re-Sync and LTC Gen Control).
  - **Encoder Data Control** table.

- **IPTV**: Displays a subpage with the following sections:

  - **Encoder 420 Output Configuration** (TTL, Rate Mode, Total TS Bitrate, DSCP, Encapsulation Type, Program Number, Audio Delay, Audio Buffer Level and Video Bitrate).
  - **Encoder 420 Output Port Control** (Output Port, Multicast IP Address and UDP Port).
  - **Encoder 420 Required PID Assignment** (PMT PID, Video PID, VANC (SMPTE 2038) PID State, VANC (SMPTE 2038) PID and PCR PID).
  - **Encoder 420 Advanced Settings** (GOP Size, SDCC Line and PID Interval).
  - **Encoder 420 Control** table.

- **JPEG 2000**: Displays a subpage with the following sections:

  - **Encoder Audio Output Control** (Audio Number of Channels, Bits per Sample and Audio PID from 1 to 4).
  - **Encoder Configuration** (Latency Mode, Color Specification, Total TS Bitrate and Max Video Bitrate).
  - **Encoder JPEG 2000 Control** (Restart button, Uptime Compliance Mode and Source).
  - **Encoder JPEG 2000 IP Output Control** table.

### CC Over IP

This page contains the **CC Generation Control**, **CC Misc System Control** and **Telenet Port Login Control** parameters, together with the following page buttons that provide access to the corresponding tables:

- **CC Telnet Port Control Table**
- **CC Permission Control Table**
- **608 to 708 Translator Table**
- **Upstream CEA-608 Service Control Table**
- **Upstream CEA-708 Service Control Table**

### SMPTE 2110 Input

This page contains parameters related to the **Input Status**, **SDI Output Monitoring** and **IP Advanced Controls**. It also contains two page buttons **B-Port 3** and **B-Port 4**, with configurable **Multicast IP**, **UDP Port** and **Status** (*Enabled*/*Disabled*) for **Video**, **VANC** and **Audio Groups 1** to **4**.

### SMPTE 2110 Output

The page contains parameters related to **IP Advanced Controls**, as well as two page buttons **B-Port 3** and **B-Port 4**, with configurable **Multicast IP**, **UDP Port** and **Status** (*Enabled*/*Disabled*) for **Video**, **Ancillary** and **Audio Groups 1** to **4**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Revision History

DATE VERSION AUTHOR COMMENTS

01/02/2018 1.0.0.1 VCO, Skyline Initial version

05/06/2018 1.0.0.2 VCO, Skyline Changed ASPEN (Input/Output) to SMPTE 2110 (Input/Output) parameters.

Implemented trap receiver for FPGA temperature.

10/12/2018 1.0.1.1 RBL, Skyline Added HTTP connection.

Added Data Port (1G) Configuration, BNC Output Video Control, Program Select.

Updated Input Video Program Source.
