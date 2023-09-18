---
uid: Connector_help_Snell_Wilcox_IQUDC1201-2B3
---

# Snell Wilcox IQUDC1201-2B3

The aim of this connector is to monitor and control amongst others the Video and Audio Inputs and Outputs, Audio Routing, Mixers, and Dolby Decoder/Encoder of the **IQUDC1201-2B3** device.

## About

This connector implements the RollCall protocol (serial protocol) for all communication with the device.

It is a smart-serial single connector, so all the updates are sent by the device asynchronously, which reduces the network load and improves performance.

The version 1.0.0.1 was built for the firmware *0713007125.*

## Configuration

### Connections

#### Serial Connection - Main

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *172.16.61.26*.
- **IP Port:** The IP port of the device, e.g. *2050*.
- **Bus address:** Used to fill in the Unit Address and the Unit Port, e.g. *25.01* is for Unit Address *0x25* and Unit Port *0x01*.

## Usage

### General

On this page, the **Display** parameter shows status information concerning the inputs and the output.

### Video 1

In the Video 1 Input section of this page, you can set the **Input 1 Standard, Input Analog Standard**, etc. The section has two page buttons:

- With the **Valid Standards** page button, standards like **1080/50p,** **1080/59p** can be selected.
- The **Errors** page button provides detailed error information (**CRC/ANC Errors**, etc.).

In the Video 1 Backup section, video backup parameters such as **Qualify CRC Error** and **Qualify ANC Error** can be set. This section also has two page buttons:

- With the **Input 1 Sel** page button, you can set the **State Input 1**, **State Standard 2**, etc.
- The **Input 2 Sel** page button displays similar information as the Input 1 Sel page button.

### Video 2 Output

On this page, you can configure general settings for the video 2 output: **Output A Type, Pattern Type, Last Frame Rate**, etc.

The following page buttons are available:

- **Video Procamp:** Allows you to set the following parameters: **Y Gain, Black Level, Hue Level**, etc.
- **User Captions:** Allows you to set the **Text, Text Alt, X Pos, Y Pos, X Size, Y Size**, etc.

### Video 2 Picture Output

On this page, you can edit the values of general picture parameters: **Colorimetry, White Max, Black Min**, etc.

The following page buttons are available:

- **Color Correct:** Displays more color-specific parameters: **Offsets, Gains** and **Gammas.**
- **Output Border:** Allows you to set border-related parameters: **Left, Right, Top, Bottom.**

### ARC Control

On this page, the arc control parameters can be configured: **Recall Display Memory, Select Display Memory, Force Mapping 1** to **Force Mapping 4.**

The following page buttons are available:

- **ARC:** Allows you to set the following parameters: **Size, Aspect, Tilt** and **Pan.**
- **Input Crop:** Allows you to set the following parameters: **Left, Right, Force ARC Mapping 1** to **Force ARC Mapping 4.**
- **AFD Mapping:** Allows you to set **4:3 AFD Mapping 2** to **4:3 AFD Mapping 16** and **16:9 AFD Mapping 2** to **16:9 AFD Mapping 16.**
- **ARC Mapping:** Allows you to set **4:3 ARC Mapping 2** to **4:3 ARC Mapping 16** and **16:9 ARC Mapping 2** to **16:9 ARC Mapping 16.**

### Genlock/Blanking

In the Genlock section of this page, you can set the **Delay Mode, Delay Frames, Horizontal Delay**, etc. With the **Dolby-E Line** page button, you can configure **Pairs 1** to **8, User Lines, Auto Align 1** to **8**, ...

In the HANC/VBI Blanking section, you can configure the **Blanking: Standard** and the **Blank HANC. Blank 1** to **36** parameters are also available through the **Blank 1-18** and **Blank 19-36** page buttons.

### WSS Control

This page displays parameters such as **Enable Mapper, Force Enable**, etc.

Two page buttons are available:

- **Widescreen I/P**: Allows you to set the **Priority**, **WSS Enable,** **VI Enable**, etc.
- **Widescreen O/P**: Allows you to set the **Line 1 Read AFD, Line 1 Write AR, Blank 525 22**, etc.

