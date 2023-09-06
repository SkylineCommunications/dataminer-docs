---
uid: Connector_help_Sky_UK_Sky_Q_AS
---

# Sky UK Sky Q AS

This connector can be used to manage device apps. The apps can be retrieved, launched, and closed.

## About

### Version Info

| **Range**            | **Key Features**                                           | **Based on** | **System Impact** |
|----------------------|------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | \- Launch and close apps.- Get system state via WebSocket. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

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
- **IP port**: The IP port of the destination. Default: *3600.*
- **Device address**: *BypassProxy*

### Initialization

No additional configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

After the connector has retrieved a list of the available device apps, you can launch and close the apps.
