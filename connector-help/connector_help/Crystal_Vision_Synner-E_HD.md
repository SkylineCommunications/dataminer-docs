---
uid: Connector_help_Crystal_Vision_Synner-E_HD
---

# Crystal Vision Synner-E HD

This device is a video synchronization tool designed to simplify system design in Dolby E environments.

## About

The Crystal Vision Synner-E HD connector makes it possible to monitor and control a specific Crystal Vision Synner-E HD card.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: The number of a specific card of the device, e.g. *11*.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### Status page

The **Status** page displays 4 blocks of data:

- **Video Status**: Displays general data regarding the status of the video.
- **Audio Groups In**: Displays general information regarding the input audio groups.
- **Input Sub PCB Audio Status**: Displays general information regarding the front and rear sub.
- **Audio Groups Out**: Displays general information regarding the audio output groups.

### Synchronizer Control page

On the **Synchronizer** **Control** page, the user can view and set the controls for the synchronizer.

### DeEmbed and Embed page

The **DeEmbed** **and** **Embed** page displays six blocks of data:

- **Audio Groups In**: Displays the input audio groups and allows the user to set the DeEmbedder A and B to a preferred group.
- **Dolby E Locking**: Allows the user to lock the front and rear sub clock to either the *input* or the *output.*
- **Embed Control**: Displays information regarding the embed control.
- **Dolby Control**: Allows the user to set the Dolby Control to a preferred value.
- **TAD Controls**: Allows the user to modify the TAD Controls as needed.
- **Audio Groups Out**: Displays the output audio groups and allows the user to set the DeEmbedder C and D to a preferred group.

### Audio Routing and Delay page

The **Audio** **Routing** **and** **Delay** page displays the **Audio Routing matrix**, which allows the user to view or set the link between the different audio inputs and outputs.

The page also contains two page buttons, **Mono .** and **Mute.** , which each open a pop-up page where extra configurations regarding the outputs can be viewed or set.

### Audio Gain page

On the **Audio** **Gain** page, the gain for the different outputs can be set to a value between *-3 dB* and *3dB*.

### Presets and Headphones page

The **Presets and Headphones** page allows the user to modify the presets and select the requested embedder for the **Headphone Monitor**.

### Alarms page

On the left-hand side of the **Alarms** page, the **GPO6 Status** is shown, and it is possible to modify the silence for the different channels.

On the right-hand side of the page, the user can modify several settings and also set the **Silence** **Alarm** **Delay**.

There is also one button available on this page, **Factory** **Reset**, which will set all the values back to the default values.

## Notes

For the output gain no formula was specified, so there can be small deviations between the set value and the actual value.
