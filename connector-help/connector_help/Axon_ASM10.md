---
uid: Connector_help_Axon_ASM10
---

# Axon ASM10

The **Axon ASM10** is an Analog-to-Digital A/V Bridge with SDI plus embedded audio processing mode. This connector monitors and controls the device via **SNMP**.

## About

The connector polls the device every 30 seconds for fast-varying information and every 6 minutes for slower-varying information. The collected information is then used to update the user interface.

### Creation

The connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device.
- **Device Address:** A logical index, between *0* and *18*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161.*
- **Get community** **string**: The community string used when reading values from the device. The default value is *public*
- **Set community string**: The community string used when setting values on the device. The default value is *private*

## Usage

This connector has five pages: **Main View,** **General Info, Settings_1, Settings_2** and **Events.**

### Main View Page

On this page, the following general information is displayed:

- **SDI Input** status
- **Analog Input** status
- **Error Detection Handling (EDH)** status
- **Ancilliary (ANC)** status
- **Group Insert** status
- **Embedded Audio 1-4** status
- **Analog Audio 1-4** status
- **Card Name**
- **User Label**
- **Description**
- **Software Revision**
- **Hardware Revision**
- **Product Code**
- **Serial Number**
- **Card ID**

### General Info Page

On this page, the following parameters are displayed:

- **SDI Input** status
- **Error Detection Handling (EDH)** status
- **Ancilliary (ANC)** status
- **Card Name**
- **User Label:** the only configurable parameter.
- **Description**
- **Software Revision**
- **Hardware Revision**
- **Product Code**
- **Serial Number**
- **Card ID**

In addition, you can also find the following parameters below:

- **Analog Input** status
- **Reference**
- **Detected Format** (Format DET)
- **Groups in Use** status
- **Group Insert**
- **Embedded Audio 1-4** status
- **Analog Audio 1-4** status

### Settings_1 Page

For each input, the following configurable settings are displayed in the left column of this page:

- **Input Selection**
- **Digital Standard**
- **Analog Standard**
- **NTSC Standard**
- **PAL Standard**
- **Synchronization Mode**
- **Dynamic Noise Reduction** (DNR)
- **Input Gain**
- **Analog Input Level**
- **Input Reference** (Ref Input)
- **Freeze capture**
- **Freeze Mode**
- **Input-Loss**
- **Delay**

In addition, the following parameters are displayed in the right column:

- **Audio Out**
- **Embedded Mode**
- **Emb-B** Mode
- **Emb-A Selection**
- **Emb-B Selection**
- **Tracking** Type
- **VLI Insert**
- **WSS Insert**
- **WSS Extended Insert**
- **WSS Standard Insert**
- **Blank-V-ANC** status
- **EDH Detection**
- **EDH Generator**

### Settings_2 Page

For each input, the following configurable settings are displayed in the left column:

- Audio **Phase Channel 1-4**
- **De-embedded** (De-emb) **Channel 1-4**
- **Analog Channel 1-4 Input**
- **Audio Gain Channel 1-4**
- **Y/C Gains**
- **Y-Black/C-Black** level
- **H/V-Delay**
- **Y-Shaping**
- **Y-Peaking**

### Events Page

On this page, the following alarm priorities can be defined:

- **Announcements**
- **Input SDI Priority**
- **Input ANA Priority**
- **EDH Status Priority**
- **Reference Status Priority**
- **ANC Status Priority**

## Notes

Version 1.0.1.1 is based on version 1.0.0.8, with additional DCF functionality.
