---
uid: Connector_help_Snell_Wilcox_KudosPro
---

# Snell Wilcox KudosPro

The **Snell Wilcox KudosPro** is a connector for the channel cards controlled by the **Snell Wilcox MC2000 Controller**. As such, both protocols need to be used in conjunction in order to get full integration of all parameters and features.

## About

This connector allows the management of the **Snell Wilcox KudosPro** using a serial connection. (Snell RollCall is used as the underlying communication protocol.)

### Version Info

| **Range** | **Description** | **DCF Integration** |
|------------------|-----------------|---------------------|
| 1.0.0.x          | Initial version | Yes                 |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.2A.10                     |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *172.16.61.11*.
- **IP Port:** The IP port of the device, e.g. *2050*.
- **Bus address:** Used to fill in the Unit Address and the Unit Port. For example, if *26.02* is filled in, this represents the Unit Address *0x26* and Unit Port *0x02*.

## Usage

### General Page

This page shows the **Display** content of the device.

### Connection Info Page

This page contains information about the RollCall connection, such as the **Session Status**, **Assigned Session Nr**., **Simulated RollCall Response**, **Card User Name**, **Unit Address**, **Unit Port** and **Local Session Nr**.

### Input Page

This page allows you to specify a video input source using the **Input Select** parameter.

### Output Page

This page allows you to apply various settings and adjustments to the video output signal (e.g. Output Standard, Current Output Standard and Output Format)

It also contains parameters related to the **Scrolling Caption Generator** (e.g. Caption Entry), **Blanking** (e.g. Embedded Audio), and **Logo Control** (e.g. Current Selected Logo, H Position and V Position).

### Video Page

This page allows you to apply various types of signal processing to the signal that is being converted. It includes **Proc Amp**, **Nonlinear Enhancer** and **Noise Reduction** controls.

### Convert Page

On this page, you can control motion processing to improve the conversion performance of stationary content.

### ARC Page

This page contains parameters related to the Aspect Ratio Control (ARC). It allows you to determine the aspect ratio of a picture from a range of options, and to adjust the size and position of the picture manually.

### Audio Routing Page

This page contains the audio routing parameters (e.g. **AES 1** to **AES4**).

### Audio Shuffle Page

This page allows you to set **Output Pair 1 L** to **Output Pair 8 L** and **Output Pair 1 R** to **Output Pair 8 R**.

### Dolby Page

This page allows you to monitor and configure the Dolby parameters. Note that these parameters are updated via element connections. Since the protocol is not able to retrieve these parameters from the card, they are polled via the MC2000 protocol, and can be linked with element connections one by one.

### Timecode Page

On this page, you can set up and control the timecode options of the unit for VITC (Vertical Interval Timecode), embedding and processing.

### Metadata Page

On this page, you can control a set of closed captions and teletext subtitle information.

### Memories Page

This page allows you to select a memory with the **Memory Select** parameter, set its name with the **Change Name** parameter, and see the defined memory names, among others.

### RollCall Page

This page displays the **Unit Name**.

### SNMP Page

This page contains the SNMP settings, such as **Control Enable** and **Traps Enable**.

### Logging Page

On this page, you can view and enable logging information, with parameters such as **Input Standard Enable** and **Input Closed Caption Input Enable**.

### Web Interface Page

This page allows you to access the original web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

The **1.0.0.x** connector range of the **Snell Wilcox KudosPro** protocol supports the usage of DCF and can only be used on a DMA with **8.5.8.5** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **SDI in 1**: Physical SDI interface with type **in**.
- **SDI in 1**: Physical SDI interface with type **in**.
- **SDI in 1**: Physical SDI interface with type **in**.
- **SDI in 1**: Physical SDI interface with type **in**.
- **SDI out 1**: Physical SDI interface with type **out**.
- **SDI out 1**: Physical SDI interface with type **out**.
- **SDI out 1**: Physical SDI interface with type **out**.
- **SDI out 1**: Physical SDI interface with type **out**.

### Connections

#### Internal Connections

- If, on the **Input** page, an **SDI input** is selected as the input value of the **Input Select** parameter, a connection will be created. The input will be connected to all four **SDI outputs**.
