---
uid: Connector_help_Rohde_Schwarz_FSV
---

# Rohde Schwarz FSV

The **Rohde Schwarz FSV** is a spectrum analyzer driver.

## About

The **Rohde Schwarz FSV** driver interfaces with the spectrum analyzer using serial commands implementing the SCPI protocol.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | 2.30                        |

## Installation and configuration

### Creation

#### Serial Main connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device, by default *5025*.

## Usage

### Spectrum Analyzer

This page contains DataMiner's default **Spectrum Analysis** component.

### General

This page contains basic device information such as the **Manufacturer**, **Model**, **Serial Number** and **Firmware Version** of the device.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
