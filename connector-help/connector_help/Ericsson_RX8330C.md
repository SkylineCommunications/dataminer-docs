---
uid: Connector_help_Ericsson_RX8330C
---

# Ericsson RX8330C

This is an **HTTP** connector that is used to retrieve status information from the **Ericsson RX8330C** device. The RX8330C is based on the existing RX8330 Integrator Receiver Decoders (IRD) and supports the embedded Conax Conditional Access system.

## About

This connector retrieves the information on tables and parameters by HTTP polling. However, to make this possible, you must specify the necessary credentials (username and password) on the **General** page.

The connector also contains an **overview of the active alarms, modules, CA Service Status** and **CA Subscription Status**.

The connector requires at least **.NET 4.0**.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 10.0.0                      |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses a HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Device address**: The device address. (Default: *ByPassProxy*)

## Usage

### General

This page displays all the parameters related to **Device Info**, including:

- The overall status (**Product Name**, **Current Time**, **Uptime** and **Front Panel Lockout**)
- The **Build** (including the **SW Version**, **PS Version** and **Hardware ID**)
- The **Environment** (e.g. Temperature and Fan Speeds)
- The **Network Settings**, including the MAC Addresses and Link Status.

It also contains two page buttons:

- **Login**: Opens a page where you can specify the login credentials, i.e. the username and password.
- **Modules**: Displays the Modules table.

### Status

This page displays parameters related to **Device Info**, **Input Status**, **Video Status**, **Audio 1 Status**, **Audio 2 Status**, **Audio 2 Status**, **CA Status** and **Mode.**

There is also a page button that allows access to the **Alarm Status** table.

### Alarm Configuration

This page displays the alarm configuration (disabled/enabled) for **Input** **Alarms**, **Environment Alarms** and **Service Alarms**.

### Customization

This page displays the **Serial Number** and **Model Type** parameters, as well as the **Licensed Features** table.

### Conditional Access

This page displays the **CA Status** parameter, as well as the **CA Service Status** and **CA Subscription Status** tables.

### Input

This page displays the input parameters (e.g. **Current Input**, **TS Lock** and **Packet Length**) and **Satellite Input** parameters.

There are also four page buttons (**Configuration RF1 - 4**) that open subpages with the current RF configuration.

### Decode - Service

This page displays the overall decode service parameters (e.g. **Service**, **Current SI Mode** and **TS ID**).

It also contains a number of page buttons:

- **Advanced**: Displays advanced information such as the **Selection Control**, **Service**, **Video**, **Audio#1** and **Audio#2**.
- **VBI-VANC**: Displays parameters related to **VBI**, **Closed Captions**, **AMOL-48 and AMOL-96**, **TVG**, **VPS**, **WSS**, **ITS**, **Monochrome**, **Brandnet**, **VITC** and **NTSC Pedestral**.
- **Splice**: Displays parameters such as **Splice PID**, **Splice Status** (with the **Splice Status - Remaining Time**, **Splice Status - Expected Time** and **Splice Status - Pending Time**) and **Splice Count**.
- **DVB Subtitles**: Displays parameters related to both **DVB-Subtitles** and **User DVB-Subtitles**.
- **Teletext**: Displays Teletext-related parameters, such as **Teletext PID**, **Stream Status** or **Teletext Insertion**.

### Decode - Video

This page displays the decode video parameters, such as **Status**, **Video Standard** or **Bit Rate**.

### Decode - Audio

This page displays the general **Channel Configuration Status** parameter, as well as several specific parameters related to both Audio 1 and Audio 2.

There is also a page button, **Audio Routing**, which displays parameters related to **Audio Connectors** and **SDI Embedding**.

### Presets

This page displays all the preset status parameters (1-40).

### Web Interface

This page displays the webpage of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
