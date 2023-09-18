---
uid: Connector_help_Agilent_E4408B
---

# Agilent E4408B

The **Agilent E4408B** is an ESA-L basic spectrum analyzer that can go up to 26.5 GHz.

## About

This connector retrieves data via **TCP/IP** **serial communication**. Commands are sent to the device with or without a response in return.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | A.14.06                     |

## Installation and configuration

### Creation

#### GPIB main connection

This connector uses a serial connection and requires the following input during element creation:

GPIB CONNECTION:

- Interface connection:

  - **Device address**: The polling device address of the device.
  - **I/O API**: The I/O API of the device.

## Usage

### Spectrum Analyzer

This page displays the **Spectrum Analyzer pane** and its parameters, such as **Reference Level**, **Amplitude Scale**, **Start Frequency**, **Stop Frequency**, **Frequency Span**, **Center Frequency**, **Resolution Bandwidth**, **Video Bandwidth**, **Sweeptime** and **Input Attenuation**.

### General

This page shows information such as **Manufacturer**, **Model Number**, **Serial Number** and **Firmware Number.** It also contains the toggle buttons **Display Status**, **Automatic Alignment** and **DMS Spectrum Measurements.**
