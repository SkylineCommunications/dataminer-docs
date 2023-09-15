---
uid: Connector_help_Ericsson_RX8200
---

# Ericsson RX8200

This is an SNMP connector that shows the status of the different parameters of an **Ericsson RX8200 receiver**.

## About

The **Ericsson RX8200** is a very versatile piece of equipment. It comes in many different configurations, in which input and output options vary between IP, satellite, combo (satellite and IP), VSB, and ASI. In case of a combo type, a primary and secondary input can be specified.

This connector allows the capturing of **traps** of type "**No TS Lock"**. The info related to the TS lock status is used to update the **TS Lock** **status** **parameter**. The IP to which the trap messages are sent can be configured in the **Trap Server** **table**, which contains the list of servers supporting the device.

### Version Info

| **Range**     | **Description**                                                                                                                                  | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version (SNMP only).                                                                                                                     | No                  | Yes                     |
| 1.0.1.x              | Evolution from the 1.0.0.x range (extends firmware compatibility).                                                                               | No                  | Yes                     |
| 2.0.0.x              | Reworked version of the 1.0.1.x range, with layout closely resembling the original device webpage.                                               | No                  | Yes                     |
| 2.0.1.x              | Added XPO interface.                                                                                                                             | No                  | Yes                     |
| 2.1.0.x              | Some new firmware 7.x features supported.                                                                                                        | No                  | Yes                     |
| 2.2.0.x              | Supports new firmware 7.x and beyond. Not fully downwards compatible: some trending/alarm history may be lost. New hardware (DVB-S2X) supported. | No                  | Yes                     |
| 3.0.0.x              | DCF functionality added.                                                                                                                         | Yes                 | Yes                     |
| 3.0.1.x              | Specific version made for customer BeIn. Based on version 3.0.0.18, but uses discreets for AudioEmbedding as they were until 3.0.0.9.            | Yes                 | Yes                     |
| 3.1.0.x \[SLC Main\] | Supports new firmware 7.x and beyond. Not fully downwards compatible: some trending/alarm history may be lost. New hardware (DVB-S2X) supported. | Yes                 | Yes                     |

### Product Info

| **Range** | **Device Software Version** |
|------------------|-----------------------------|
| 1.0.0.x          | Under 5.0.0                 |
| 1.0.1.x          | 5.0.0 onwards               |
| 2.0.0.x          | 5.0.0 onwards               |
| 2.0.1.x          | 5.0.0 onwards               |
| 2.1.0.x          | 7.0.0 onwards               |
| 2.2.0.x          | 7.0.0 onwards               |
| 3.0.0.x          | 3.0.0.x                     |
| 3.0.1.x          | 8.11.x                      |
| 3.1.0.x          | 7.0.0 onwards               |

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
- **Set community string**: The community string in order to set to the device. The default value is *private*.

#### Serial connection

Ranges 2.0.1.x and 3.0.0.x require a second, TCP/IP connection.

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Port**: The port used by the device for its web interface, normally this is *80.*

### Configuration

In the 3.1.0.x range, from version 3.1.0.20 onwards, the timers have been replaced by a single timer, which checks if the "timer" interval for each of the previous timers has been reached. The timer intervals can be configured on the **Polling Configuration** page.

In the 3.0.0.x range, from version 3.0.0.15 onwards, and in the 3.1.0.x range, from version 3.1.0.26 onwards, you can choose whether to display the **PID+Name** or only the **PID** on the Decode Audio page.

## Usage

### Main View Page

This page contains general status information, such as the **TS Lock status**, **Signal Status** and **Current Status**. There are also three bar graphs, showing the **Signal Strength**, **C/N** and **C/N Margin**.

On the right-hand side, you can find the **Selected Service Name**, **Selected Service ID,** **Uptime**, **Video Status** and **Combined Audio Status**.

Below this, you can find the **Audio Channel Configuration**, which lists the following parameters: **Audio Channel, Audio PID, PIDs list, Audio Status, Primary Language, Default Primary Language, Primary Language Changed, Secondary Language, Audio Bitrate, Audio Coding Type, Sampling Frequency, Buffer Usage, Decode Time, Info, Downmix, Audio Gain, Audio User PID, User Standard, Clipping Level, Routing, Delay Adjustment, Range Control** and **Line Mode Adjust**.

### General Page

This page contains more general status information, such as the **Current Temperature, Fan Rotation Speed, Board List, Name, IP Address, Subnet Mask, Gateway IP Address, MAC Address** and **Current Status.**

There is also a **Reboot button**, which allows you to restart the device.

With the **Configurations** page button, you can export and import configurations for your device.

The **Features** page button opens a table listing all the features with the license state.

### Alarm Settings Page

This page displays configuration parameters for the alarm messages, such as **TS Lock Alarm Delay** and **No Primary Input Lock (Relay Mapping)**.

This page is only available in the **2.0.1.x** connector range from **2.0.1.14** onwards, in the **2.1.0.x** connector range (**all versions**), the **2.2.0.x** range (**all versions**), the **3.0.0.x** range (**all versions**), and the **3.0.1.x** range (**all versions**)

