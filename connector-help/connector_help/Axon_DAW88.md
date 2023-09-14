---
uid: Connector_help_Axon_DAW88
---

# Axon DAW88

The DAW88 is an audio watermarking embedder for Audience Measurement, Second Screen applications, or both.

## About

The Axon DAW88 connector makes it possible to monitor and control a selected card. The preferred settings can be set for each channel of this card.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: The card number, e.g. *11*.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string needed to read from the device. The default value is *public*.
- **Set community string**: The community string needed to set to the device. The default value is *private.*

## Usage

### General page

This page displays general information regarding the device. Some of the parameters on the page can be set by the user.

There are four page buttons on this page that each lead to a pop-up page:

- **Input** **Channels**: Displays information regarding the inputs.
- **Status**: Displays information regarding the status of the device.
- **Quad** **Speed**: Displays information regarding the quad speed.
- **WK**: Displays information regarding the WK, and contains some parameters that can be set by the user.

### Channel 1/2 and 3/4 page

On this page, you can modify the settings for **channels 1 to 4**.

### Channel 5/6 and 7/8 page

On this page, you can modify the settings for **channels 5 to 8**.

### Channel 9/10 and 11/12 page

On this page, you can modify the settings for **channels** **9** **to** **12**.

### Channel 13/14 and 15/16 page

On this page, you can modify the settings for **channels** **13** **to** **16**.

### Slots page

This page displays information about all the available slots. You can also perform sets on each slot to select the preferred setting.
