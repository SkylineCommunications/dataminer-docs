---
uid: Connector_help_All_In_Media_RAPID
---

# All In Media RAPID

The **All In Media RAPID** connector displays the alarm table of the corresponding device.

## About

The connector uses **HTTP** to retrieve the content of the alarm table.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 3.5.0.7469                  |

## Installation and configuration

### Creation

#### HTTP \[Main\] connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: 9000
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

## Usage

### General

This page displays the alarm table.

### Web Interface

This page displays the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
