---
uid: Connector_help_Cisco_D9094
---

# Cisco D9094

This device has the ability to stream and decode HD/SD AVC video streams for TV. It does so at lower bit rates, while being able to maintain a 4:2:2 chroma, over DVB and broadband IP networks. It also has support for DVB-S/S2 satellite communication.

This driver allows you to retrieve information from Cisco's D9094 platform. You can monitor alarms and statistical information, and configure/activate the encoding, decoding and recording of video streams. The driver retrieves and sets information on the device via SNMP.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public.*
- **Set community string**: The community string used when setting values from the device, by default *private.*

## How to Use

The element consists of the data pages detailed below.

### General

Contains generic machine information/configuration, such as the **unit information** (name, software version, etc.), the **provided services**, the **system status** and the **ports** and **data** information.

### Management

Contains the more advanced unit configuration, not directly related to the encoding/decoding. Also contains settings for identification, time, and network access (LAN, HTTP, SNMP, PPPoE, Data Ports, Serial, Intercom, Console). You can also find the **logging page** in here.

### Encoders

Contains the entry point for several of the encoder's information and configuration. The **status** and **interfaces** can be found here. You can also **start and stop** the encoder. Reports can be configured here as well.

Several subpages are available:

- **DVB Settings**: Contains the configuration for both the ASI and S/S2 parts of the Digital Video Broadcasting encoding.
- **IP Settings**: Contains the configuration for the **main** and **sub** encoder's IP stream settings, including several protocol options, and the destination IP address and ports.
- **Inputs**: Contains the options for the encoder's **video** and **audio** input.
- **Statistics**: Contains the statistical information regarding the number of packets received or lost by the encoder.
- **PID**: Contains the process IDs for the main and sub encoders, including their stream, network, service and video/audio IDs.
- **BISS**: Contains the configuration for the satellite signal scrambling system (Basic Interoperable Scrambling System).
- **ANC Data**: Contains the auxiliary data configuration, both for the main and sub encoder.
- **Encoding**: Contains the core configuration for the base encoding process, including several rates, the video resolution, and the detailed audio configuration.

### Decoders

Much like the encoder page, this page works as an entry point for the controls of the decoding process of the unit. It contains **status** information for the decoder and current configuration, allows you to **start** or **stop** the decoding process, and lists the various **process IDs**.

Several subpages are available:

- **IP Settings**: Contains the configuration for the decoder's IP stream settings, including the streaming mode, several protocol options, and the destination IP address and ports.
- **Inputs**: Contains the options for the decoder's **video** and **audio** input.
- **Statistics**: Contains statistical information regarding the number of packets received or lost by the decoder.
- **PID**: Contains the process IDs for the decoder, including the service and video/audio IDs.
- **BISS**: Contains the configuration for the satellite signal scrambling system (Basic Interoperable Scrambling System).
- **Decoding**: Contains the State, Error Concealment and Passthrough options for the decoding process.

### Recorder

This page allows control over the recording section of the Cisco unit, allowing you to see whether that unit is **equipped or not** and to **start/stop** the recording process.
