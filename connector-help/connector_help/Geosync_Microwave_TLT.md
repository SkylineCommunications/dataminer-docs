---
uid: Connector_help_Geosync_Microwave_TLT
---

# Geosync Microwave TLT

The **Geosync Microwave TLT** is a test translator.

## About

This is a **serial** connector for the **Geosync Microwave TLT**.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | R1.01 05/21/15              |

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **IP port**: The port of the connected device, e.g. *23.*
- **Bus address**: The bus address of the connected device. The range is defined from *64* to *95*.

## Usage

### General Page

This page displays parameters such as **Attenuation**, **Control Mode**, **Reference Frequency Adjustment**, etc.

### System Info

This page displays alarm parameters and power measurements, such as **12V Power Supply**, **Power Supply Status**, **Nonvolatile Memory Status**, etc.

### Log

This page displays the log table of the device, with the following parameters: **Event Number**, **Date/Time** and **Event**.

### Serial Communication

This page displays the current serial communication settings of the device: **Address**, **Baudrate**, **Parity** and **Bus Format**.
