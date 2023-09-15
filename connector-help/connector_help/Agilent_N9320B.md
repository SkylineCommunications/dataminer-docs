---
uid: Connector_help_Agilent_N9320B
---

# Agilent N9320B

The **Agilent N9320B** is a spectrum analyzer that can go up to 3 GHz.

## About

The **Agilent N9320B** connector interfaces with the spectrum analyzer of the same name, and allows the user to monitor the spectrum of any signal connected to the spectrum analyzer. In addition, the connector allows for basic configuration of the device.

Ranges of the connector

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device, by default *5025*.
- **Bus address:** The bus address of the device. This can be any number from *0* to *32*.

## Usage

### General

This page contains basic device information such as the **Manufacturer**, **Model**, **Serial Number** and **Firmware Version** of the device. It also contains two toggle buttons: **Display Status** and **DMS Spectrum Measurements**.

In version 1.0.0.2, an additional toggle button **VGA Output Status** is included.

### Spectrum Analyzer

This page contains DataMiner's default **Spectrum Analysis** component. In addition to the default functionalities available in all spectrum analyzer elements, it allows you to configure the following parameters:

- **Reference Level**
- **Reference Scale**
- **Start & Stop Frequency**
- **Frequency Span**
- **Center Frequency**
- **Resolution Bandwidth**
- **Video Bandwidth**
- **Sweep Time**
- **Input Attenuation**
