---
uid: Connector_help_Keysight_N934xC
---

# Keysight N934xC

This connector can be used for three types of handheld spectrum analyzers: **N9342C** (7 GHz), **N9343C** (13.6 GHz), and **N9344C** (20 GHz).

The connector interfaces with the spectrum analyzer and allows you to monitor the spectrum of any signal connected to the spectrum analyzer. You can also use it for the basic configuration of the device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | A.06.27                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device, by default *5025*.

## How to Use

### General

This page contains basic device information such as the **Manufacturer**, **Model**, **Serial Number**, and **Firmware Version** of the device, as well as the **DMS Spectrum Measurements** toggle button, which determines whether measurements are initiated from the DMA or not.

### Spectrum Analyzer

This page contains DataMiner's default Spectrum Analysis component. In addition to the default functionalities available in all spectrum analyzer elements, it allows you to configure the following parameters:

- **Reference Level**
- **Reference Scale**
- **Start & Stop Frequency**
- **Frequency Span**
- **Center Frequency**
- **Resolution Bandwidth**
- **Video Bandwidth**
- **Sweep Time**
- **Input Attenuation**
