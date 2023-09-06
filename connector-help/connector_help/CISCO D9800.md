---
uid: Connector_help_CISCO_D9800
---

# CISCO D9800

The Cisco D9800 Network Transport Receiver supports high-efficiency video coding (HEVC) and ultra-high-definition (UHD) delivery over satellite and IP terrestrial content distribution networks requiring DVB-S (Digital Video Broadcasting - Satellite), DVB-S2 (Digital Video Broadcasting - Satellite - Second Generation), and IP reception capabilities. This device can decode an MPEG-2, advanced video coding (AVC), or HEVC video-encoded service, and it can output the serial digital interface (SDI) or composite uncompressed video.

The Cisco D9800 connector polls values in order to display information about the device and allows you to configure certain parameters.

The connector retrieves and sets information on the device through HTTP and SNMP.

## About

### Version Info

| **Range**            | **Description**                                                                                                                          | **DCF Integration** | **Cassandra Compliant** |
|----------------------|------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version.                                                                                                                         | No                  | No                      |
| 1.1.0.x              | Supports firmware 3.01.                                                                                                                  | No                  | Yes                     |
| 1.2.0.x              | Supports firmware 3.75.                                                                                                                  | No                  | Yes                     |
| 1.3.0.x              | Supports firmware 5.50 and possibility to switch between SS (Single-Stream) and MS (Multi-Stream) functionality depending on the device. | No                  | Yes                     |
| 1.3.1.x \[Obsolete\] | Supports firmware 6.80.                                                                                                                  | No                  | Yes                     |
| 1.4.0.x \[Obsolete\] | Supports firmware 6.52.                                                                                                                  | No                  | Yes                     |
| 1.5.0.x \[SLC Main\] | Supports firmware 7.0.SNMP connection removed.                                                                                           | No                  | Yes                     |

### Product Info

The table below indicates which device revision is available since a specific range. Every version within the same range also supports the previously implemented revisions.

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |
| 1.1.0.x   | 3.01                   |
| 1.2.0.x   | 3.75 & 4.01            |
| 1.3.0.x   | 5.50                   |
| 1.3.1.x   | 6.80                   |
| 1.4.0.x   | 6.52                   |
| 1.4.0.x   | 7.0                    |

## Configuration

### Connections

#### HTTP Main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

### Initialization

In order to poll all the data of the device, you must enter a valid username and password on the **Admin** page to start a new session.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage (Ranges 1.0.0.x - 1.1.0.x - 1.2.0.x)

### RF Status

This page displays information on the satellite-communicating antennas of the device. This information is directly related to the values configured on the **RF Inputs page**.

### Inputs

This page contains all the information on the inputs managed by the device:

- **RF Inputs**: Includes Port, Downlink Frequency, Symbol Rate, FEC, Modulation, Roll Off, I/1, AFC Limit, 22KHz, Power, LO1, LO2, Crossover, Polarization, Orbital Position, East/West Flag, and SAT Input Lock. The page also displays **RF Settings** such as Active Input, Downlink Frequency, Symbol Rate, FEC, Modulation, Roll Off, I/1, AFC Limit, 22KHz, Power, LO1, LO2, Crossover, Polarization, Orbital Polarization, East/West Flag, and SAT Input Lock for the 4 ports of the device.
- **ASI Inputs**: Includes Port, Active Input, Lock, Input Rate, Scramble Mode, Packet Size, and Link.
- **IP Inputs**: Includes MOIP Port, Interface, MOIP Active Input, Source IP Selection Mode, Enable Multicast, Multicast Address, FEC Mode, TS Destination Port, FEC Columns Port, FEC Rows Port, Source Filtering, De-Jitter Configuration Algorithm, De-Jitter Configuration Latency, Data Source 1, Data Source 2, Data 1 Transport Type, Data 2 Transport Type, and the Source Filter List Configuration.

### Status

This page contains several tables with status information:

