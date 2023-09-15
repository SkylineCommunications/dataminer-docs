---
uid: Connector_help_Agilent_N1996A
---

# Agilent N1996A

The **Agilent N1996A** is a spectrum analyzer device.

This connector interfaces with the spectrum analyzer of the same name, and allows the user to monitor the spectrum of any signal connected to the spectrum analyzer. In addition, the connector allows basic configuration of the device.

## About

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |
| 1.1.0.x          | Refactor connector | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.1.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device, by default *5025*.

## Usage

### Spectrum Analyzer

This page contains DataMiner's default **Spectrum Analysis** component.

### General

This page contains basic device information such as the **Manufacturer**, **Model**, **Serial Number**, and **Firmware Version** of the device.
