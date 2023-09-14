---
uid: Connector_help_ZTE_ZMC
---

# ZTE ZMC

This connector can be used to integrate the alarms from the ZTE ZMC monitoring platform into DataMiner.

## About

### Version Info

| **Range**            | **Key Features**                      | **Based on** | **System Impact** |
|----------------------|---------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Integrates active and cleared alarms. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | v8.0.50                |

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
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

To start using the element, you need to configure the user credentials to connect to ZMC, and retrieve a user token to poll the alarms.

### Redundancy

There is no redundancy defined.

## How to use

When a valid token is successfully retrieved (after correct user credentials have been specified), the alarms start to be polled automatically every minute.

In case the token expires or the maximum number of requests is reached, a new token request will be triggered automatically to refresh the token. Upon refresh, the alarms will start to be polled again. If the credentials remain valid, this revalidation will only skip one polling cycle.
