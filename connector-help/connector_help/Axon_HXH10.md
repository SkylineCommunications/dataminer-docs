---
uid: Connector_help_Axon_HXH10
---

# Axon HXH10

This is an SNMP-based connector used to display and configure information of the **Axon HXH10** card.

## About

The Axon HXH10 is an **HD-SDI** or **SD-SDI** to two **SDI output cross-converter**. The connector displays information and allows the user to change settings regarding the converter.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host:** The polling IP of the device.
- **Device address:** Required range: 0 - 18.

**SNMP Settings:**

- **Port number:** The port of the connected device, by default *161*.
- **Get community string:** The community string in order to read from the device. The default value is *public*.
- **Set community string:** The community string in order to set to the device. The default value is *private*.

## Usage

This connector has 2 pages: **General** and **Settings**.

### General

This page displays information regarding the device itself, such as the **Card ID** and **Name**, **User Label**, **Software** and **Hardware Revisions**, **Product Code**, **Serial Number**, **SDI Input**, **Output** **Format** and **Color Converter**.

### Settings

On this page, you can view and configure settings concerning the **Output Format**, **Color Converter**, **Gains**, **Blacks**, **Embedded Inputs** and **Audio Delay**.

With the **Alarm Priority** page button, you can access the following settings: **Announcement Priority**, **Input Priority** and **CRC Status**.

## Notes

DCF implementation on version: 1.0.1.1
