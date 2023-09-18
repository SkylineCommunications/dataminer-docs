---
uid: Connector_help_General_Electronics_UPS
---

# General Electronics UPS

The General Electronics UPS is an uninterruptible power supply that works with three phases.

## About

The General Electronics UPS connector makes it possible to monitor and control a selected UPS. The connector was made to resemble the existing web interface.

## Installation and configuration

### Creation

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not used.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General page

The **General** page displays three groups of information:

- **General** **Status**: Contains the most important parameters of the device.
- **Batteries**: Information regarding the batteries.
- **System**: General information about the device.

The button **Normalize** will set the current values as baseline values for the following parameters (used in absolute alarming):

- **(Output) Load Phase 1**
- **(Output) Load Phase 2**
- **(Output) Load Phase 3**

### Output page

The **Output** page displays four blocks of information, for each of the three phases of the output:

- **Voltage**,
- **Current**,
- **Load**,
- **Power**.

### Input page

The **Input** page displays the voltage of each of the three phases of the input.

### Bypass page

The **Bypass** page displays the voltage of each of the three phases of the bypass.

### Alarms page

On this page, the different types of possible alarms are shown. For alarms that are currently active, the duration of the alarm is shown. If an alarm is not active, it will display *OK*. The first parameter, **AlarmsPresent,** shows the number of active alarms. If a certain type of alarm is not possible on the UPS, that alarm will be grayed out and it will display *Not* *Available*.

### Identification page

This page displays some general information about the device in the left column. In the column on the right, the first eight parameters display data about the battery. The next four parameters display data about the current or last UPS diagnostics test. The value of some of the parameters can be modified.

### Status page

This page contains three tables:

- **Input:** Displays information about the different inputs.
- **Output:** Displays information about the different outputs.
- **Bypass:** Displays information about the different bypasses.

Aside from these tables, several other parameters are displayed that give additional information.

### PMAD/Config page

On this page, you can see three different blocks of parameter data. The first block in the top left corner displays diagnostic data that shows the remaining lifetime of different components. Below this, another block of data shows the number of failures since the UPS installation. The block of parameters in the right column displays the configuration parameters, which can be set to a different value as preferred.

### Parallel page

On this page the status of the different UPS devices can be seen. If you click a page buttons for a particular UPS, a pop-up page will be opened. The different pop-up pages are the same as the pages discussed above(**Identification**, **Status**, **Alarms**, and **PMAD/Config**).

The parameter above each row of page buttons displays whether the UPS is *Online* or *Offline*. Only when the status is *Online,* the page button of the UPS in question will display data.

### Webpage

This page displays the webpage of this device.

## Notes

Note that if you use firmware version "GEDE CP5 SNMP/Web Interface Ver.1.0 (2008/05/09)", the connector will not be able to set parameters.
