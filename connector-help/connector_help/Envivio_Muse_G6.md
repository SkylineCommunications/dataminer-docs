---
uid: Connector_help_Envivio_Muse_G6
---

# Envivio Muse G6

This connector can be used in combination with an **Envivio Muse G6** encoder.

## About

This connector uses an HTTP connection to get and set the configuration file of the Envivio Muse G6.

### Version Info

| **Range** | **Description**                             | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version (Config Import/Export only) | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 5.00.06 (041)               |

## Installation and configuration

### Creation

#### HTTP Main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination, by default *80*.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

## Usage

### Config

This page has two sections:

- **Export**: With the export feature, you can save (backup) the entire configuration of the Envivio Muse G6 to an XML file.
- **Import**: With the import feature, you can easily configure the Envivio Muse G6 by uploading a configuration XML file.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