### Input Page

This page contains information about the input parameters and allows you to set the values of several parameters.

The page displays the **Card Type**, **Selected Input Source**, **Current Input Source**, **Primary Input**, **Secondary Input** (in case of a combo board), **TS Lock status**, **TS Bitrate**, **Packet Length**, **Return to Primary**, **Primary Lock Switch Period time** and **Input Loss Switch Period time**.

It also shows a separate **ASI Status**, a **Sat Status**, and an **IP Status** (when available).

The page contains a number of page buttons:

- **VSB Card**: Shows status parameters of a VSB input board.
- **Inputs ASI**: Shows ASI parameters, such as signal strength.
- **Inputs IP**: Opens a page with all IP input-related parameters, such as **Last IP Address Received**, **TS Packets per UDP Frame**, **network utilization**, **IP Jitter**, **Buffer Level**, **IP Card Firmware/Software Version**, **redundancy parameters**, etc. There is also a **Reset IP Stats** button that can be used to reset the IP statistics.
- **Inputs Sat**: Opens a page with parameters related to satellite input: **Sat Status**, **Null Packet Override**, **Null Packet Threshold**, **Signal Status**, **Selected Input RF**, **Post Viterbi BER**, **Selected Modulation**, **Selected Format**, **Selected FEC**, **Selected Sense**, **Selected Input Symbol Rate**, **Pilot Symbol Status** and **Frame Length**. There are also three bar graphs, showing the **Signal Strength**, **C/N** and **C/N Margin**.
- **Sat Input**: Displays the **Satellite Input Configuration** table, where you can define the **LNB Frequency, Satellite Frequency, L-Band Frequency, Symbol Rate, Modulation Type, Roll Off, Spectrum Sense, Search Range, LNB Power Output, LNB Power Level** and **LNB 22Khz** parameters.
- **IP Configuration**: Opens a page where you can see and modify parameters for the IP configuration, such as **Network Utilization, Rx Uptime, IP Address, Subnet Mask, Default Gateway, VLAN Tag, VLAN Enable, ICMP Enable, IGMP Version, ARP Enable, Ethernet Line Mode, Ethernet Current Line Mode, Duplex Mode, MAC Address, Multicast Address, Enable Multicast, Enable Unicast, Source IP Address, UDP Port, Column** and **Row Port**.
- **Terrestrial Input**: Shows status parameters of a **DVB-T** input board, such as **Modulation**, **Bandwidth**, **MER**, **Demodulator Lock**, **Carrier Frequency Offset**, **FFT Size**, etc. This subpage also displays config parameters such as **Card Alarm Status**, **System**, **Channel**, **Scanning Status**, **Start Search with Modulation** and **Bandwidth**.

### Output Page

This page contains all parameters for the output, such as **TS Feed** (*Input, Transcoded to MPEG2, Descrambled* or *Unknown*), **Output 1, 2 and 3** (*ASI, SD SDI, Automatic, HD SDI* and *SDI 3G*), and the configuration of the IP output ports, with **Source IP, Destination IP, Destination Subnet Mask, IPO Gateway, Ethernet MAC Address, Link Status, UDP Source Port, UDP Destination Port** and **Custom Source IP**. Router parameters are also included, such as **Link Speed, MSM IP Address, NC State, RIP Metric Port1** and **RIP TX Interval**.

### CA Card Page

This page contains all parameters for use with the Conditional Access Module or CA descrambling in the software. The parameters include **Over Air Control, Over Air Message, Power Carrier Mode** and **Biss Mode**, and **BISS Detected**. The **BISS Key** and the **User 1** and **User 2 keys** can also be entered here. Finally, the page also displays the **CI Module Status**, the **CI Module Name**, the **Number of Descrambled Services** and the **Number of Descrambled Components**, and it allows you to define the **Max CAM Services** and **Max CAM Components**.

### Decode Page

This page contains parameters related to the decoding of the TS, including the parameters **Service, Service ID, PCR, PCR Status, SI Mode Detected, SI Mode, TS ID, Network ID, Original Network ID, Service Hunt, Service Drop, Major Minor Tracking, PID Flush, MSD Hunt** and **MSD Drop**.

There are page buttons to the following subpages:

- **Teletext:** Shows the status of and lets you change the parameters for Teletext, such as **Current Teletext, User Teletext PID, Stream Status, Output Status, Insertion Status** and **PTS Sync Status**.
- **DVB** **Subtitles**: Shows the status of and lets you change the parameters for subtitles, such as **Current Subtitles, User Subtitles PID, Subtitle State, Subtitle Status, Subtitle Language, Subtitles Control,** etc.
- **Splice:** Shows parameters related to splice, such as **Current Splice, User PID, Status, Event ID, Program ID, Splice Filtering, Filter Mask** and **Filter Value.**
- **Service Plus** (only available from **version 2.0.1.23** onwards): Shows parameters related to a service, such as **Encryption, Service Type, Service ID, Service Name, Decrypt** and **Decode.**
- **VANC-VBI:** Shows parameters related to the VANC-VBI, such as **VITC Insertion Line 525(1)** and **(2), VITC Insertion Line 625 (1)** and **(2), VITC Output Status, WSS Insertion List, WSS Stream Status** and **WSS Output Status**.

