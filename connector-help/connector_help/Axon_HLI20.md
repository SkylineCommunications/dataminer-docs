---
uid: Connector_help_Axon_HLI20
---

# Axon HLI20

This is an SNMP-based connector used to display and configure information of the **Axon HLI20** card.

## About

The Axon HLI20 is an **HD/SD logo inserter** and its connector provides information regarding logo parameters.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host:** The polling IP of the device.
- **Device address:** Required range: *0 - 18*.

**SNMP Settings:**

- **Port number:** The port of the connected device, by default *161*.
- **Get community string:** The community string in order to read from the device. The default value is *public*.
- **Set community string:** The community string in order to set to the device. The default value is *private*.

## Usage

This connector has 4 pages: **General**, **Device Settings**, **Logo Generator A** and **Logo Generator B**.

### General

This page displays information regarding the device itself, such as **Product** **Code**, **Serial Number**, **Networking** **Configurations**, **SDI Input** and **SDI** **Output** formats, **Logo A** and **Logo B** parameters (**Name**, **Memory**, **Dimensions**, **Opacity** and **Position**).

### Device Settings

This page contains configuration settings for **Input Format**, **Logo Modes**, **Reference Input**, **GPI Control**, **NTP Offset** and **Server** and **Networking**. There are also three page buttons that allow access to **Events**, **Logo Scheduler** and **Logo Upload** settings.

### Logo Generator A and Logo Generator B

Each of these pages contains a table where you can view and configure the **Logos settings**, such as **Position**, **Opacity**, **Animation**, **Fade** and **Dimensions**.

## Notes

DCF implementation on version: 29.11.1.1
