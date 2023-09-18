---
uid: Connector_help_Ericsson_EN81X0
---

# Ericsson EN81X0

This is a **serial** connector that displays the status of the different parameters of an **Ericsson EN81X0 Encoder**.

## About

The **Ericsson EN81X0 Encoder** connector supports various encoder/re-encoder modules: the **EN7100** and the **EN8190**.

The connector has 2 connector ranges: the v.1.0.0.x and v.3.0.0.x.

Range 3.0.0.x differs from range 1.0.0.x in that it supports firmware version 7.

## Installation and Configuration

### Creation

This connector uses a serial connection (HTTP) and requires the following input during element creation:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not required.
- **Port**: Default port *80.*

## Usage

### General Page

This page contains general status information, such as the **Model Number**, the **Serial Number**, a table with **Controller Information**, etc.

On the right-hand side of the page, several page buttons are available:

- The **Fans** subpage contains information about the fans in the system.
- The **Advanced** subpage contains some advanced information about the system, such as the **controller requested airflow,** and various **temperature** parameters.
- The **Configurations** subpage contains some fields that allow you to **back up** and **restore** the current configuration.

### Network Page

This page contains the **Network Overview** table, which shows information about the ports in the system, as well as networking details such as the **Duplex mode, Default MAC Address**, etc.

### Slots Page

This page contains information about the different cards that are inserted in each slot. You can find information such as the **actual and expected HW version,** and **actual and expected SW version.**

On the right-hand side of the page, a page button is available for each slot. Each button opens a subpage with more detailed information on the card in that slot, such as the **card name,** **card status, card mode**, etc.

### Transport Stream Page

This page displays two tables:

- **Output Transport Stream table**: Contains information about the Output TS, such as the number of **TS Packets**, **TS Mode**, **TS Bitrate**, etc.
- **TS Destination Overview table**: Contains information about the **Destination IP Address, Source IP port**, etc.

### Services And PIDs Page

This page contains parameters referring to Services and PIDs.

There are two tables on this page:

- **Services** **table**: Contains parameters such as **Service Provider**, **Service Type**, **PMT PID**, etc.
- **PID Overview** **table**: Contains parameters such as **Elementary Stream**, **PID Status**, etc.

### ASI IO Info Page

This page contains parameters referring to the **ASI IO Option Card**, such as the **ASI IO Name, ASI IO SW Version**, etc.

On the right-hand side, the **ASI IO Port** table is displayed, which contains the **ASI IO Port Type,** **ASI IO Port Status,** etc.

The **Advanced** page button opens the **Advanced ASI IO Info** subpage, which contains environmental information about the **ASI IO Card**, such as the **ASI IO Requested Air Flow, ASI IO FPGA Temperature**, etc.

### ASI IO TS Stream Page

This page contains parameters referring to the **ASI IO TS Streams**.

The **ASI IO TS Stream** table contains parameters such as the **ASI TS Mode, ASI TS Bitrate, ASI IO TS Network ID**, etc.

There are two page buttons available:

- **Services**: Opens the **ASI IO Services** subpage, which contains the **ASI IO Services** table, with parameters such as **ASI IO Service Provider, ASI IO PMT PID**, etc.
- **PIDs**: Opens the **ASI IO PIDs** subpage, which contains the **ASI IO PID Overview** table, with parameters such as the **ASI IO Elementary Stream**.

### EN7100 Info Page

This page contains general information about the EN7100 Card, such as the **EN7100 Card ID, EN7100 Build Date**, etc.

### EN7100 Audio Page

This page contains parameters related to the Audio part of the EN7100 Card.

It consists of the following three tables:

- **EN7100 Audio Decoder**: Consists of parameters such as **EN7100 Decoder Input Source**, **EN7100 Decoder Type**, **EN7100 Switchout**, etc.
- **EN7100 Audio Encoder Input**: Contains parameters such as **EN7100 Encoder Input Source, EN7100 Encoder Input Rate,** etc.
- **EN7100 Audio Output Stream**: Contains parameters such as **EN7100 Audio Stream Type,** **EN7100 Audio Stream Port,** **EN7100 Audio Bitrate**, etc.

### EN7100 Audio Encode Page

This page contains parameters related to the Audio Encoding part of the EN7100 Card.

It contains amongst others the **EN7100 Audio Encoding Overview** table, with parameters such as the **EN7100 Audio Coding Standard, EN7100 Audio Encoding Delay**, etc.

There are also 8 page buttons:

