---
uid: Connector_help_Grass_Valley_iControl_Router_Manager
---

# Grass Valley iControl Router Manager

This protocol allows you to monitor a single **level of a router** present in the **iControl Router Manager**.

The iControl Router Manager is a graphical user interface that provides advanced routing switcher control and status monitoring. It allows you to control multiple routers from different vendors via a single user interface. It provides both matrix and single bus views for maximum flexibility and simplicity, and can be integrated with other devices and applications to offer an end-to-end view of a broadcast environment.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                |
|-----------|---------------------------------------|
| 1.0.0.x   | iControl version 8.10 - REST API v1.0 |

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
- **IP port**: The IP port of the destination (default: *5970*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

For the **matrix** to be polled correctly, you must specify the level that should be monitored in the **Levels** **Table**. As soon as this done, the matrix will be initialized.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The iControl Router Manager can manage several routers. With this connecter, you can monitor only **one single level of a specific router at a time**. If multiple levels need to be monitored, create an element for each level.

You can **switch levels** at any time by selecting the desired level in the **Levels Table**.

## Notes

Currently, the connector is read-only, meaning that any crosspoint sets done on the element will not be reflected on the actual device.
