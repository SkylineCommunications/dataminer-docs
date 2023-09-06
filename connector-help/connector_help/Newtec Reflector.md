---
uid: Connector_help_Newtec_Reflector
---

# Newtec Reflector

The **Newtec Reflector** driver is a **serial** driver that is used to control the Newtec Reflector.

## About

The **Newtec Reflector** driver is used to add and remove destinations in the Newtec Reflector. These destinations are added and removed by using the **'addDestination'** and **'removeDestination' Telnet** commands respectively. When a destination has been added, the driver will poll the statistics for this destination using the **'getStatistics'** command.

## Installation and configuration

### Creation

This driver uses a serial connection and needs the following user information:

**SERIAL CONNECTION:**

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device, by default *3487.*

## Usage

### Statistics

Thispage displays the **Statistics Table**, which has 2 fixed entries for the 2 channels that the Newtec Reflector should be configured with. The 2 fixed channels should have the following configuration:

- Channel 1: **In Port** = 1111 and **In Address** = polling IP
- Channel 2: **In Port** = 2222 and **In Address** = polling IP

When a channel is added to a destination, then the driver will start polling the statistics for that channel.

### Debug

The **Debug** page contains the **External Command** parameter and the **External Command Status** parameter.

The Newtec Reflector driver will primarily be used to **add** and **remove destinations** from an external source (Automation script, manager driver, ...). To add or remove a destination, an external command needs to be set on the External Command parameter with the following format:

- Add destination: 'addDestination\|inPort=xxx;inAddr=xxx;destPort=xxx;destHost:xxx'
- Remove destination: 'removeDestination\|inPort=xxx;inAddr=xxx;destPort=xxx;destHost=xxx'
- Get statistics: 'getStatistics\|inPort=xxx;inAddrs=xxx'
- List channels: listChannels
