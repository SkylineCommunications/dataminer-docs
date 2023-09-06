---
uid: Connector_help_Keysight_N934xC
---

# Keysight N934xC

The **Keysight N934xC** protocol is a driver that can be used for three types of handheld spectrum analyzers: **N9342C** (7 GHz), **N9343C** (13.6 GHz), **N9344C** (20 GHz).

## About

The ****Keysight N934xC**** driver interfaces with the spectrum analyzer of the same name, and allows the user to monitor the spectrum of any signal connected to the spectrum analyzer. In addition, the driver allows for basic configuration of the device.

Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | Yes                 | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | A.06.27                     |

## Installation and configuration

### Creation

#### Serial main connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device, by default *5025*.

## Usage

### General

This page contains basic device information such as the **Manufacturer**, **Model**, **Serial Number** and **Firmware Version** of the device. It also contains a toggle button: **DMS Spectrum Measurements**.

### Spectrum Analyzer

This page contains DataMiner'sdefault **Spectrum Analysis** component. In addition to the default functionalities available in all spectrum analyzer elements, it allows you to configure the following parameters:

- **Reference Level**
- **Reference Scale**
- **Start & Stop Frequency**
- **Frequency Span**
- **Center Frequency**
- **Resolution Bandwidth**
- **Video Bandwidth**
- **Sweep Time**
- **Input Attenuation**
