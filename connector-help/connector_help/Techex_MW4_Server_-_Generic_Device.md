---
uid: Connector_help_Techex_MW4_Server_-_Generic_Device
---

# Techex MW4 Server - Generic Device

The **Techex MW4 Server - Generic Device** connector is an HTTP-based connector that is used to monitor and configure a **Techex MW4 Server**. The middleware server will expose set-top boxes connected to the system and allows the user to manage these.

## About

This connector provides a monitoring interface for a **Techex MW4 Server**.

### Product Info

| **Range**     | **Device Firmware Version** |
|----------------------|-----------------------------|
| 1.0.0.x              | 4.6.4                       |
| 1.0.1.x \[SLC_Main\] | 4.6.4                       |

## Installation and configuration

### Creation

This connector is used by DVE child elements that are **automatically created** by the parent connector **Techex MW4 Server**.

## Usage

### General

This page displays general information about the device, such as the **Name**, **Location**, **Manufacturer**, **Model**, **Channel**, **Volume**, **Connection** and **State**.

The page also contains buttons that allow you to perform different operations on the DVE device: **Refresh**, **Reboot**, **TV On**, **TV Off**, **Power On** and **Power Off**.

### Network

This page contains the device **network configuration**, including the **Internal IP**, **External IP**, **DHCP**, **DNS**, **MAC**, **Mask**, **Gateway**, **NTP Server** and **Location**.

### Settings

This page includes all the **configuration parameters**, such as **Aspect Ratio**, **Resolution**, **Interface Resolution**, **Subtitles**, **Force Mute**, **Stats Interval**, etc.

The page also contains buttons that allow you to **Upgrade** or **Delete** the DVE device.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

The **1.0.1.x** connector range of the **Techex MW4 Server - Generic Device** protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

Connectivity for this protocol is managed by the parent protocol **Techex MW4 Server**.
