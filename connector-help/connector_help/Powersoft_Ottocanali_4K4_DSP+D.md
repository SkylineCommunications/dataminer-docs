---
uid: Connector_help_Powersoft_Ottocanali_4K4_DSP+D
---

# Powersoft Ottocanali 4K4 DSP+D

The **Ottocanali 4K4** is a flexible and reliable 8-channel power amplifiers with up to a total of 4,000 W at 4ê, ideal for multi-zone applications in small to mid-scale installs. It supports any combination of lo-Z loudspeakers, mono-bridgeable channel pairs and 70V/100V Hi-Z distributed lines with no need for output step-up transformers. It features switchable main/aux signal inputs and offers a wide range of system control, alarms, GPI/O and monitoring functions as well as sound shaping options.

## About

Protocol to monitor **Ottocanali 4K4** 8-channel power amplifiers, that uses a **Serial** connection. It is also required the **Local IP Por**t as 61001 (set by default).

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial Version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.7.6.36                    |

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
  - **Local IP port**: The IP port of the element that connects to the device.

## Usage

### General

General device information (e.g.: Name, Serial number, etc.).

### Alarms

This page displays Channels and device internals parameter status alarms.

### Channel-1

Contains Channel 1 status alarms, as well as channel configuration parameters.

### Channel-2

Contains Channel 2 status alarms, as well as channel configuration parameters.

### Channel-3

Contains Channel 3 status alarms, as well as channel configuration parameters.

### Channel-4

Contains Channel 4 status alarms, as well as channel configuration parameters.

### Channel-5

Contains Channel 5 status alarms, as well as channel configuration parameters.

### Channel-6

Contains Channel 6 status alarms, as well as channel configuration parameters.

### Channel-7

Contains Channel 7 status alarms, as well as channel configuration parameters.

### Channel-8

Contains Channel 8 status alarms, as well as channel configuration parameters.

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
