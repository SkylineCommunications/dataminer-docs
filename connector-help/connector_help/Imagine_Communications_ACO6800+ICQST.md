---
uid: Connector_help_Imagine_Communications_ACO6800+ICQST
---

# Imagine Communications ACO6800+ICQST

The ACO6800+ICQST is an intelligent Clean/Quiet Automatic Changeover for HD/SD/ASI sources. This product has been added to the ACO6800+ product line, expanding the solution to combine the clean switch functionality from the ACO6800+ISCST module with the 4x2 functionality from the ACO6800+4X2D module, along with some additional features.

## About

This connector uses **SNMP** to retrieve and configure data on the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.1                         |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device Address:** The Slot Id that will be monitored

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: public
- **Set community string**: private

## Usage

### General

This page displays general parameters about the device, such as the **Serial Number, License Key, Enable Options, Operation Mode, Sub Module** and **Back Module Type**. It's also possible to trigger a **Soft Reboot.**

### System

This pages displays specific information regarding the system.

This page also contains 4 page buttons: **Frozen Detection**, **General Purpose**, **Relay Control** and **Switch Settings:**

- The **Frozen Detection** subpage displays information about the frozen detection system: **Level Sensitivity** and **Pixel Sensitivity**.
- The **General Purpose** subpage displays information about the General Purpose Interface: **GPI Trigger Mode**, **GPI Input Trigger Level**, **GPI I/O 6 Functionality** and the Status of **GPI Inputs**.
- The **Relay Control** subpage displays relay control information: **In 1 Relay Bypass**, **In 1 Relay Status**, **In 2 Relay Bypass**, **In 2 Relay Status**, **In 1 Relay Auto-Hold**, **In 2 Relay Auto-Hold** and **FS Fill Source.**
- The **Switch Settings** subpage displays switch settings Information: **PGM Output Source**, **Switch Event**, **Switch High Priority**, etc. This subpage also displays information regarding **Alarm Switch**.

### Video

This page displays video information regarding **Line Sync**, **Still Image**, **ProcAmp** and **FS Settings** parameters.

### Audio

In this page besides the general audio information such as the Fade Time, LOV Mute En, Master Mute and V-bit Mute En, the audio information is grouped into Audio Input, Processing, Output and Tones.

In Audio Input group, it is displayed 3 page buttons: **SRC** **Bypass**, **Demux** **Settings** and **Demux** **Status**:

- The **SRC Bypass** subpage enables bypass to specific sources.
- The **Demux Settings** subpage enables to set the reporting behavior when there are audio errors.
- The **Demux Status** subpage displays the audio presence and type of each channel. It also display Checksum, DBN, Parity and ECC errors.

In Processing group, it is displayed 4 page buttons: **Bit Width**, **Phase Invert**, **Gain** and **Delay**:

- The **Bit Width** subpage enables to specify the internal processing bit width of the audio for each channel.
- The **Phase Invert** subpage enables to invert the audio phase for each channel.
- The **Gain** subpage enables to adjust the audio gain for each channel.
- The **Delay** subpage enables to adjust the audio delay for each channel.

In Output group, it is displayed 2 page buttons: **Routing** and **Mux Settings**:

- The **Routing** subpage displays information of each audio source embedder.
- The **Mux Settings** subpage enables the SDI Embedding for each audio group.

In Tones, it's displayed Tone1 400Hz Level, Tone2 1KHz Level, Tone3 2KHz Level and Tone4Hz Level parameters

### Input 1 - Status

This page displays the status information for Input 1, such as **Video Present**, **Video Standard**, **Audio Group Present**, etc...

### Input 1 - SQM Settings

This page displays the SQM Settings information for Input 1, such as **Luminance Low, Luminance Peak, Chrominance Low, Chrominance Peak, Video Black and Peak Audio Thresolds.**

### Input 1 - SQM

This page displays information about the average audio level of each channel.

### Input 2 - Status

This page displays the status information for Input 2, such as **Video Present**, **Video Standard**, **Audio Group Present**, etc...

### Input 2 - SQM Settings

This page displays the SQM Settings information for Input 2, such as **Luminance Low, Luminance Peak, Chrominance Low, Chrominance Peak, Video Black and Peak Audio Thresolds.**

### Input 2 - SQM

This page displays information about the average audio level of each channel.

### Input 3 - Status

This page displays the status information for Input 3, such as **Video Present**, **Video Standard**, **Audio Group Present**, etc...

### Input 3 - SQM Settings

This page displays the SQM Settings information for Input 3, such as **Luminance Low, Luminance Peak, Chrominance Low, Chrominance Peak, Video Black and Peak Audio Thresolds.**

### Input 3 - SQM

This page displays information about the average audio level of each channel.

### Input 4 - Status

This page displays the status information for Input 4, such as **Video Present**, **Video Standard**, **Audio Group Present**, etc...

### Input 4 - SQM Settings

This page displays the SQM Settings information for Input 4, such as **Luminance Low, Luminance Peak, Chrominance Low, Chrominance Peak, Video Black and Peak Audio Thresolds.**

### Input 4 - SQM

This page displays information about the average audio level of each channel.

### Web Interface

On this page, you can access the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
