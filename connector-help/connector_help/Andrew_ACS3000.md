---
uid: Connector_help_Andrew_ACS3000
---

# Andrew ACS3000

The **Andrew ACS3000** connector is a serial connector that is used as an Antenna Control Unit. It allows alarm monitoring and trending of many important parameters.

## About

The **Andrew ACS3000** device is an Antenna Control Unit. It supports a wide range of configuration properties. All connected satellites are displayed in tables. Positioning of the antenna can be changed in multiple ways (step, position, jog, x degrees). Step Track, Smart Track, Intelsat Track and Norad Track are supported. The alarm log can be retrieved.

### Version Info

| **Range**     | **Description**                      | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version                      | No                  | Yes                     |
| 2.0.0.x              | Changed port settings: Local IP Port | No                  | Yes                     |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the Andrew ACS3000 connected to the network, e.g. *10.11.12.13.*
- **IP port**: The port of the local TCP connection used by the Andrew ACS3000 (default: *6192*).

## Usage

### General Page

This page displays general information about the **ACU**, with page buttons to the **Log/Alarms**, **Working Sat Table**, **Configuration** and **Set Time** subpages.

### Position/Jog Page

This page contains positioning parameters for the antenna. The position can be changed by entering positioning parameters, moving by step, or moving by degrees or JOG. A base satellite can also be selected.

With the parameter **Time Offset Same Position**, you can configure the time to ignore that the position has not changed for a moment.

With the parameter **Offset Small Position Degree Movement**, you can configure the offset to ignore a small degree change.

### Tracking Page

On this page, tracking parameters and track mode are available. You can among others configure the **Scan Cycle Time**, **Scan Cycle Level**, **Low Signal Level**, **Beacons Offset** and **Downlink Frequency**.

## Notes

Before a track mode can be set, a base satellite has to be selected on the **Position/Jog** page.
