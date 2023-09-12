---
uid: Connector_help_Kronback_Tracers_X16
---

# Kronback Tracers X16

The Kronback Tracers X16 is a spectrum connector that polls and displays real-time and history spectrum analysis. It polls the device over a serial connection.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.9.8                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection - Main

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

#### SNMP Connection - Info

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string is used when reading values from the device (default: *public*).
- **Set community string**: The community string is used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### Spectrum Analyzer

On this page, you can configure the spectrum analyzer and view the same real-time trace as would be visible on the analyzer itself.

### Device Info

This page displays the **Serial Number**, **Firmware**, **FPGA**, and **Hardware** version. It also allows you to edit the trace settings parameters.

### Channel

Here you can select **Active Input** from the available channels and specify the **Compensation Level** to add to the trace.
