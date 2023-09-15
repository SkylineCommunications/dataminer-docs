---
uid: Connector_help_Wellav_Media_Platform
---

# Wellav Media Platform

The **Wellav Media Platform** connector is used to monitor a Wellav Media Platform IRD device.

## About

This connector supports 2 types of Media Platform:

-An SMP100 chassis: 1 main board and 3 modules

-A DMP900 chassis: 1 main board and 6 modules

Each module can be exported as a Dynamic Virtual Element (DVE).

## Installation and Configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.
- **Device Address:** The type of chassis for this device (SMP100 or DMP900, *default:* *SMP100* ). Case must be respected. If nothing is specified, no data will be polled from the device.

**SNMP Settings:**

- **Port number:** The port of the connected device, by default *161.*
- **Get community string:** The community string used when reading values from the device. The default value is *public.*
- **Set community string:** The community string used when setting values on the device. The default value is *private.*

## Usage

The main element contains 10 pages.

### General

This page lists all the submodules available from that chassis. For each submodule, the **Export Module?** column is used to specify which modules to export as a DVE. Note that the user has to click the **Export Module(s)** button to have the changes taken into account.

The **Device Type** parameter shows the type of chassis. If it displays *Incorrect Bus Value*, the **Device Address** field in the element wizard probably contains a mistake.

### Module X (1 to 6)

These pages display multiple page buttons. Each page button links to a table containing data about a submodule (**ASI**, **IP**, etc.).

### All Modules

This page has the same layout as the **Board X** pages. The linked tables display data about all the modules (from 1 to 6).

### Alarms

This page displays various alarms for the main board. Those parameters are not polled from the device, they are updated when the associated trap is received.

### Web Interface

The native web interface of the device. The client machine has to be able to access the device. If not, it will not be possible to open the web interface.


