---
uid: Connector_help_Ericsson_TT1222
---

# Ericsson TT1222

This is an HTTP connector that is used to retrieve status information from the Ericsson TT1222, an integrator receiver decoder (IRD) device.

## About

The information on tables and parameters is retrieved via HTTP polling.

This connector contains an overview of the **active alarms**, **modules**, **Service System**, **Service TV** (which includes TV Service, Video and Audio 1), **Service Audio 2** and **Output Status**.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.0                         |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Device address**: The device address, by default *ByPassProxy*.

## Usage

### General

This page displays general information about the device, such as the **Device Info**, **IP Address**, **Current Status**, **Current Time**, **Input Status**, **Video Status**, **Audio 1 Status** and **Audio 2 Status**.

### Alarms

This page displays the **Alarms** Table.

### Device Info

This page displays all the parameters related to **Product Information** (**Name**, **Product Name** and **Product Version**) and **Alarm Information**.

In the Product Information section, three page buttons display the **Network Settings**, the **Modules** table and the **Remote Configuration**.

In the Alarm Information section, two page buttons display the **Alarm Filters** and **Alarm Types** tables.

### Presets

This page displays preset selection and saved preset information.

### Input

This page displays the parameters related to **TS Input Status**, **RF Input Status** and **RF Input Control**.

### Service - System

This page displays the **PSI Mode**, **System Delay**, **Data Parameters** and **Data Port Settings**.

### Service - TV

This page displays the **TV service ID**, as well as **Video** and **Audio 1** related parameters.

It also includes the page buttons **Teletext - Subtitles**, **DVB - Subtitles**, **TV Service PIDs**, **Service Cycling**, **Video Advanced** and **Audio 1 Advanced**.

### Service - Audio 2

This page contains parameters related to Audio 2. More advanced parameters are available via the page button **Audio 2 Advanced**.

### Conditional Access

This page contains CA-related parameters.

### Output

This page displays parameters related to the output streaming.

The **GPO** or **General Purposes Output** page button displays the triggering information coming from events **No Input Lock**, **Video Error**, **Audio 1 Error**, **Audio 2 Error**, **Data Error** and **BER Exceeded**.

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
