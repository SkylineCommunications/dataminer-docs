---
uid: Connector_help_Infothuis_DST100
---

# Infothuis DST100

The Infothuis DST100 is used to restamp timing data and to model subtitles.

## About

The Infothuis DST100 connector is used to monitor a DST100 device. This connector uses SNMP communication to retrieve data from the device.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not used.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General

The **General** page displays the **System** and **Service** **Contact** **Information** and the overall status of the device.

### Health Monitor

The **Health Monitor** page displays values from the monitor device fan, voltage and temperature readings.

### DST

This page gives an overview of the subtitles information.

### ASI

This page gives an overview of the devices used as transmitter or receiver, as well as their status.

### Web Interface

Shows the webpage of the device.
