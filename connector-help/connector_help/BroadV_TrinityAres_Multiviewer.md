---
uid: Connector_help_BroadV_TrinityAres_Multiviewer
---

# BroadV TrinityAres Multiviewer

The **BroadV TrinityAres Multiviewer** system is a multi-screen mosaic synthesis system for broadcasting regulators, video conferencing and security surveillance. It supports a variety of common input stream formats, and outputs different multiplexer streams to meet the different possible application requirements. This connector is a solution designed to monitor this system.

## About

The **BroadV TrinityAres Multiviewer** connector captures **SNMP** traps from an IP source and displays them in tables.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and Configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.

## Usage

### Signal Alarms Page

This page displays a table with information about signal alarms.

### Device Alarms Page

This page displays a table with information concerning device alarms.

### State Synchronization Alarms Page

This page displays a table with alarms related to the state of the synchronization in the system.

### Channel Information Page

This page displays a table with information regarding the active channel indicators for the third-party system.

## Notes

All these pages also contain a **Configuration** page button, which opens a pop-up page with the following generic parameters:

- **Alarm Filter Status**: A configurable parameter to enable/disable a filter for displayed alarms.

- **Alarms Max Number**: The maximum number of alarms that can be displayed. This value will only be used if the Alarm Filter is enabled.

- **Alarm Clean Up Method**: There are three possible ways to clean up the Alarms Table:

- Based on the number of rows (option *Row Count*).
  - Based on the amount of time the alarm exists (option *Alarm Age*).
  - Based on a combination of both (option *Combo*). In this case, the check on the row count is done first.

- **Alarms Clean Up Amount**: The number of oldest alarms removed from the Alarms Table when the maximum has been reached.

- **Max Age Alarms**: The maximum age of an alarm allowed in the Alarms Table.
