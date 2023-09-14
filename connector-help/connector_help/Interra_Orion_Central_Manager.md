---
uid: Connector_help_Interra_Orion_Central_Manager
---

# Interra Orion Central Manager

Orion Central Manager is a solution that gathers data from underlying Orion probes. This is used to monitor channel performance in different stages of the service delivery chain. It provides real-time metrics for channels, probes, and stages.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                         |
|-----------|------------------------------------------------|
| 1.0.0.x   | Enterprise Edition, Version 2.3 P2, Build 8606 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *3019*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

When the element has been created, do the following to make sure the connector can start polling data:

1. Go to the **General** page.
1. Click the **Login** button.
1. Fill in the **Username** and **Password**.
1. Click the **Connect** button and wait for the **Connection Status** to change to ***Connected***.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

Make sure the **username and password** are filled in as detailed in the Initialization section above, so that the connector can poll data. If these have already been filled in, the connector will automatically attempt to establish a connection when the element is restarted.

On the **Channel Alert** page, you can adjust the maximum number of alerts that is received in a request using the **Channel Alerts Alert Limit** parameter. The default value is 1000 alerts.
