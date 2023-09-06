---
uid: Connector_help_AJA_IPR-10G2-HDMI
---

# AJA IPR-10G2-HDMI

This connector allows you to monitor and control the IPR-10G2-HDMI mini-converter. This device is designed to bridge SMPTE ST 2110 networks to HDMI, with support up to Ultra HD 50p or HD 60p. IPR-10G2-HDMI receives SMPTE ST 2110 audio and video over 10 GigE, and then de-encapsulate the data to output baseband HDMI video. Associated audio from the SMPTE ST 2110 stream is likewise extracted, synchronized, and embedded into the HDMI output.

## About

### Version Info

| **Range**            | **Key Features**                                                                             | **Based on** | **System Impact**                                                                                                                       |
|----------------------|----------------------------------------------------------------------------------------------|--------------|-----------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version                                                                              | \-           | \-                                                                                                                                      |
| 1.0.1.x \[SLC Main\] | Major range introduction to fix parameter types, descriptions, major validator remarks, etc. | 1.0.0.2      | Changes to PIDs/parameter types.Changes to saved parameters/primary keys.Changes to parameter descriptions and discrete display values. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.7.x                  |
| 1.0.1.x   | 2.7.x                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the destination.
- **IP port**: The IP port of the destination (default: *80*).

### Initialization

If the web API is secured with authentication, make sure the **username** and **password** are correctly filled in (via General \> Authentication).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

On the **Authentication** subpage of the **General** page, you can configure the username and password to access the device.

The **Boot Info** page contains all information about the booting of the device.

The **Audio** and **Video** page contain all information about the conversion from SMPTE ST S2110 to HDMI.
