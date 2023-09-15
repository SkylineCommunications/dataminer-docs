---
uid: Connector_help_Snell_Wilcox_MC2000_Controller
---

# Snell Wilcox MC2000 Controller

The **Snell Wilcox MC2000 Controller** is a 1U motion-compensated frame rate and format converter. The Snell Wilcox KudosPro connector should be used along with this connector (for the controller) to provide full parameter and feature monitoring and control.

## About

This connector allows you to manage a Snell Wilcox MC2000 Controller using a **serial** connection (Snell RollCall is used as the underlying communication protocol).

### Version Info

| **Range** | **Description** |
|------------------|-----------------|
| 1.0.0.x          | Initial version |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.2A.10                     |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device (e.g. *172.16.61.11*).
- **IP port**: The IP port of the device (e.g. *2050*).
- **Bus address**: Used to fill in the Unit Address and the Unit Port (e.g. *26.02* is for Unit Address 0x26 and Unit Port 0x02).

## Usage

### General Page

This page contains the **Display**.

### Connection Info Page

This page contains information about the RollCall connection, e.g. **SessionStatus**, **Assigned Session Nr**., **Simulated RollCall Response**, **Card User Name**, **Unit Address**, **Unit Port** and **Local Session Nr**.

### Genlock Page

This page provides controls (**Source Ch1, Source Ch2, Current Reference Standard**) that lock the output video clock to the genlock source (input or reference) regardless of the video standard.

### Audio Routing Page

This page contains the audio routing parameters **AES 1 - AES4**, **Group 1** and **Group 2**.

### CVBS Page

This page displays the configuration parameters for decoder A and B (e.g. **CVBS Decoder A: Source**, **NTSC Hue**, **Pedestal**, **ACC**, **CTI**) and encoder C and D (e.g. **CVBS Encoder C: Source**, **Format**).

### Dolby Page

This page enables you to set up the way the unit handles Dolby audio. It contains the Dolby configuration parameters for channel 1 and channel 2 (e.g. **Decoder Source**, **Metadata Source**, **Input Status**, **Decoder Rate**, etc.).

### Network Page

This page provides access to the unit's network details and setup (e.g. **IP Configuration Status**, **Current IP Address**, **Gateway**, **Netmask**, etc.).

### SNMP Page

This page contains the SNMP settings (e.g. **Read Community**, **Write Community**, **sysContact**, **sysName**, **sysLocation**) and configuration parameters for SNMP traps.

### Front Panel Page

This page enables you to customize some front panel features for ease of use (e.g. the **Brightness** of the LCD display).

### Memories Page

On this page, you can select a memory (**Memory Select**), set its name (**Change Name**), and see the defined memory names, among others.

### Logging Page

On this page, you can enable general logging and view the logged information: **Serial Number**, **Uptime**, etc.

### Status Page

This page provides an overview of the status of the device (e.g. **Software Version**, **Dolby Ch1**, **PSU A**, **Module 1 Temperature**).

### CVBS Calibration Page

This page contains parameters for the CVBS Decoder A and B Calibration (e.g. **CVBS Decoder A: Luma Gain**) and the CVBS Encoder C Calibration (e.g. **CVBS Encoder C Calibration: DAC Gain**).

### Web Interface Page

This page provides access to the original web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
