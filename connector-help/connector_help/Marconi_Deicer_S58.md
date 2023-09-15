---
uid: Connector_help_Marconi_Deicer_S58
---

# Marconi Deicer S58

The **Marconi Deicer S58** is an anti-icing system.

## About

The **Marconi Deicer S58** will update its monitoring parameters by receiving **Smart-Serial** data.

### Version Info

| **Range** | **Description** |
|------------------|-----------------|
| 1.0.0.x          | Initial version |

## Installation and configuration

### Creation

This connector uses a Smart-Serial connection and requires the following input during element creation:

**SMART-SERIAL CONNECTION:**

- Direct connection:

- **Baudrate:** Baudrate specified in the manual of the device. E.g. 9600
  - **Databits:** Databits specified in the manual of the device. E.g. 7
  - **Stopbits:** Stopbits specified in the manual of the device. E.g. 1
  - **Parity:** Parity specified in the manual of the device. E.g. No
  - **FlowControl:** FlowControl specified in the manual of the device. E.g. No

- Inteface connection:

- **IP address/host:** The polling IP of the device.
  - **IP port:** The IP port of the device.

## Usage

### General

Default page with all monitoring parameters.

### Connection

In the connection page, the user can see how long ago data from the device was received.

It is also possible to define when the element goes into **Timed Out** after a specified time.
