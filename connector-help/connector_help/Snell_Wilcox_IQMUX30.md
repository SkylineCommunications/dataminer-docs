---
uid: Connector_help_Snell_Wilcox_IQMUX30
---

# Snell Wilcox IQMUX30

The **Snell Wilcox IQMUX30** connector uses an SNMP connection to monitor and configure the **IQMUX30 multiplexer**.

## About

This protocol is used to control and monitor the **Snell Willcox IQMUX30** via SNMP.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Slot number of the module in the chassis, e.g. *1.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*. However, if you have defined a different default value in the connector, then set this one.
- **Set community string**: The community string in order to set to the device. The default value is *private.* However, if you have defined a different default value in the connector, then set this one.

## Usage

### General

The **General Page** of this connector displays some general information (for example: **Slot Number**, **Serial Number**, etc.). It is also possible to **Restart the Unit** or to reset it to the **Default Settings** or **Factory Defaults**.

### Setup

The **Setup** section consists of multiple pages:

- **RollTracks:** RollTrack information and settings.
- **Video** **Input:** Current video input and possibility to *enable/disable* the video input logging.
- **Audio** **Input:** Current audio input and possibility to *enable/disable* the audio input logging.
- **AES** **Input:** Current AES input state and possibility to *enable/disable* the AES input logging.
- **Video** **Output:** Current video output and possibility to *enable/disable* the video output logging.
- **Audio** **Output:** Current audio output and possibility to *enable/disable* the audio output logging.

### Video

The **Video Page** allows the user to set some general **Video Settings**. The user can also choose which **Video Formats** are valid. There are also some page buttons that can be used to configure extra information. The **Video Blanking** page is used to enable or disable the blanking of some specific lines. The **Video Delay** page is used to set the delay of the video. The **Procamp** page enables adjusting of the processing amplifier settings.

### Audio

The **Audio** page is used to set some general audio settings as well as the delay.

### Audio - Embedder

Four **Embedder** groups are provided. Each embedder group comprises two stereo audio pairs, each of which has a left and right channel. The settings on these screens enable you to:

- *Enable/disable* the embedder group.
- Apply a *mute* to a pair within the group.
- Configure each pair as either 2 Channel, Stereo, or Non-PCM.
- Configure each channel within the pair.
- Specify the route for each channel.

With the exception of the Embedder Enable control, each control is duplicated for Pair 1 and Pair 2.

### Memories

The **Memories** page enables up to 16 setups to be saved and recalled later. Default memory names can be changed to provide more meaningful descriptions.

### Webpage

This page can be used to access the web interface of the device. Note that the interface must be accessible from the client PC.