- **MPEG Layer 2**: Displays the **EN7100 MPEG Layer 2** table, with the **EN7100 MPEG Layer 2 Bitrate**, the **EN7100 MPEG Layer 2 Lipsync Offset**, etc.
- **Audio Desc**: Displays the **EN7100 Desc Service Bitrate, EN7100 Desc Service Embedded PCR**, etc.
- **Dolby Digital**: Displays the **EN7100 Dolby Digital** table, which contains parameters such as **EN7100 Bitrate, EN7100 DD Coding Mode**, etc.
- **DD Pass Thru**: Displays the **EN7100 DD Pass Thru** table, with parameters such as **EN7100 DD Pass Thru Embedded PCR**, **EN7100 DD Pass Thru Lipsync Offset**, etc.
- **DE Pass Thru**: Displays the **EN7100 DE Pass Thru** table, with parameters such as **EN7100 DE Pass Thru Embedded PCR**, **EN7100 DE Pass Thru Lipsync Offset**, etc.
- **AAC**: Displays the **EN7100 AAC** table, with parameters such as **EN7100 AAC Bitrate**, **EN7100 AAC Coding Mode**, etc.
- **HE-AAC**: Displays the **EN7100 HE-AAC** table, with parameters such as **EN7100 HE-AAC Bitrate, EN7100 HE-AAC Encapsulation**, etc.
- **LPCM Pass Thru.**: Displays the **EN7100 LPCM Pass Thru** table, with parameters such as **EN7100 LPCM Pass Thru Channel Mode, EN7100 LPCM Pass Thru Channel ID**, etc.

### EN7100 Pre-Processor Info Page

This page contains general information about the EN8190 Pre-Processor Card, such as **EN8190 Pre-Processor Card ID, EN8190 Pre-Processor Build Date**, etc.

There is an **EN8190 Pre-Processor Port** page, which contains parameters such as the **EN8190 Pre-Processor Port Type, EN78190 Pre-Processor Port Direction**, etc.

The **Advanced** page button opens the **Advanced EN8190 Pre-Processor Info** subpage, where you can find environmental information about the EN8190 card, such as the **EN8190 Backend FPGA Temperature**.

### EN8190 Input/Stream Output Page

This page contains parameters related to the Video Input part and the Video Stream Output part of the EN8190 Card:

- For the Video Input part, you can find parameters such as the **EN8190 Video Input Lock**, the **EN8190 Bandwidth**, the **EN8190 Film Mode**, etc.
- For the Video Stream Output part, you can find parameters such as the **EN8190 Video Embedded PCR,** the **EN8190 Video Copyright**, etc.

### EN8190 Video Encoder Page

This page contains parameters related to the Video Encoder part of the EN8190 Card, such as **EN8190 Video Encoder Bitrate, EN8190 Video Encoder Lookahead Delay,** etc.

The **Output** page button opens the **Video Encoder Output Stream** subpage, which contains the **EN8190 Video Encoder Output** table, with parameters such as the **EN8190 Video Stream Type**, the **EN8190 Video Stream Port**, etc.

### EN8190 VBI/VANC Data Page

This page contains parameters related to the VBI/VANC Data part of the EN8190 Card, such as **EN8190 HD SMPTE 2016, EN8190 HD Closed Captions,** etc.

### EN8190 Audio Page

This page contains parameters related to the Audio part of the EN8190 Card.

It contains the following three tables:

- **EN8190 Audio Decoder:** Contains parameters such as **EN8190 Decoder Input Source, EN8190 Switchout, EN8190 Decode DE Config**, etc.
- **EN8190 Audio Encoder Input:** Contains parameters such as **EN8190 Encoder Input Bitrate, EN8190 Downmix Status, EN8190 Encoder DE Bit Depth**, etc.
- **EN8190 Audio Output Stream**: Contains parameters such as **EN8190 Audio Stream Type**, **EN8190 Audio Bitrate**, etc.

### EN8190 Audio Encode Page

This page contains parameters related to the Audio Encoding part of the EN8190 Card.

It contains amongst others the **EN8190 Audio Encoding Overview** table, with parameters such as the **EN8190 Audio Coding Standard, EN8190 Audio Encoding Delay,** etc.

There are also 8 page buttons:

- **MPEG Layer 2**: Displays the **EN8190 MPEG Layer 2** table, with the **EN81900 MPEG Layer 2 Bitrate**, the **EN8190 MPEG Layer 2 Lipsync Offset**, etc.
- **Audio Desc:** Displays the **EN8190 Desc Service Bitrate, EN819 Desc Service Embedded PCR,** etc.
- **Dolby Digital**: Displays the **EN8190 Dolby Digital** table, which contains parameters such as **EN8190 Bitrate, EN8190 DD Coding Mode**, etc.
- **DD Pass Thru**: Displays the **EN8190 DD Pass Thru** table, with parameters such as **EN8190 DD Pass Thru Embedded PCR**, **EN8190 DD Pass Thru Lipsync Offset**, etc.
- **DE Pass Thru**: Displays the **EN8190 DE Pass Thru** table, with parameters such as **EN8190 DE Pass Thru Embedded PCR**, **EN8190 DE Pass Thru Lipsync Offset**, etc.
- **AAC**: Displays the **EN8190 AAC** table, with parameters such as **EN8190 AAC Bitrate**, **EN8190 AAC Coding Mode,** etc.
- **HE-AAC**: Displays the **EN8190 HE-AAC** table, with parameters such as **EN8190 HE-AAC Bitrate, EN8190 HE-AAC Encapsulation**, etc.
- **LPCM Pass Thru**: Displays the **EN8190 LPCM Pass Thru** table, with parameters such as **EN8190 LPCM Pass Thru Channel Mode, EN8190 LPCM Pass Thru Channel ID**, etc.

