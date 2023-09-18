---
uid: Connector_help_Vertex_LRx-1201-xx
---

# Vertex LRx-1201-xx

The **Vertex LRx-1201-xx** connector will display information related to the **Vertex LRx-1201-xx** device.

## About

The connector has a serial communication to the device and allows the end user to control and monitor the switches. Note that currently only a 2+1 system is supported.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 2.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 2.0.0.x          | 1.092                       |

## Installation and configuration

### Creation

Serial Main connection

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

## Usage

### General Page

This page contains general information about the device together with some general monitoring and config data.

### Configuration Page

This page displays the configuration parametes of the device.

### Alarms Page

This page contains the currenlty active and latched alarms on the device.
