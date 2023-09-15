---
uid: Connector_help_NTT_Electronics_HC11000E
---

# NTT Electronics HC11000E

This connector allows the user to monitor and control HC11000E devices.

This device uses a single-chip HEVC encoder LSI and supports 4K/60p 4:2:2 10-bit.

## About

With this connector, it is possible to monitor the hardware and performance status of an HC11000E device and to change the configuration of some of its parameters. The connector uses a **SNMP connection** to retrieve data from the device and to set parameters on it.

### Version Info

| **Range** | **Description**                      | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                      | No                  | Yes                     |
| 1.1.0.x          | Support for firmware version RC3.B.1 | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Ver.00.24.0002              |
| 1.1.0.x          | RC3.B.1                     |

## Installation and configuration

SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, *e.g. 10.10.250.250*.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays **System Information**, such as the System Name and Version **Alarm** **Status** information, such as Alarm Error and Alarm Warning, and **Device Status** information, such as the device Temperatures, Fan Status, etc.

### Alarms

This page displays the **Alarm Table**, which lists the active alarms of the device.

### Status

This page displays detailed information regarding the device network, input signal and encoding status.

The page contains page buttons to the following subpages:

- **Network Status 1** and **Network Status 2:** These subpages display parameters related to the network interfaces.
- **Input Status**: Displays parameters related to the input signal for this device (SDI 1, SDI 2, SDI 3 and SDI 4).
- **IP Status**: Displays parameters regarding **TX 1** and **TX 2** metrics (Bitrate, Count Resend Packet, Delay Time, etc.).
- **Encode Status**: Displays parameters related to the Video Encoder Status and Audio Encoder Status.
- **Ancillary Status:** Display parameters related to the ancillary status.

### Configuration - Input

On this page, you can navigate to the configuration parameters of **Video Input** (4K Division, Black Screen HDSDIA and Test Signal HDSDIA) and **Audio Input** - **Test Signal** and **Gain** parameters.

### Configuration - Output

This page allows you to configure parameters related to the **Output** of the device (ASI Format) and to the **Output IP** (Data MPEG2 TS Format, Packet Density, Copy Cast and Output IP Data Table).

### Configuration - Encode

This page contains encode configuration parameters (Stream Mode and Stream MMTFS) and allows you to navigate to **Encode Stream**, **Encode BISS**, **Encode Ancillary**, **Encode Video** and **Encode Audio** parameters via page buttons:

- **TS Ancillary:** Displays the Encode Stream Ancillary Table.
- **TS1**: Displays the Stream TS Table.
- **TS** **Program:** Displays the Stream Program Table.
- **TS Audio:** Displays the Stream Audio Table.
- **BISS:** Displays the BISS Encode Table.
- **Ancillary**: Displays the Encode Ancillary Table, User Selection 1 Table and User Selection 2 Table.
- **Audio:** Displays the Encode Audio Table, Encode Audio AAC Table, Audio Mapping Table and Audio SMPTE302M Table, as well as the Audio Mapping Mode and Audio ARIB B39 parameters.
- **Video:** Displays the Video Format, Latency, Aspect Ratio and Encode Video Table.

### Preset

This page displays parameters related to presets, such as **Active Preset** and **Startup Preset**, as well as the **Preset Table**, where you can configure the different available presets.

### Network

This page allows you to configure the **Network Host Name** and the **Network 1** and **Network 2** ports.

There are several page buttons available, which allow you to configure:

- The **Network Web UI** port.
- The **Network SNMP** ports, community strings and SNMP traps
- **Network Syslog** IP parameters
- **Network Monitoring** target parameters
- **Network Data Table** parameters, such as DHCP, IPv4/IPv6 addresses, subnet masks, Gateway, etc.

### Event Log

On this page, the **Event Customize Table** allows you to configure a particular level for each specific event ID.

### Miscellaneous

On this page, several other parameters can be configured: **Buzzer Volume**, **Front Panel Customize** and **User Text**, **NTP Server Name**, **Time Zone**, **Time Sync**, **Date** and **Time**, etc.

There are also three action buttons to **Clear Alarms** and **Reboot System** and **Clear Packet Counter.**

### Web Interface

This page contains the web interface for the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
