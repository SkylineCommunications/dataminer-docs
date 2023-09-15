---
uid: Connector_help_CEFD_Spectrum_VUE-2
---

# CEFD Spectrum VUE-2

The Spectrum VUE-2 is a next-generation spectrum measurement and analysis unit with an integrated 2-port RF switching capability.

## About

### Version Info

| **Range**            | **Key Features**                                  | **Based On** | **System Impact** |
|----------------------|---------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.                                  | \-           | \-                |
| 1.0.1.x \[SLC Main\] | DataMiner protocol feature for lengthy responses. | 1.0.0.4      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |
| 1.0.1.x   | Unknown                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial IP Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host:** The polling IP of the device.
- **IP port:** The IP port of the device.

## Usage

On the Spectrum Analyzer page of the element, you can find the spectrum analyzer UI. this allows you to view and configure traces from the device using all DMS Spectrum Analysis features. For more information, refer to [Working with spectrum analyzer elements](xref:Working_with_spectrum_analyzer_elements).