### Decode Video Page

This page contains parameters related to the decoding of the video part of the TS: **Current Video, Video Status, Video Standard, Frame Rate, Aspect Ratio, Aspect Ratio Conversion, Down Conversion, Up Time, Video Height and Width, Bitrate, Scan Type, Color Type, GOP Sequence, GOP Length** and **Bit Buffer Level.**

The **Advanced** subpage contains more advanced options: **Test Pattern Type, Test Pattern Standard, Video Fail Mode, AFD/Bar Data, AFD/Bar Timeout, AFD Timeout, Composite 625 Modes, Composite 525 Modes, User Video PID, User Coding Standard, Video Conversion Modes, VGA Output Type, VGA Embedded Sync, Frame Sync** and **Frame Sync Status.**

### Decode Audio Page

This page contains parameters related to the decoding of the audio part of the TS.

You can find a table here for the **Audio Channel Configuration**, which lists the **Audio Channel, Audio PID, PIDs list, Audio Status, Primary Language, Default Primary Language, Primary Language Changed, Secondary Language, Audio Bitrate, Audio Coding Type, Sampling Frequency, Buffer Usage, Decode Time, Info, Downmix, Audio Gain, Audio User PID, User Standard, Clipping Level, Routing, Delay Adjustment, Range Control** and **Line Mode Adjust**.

Another table displays the **Audio Embedding status**, with **Audio Embedding Decoder** and **Audio Embedding Status** settings.

### PID Overview Page

This page contains an overview of all the **PIDs** for the active service, with their **PID Name**, **PID Full Name**, and **PID Type**.

It is only available in the **3.0.0.x** connector range from **3.0.0.15** onwards, and in the **3.1.0.x** connector range from **3.1.0.26** onwards.

### Presets Page

This page contains a table with **Presets** of settings, which can be saved and restored.

It is only available in the **2.0.1.x** connector range from **2.0.1.14** onwards, in the **2.1.0.x** range (**all versions**), in the **2.2.0.x** range (**all versions**), in the **3.0.0.x** range (**all versions**), and in the **3.1.0.x** connector range (**all versions**).

### SNMP Page

This page contains a table that allows you to set up **Trap Servers**.

### Switching Parameters Page

This page contains parameters related to redundancy, such as **CA Detection Mode, CA Detection, Element ID Source Matrix, Selected Service Name, Expected Service Name, Selected Service ID, Expected Service ID** and **Service Selection Check**.

### Service List Page

This page contains a table that shows a list of the services. It is only available in the **3.1.0.x** connector range.

The table lists the following parameters: **Type**, **ID**, **Name** and **Encryption**.

### Service Split Page

This page contains a table that shows a list of service splits. It is only available in the **3.1.0.x** connector range.

The table lists the following parameters: **Program Number**, **Service Name**, **Status**, **Ethernet Port 1**, **Ethernet Port 2**, **VBR**, **CBR Rate**, **Source IP**, **Source UDP Port**, **Destination IP**, **Destination UDP Port** and **TTL**.

### Alarms Page

This page contains the **Alarms Current** table, a table that shows all currently detected alarms. It contains information such as the **Alarm Type**, the **Module Type** and the **Profile ID**.

### Polling Configuration Page

This page allows you to set the timer intervals. It is only available in the **3.1.0.x** connector range, from **3.1.0.20** onwards.

### Web Interface Page

This page contains a link to the web page of the actual device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

The **3.0.0.x** and **3.1.0.x** connector range of the **Ericsson Rx8200** protocol support the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

Fixed interfaces

- **Input - ASI Input -** related parameter: **ASI Status**.
- **Input** - **IP Input 1** - no related parameters.
- **Input** - **IP Input 2** - no related parameters.
- **Output - Output 1 -** related parameter: **Output 1**.
- **Output - Output 2 -** related parameter: **Output 2**.
- **Output - Output 3 -** related parameter: **Output 3**.
- **Output** - **IP Output 1** - no related parameters.
- **Output** - **IP Output 2** - no related parameters.

#### Dynamic Interfaces

Physical dynamic interfaces:

- **Input - SAT Input -** These inputs refer to the **Satellite** table.

Virtual dynamic interfaces:

- **In/Out**: - **DCF** - These inputs refer to the **Remote DCF Interface** table (only applies for Visio).

### Connections

#### Internal Connections

- Between **ASI Input** and **Outputs**: User selection under the **Input Source** parameter.
- Between **SAT Input** and **Outputs**: User selection under the **Input Source** and **Select Input RF** parameters.
- Between **IP Input** and **Outputs**: User selection under the **Input Source** and **Input Port** parameters.

## Notes

Because of the versatility of the equipment, not all parameters will be filled in. If, for instance, your device is only IP-based, the Sat options will not be filled in.

For version 3.1.0.x, which allows the configuration of the timers to be set, this is the list of parameters that correspond with each timer group:

