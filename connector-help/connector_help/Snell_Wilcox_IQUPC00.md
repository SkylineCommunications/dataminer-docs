---
uid: Connector_help_Snell_Wilcox_IQUPC00
---

# Snell Wilcox IQUPC00

The **Snell Wilcox IQUPC00** connector monitors and controls changes on the up-converter unit through a **Rollcall** **smart-serial** protocol. The card is used in the **IQ Modular Chassis**.

## About

The connector periodically polls relevant information from the device. This happens every 15 seconds for Rollcall protocol purposes and every two hours for backchannel purposes.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Release 5.6 .11             |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host:** The polling IP of the device.
  - **IP port:** The IP port of the device, by default *2050*.
  - **Bus Address:** The bus of the card on the chassis. The default, *UU.PP (Hex)*, shows the expected structure of the address, where UU is the chassis ID, and the PP is the card position, both in Hex.

## Usage

### General

This page contains general information on the card hardware, including the **information shown on the display** of the device, and its various **versions** and **serial numbers**.

### Video - Input

This page contains information related to the **Inputs** and their standards, the configuration of the **Valid Input Standards**, the current **Errors** on the CRC and ANC, and the **ProcAmp** (Processing Amplificator) configuration.

### Video - Backup

This page contains the configuration of both the **Master Input** and the **Backup Input**. It allows you to check the current status of several data streams of each of those inputs, and to configure their states and backup states. It also contains GPI and Dolby information for each input.

### Video - Output

This page contains the information and configuration of **Standards**, **Patterns**, **Defaults**, **Output Routing** and **User captions**.

### Video - Picture

This page contains the configuration of specific parts of the picture quality of the video data. This includes **Output Borders**, extra **Color Corrections** on the image, **Enhancements** of the image, the **Luma Clipper**, the range of the **RGB Legalizer**, and **Advanced H Enhancements**.

### Video - ARC Control

This page contains the ARC part of the system, which includes its saved **Display Memory** (containing several saved presets), the **ARC** details (size, aspect, pan and tilt), the **Input Crop** configuration, and the 4:3 and 16:9 **Mappings** for both ARC and AFD.

### Video - Widescreen

This page contains the configuration for widescreen mapping. This includes settings for the **Reader**, **Writer**, general **Read/Write Mapping** and **Line Blanking** for several line combinations. It also contains **Global Preset** settings.

### Delay - Genlock

This page contains the **Delay**, **Dolby-E Auto Line** and **User Dolby-E Lines** settings for the Genlock part of the system.

### Ancillary Data

On this page, you can configure several auxiliary parts of the system, such as **SMTPE 2016**, the **Ancillary Input States**, **ATC**, and several **SD VBI Lines**.

### Audio - Input Disembed

This page contains the audio configuration for the eight **Disembed** channels. It allows you to make changes to the **ProcAmp**, **Mute**, **Stereo**, **Inverts** and **Dolby Lines**.

### Audio - Routing Input

On this page, you can check the available **Input Names**, check the eight **Hide AES Inputs**, and configure the eight **Input Routing** buses and the **Routing Input Destination**.

### Audio - Routing Output Embed

This page contains the configuration for the **Audio** **Output Routing**, the **Output Routing Options** and the **Audio** **Output Destination**. It also displays the **Output Routing Status**.

### Audio - Setup

This page allows you to configure the **Audio Bus Delays** on several levels, the **Test Tones**, the **Audio Levels** and the **Remote RollTrack Sources**.

It also displays the **Total Pair Delay** for each of the eight buses and allows you to configure the delays in a more **Coarse** or **Fine** way.

### Audio - Mixer

This page allows you to **select the mixer** in use, configure the **LoRo** part of the mixer, and configure each of the six **Mixer Sources**, including the **Source**, **ProcGain**, **Invert** and **Mute**.

### Audio - Output Embed

On this page, you can configure the **Default ProcAmp**, as well as the eight output **Embed** channels, including the **ProcAmp**, **Mute**, **Stereo** and **Dolby Line**.

You can also configure the **Embed Groups**, which join each of the followed outputs into a single unit. This means that there are four groups:

- Embed 1+2
- Embed 3+4
- Embed 5+6
- Embed 7+8

### Loud Monitoring

On this page, you can view and configure the settings related to the loudness of the audio. This includes general loudness parameters, **Block** parameters, and the two **Loudness Monitors** and their five audio channels.

There are also subpages for **Multi Band AGC**, general **Multi Band**, **AGC**, **Up Mixer**, audio **Master** and the **Parametric Equalizer**.

### Dolby

This page displays the status of the **Common** parameters, **Encoder** parameters and **Channel Assignment** parameters.

It also provides access to subpages for the **Programs**, the **Metadata**, the **Outputs**, the **Encoder**, the **Decoder**, the **Metadata Control** and the **Inputs**.

### Logging - Miscellaneous

This page contains the **Miscellaneous Values** for the card, which include states, versions and uptimes. The page also allows you to configure whether to **log** those values or not.

### Logging - Video Input

This page contains the **Video Input Values** for both video inputs of the card, which include states, errors and identification. The page also allows you to configure whether to **log** those values or not.

You can also find the **Reference Values** for the card here, including states and identification. For these values too, you can configure the logging.

### Logging - Video Output

This page contains the **Video Output Values** for both video outputs of the card, which include states, errors and identification. The page also allows you to configure whether to **log** those values or not.

### Logging - Audio Embed

This page contains two **Input Embed Values** groups, one **Input Embedded Values** group, and a group for **Output Embed Values**, and contains state information for each of these groups. It also allows you to configure whether to **log** those values or not.

### Logging - Audio Embed Dolby

This page contains the **Audio Dolby Values** and the **Output Embed Dolby Values** of the card, which include states, errors and identification. The page also allows you to configure whether to **log** those values or not.

### Logging - Ancillary

This page contains two **ANC** **Input Values** and one **ANC** **Output Value** for the card, which refer to auxiliary data for each of those groups. The page also allows you to configure whether to **log** those values or not.

### System - Memories

The page displays the configurable **User Memory** setting slots **1 to 16** of the device.

You can recall the settings from any of the previous slots with the **Recall Memory** option and check the last used memory setting slot in the **Last User Memory**.

To save a memory setting, first use the **Select Memory** parameter to either select one of the memory slots or select *None*, configure the name using the **Change Memory Name** parameter (which will be displayed for the corresponding **Memory Name Values** parameter), and select whether to **Save** or **Clear** the memory. Note that when you clear the memory, the configuration associated with it will be lost, and you will need to save it again later in order to re-create it.

### System - GPIO

On this page, you can configure the General Purpose Input/Output for both streams of the system. The page also contains the **Hide Configuration** for the system's AES.

### System - RollTrack

This page allows you to check the status of and configure the RollTrack system of the card. This includes **Indexes**, **Sources**, **Addresses** and **Commands.**

### System - Setup

On this page, you can configure the names for each **input**, configure data related to the **board**, **reset settings to the defaults**, and **restart** the device.

### Connection Info

This page displays the current status of the remote connection to the card.

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
