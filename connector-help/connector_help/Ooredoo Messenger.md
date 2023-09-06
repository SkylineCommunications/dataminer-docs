---
uid: Connector_help_Ooredoo_Messenger
---

# Ooredoo Messenger

This driver allows you to send test messages to a recipient using the Ooredoo messaging service. Through an HTTP connection, the driver sends GET requests to the Ooredoo messaging service, which allows the user to send SMS messages to a specific phone.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses a HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The address/IP of the Ooredoo messaging service (*messaging.ooredoo.qa*).
- **IP port**: The IP port (default value: *80*).

## How to use

The **General** page is where you can send messages using the Ooredoo service. This page contains the following parameters:

- **SMS Text**: The body of the message to be sent.
- **Recipient Phone Number**: The number of the message destination.
- **Send Message**: Click this button to send the message.
- **Result**: The result from the attempt to send a message.

The **Configuration** page displays the parameters that need to be configured in order to **authenticate** with the Ooredoo messaging service.
