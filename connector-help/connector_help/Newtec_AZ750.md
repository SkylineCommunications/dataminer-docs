---
uid: Connector_help_Newtec_AZ750
---

# Newtec AZ750

The **Newtec AZ750** is an L-band combiner and upconverter.

## About

Range **1.0.0.x** of the protocol uses **serial** communication to monitor the device.

Range **2.0.0.x** of the protocol uses **SNMP** communication to monitor the device.

### Version Info

| **Range** | **Description**        | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial serial version | No                  | Yes                     |
| 2.0.0.x          | Initial SNMP version   | No                  | Yes                     |

## Installation and configuration

### Creation

#### Serial connection \[1.0.0.x range\]

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600.*
  - **Databits**: Databits specified in the manual of the device, e.g. *7.*
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1.*
  - **Parity**: Parity specified in the manual of the device, e.g. *No.*
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No.*

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device.

#### SNMP connection \[2.0.0.x range\]

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays the **Combiner Table**, as well as the standalone parameters **Overload Threshold**, **Underload Threshold**, **RF Output** and **Output Level**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
