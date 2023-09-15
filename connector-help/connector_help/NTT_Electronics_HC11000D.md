---
uid: Connector_help_NTT_Electronics_HC11000D
---

# NTT Electronics HC11000D

This connector monitors and controls HC11000D devices, manufactured by NTT Electronics.

The HC11000D is a high-performance and reliable 10-bit 4:2:2 HEVC/AVC/MPEG-2 decoder.

## About

This connector allows you to view and control general and workflow (input, decode, output) settings of the device. These settings are retrieved and set via SNMP. SNMP traps, when enabled in the device, will update the list of alarms.

### Version Info

| **Range** | **Description**    | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version    | No                  | Yes                     |
| 1.0.1.x          | DCF implementation | Yes                 | Yes                     |
| 1.0.2.X          | DCF addition       | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 02.00                       |
| 1.0.2.x          | 02.00                       |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*. Can be changed in the SNMP settings of the device.
- **Get community string**: The community string used when reading values from the device. The default value is *public*. The device allows 10 SNMP communities to be configured on the SNMP settings page.
- **Set community string**: The community string used when setting values on the device. The default value is *private*. The device allows 10 SNMP communities to be configured on the SNMP settings page.

## Usage

### General

This page provides an overview of the general system information and status. It also allows you to perform a system reboot and change network settings.

The following subpages are available:

- **Network / Control**: Allows you to configure the CTRL1 and CTRL2 network interfaces and view their status.
- **Network / Data**: Allows you to configure the DATA1 and DATA2 network interfaces and view their status.
- **Network / SNMP**: Allows you to configure and consult the SNMP settings (ports, community string, and traps).
- **Network / Syslog**: Allows you to configure and consult the syslog target server settings.
- **Network / Monitoring**: Allows you to configure and consult the monitoring target server settings.
- **Miscellaneous**: Allows you to configure and consult buzzer volume, ID format, front panel, date and time and NTP settings
- **Event Log**: Allows you to configure and consult the event log level customization settings.

### Alarms

This page provides a list of the current alarms. It also allows you to clear this list in the device.

### Input

This page allows you to configure the IP stream settings of the device. The input stream can be selected and the common stream settings can be configured.

The following subpages are available:

- **Input Stream / Primary**: Allows you to configure the settings of the first IP stream.
- **Input Stream / Secondary**: Allows you to configure the settings of the second IP stream.
- **Input Stream / Status**: Displays the status of the two IP streams and the IP receiver decoding information.

### Decoder

This page allows you to configure the decode settings of the device. The program number and packet identifiers of the transport stream can be configured. It is also possible to change the video, audio and genlock decode settings and the audio mapping.

The following subpages are available:

- **Program Status**: Provides an overview of the status info of the decoded stream, as well as a list of the available programs the stream.
- **TS Stream PID / ID Status**: Provides a status overview of the packet identifiers in use by the different output types.
- **TS Stream PID / Audio**: Allows you to configure the packet identifiers for each of the eight audio streams.
- **TS Stream PID /** **Ancillary**: Allows you to configure the packet identifiers for each of the four ancillary streams.
- **TS Stream Status /** **Video**: Displays the status information of the video stream.
- **TS Stream Status /** **Audio**: Displays the status information of each audio stream.
- **TS Stream Status /** **Ancillary**: Displays the status information of each ancillary stream.
- **Audio Settings**: Allows you to change audio delay settings per audio stream.
- **Audio Mapping**: Allows you to map the audio stream channels to the embedded SDI audio channels.

### Output Video

This page displays the current SDI output status and allows you to configure the video main and SDI level output settings.

### Output Audio

This page allows you to configure the audio output gain settings.

### Presets

This page allows you to load, save, protect and delete configuration presets. A list of up to 64 presets can be maintained. The current preset is shown. A startup preset can be selected and the default preset can be loaded.

### Web Interface

On this page, you can consult and manage the device through its web interface. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

The **1.0.1.x** connector range of the NTT Electronics HC11000D protocol supports the usage of DCF and can only be used on a DMA with **8.5.8.5** as the minimum version. DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **Data 1**: Interface of type **in** based on *Network Data 1 Link Status*
- **Data 2**: Interface of type **in** based on *Network Data 2 Link Status*
- **ASI**: Interface of type **in** based on *Input Signal ASI Status*
- **SDI A**: Interface of type **out** based on *Video Output SDI Signal Status*
- **SDI B**: Interface of type **out** based on *Video Output SDI Signal Status*
- **SDI** **C**: Interface of type **out** based on *Video Output SDI Signal Status*
- **SDI D**: Interface of type **out** based on *Video Output SDI Signal Status*
- **ASI Output**: Interface of type **out**.

### Connections

#### Internal Connections

- Between Data 1 and SDI A, SDI B, SDI C, SDI D & ASI Output
- Between Data 2 and SDI A, SDI B, SDI C, SDI D & ASI Output
- Between ASI and SDI A, SDI B, SDI C, SDI D & ASI Output
