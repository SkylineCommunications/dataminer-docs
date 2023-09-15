---
uid: Connector_help_Ericsson_RX8315
---

# Ericsson RX8315

This is an SNMP connector that shows the status of the different parameters of an **Ericsson RX8315 receiver**.

## About

The **Ericsson RX8315** is a very versatile piece of equipment. It comes in many different configurations, in which input and output options vary between IP, Satellite, Combo (satellite and IP), VSB, and ASI. For a combo type, a primary and secondary input can be specified.

This connector is intended to be usable with as many variations of the product as possible.

### Version Info

| **Range** | **Description**          | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version.         | No                  | Yes                     |
| 1.1.0.x          | New firmware. Added DCF. | Yes                 | Yes                     |

### Product Info

| **Range** | **Device Software Version** |
|------------------|-----------------------------|
| 1.0.0.x          | Under 8.10                  |
| 1.1.0.x          | New firmware version 8.10   |

## Installation and Configuration

### Creation

#### SNMP Connection

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

This page contains general status information:

- On the left-hand side, you can find the **TS Lock status,** **Signal Status**, and **Current Status**. There are also three bar graphs, showing the **Signal Strength, C/N** and **C/N Margin.**
- On the right-hand side, you can find the **Selected Service Name, Selected Service ID** **Fan rotation speed, Uptime,** **Video Status**, and **Combined Audio Status.**
- Below this, you can find the **Audio Channel Configuration** table, which lists the following parameters: **Audio Channel, Audio PID, PIDs list, Audio Status, Primary Language, Default Primary Language, Primary Language Changed, Secondary Language, Audio Bitrate, Audio Coding Type, Sampling Frequency, Buffer Usage, Decode Time, Info, Downmix, Audio Gain, Audio User PID, User Standard, Clipping Level, Routing, Delay Adjustment, Range Control, Line Mode Adjust**.

### General Page

This page contains more general status information, such as the **Current Temperature, Fan Rotation Speed, Board List, Name, IP Address, Subnet Mask, Gateway IP Address, MAC Address** and **Current Status.**

Several buttons are available on the page:

- The **Reboot button** allows you to restart the device.
- With the **Configurations** page button, you can export and import configurations for your device.
- The **Features** page button opens a table listing all the features with the license state.

### Input Page

This page contains information about the input parameters, and lets you set several parameters values.

On this page, you can find the **Card Type, Selected Input Source, Current Input Source, Primary Input, Secondary Input** (in case of a Combo Board)**, TS Lock status, TS bitrate, Packet Length, Return to Primary,** **Primary Lock Switch Period time,** and **Input Loss Switch Period time**.

It also shows a separate **ASI Status**, **Sat Status**, and **IP Status** (when available).

Several buttons are available on the page:

- The **VSB Card** page button shows status parameters of a VSB input board.
- The **Input ASI** page button shows ASI parameters, such as signal strength.
- The **Input IP** page button opens a page with all IP input related parameters, such as **Last IP address received, TS packets per UDP frame, network utilization, IP jitter, de-jitter buffer level, IP card firmware/software version, Redundancy parameters**, etc. On this subpage, there is a **Reset IP Stats** button that can be used to reset the IP statistics.
- The **Input Sat** page button leads to a page with parameters related to satellite input: **Sat Status, Null Packet Override, Null Packet Threshold, Signal Status, Selected Input RF, Post Viterbi BER, Selected Modulation, Selected Format, Selected FEC, Selected Sense, Selected Input Symbol Rate, Pilot Symbol Status** and **Frame Length**. There are also three bar graphs, showing the **Signal Strength, C/N** and **C/N Margin.**
  On this subpage there is another page button called **Sat Input**. It leads to a subpage where you can define the **LNB Frequency, Satellite Frequency, L-Band Frequency, Symbol Rate, Modulation Type, Roll Off, Spectrum Sense, Search Range, LNB Power Output, LNB Power Level** and **LNB 22Khz parameters**.
- The **IP Configuration** page button leads to a page where you can see and modify parameters for the IP configuration, such as **Network Utilization, Rx Uptime, IP address, Subnet Mask, Default Gateway, VLAN Tag, VLAN enable, ICMP enable, IGMP Version, ARP Enable, Ethernet Line Mode, Ethernet Current Line Mode, Duplex Mode, MAC Address, Multicast Address, Enable Multicast, Enable Unicast, Source IP Address, UDP Port, Column** and **Row Port**.

### Output Page

This page contains all parameters for the output, such as:

- **TS Feed** (with the following possible values: *Input, Transcoded to MPEG2, Descrambled* or *Unknown*).
- **Output 1, 2 and 3** (*ASI, SD SDI, Automatic, HD SDI* and *SDI 3G*)
- The **IP Output Ports Configuration** table, containing **Source IP, Destination IP, Destination Subnet Mask, IPO Gateway, Ethernet MAC Address, Link Status, UDP Source Port, UDP Destination Port,** and **Custom Source IP.**
- Router parameters, such as **Link Speed, MSM IP Address, NC State, RIP Metric Port1** and **RIP TX Interval.**

### CA Card Page

