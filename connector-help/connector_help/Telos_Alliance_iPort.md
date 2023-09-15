---
uid: Connector_help_Telos_Alliance_iPort
---

# Telos Alliance iPort

The Telos Alliance iPort is an audio gateway. This connector can be used to monitor and control this device.

## About

The connector uses SNMP and serial communication (based on the Livewire protocol) to retrieve information from the device.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.1.0j                      |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

#### Serial "Serial Connection" Connection

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

This page displays general information on the device.

### Source page

This page contains the **Sources table**, with stream status and stream address information.

### Encoder page

This page contains the **Encoder table**, with information on the input gain, address, source name, number of channels, operational state, receive state and audio state.

### V-Mixer/V-Mode page

This page contains the **VMix** and **VMode tables**, with information on the input gain, address, source name and number of channels.

### Meter Data page

This page contains the **Input MTR** and **Outputs MTR tables**, with their respective PEEK and RMS values.

### Input Detection and Output Detection pages

These pages allow you to configure the clip and silence level of the available channels.
