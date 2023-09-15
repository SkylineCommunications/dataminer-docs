---
uid: Connector_help_Keysight_N5173B
---

# Keysight N5173B

The Keysight N5173B connector will interact with Keysight X-Series microwave analog signal generators using a LAN interface so that you can use DataMiner to monitor and control this series of devices. N5173B EXG X-Series microwave analog signal generators offer 9 kHz to 40 GHz frequency coverage.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**         |
|-----------|--------------------------------|
| 1.0.0.x   | B.01.96 (SCPI version: 1997.0) |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Connection - Main

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

Interface connection:

  - **Type of port:** TCP/IP
- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device. Default: *5025.*

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

SCPI commands (Standard Commands for Programmable Instruments) are used to retrieve the device information. To see the actual traffic between the element and the device, a built-in DataMiner tool called Stream Viewer can be used. You can access it by right-clicking the element in the Surveyor and selecting View \> Stream Viewer.

### General Page

The General page shows basic device information and contains general configuration parameters related to **System Settings**, **Presets**, and **Diagnostics**.

### Frequency Page

On this page, you can view and modify frequency-related parameters. The parameters related to **Channel Band** can also be found here.

### Power Page

On this page, you can view and modify power-related parameters. The parameters related to **Attenuation** and **Automatic Leveling Control (ALC)** can also be found here.

### Errors Page

This page contains the Errors table. You can limit the number of errors in the table by adjusting the **Max Errors Count** or by changing the **Max Error Duration**. Both settings are located at the top of this page.
