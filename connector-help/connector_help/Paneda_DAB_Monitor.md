---
uid: Connector_help_Paneda_DAB_Monitor
---

# Paneda DAB Monitor

The Paneda DAB Monitor provides aggregated telemetry information from the DAB monitor.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

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

To make sure the connector can start polling, on the **General** page, fill in the **API Token** with the Bearer token key, and specify the ID of the DAB monitor that should be monitored with the **DAB Monitor ID** parameter.

### Redundancy

The connector uses a redundant connection (HTTP Connection - REDUNDANT). If the first connection fails, the connector will automatically use this connection instead.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

On the **General** page of this connector, you can initialize the **API Token** and **DAB Monitor ID** to be able to poll data. The page also shows the state of the specified monitor.

The **Debug** page contains basic information about the communication with the device, as well as specific logs for every entry.

The **Transport Aggregated Data** page contains aggregated telemetry information from the DAB monitor for the transport layer, as well as a button for clearing the counters.
