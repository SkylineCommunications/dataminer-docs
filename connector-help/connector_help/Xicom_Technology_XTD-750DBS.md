---
uid: Connector_help_Xicom_Technology_XTD-750DBS
---

# Xicom Technology XTD-750DBS

The **Xicom Technology XTD-750DBS** connector can be used to display and configure information of the related controller.

## About

This protocol can be used to monitor and control the Xicom Technology XTD-750DBS controller. A serial connection is used in order to successfully retrieve and configure the device's information.

## Installation and configuration

### Creation

**SERIAL CONNECTION:**

- **Type of port:** *TCP/IP.*
- **IP address/host:** The polling IP of the device, e.g. *10.11.12.13.*
- **IP port:** The IP port of the device, e.g. *4001.*

**TCP/IP Settings:**

- **Bus address:** Range 64 to 255.

## Usage

The DataMiner element has three pages: **General**, **Amplifier** and **Alarm**.

### General

This page displays the controller's general information, such as the **Amplifier Model Number**, **Amplifier Serial Number**, **Firmware Version**, **Temperature**, etc.

### Amplifier

This page contains all amplifier-related readings and settings of the controller, such as the **Output Power**, **Attenuator**, etc.

### Alarm

This page contains the controller's alarm reading, with parameters such as **Summary Alarm**, **Current Alarm Status**, etc.

The sub-page **Alarm Control** contains the controller's alarm settings, e.g. **Power High**, **Power Low** and **Reverse Power**.
