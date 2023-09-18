---
uid: Connector_help_Vertex_7134
---

# Vertex 7134

The **Vertex 7134** connector is a serial connector that is used for antenna control. It allows alarm monitoring and trending of many important parameters.

## About

This is an antenna control unit, with support for step tracking and memory tracking. Positioning of the antenna can be set manually, or through a predefined value saved in a table as a preset.

## Installation and configuration

### Creation

The **Vertex 7134** is a serial connector. The IP address and port need to be configured during creation of the element. These communication settings will be used to send and receive commands and responses to and from the device.

## Usage

### Main View

On this page, you can find general information about the unit.

### General Page

On this page, you can find more detailed information about the unit, along with a large number of statuses.

### Positions Page

On this page, you can set manual positioning of the antenna and target and program tables.

### Step Track Page

On this page, **Step Track** parameters and sets are available.

### Memory Track Page

On this page, enhanced memory track parameters and sets are available.

### Alarms Page

On this page, all alarms that can be present on the unit are displayed. Monitoring is enabled for these parameters.

## Notes

As this is a serial connector, this means that there has to be a connection to a real device.

Step track and enhanced memory track are only supported on the 7134 EMT device. Before the memory track can be started, the correct track parameters have to be set. The targets (A, B, C) used when setting the track parameters have to be present in the target table.

To be able to control the device from DataMiner, the device needs to be in **Remote Control Mode** (RS-232/422 Remote Control or Remote Mode), not in **Local** mode.

If the serial gateway is configured at a slow 1.2 kbaud rate (RS-232), is it possible that Target Azimuth, Polarization or Elevation settings do not work correctly in the **Target** table. If the serial gateway is configured to RS-428, these settings will work correctly.
