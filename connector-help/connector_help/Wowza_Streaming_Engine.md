---
uid: Connector_help_Wowza_Streaming_Engine
---

# Wowza Streaming Engine

Wowza Streaming Engine is customizable, scalable server software that powers reliable video and audio streaming to any device.

## About

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

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

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The connector requests the list of server applications that are going to be monitored by the element.

In the **Applications** table, you can configure which of the applications should be monitored.

Once an application is enabled, the element will request the information for that application. That information will be displayed in the **Monitored Applications** table, **Connection Count Table** and **Monitoring Historic** table. In case the application is disabled, its information will be removed from the tables.

Note: All applications are enabled for monitoring by default.

In the **Configure Metrics** table, you can customize the name of the metrics in order to have more readable keys. This change is then reflected in the metric name in the **Monitoring Historic** table (in the Metric column).

Note: By default, the name of the metric in the **Monitoring Historic** and **Configure Metrics Table** is the position number of the list that comes from each entry.
