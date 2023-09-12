---
uid: Connector_help_Paneda_Mux_Orchestration
---

# Paneda Mux Orchestration

The **Paneda Mux Orchestration** connector can be used to orchestrate and manage Paneda multiplexers.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

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

The **Muxes** page contains a table that lists the current muxes that are configured on the system. Mux entities are the parent structure for mux containers. The mux entity is long-lived and remembers important metadata for the more short-lived mux container. Entities and Docker containers are combined in the same table.

To create or remove items, use the right-click menus of the tables. Entities can only be removed when the corresponding container is already removed.

When you create a new mux, you can assign multiple network interfaces and static routes. To do so, separate the values with a comma (,) as shown in the following screenshot:

![image](~/connector-help/images/Paneda_Mux_Orchestration_image.png)
