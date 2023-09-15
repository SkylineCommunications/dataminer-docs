---
uid: Connector_help_Imagine_Communications_4CQS1-S
---

# Imagine Communications 4CQS1-S

The **Imagine Communications 4CQS1-S** is a **Dual 2x2** or **Single 4x4** Clean and Quiet Switcher for Selenio MCP3 frames. It provides a clean, non-disruptive and glitch-free transition of video content when switching from one source to another source of the same data rate and frame rate.

## About

This connector allows you to access various information on the device. The data is retrieved using SNMP. There are different possibilities available for alarm monitoring and trending.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 13                          |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: The device address.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains information such as the **Slot Number**, **Firmware Revision**, **Temperature** and **Serial Number**.

It also allows you to set the **Operation Mode** to either ***Single 4x4 Mode*** or ***Dual 2x2 Mode***. In **Dual 2x2 Mode**, the two SDI signals entering a 2x2 switch must have the same data rate and frame rate. Similarly, in **Single 4x4 Mode**, clean and quiet switching can only be executed if the SDI signals going into the 4x4 switch share the same data rate and frame rate.

### Control

This page displays the **Serial**, **Ethernet** and **GPI Control**. The serial port must be configured prior to first use, with the parameters **Port Mode**, **Baud Rate**, **XY Over Serial** and **XY Framed ID**.

For **Ethernet Control**, the following settings can be configured: **Device IP**, **Subnet Mask**, **Gateway** and **Ethernet XYNet**.

### Reference

On this page, you can configure the **Reference Selection** (*Primary*, *Secondary* or *Free Run*).

The page also displays the **Reference Standard**, **Reference Status**, **Processing Channel Status (1-4)**, **Line Sync Offset** and **Line Sync Window**.

### Video Input Routing and Status 1

This page displays **Input Routing**, **Video Status** and **Video Configuration** parameters for **Channels 1** and **2**. Note that these parameters depend on the **Operation Mode** (***Single 4x4*** or ***Dual 2x2*)**.

### Video Input Routing and Status 2

This page displays **Input Routing**, **Video Status** and **Video Configuration** parameters for **Channels 3** and **4**. Note that the configuration of these parameters depends on the **Operation Mode** (***Single 4x4*** or ***Dual 2x2*)**.

### Frame Sync/Line Sync 1

On this page, you can configure the **Frame Sync Controls** for **Channels 1** and **2**. The different **Frame Synchronizers** can also operate as **Line Synchronizers**.

When Frame Sync is used in the **4x4 mode**, video sources can be asynchronous with respect to each other, but they must have the same data rate and frame rate.

### Frame Sync/Line Sync 2

On this page, you can configure the **Frame Sync Controls** for **Channels 3** and **4**. The different **Frame Synchronizers** can also operate as **Line Synchronizers**.

When Frame Sync is used in the **4x4 mode**, video sources can be asynchronous with respect to each other, but they must have the same data rate and frame rate.

### Video TSG

This page displays the **Test Signal Generator** controls for each of the four **SDI Inputs**. During firmware upgrades, the **TSG** automatically outputs **Color Bars 75%**.

### Audio Control & Status 1 - 4

These pages contain the status of the audio de-embedding values for **DMB 1-4**. For each of the four audio groups in the **SDI Signal**, the page displays if they are ***Present*** and if they have any errors in **Checksum**, **DBN**, **Parity** and **ECC**.

### Audio De-embedder 1 - 4

These pages display several controls for **DMB 1-4**. It is possible to set which action (*Mute*/*Repeat*) must be taken when the module detects a demuxed audio group error, and to configure whether alarms for the following errors should be ignored: **DBN**, **Checksum**, **ECC** and **Parity**.

It is also possible to select the **Link Source** (*Link A*/*Link B*) for this audio de-embedder.

### Audio Delay & Sync 1 - 4

On these pages, you can configure the **Source Control** (*Auto*/*Enabled*/*Bypass*) for each channel pair of **DMB 1-4**. Audio synchronization with the video frame synchronizer can also be configured with the **DMB 1-4 Audio Tracking** parameter.

### Audio EMB 1 - 4

These pages contain the controls to adjust the **Gain**, **Invert**, **Summing**, **Copy/Swap**, **Mute**, **Word Length** and **Format** of the **Embedded Audio 1-4 Output Channel** pairs **1A** and **1B** to **8A** and **8B**.

### Misc Audio

This page displays the **Audio TSG Level** configuration, which can be used to adjust the volume of the audio test tones. With the other parameters on this page, you can modify the configuration of all **Embedded Audio Channels**, from SDI in 1 to 4.

### Audio Tones 1 - 4

On this page, you can substitute any of the 16 mono channels of the **EMB 1-4** with a test tone. The default selection is **DMB Ch**, which means that the originally embedded audio channel will be preserved.

### Audio Embedding 1 - 4

These pages display the **Append** and **Overwrite Status** for each group of **EMB 1-4**. They also allow you to configure the **Embedding Mode** (*Append*/ *Overwrite*/ *Auto*) for each of the four audio groups.

### Clean Quiet Switch 1 - 4

The **SEL-4CQS1** performs **Clean/Quiet Switching** automatically, by remote control (**Serial**, **Ethernet** or **GPI**) or by using manual triggers. It is possible to configure different parameters, such as **Transition Rate**, **CQS Trigger Mode** and **Input Trigger Source**.
