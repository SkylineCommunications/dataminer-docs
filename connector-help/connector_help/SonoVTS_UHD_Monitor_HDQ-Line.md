---
uid: Connector_help_SonoVTS_UHD_Monitor_HDQ-Line
---

# SonoVTS UHD Monitor HDQ-Line

This device is a multi-monitor controller with support for UHD broadcasting.

## About

This connector allows you to monitor the parameters of the media stream connected to the device. This connector implements the Ember+ protocol to fetch the relevant information from the device.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | V0.9022                     |

## Installation and configuration

### Creation

#### Smart-serial Main Connection

This connector uses a serial-over-IP connection implementing the Ember+ protocol, and requires the following input during element creation:

SMART-SERIAL CONNECTION:

- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device. By default, this value is *9000*.

## Usage

### General

This page provides information about system variables such as the **firmware version**, **device name**, **serial number** and equipment **type**. It also allows you to set the **standby** and **exit** modes of the device.

A subsection of this page provides basic networking information, such as the **IP address**, **netmask**, **MAC address** and **gateway**.

### Overlay

This page shows the **input type** and the graphic layer. It also provides access to three subsections: **Audio Bar Settings**, **Overlay Settings** and **Safe Frame**. These subsections contain tables to configure **UMD**, **Tally** and **Safe Layer** options.

### Picture Settings

This page contains information about the properties of the image that is being broadcast. Most of these properties are read-only. The parameters on this page include among others **Backlight**, **Brightness**, **Deinterlacing**, **Color Space**, **Range**, **Aspect** and **Gain Backlift** (configurable).

## DataMiner Connectivity Framework

This connector supports DCF connections since version **1.0.0.2** and requires a DMA with at least DataMiner version **9.0.0.5**.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed Interfaces

There is a single input (parameter **Selected Input**) that is available through DCF.
