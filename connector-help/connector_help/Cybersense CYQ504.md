---
uid: Connector_help_Cybersense_CYQ504
---

# Cybersense CYQ504

The **cybersense CYQ504** is a serial driver that retrieves 7 parameters from the device.

## about

The driver retrieves the voltages of the 4 ports and 3 general parameters.

the voltages must have a binary value between 0 and 4096.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | VERSION                     |

## Installation and configuration

### Creation

SERIAL CONNECTION:

- Direct connection:

- **Baudrate**: 9600
  - **Databits**: 8
  - **Stopbits**: 1
  - **Parity**: none

- Interface connection:

- **IP address/host**: \[The polling IP of the device.\]
  - **IP port**: \[The IP port of the device. Indicate if required or not. If so, specify default value and range.\]

## Usage

In this section of the driver help, some general info is available about the usage of the Cybersense CYQ504 driver.

### General

Here you find the voltage on the 4 ports and general parameters about the device.

There are also 2 buttons that can be used to reset the error led and to querry the settings of the device.
