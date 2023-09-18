---
uid: Connector_help_Foxcom_SatLight
---

# Foxcom SatLight

The Foxcom Satlight is a chassis for Complete RF-2-Fiber Solutions.

## About

With this connector, it is possible to monitor and configure **transmitters**, **receivers** and **switches** in a **Foxcom SatLight** chassis with SNMP.

Different DVEs are created for each transmitter, receiver or switch in the chassis. Each DVE has appropriate parameters to monitor and manage the modules.

General parameters are displayed on the main element.

The connector implements all traps to update the trap table and the slots tables in order to generate alarms immediately.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

**SNMP Settings:**

- **Port number:** The port of the connected device, by default *161.*
- **Get community string:** The community string needed to read from the device. The default value is *public*.
- **Set community string:** The community string needed to set to the device. The default value is *private*.

## Usage

### General

This page displays general information, such as:

- **System Description**
- **System Up Time**
- **System Time**
- **System Temperature**

The device can also be **reset** from the general page.

Use the **Power Supply** page button to view the state of the power supplies.

### Modules

This page displays the 3 tables with the **Receivers**, **Transmitters** and the **Switches**.

### Traps

This page displays occurred events and lets you set the **trap destinations**.

### Web Interface

The native web interface of the device. The client machine has to be able to access the device. Otherwise, it will not be possible to open the web interface.
