---
uid: Connector_help_Axon_HJA420
---

# Axon HJA420

The device Axon HJA420 is a **Loudness Controller**.

## About

This connector uses **SNMP** to monitor and control the Axon HJA420 Loudness Controller device.

### Version Info

| **Range** | **Description**      | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version      | No                  | Yes                     |
| 1.1.0.x          | New firmware version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.1.0.x          | V0706                       |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host:** The polling IP of the device.
- **Device address:** Required range: *1 - 4*.

**SNMP Settings:**

- **Port number:** The port of the connected device, by default *161.*
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

## Usage

This connector consists of 11 pages.

### General

This page displays information regarding the card itself, such as the **Card ID**, **Status**, **Name**, **Description**, **Software** and **Hardware Revision**, **Product Code** and **Serial Number**. It is possible to edit the **User Label**, **Key**, and **Junger License**.

There is also information about the **Module**, in particular: **ID**, **Status**, **Name**, **Type**, **Software** and **Hardware** **Revision**, **Protocol Code**, **Serial**, **HD** and **3G capable**.

You can also find the **Modes** and **Status** of the **J1** and **J2 Engines** here.

Finally, the page also has an **Alarm Priority** page button that allows you to turn the **Announcements** on or off, and to change options related to alarm monitoring.

### Video

On this page, you can change settings that are **related to Video** and its **Phasers** and **Delays**, such as **Input**, **Output Format**, **Lock Mode**, **Phaser Offsets**, **Enable/Disable Delay**, **Delay Mode**, **Time Delay**, **Frame Delay**, **Vertical** and **Horizontal Phase Delays**.

### Preset

On this page, you can change the **Control**, **GPI Control**, **Ext Mode**, **Preset configurations**, **Loudness Links** and **Engines**.

There are also two page buttons:

- **Loudness:** Allows you to change settings regarding the **Loudness Sources** and **Engine Channels.**
- **Program:** Allows you to change settings regarding **Engine Programs**.

### Loudness Program

This page contains settings such as **Program Name**, **Gains**, **Target Level**, **AGCs**, **TRPs**, **Processing**, **Expander** and **Compressor**.

### Status

This page displays the status information regarding the **SDI Input 1** and **SDI Input 2**, **Reference Format**, **Active Output**, **IO Delay**, **GPI**, and **Ancillary Data**, **ATC**, **Audio Groups**, **Metadata** **Input** and **FPGA** error status.

### Metadata

This page contains settings such as **Extract/Insert Line**, **Insert Method**, **Metadata Status Source** and **Program**, and **S2020 Metadata Source** and **Associate Channel**.

The **Metadata Status** page button displays metadata information such as **AC3 Copyright** and **Original Bitstream**, **Audio Product Info** and **Production Room Type**, **RF Mode**, **Center** and **Surround Downmix Levels**, **Dolby Surround**, **DC Filter**, **Lowpass Filter** and **Line Mode**.

### Embedding

On this page, you can select the **Embedder Mode** and the **group** of the **A**, **B**, **C** and **D** **Embedders**.

There are several page buttons:

- The **Add-on** page button displays the formats for each corresponding add-on bus channel.
- The **Embedder Format Input** page button shows the format for each corresponding de-embedded audio.
- With the **Miscellaneous** page button, you can modify the following settings: **Fade Time**, **Audio Phase**, **Audio Status Bits**, **Silence Level** and **Silence Time**.

### Embedder A, B, C and D

On these four pages, you can access the corresponding **Embedder** **configuration**, with parameters such as **Embedder** **Sources**, **Channels**, **Gains**, **Phases** and **Delays**.
