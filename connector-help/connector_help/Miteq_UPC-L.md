---
uid: Connector_help_Miteq_UPC-L
---

# Miteq UPC-L

The **Miteq UPC-L** connector is a serial connector used to monitor and control the **Miteq UPC-L upconverter**.

## About

The **Miteq UPC-L** is a unit designed for geostationary satellite communications systems. This connector can be used to monitor and configure the upconverter.

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **IP port**: The port of the connected device.
- **Bus address**: The bus address of the connected device, between *64* and *95.*

## Usage

### General

The **General** page displays all information and configuration settings related to the entire unit.

This page can be used to check the overall status of the device, for example which **Algorithm** the device is using or which receiver is currently active.

The **Mode Status** parameter displays if the device is in *local* or *remote* mode. *Local mode* means that settings can only be done via the front panel of the device, while *remote mode* means that the settings can be done remotely. As such, it is important that the device's **Mode Status** is set to *Remote* if you want to change settings via the connector.

### Channel

There are 2 pages related to the channels: **Channel 01** and **Channel 02**. Both display the same information, but for their particular channel.

These pages can be used to configure certain settings for the channel in question, for example the **Attenuator Operation Mode** or the **Attenuation**.

In addition, the status of the channel can also be monitored via these pages.

### Receiver

There are also 2 pages for the receivers: **Receiver A** and **Receiver B**. Both pages display the same information, but related to either Receiver A or B.

These pages can be used to configure certain settings for the receiver, for example if the receiver is active or not.

In addition, you can also access the **Downlink Signal Strength** and some other monitoring data via these pages.
