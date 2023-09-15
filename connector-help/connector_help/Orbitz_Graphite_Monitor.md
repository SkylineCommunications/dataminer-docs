---
uid: Connector_help_Orbitz_Graphite_Monitor
---

# Orbitz Graphite Monitor

The Orbitz Graphite Monitor is a device that stores numeric time-series data and renders graphs of this data on demand.

This connector allows you to read the time-series data from the device via an HTTP connection.

## About

### Version Info

| **Range**            | **Key Features**                             | **Based on** | **System Impact** |
|----------------------|----------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version (minimum .NET Framework 4.0) | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | v1.1.3                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses a HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Device address**: The device address (default: *ByPassProxy*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

On the **General** page, you can find the **Polling Status: Tree Structure** and **Polling Status: Values**.

The **Tree Control** page contains a tree overview with all the nodes received from the device. When the parent node of a metric is selected, its values are displayed in the extra tab **Values**.
