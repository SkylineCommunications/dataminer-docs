---
uid: Connector_help_Meinberg_SCU-XPT
---

# Meinberg SCU-XPT

The **Meinberg SCU-XPT** connector is an SNMP connector that is used to monitor **Meinberg SCU-XPT** devices with SNMP.

## About

With this connector, you can monitor the status of satellite tracking with the **Meinberg SCU-XPT**.

## Installation and configuration

### Creation

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device.

**SNMP Settings:**

- **Port Number:** The port of the connection device, by default *161*.
- **Get community string:** The community string required to read from the device. The default value is *public*.
- **Set community string:** The community string required to set to the device. The default value is *rwpublic*.

## Usage

### General Page

This page contains general device statuses and information like: **Master Select**, **SCU Type**, **PSU Status**, etc.

### GPS Refclock Page

This page displays information about the two refclocks, such as the **Type**, **Mode**, **State**, etc.
