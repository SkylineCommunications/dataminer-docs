---
uid: Connector_help_Newtec_EL470
---

# Newtec EL470

This protocol supports monitoring and full control over the Newtec EL470 modem.

## About

This protocol can be used to monitor and control a Newtec EL470 device. A **serial** connection (RMCP protocol) is used in order to successfully retrieve and configure the information of the device. There are also different possibilities for **alarm monitoring** en **trending**.

The web interface can be accessed if the client machine has access to it.

### Version Info

| **Range** | **Description**                           | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------------------|---------------------|-------------------------|
| 1.7.2.x          | Initial version                           | No                  | Yes                     |
| 1.8.25.x         | New firmware based on 1.7.2.x (see below) | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**            |
|------------------|----------------------------------------|
| 1.7.2.x          | Software version 7.02 software id 6279 |
| 1.8.25.x         | Software version 8.25 software id 6281 |

## Installation and configuration

Serial main connection

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
  - **IP port**: The IP port of the device, by default *5933*.
  - **Bus address**: The bus address of the connected device, by default *100.*

## Usage

### General page

This page displays both device info and the internal temperature. There are also several page buttons.

### Ethernet page

This page allows control of the Ethernet interface, including redundancy and packets.

### Modulator page

On this page, **Modulator** parameters can be monitored and set.

### Demodulator page

On this page, **Demodulator** parameters can be monitored and set.

### IP Encap - Decap Page

This page displays the **IP interface and filter** parameters.

### ACM page

This page displays the ACM control.

### Alarms page

On this page, you can find all alarms and statuses on the device.

### Web Interface page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
