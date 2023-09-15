---
uid: Connector_help_Miteq_UPC-A
---

# Miteq UPC-A

The **Miteq UPC-A** connector allows monitoring and configuration of this uplink power control system through its serial interface.

## About

This serial connector sends commands to the device in order to receive data. It is an implementation of the **IEEE-488 Message protocol** supported by this device.

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION:**

- **Type of port**: TCP/IP (Automatically filled in by the connector).
- **IP address/host**: The polling IP of the device.
- **IP port**: Port used for the device.
- **Bus address**: Bus address for the device.

No further configuration is necessary in order for this connector to work.

## Usage

### General

Lists general information for the device. The **Uplink Power Correction Algorithm** can be set here, as well as the **Sample Time**.
In addition, this page links to pop-up pages containing alarm states for the **PSUs** and the **Channel Attenuators**.

### Channels

This page replaces the Channel 01 page from the older range (1.0.0.x) and holds a table containing information about all the channels (instead of only channel 01).

### Receiver A

Page displaying information about receiver A. Here the receiver mode can be configured as well as the **Voltage** **Range** and **Receiver Calibration** values.

### Receiver B

This page is identical to the page above, but for receiver B instead of A.
