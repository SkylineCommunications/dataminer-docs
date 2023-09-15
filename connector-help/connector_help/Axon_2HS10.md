---
uid: Connector_help_Axon_2HS10
---

# Axon 2HS10

The Axon 2HS10 is a dual channel ultra high-quality down-converter. The connector monitors and controls the device via **SNMP**.

## About

The connector of this device polls in two distinct periods of time, each lasting thirty seconds, and updates the corresponding user interface.

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

- **SNMP CONNECTION:**

  - **IP address/host**: The polling IP of the device.
  - **Device Address:** A logical index, between *0* and *17*.

  **SNMP Settings:**

  - **Port number**: The port number used to poll the device, by default *161.*
  - **Get community** **string**: The community string used to read from the device. The default value is *public*.
  - **Set community string**: The community string used to write on the device. The default value is *private*.

## Usage

The connector has three pages: **General**, **Global** and **Input Settings.**

### General Page

On this page, the following general information is displayed:

- **Card Name**
- **User Label:** This parameter can also be updated.
- **Card Description**
- **Software Revision**
- **Hardware Revision**
- **Product Code**
- **Serial Number**
- **Card ID**

In addition, the following functional information from the device is displayed:

- **Reference Detected**
- **Lock Status**
- **SDI Input 1**
- **SDI Input 2**
- **CRC Status Input 1**
- **CRC Status Input 2**
- **Group In Use Input 1**
- **Group In Use Input 2**
- **IO Delay Input 1**
- **IO Delay Input 2**

### Global Settings Page

This page displays the following configurable device parameters:

- The input **Video Format**
- The **Lock Mode**
- The **Reference Input** (either the first or the second)
- The **Reference Type** (Bi/Tri levels)
- The Horizontal Delay **(H Delay**) in pixels
- The Vertical Delay **(V Delay**) in pixels
- The **Delay Status**

In addition, the **Alarm Priority...** page button allows you to define the priority of the:

- **Announcements**
- **Reference Status**
- **Lock Status**
- **Input 1**
- **Input 2**
- **CRC Status Input 1**
- **CRC Status Input 2**

### Input Settings Page

For each input, the following configurable settings are displayed on this page:

- **Horizontal Position (H Position)**
- **Vertical Position (V Position)**
- **Horizontal Sharpness (H Sharpness)**
- **Vertical Sharpness (V Sharpness)**
- Four Gains**: Y-Gain, C-Gain, R-Gain** and **G-Gain**
- Four Black Levels: RGB Black; R-Black; G-Black and B-Black

In addition, the page button **Other Settings...** allows you to configure the following for each input*:*

- **SDI Output**
- **Input Scale**
- **Color Converter**
- **Mark 4:3**
- **Coring**
- **Audio Delay**
- **Embedded Input Select**
- Video Index Insert Information **(VI Insert)**
- Video Index Data Information **(VI Data)**
- **WSS Insertion Mode**
- **WSS Standard**
- **WSS Extended Format**
- **WSS GPI**

## Notes

Version 1.0.1.1 is based on version 1.0.0.3, with additional DCF functionality.
