---
uid: Connector_help_Ateme_Titan_Recorder
---

# Ateme Titan Recorder

TITAN Recorder is a powerful, flexible, and reliable stream-delay solution that can adapt to a wide range of ecosystems and with secure 24/7 service.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | API version 6.5.0      |

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
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

When you have created the element, set the credentials of the device on the **General** page.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element displays the available information of the device on the following pages: **General**, **Recorders**, **Delay Lines**, and **Alarms/Events**.

On the **Polling page**, you can configure the polling of the parameters.
