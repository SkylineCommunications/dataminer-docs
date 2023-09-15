---
uid: Connector_help_EVS_IPD-VIA
---

# EVS IPD-VIA

The EVS IPD-VIA connector is used to collect data from the EVS IPD-VIA API and integrates with the **RabbitMQ** queues to get live updates.

**IPD-VIA** is the web-based asset management component of EVS's VIA ecosystem, which allows access to and management, editing, and sharing of live production assets.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | RabbitMQ 3.8.5         |

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

The element will only start requesting data via the **API** once the **user name** and **password** have been configured. These need to be configured on the **Configuration** page.

The **Configuration** page also contains all the required configuration parameters to set up the connection with the **RabbitMQ** queues.

A **Status** parameter is available both for the API and the RabbitMQ connection to indicate if the connection was successful using the provided details.

## How to use

The current version is mainly intended to monitor and create recording sessions.

The **Recording Sessions** table on the **General** page contains an overview of all the ongoing and future recording sessions and their targets. Recording sessions are automatically removed from the element after a configurable time. The element will regularly retrieve recording sessions through the API, and it will also subscribe to the recording session queue (RabbitMQ) to receive updates immediately.

The different available recorders and targets are also retrieved using the API.

### InterApp

Recording sessions can be created, updated, and removed using the InterApp framework. This means there is no functionality to create recording sessions directly using the element card, but a dedicated script can be created to do so. The required DLLs to construct the messages are installed in the DataMiner System with the connector.

When a message is received, it will send the required API requests towards EVS IPD-VIA, and the response will be sent to the original source of the InterApp message.

## Notes

Currently, the connector only supports subscriptions to the RabbitMQ "**recording-session**" queue.
