---
uid: Connector_help_CEFD_MBT-5000_Serial
---

# CEFD MBT-5000 Serial

Comtech EF Data's MBT-5000 L-Band Up/Down Converter System provides frequency conversion between L-Band IF and C-/X-/Ku-Band RF frequencies.

## About

With this connector, it is possible to monitor and configure **CEFD MBT-5000** devices with a **serial** connection.

The different parameters from the device are displayed on multiple pages following the web interface.

## Installation and configuration

## Creation

When creating the element the **device IP address** must be filled in as well as the **port**. The device **bus address** is 1 by default. The Valid range is between 1 and 9997.

## Usage

### General

This page displays **general System Information** and the **Overall Status** of the device.

### Admin - Access

This page displays the **IP Address**, the **Gateway** and the **MAC address** of the device. The **IP address** and the **Gateway** can be changed.

### Config - MBT

This page allows the user to adjust settings from the main unit such as:

- **Serial Remote Address**
- **Serial Baud Rate**
- **Auto Fault Recovery**

Some converter specific configuration can also be changed from this page:

- **Attenuation**
- **Attenuation Offset**
- **Mute State**
- **Operating RF Frequency**
- **LNA Current Source**

### Config - Utility

This page displays the **System Date** and **Time** and allows the user to modify the **identification** string and change the **active software Image.** The user can start a **soft reboot** from this page.

The setting "**Local/Remote State**" should be on "**Serial**" to be able to write to the device. (The Local/Remote state can be changed if Local/Rmote State is not on Serial)

With the "Time Sync..." page button, **time synchronization** can be configured to keep the time of the device in sync with the DataMiner time.

### Config - Redundancy

This page allows the user to adjust some **redundancy** settings.

### Status - Events

This page displays events information and allows the user to mask alarms.

The event log can be cleared from dataminer with the "**Clear Event Log**" button. To get all stored events on the device, reset the Events Pointer by clicking the "**Initialize Events Pointer**" button.
To clear all events on the device, click the "**Clear all Stored Events**" button.

### Status - Status

This page displays some general information such as:

- **Part Numbers**
- **Software Revisions**
- **Power Supply Voltages**
- **Converter Temperatures**
