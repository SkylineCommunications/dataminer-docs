---
uid: Connector_help_Axon_HES20
---

# Axon HES20

The **HES20** is a Dolby-E aligner and frame synchronizer.

## About

The Axon HES20 connector makes it possible to monitor and control an Axon HES20 card.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: The card number, e.g. *11.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string needed to read from the device. The default value is *public*.
- **Set community string**: The community string needed to set to the device. The default value is *private.*

## Usage

### General page

This page displays general information regarding the selected card. It also allows the user to perform some sets to adjust some settings of the device.

There is one page button available on this page (**Embedded.**). It leads to a pop-up page where the settings for embedding are displayed and a preferred setting can be chosen.

### Video page

This page displays the settings regarding video. The user can configure each setting as they prefer.

At the bottom of the page, there is a page button (**Delay.**) that leads to a pop-up page where the delays can be viewed and set.

### Audio page

This page displays information regarding audio. It allows the user to modify the settings as preferred.
