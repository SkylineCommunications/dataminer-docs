---
uid: Connector_help_Forzasys_Telenor_Norway_AS_API
---

# Forzasys Telenor Norway AS API

The **Forzasys Telenor Norway AS API** interfaces with an external API to list current match details and system metrics.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                   |
|-----------|----------------------------------------------------------|
| 1.0.0.x   | Initial API version from Forzasys. No API version known. |

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
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

In case the API requires authorization, please enter the **HTTP X-IBM-Client-ID** and **HTTP Authenticate Token** (this is a fixed permanent token) on the **Configurations** page along with the **HTTP URL**.

### Redundancy

There is no redundancy defined.

## How to use

On the General page you can find the current responsible person via the **On Call Name** and the **On Call Telephone Number**. All **Matches** are listed in a table.

Additional metrics and info are available on the **System Metrics** page.
