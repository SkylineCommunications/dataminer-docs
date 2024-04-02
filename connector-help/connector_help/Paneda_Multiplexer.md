---
uid: Connector_help_Paneda_Multiplexer
---

# Paneda Multiplexer

The Paneda multiplexer looks at the multiplexing compartment for each provider.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | h-2024-02-09           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection - MAIN

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

#### HTTP Connection - REDUNDANT

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Initialization

To make sure the connector can start polling, on the **General** page, fill in the **API Token** with the Bearer token key.

After you have filled in this token, and the first call has been performed, select a provider with the parameter **Provider**. The other calls will only work when this has been done.

### Redundancy

The connector uses a redundant connection (HTTP Connection - REDUNDANT). If the first connection fails, the connector will automatically use this connection instead.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

On the **General** page of this connector, you can configure the **API Token** and **Provider** to access the device.

The **Debug** page contains basic information about the communication with the device, as well as specific logs for every entry.

The other pages contain status information for the multiplexer and general information.
