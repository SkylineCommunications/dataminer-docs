---
uid: Connector_help_Teracue_Encoder_ENC-300
---

# Teracue ENC-300

The ENC-300 encoder is designed for IPTV and live streaming.

## About

The Teracue ENC-300 connector is used to monitor and control a Teracue ENC-300 device. The information is spread over different pages to resemble the web interface of the device as much as possible.

## Installation and configuration

### Creation

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not used.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### Overview Page

The **General** page displays general information about the device.

### Setting page

The **Encoder** page displays the encoder settings. The user can modify some of these values.

### Video page

On this page, the settings for video can be viewed and modified as preferred.

### Audio page

On the **Audio** page, the settings for audio can be viewed and modified as preferred.

### Output page

On the **Output** page, the **Transport Protocol** and the **FEC** parameters can be viewed and modified. Below them, the **Destination Table** is displayed.

### GPIO page

On this page, the **GPO** **Value** can be viewed and set, and the **GPI** **Value** can be viewed.

### Webpage

This page displays the webpage of the device.
