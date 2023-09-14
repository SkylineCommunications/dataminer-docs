---
uid: Connector_help_Snell_Wilcox_IQHIP10
---

# Snell Wilcox IQHIP10

The **Snell Wilcox** **IQHIP10** is a multiplexer for audio streams.

## About

The connector allows the management of the **Snell Wilcox IQHIP10** using a smart-serial connection.

### Version Info

| **Range** | **Description**    | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version    | No                  | Yes                     |
| 1.0.1.x          | DCF Implementation | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | V167                        |
| 1.0.1.x          | V167                        |

## Installation and configuration

### Creation

#### Serial \[Main\] connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device (e.g. *192.168.14.15*).
  - **IP port**: The IP port of the device (e.g. *2050*).
  - **Bus address**: Used to fill in the Unit Address and the Unit Port (e.g. 10*.04* is for Unit Address *0x10* and Unit Port *0x04*).

## Usage

### Connection Info

The Connection Info contains an overview of the session status such as **Session Status**, **Assign Session Number**, **Local Session Number**, **Simulated RollCall Response**, **Card User Name**, **Unit Adress** and **Unit Port.** There is also a **Display** with a overview of the unit status and a Force

### Region Detectors

This page contains the Regions configuration, in the main page you can **disable** or **enable**, **Region 1** or **Region 2**. It is possible to configurate the size of the window or activate **Full Screen**. There are also four buttons on the right **Black Region, Blackish Region, Freeze Region** and **Stillish Region.**

> ### Black Region
>
> In here you can check the Alarm and define some thresholds such has **Black Fail**, **Black Warning** and **Black Hail Hold.**
>
> ### Blackish Region
>
> This page has the alarm state and some threholds can also be configured.
>
> ### Freeze Region
>
> The main difference between previous pages is that the **Freeze Tolerance** can also be configured.
>
> ### Stillish Region
>
> The last page is similiar to the other three, but here is possible to configure the **Stillish Max Threshold**.

### Input/Output/Pattern

Here it is possible to enable or disable the **Pattern**, **Pattern Scroll,** **Pattern on Input Error** and **Pattern Type.** The mute of the Output can also be configured on Input Error or by user's will.

### Video Monitor

This page allows the configuration of the **Average Picture Level Alarm**, **RGB Legalizer** and **Logging Threshold**. There are two button which open a pop up where the **Luma** and **Chroma** can be configured.

### Closed Captions

The Close Captions allows to check the **Close Caption CEA-608-B**, **Close Caption CEA-608-B Title 1** and **Title 2**, **CC CEA 708 B Field 1** and **Field 2**. Is is also possible to check and configure some **Temporal Control** parameters page gives an overview of the audio controls over the group 1.

### Ancillary Data

This page gives an overview of the Ancillary parameters, such has Time Code Fileds, VITC fieldsover the group 2, Packet Detection.

### Wide Screen Signalling

This page gives an overview of the **Wide Screen Signalling**, **VI state** and **AFD (SMPTE 2016)**.

### Audio Data Page

This page gives an overview of the audio data such has **Data Type** and **Bit Depth** for all sixteen Channels and each pair of channels.

### Audio Level Detectors

In this page it is possible to copy the Audio Level Detectors from one channel to another. There four buttons each one opens a pop up to configure the **Overload Detector**, **Quiet Detector**, **Loud Detector** and **Silence Detector**.

### Audio Level Indicators

The Audio Level Indicators allows to enable or disable the indicators for each sixteen channels.

### Clipping Detector

This page contains the clipping alarms for all the sixteen channels.

### Audio Likeness

This page gives an overview of the Likeness for each of the four detectors.

### UMID

This page shows all the information about UMID and allows to configure the UMID generator.

### PID

This page shows all the information about Program ID and allows to configure the Program ID generator.

### Alarm Enable Summary

Here you can enable or disable all the alarms existing in previous pages such has channels, Regions, Luma, Chroma, etc...

### Memory 1-16

This page Shows all sixteen memories and allows to save them.

### Setup

Here is shown all the information from the device such has **Serial**, **PCB**, **Build**, **Firmware**. It is also possible to force a restart on the system and a **factory reset**.

### On Screen Display

In this page it is possible to enable or disable all four outputs, configure and check the **OSD state**, **Window Size**, **Caption**, **RGB Legalizer Range**, **Incoming** and **Outgoing PID**.

### Logging Misc

The Logging Misc allows to enable or disable the logging, but also see the value of parameters such has Hardware Version, Caption1 and 2, RearStatus, Power Usage.

### Logging Input

The Logging Input allows to enable or disable the logging, but also see the value of parameters such has Input Name, Input State, Input Type, CRC, EDH.

### Logging Region 1

The Logging of Region 1 allows to enable or disable the logging, but also see the value of parameters such has Black, Blackish, Freeze, Stillish.

### Logging Region 2

The Logging of Region 2 allows to enable or disable the logging, but also see the value of parameters such has Black, Blackish, Freeze, Stillish.

### Logging Inp 1 Monitor 1

The Logging of Input 1 Monitor 1 allows to enable or disable the logging, but also see the value of parameters such has Hyperion, Close Caption State, Close Caption Type and Close Caption Title.

### Logging Inp 1 Monitor 2

The Logging of Input 1 Monitor 2 allows to enable or disable the logging, but also see the value of parameters such has Hyperion, Y Bit Depth, C Bit Depth, CA State, CA System, etc.

### Logging Input 1 WideScreen

The Logging of Input 1 WideScreen allows to enable or disable the logging, but also see the value of parameters such has WideScreen State, Aspect, ETSI Data, VI State, VI Aspect, etc.

### Logging Input 1 Audio State

The Logging of Input 1 Audio State allows to enable or disable the logging, but also see the value for all the channels.

### Logging Input 1 Audio Type

The Logging of Input 1 Audio Type allows to enable or disable the logging, but also see the value of the audio type for all the channels.

### Logging Input 1 Dolby E State

The Logging of Input 1 Dolby E State allows to enable or disable the logging, but also see the value of the audio each audio pair, having a total of eight.

### Logging Input 1 Audio Bit Depth

The Logging of Input 1 Audio Bit Depth allows to enable or disable the logging, but also see the value of the bit depth for all the sixteen channels.

### Logging Input 1 Audio Level

The Logging of Input 1 Audio Level allows to enable or disable the logging, but also see the value of the audio level for all the sixteen channels.

### Logging Input 1 Audio Clipping

The Logging of Input 1 Audio Clipping allows to enable or disable the logging, but also see the value of the audio clipping for all the sixteen channels.

### Logging Input 1 Audio Likeness

The Logging of Input 1 Likeness allows to enable or disable the logging, but also see the value of the all four detectors.

### Logging Input 1 UMID/PID

The Logging of Input 1 UMID/PID allows to enable or disable the logging, but also see the value of the the UMID and PID for the input.

### Logging Output 1 UMID/PID

The Logging of Output 1 UMID/PID allows to enable or disable the logging, but also see the value of the the UMID and PID for the output.

### Rolltrack Page

The Rolltrack page provides a simple command interface for sending unconnected Rolltrack commands to any Rollcall compatible unit on the network. The following parameters are displayed: **Disable All**, **Rolltrack Index from 1 to 16, **Rolltrack Source**, Rolltrack Address**, **Rolltrack Command**, **Rolltrack** **Sending** and **Rolltrack** **Status**.

### Web Interface Page

This page allows the user to access the original web interface of the device. The client machine has to be able to access the device. If not, it won't be possible to open the web interface.

## DCF Implementation

The input connects to all the outputs at startup, all the connections are static only allowing to disconnect or connect to an output.
