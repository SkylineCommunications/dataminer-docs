---
uid: Connector_help_Miteq_NSU2
---

# Miteq NSU2

This is a New Switchover Unit (NSU) Redundant Switchover System with 2 primary units and 1 backup unit.

If a primary unit fails, the backup unit will take over (if **Redundancy Mode** is set to *Automatic*).

## About

The connector can be used as a remote control for the device, and also monitors the device.

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **IP port**: 23
- **Bus address**: The bus address of the connected device. The range is defined from *64* to *95.*

## Usage

### General

This page displays the unit's **Model Number, Serial Number**, **Name** and other general parameters. Only the **Unit Name** can be modified.

With the **Eth. Authentication** page button, you can enable or disable the sending of an ethernet password and you can specify the password. These parameters are custom parameters and are not configured on the device.

By default, the ethernet authentication is enabled and a default password "11111" is used.

You can enable this functionality and change passwords using the web interface.

### Control Unit

This page shows the status of the 2 primary converters and the backup converter. With the **Redundancy Mode** parameter you can configure whether switching is done automatically or manually.

With the **Convertor** page button, you can configure the **Link Status** and the **Converter Activity** of each converter.

### Alarms

This page shows the status of the power supplies, the converter bus and contact, and the switch modules.

### Web Interface

This page shows the web interface of the device.
