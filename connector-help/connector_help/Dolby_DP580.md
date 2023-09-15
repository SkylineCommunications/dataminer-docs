---
uid: Connector_help_Dolby_DP580
---

# Dolby DP580

The **Dolby Professional Reference Decoder DP580** is a real-time audio decoder and monitoring tool that supports Dolby codecs. This connector allows you to monitor this device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.5.0.5                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

Since most of the parameters for **Dolby Digital** and **Dolby Digital Plus** codecs are similar, they are grouped together in tables on the **Dolby Digital** page. The Dolby Digital page therefore contains information about both Dolby Digital and Dolby Digital Plus audio signal formats.
