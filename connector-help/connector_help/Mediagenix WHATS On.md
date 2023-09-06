---
uid: Connector_help_Mediagenix_WHATS_On
---

# Mediagenix WHATS On

The function of this connector is to receive and display data from a Mediagenix WHATS On service. The Mediagenix WHATS On software allows broadcasting and media companies to schedule and manage video and radio streams. The open architecture of the software allows users to define their own communication channel between service and connector, resulting in multiple versions of the connector.

## About

### Version Info

| **Range**            | **Key Features**                                                          | **Based on** | **System Impact** |
|----------------------|---------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.                                                          | \-           | \-                |
| 2.0.0.x \[Obsolete\] | \- Finnish Broadcasting Company branch- Communication through web service | \-           | \-                |
| 2.0.1.x \[Obsolete\] | Support for Unicode characters added.                                     | 2.0.0.4      | \-                |
| 2.0.2.x \[SLC Main\] | Communication through RabbitMQ.                                           | 2.0.1.7      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 2.0.2.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 2.0.2.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection - Main

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

Depending on the connector range, you may need to configure the connection settings on the Configuration page of the element.

### Redundancy

There is no redundancy defined.

## How to use (range 2.0.2.x)

During startup of the element, the connector will start listening to several hardcoded RabbitMQ queues using the connection settings defined in the parameters.Data coming in through these queues is parsed and stored in one of the multiple tables in the connector.

On the Configuration page of this connector, you can configure the connection settings for the RabbitMQ communication.

All other pages contain tables displaying the parsed data received through these RabbitMQ queues.
