---
uid: Connector_help_Crosspoint_HUB-DSPv2
---

# Crosspoint HUB-DSPv2

The **Crosspoint HUB-DSPv2** is used to read out and monitor the **Multiviewer** device.

## About

The **Crosspoint HUB-DSPv2** is a read-only protocol containing the general and status information from the device. This information is retrieved via an **HTTP connection**.

## Installation and configuration

### Creation

This connector uses an HTTP connection and requires the following input during element creation:

**HTTP CONNECTION:**

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Bus address**: The bus address of the device, by default *ByPassProxy*.

## Usage

### General

On the **General** page, the following information is displayed:

- General information, with the parameters **Serial Number**, **Version** and **Device Name**.
- Status information, with the parameters **Temperature**, **Matrix Connection**, **PS Values**, and the **Voltages**.
- Basic device information, with parameters such as the **Name, Version, Serial Number, Firmware Version, Temperature, Voltage Values**, and **all alarms** for the device.
