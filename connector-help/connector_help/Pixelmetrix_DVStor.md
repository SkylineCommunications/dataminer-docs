---
uid: Connector_help_Pixelmetrix_DVStor
---

# Pixelmetrix DVStor

The aim of this connector is to retrieve recording, playback and buffer information from a Pixelmetrix DVStor device with transport stream recording and playout capabilities.

## About

The polling information is retrieved through HTTP requests over serial commands. SNMP traps are also managed.

This topic concerns version 2.7.2.2 of the **Pixelmetrix DVStor** connector.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.244*.
- **Device address**: Not required.

**SNMP Settings:**

- **Port number:** The port of the connected device, by default *161*.
- **Get community string:** The community string used when reading values from the device, e.g. *public*.
- **Set community string:** The community string used when setting values on the device, e.g. *private*.

This connector also uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.244.*
- **IP port**: The IP port of the device, e.g. *80*.
- **Bus address**: The bus address of the device. Not required.

## Usage

### General

On this page, you can find recording information such as the **Recording Status, Source Bitrate, Source IP Port**, etc. You can start or stop recording with buttons.

Playback information is also available through the parameters **Playback Status, Playback Bitrate**, etc.

For the **Buffer**, memory usage data are displayed: **Used HDD Size, Used TS Size (%), Playback Delay**, etc.

### Recording

On this page, other recording-specific parameters are shown (**Full HDD Size, Used TS Size, ...**) and the **Recording Table** shows detailed information concerning the recorded transport streams: **Start Time, Stop Time, TS Duration, TS Size, TS Bitrate**.

### Web Interface

The client machine has to be able to access the device. If not, it will not be possible to open the web interface.
