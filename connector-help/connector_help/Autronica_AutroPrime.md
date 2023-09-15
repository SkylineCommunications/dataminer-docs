---
uid: Connector_help_Autronica_AutroPrime
---

# Autronica AutroPrime

This protocol provides information about the system status of the device, which is a fire detection system, and about the status of the different available detectors. It is also possible to configure which detectors there are for each register address and how these should be interpreted, i.e. as a loop, detector, FAD or FPE.

## About

When the request table has been configured, all the information about each detector is automatically added to the relevant tables.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device.
  - **Stopbits**: Stopbits specified in the manual of the device.
  - **Parity**: Parity specified in the manual of the device.
  - **FlowControl**: FlowControl specified in the manual of the device.
- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

## Usage

### System Status

This page displays the status of the device. There is an extra value, **Watchdog**, which should change every 2 minutes. If it does not change, the device is not responding properly.

### Requests

This page displays the request table, which allows you to configure the way data will be interpreted for each of the possible registers (30006-30049).

To request data from a register, fill in the **MSB** (Most Significant Byte) or the **LSB** (Least Significant Byte) (Naming is optional). After the data is requested, the information will be displayed in the relevant tables (Loop, Detector, FAD and FPE).

Note: When a detector has been added to a table, its information will be automatically updated every 20 seconds.

### Commands

This page displays the commands table. With this table, you can perform sets on the device using the following commands:

- Silence
- Reset
- Set System Time/Date
- Detector Disable
- Detector Enable
- FPE Activate
- FPE Deactivate
- FPE Disable
- FPE Enable
