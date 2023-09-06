---
uid: Connector_help_2WCOM_MoIN_Controller
---

# 2WCOM MoIN Controller

The 2WCOM MoIN (Multimedia over IP Network) software solution brings controlling, transcoding, and distribution of IP signals all in one place. This DataMiner connector can be used to monitor and administer such MoIN containers.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | v2.3.0                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

This connector uses HTTP connections and requires the input detailed below during element creation.

#### HTTP Connection - Primary

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

#### HTTP Connection - Secondary

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Redundancy

The element is configured with a redundant connection. When the primary connection is no longer responding (i.e. a timeout occurs on this connection), DataMiner will automatically switch to the secondary connection (and vice versa).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The **General** page contains a table that lists all MoIN containers that are currently available. In addition to their status, some other information is shown such as the IP addresses and the Docker image that was used to create the container. The table contains buttons that can be used to start, stop, delete, and recreate a container. The **Create MoIN** button at the bottom of the page opens a window that allows you to configure and create a new MoIN container.

The **Images** page shows a list of all Docker images that are currently available in the system. These images can be used to create a new MoIN container.

The **Interfaces** page lists all system and environment interfaces.
