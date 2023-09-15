---
uid: Connector_help_Vislink_Lynx_Receiver_L2174
---

# Vislink Lynx Receiver L2174

This connector is made for devices such as the **Vislink Lynx Receiver**. With this connector, several parameters can be monitored and set.

## About

With two timers, all parameters are polled. Some values in the connector can also be set.

## Installation and configuration

### Creation

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.8.34.76*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays general device information.

### Demodulator

On this page, all configuration and status info related to the demodulator is displayed.

### Decoder

On this page, all configuration info and status info related to the decoder is displayed.

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
