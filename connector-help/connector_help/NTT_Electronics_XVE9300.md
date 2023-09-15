---
uid: Connector_help_NTT_Electronics_XVE9300
---

# NTT Electronics XVE9300

XVE9300 is a Full-HD-3D transmittable AVC/H.264 Encoder, which inherits its high image quality and performance from the HV9100 series

## About

The NTT Electronics XVE9300 connector is able to monitor and control an XVE9300 device. The information is divided over different pages (General, Video, Audio and Alarms). On the Video and Audio page, the settings can be modified.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not used.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General page

The **General** page displays some general parameters of the device.

### Audio page

The **Audio** page displays different parameters regarding the audio. These parameters can also be modified.

There are also several page buttons available that will take the user to different pop-up pages where additional settings can be done.

### Video page

On this page, the settings for the video can be modified.

### Alarms page

The **Alarm** page displays a table with alarm information. Below the table, information is displayed regarding the traps.
