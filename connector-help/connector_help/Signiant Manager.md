---
uid: Connector_help_Signiant_Manager
---

# Signiant Manager

The Signiant Manager is responsible for reading and adjusting the data received from the Signiant API, a software for secure file transferring systems. Currently, the device allows the polling of data from the Manager and from the Agent API.

## About

### Version Info

| **Range**            | **Key Features**                                                                                  | **Based on** | **System Impact** |
|----------------------|---------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | \- HTTP request to poll Agents and Resource Control List.- Configurable resource control ceiling. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 14.0.4                 |

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
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

To connect to the API, go to the **General** page of the element, and specify the following credentials:

- *User: apiuser*
- Password: *apiUser01*

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The following data pages are available:

- **General**: This is where you can specify the credentials to connect to the API. The status of the last connection is also shown.
- **Agents**: Displays the Agents List obtained from the API.
- **Resource Controls**: Displays the Resource Controls List obtained from the API. In each row, you can change the "ceiling" setting.
- **HTTP Logger**: Lists the requests made to the API with their status.