This page contains all parameters for use with Conditional Access Module or CA descrambling in software. Parameters include:

- On the left side: **Over Air Control, Over Air Message, Power Carrier Mode,** and **Biss Mode**.
- Below this, you can enter the **BISS Key, User 1** and **User 2** **keys**.
- On the right side: **CI Module Status, CI Module Name,** the **Number of Descrambled Services,** and the **Number of Descrambled Components**, as well as the write parameters **Max CAM Services** and **Max CAM Components.**

### Decode Page

This page contains parameters related to the decoding of the TS.

Here, you can find the parameters **Service, Service ID, PCR, PCR Status, SI Mode Detected, SI Mode, TS ID, Network ID, Original Network ID, Service Hunt, Service Drop, Major Minor Tracking, PID Flush, MSD Hunt**, and **MSD Drop**.

There are several page buttons: **Teletext, Subtitles, Splice** and **VANC-VBI:**

- The **Teletext** subpage shows the status of and lets you change the parameters for Teletext, such as **Current Teletext, User Teletext PID, Stream Status, Output Status, Insertion Status and PTS Sync Status**.
- The **DVB** **Subtitles** subpage shows the status of and lets you change the parameters for subtitles, such as **Current Subtitles, User Subtitles PID, Subtitle State, Subtitle Status, Subtitle Language, Subtitles Control**, etc.
- The **Splice** subpage shows parameters related to Splice, such as **Current Splice, User PID, Status, Event ID, Program ID, Splice Filtering, Filter Mask** and **Filter Value.**
- The **VANC-VBI** subpage shows parameters related to the VANC-VBI, such as **VITC Insertion Line 525(1)** and **(2), VITC Insertion Line 625 (1)** and **(2), VITC Output Status, WSS Insertion List, WSS Stream Status** and **WSS Output Status.**

### Decode Video Page

This page contains parameters related to the decoding of the Video part of the TS.

Here, you can find **Current Video, Video Status, Video Standard, Frame Rate, Aspect Ratio, Aspect Ratio Conversion, Down Conversion, Up Time, Video Height and Width, Bitrate, Scan Type, Color Type, GOP Sequence, GOP Length** and **Bit Buffer Level.**

There is an **Advanced** subpage, which contains more advanced options: **Test Pattern Type, Test Pattern Standard, Video Fail Mode, AFD/Bar Data, AFD/Bar Timeout, AFD Timeout, Composite 625 Modes, Composite 525 Modes, User Video PID, User Coding Standard, Video Conversion Modes, VGA Output Type, VGA Embedded Sync, Frame Sync** and **Frame Sync Status.**

### Decode Audio Page

This page contains parameters related to the decoding of the Audio part of the TS.

It contains two tables:

- The **Audio Channel Configuration** table, which lists: **Audio Channel, Audio PID, PIDs list, Audio Status, Primary Language, Default Primary Language, Primary Language Changed, Secondary Language, Audio Bitrate, Audio Coding Type, Sampling Frequency, Buffer Usage, Decode Time, Info, Downmix, Audio Gain, Audio User PID, User Standard, Clipping Level, Routing, Delay Adjustment, Range Control, Line Mode Adjust**.
- The **Audio Embedding Table**, with **Audio Embedding Decoder** and **Audio Embedding Status** settings.

### SNMP Page

This page contains a table that allows you to set up **Trap Servers**.

### Switching Parameters Page

This page contains parameters related to redundancy parameters, such as **CA Detection Mode, CA Detection, Element ID Source Matrix, Selected Service Name, Expected Service Name, Selected Service ID, Expected Service ID, Service Selection Check**.

**Note:** The **Switching Parameters page** was **removed** from version 1.1.0.1 onwards.

### Web Interface Page

This page contains a link to the web page of the actual device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

The **1.1.0.x** connector range of the Ericsson RX8315 protocol supports the usage of DCF and can only be used on a DMA with **8.5.8.5** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **SAT Input 1**: A single fixed interface of type **input.**
- **SAT Input 2**: A single fixed interface of type **input.**
- **SAT Input 3**: A single fixed interface of type **input.**
- **SAT Input 4**: A single fixed interface of type **input.**
- **ASI Input**: A single fixed interface of type **input.**
- **ASI Output 1**: A single fixed interface of type **output.**
- **ASI Output 2**: A single fixed interface of type **output.**
- **IP Output 1**: A single fixed interface of type **output.**
- **IP Output 2**: A single fixed interface of type **output.**

### Connections

#### Internal Connections

- Between **\[SAT Input x -\> ASI Output y\]** and **\[SAT Input x -\> IP Output z\],** where **x** is the value of the **Input RF** parameter, **y** will assume values of 1 and 2, and **z** is the **Output Port** **IP Index** that has a **UP Link Status**.
- Between **\[ASI Input-\> ASI Output y\]** and **\[ASI Input -\> IP Output z\],** where **y** will assume values of 1 and 2, and **z** is the **Output Port** **IP Index** that has a **UP Link Status**.

## Notes

Because of the versatility of the equipment, not all parameters will be filled in. If, for instance, your device is only IP-based, the Sat options will not be filled in.
