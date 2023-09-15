---
uid: Connector_help_Axon_SDB15
---

# Axon SDB15

This connector is used to monitor the **Axon SDB15** Audio Embedder.

## About

This connector uses **SNMP** in order to display information and configure settings of the device.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host:** The polling IP of the device.
- **Device address:** Required address: *1*, *2*, *3* and *12*.

**SNMP Settings:**

- **Port number:** The port of the connected device, by default *161.*
- **Get community string:** The community string in order to read from the device. The default value is *public*.
- **Set community string:** The community string in order to set to the device. The default value is *private*.

## Usage

The Axon SDB15 connector has the following pages: **Main View**, **General Info**, **Settings** and **Events**.

### Main View / General Info

This page displays the information status of **SDI Input**, **FPGA**, **EDH**, **ANC**, **Audio Embedders** and **Channels**. It also contains information about the device itself, such as the **Card Name** and **ID**, **Description**, **Software** and **Hardware Revision**, **Product Code** and **Serial Number**.

### Settings

On this page, you can configure settings regarding the **Output** and **Add-Ons Channels**, **Gains**, **Phases**, **Audio Out Levels** and **EDH Detection**.

### Events

On this page, you can configure **Announcements**, **Input Prority**, **EDH Status Priority** and **ANC Status Priority**.

## Notes

DCF implementation on version 1.0.1.1.
