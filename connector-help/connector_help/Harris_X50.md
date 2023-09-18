---
uid: Connector_help_Harris_X50
---

# Harris X50

With this connector it is possible to monitor **Harris X50** devices with **SNMP**.

## About

This connector is used to monitor the **Harris X50** Frame Synchronizer and Converter.

In addition to the normal **SNMP** **polling**, the device also sends **traps** (**notifications**) when an alarm occurs on the system. If a trap is received, the connector will update the **Alarms Page** with the new alarms.

## Installation and configuration

### Creation

This is an SNMP connector. The IP and Bus Address need to be configured during creation of the element.

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: The bus address of the device. The default value is *1.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General Page

This page displays general information related to the device:

- **Software Version**
- **System info**

### Parameters Page

On this page, the values are displayed that are present in the web interface of the device under 'Parameters'.

### Video Page

On this page, the values are displayed that are present in the web interface of the device under 'Parameters/Video'.

The page includes page buttons to the following subpages:

- **Scalar1**
- **Scalar2**
- **Status**
- **Logo**
- **Color Corrector**
- **Data**

### Audio Page

On this page, the values are displayed that are present in the web interface of the device under 'Audio'.

The page includes page buttons to the following subpages:

- **Input Gain** (Note that this is displayed on the audio page in the web interface, but we present it on a different page.)
- **Output Gain**
- **Input Delay**
- **Output Mute**
- **Routing**
- **Audio Embedder**
- **Audio Metadata**
- **Metadata Generator**
- **Output Phase Invert**

### System Setup Page

On this page, the values are displayed that are present in the web interface of the device under 'Parameters/System Setup'.

### Alarm Page

On this page, the values are displayed that are present in the web interface of the device under 'Alarms'.