- **ABR Input**: Includes Status, ASI Signal Lock, Input Rate, Download Fragment Count, Download Fragment Count, and more.
- **Zixi Input**: Includes Status, Signal Lock, Bit Rate, Network Name, and everything related to Zixi input.
- **Audio STC302 Decode**: Includes Device Number, Stream, Number of Streams, and Packet Size.
- **Video Decode Status**: Includes Input Stream Format, PV Output Format, SD Video Output Format, Bitrate, 3:2 Pulldown, Frames, Synchronization Mode, and Encoding Standard.
- **Audio Decode Status**: Includes Device, Mode, Bitrate, Buffer Level, Sample Rate, Dolby Digital Mode, Audio Dual Mono Mode, and Language.

### Configuration

This page contains three tables that are part of the configuration API:

- **ABR Input Configuration**: Contains all settings related to the ABR input, in accordance with the API.
- **Zixi Input Configuration**: Contains all Zixi input settings.
- **MOIP Output Stream**: Contains all MOIP output stream settings.

### Decryption

This page contains BISS CI and CA status information:

- **BISS**: Includes Mode, 1 Session Word, E Session Word, and E Injected ID.
- **CI Status Table**: Includes CAM Status, Sys Name, Comp Name, Manufacturer Code, Manufacturer ID, CI Serial Number, and Hardware Version Application Version.
- **CA Status Table**: Includes ISE User Address Enc Data Packets Passed, Enc Data Packets Received, Non-Enc Data Packets Passed, and Non-Enc Data Packets Received.

### Services

This page contains information on all the services that could be managed by the device:

- **TS Video Parameters**: Includes Video Bitrate, Video Frame Rate, and Encoding Format.
- **Video Setup**: Includes SDI 1, SDI 2, Primary Video Output, Standard Definition Output, Video Tri-Sync, Standard Definition Aspect Ratio, Selected Aspect Ratio Conversion, and Wide Screen Signaling Mode.
- **Video Status**: Includes Video Input Format, Services-Primary Video Output, Video Standard Definition Output, Video 3:2 Pull down, and Video Synch Mode.
- **Decode Program Status**: Includes Channel Name, Channel Number, PMT, and PCR.
- **Channel Status Table**: Includes Input Name, Channel, Channel Name, Conditional Access System ID, Channel Authorized, Channel Encrypted, Channel Scrambled, SR Status, SR Type, SR Start, and SR End.
- **Audio Status Table**: Includes PID, Language, Bitrate, Format, SFR, Buffer, DDP Mode, and Dual Mono.
- **Caption & VBI**: Includes Closed Caption Mode, Preferred Closed Caption Mode, VBI-VITC Status, VITS PAL Line 17, VITS PAL Line 18, VITS PAL Line 330, and VITS PAL Line 331.
- **Subtitles**: Includes Subtitle Control, Imitext Position, Imitext Foreground Color, Imitext Background Color, Language List, Language Entry, and PMT Order.
- **SDI**: Includes Interlaced, Frames/Second, Lines, Words, First, Last, Switch, Multiline, and the SDI VANC Service Setup & Status Table.
- **Audio 1 to 4 Setup**: Includes Audio Decode, AC3 Compression Mode, DD+Output, Language, Select by, Left Attenuation, Mode, and PMT Source and Right Attenuation.

### Outputs

This page contains all the information on the outputs managed by the device:

- **ASI Settings**: Includes Output Rate Control Mode, Output Rate, Output Mode, Output Descrambling Mode, and Insert Null Packet.
- **ASI Output Status**: Includes Output Rate and Free Bandwidth.
- **ASI DPM Program Entry Setup**: Includes ASI Action, ASI PMT PID, and ASI Output Channel Number.
- **ASI Output Transport Status**: Includes Type, Input, Output, PCR, Output Scrambled, and Input Received.
- **MOIP Settings**: Includes Output Rate Control Mode, Output Rate, Output Mode, Output Descrambling Mode, and Insert Null Packet.
- **MOIP Output Status**: Includes Critical MOIP Engine Error, MOIP TS Stream Overflow, Combined User Rate, Actual TS1 Port User Rate, and Actual TS2 Port User Rate.
- **MOIP DPM Program Entry Setup**: Includes MOIP Action, MOIP PMT PID, and Output Channel Number.
- **MOIP Output Transport Status**: Includes Type, Input PID, Output PID, PCR, Output Scrambled, and Input Received.
- **MOIP Stream Table**: Includes Stream, Bitrate, Encapsulation, Destination IP, Destination UDP Port, Traffic Class, Time to Live, and Source UDP Port.

