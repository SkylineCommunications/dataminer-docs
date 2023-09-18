---
uid: Connector_help_Tandberg_RX1290
---

# Tandberg RX1290

The **RX1290** is an MPEG2 and MPEG4-AVC integrated receiver decoder that can also operate with SD and HD, and that can decode both 4:2:0 and 4:2:2 video.

## About

This is an **SNMP** connector that is used to display the status of the different parameters of a **Tandberg RX1290 SNMP receiver**.

### Version Info

| **Range** | **Description**                               | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------------|---------------------|-------------------------|
| 3.0.0.x          | New range to support DCF internal connections | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 3.0.0.x          | 3.0.0                       |

## Installation and Configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not needed.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### Main View Page

This page contains general status information, such as the **Video Status**, **Audio 1 Status** and **Selected Service Name**.

There are also two bar graphs that show the **Eb/N0 Margin** and **RF Level.**

### General Page

This page contains more general status information, such as the **Model Name**, **Serial Number**, **Control Mode**, **Temperature**, etc.

A **Reset button** allows you to reset the device.

There are four page buttons, which lead to the following subpages:

- **License Table**: Displays the features that need a separate license, and shows whether the **license status** is disabled or enabled.
- **Board List**: Displays the hardware boards in the system, with some more information such as the **Software version** and the **Hardware Version**.
- **Configurations**: Allows you to upload and download configurations to and from your device.
- **Upgrade**: Allows you to upgrade the firmware of the device, with parameters such as **Path, Local Filename, FTP Username**, etc.

### Input Page

This page contains information about the input parameters, and allows you to change the **Input Card selection** and **Input Source**.

It also displays the **Input Bit Error Rate, Input Bit Rate** and **Input Status**.

### Input IP Page

This page contains information about the input IP option, and allows you to change IP-related parameters. It contains parameters such as **Encapsulation**, **Last IP Received, Multicast UDP Port**, etc.

### Input IP Dual NIC Page

The information on this page will only be filled in if the board configuration features a **Dual NIC board**.

The page contains parameters such as **Encapsulation Dual NIC**, **Last IP Received Dual NIC**, **UDP Port 1 Dual NIC**, **Mcast IP Address 2 Dual NIC**, etc.

### Input Demodulator Page

The information on this page will only be filled in if the board configuration features an **RF board**.

It contains parameters such as **RF Level**, **C/N**, **BER Measurement**, etc.

The following page buttons are available:

- **Input Config**: Displays parameters such as **Tune Frequency**, **FEC Rate, Polarization**, etc.
- **Normalize**: Opens a subpage where you can normalize the **C/N**, and the **Eb/N0 Margin**.

### Service Page

This page contains parameters related to the service, such as **Provider Name, Service ID, Current PCR PID, PCR Status**, etc.

The following page buttons are available:

- **VANC**: Displays parameters related to the VANC, such as **VANC Status** and **VANC PID**.

- **Advanced**: Displays advanced configuration parameters, such as **Network ID**, **Fail Mode**, **Output Mode, 4:2:0 Delay**, **Frame Sync PAL Offset**, **Embedded Audio 2**, etc.

- **Data**: Displays information about data parameters, such as **Asynchronous Data Status**, **Asynchronous Data Bit Rate**, etc.

- **VBI**: Displays information about VBI parameters, such as **VBI Status**, **VITC 625 Line 1**, **Closed Captions Status**, **WSS Status**, **AMOL Status**, etc.

- **PID Tables**: Displays parameters related to PIDs. The subpage contains 3 tables and an **Update Now** button, which can be used to immediately update the tables on this page:

- **PID Table:** Contains information about the PIDs in the system, listing the **Type** for each one.
  - **DVB Subtitle Table**: Contains more information about the **DVB Subtitles**, such as the **DVB Sub Language**, the **DVB Sub Comp Page Id**, etc.
  - **Audio Table**: Lists the different **Audio PIDs** in the stream, the **Audio Language**, **Audio Format**, etc.

- **Splice**: Displays parameters related to Splice, such as **Splice Reason** and **Splice PID.**

- **DVB Subtitles**: Displays the status of and lets you change the parameters for Subtitles, such as **DVB Subtitles Reason, DVB Subtitles User PID, DVB Subtitles Language**, etc.

- **Teletext**: Displays the status of and lets you change the parameters for Teletext, such as **Teletext Status, Teletext Reason** and **Teletext PID**.

The page also contains a **buffer mechanism** for services that need to be set. This mechanism can be **triggered** **externally** (e.g. via Automation scripts) or from within the connector.

### Video Page

This page contains parameters related to the decoding of the video part of the TS, such as **Video Status, Video Standard, Frame Rate** and **Aspect Ratio**.

### Audio Page

This page contains parameters related to the audio part of the TS, such as **Audio 1 PID, Audio 3 Format, Audio 2 Sample Rate**, etc.

There is a list of parameters for each of the 4 audio channels.

The **Advanced 1 & 2** page button opens the **Advanced** subpage for audio channels 1 & 2; the **Advanced 3 & 4** page button opens the **Advanced** subpage for audio channels 3 & 4.

The **Advanced Audio** subpage contains parameters for either audio channels 1 & 2 or audio channels 3 & 4, such as **Audio User PID, Audio Routing, Audio Clipping Level, Audio Delay Adjustment**, etc.

### Conditional Access Page

This page contains all the parameters for use with the Conditional Access Module or CA descrambling in software, such as **CA Status, BISS Mode, Mode 1 Key, RAS Mode** and **Common Interface Detected**.

### Output Page

This page contains parameters related to the output, such as **Transport Stream Output, Output Connector 1, Output Connector 2** and **Output Connector 3**.

### Switching Parameters Page

This page contains parameters related to redundancy parameters, such as **CA Detection Mode, CA Detection, Matrix input for the CA Message** and **Expected Service ID**.

### Embedded Web Server

This page contains a link to the web page of the actual device.

### Web Interface.

This page shows the web page of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

Due to the versatility of the equipment, not all parameters will be filled in. For example, if your device is only IP-based, the RF options will not be filled in.
