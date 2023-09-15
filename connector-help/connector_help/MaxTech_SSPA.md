---
uid: Connector_help_MaxTech_SSPA
---

# MaxTech SSPA

The MaxTech SSPA is a Solid State Power Amplifier that offers a 14 stage amplification.

## About

The MaxTech SSPA connector allows for monitoring and basic configuration of the SSPA device.

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host:** The polling IP of the device
- **IP port:** The IP port of the device.
- **Bus address:** The bus address of the device.

## Usage

### General

The general page contains all information concerning the **Redundancy Setup** if the device is setup in a **Redundant System**. It also contains **Global Alarm States** and the **Unit Type** and **Firmware**.

### Alarms

The Alarms page contains all possible **alarm states** for the Maxtech SSPA device. An alarm parameter will show as ***Fault*** if something is wrong.

### Measurements

Provides the bulk of the SSPA data. This includes the **Power Supply Voltages**, **Forward Power, Reflected Power, Dummy Power** and the **SSPA Current** for every **Stage** and **Total**. It also provides the user with the currently setup **Units** for power used on the device.

### Configuration

Displays the current configuration settings of the device, including such parameters as the **Power Up State, Calibration Offsets, Power Savings Features**.
