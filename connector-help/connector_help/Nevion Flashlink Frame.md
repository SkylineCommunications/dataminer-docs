---
uid: Connector_help_Nevion_Flashlink_Frame
---

# Nevion Flashlink Frame

The **Nevion Flashlink** transport system offers signal processing solutions for broadcast environments. The **Nevion Flashlink Frame** connector is the solution designed to monitor this system.

This SNMP connector is a **DVE manager** that will create a Dynamic Virtual Element for each supported module type on the frame. For each of the supported and installed card types, a child element is created. Depending on the card type, various tables are shown (with a page per table).

## About

### Version Info

| **Range** | **Description**                                                           | **DCF Integration** | **Cassandra Compliant** |
|-----------|---------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x   | Basic range.                                                              | No                  | Yes                     |
| 2.0.0.x   | Tree controls added to monitor parameters.                                | No                  | Yes                     |
| 2.0.1.x   | Audio Block status fix (ONLY for firmware 2.0.4).                         | No                  | Yes                     |
| 2.0.2.x   | Changed naming structure.                                                 | No                  | Yes                     |
| 2.0.3.x   | Added "card location" and "label" to description column (for all tables). | No                  | Yes                     |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |
| 2.0.0.x   | Unknown                |
| 2.0.1.x   | 5.0.4                  |
| 2.0.2.x   | 5.0.4                  |
| 2.0.3.x   | 5.0.4                  |

### Exported Connectors

