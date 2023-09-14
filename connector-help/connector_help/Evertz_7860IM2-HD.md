---
uid: Connector_help_Evertz_7860IM2-HD
---

# Evertz 7860IM2-HD

The **7860IM2-HD** is a device for performing signal monitoring and analysis on HD/SD-SDI signals.

## About

The connector is an **SNMP** connector that can change the configuration of the device and the signals
and it monitors the incoming signals of the device. **Alarming** is enabled for the configuration parameters and for the incoming signals.

## Installation and configuration

This connector uses a Simple Network Management Protocol (**SNMP**) connection and needs following user information:

**SNMP CONNECTION**:

- **IP address/host**: the polling IP of the device eg *172.23.109.146*

**SNMP Settings**:

- **Port number**: the port of the connected device, default *161*
- **Device address:** Is the card number of the card that will be used.
- **Get community string**: the community string in order to read from the device. The default value is *public*.
- **Set community string**: the community string in order to set to the device. The default value is *private.*

## Usage

The connector is an **SNMP** connector that can change the configuration of the device and the signals

### General

Specific to the device you can see the **FPGA build number** and the **Factory Reset** allows you to reset the device to the factory settings**.**
You can control the path of the signal and can check the **GPI**, **VANC** and **Split display** parameters through the page buttons.

### Video

On the video page, there are four tables used for the configuration of the video stream.
There's a button that brings you to the **Subtitle detection page**, where you can set the configuration for the subtitles.

### Audio

This page contains the four tables that are used to configure the audio stream.

### Monitor

You can monitor the video and audio settings directly. You can get to the monitoring tables for **PSNR**,**VANC** or **VBI analyzer** trough the page buttons.

### SCTE104

This is the monitoring part for the SCTE104 parsing.

### IntelliTrak

This page contains the three tables that are used to monitor the IntelliTrak parameters.

### Notify

On this page you can set for what faults you want a trap sended, and if there are any faults for the moment.

### Faults

On this page you can set the configuration of the different faults. With the **GPO Fault Collection** button, you go to a page where you can make faults part of an collection.

### Traps

This page shows a table with information of the traps received. On the bottom of the page, you can select a parameter that removes all cleared traps every 24 hours.
