---
uid: Connector_help_Ateme_Kyrion_2
---

# Ateme Kyrion 2

This **SNMP** connector can be used to monitor all kinds of Ateme Kyrion 2 devices.

## About

This connector retrieves all data using SNMP. The full ATEME-KYRION-2 MIB is implemented, which allows full monitoring of the device.

Alarms are also generated for each received trap.

### Version Info

| **Range** | **Description**                                                                                                                                           | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version.                                                                                                                                          | No                  | Yes                     |
| 1.0.1.x          | New firmware based on 1.0.0.13.                                                                                                                           | Yes                 | Yes                     |
| 1.0.2.x          | New firmware based on 1.0.1.16.                                                                                                                           | No                  | Yes                     |
| 1.0.3.x          | Based on 1.0.1.25. In every TS-related parameter, descriptions changed from '\[XXX\] \[ChannelNumber\].1' to 'Channel \[ChannelNumber\] Main TS \[XXX\]'. | Yes                 | Yes                     |
| 1.1.0.x          | New firmware based on 2.0.1.17.                                                                                                                           | Yes                 | Yes                     |
| 2.0.0.x          | Alternative parameter implementation based on version 1.0.0.11.                                                                                           | No                  | Yes                     |
| 2.0.1.x          | New firmware based on 2.0.0.9.                                                                                                                            | No                  | Yes                     |
| 2.0.2.x          | New firmware based on 2.0.1.14.                                                                                                                           | No                  | Yes                     |
| 2.0.3.x          | DCF support.                                                                                                                                              | Yes                 | Yes                     |
| 2.1.0.x          | New firmware based on 2.0.3.5. New trap mechanism.                                                                                                        | Yes                 | Yes                     |
| 3.0.0.x          | New firmware based on 2.0.2.16. New trap mechanism. Compatible with DataMiner 7.5.                                                                        | No                  | Yes                     |

### Product Info

| **Range**    | **Device Firmware Version**            |
|---------------------|----------------------------------------|
| 1.0.0.x             | MIB revision 201304081515Z             |
| 1.0.1.x             | v.2.0.1.0 (build 25.0.1-rc)            |
| 1.0.2.x             | v2.1.0.0 (build 26.0.0.0)              |
| 1.0.3.x             | v.2.0.1.0 (build 25.0.1-rc)            |
| 1.1.0.x             | v.2.0.1.2 (build 25.0.4)               |
| 2.0.0.x             | MIB revision 201304081515Z             |
| 2.0.1.1 - 2.0.1.13  | v.2.0.1.0 (build 25.0.1-rc)            |
| 2.0.1.14 and higher | v.2.0.1.2 (build 25.0.4)               |
| 2.0.2.x             | v.2.1.0.0 (build 26.0.0.0)             |
| 2.0.3.x             | v.2.1.0.0 (build 26.0.0.0)             |
| 2.1.0.x             | build 27.0.5.0 (MIB rev 201503311633Z) |
| 3.0.0.x             | build 27.0.5.0 (MIB rev 201503311633Z) |

## Configuration and Installation

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device*.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage: Range 1.0.x.y

### General

This page contains information about the device hardware and firmware. On the right-hand side of the page, there are page buttons to all the non-stream-related parameters.

The following subpages are available:

- **Time**: Time and NTP settings of the unit.
- **Biss**: Allows you to set the **Biss Injected Id**.
- **Software**: Displays the **Software** and **Software Backup Version**.
- **Preset**: Contains the **Preset** table.
- **Statmux**: Allows you to check and edit the **Statmux Port**.
- **Web**: Allows you to enable and authenticate the **Web Authentication**.
- **Network**: Contains the **Network Connection** and **Network Route** tables.
- **SNMP**: Allows you to set the read and write communities, and edit the SNMP trap settings in the **SNMP Manager** table.
- **Hardware Extension Slot**: Displays the **Extension Slot** table.
- **Hardware Power Supply**: Displays the **Power Supply** table, which allows monitoring of the PSU status.
- **Hardware Fan**: Displays the **Fan** table, which allows monitoring of the fan status.
- **Hardware Ethernet**: Displays the **Ethernet** table. In this table, the **State** column indicates the status of a connection, e.g. if it has been deleted from the table. A **Delete** button allows you to remove a row when its state is "*deleted*".
- **Hardware Modulator**: Displays the **Modulator** table, which allows monitoring of the alarm and mute status of the modulators.
- **License**: Displays the **License Table** with available licenses.
- **Configurations**: Allows you to download and upload configurations per slot to one or more files on the DMA.

