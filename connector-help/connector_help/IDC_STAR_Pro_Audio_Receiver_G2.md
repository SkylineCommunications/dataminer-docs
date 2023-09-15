---
uid: Connector_help_IDC_STAR_Pro_Audio_Receiver_G2
---

# IDC STAR Pro Audio Receiver G2

STAR Pro Audio Generation 2 (G2) is used to increase ad revenue by inserting ads for regionalized and localized campaigns, with a low cost per channel and low bandwidth usage.

STAR G2 is a DVB-S/S2 audio receiver with integrated advertisement and content playout system, which allows both live audio decoding and file playout. It is typically deployed at co-located radio stations or transmitter sites. Each audio decoder is independent of the other, allowing flexibility in data rates, codecs and sample rates: MPEG layer 2 for existing DVB compatibility or High-Efficiency Advanced Audio Coding (AAC HE) for the best audio performance at the lowest bit rate. With this device, the network can target advertising to specific locations so each receiver in the network can play unique programs and advertisements. It allows multiple radio networks to share a single 4-channel receiver (compared to each radio network deploying a standalone single-channel receiver), and features pre-emphasis and limiter functions.

## About

The **IDC STAR Pro Audio Receiver G2** connector is used to monitor and control a Star G2 device. It provides an overview of the different parameters of the device along with its statuses and generated alarms. The connector uses **SNMP** to retrieve the data from the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N7A                         |

## Installation and configuration

### Creation

#### SNMP \[Main\] connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *skyline*.
- **Set community string**: The community string used when setting values on the device, by default *skyline*.

## Usage

### General

This page allows you to manage the following general parameters of the device: **Name**, **Location**, **Serial Number**, **NCC Address** and **Device Manual Link**

### Input

This page allows you to set the inputs on the device, including the **LNB Mode** and **LNB Local Offset Frequency**, the **Preferred Carrier**, the polarization, frequency, mode, symbol rate and NCC PID for Carrier A and B, and the local port and input stream settings**.**

### DVB-TS

On this page, you can configure the PID modes, MPE PID and PID output.

### Decoder - Channel 1 to 4

On these pages, you can configure the parameters and backup configuration for each of the 4 channels.

### Output

On this page, you can set the outputs on the device with the parameters **ASI Out**, **IP Out**, **IP Out Local Port Mode**, **IP Out Local Port Address**, **IP Out Output Stream Address** and **IP Out Output Stream UDP Port**.

### Alarms

This page displays the alarms related to the satellite, audio channels, data channels and backups of the device.

### Status - Input

This page displays the status of the inputs of the device.

### Status - Decoder

This page displays status information of the decoder, including the **Decoder Transport Stream Rate**, the **Decoder Transport Stream Network**, the **PSI Audio Service Table** and the **ECG Audio Service Table**.

### Status - Channels

This page displays the status of the 4 audio channels of the device.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
