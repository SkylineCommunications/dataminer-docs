---
uid: Connector_help_Vitec_MGW_Prism
---

# Vitec MGW Prism

The Vitec MGW Prism is an IPTV transcoder for over-the-top services and mobile streaming.

This driver allows you to monitor general parameters of the Vitec MGW Prism as well as detailed information about each channel included in the network. It also allows you to configure settings such as the current Source IP Address, Port Number, SSMP State, the running state of the channels, and more.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Kiwi.10.8.47259        |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Device address**: The device address (default: *ByPassProxy*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the following data pages:

- **General**: Contains parameters related to the different servers, software, system names, memory and CPU usage.
- **Command**: Contains general information about every channel, and allows you to configure the **current state** of each channel.
- **TS Input**: Allows you to view and configure the IP address, port number and SNMP state for each channel.
- **IO**: Contains information about the input and output mode. Also contains page buttons that lead to the Input Common, HLS Input, UDP Input, Input OTT, and Other Data subpages.
- **Input PIDs**: Displays the audio and video PIDs, as well as detailed information about audio and video. A page button provides access to information on the Audio and Video Streams.
- **Network Setup**: Contains network adapter parameters, as well as VLAN information about speed, states, and addresses. The VPN page button will take you to the VPN configuration page.
