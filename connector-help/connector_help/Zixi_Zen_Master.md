---
uid: Connector_help_Zixi_Zen_Master
---

# Zixi Zen Master

The Zixi Zen Master is a platform to monitor and control live video orchestration and telemetry. It provides a centralized overview of the Zixi devices.

## About

### Version Info

| **Range**            | **Key Features**                                             | **Based on** | **System Impact**                                                  |
|----------------------|--------------------------------------------------------------|--------------|--------------------------------------------------------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                                             | \-           | \-                                                                 |
| 1.0.1.x              | DCF interfaces enabled.                                      | 1.0.0.1      | DCF interfaces are now available for this cpnnector.               |
| 1.1.0.x              | DCF interfaces enabled. Supports Zixi Zen API version 1.0.0. | 1.0.1.4      | Table modifications have been implemented to adapt to the new API. |
| 1.1.1.x \[SLC Main\] | DCF interfaces enabled. Supports Zixi Zen API version 1.0.0. | 1.1.0.6      | General status parameters are now discrete strings.                |

### Product Info

| **Range** | **Supported Firmware**    |
|-----------|---------------------------|
| 1.0.0.x   | 2019 c Zixi LLC.          |
| 1.0.1.x   | 2019 c Zixi LLC.          |
| 1.1.0.x   | Software version 22.06.01 |
| 1.1.1.x   | Software version 22.06.01 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.1.1.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

Before the API can be polled, you need to specify the **Username** and **Password** on the **Configuration** page. With the **Connect** button, you can enforce the connection setup.

### Redundancy

There is no redundancy defined.

## How to use

The first pages display **Broadcasters**, **Feeders**, and **Receivers** in a tree view.

The remaining pages (**Channels**, **Targets**, **Sources**, and **Events**) display information in a table.
