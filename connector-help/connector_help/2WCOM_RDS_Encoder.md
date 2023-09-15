---
uid: Connector_help_2WCOM_RDS_Encoder
---

# 2WCOM RDS Encoder

This connector monitors the **2WCOM RDS Encoder**, a professional, fully featured dynamic RDS/RBDS Encoder.

## About

The C02 RDS Encoder matches up with almost any transmitter system. The integrated TCP/IP-interface makes it easy to install, monitor and control the encoder remotely via TCP or SNMP.
The device can be configured and operated via control software ARCOS Config. The 2WCOM RDS Encoder C02 is meant for use by TMC service providers such as NAVTEC or other RDS broadcasters.

## Installation and configuration

### Creation

#### Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: This is not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.

### Configuration of the LITE functionality

It is possible to enable the LITE functionality, so that only the most important parameters are polled. As soon as you disable LITE, polling of all parameters will be resumed.

To enable LITE functionality, go to the **Network Settings** page, and enable the parameter **LITE PROTOCOL**.

## Usage

### General

This page contains **System** parameters and **MIB** parameters.

### Interfaces

This page contains **IP** parameters.

### RDS Encoder

This page displays status parameters. It also contains page buttons that can be used to access various **Timeout** tables.

### Trap Configuration

On this page, you can enable or disable the traps, as well as set priorities for the traps.

### Network Settings

On this page, you can enable or disable **LITE polling**.
