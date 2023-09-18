---
uid: Connector_help_DVBControl_DVBLoudness
---

# DVBControl DVBLoudness

The **DVBLoudness** is part of the DVBControl software toolset which enables powerful Loudness measurements for multiple Audio services coming from multiple Transport Streams. Loudness is measured according to the ITU-R BS.1770-3 standard and EBU R.128 recommendations.

## About

This connector is intended to communicate with the DVBLoudness toolset using SNMP commands.

## Installation and configuration

### Creation

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*
- **Device address**: not used

**SNMP Settings**:

- **Port number**: the port of the connected device, default *1610*
- **Get community string**: the community string in order to read from the device. The default value is *public*.
- **Set community string**: the community string in order to set to the device. The default value is *private.*

## Usage

### General

Use the General Page to have access to general information about the toolset. It's also possible to set the **Contact**, **Name** and **Location** of it.

### Inputs

Use this page to see the status of the **Inputs** and **Channels** and also to set the **Program** and **Daily Service Loudness States**.
