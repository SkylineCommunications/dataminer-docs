---
uid: Connector_help_JVC_PTZ_Camcorder
---

# JVC PTZ Camcorder

JVC PTZ Camrecorder KY-PZ100 is a robotic pan, tilt and zoom video production camera, it can be used as a single camera or part of a multi-camera shoot. In addition to its 3G-SDI and HDMI outputs, it is also capable of reliably streaming 1080i/60, 1080p, 720p, and 360p video with 2-channel audio-all.
The **JVC PTZ Camrecorder** connector can be used to display and configure information related to this device.

## About

This connector allows you to access various information on the device. Data is retrieved using HTTP. There are different possibilities available for alarm monitoring and trending.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | V0102-0103                  |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses a HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.

## Usage

### General

In this page it is possible to set the **Username** and **P**a**ssword** for retrieving the camera data. Also **S**ystem** Model**, **Destination** and **API version** is available in this page.

### Status

This page displays information related to the main camera operations:

- **Pan/Tilt: Pan** and **Tilt** parameters will move the camera with a configurable **Speed.**
- **Zoom:** Manual zoom can be configured using **Zoom Position;** or **Tele** and **Wide** buttons can be used as well for **Zoom In** and **Zoom Out**
- **Focus:** Can be set to **Auto** or manual using the **Far** and **Near** buttons.
- **Streaming: Resolution** and **Bit Rate** can be configured for streaming the image.

### Camera

In this page it is possible to configure some camera settings depending on the **Exposure Status** value:

- If it is set to **Auto**, **Automatic Exposure (AE) Level** can be configured.
- If it is set to **Shutter**, **AE Level** and **Shutter** can be configured.
- If it is set to **Iris**, **AE Level** and **Iris** can be configured.
- If it is set to **Manual**, **Iris**, **Gain** and **Shutter** can be configured.

It is also possible to configure the **White Balance**. When it is set to **AWB** or **Manual**, **Red** and **Blue** values can be configured.

### Server

In this page it is possible to configure the **Live Streaming Server**. When configuring the **Server Settings**, note that some parameters are mandatory to be filled in depending on the server **Type**:

- **UDP**: **Address** and **Port** must be filled in.
- **Zixi**: **Address**, **Port**, **Stream ID**, **Password**, **Latency** and **Adaptive Bitrate** must be filled in.
- **RTP**: **Adddress**, **Port**, **SNMPTE 2022-1 FEC**, **FEC Matrix L** and **FEC Matrix R** must be filled in.
- **RTMP**: **URL** and **Stream** **Key** must be filled in.
- **RTSP**: **Password** must be filled in.
