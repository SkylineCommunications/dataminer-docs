---
uid: Connector_help_Cobham_PRORXB
---

# Cobham PRORXB

The Cobham PRORXB is a COFDM receiver that works with the next generation of H.264 wireless camera systems. It incorporates on-screen display diagnostics, IP control and optional IP streaming video. All DVB-T 6/7/8 MHz modes are supported, plus optional Cobham Narrowband.

This protocol can monitor status parameters of a Cobham PRORXB device. It also allows the user to configure global configuration parameters and presets.

## About

HTTP requests are used to retrieve the device information.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                            |
|------------------|--------------------------------------------------------|
| 1.0.0.x          | Software version 2.0 H264 Decoder software version 1.3 |

## Installation and configuration

### Creation

#### HTTP connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP.
- **IP port**: The IP port of the destination: *80*.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

## Usage

### General

This page displays the **Unit Name** and the **H264 Decoder Software Version/Serial Number**.

### Status

This page displays status parameters of **Demod 1**, **Service 1**, **Genlock**, **ASI** and **IP**.

### Global Settings

On this page, you can view and configure the global configuration parameters: **General**, **Downconverter**, **IP**, **Streaming**, **OSD Settings** and **Genlock settings**.

### Configuration

On this page, you can view and configure the **Presets**, in the tables **Basic**, **Demod 1** and **Decoder 1 Configuration**.

### Web Interface

This page displays the web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
