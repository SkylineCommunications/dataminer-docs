---
uid: Connector_help_DTC_PRORXD
---

# DTC PRORXD

The PRORXD is a COFDM receiver decoder with dual optional receive and HD decoding capability. The PRORXD 1RU is available with 2-way or 4-way maximum ratio combining RF inputs, while the 2RU version is available with 6-way or 8-way combination.

## About

This protocol can monitor status parameters of a Cobham PRORXD device. It also allows the user to configure global configuration parameters and presets.
HTTP requests are used to retrieve the device information.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### HTTP connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP.
- **IP port**: The IP port of the destination: *80*.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

## Usage

### General

This page displays general information on the device, such as the **Unit Name**, **H264 Software Version/Serial Number**, **Build Number** and **CPU Temperature**.

It is possible to create an image of the current spectrum of antennas A and B of the device, for the channels 1 to 8. For this to work, the **Thumbnail Status** has to be set to *Enabled*. Also, a **Grid.jpg** file has to be placed in the following location: **C:\Skyline DataMiner\Documents\DTC PRORXD**

### Status

This page displays status parameters of the **Demodulator**, **Genlock** and **ASI**.

### Services

This page displays the status of the Services 1 and 2. It also contains the Service List names.

### Global Settings

On this page, you can view and configure the global configuration parameters: **General**, **Downconverter**, **IP**, **Streaming**, **OSD Settings** and **Genlock settings**.

### Configuration

On this page, you can view and configure the **Presets**, in the tables **General Configuration**, **IFB** and **Decoder** and **Demodulator Configuration**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
