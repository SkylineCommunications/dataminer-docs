---
uid: Connector_help_Anritsu_Spectrum_Master_MS2721A
---

# Anritsu Spectrum Master MS2721A

The MS2721A was the first fully-functional handheld spectrum analyzer designed to conduct highly accurate analysis on the new wave of wireless LAN and cellular signals, including 802.11a, 3G, ultra-wideband, WiMAX, and wireless medical patient monitoring systems. The MS2721A was replaced with model MS2721B.

## About

This connector retrieves data via **GPIB**. Commands are sent to the device with or without a response in return.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 2.1.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 2.1.0.x          | Unknown                     |

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

This page displays the **Spectrum Analyzer pane** and its related parameters, such as **Reference Level**, **Amplitude Scale**, **Start Frequency**, **Stop Frequency**, **Frequency Span**, **Center Frequency**, **Resolution Bandwidth**, **Video Bandwidth**, **Sweeptime** and **Input Attenuation**.

### General

This page shows information such as **Manufacturer**, **Model**, **Serial Number**, **Firmware Version** and **Sweep Time.**

### Web Page

This page displays the web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
