---
uid: Connector_help_Globecast_GCMCN_Platform
---

# Globecast GCMCN Platform

This DataMiner connector can be used to retrieve information from a Globecast GCMCN channel supervision platform for monitoring purposes.

An HTTP(S) REST API is used to retrieve data from the platform.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

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

#### HTTP Connection - Main

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443, HTTPS*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

When the element has been created, the API token needs to be configured on the **Configuration** page.

On the same page, you can also configure whether finished channels should be displayed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

This connector uses the HTTP RESTful API to communicate with the platform. The traffic can be seen in the **Stream Viewer**.

The **Overview** page shows an overview of the system in a tree view. The root nodes display the entities. By expanding an entity, you can drill down to its channels.

More detailed information on all the components in the system can be found on the various pages that are implemented in the connector.
