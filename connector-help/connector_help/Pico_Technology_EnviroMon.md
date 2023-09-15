---
uid: Connector_help_Pico_Technology_EnviroMon
---

# Pico Technology EnviroMon

The **Pico EnviroMon** is a data logger that can be used to display environmental information obtained through various sensors.

## About

This connector uses a serial connection in order to retrieve the readings from the device.

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION:**

- **Type of port:** *Serial.*
- **Baud rate**: 57*600*
- ***Databits:** 8*
- **Serial port:** The serial port of the device, e.g. *com1.*
- ***Stopbits**: 2*
- ***Parity**: none*

## Usage

The DataMiner element has only 1 page: **General.**

### General

This page displays the information obtained through the active sensors connected to the data logger. The information is displayed in a table.

For each sensor, the most recently obtained **reading** is displayed (updated every 10 seconds), along with its **alarm status**. You can also add a description for each sensor.