### Admin

This page contains general information about the device: Host Name, Tracking ID, Master user address, Ethernet control port MAC address, MPEG Over IP Output, MPEG Over IP Input Supported, MPEG Over IP FEC Supported, and Serial Digital Interface Supported.

Via the **Login** page button, you can specify a username and password to start a new session.

There are also two tables:

- **Ethernet Link Status**: Includes Link Status, Link Speed, and Link Crossover.
- **Power Status**: Includes Power Good Signal, Card, and Status.

The following page buttons are also available:

- **Licenses**: Displays the information Number of HD Transcode Licenses, Number of SD Transcode Licenses, Number of HVEC Transcode Licenses, Number of Tuner Licenses, Licensed for Decryption, Licensed for DVB S2, Licensed for Tuner ASPK, Licensed for AVC decode, Licensed for HVEC decode, Licensed for HD output, Licensed for Full HD output, Licensed for UHD output, and Licensed for Audio 3 and 4 output.
- **Device General Information**: Displays the information Host Name, Host MAC Address, Device Model Number, Device Model Name, Device Board ID, Device Board FPGA Type, Primary Processor Boot Code Version, and Current App Version.

### Disaster Recovery

This page contains general information related to disaster recovery, including the **User Configuration** and **Search Path Status**.

Via page buttons, you can view the **Backup Table** and the **Search Path Table**

## Usage (Range 1.3.0.x - 1.5.0.x)

### General

This page contains generic information on the device hardware, such as the models and versions.

From range 1.3.0.x onwards, this page displays the type of the device, Single-Stream (SS) or Multi-Stream (MS). You can change the type manually if required.

### Output Status

This page contains the main information and settings for **ASI Output** and **IP Data/MoIP.** This includes the **DPM Collisions** for ASI and MoIP.

### Services

This page contains information about the services managed by the device (video, audio, subtitles, SDI, and VBI). The **Audio Setup** subpage is only available if the device is configured as **SS**.

### Status

This page contains three tables with status information for the video and audio services.

### Admin

This page contains general information about the device: Host Name, Tracking ID, Master User Address, Ethernet Control Port MAC Address, MPEG Over IP Output, MPEG Over IP Input Supported, MPEG Over IP FEC Supported, and Serial Digital Interface Supported.

Via the **Login** page button, you can specify a username and password to start a new session.

There are also two tables:

- **Ethernet Link Status**: Includes Link Status, Link Speed, and Link Crossover.
- **Power Status**: Includes Power Good Signal, Card, and Status.

The following page buttons are also available:

- **Licenses**: Displays the information Number of HD Transcode Licenses, Number of SD Transcode Licenses, Number of HVEC Transcode Licenses, Number of Tuner Licenses, Licensed for Decryption, Licensed for DVB S2, Licensed for Tuner ASPK, Licensed for AVC decode, Licensed for HVEC decode, Licensed for HD output, Licensed for Full HD output, Licensed for UHD output, and Licensed for Audio 3 and 4 output.
- **Device General Information**: Displays the information Host Name, Host MAC Address, Device Model Number, Device Model Name, Device Board ID, Device Board FPGA Type, Primary Processor Boot Code Version, and Current App Version.

### Disaster Recovery

This page contains general information related to disaster recovery, including the **User Configuration** and **Search Path Status**.

Via page buttons, you can view the **Backup Table** and the **Search Path Table**.