### TS Overview

This page displays a tree view showing the relationship between presets, transport streams and components.

### Channels

This page contains the **Channel Table**, which indicates which channels are currently running.

### Channel {x}

Overall, there are 2 channels, designated as {x}, containing 2 transport streams each, designated as {y}.

The information for each transport stream is divided over separate pages. The pages Channel 1 and Channel 2 contain top-level parameters for both their transport streams and an array of page buttons to access more detailed information.

The following subpages are available:

- **TS {x}.{y} More**: Contains miscellaneous parameters: **Standard**, **Packet Size**, **Null Bitrate**, **PMT PID**, **PMT Number**, **PMT PCR PID**, **Enable SI/PSIP Tables**.
  In addition, this page links to the following subpages at an even lower level:

- **TS {x}.{y} SI Tables**: Contains parameters regarding the carrier, network and service setup.
  - **TS** **{x}.{y} Expert**: Contains the following parameters: **PAT TS ID**, **PAT Period**, **PMT Period**, **CAT Period**.

- **TS {x}.{y} More Video**: Contains video settings and page buttons to the encoding subpages:

- **TS {x}.{y} More Video MPEG-2**: Contains MPEG-2 encoding settings.
  - **TS {x}.{y} More Video H264**: Contains H264 encoding settings.

- **TS {x}.{y} Output ASI**: Allows you to enable the ASI output.

- **TS {x}.{y} Output DVB-S/S2**: Contains DVB-S-specific settings.

- **TS {x}.{y} Output IP**: Contains the **Output IP Table**, which contains settings for each IP output for this specific transport stream.

- **TS {x}.{y} Audio**: Contains the **Audio Table**, which allows you to enable audio and various other settings for each audio channel.
  This page also links to various subpages at an even lower level:

- **TS {x}.{y} Audio MPEG-L2**: Contains the **Audio MPEG-L2 Table**, which contains settings related to MPEG-L2 for each audio channel.
  - **TS {x}.{y} Audio AAC**: Contains settings related to AAC encoding.
  - **TS {x}.{y} Audio AC3**: Contains settings related to AC3 encoding.
  - **TS {x}.{y} Audio Input PCM**: Contains the **Audio Input PCM Table**, which allows you to change the **PCM Count** and **PCM Layout** for each audio channel.
  - **TS {x}.{y} Audio Input AC3**: Contains the **Audio Input AC3 Table**, which allows you to toggle the **AC3 Enhanced** and change the **AC3 Bitrate** for each audio channel.
  - **TS {x}.{y} Audio AES3**: Contains the **Audio Input AES3 Table**, which allows you to change the **AES3 Pair** and **AES3 Size**.
  - **TS {x}.{y} Audio DolbyE**: Contains the **Audio Input DolbyE Table**, which allows you to change the **DolbyE Size** and **DolbyE Program**.
  - **TS {x}.{y} Audio Emulation**: Contains the **Audio Input Emulation Table**, which allows you to toggle the **Force Emulation** and change the **Emulation Mode**.
  - **TS {x}.{y} Audio Analog**: Contains the **Audio Input Analog Table**, which allows you to change the **Analog Level**.

- **TS {x}.{y} Data**: Displays the **Data** **Table**, which allows you to change the **Data Enabled**, **Data Type** and **Data PID**.
  This page also links to the following subpages at a lower level:

- **TS {x}.{y} Teletext Descriptor**: Contains the **Teletext Descriptor** **Table**, which contains Teletext-specific settings.
  - **TS {x}.{y} More Data**: Contains the **Data Table More**, which allows you to change the **Data Delay** and toggle the **Data Teletext Filter Enabled**.

- **TS {x}.{y} Rate Control {z}**: Allows you to change the **{z}** **Video Rate Control Mode**. There are two encodings available, for which {z} is a placeholder in this help: **H264** and **MPEG-2**.
  This page also links to several subpages:

- **TS {x}.{y} Rate Control {z} CBR**: Allows you to change the **CBR Bitrate** and **CBR CPB** parameters.
  - **TS {x}.{y} Rate Control {z} Capped VBR**: Allows you to change the **VBR Capped Max Bitrate**, the **VBR Capped Quality** and **VBR Capped CPB** parameters.
  - **TS {x}.{y} Rate Control {z} StatMux VBR**: Allows you to change the **VBR StatMux Min Bitrate**, the **VBR StatMux Max Bitrate** and **VBR StatMux CPB** parameters.
  - **TS {x}.{y} Rate Control {z} Piecewise CBR**: Allows you to change the **Piecewise CBR Min Bitrate**, the **Piecewise CBR Bitrate** and **Piecewise CBR CPB** parameters.

