---
uid: Connector_help_Snell_Wilcox_CVR900
---

# Snell Wilcox CVR900

The Snell Wilcox CVR900 is an HD & SD standards converter and format converter with synchronization capability. It provides multi-rate 3Gb/s HD/SD inputs and outputs and is capable of providing upconversion, downconversion and crossconversion.

It also handles embedded, AES and analog audio. It can do aspect ratio conversion and color space conversion.

## About

### Version Info

| **Range**            | **Key Features**                                                      | **Based on** | **System Impact** |
|----------------------|-----------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version, enables monitoring and setting of device parameters. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.00.a                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.
- **IP port**: The IP port of the destination (default: *161*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *public*).

### Initialization

No extra configuration is needed.

## How to use

On the **General** page, you can find general information about the device. Alarm monitoring can be enabled on the parameters related to **signaling and hardware** to ensure that signal drops are noticed quickly.

On the **Initial Setup** page, you can set the most important IP settings on the device. This page also contains information on the front panel and the version.

The other pages of the connector contain the settings related to the names of the pages. For example, the Video page contains the settings related to the video source.
