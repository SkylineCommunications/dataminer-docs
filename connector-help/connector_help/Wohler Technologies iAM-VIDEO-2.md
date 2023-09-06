---
uid: Connector_help_Wohler_Technologies_iAM-VIDEO-2
---

# Wohler Technologies iAM-VIDEO-2

The Wohler iAM-VIDEO-2 is a multichannel multi-source audio/video monitor with multiple standard copper connections and multiple SFP module options facilitating high-density coax and optical fiber connections.

The product can be configured with **presets**, which are complete monitoring configurations.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.3.0                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

This driver displays the **Groups**, **Sub-Groups** and **Presets**,as well as the **Cluster and Meters** information associated with each **Preset.**
