---
uid: Connector_help_Factum_MULTIMUXA
---

# Factum MULTIMUXA

Factum MULTIMUXA is an encoding, multiplexing, and management system for digital radio signals, which includes small-scale DAB.

## About

### Version Info

| **Range**            | **Key Features**                                                   | **Based on** | **System Impact** |
|----------------------|--------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version: Controller, Encoder, Data Server and Multiplexer. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The IP address of the device, prefixed with "*https://*" if the port is not 443.
- **IP port**: 5002

### Initialization

To make sure the element can log in to the device, fill in the credentials on the **Credentials** page of the element.

### Redundancy

There is no redundancy defined.

## How to use

On the **API Command** page, you can execute any API command from the documentation. To do so, fill in the method and URL in the URL field, and add the body of the command in the content field.

On the **General** page, you can find general information about the controller.

The other pages contain details about the Encoder, Data Server, and Multiplexer.
