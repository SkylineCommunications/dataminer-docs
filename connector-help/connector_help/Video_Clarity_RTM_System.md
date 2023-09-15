---
uid: Connector_help_Video_Clarity_RTM_System
---

# Video Clarity RTM System

The **Video Clarity Real Time Monitoring System** is a full reference broadcast quality monitor that allows the measurement of audio and video quality and delay, as well as program loudness and VANC integrity.

## About

This is an **SNMP**-based connector for the Video Clarity Real Time Monitoring System.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | \-                          |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

### General

On this page, you can connect to the RTM system, as well as clear logs and record files.

The following buttons are displayed: **Clear** **Records**, **Clear** **Logs** and **Connect** **RTM**.

### Status

This page displays the configuration from the last time that the RTM system was operating. It also presents general information regarding the device itself.

The following parameters are displayed: **Start** **Time**, **Run** **Time**, **Video** **Impairments**, **Audio** **Impairments**, **Audio** **Sync** **Errors**, **VANC Errors**, **Dropped Frame 1**, **Dropped Frame 2**, **Last** **Video** **Impairment** **Time**, **Last** **Audio** **Impairment**, **Last** **Audio** **Sync** **Errors** **Time**, **Clear Status**, **Invalid Input Signal Source 1**, **Invalid Input Signal Source 2**, **Temperature System Mother Board**, **Temperature CPU**, **Temperature Video Card 1**, **Temperature Video Card 2**, **Invalid Input Signal Source 1 Error Time** and **Invalid Input Signal Source 2 Error Time**.

The parameters can be changed while the system is running.

### Control

On this page, you can start/stop the quality checking of the audio and video. Note that the preview option does not start the quality checking; it only acquires and shows the audio and video in the preview pane.

The following buttons are displayed: **Preview**, **Start**, **Stop**, **Exit** and **Reset System**.

### Alignment

On this page, you can manage a full alignment of the video and audio by means of the following parameters/buttons: **Re-Align All**, **Align** **Video**, **Align** **Audio**, **Video** **Offset**, **Audio** **Sample** **Offset**, **Audio** **Frame** **Offset**, **Audio** **Offset**, **Spatial** **X-Axis** and **Spatial Y-Axis**.

### Video and Audio

This page contains the status of the RTM Video Quality as well as the status of the RTM Audio Quality. The video and audio components are defined in terms of threshold and duration as quality measurements.

Note that the video threshold can be different for **Y**, **Cb** and **Cr.** Quality is deemed to be poor if it falls below the threshold stated here. The video duration defines how many consecutive video quality failures are needed to trigger a recording.

The **Audio** **Threshold** **Config** and **Audio** **Frame** **Config** page buttons provide access to the current audio quality score for each active audio channel.

### VANC Quality

This page contains two tables: **VANC** **Threshold** and **VANC** **Duration**. These enable VANC quality measurements on the inputs.

### PSNR

As the RTM creates average log files and error log files, three tables are available on this page: **Periodic Performance Monitoring Video**, **Periodic Performance Monitoring Audio** (available via the **PSNR** **Audio** **Metrics** page button) and **Periodic Performance Monitoring VANC Error** (available via the **PSNR** **VANC** **Metrics** page button).

## Notes

In order to communicate with this device, the programs RTMServer and RTMonitor must be running directly on the probe. The very first SNMP command after startup must be a set to rtmonConnectRTMControl with any value. The connector does this initial setting during the element startup, but a button is also available on the General Page to retry the command, in case this should be necessary.