### SDI

This page contains the following tables:

- **Hardware SDI**
- **Hardware SDI Audio**
- **Hardware SDI Audio Channel**

### Channel Command

This page allows you to manipulate presets per channel.

### Event Log

On this page, the **Event Log** table shows the most recent events that have occurred in the device.

This page has the following subpage:

- **Event Log Configuration**: Allows you to enable and change the delay of specific event logging.

### Web Interface

This page opens the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage: Range 1.1.0.x

### General

This page contains information about the device hardware and firmware. On the right-hand side of the page, there are page buttons to all the non-stream-related parameters.

The following subpages are available:

- **Time**: Time and NTP settings of the unit.
- **Software**: Displays the **Software** and **Software Backup Version**.
- **Preset**: Contains the **Preset** table.
- **Statmux**: Allows you to check and edit the **Statmux Port**.
- **Web**: Allows you to enable and authenticate the **Web Authentication**.
- **Network**: Contains the **Network Connection** and **Network Route** tables.
- **SNMP**: Allows you to set the read and write communities, and edit the SNMP trap settings in the **SNMP Manager** table.
- **Hardware Extension Slot**: Displays the **Extension Slot** table.
- **Hardware Power Supply**: Displays the **Power Supply** table, which allows monitoring of the PSU status.
- **Hardware Fan**: Displays the **Fan** table, which allows monitoring of the fan status.
- **Hardware Ethernet**: Displays the **Ethernet** table. In this table, the **State** column indicates the status of a connection, e.g. if it has been deleted from the table. A **Delete** button allows you to remove a row when its state is "*deleted*".
- **Hardware Modulator**: Displays the **Modulator** table, which allows monitoring of the alarm and mute status of the modulators.
- **License**: Displays the **License Table** with available licenses.

### TS Overview

This page displays a tree view showing the relationship between presets, transport streams and components.

### Channels

This page contains the **Channel Table**, which indicates which channels are currently running. You can **Start** or **Stop** a **Channel** by right-clicking it in the table.

### Channel 1

Overall, there is 1 channel containing 2 transport streams designated as {y}.

The information for each transport stream is divided over separate pages. The Channel 1 page contains top-level parameters for both its transport streams and an array of page buttons to access more detailed information.

### TS 1.{y} More:

This page contains miscellaneous parameters: **Standard**, **Packet** **Size**, **Null** **Bitrate**, **PMT** **PID**, **PMT** **Number**, **PMT** **PCR** **PID**, **Enable** **SI/PSIP** **Tables**.
In addition, this page links to the following subpages:

- **TS 1.{y} SI Tables**: Contains parameters regarding the carrier, network and service setup.
- **TS 1.{y} Expert**: Contains the following parameters: PAT TS ID, PAT Period, PMT Period, CAT Period.

### TS 1.{y} More Video:

This page contains video settings and page buttons to encoding subpages:

- **TS 1.{y} More Video MPEG-2**: Contains **MPEG-2** encoding settings.
- **TS 1.{y} More Video H264**: Contains **H264** encoding settings.

### TS 1.{y} Output ASI:

This page allows you to enable the **ASI output**.

### TS 1.{y} Output DVB-S/S2:

This page contains **DVB-S**-specific settings.

### TS 1.{y} Output IP:

This page contains the **Output IP** **Table**, which contains settings for each IP output for this specific transport stream.

### TS 1.{y} Audio:

This page contains the **Audio** **Table**, which allows you to enable audio and various other settings for each audio channel.
The page also links to various subpages:

