---
uid: Connector_help_Teracue_iCue
---

# TeraCue iCue

The **TeraCue iCue** is used for streaming media with an integrated video archive. It allows the digital distribution, management and recording of TV channels and camera signals.

## About

This is an SNMP driver that displays all the services, broadcastings and recordings. It also uses traps to update the values faster.

## Installation and configuration

### Creation

This driver uses a Simple Network Management Protocol (SNMP) connection and needs the following user information:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General

The **General** page contains the device information. With the **Export Profile** button, you can create a .csv file at the selected **Destination.**

### Services

On this page, you can see the state of all the services.

### Broadcast

This page provides an overview of all the broadcasts that are available and their information.

### Recording

This page provides an overview of all the recordings and their information.

### Webinterface

The web interface of the device.
