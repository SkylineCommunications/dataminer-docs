---
uid: Connector_help_Anacom_AnaSat_C_Serial
---

# AnaCom AnaSat C Serial

The AnaCom AnaSat C Serial connector has been designed to monitor and manage an AnaCom transceiver using serial RS-485 connection via packet mode.

## About

The AnaSat -C VSAT series C-Band transceivers are suited for SCPC, MCPC and DAMA applications, transmitting in the 6 Ghz frequency range and receive in the 4 Ghz range.

This connector uses a serial communication and it has been designed to work using packet mode transmission, through it, its possible to manage and visualize the internal values of the device and stablish an alarming monitor system.

### Version Info

| **Range** | **Description**                 | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version - Serial RS-232 | No                  | No                      |
| 2.0.0.x          | Initial Version - Serial RS-485 | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.0                         |
| 2.0.0.x          | 1.0                         |

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION

- **Baurate:** 1200
- **Databits:** 8
- **Stopbits:** 1
- **Parity: No**
- **FlowControl:** No
- **Bus Address:** 01FF
- **Serial Port:** COM11

## Usage

### General

General page, displays the main information values from the device. Serial Settings and Device Control can be managed through the page buttons contained into this page.

### Analog-to-Digital Converter

This page provide the values information for the sensors and PA Supplies obtained and calculated from the ADC circuit response.

### Offset

Offset page displays the current and default offset values for Tx/Rx Gain, Tx/Rx Output and Tx Input, and the management to set this values.

### Device Values

Device Values page displays the current values for Rx and Tx ranges.

### TX/RX Config

Tx/Rx Config page displays the actual information for RX and TX, and the management to set new values for this.

### Alarms

Alarm page displays the current alarm readings from the ODU obtained by the command ALARM categorized as major and minor, the major alarms cause the external red led on the ODU to begin to flash. From here can be managed the alarm mode control.

The detail of the alarms can be consulted by the use of the page button I/O Alarm based on the REGS array, and the Alarm Details page button based on the FLAGS array from the P command response.
