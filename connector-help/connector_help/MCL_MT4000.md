---
uid: Connector_help_MCL_MT4000
---

# MCL MT-4000

The **MCL MT-4000** connector is a serial connector used to monitor and configure the **MCL MT-4000 HPA**.

## About

The **MCL MT-4000** connector is a serial connector that is used to configure and monitor the high power amplifier.

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **IP port**: The port of the connected device.
- **Bus address**: The bus address of the connected device, by default *7*. The bus address can be read on the front panel of the device. It's in hexadecimal format and needs to be converted to decimal to be used in the bus address field of the DataMiner element.

## Usage

### Main View

The **Main** **View** page displays various status parameters related to the device. These parameters provide information on **power**, **current**, **temperature**, etc.

### General

The **General** page displays more detailed information about the status parameters that are displayed on the **Main View** page. You can also modify the settings of these parameters, and a lot of extra information is displayed. Some of the parameters are displayed by means of page buttons.

### Alarms 1

This page displays some of the alarms in the system. It's also possible to configure the alarm levels and fault count for some of the alarms. This can be done by clicking the **Alarm Levels.** or **Fault Count.** button, respectively.

### Alarms 2

This page is very similar to the **Alarms** **1** page, but displays different alarms.

### Digital Status

This page also displays faults and alarms in the system.

### Fault Levels

This page displays the different fault levels that have been set.
