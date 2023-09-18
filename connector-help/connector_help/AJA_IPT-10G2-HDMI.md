---
uid: Connector_help_AJA_IPT-10G2-HDMI
---

# AJA IPT-10G2-HDMI

This connector can be used to monitor and control the **IPT-10G2-HDMI** mini-converter. The AJA IPT-10G2-HDMI is a device that allows the conversion of HDMI video signals into an IP stream that can be transmitted over an Ethernet network. This device is commonly used in professional video production environments where high-quality video streams need to be distributed over long distances.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.7.x                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection - Main

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

### Initialization

If the web API is secured with authentication, make sure the **username** and **password** are correctly filled in (via General \> Authentication).

### Redundancy

No redundancy is defined in the connector.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

On the **Authentication** subpage of the **General** page, you can configure the username and password to access the device.

The **Boot Info** page contains all information about the booting of the device.

The Audio and Video page contain all information about the conversion from SMPTE ST S2110 to HDMI.
