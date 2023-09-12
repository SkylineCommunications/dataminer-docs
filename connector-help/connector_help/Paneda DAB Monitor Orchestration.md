---
uid: Connector_help_Paneda_DAB_Monitor_Orchestration
---

# Paneda DAB Monitor Orchestration

The **Paneda DAB Monitor Orchestration** connector can be used to orchestrate and manage Paneda DAB multiplexers and UDP proxies.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                                             |
|-----------|------------------------------------------------------------------------------------|
| 1.0.0.x   | \- Document revision: rev.79 - System version: h-2023-06-29 - Git commit: 61967b0c |

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
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: If the proxy server has to be bypassed, specify *BypassProxy*.

#### HTTP Connection - REDUNDANT

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: If the proxy server has to be bypassed, specify *BypassProxy*.

### Redundancy

This connector supports redundant polling. Because of that, you can configure two connections when creating or editing an element. When one of the connections becomes unavailable, DataMiner will automatically switch to the other connection.

### Initialization

When you have created the element, you need to configure the API authentication token on the **Configuration** page. This so-called "Bearer" token can be created and obtained from the web interface of the device.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

All communication between DataMiner and the device goes over the HTTP REST API. An OpenAPI spec file, which fully describes the API, can be downloaded from the web interface. This file can be imported in tools like Postman for debugging and testing purposes.

### DAB Monitor Page

The **DAB Monitor** page contains a table that lists DAB Monitors. Each row is a combination of the entity and Docker container. DAB monitor entities are the parent structure for DAB monitor containers. The DAB monitor entity is long-lived and remembers important metadata for the more short-lived container.

To create or remove items, use the right-click menus of the tables. Entities can only be removed when the corresponding container is already removed.

When you create a new DAB monitor container, you can configure multiple sources in the source list by separating them with a comma, as shown in the following screenshot:

![image](~/connector-help/images/Paneda_DAB_Monitor_Orchestration_image.png)

### UDP Proxies Page

The **UDP Proxies** page contains a table with all configured UDP proxies. The same distinction between entity and encoder also exists here.

Configuring UDP proxies works in the same way as configuring DAB Monitors (see above).

### Network Page

The **Network** page provides a list of all available (VLAN) networks on the device. These networks can be assigned to an UDP proxy.
