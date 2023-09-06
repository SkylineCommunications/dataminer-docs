---
uid: Connector_help_InfluxData_InfluxDB_Collector
---

# InfluxData InfluxDB Collector

This connector is able to query databases through HTTP connections and retrieve the responses. Queries can be added, removed, or duplicated. Their details, such as names, definition, and execution frequency can also be altered. The responses of these queries are then sent to target elements, which are also configurable.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

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
- **Device address**: If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

On the **General** page, specify the database to query and the credentials to access it.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this connector consists of the following data pages:

- **General**: Allows you to configure the necessary information to execute queries.
- **Queries:** Lets you manage active queries and delete or duplicate existing ones. You can also add new queries.

## Notes

Further child elements developed to communicate with elements created with this connector need to configure their query response receiving parameter with ID 50.
