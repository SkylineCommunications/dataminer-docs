---
uid: Connector_help_CEFD_SDM-300A_Serial_Straight
---

# CEFD SDM-300A Serial Straight

## About

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 2.0.0.x          | Initial Version | No                  | False                   |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 2.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device. (default: 7)
  - **Stopbits**: Stopbits specified in the manual of the device. (default: 2)
  - **Parity**: Parity specified in the manual of the device. (default: even)
  - **FlowControl**: FlowControl specified in the manual of the device. (default: )
- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device. (Default: 31) (Range: 255 - 1)

## Usage

### Main View

Here you can see the status from the modulator, demodulator also some info about the Tx and Rx.

### General

Here you can find the serial numbers of the device and the installed card, also the time and date on the device.

Also the modem operation mode and system mode, there are several buttons on this page to other pages.

### Alarm

On this page are all the alarms displayed related to the modulator and demodulator.

### Modulator

On this page you find all the information about the modulator.

### Demodulator

Here you can see the information from the demodulator.

### Interface

On this page you find more information about the interface and connector type for the Rx and Tx.

### AUPC

Here you can see parameters related to the AUPC.

### Memorised Alarm

On this page you can see the memorised alarm related to the modulator and demodulator.
