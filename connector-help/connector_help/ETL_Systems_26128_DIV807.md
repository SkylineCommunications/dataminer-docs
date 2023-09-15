---
uid: Connector_help_ETL_Systems_26128_DIV807
---

# ETL Systems 26128 DIV807

The **ETL Systems 26128 DIV807** protocol is used to monitor and control 8-way active single L-band splitter modules housed in a modular system chassis.

## About

This protocol can be used to monitor and control any ETL Systems 26128 DIV807 module. A **TCP/IP** connection is used in order to successfully retrieve and configure the settings of the device.

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL Connection:**

- **Type of port:** The type of port of the connection, by default *TCP/IP*.
- **IP Address/host:** The polling IP of the device. For instance: *10.1.48.70*.
- **IP Port:** The IP port of the connection device. For instance: *4012*.
- **Bus Address:** The device's address. For instance: *15*.

## Usage

### General

This page displays general information about the device: **Software Version**, **Temperature**, **Supply 5V**, **Supply 8V**, etc.

### Attenuator

This page displays the attenuator-related settings of the device: **Attenuator Flag**, **Attenuator** and **Attenuator Bias Voltage**.

### Amplifier

On this page, for each of the four amplifiers of the device, the **Amplifier Flag** and **Amplifier Bias Voltage** is available.

### LNB

This page displays the LNB-related settings of the device: **LNB Voltage Level**, **LNB Tone**, **LNB Voltage** and **LNB Current.**

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
