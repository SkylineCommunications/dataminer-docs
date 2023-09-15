---
uid: Connector_help_Fujitsu_IP-920
---

# Fujitsu IP-920

The **Fujitsu IP-920** connector has been designed to monitor IP-920D HD/SD compact video decoder or IP-920E HD/SD compact video encoder devices. The IP-920 is an audio/video codec that utilizes advanced MPEG-4 AVC (H.264) encoding to perform real-time transmission of SDTV and HDTV at low bit rates over IP network.

## About

By utilizing sophisticated MPEG-4 AVC (H.264) compression algorithms, the streaming bit rates are reduced more than half compared to MPEG-2 encoding while achieving the same video fidelity. HDTV contents can be transmitted over existing enterprise IP networks. Robust error correction ensures high fidelity service over IP networks by preventing the distortion of decoded video, even when network packet losses occur. IP-920 reduces the transmission cost for communication among remote locations that demand SDTV and HDTV video fidelity with the compact size and rugged construction.

The IP-920 has an analog video (NTSC/PAL) interface. The existing CCTV camera can reduce your beginning investment for your system. When the camera is replaced to HD camera, you can easily add the HD option software to the IP-920. Utilizing the optional 16GB internal storage function, the IP-920 can also be used for file transmissions across IP networks. Encoded video can be recorded in the encoder and remotely downloaded. Therefore, the video data can be transferred even when network bandwidth is too narrow to support real-time transmission.

An enhanced IP-920 can stream video more smoothly by supporting Ultra low latency of approx. 99ms. These new feature is especially useful for decoding video from remote site. (e.g. Video transmission among different countries, broadcasters and global companies) The new feature enables to decode video seamlessly and simultaneously and the operator in decoding site would not have to feel any stresses for waiting the process.

The information displayed in this connector is delivered in different pages and are described in the **Usage** section of this document.

The connector manages independent counters, and a reset button is available to clear the content of these values as well as the internal counters of web page device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.0                         |

## Installation and Timing

### Creation

This connector uses a Simple Network Management Protocol (**SNMP**) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string needed to read from the device.
- **Set community string**: The community string needed to set to the device.

### Timing

The data is retrieved using multiple timers having polling intervals of 30 seconds, 1 minute, 5 minutes, 12 hours.

## Usage

The **connector** contains different pages divided into different sections using separators.

### System Overview

The System Overview Page displays a general overview on system status, system management, system control.

- **System Settings:** Displays the management of the actual information for System Configuration Settings and System Common Settings.
- **Time Settings:** Displays the management of the actual information for System Date/Time Settings and Time Server Settings (SNTP).

### Ports Overview

The Ports Overview Page displays a general overview relative to the Data Port and Usb .

- **USB Settings:** Displays the management and configuration for Usb Settings, allow to enable/disable the usb service.
- **Data Port Settings:** Displays the management and configuration for Ethernet and Serial RS232 Port Settings, allowing the user to enable/disable the data port service.

### Encoder Overview

The Encoder Overview Page displays the actual state of encoder 1 and 2, and handles internal counters for ARQ Packets. On the left, in the **Decode Information** box the user can find the raw data polled from the device. On the right, there is the **Internal Counters** box, with internal counters that are updated on every poll cycle, but can be reset by the **Reset Counters**. These vales are local. Below, there is a box **Rate Calculation**. It keeps track of the packets that are lost and recovered and the decode errors, since the last poll. This is than used to calculate rates. As these params are normally polled every 5 seconds, these rates are recalculated (and thus overwritten) every 5 seconds. If you enable trending on these params via a Trend Template, a history of this rates can be stored in the DataMiner Database.

#### Encoder Management

The Encoder Management Page displays the encoder status values and general control management.

- **Encoder Video Input:** Displays the encoder video input general management.

- **Encoder Audio Input:** Displays the encoder audio input general management.

- **Main Encoder:** Displays the configuration and allows the management relative to main encoder IP, main encoder IP Port and main encoder PIDs.

  - **Main Encode:** Displays information and allows the management for Common Main Encoder Encode, SD and HD Encoding configuration.
  - **Main Superimpose:** Displays information and allows the management for Main Encoder Superimpose Encoding configuration.

- **Sub Encoder:** Displays the configuration and allows the management relative to sub encoder IP, sub encoder IP Port and sub encoder PIDs.

  - **Sub Encode:** Displays information and allows the management for Common Sub Encoder Encode, SD and HD Encoding configuration.
  - **Sub Superimpose:** Displays information and allows the management for Sub Encoder Superimpose Encoding configuration.

### Decoder Overview

The Decoder Overview Page displays decoder general information, and handles internal counters, the page has a Reset button that clears the internal counters as well as the device web page internal counters.

### Decoder Management

The Decoder Management Page displays the decoder status values and PID control management.

- **Decoder Settings:** Displays the configuration and allows the management for Decoder Control, Decoder Reference Settings, Decoder IP, Decoder IP Port.
- **Decoder Video Output:** Displays the configuration and allows the management for Decoder Video Ouput.
- **Decoder Audio Output:** Displays the configuration and allows the management for Decoder Audio Output.

### Record Management

The Record Management Page displays the recorder status values and Recorder Control and Settings management.

### Device Web Page

The Device Web Page gives access to the device web portal.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
