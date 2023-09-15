---
uid: Connector_help_Snell_Wilcox_IQMCC3000-1B3
---

# Snell Wilcox IQMCC3000-1B3

The **Snell Wilcox IQMCC3000-1B3** is a motion-compensated frame rate converter that provides multi-rate and format conversion for 3Gbps SDI and HD-SDI digital video signals. The **Snell Wilcox IQMCC3000-1B3** connector is the solution designed to monitor this converter.

## About

With this connector, you can manage the **Snell Wilcox IQMCC3000-1B3** device using a smart-serial connection.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 4.15.3                      |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device, e.g. *192.168.14.15*.
  - **IP port**: The IP port of the device, e.g. *2050*.
  - **Bus address**: The unit address and the unit port. For example, for unit address *0x10* and unit port *0x04*, specify *10.04*.

## Usage

### General

This page displays information related to the unit itself and to the session status, such as **Unit Name**, **Card User Name**, **IP Share Port**, **IP Bridging Port**, **Session Status** and **Assigned Session Number**.

### Input

This page shows information about input source parameters and allows you to select the input for this converter.

### Output-Ch1

On this page, you can view and configure output parameters for channel 1, such as **Output Standard**, **Force Freeze**, **Embedded Audio**, **Luma Clipper** and **Default Output**.

### Video-Ch1

On this page, you can view and configure video parameters for channel 1, such as **Master Gain**, **Contrast**, **Black Level**, **Noise Rejection**, **Nonlinear Enhancer** and **Vertical Frequency Band**.

### Convert-Ch1

This page provides an overview of the converter parameters for channel 1, such as **Up Conversion**, **Motion Processing**, **Input Cadence** and **Output Cadence.**

### ARC & Sidebar Keyer-Ch1

On this page, you can view and configure ARC & Sidebar Keyer parameters for channel 1, such as **Post Scaling Control**, **Arc Memories**, **Scaler Config** and **Output Signaling Config**.

### Audio Routing-Ch1

On this page, you can configure audio routing parameters for channel 1 for all eight process pairs.

### Audio Shuffle-Ch1

On this page, you can configure audio parameters for channel 1 for all eight output pairs.

### Audio Control-Ch1

On this page, you can configure audio parameters for channel 1, such as **Tone Frequency**, **Dolby E Alignment Offset**, and **Delay**. It is also possible to configure the gain for each of the eight output pairs here.

### Genlock

On this page, you can configure the **Vertical** and **Horizontal Timing** for each source.

### Timecode-Ch1

On this page, you can view and configure timecode parameters for channel 1, such as **Source**, **Mode**, **On Timecode Loss**, **Timecode Entry** and **29.94FPS**.

### Metadata-Ch1

On this page, you can view and configure parameters for channel 1, such as **Closed Captions**, **Teletext**, **SMPTE RDD08/SMPTE 2031 VANC PKT** and **SMPTE 2020 Output**.

### Ancillary Bridge-Ch1

On this page, you can configure several ancillary data stores parameters related to channel 1, from block 1 to 7.

### Rolltrack

This page provides a simple command interface for sending unconnected Rolltrack commands to any Rollcall-compatible unit in the network. The following parameters are displayed: **Disable All**, **Rolltrack Index,** **Rolltrack Source**, **Rolltrack Address**, **Rolltrack Command**, **Rolltrack** **Sending** and **Rolltrack** **Status**.

### Memories

This page shows all 32 memories and allows you to save them.

### Misc. Logging

On this page, you can enable or disable the logging for miscellaneous parameters, such as **Serial Number**, **Up Time** and **Power Usage**.

### Video Input Logging

On this page, you can enable or disable the logging for video input parameters, such as **Input 1 Type**, **State** and **Standard.**

### Output Logging

On this page, you can enable or disable the logging for output parameters such as **Output Type**, **State** and **Standard**.

### O/P Audio State Ch1 Logging

On this page, you can enable or disable the logging for **Output Embedded State** type parameters.

### O/P Audio Type Ch1 Logging

On this page, you can enable or disable the logging for **Output Embedded Audio** type parameters.

### Setup

This page displays information regarding setup parameters, such as the **Software Version**, **Rear ID**, **Serial Number** and **Build Version**.

### Web Interface.

This page can be used to access the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface
