---
uid: Connector_help_Rohde_Schwarz_NRPxxS(N)
---

# Rohde Schwarz NRPxxS(N)

This sensor measures the power of a given frequency. It is possible to configure the frequency, resolution, aperture time, average count, averaging filter mode and the terminal control mode to obtain the measured power, using this connector.

## About

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | True                    |

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

### General

In this page it is possible to set the configuration parameters for the measurement calculation, by default these parameters will have the following values:

- **Frequency**: 10 MHz
- **Resolution:** 3
- **Aperture Time:** 0.02 ms
- **Average Count:** On
- **Averaging Filter Mode:** Resolution
- **Terminal Control Mode:** Repeat

Also it is possible to configure the alarm threshold for the power measurement results, either if it is the one in dBm or the one in nanowatts.Extra functions that are available in this page: **Zero Calibration**, **Reset Sensor** and **Reboot.Note that if Reset Sensor or Reboot are activated, the configuration parameters must be set again, otherwise the measurement result will be "Not Available".**
