---
uid: Connector_help_Advantech_AMT_Intrac_405
---

# Advantech AMT Intrac 405

This protocol can be used to display information from the Advantech AMT Intrac 405 intelligent tracking antenna controller and to configure this device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### Serial connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

- **Baudrate**: *1200* to *57900*
  - **Databits**: *8*
  - **Stopbits**: *1*
  - **Parity**: *No*
  - **FlowControl**: *No*

- Interface connection:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
  - **IP port**: The port of the connected device, by default *161.*

## How to use

The element consists of the data pages detailed below.

### Main View

This page displays general parameters such as the current azimuth, elevation and polarization position, and the beacon signal.

### General

This page contains parameters related to the beacon, the device, the resolvers and the versions.

Page buttons provide access to additional parameters:

- **Debug**: Displays parameters used for debugging.
- **System** **Config**: Displays parameters related to the system configuration.
- **INTRAC** **Operation**: Contains the INTRAC and dual redundant INTRAC configuration.
- **EEPROM** **Status**: Contains parameters related to the **EEPROM**.
- **Diagnostics**: Displays the diagnostics 1, 2 and 3.

### Positioning

This page contains all position-related readings and settings of the controller, such as the **Current** **Positions.** Buttons are included on this page to move the satellite up and down, left and right, clockwise and counterclockwise.

Page buttons provide access to additional parameters related to **Search Parameters**, **Hysteresis level**, **FineTune Offsets**, **Software Limits**, **Limits of Search**, **Step Track** and **Limits**.

The **Goto Satellite** page button opens a subpage that allows you to lock the device onto a given predefined satellite from the **Satellite Presets**. On the same subpage, you can also define how many samples the protocol needs to collect before the frequency and the polarization angle are adjusted. In case the device cannot adjust to a specific satellite in time, you can also define a sliding window that discards the initial samples that do not belong to it.

In version 1.0.0.25 of the driver, the **Positions** subpage is added, which allows you to change the azimuth, elevation and polarization separately. These separate buttons were added for older devices that have difficulty processing the 3 parameter values at the same time. However, the functionality is the same as on the main Positioning page.

### Satellite Presets

This page displays the **Satellite Info Table** and the **Satellite List Counter**.

### Stow

This page contains all stow-related readings and settings, both for the Az Stow and the El Stow, such as the **Stow Pin**, **Stow Aligned**, **Brake**, some **Alarms**, etc.

Two buttons on this page allow you to **Stow** or **Unstow**.

The page also contains three page buttons:

- **Stow Position**: Allows you to set the **Stow Azimuth** and **Stow Elevation**.
- **Preset Modes**: Displays if certain commands are disabled or enabled.
- **Drive Cabinet Alarm**: Displays the drive cabinet alarms.

### Alarms

This page contains the controller's alarm reading, with parameters such as Beacon Alarm, Primary Alarm, Hardware Alarm, etc.
