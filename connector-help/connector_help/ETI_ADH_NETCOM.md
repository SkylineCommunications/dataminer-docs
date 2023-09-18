---
uid: Connector_help_ETI_ADH_NETCOM
---

# ETI ADH NETCOM

The **ETI ADH NETCOM** is an Automatic Air Dehydrator that uses Ethernet communication. It prevents the accumulation of moisture in transmission lines by maintaining the pressure and dew point of the air inside the line.

## About

This connector is used in order to gather information from the device, such as alarms and measurements.

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION:**

- **Type of Port**: UDP/IP
- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device, *52091*.
- **Bus address**: Not used.

## Usage

### General

This page shows information related to:

- **Control**: Allows you to set the dehydrator into standby or online mode.
- **ADH NETCOM Identification**: Displays information related to the unit.
- **Dehydrator Status Information**: Displays the current status and state of the unit.
- **Measurements**: Displays current measurements.
- **From Master To Slave**: Used when the dehydrator works as a Master in a serial master-slave connection between two dehydrators.

### Alarms

This page displays the current state of the dehydrator's alarm relays.

## Notes

The ADH NETCOM automatic dehydrator receives commands on **UDP** **port 52091**. When it is operating as a master dehydrator in a master/slave configuration, the master will send out messages using **UDP** **port** **52092** as the source port and **52091** as the destination port.
