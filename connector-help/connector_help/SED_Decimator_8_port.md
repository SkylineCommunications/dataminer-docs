---
uid: Connector_help_SED_Decimator_8_port
---

# SED Decimator 8 port

The SED Decimator 8 port enables low-cost spectrum measurement and analysis. It contains 8 user-selectable inputs.

## About

This connector is used to monitor and control the spectrum analyzer using the proprietary SED Decimator API, which makes use of a **TCP/IP** connection.

### Version Info

| **Range** | **Description**                                                   | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.8          | Span frequencies bigger than 52 MHz up to 1200 MHz are supported. | No                  | Yes                     |

### Supported firmware version

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 3.0.19-1                    |

## Installation and configuration

### Creation

#### Serial connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the destination, which is configured to always be *9784*.
- **Bus address**: Not required.

## Usage

### Spectrum Analyzer page

This page contains the spectrum analyzer interface and allows the user to see and configure traces from the device using all DMS Spectrum Analysis features.

### General page

This page contains general parameters such as the voltage, and global status parameters such as **Input Status**. With the **Active Switch** parameter, you can select the used input.

## Notes

Since it is not possible to retrieve the center frequency, frequency span or resolution bandwidth, from protocol version 1.0.0.7 onwards, default values are set after startup to initiate the communication. Earlier protocol versions required these parameters to be set using DataMiner's "Multiple set" feature. The default values are *1550 MHz* for the center frequency, *15885 Hz* for the span and *100 Hz* for the resolution bandwith.