| **Exported Connectors**                                                                                              | **Description**  |
|----------------------------------------------------------------------------------------------------------------------|------------------|
| [Nevion Flashlink Frame - GYDA](xref:Connector_help_Nevion_Flashlink_Frame_-_GYDA)                           | Flashlink Module |
| [Nevion Flashlink Frame - ETH100](xref:Connector_help_Nevion_Flashlink_Frame_-_ETH100)                       | Flashlink Module |
| [Nevion Flashlink Frame - 3G-HD-OE](xref:Connector_help_Nevion_Flashlink_Frame_-_3G-HD-OE)                   | Flashlink Module |
| [Nevion Flashlink Frame - 3G-HD-OEL](xref:Connector_help_Nevion_Flashlink_Frame_-_3G-HD-OEL)                 | Flashlink Module |
| [Nevion Flashlink Frame - 3G-HD-OE-2](xref:Connector_help_Nevion_Flashlink_Frame_-_3G-HD-OE-2)               | Flashlink Module |
| [Nevion Flashlink Frame - 3G-HD-OE-2-L](xref:Connector_help_Nevion_Flashlink_Frame_-_3G-HD-OE-2-L)           | Flashlink Module |
| [Nevion Flashlink Frame - HD-SDI-CHO](xref:Connector_help_Nevion_Flashlink_Frame_-_HD-SDI-CHO)               | Flashlink Module |
| [Nevion Flashlink Frame - SDI-CHO](xref:Connector_help_Nevion_Flashlink_Frame_-_SDI-CHO)                     | Flashlink Module |
| [Nevion Flashlink Frame - DA-SDI](xref:Connector_help_Nevion_Flashlink_Frame_-_DA-SDI)                       | Flashlink Module |
| [Nevion Flashlink Frame - DA-HD-SDI](xref:Connector_help_Nevion_Flashlink_Frame_-_DA-HD-SDI)                 | Flashlink Module |
| [Nevion Flashlink Frame - SDI-EO](xref:Connector_help_Nevion_Flashlink_Frame_-_SDI-EO)                       | Flashlink Module |
| [Nevion Flashlink Frame - HD-OE](xref:Connector_help_Nevion_Flashlink_Frame_-_HD-OE)                         | Flashlink Module |
| [Nevion Flashlink Frame - DA-3G-HD](xref:Connector_help_Nevion_Flashlink_Frame_-_DA-3G-HD)                   | Flashlink Module |
| [Nevion Flashlink Frame - UDC-HD-XMUX](xref:Connector_help_Nevion_Flashlink_Frame_-_UDC-HD-XMUX)             | Flashlink Module |
| [Nevion Flashlink Frame - FRS-HD-CHO](xref:Connector_help_Nevion_Flashlink_Frame_-_FRS-HD-CHO)               | Flashlink Module |
| [Nevion Flashlink Frame - 3G-HD-CHO](xref:Connector_help_Nevion_Flashlink_Frame_-_3G-HD-CHO)                 | Flashlink Module |
| [Nevion Flashlink Frame - SDI-OE-S](xref:Connector_help_Nevion_Flashlink_Frame_-_SDI-OE-S)                   | Flashlink Module |
| [Nevion Flashlink Frame - DA-AES](xref:Connector_help_Nevion_Flashlink_Frame_-_DA-AES)                       | Flashlink Module |
| [Nevion Flashlink Frame - DAC-AES](xref:Connector_help_Nevion_Flashlink_Frame_-_DAC-AES)                     | Flashlink Module |
| [Nevion Flashlink Frame - AV-SD-XMUX](xref:Connector_help_Nevion_Flashlink_Frame_-_AV-SD-XMUX)               | Flashlink Module |
| [Nevion Flashlink Frame - SDI-TD-DMUX-4](xref:Connector_help_Nevion_Flashlink_Frame_-_SDI-TD-DMUX-4)         | Flashlink Module |
| [Nevion Flashlink Frame - OE-LBand](xref:Connector_help_Nevion_Flashlink_Frame_-_OE-LBand)                   | Flashlink Module |
| [Nevion Flashlink Frame - PSU](xref:Connector_help_Nevion_Flashlink_Frame_-_PSU)                             | Flashlink Module |
| [Nevion Flashlink Frame - 3GHD-EO](xref:Connector_help_Nevion_Flashlink_Frame_-_3GHD-EO)                     | Flashlink Module |
| [Nevion Flashlink Frame - PWR](xref:Connector_help_Nevion_Flashlink_Frame_-_PWR)                             | Flashlink Module |
| [Nevion Flashlink Frame - 3GHD-OE-SFP](xref:Connector_help_Nevion_Flashlink_Frame_-_3GHD-OE-SFP)             | Flashlink Module |
| [Nevion Flashlink Frame - WOS](xref:Connector_help_Nevion_Flashlink_Frame_-_WOS)                             | Flashlink Module |
| [Nevion Flashlink Frame - 3GHD-OE-SFP-2](xref:Connector_help_Nevion_Flashlink_Frame_-_3GHD-OE-SFP2)          | Flashlink Module |
| [Nevion Flashlink Frame - EO-LBand](xref:Connector_help_Nevion_Flashlink_Frame_-_EO-LBand)                   | Flashlink Module |
| [Nevion Flashlink Frame - ETH-1000-D](xref:Connector_help_Nevion_Flashlink_Frame_-_ETH-1000-D)               | Flashlink Module |
| [Nevion Flashlink Frame - EDFA-BOOST-B](xref:Connector_help_Nevion_Flashlink_Frame_-_EDFA-BOOST-B)           | Flashlink Module |
| [Nevion Flashlink Frame - DA-3GHD-2x4](xref:Connector_help_Nevion_Flashlink_Frame_-_DA-3GHD-2x4)             | Flashlink Module |
| [Nevion Flashlink Frame - SDI-EO-2](xref:Connector_help_Nevion_Flashlink_Frame_-_SDI-EO-2)                   | Flashlink Module |
| [Nevion Flashlink Frame - FRS-HD-CHO-ASI](xref:Connector_help_Nevion_Flashlink_Frame_-_FRS-HD-CHO-ASI)       | Flashlink Module |
| [Nevion Flashlink Frame - SDI-EO-D"](xref:Connector_help_Nevion_Flashlink_Frame_-_SDI-EO-D)                  | Flashlink Module |
| [Nevion Flashlink Frame - HD-EO](xref:Connector_help_Nevion_Flashlink_Frame_-_HD-EO)                         | Flashlink Module |
| [Nevion Flashlink Frame - AV-MUX](xref:Connector_help_Nevion_Flashlink_Frame_-_AV-MUX)                       | Flashlink Module |
| [Nevion Flashlink Frame - AAV-DMUX](xref:Connector_help_Nevion_Flashlink_Frame_-_AAV-DMUX)                   | Flashlink Module |
| [Nevion Flashlink Frame - AAV-MUX](xref:Connector_help_Nevion_Flashlink_Frame_-_AAV-MUX)                     | Flashlink Module |
| [Nevion Flashlink Frame - AAV-SD-XMUX](xref:Connector_help_Nevion_Flashlink_Frame_-_AAV-SD-XMUX)             | Flashlink Module |
| [Nevion Flashlink Frame - AAV-SD-DMUX](xref:Connector_help_Nevion_Flashlink_Frame_-_AAV-SD-DMUX)             | Flashlink Module |
| [Nevion Flashlink Frame - 3G-HD-EO-2](xref:Connector_help_Nevion_Flashlink_Frame_-_3G-HD-EO-2)               | Flashlink Module |
| [Nevion Flashlink Frame - SDI-OE](xref:Connector_help_Nevion_Flashlink_Frame_-_SDI-OE)                       | Flashlink Module |
| [Nevion Flashlink Frame - AAV-HD-DMUX](xref:Connector_help_Nevion_Flashlink_Frame_-_AAV-HD-DMUX)             | Flashlink Module |
| [Nevion Flashlink Frame - AAV-HD-XMUX](xref:Connector_help_Nevion_Flashlink_Frame_-_AAV-HD-XMUX)             | Flashlink Module |
| [Nevion Flashlink Frame - 10G-TR-2](xref:Connector_help_Nevion_Flashlink_Frame_-_10G-TR-2)                   | Flashlink Module |
| [Nevion Flashlink Frame - QUAD-CHO-2X1-PB](xref:Connector_help_Nevion_Flashlink_Frame_-_QUAD-CHO-2X1-PB)     | Flashlink Module |
| [Nevion Flashlink Frame - 3G-EO](xref:Connector_help_Nevion_Flashlink_Frame_-_3G-EO)                         | Flashlink Module |
| [Nevion Flashlink Frame - 3G-OE](xref:Connector_help_Nevion_Flashlink_Frame_-_3G-OE)                         | Flashlink Module |
| [Nevion Flashlink Frame - ETH1000-SFP](xref:Connector_help_Nevion_Flashlink_Frame_-_ETH1000-SFP)             | Flashlink Module |
| [Nevion Flashlink Frame - HD-TD-10GDX-6-SFP](xref:Connector_help_Nevion_Flashlink_Frame_-_HD-TD-10GDX-6-SFP) | Flashlink Module |
| [Nevion Flashlink Frame - SPG-AVA-DMUX-R](xref:Connector_help_Nevion_Flashlink_Frame_-_SPG-AVA-DMUX-R)       | Flashlink Module |
| [Nevion Flashlink Frame - ASI-CHO-2x1-PB](xref:Connector_help_Nevion_Flashlink_Frame_-_ASI-CHO-2x1-PB)       | Flashlink Module |
| [Nevion Flashlink Frame - 3G-IP-MUX-8-SFP](xref:Connector_help_Nevion_Flashlink_Frame_-_3G-IP-MUX-8-SFP)     | Flashlink Module |

## Configuration

The **Nevion Flashlink Frame** is an SNMP connector. The IP needs to be configured during creation of the element.When a new element is created, the DVE child elements will be created in the same view as the main element.

## Usage

### General

This page contains the general **system info**, the number of **active alarms** in the system, and **module actions**. The module actions make it possible to remove one or all inactive DVEs (removed cards).

Via the **Polling Config** page button, the polling speed can be altered.

### Module Overview

Thispage contains the **Module List Table** with a list of all the modules on the frame.

The parameter **Module Alarm Count** displays the number of alarms retrieved from the device.

### Custom Frame Name

On this page, a custom frame name can be configured.

Available from version 2.0.3.8 onwards.

### Audio

This page displays the **Audio Block** **Table**, which contains information about all audio I/O blocks.

It also allows you to configure some parameters, such as **Incoming** and **Outcoming Format**, **SRC**, **Peak** and **Max Level**, **Alarms**, etc.

### Audio Generator

This page displays the **Audio Generator** **Table**, which contains information about audio generators.

It also allows you to configure the **Audio** **Level** and view the **Audio Generators**.

### Audio Matrix - SDI Outputs

This page displays the **Audio Matrix** **Table** and the **SDI Outputs Table**.

In both tables, the **Input** can be configured.

### Audio Processing - Embedder

This page displays the **Audio Proc** **Table**, which contains information about the audio processing capabilities of each card. The table allows you to configure the **Mode** and view the **Audio Proc**, **Inputs** and **Outputs**.

This page also displays the **Embedder Table**, which lists all embedders for those modules that have them. You can configure the **Status**, **Word Length**, and **Alarms**, as well as enable or disable the Embedder.

### Delay

This page displays the **Delay Table**, which contains information about delay parameters.

It also allows you to configure the **Status**, **Lines**,**Samples** and **Nanosecs** delays.

### DMUX Matrix

This page displays the **DMUX Matrix Table**, which represents the matrix shown on the web interface of the AAV-SD-DMUX device.

It also allows you to configure the **Input** and **Crosspoint Lock**.

### GPIO

This page displays the **General Purpose Input Output Table**, which contains information regarding I/O blocks.

It also allows you to configure the **Mode**, **Status**, **Description** and **Alarms**.

### Ethernet Ports

This page displays the **Ethernet Ports Table**, which contains information regarding Ethernet ports.

### Cable Driver

This page displays the **Cable Driver** **Table**, which contains information about cable driver parameters.

It also allows you to configure the **Config** and **Slew Rate**.

### Monitor

This page displays the **Monitor** **Table**, which contains information about monitor parameters.

### Laser

This page displays the **Laser Table**, which contains information about laser parameters.

It also allows you to view the **Laser** **Num**, **Wavelength**, **Power** and **Type**, as well as to configure the **Config**, **Status** and **Alarms**.

### Optical Input

This page displays the **Optical Input** table, which contains information about optical input parameters.

It also allows you to view the **Opt Input**, **Input Status** and **Signal Strength**, as well as to configure the **Opt Input Alarms**.

### Reclocker

This page displays the **Reclocker Table**, which contains information about reclocker parameters.

It also allows you to view the Reclocker **Num**, **Status** and **Bit Rate**, as well as to configure **Config**, **ASI**, **Bandwidth** and **Alarms**.

### Signal Input

This page displays the **EQ Table**, which contains information about EQ parameters.

It also allows you to view the **Num** and **Status**, as well as to configure **Config** and **Alarms**.

### Signal Integrity

This page displays the **Monitor Table**, which contains information about monitor parameters.

It also allows you to configure **Monitor Alarm**, **Error Count**, **Error Delta** and **Error Free Alarm**, **FF-CRC**, **AP-CRC**, **LOCK**, **ANCS**, etc.

### Serial Port

This page displays the **Serial Port Table**, which contains all serial port functions, such as **Mode**, **Status**, **Parity**, **Stopbits**, **Speed**, etc.

### Sync Source

This page displays the **Serial Port Table**, which lists all sync source inputs.

It also allows you to view the **Sync Src**, **Type**, **Lines**, **Frame Rate** and **Structure**, **Sample Rate** and **Word Length**, as well as to configure **Alarms**.

### Temperature

This page displays the **Temperature Table**, which contains information about temperature measurements.

It also allows you to configure the **Nominal** value, **Upper** and **Lower Limit** and **Alarms**, as well as to view the actual temperature **Value**.

### Changeover

This page displays the **Changeover** **Table**, which contains information about cho1BlockTable parameters.

It also allows you to configure the **Mode**, **Current Input**, **Main**, **Backups**, **Rule**, **Latch**, **Hold** and **Lock Time** and **Alarms**.

### Voltage

This page displays the **Voltage Table**, which contains information about voltage measurements.

It also allows you to configure the **Upper** and **Lower Limit** and **Alarms**, as well as to view the **Nominal** effect and the **Value** in Volts and Watts.

### Video Generator

This page displays the **Video Generator** **Table**, which lists all video generators.

It also allows you to configure the **Pattern**, **Y**, **Cb** and **Cr**.

### Video Scaler

This page displays the **Video Scaler** **Table**, which lists all video scalers.

It also allows you to see the **Video Scaler**, **Lines**, **Frame Rate** and **Structure**, **Aspect Ratio**, etc.

### XMUX Matrix

This page displays the **XMUX Matrix** **Table**, which represents the matrix shown on the web interface of the AV-SD-XMUX or AVV-SD-XMUX device.

It also allows you to configure the **Input** and **Crosspoint Lock**.

### Alarms

This page displays the **Alarms** table, which contains all alarms accessible from the system. This page is available on the DVEs when there is an alarm for the corresponding DVE.

### Web Interface

On this page, you can directly connect to the webpage of the device itself.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

The following traps are supported:

- Card Removed
- Card Inserted
- Correct/Loss of Optical Signal
- Correct/Loss of EQ Signal
- Correct/Loss of Reclocker Lock
- Voltage Error/OK
- Temperature Error/Ok
- Laser Error/Ok
- Embedder Error/Ok
- Audio Block Error/Ok
- General Purpose Input Output Error/Ok
- Monitor Error/Ok
- Changeover Backup/Main
- Video Scaler Error/Ok
- Sync Source Error/Ok
- Serial Port Error/Ok
