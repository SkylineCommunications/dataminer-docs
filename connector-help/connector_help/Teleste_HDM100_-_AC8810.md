---
uid: Connector_help_Teleste_HDM100_-_AC8810
---

# Teleste HDM100 - AC8810

The AC8810 is an intelligent dual active output node for deep fiber solutions. It has two fixed optical receivers with redundancy for the forward path. The return path can also be fully redundant with double optical transmitter modules.

## About

The AC8810 connector provides a way to interface with the AC8810 ONU module. It is used to display and configure general module and transponder information, forward and return path parameters and alarms.

### Product Info

| **Range** | **Device Revision** |
|------------------|---------------------|
| 1.0.1.x          | 4.4.5               |

## Installation and configuration

### Creation

This connector is used by DVE child elements that are **automatically created** by the parent connector [Teleste HDM100](xref:Connector_help_Teleste_HDM100), version **1.0.1.x**. No user input is required.

## Usage

### General

This page displays general information on the unit, such as identification, statistics, etc.

The page contains the following page button:

- **Alarm Limits AC8810**: Allows you to configure the alarm limits and severities.

### Status

This page displays power-related measurement data.

### Alarms

This page contains the list of alarms with their severity values.

### Forward Path

This page displays information related to the forward path, such as the measured optical input power and reference levels, as well as gain and slope controls.

The page also contains the following page buttons:

- **Forward Path Settings**: Allows you to configure the routing mode and OMI-related forward path settings.
- **Pilots**: Allows you to configure the frequency, target and lost levels, type and status of pilots.

### Return Path

This page displays the optical transmitter modules, gain control and ingress switches.

The page contains the following page button:

- **Return Path Settings**: Allows you to configure the transmitters, routing control, power save, OMI-based alignment, automatic ingress blocking and transponder pilot generator.

### ONU Transponder

This page displays all the data and settings related to the transponder's RF modem and remote communication.

Note that **changing any of the fields** on this page, except the transmitter min and max levels, will **reset RF modem communication**.

### ONU Spectrum Monitoring

This page displays Spectrum Analyzer and Ingress Overview tables.

It also contains a page button that can be used to import a CSV file and send/set the spectrum/ingress points to the device:

- **Import Spectrum Points**: Allows you to enter the CSV file path and perform either an **Ingress Import** or **Spectrum Import** using the two buttons **Start Ingress Import** and **Start Spectrum Import**, respectively.
  The CSV file must have the correct header with the correct order: ***Spectrum Freq.;Freq. Type;Low Limit;High Limit***
