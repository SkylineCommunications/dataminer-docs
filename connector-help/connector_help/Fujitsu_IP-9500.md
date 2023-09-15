---
uid: Connector_help_Fujitsu_IP-9500
---

# Fujitsu IP-9500

The Fujitsu IP-9500 connector has been designed to monitor IP-9500 high-performance encoder/decoder devices. The Fujitsu IP-9500 is an audio/video codec that utilizes advanced MPEG-4 AVC (H.264) encoding to perform real-time transmission of HDTV at low bit rates over DVB and broadband IP networks.

## About

Applying the latest MPEG-4 AVC (H.264) video processing algorithms, IP-9500D can provide best-in-class video fidelity for an application in Electronic News Gathering (ENG) as well as broadcast contribution and distribution networks. Compared with MPEG-2 encoding, the streaming bit rate is reduced by more than half. By utilizing sophisticated MPEG-4 AVC (H.264) compressing algorithms, the high video fidelity remains to be implemented. As a result, HDTV content can be transmitted at narrow bandwidths over existing DVB satellite or low-cost broadband IP networks.

IP-9500D utilizes auto-sensing 10T/100T/1G Ethernet for IP connectivity as well as ASI I/O ports for connecting to DVB networks. IP-9500D also provides industry standard HD-SDI (SD-SDI) and HDMI I/Os for connecting to HDTV (SDTV). Operating with an IP-9500 encoder, IP-9500D is mainly utilized for delay-sensitive ENG applications. A bidirectional voice intercom's capability is provided across broadband networks for interactive communication among remote HQ and local branches.

This connector displays information on different pages, as described in the **Usage** section of this document.

The connector manages independent counters, and a reset button is available to clear the content of these values as well as the internal counters of the web page of the device.

From version 1.0.0.2, the **DataMiner Connectivity Framework** has been implemented in the connector.

### Version Info

| **Range**     | **Description**  | **DCF Implementation** | **Cassandra Complaint** |
|----------------------|------------------|------------------------|-------------------------|
| 1.0.0.x              | Initial version  | Yes                    | Yes                     |
| 1.0.1.x \[SLC Main\] | Based on 1.0.0.3 | Yes                    | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.0                         |
| 1.0.1.x          | 1.0                         |

### Timing

The data is retrieved using multiple timers with polling intervals of 30 seconds, 5 minutes and 1 hour.

## Installation and Configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string needed to read from the device.
- **Set community string**: The community string needed to set to the device.

## Usage

### System Overview

This page displays a general overview of the system status, software management and system control.

The following subpages are available:

- **System Settings:** Allows you to manage the system configuration and system common settings.
- **Time Settings:** Allows you to manage the system date/time settings and time server settings (SNTP).

### Ports Overview

This page displays information related to the data port and USB.

The following subpages are available:

- **Intercom Settings:** Allows you to manage the intercom settings. This includes the possibility to enable or disable the intercom service.
- **Data Port Settings:** Allows you to manage the Ethernet and serial RS232 port settings. This includes the possibility to enable or disable the data port service.

### Encoder Overview

This page displays the actual state of encoder 1 and 2, encoder DVB-ASI and encoder DVB-SS.

### Encoder Management

This page displays the encoder status values and general control management.

The following subpages are available:

- **Encoder Video Input:** Allows you to manage the encoder video input settings.

- **Encoder Audio Input:** Allows you to manage the encoder audio input settings.

- **Main Encoder:** Allows you to manage settings related to the main encoder IP, main encoder IP port and main encoder PIDs.

- **Main Encode:** Allows you to manage the common main encoder encoding, ANC and BISS encoding configuration.

- **Sub Encoder:** Allows you to manage settings related to the sub encoder IP, sub encoder IP port and sub encoder PIDs.

- **Sub Encode:** Allows you to manage the common sub encoder encoding and ANC encoding configuration.

- **Encoder DVB Settings:** Allows you to manage settings related to the DVB-ASI and DVB-SS2 configuration.

### Decoder Overview

This page displays general information on the decoder.

### Decoder Management

This page displays the decoder status values and PID control management.

The following subpages are available:

- **Decoder Settings:** Allows you to manage the configuration for Decoder Control, Decoder Reference Settings, Decoder BISS, Decoder IP and Decoder IP Port.
- **Decoder Video Output:** Allows you to manage settings related to the decoder video output.
- **Decoder Audio Output:** Allows you to manage settings related to the decoder audio output and the decoder decoding.

### Record Management

This page displays the recorder status values and allows you to manage Recorder Control and Recorder Settings.

### Device Web Page

This page provides access to the device web portal. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

The version **1.0.0.2** of the Fujitsu IP-9500 supports the usage of DCF and can be only on a DMA with **8.5.7** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed Interfaces

Physical fixed interfaces:

- **ASI DECODER IN:** Physical ASI interface of type **in**.
- **ASI ENCODER OUT:** Physical ASI interface of type **out**.
- **IP DECODER IN:** Physical IP interface of type **in**.
- **IP MAIN ENCODER OUT:** Physical IP interface of type **out**.
- **IP SUB ENCODER OUT:** Physical IP interface of type **out**.
- **SDI DECODER OUT:** Physical SDI interface of type **out**.
- **SDI ENCODER IN:** Physical SDI interface of type **in**.

### Connections

#### Internal Connections

The connections are made based on the following conditions:

If the **Decoder** is enabled:

- **Decoder Input** is type **IP**: **IP DECODER IN (ID:2)** --\> **SDI DECODER OUT (ID:3)**
- **Decoder Input** is type **ASI**: **ASI DECODER IN (ID:1)** --\> **SDI DECODER OUT (ID:3)**

If the **Main** **Encoder** is enabled:

- **Encoder Output** is type **IP**: **SDI ENCODER IN (ID:11)** -- \> **IP MAIN ENCODER OUT (ID:13)**
- **Encoder Output** is type **ASI**: **SDI ENCODER IN (ID:11) -- \> ASI ENCODER OUT (ID:12)**

If the **Sub Encoder** is enabled:

- **SDI ENCODER IN (ID:11)** -- \> **IP SUB ENCODER OUT (ID:14)**
