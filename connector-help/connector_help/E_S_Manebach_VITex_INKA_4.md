---
uid: Connector_help_E_S_Manebach_VITex_INKA_4
---

# E&S Manebach VITex INKA 4

The **VITex INKA 4** is a playout system for audio, video and videotext data. It can save video and picture files internally on the HDD and play them out, either on demand or through the transmission cycle control.

## About

This connector communicates with the device using SNMP commands. It also deals with SNMP traps sent from the device.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not used.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General

This page displays general information about the device, such as the **Serial Number**, **Fan Information** and **Clip Information**.

When the **Clip Status** changes in the device, it will send a trap that will set the **Clip Status Info** to the relevant value. However, **Clip Status Info** can also be set with one of the 4 available values. This can be useful when assigning an alarm on this parameter.

### Web Interface

This page provides access to the configuration webpage of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
