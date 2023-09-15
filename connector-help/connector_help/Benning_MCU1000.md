---
uid: Connector_help_Benning_MCU1000
---

# Benning MCU1000

This connector is used to monitor the MCU1000 device.

## About

All the status information is retrieved via a serial command. Then appropriate parameters are updated and meaningful alarms are generated.

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *192.168.1.2*.
- **IP port**: The IP port of the device, e.g. *80*.
- **Bus address**: Not required.

## Usage

### Main View

On this page, the main alarms and the most important electrical quantities are displayed.

For the alarms you can amongst others find the following parameters: **Urgent Alarm**, **Non-Urgent Alarm** , **Rectifier x Failure**, ...

For the electrical quantities, you can for example find the following parameters: **Busbar Voltage, Total Rectifier Current, Maximum Load Power,** ...

### General

This page contains general system information, such as the **Serial Number, Date**, and **Time.** You can also find more detailed electrical data here: **Busbar Voltage, Load Current Total, Rectifier Currents** (via the **Detailed Info** page button).

### Alarm

All the alarms are grouped on this page, with amongst others the following information: **Battery Fuse, Non-Urgent Alarm, Modem Status, Discharging Battery, Rectifier x Failure, Mains Error Rectifier x, Fan Rectifier x Failure,** ...
