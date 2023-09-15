---
uid: Connector_help_ETL_Systems_26128_DIV407_Serial
---

# ETL Systems 26128 DIV407 Serial

The **ETL Systems 26128 DIV407 Serial** protocol is used to monitor and control 4-way active single L-band splitter modules housed in a modular system chassis.

## About

This protocol can be used to monitor and control any ETL Systems 26128 DIV407 module. A **TCP/IP** connection is used in order to successfully retrieve and configure the settings of the device.

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL connection:

- **Type of port:** The type of port of the connection, by default *TCP/IP*.
- **IP Address/host:** The polling IP of the device. For instance: *10.1.48.70*.
- **IP Port:** The IP port of the connection device. For instance: *4012*.
- **Bus Address:** The device's address. For instance: *12*.

## Usage

### General

This page displays general information about the device: **Software Version**, **Temperature**, **Supply 5V**, **Supply 8V**, etc.

### Amplifiers

On this page, for each of the four amplifiers of the device, the **Amplifier Status** and **Amplifier** is available.

### Attenuators

This page displays the attenuator-related settings of the device: **Attenuator 1 Status**, **Attenuator 1 Gain** and **Attenuator 1**.

### LNB

This page displays the LNB-related settings of the device: **LNB Supply Voltage**, **LNB Supply Current**, **LNB Voltage** and **LNB 22 KHz Tone.**

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
