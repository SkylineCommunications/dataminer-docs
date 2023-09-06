---
uid: Connector_help_TM_Forum_Service_Problem_Management
---

# TM Forum Service Problem Management

The Service Problem Management API is used to manage service problems. Service problems are generated based on information provided by a partner or based on event information provided by infrastructure providers. The event information includes alarm information, performance anomaly information, trouble ticket information, SLA violations, maintenance information, and prediction information.

## About

### Version Info

| **Range**            | **Key Features**                                                           | **Based on** | **System Impact** |
|----------------------|----------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version.This is a customer-specific branch with custom attributes. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | TMF656                 |

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
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

To initialize the connector, go to the **Configuration** page of the element, and fill in the **API Base Path**, **Username**, and **Password** parameters.

### Redundancy

There is no redundancy defined.

## How to use

This connector synchronizes tickets between DataMiner Ticketing and SNOW.

On the **General** page of this connector, you can see a table listing all the managed tickets.

The **Configuration** page contains basic configurable information such as the **Ticket Synchronization State**, which allows you to enable or disable ticket synchronization, and the **Ticket Synchronization Frequency**, which determines how much time there is between each synchronization interval. This page also contains the **API Base Path**, **Username**, and **Password** parameters needed for the element initialization.

## Notes

For this connector to work, the DMS needs to have a **DataMiner Ticketing license**.
