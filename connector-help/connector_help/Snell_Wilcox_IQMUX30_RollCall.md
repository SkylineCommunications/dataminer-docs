---
uid: Connector_help_Snell_Wilcox_IQMUX30_RollCall
---

# Snell Wilcox IQMUX30 RollCall

The **Snell Wilcox IQMUX30 RollCall** is a multiplexer for audio streams.

## About

The connector allows the management of the **Snell Wilcox IQMUX30 Rollcall** using a smart-serial connection.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 4674                        |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device, e.g. *192.168.14.11*.
  - **IP port**: The IP port of the device, e.g. *2050*.
  - **Bus address**: Used to fill in the unit address and the unit port, e.g. *10.04* is for unit address *0x10* and unit port *0x04.*

## Usage

### General Page

This page contains the **Display** parameter and the **Status Display** parameter. An overview of module statuses is also displayed, such as **Software** **version**, **KOS**, **Build**, **PCB**, **Firmware**, **UpTime**, **Licensed** **Options**, **Product** and **Serial Number.**

Additionally, there are three buttons:

- **Factory** **Default**: Resets all module settings to factory-specified default values and clears memories
- **Default** **Settings**: Resets all module settings to factory-specified defaults but does not clear memories.
- **Restar**: Software restart of the module.

The parameters of the output display are also displayed.

### Video Page

This page contains information about video.

### Procamp Page

This page contains information about the processing amplifier, e.g. **ProcAmp** **Enable**, **Black** **Level**, **Hue** **Adjust**, **Master** **Video** **Gain**, **Y Gain**, **Cb/Cr Gain**, **Y/C Timing**, etc.

### Video Delay Page

This page provides an overview of the video delay: **Horizontal** **Delay**, **Vertical** **Delay**, **Frame** **Delay** **Added** and **Active** **Video** **Delay**.

### Embedder 1 Page

This page contains the audio controls for group 1.

### Embedder 2 Page

This page contains the audio controls for group 2.

### Embedder 3 Page

This page contains the audio controls for group 3.

### Embedder 4 Page

This page contains the audio controls for group 4.

### Router Overview Page

This page contains the audio controls for the groups.

### Audio Page

This page contains information about the audio, e.g. **Frequency**, **Channel** **ident**, **Internal** **Status**, **Silence** **Level**, **Overload** **Level**, **Warning** **Timer**, etc.

### Pattern & Caption Page

This page contains information about the displayed **Pattern** and **Caption**. You can also set the caption or the pattern.

### Memories Page

This page provides an overview of the system memory, with a table containing 16 user memories. It also allows you to save and clear memory.

### Logging Video Input Page

This page contains the input 1 log video settings and input 2 log video settings. Note that all status parameters can be enabled or disabled.

### Logging Audio Input Page

This page contains the input 1 log audio settings and input 2 log audio settings. Note that all status parameters can be enabled or disabled.

### Logging AES Input Page

This page contains the input AES log settings. Note that all status parameters can be enabled or disabled.

### Logging Video Output Page

This page contains the output video log settings. Note that all status parameters can be enabled or disabled.

### Logging Audio Output Page

This page contains the output audiolog settings. Note that all status parameters can be enabled or disabled.

### Rolltrack Page

This page provides a simple command interface that can be used to send unconnected Rolltrack commands to any Rollcall-compatible unit on the network. The following parameters are displayed: **Rolltrack Disable All**, **Rolltrack Index 1, Rolltrack Address 1**, **Rolltrack** **Sending, Rolltrack Source 1**, **Rolltrack Command 1** and **Rolltrack** **Status**.

### Web Interface Page

This page provides access to the original web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
