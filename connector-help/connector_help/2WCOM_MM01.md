---
uid: Connector_help_2WCOM_MM01
---

# 2WCOM MM01

This connector monitors the 2WCOM MM01, a **Codec** device, using **SNMP**.

## About

### Ranges of the connector

| **Range**              | **Description**                                                 |
|------------------------|-----------------------------------------------------------------|
| 1.0.0.x                | Initial version.                                                |
| 1.1.0.x \[Obsolete\]   | Support for CSRF Token.                                         |
| 1.1.1.x \[Main range\] | Based on 1.1.0.8. Changed default communication type to SNMPv2. |

### Product Info

| **Range**              | **Device Firmware Version**                                                            |
|------------------------|----------------------------------------------------------------------------------------|
| 1.0.0.x                | 2.6.37-2wcom (kernel release) / 1.30 (MM01 version)                                    |
| 1.1.0.x \[Obsolete\]   | 2.6.37-2wcom_ACIP (kernel release) / 185 (MM01 version) / 2.80 (web interface version) |
| 1.1.1.x \[Main range\] | 2.6.37-2wcom_ACIP (kernel release) / 185 (MM01 version) / 2.80 (web interface version) |

## Configuration

### Connections

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host:** The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

#### HTTP connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

## Usage

### Overview

This page contains information regarding the status of the device, such as the **Uptime**, **Temperature**, **Temperature Alarm Status**, **Internal Storage Alarm Status** and **SFN Clock Alarm Status**.

It displays the **Input** and **Output Audio Levels (AES/EBU, Analog, Digital)** and the **Decoder Silence Detection** as analog graphs. It also contains the **Decoder Status Table**.

The page also allows you to change the settings for **System Name**, **Location** and **Description**.

### Decoder Settings

This page contains information about the decoder, such as the **Output Audio Levels** analog graphs, the **Decoder Current Input Source**, the **Decoder Status Table**, the **Decoder Alarm Table** and the **Decoder Silence Detection Alarms** analog graphs.

### Encoder Settings

This page consists of the **Input Audio Levels** analog graphs, **Encoder no Audio Input Alarm Status** and the **Streaming Input Data Table**.

### Tuner

This page contains tuner-related parameters, such as the **Tuner Frequency**, **Pilot**, **RF Level**, **MPX Deviation** and **Tuner Alarms**.

There is also a toggle button that can be used to **enable or disable the polling** of the tuner parameters.

### Network Settings

This page displays the **LAN Table**.

### System Settings

On this page, you can change settings for the **System Description**, **Name** and **Location**. The page also displays system information, such as the **Serial Number**, **Device Type**, **Kernel Release**, **MM01 Version**, **ACIP Version**, **FPGA Version** and **MIB Version**.

The page also contains 3 page buttons:

- **Login**: In order to change the system settings parameters or to upload a configuration or firmware file, user **credentials** must be entered here.
- **Settings**: On this page, you can save the current device configuration or upload a previously saved configuration file.
- **Firmware** **Upload**: On this page, you can upload a firmware file to the device.

### Status

This page displays the **Internal Storage Alarm Status** and the **PSU Table.**

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
