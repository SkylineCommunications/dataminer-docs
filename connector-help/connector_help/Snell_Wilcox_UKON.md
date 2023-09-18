---
uid: Connector_help_Snell_Wilcox_UKON
---

# Snell Wilcox UKON

This connector is used to poll and edit configuration information from a Snell & Wilcox UKON device.

## About

The communication is based on a serial protocol implemented by the device (RollCall protocol). As the element has to receive unsolicited messages, its type is "smart-serial".

The element uses 2 interfaces for a redundant polling: if connection is lost on one of the interfaces, the polling is automatically switched over to the other one.

### Ranges

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | All                         |

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION:**

- **Interface connection:**

- **IP address/host**: The polling IP of the device/serial gateway (e.g. *127.0.0.1*)
- **IP port**: The IP port of the device/serial gateway (required, e.g. *7000*)
- **Bus address**: The bus address of the device/serial gateway (required, e.g. *1.1.1, \<Network Address Used For Bridging\>.\<Unit Address\>.\<Port Address\>*)

## Usage

### Audio

On this page, you can find audio parameters such as **O/P 1 Source, O/P 3/4, Digital Audio Delay Mode, Individual O/P 4, ...**

### Convert

Here are displayed the convert parameters: **Input Type, Output Sense, Bias, ...**

The **Free Run...** page button gives the **Flag Delay**, **Reset Type**, ... and the **Video...** page button the following parameters: **Video Aperture, Blur, ...**

### Display

This part concerns the display parameters: **Transition Type, Transition Shape, Update Rate, Var Tilt, ...**

### Information

The available parameters are: **Unit Status, Unit Input Standard, Unit Output Standard.**

### Input

Here are shown the Input parameters: **Input Std, Input Active Top, Matrix Colorimetry, Input A/B, ...**

### Memory

You can select the memory to use with the **Use Memory** parameter and set another name with the **Rename** parameter.

### Output

Here you can edit the Output parameters such as the **Output Std, Clipper** or the **Output Colorimetry**.

In the **Enhancer...** page button, following parameters, among others, can be edited: **Horz Enh Band, Vertical Enh Y+C, ...**

In the **Processing Amplifier...** page button, you can adjust parameters such as **Gain Master, Gain Y, Offset Master, Offset Y, ...**

In the **Border...** page button, you can edit the following parameters: **Border Enable, Border Red, Border Green, Border Blue, Full Color, ...**

### Reference

This page allows to configure the reference through these parameters: **Reference Enable, Ext Reference Std., Reference Source, Horizontal Timing, Vertical Timing, ...**

### Session Information

The **Session Status** indicates in which phase is the communication process with the device (*initialization* or *normal communication*),

### Setup

Modification of **Setup Info** or **GPI Status** is possible.

In the **RollCall...** page button, these parameters are available, inter alia: **Sys Name, Input Status, Output Standard, Picture, ...**

### Timecode

On this page, time parameter are editable: **Trigger Hour, Trigger Frame, Synchronization, Manual Minutes, ...**

### Utils

Finally, in the Utils page, you can modify, for example, the **Utils Pattern**, the **Mono Enable** or the **YC-Delay.**
