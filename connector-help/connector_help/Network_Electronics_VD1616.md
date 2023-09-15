---
uid: Connector_help_Network_Electronics_VD1616
---

# Network Electronics VD1616

The **Network Electronics VD1616** connector can be used to monitor and control information of the related device.

## About

This protocol can be used to monitor the Network Electronics VD1616 device. A **serial** connection is used in order to successfully retrieve and configure the device's information.

In addition, **DCF** support has been implemented for the matrix.

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION**

- **IP address/host:** The polling IP of the device.
- **IP port:** The IP port of the device.
- **Type of port:** TCP/IP

## Usage

This connector contains the following pages:

- **Main View:** Matrix overview.
- **General:** Matrix crosspoint settings.
- **Alarm:** Information about the **PSU Status**.
- **Input Connections:** Overview table of the connected inputs to the related outputs.
- **Matrix Configuration:** Settings for the configuration of the matrix (for instance **Input/Output Selection**).
- **Grouped Crosspoints Status:** Overview table containing **Device Status** information.