### Ancillary Data

In the SMPTE 2016 section of this page, you can set the following parameters: **2016 I/P F1 Status, 2016 O/P F1 Line, 2016 Follow**.

In the SD VBI section, you can set the **WSS I/P Status, VITC I/P Status, CC608 I/P Status**, etc. There are also two page buttons in this section:

- **Lines Setup**: Allows you to set **Line 7** to **Line 23** to one of the following settings: *Off*, *VITC Output*, *WST*.
- **WST Lines**: Displays the status of **WST Line 7** to **WST Line 22**.

### Timecode

In the Input section, you can set parameters such as **Select ATC-LTC Input, Select ATC-VITC Input, Refresh Rate**, etc.

With the **Freerun** page button, you can define the **Hours, Minutes** and **Seconds** and confirm the new configuration with the **Apply** button.

In the Output section, you can monitor the **Timecode Value, Timecode Source**, etc. In this section, you can also set the **Offset Direction, Offset Field, Offset Frames**, etc.

With the **Output Insert** page button, you can set the **STD ATC-VITC Follow Input Line, HD ATC-LTC Output Line, Output Line F1**, etc.

### Audio Input

In the Disembed 1-8 section, the **Procamp Saveset** can be set. The **Disembed 1** to **Disembed 8** page buttons provide access to similar parameters: **Procamp, Mute, Stereo, Invert, Dolby Line.**

In the AES Input 1-8 section, the page buttons **AES Input 1** to **AES Input 8** show similar parameters: **Procamp, Mute, Stereo, Invert, AES I/O**.

The **Analog Input 1-2** page button provides access to the following parameters: **Procamp, Mute, Invert**.

### Audio Output

In the Embed 1-8 section, you can configure the **Embed Group 1** to **Embed Group 4.**

The following page buttons are available:

- **Embed 1** to **Embed 8:** Allow you to edit the **Procamp, Mute, Stereo** and **Dolby Line** parameters.
- **AES Output 1** to **AES Output 8:** Display the following parameters: **Procamp, Mute** and **Stereo.**
- **Analog Output 1-2:** Displays the parameters **Pro, Mute** and **Stereo**.
- **Routing** **Names:** Displays the **Output Name 30** to **Output Name 42.**

### Audio Setup

On this page you can find parameters such as **Silent Level, Overload Level, Level Timeout, Headroom Output**, etc.

In the Delay Select section of the page, you can configure settings that affect the global delays: **Bus Bulk Delay, Threshold, Delay Select: RollTrack 14**, etc. The **Total Delay Bus** displays the total delay affecting each of the 8 buses: **Total Delay Bus 1** to **Total Delay Bus 8.**

The values that these parameters display are the result of the combination of the values entered under the **Bus Delay** page button (**Bus 1 Delay** to **Bus 8 Delay** \[great step\]) and the settings of the **Bus Fine** page button (**Bus 1 Fine** to **Bus 8 Fine** \[small step\]).

**Frequency 0** to **7** can be set via the **Freq** page button, and **Ident 0** to **Ident 7** can be set via the the **Ident** page button.

The Status of **RollTrack 14** to **RollTrack 17** can be found under the **RollTrack** page button, while **Current RollTrack 14 Delay** to **Current RollTrack 17 Delay** are displayed under the **Curr RollTrack Delay** page button.

### Audio Routes

The Routing section of this page shows the parameters **Input Name Analog, Dolby Decode Source** and **Dolby Decode Number**, as well as the following page buttons:

- **Input Route Dest:** Allows you to configure the following parameters: **Input Route Destination 1** to **Input Route Destination 8.**
- **Input Hide AES:** Displays the status of the parameters **Input Hide AES 1** to **Input Hide AES 8.**
- **Input Name Dolby**: Displays the **Input Name Dolby 1** to **Input Name Dolby 5**.
- **Output Hide AES:** Displays the status of the parameters **Output Hide AES 1** to **Output Hide AES 8.**
- **Bus RName:** Displays the **Bus 1 RName** to **Bus 8 RName** parameters.

In the Output Routing section, the **Output Destination 1** to **Output Destination 30** configuration parameters are divided over 2 page buttons: **Out Dest 1-18** and **Out Dest 19-36**.

### Audio Routing Parameters

On this page, you can set the parameters **Bus 1 Audio Select** to **Bus 8 Audio Select.** Some of the possible values are: *Disembed 4, AES Input 8, Analog Input 1, Dolby Decoder 3.*

### Audio Output Route Matrix

This page contains several page buttons:

- **Embed**: Allows you to configure the **Embed 1 1 Audio Select** to **Embed 8 2 Audio Select** parameters. Some of the possible values are: *Bus 3 2, Downmix 2 2, Dolby Encode 2, Tone 7.*
- **AES:** Displays the parameters **AES1 1 Audio Select** to **AES8 2 Audio Select.**
- **Anlg:** Displays the parameters **Analog 1 1 Audio Select** to **Analog 2 2 Audio Select.**
- **Defaults:** Displays the parameters **Embed Output, AES Output** and **Analog Output**.

### Up Mixer Loud 1 to 4

In the sections **Up Mixer Loud S1** to **Up Mixer Loud S4,** the following parameters are displayed: **Procamp Gain, Mute** and **Source.** Some other general parameters such as the **Mode, Status, Center Width** and **Surround** are displayed below.

### Up Mixer Loud 5 to 8

In the sections **Up Mixer Loud S5** to **Up Mixer Loud S8**, the following parameters are displayed: **Procamp Gain, Mute** and **Source.**

There are also 2 general parameters: **Up Mixer Hide** and **Dialog Hide**, and two page buttons:

- The **Channel Name** page button displays the parameters **Channel 1 Name** to **Channel 8 Name**, and the **Channel 1 Name In** to **Channel 8 Name In.**
- Via the **Loudness** page button, the following parameters can be configured: **Preset 1/2, Master Level 1/2, Name 1/2** and **Bypass 1/2.**

### Loud Custom

In the Loud Custom Block 1 and 2 sections, the **Name** of the current custom preset can be edited and the **Custom Preset** can be selected.

Each of the 2 sections contains the following page buttons:

- **In AGC:** Displays amongst others: **In AGC Freeze, In AGC Gate, In AGC Threshold**, etc.
- **PEQ:** Displays the **PEQ Freq 1/2/3**, **PEQ Q 1/2/3** and **PEQ Level** **1/2/3.**
- **MB AGC:** Display the following parameters: **Atk 1** to **5, Release 1** to **5,** **Thresh 1** to **5, Output Lev 1** to **5,** **Lim Thresh 1** to **5, AGC Inf Thr 1** to **5.**
- **MB:** Display the following parameters: **Range, Progrise, Soft Clip 1/2, Ratio, Lim Drive.**

There is one additional page button, **Master Level**, which displays amongst others the following parameters: **Custom 1, Light 51, Heavy Ster B, Protect Ster B.**

### Mixers 1 to 3

In the Mixers S1 to Mixers S3 sections of this page, the following parameters are displayed: **Procamp Gain, Invert, Mute, Source** and **Name.**

The general parameter **Select** allows you to select one mixer.

### Mixers 4 to 6

In the Mixers S1 to Mixers S3 sections of this page, the following parameters are displayed: **Procamp Gain, Invert, Mute, Source** and **Name.**

### Dolby Decode

In the Decoder Output section of this page, the parameters **Master Gain** and **Master Mute** can be configured.

The following page buttons are available:

- **Output A1/A2:** Displays the following parameters: **A1/A2 Gain**, **Mute A1/A2**, and **Stereo A.**
- **Output B3/B4:** Displays the parameters **B3/B4 Gain**, **Mute B3/B4**, and **Stereo B.**
- **Output C5/C6:** Displays the parameters: **C5/C6 Gain**, **Mute C5/C6**, and **Stereo C**.
- **Output D7/D8:** Displays the parameters: **D7/D8 Gain**, **Mute D7/D8**, and **Stereo D**.
- **Output ML/MR:** Displays the parameters: **ML/MR Gain**, **Mute ML/MR**, and **Stereo M**.
- **Dolby Decoder:** Displays several sections. The Downmix Channel section displays the **Program Select, Output Mode**, etc. The **Decoder Status** section displays the **Bitstream Format, Bitstream Status**, etc. Some general parameters are also displayed: **Detect Mode, PCM Latency, Listening Mode Dolby**, etc.

