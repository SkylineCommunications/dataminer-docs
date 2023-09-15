---
uid: Connector_help_Avcom_of_Virginia_RSA-6500
---

# Avcom of Virginia RSA-6500

The **Avcom of Virginia RSA-6500** is used as a **spectrum analyzer** that measures the magnitude of an input signal versus the frequency within the full frequency range of the instrument. Its primary use is to measure the power of the spectrum of known and unknown signals.

## About

This connector uses a **serial** connection to gather data from the device. Critical information related to the **spectrum analyzer** is displayed on a dedicated Spectrum Analyzer page, where advanced configuration is possible, e.g. adjusting the **Center Frequency** and **Resolution Bandwidth**.

### Version Info

| **Range** | **Description**                                                       | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version, based on version 1.0.0.4 Avcom of Virginia RSA-2500B | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 3.6                         |

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

## Usage

### General

This page contains general information about the device, such as the **Firmware Version**, **Product ID** and **Project ID**.

The page also allows you to change the **RF Input** of the device. A button at the bottom of the page can be used to refresh the data.

### Spectrum Analyzer

This page contains the **spectrum analyzer UI**. This UI displays a graph with the **current center frequency** trace, with various controls that allow you to configure the graph. You can also adjust the **center frequency, frequency span** and **resolution bandwidth** of the device.