- **TS 1.{y} Audio MPEG-L2**: Contains the **Audio MPEG-L2** table, which contains settings related to **MPEG**-**L2** for each audio channel.
- **TS 1.{y} Audio AAC**: Contains settings related to **AAC** encoding.
- **TS 1.{y} Audio AC3**: Contains settings related to **AC3** encoding.
- **TS 1.{y} Audio Input PCM**: Contains the **Audio Input PCM** table, which allows you to change the **PCM Count** and **PCM** **Layout** for each audio channel.
- **TS 1.{y} Audio Input AC3**: Contains the **Audio** **Input AC3** table, which allows you to toggle the **AC3 Enhanced** and change the **AC3** **Bitrate** for each audio channel.
- **TS 1.{y} Audio AES3**: Contains the **Audio Input AES3** table, which allows you to change the **AES3 Pair** and **AES3 Size**.
- **TS 1.{y} Audio DolbyE**: Contains the **Audio Input DolbyE** table, which allows you to change the **DolbyE Size** and **DolbyE Program**.
- **TS 1.{y} Audio Emulation**: Contains the **Audio Input Emulation** table, which allows you to toggle the **Force Emulation** and change the **Emulation Mode**.
- **TS 1.{y} Audio Analog**: Contains the **Audio Input Analog** table, which allows you to change the analog level.

### TS 1.{y} Data:

This page displays the **Data** table, which allows you to change **Data Enabled**, **Data Type** and **Data PID**.
The page also links to the following subpages:

- **TS 1.{y} Teletext Descriptor**: Contains the **Teletext** **Descriptor** table, which contains **Teletext**-specific settings.
- **TS 1.{y} More Data**: Contains the **Data Table** **More**, which allows you to change the **Data Delay** and toggle **Data Teletext Filter Enabled**.

### TS 1.{y} Rate Control {z}:

This page allows you to change the {z} **Video Rate Control Mode**. There are two types of encoding available, for which {z} is a placeholder in this help: **H264** and **MPEG**-**2**.
This page also links to several subpages:

- **TS 1.{y} Rate Control {z} CBR:** Allows you to change the **CBR Bitrate** and **CBR CPB** parameters.
- **TS 1.{y} Rate Control {z} Capped VBR:** Allows you to change the **VBR** **Capped Max Bitrate**, the **VBR Capped Quality** and **VBR Capped CPB** parameters.
- **TS 1.{y} Rate Control {z} StatMux VBR:** Allows you to change the **VBR** **StatMux Min Bitrate**, the **VBR StatMux Max Bitrate** and **VBR StatMux CPB** parameters.
- **TS 1.{y} Rate Control {z} Piecewise CBR:** Allows you to change the **Piecewise** **CBR Min Bitrate**, the **Piecewise CBR Bitrate** and **Piecewise CBR CPB** parameters.

### Event Log

On this page, the **Event Log** table shows the most recent events that have occurred in the device.

This page has the following subpage:

- **Event Log Configuration**: Allows you to enable and change the delay of specific event logging.

### Web Interface

This page opens the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage: Range 2.0.x.y

### General page

This page contains general information about the device, such as the unit name and model. However, you can also find important parameters here that are not related to specific functions of the device, e.g. the fan speeds and temperature.

### TS Overview page

This page contains a **tree view** with the **transport streams** (audio and video). You can also find the runtime status of the device on this page.

### Channels page

This page contains a table with all the channels.

### Channel 1 page

This page displays all the configuration parameters of the device, using a similar structure as in the web interface of the device.

### Channel Command page

This page contains actions that can be done on a channel, e.g. starting or stopping the streams.

### Polling Control page

This page contains all the tables from the Ateme Kyrion 2 device and allows you to define how quickly the tables must be polled.

### Event Log page

This page displays a table with the events that have happened in the system.

In the **2.1.0.x** range of the connector, **HEVC** tables and a **License** table are also available.

## DataMiner Connectivity Framework

The **1.0.1.x** and **1.1.0.x** connector range of the Ateme Kyrion 2 protocol support the usage of DCF and can only be used on a DMA with **8.5.8.5** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Dynamic Interfaces

Physical dynamic interfaces:

- **Inputs**: Created from entries in the **DCF Interface Table** with names starting with *SDI*\*, type: *in.*
- **ASI outputs**: Created from entries in the **DCF Interface Table** with names starting with *ASI*\*, type: *out.*
- **IP outputs**: Created from entries in the **Ethernet** table, type: *out.*

### Connections

#### Internal Connections

- Between **inputs SDI1** and **ASI outputs ASI1** when **ASI Enabled 1.1** is *True.*

- Between **inputs SDI2** and **ASI outputs ASI2** when **ASI Enabled 2.1** is *True*.

- Between an **input SDI {*x}*** and an **IP output *{y}***, when the IP output is enabled, with properties:

- **Service** connection property of type **generic** with value *{service name}*.
  - **MCOut** connection property of type **generic** with value *{IP}:{port}*.
