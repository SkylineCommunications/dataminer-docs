---
uid: Connector_help_Nevion_TNS460
---

# Nevion TNS460

The Nevion TNS460 HD/SD SDI monitor is used for continuous monitoring of uncompressed video signals.

This connector uses an HTTP connection to retrieve information from the device and send commands to the device. The commands sent to the device are based on its communication protocol, the TXP - T-VIPS XML protocol.

The layout of the connector mirrors the web interface of the device as much as possible. For more information about this device, refer to <https://nevion.com/products/tns460/>.

## About

### Version Info

| **Range**            | **Description**                                                        | **DCF Integration** | **Cassandra Compliant** |
|----------------------|------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version.                                                       | No                  | Yes                     |
| 1.0.1.x \[SLC Main\] | Tables using naming and display key.                                   | No                  | Yes                     |
| 2.0.0.x              | Compatible with DataMiner 7.5 only (not compatible with DataMiner 10). | No                  | Yes                     |
| 2.0.1.x              | New SNMP connection for trap handling.                                 | No                  | Yes                     |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Sw Version 1.8.10      |
| 1.0.1.x   | Sw Version 1.8.10      |
| 2.0.0.x   | Sw Version 1.8.10      |
| 2.0.1.x   | Sw Version 1.8.10      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination, by default *80.*
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

#### SNMP Connection

This connector uses an SNMP connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the destination.
- **IP port**: The IP port of the destination, by default 161*.*

### Initialization

Once the connection has been configured, data will be polled from the device.

To be able to set new values on the device, the **Username** and **Password** must be set via the **General** page.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

### General

On this page, you can set the **Username** and **Password**.

### Status - Current Alarms

This page displays the current alarms on the device, as well as information about the configured severity of each one of the elements that are part of this device.

### Device Info

This page displays product info, time settings, reference settings, network-related settings, and also alarm-related settings.

### Tree Control

This page contains a tree control with information about the SDI monitors.

### SDI Monitors - Main/Advanced

This page displays information related to the main and advanced settings.

### SDI Monitors - Audio

This page displays information related to the audio status.

### SDI Monitors - Loudness

This page displays information related to the loudness group settings and status.

### SDI Monitors - SD VBI

This page displays information related to the SD VBI settings and status.

### SDI Monitors - ANC

This page displays information related to the ANC status.

### SDI Monitors - Templates

This page displays information related to the video, ANC, audio, and VBI templates.

### SDI Monitors - SLA

This page displays information related to the SLA status.

### SDI Ports

This page displays the status of the SDI In and SDI Out sources.

### SD VBI

This page displays information related to the SD VBI types.

### Maps - VP

This page displays the port map.

### Maps - IP

This page displays the IP-related maps.

### Maps - Emb

This page displays the audio and VBI maps.
