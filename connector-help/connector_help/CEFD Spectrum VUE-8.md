---
uid: Connector_help_CEFD_Spectrum_VUE-8
---

# CEFD Spectrum VUE-8

The Spectrum VUE-8 is a next-generation spectrum measurement and analysis unit with integrated 8-port RF switching capability.

## About

### Version Info

| **Range**            | **Key Features**                                  | **Based On** | **System Impact** |
|----------------------|---------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.                                  | \-           | \-                |
| 1.0.1.x \[SLC Main\] | DataMiner protocol feature for lengthy responses. | 1.0.0.6      | \-                |

### Product Info

| **Range** | **Supported Firmware**                                   |
|-----------|----------------------------------------------------------|
| 1.0.0.x   | Firmware version: 3.1Software version: 3.1.1-6, 3.1.23-1 |
| 1.0.1.x   | Firmware version: 3.1Software version: 3.1.1-6, 3.1.23-1 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | DMS Spectrum Analysis | \-                      |
| 1.0.1.x   | No                  | Yes                     | DMS Spectrum Analysis | \-                      |

## Configuration

### Connections

#### Serial IP Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host:** The polling IP of the device.
- **IP port:** The IP port of the device.

## Usage

### Spectrum Analyzer Page

This page contains the spectrum analyzer interface and allows you to view and configure traces from the device using all DMS Spectrum Analysis features.
