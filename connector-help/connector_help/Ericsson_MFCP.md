---
uid: Connector_help_Ericsson_MFCP
---

# Ericsson MFCP

The **Ericsson MFCP** (MediaFirst Content Processing) is a UHD (4K) HEVC professional decoder specifically designed to meet the needs of the contribution market.

This MFCP Application can decode UHD (4K) HEVC compressed streams, whether 4:2:0 or 4:2:2, 8-bit or 10-bit, and produce an uncompressed output via four 3G outputs.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 10.1                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination, by default port 80.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

This connector is capable of fully monitoring the Ericsson MediaFirst Content Processing platform, including alarms and servers. The connector uses a REST Web API to send and receive data to and from the system, using the JSON or XML formats.

Below you can find more detailed information about specific pages of the connector.

### Servers

This page displays the following tables:

- **Servers**: Lists all the server nodes in the system.
- **Software**: Lists all the software installed and running on each server.

Page buttons provide access to the following subpages:

- **Memory and CPU**: Includes detailed information about the server memory and CPU statistics.
- **Input and Output**: Includes detailed information about the server data input and data output traffic statistics.
- **Disks**: Includes detailed information about the server disk statistics.
- **Network**: Includes detailed information about the server network statistics.

### Services

This page displays the following tables:

- **Services**: Lists all the services in the system with State, Type and Name information, and allows you to perform the following actions:

- **Assign Server**: Assigns a server to a service.
  - **Remove Servers**: Removes all servers from a service.
  - **Start**: Starts the selected service.
  - **Stop**: Stops the selected service.

- **Assigned Servers**: Lists all the servers assigned to each service.

### Alarms

This page displays the **Alarms** table, which includes parameters such as the alarm ID, severity, description, and impacted servers and services.

A page button provides access to the **History Alarms** subpage, with detailed information about past alarms.
