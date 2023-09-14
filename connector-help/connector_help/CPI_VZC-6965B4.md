---
uid: Connector_help_CPI_VZC-6965B4
---

# CPI VZC-6965B4

The **CPI VZC-6965B4** Traveling Wave Tube (TWT) High Power Amplifier (HPA) series is designed for satellite communication earth stations operating in the C-band frequency range.
The 2.25 kW TWT HPA utilizes a 2250 Watt rated power, wideband TWT to produce radio frequency (RF) power output of up to 2000 Watts at the output waveguide of the HPA.

## About

This connector uses a serial connection to send data to and get data from the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | VZ2                         |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600*.
  - **Databits**: Databits specified in the manual of the device, e.g. *7*.
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1*.
  - **Parity**: Parity specified in the manual of the device.
  - **FlowControl**: FlowControl specified in the manual of the device.

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device.

## Usage

### General

This page displays the general info about the device, such as:

- HPA Version
- Attenuator Value
- RF O/P Power
- Heater Voltage and Current
- Helix Voltage and Current

### Status

This page shows the overall device status, such as:

- Summary Fault
- ALC Status
- HPA Status
- Fault Recycle Mode
- RF Inhibit