### Dolby Encode

On this page, the **Source 1** to **Source 8** page buttons display the following parameters: **Procamp Gain, Mute** and **Source.**

### Dolby Control

On this page, you can find the following sections:

- Encoder Control, with the **Meta Revert Mode, Encoding Mode**, etc.

- E Encoder Control, with the **Bit Depth**, **Internal Config**, etc.

- Dolby Meta Program Select, with the **Meta Program Select \[42413\]** and **Meta Program Select \[42440\]**)

- Dolby D Encoder Control, with the **Internal Mode, Stream Number**, etc.

- Int Meta Control, with amongst others the **LFE Channel**, and the following page buttons:

- **Audio Production In:** Displays parameters such as **Mix Level, Room Type** and **Surround Mode**.
  - **Extended BSI1:** Displays parameters such as **Lt/Rt Centre Mix Level, Lo/Ro Centre Mix Level, Lo/Ro Surround Mix Level**, etc.
  - **Extended BSI2:** Displays parmaters such as **LFE Filter, Surround 3dB Attenuator, Int Meta Saveset**, etc.

### Dolby Status/Meta

This page has three sections. The Dolby Encoder Status section contains the **Reversion Status, H/W Version, O/P Program Config**, etc.

The Dolby Metadata State section displays amongst others the **Dialogue Norm, Line Mode, Surround Mode** and **Copyright** parameters, as well as three page buttons:

- The **Audio Production In** page button displays the **Mix Level, Room Type**, etc.
- The **Extended BSI1** page button displays the **Stereo** **Downmix Mode, Lo/Ro Centre Mix Level**, etc.
- The **Extended BSI2** page button displays the **LFE Filter,** **Surround 3dB Attenuation**, etc.

The Dolby Ext Prog State section contains the parameters **P1 Status** to **P8 Status**, as well as two page buttons:

- The **Dolby Metadata** page button displays the **RS485 Port Config, SMPTE 2020 Embedder**, etc. The SMPTE 2020 section displays specific parameters such as **O/P Enable** and **Follow I/P Line.**
- The **Dolby Common Status** subpage has 2 main sections: Channel Assignment (**Dolby A1, Dolby D8**, etc.) and Channel Pair Assignment (**Dolby 1/2, Dolby 3/4**, etc.). There are also some general parameters on this subpage: **Frame Rate**, **F/W Version**, **Device Name**.

### RollCall/Memories

This page is divided into 4 main sections:

- RollTrack: **Adress, Command, Sending**, etc.
- Logging 1: **AES Input, Dolby Decoder, VBI/ANC**, etc.
- Memories ABC: **Recall Memory, Select Memory**, etc.
- Logging 2: **Input Embed, Dolby E Align, Misc**, etc.

### GPIO

The GPI-1 and GPI-2 sections contain similar data: **GPI/O 1 Mode**, **Invert GPIO 1**, etc.

### Setup

This page contains the following parameters: **Setup Display, Product, Release, KOS, Serial Number, Input 1 Name**.

The following page buttons lead to more specific setup information: **FPGA**, **FPGA ENG**, **Options** and **Demo**.

### Loud Monitor Block

In the two sections of this page, Loud Monitor Block 1 and Loud Monitor Block 2, similar parameters are displayed: **Source L: Source, Source LS: Source, Source C: Source**, etc.

### Loud Monitor Block 1

This page contains the following parameters: **Integrated Level, Session Status, MS Update**, etc.

### Loud Monitor Block 2

This page contains amongst others: **Procamp 2 Status, Channel 1 ID, Integrated Level, LRA, MTPL**, etc.

### Connection Info

This page provides general information about the connection: the **Session Status**, **Assigned Session Nr, Unit Address, Unit Port**, etc.

It is also possible to force a new poll with the **Force Poll** button.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
