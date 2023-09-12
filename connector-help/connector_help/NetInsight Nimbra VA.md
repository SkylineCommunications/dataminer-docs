---
uid: Connector_help_NetInsight_Nimbra_VA
---

# NetInsight Nimbra VA

With this driver it is possible to monitor **NetInsight Nimbra VA 210** devices with SNMP.

## About

The **NetInsight Nimbra VA** will monitor the **NetInsight Nimbra VA 210** devices.

Current Version: 1.0.0.1

## Installation and configuration

### Creation

This is an SNMP driver. The IP has to be configured during creation of the element.

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays general information, such as:

- **System Name**
- **System Uptime**
- **System Description**

### Input Page

This page displays a table with the input information, such as:

- **Push information**
- **Pull Information**
- **Jitter**
- **Latency**
- **Uptime**

### Output Page

This page displays a table with the Output information, such as:

- **Push informartion**
- **Jitter**
- **Latency**
- **Bitrate**