### EN8190 Dolby Metadata Presets Page

This page contains parameters related to the Dolby Metadata Presets part of the EN8190 Card.

It consists of the **EN8190 Dolby Metadata Presets** table, with parameters such as the **EN8190 Bitstream Mode, EN8190 Line Mode Compression Profile,** etc.

### EN8190 Encoder Info Page

This page contains parameters referring to the EN8190 Encoder Card, such as the **EN8190 Encoder Name, EN8190 Encoder SW Version**, etc.

The **Advanced** page button opens the **Advanced EN8190 Encoder Info** subpage, which contains environmental information about the EN8190 Encoder Card, such as the **EN8190 Encoder** **Requested Air Flow, EN8190 Encoder Motion FPGA Temperature**, etc.

### Device Alarms Page

This page contains parameters referring to the hardware and environment of the system, such as the **Unit Fan Fail, Unit Power On Self Test Failure,** etc.

There are three page buttons:

- **Network**: Opens the **Network Alarms** subpage, which contains information about network alarms. Here you can find parameters such as **Ctrl 1: Link Down, Data 2: Duplicate IP Address**, etc.
- **Slots**: Opens the **Slots Alarms** subpage, which contains information about slot alarms. Here you can find parameters such as **Slot 1 Boot Failed, Slot 2 Comms Failure, Slot 3 HW Configuration Mismatch**, etc.
- **Services**: Opens the **Services Alarms** subpage, which contains information about services alarms. Here you can find parameters such as **Slot 1 Referenced Output Stream Unavailable**.

### ASI IO Alarms Page

This page contains alarm parameters referring to the ASI IO Card, such as **ASI IO Over Temperature, ASI IO Module Error**, etc.

### EN7100 Alarms Page

This page contains alarm parameters referring to the EN7100 Card, such as **EN7100 Over Temperature Warning, EN7100 Video Input Lock**, and **EN7100 Audio Module Error**.

The page also contains two page buttons, **Audio Decode** and **Audio Encode,** which open the following subpages:

- **EN7100 Audio Decoder Alarms**: Contains alarms related to the Audio Decoder part of the EN7100 Card, and contains parameters such as **EN7100 Audio Decode 1 DE Alignment, EN7100 Audio Decode 2 Decoder Input Not Locked**, etc.
- **EN7100 Audio Encoder Alarms**: Contains alarms related to the Audio Encoder part of the EN7100 Card, and contains parameters such as **EN7100 Audio Encode 1 Input Lock, EN700 Audio Encode 2 Silence**, etc.

### EN8190 Alarms Page

This page contains alarm parameters referring to the EN8190 Card, such as **EN8190 Over Temperature Warning, EN8190 Video Input Lock Status, EN8190 Video/Audio Module Error**.

The page also contains the following page buttons:

- **Reflex**: Opens the **EN8190 Video Encoder Reflex Alarms** subpage, which contains alarms such as the **EN8190 Reflex PCR Exchange Timeout**, **EN8190 Reflex Apply-Time Out Of Range**, etc.
- **Audio Decode**: Opens the **EN8190** **Audio Decoder Alarms** subpage, which contains alarms related to the Audio Decoder part of the EN8190 Card, and contains parameters such as **EN8190 Audio Decode 1 DE Alignment, EN8190 Audio Decode 2 Decoder Input Not Locked,** etc.
- **Audio Encode 1**: Opens the **EN8190 Audio 1 Encoder Alarms** subpage, which contains alarms related to the Audio Encoder part of the EN8190 Card, and contains parameters such as **EN8190 Audio Encode 1 Input Lock, EN8190 Audio 1 Encode 5 Silence**, etc.
- **Audio Encode 2:** Opens the **EN8190 Audio 2 Encoder Alarms** subpage, which contains alarms related to the Audio Encoder part of the EN8190 Card, and contains parameters such as **EN8190 Audio Encode 2 Input Lock, EN8190 Audio 2 Encode 5 Silence**, etc.
- The **EN8190 Encoder Alarms** subpage contains alarms related to the Encoder part of the EN8190 Card, and contains parameters such as **EN8190 Encoder Over Temperature Warning, EN8190 Encoder Video/Audio Module Error**, etc.

### EN8190 Switching VLAN Page

This page contains parameters related to the configuration of the VLAN part, and contains parameters such as **IF VLAN Port 1, RX Bitrate Port 2**, etc.

### Web Interface

This page links to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
