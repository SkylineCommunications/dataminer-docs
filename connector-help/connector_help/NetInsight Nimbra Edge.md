---
uid: Connector_help_NetInsight_Nimbra_Edge
---

# NetInsight Nimbra Edge

This DataMiner connector can be used to retrieve information from a NetInsight Nimbra Edge platform for monitoring purposes. It also allows you to change which input is connected to a specific output.

The HTTP(S) REST API is used to retrieve data from Nimbra Edge.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                |
|-----------|---------------------------------------|
| 1.0.0.x   | R3.9.0, 2022-02-18T14:18:05, 299fd87b |

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
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

When the element has been created, the API username and password need to be configured on the **Configuration** page.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

This connector uses the HTTP RESTful API to communicate with the device/platform. The traffic can be seen in the **Stream Viewer**.

The **General** page shows an overview of the system in a tree view. The root nodes display the appliances. By expanding an appliance, you can drill down to its inputs and outputs.

More detailed information on all the components in the system can be found on the various pages that are implemented in the connector.
