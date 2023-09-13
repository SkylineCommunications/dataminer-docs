---
uid: Connector_help_Anritsu_MS27101A
---

# Anritsu MS27101A

The Anritsu MS27101A is a spectrum driver that polls and displays the real-time trace.

## About

The driver polls the device over a serial connection.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | V2017.12.1                  |

## Installation and configuration

### Creation

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

## Usage

### Spectrum Analyzer

On this page, you can configure the spectrum analyzer and view the same real-time trace as would be visible on the analyzer itself.

### General

This page displays the Manufacturer, Model Number, Serial Number and Firmware Package Number.

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
