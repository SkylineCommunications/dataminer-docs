---
uid: Connector_help_directOut_montone.42
---

# directOut montone.42

The **Montone.42** is an audio-over-IP device used in professional Ethernet-based audio transmission environments. It supports redundant audio streaming and integrates RAVENNA networking technology.

The **directOut montone.42** connector provides information related to the input and output streams. Each stream has a custom configuration, and it has two available ports to have a linked connection.

## About

### Version Info

| **Range**            | **Key Features**               | **Based on** | **System Impact** |
|----------------------|--------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version                | \-           | \-                |
| 1.1.0.x              | Supports new firmware changes. | 1.0.0.4      | \-                |
| 1.1.1.x \[SLC Main\] | Supports DCF                   | 1.1.0.7      |                   |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.1.0.x   | RAV.IO module          |
| 1.1.1.x   | RAV.IO module          |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.1.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

No extra configuration is needed.

### Redundancy

From version 1.1.0.4 onwards, there is a mechanism in this connector that will detect when the element is in timeout and automatically switch over to the other IP address. The connector will use the parameters for **Port 1 IP** and **Port 2 IP** to decide which IP to switch to, based on the actively polled IP address.

On the **Network** subpage, the **Actively Polled IP** parameter will show the IP address that is currently being polled by DataMiner.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector consists of the following data pages:

- **General:** Contains general information about the device.

- As of range 1.1.0.x, there is a configurable parameter to switch between the MONTONE.42 module and the RAV.IO module.

- **Advanced:** Contains PTP and advanced network settings.

- **Input Streams:** Contains input stream configuration data and ports data (for port 1 and 2).

- **Output Streams:** Contains output stream configuration data and ports data (for port 1 and 2).

- **PTP Config:** Contains PTP clock configuration parameters (accuracy, delays, timeouts and basic settings).

- **PTP Status:** Contains PTP clock status parameters (accuracy, offset and priorities).

- **Network Advanced Settings:** Contains the user-configurable network parameters (ports and announcements).

- **Web Interface:** Contains the web interface of the device.
