---
uid: Connector_help_Newtec_EL970
---

# Newtec EL970

This protocol supports full control over the **EL970 demodulator**.

## About

This protocol can be used to monitor and control a Newtec EL970. A **serial** connection (RMCP protocol) is used in order to successfully retrieve and configure the information of the device. Alarm monitoring and trending are possible for many parameters.

## Installation and configuration

This connector uses a **serial** connection and requires the following input during element creation:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Bus address**: The bus address of the connected device, by default *100.*

## Usage

### General page

This page displays device information, the internal temperature and several page buttons.

### Ethernet page

This page allows control of the Ethernet interface, including redundancy and packets.

### Demodulator page

On this page, you can monitor and set demodulator parameters.

### IP Encap - Decap Page

This page contains IP interface and filter parameters.

### Redundancy page

This page provides full redundancy control.

### Alarms page

On this page, all alarms and statuses on the device are displayed.

### Web Interface page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface
