---
uid: Connector_help_Gracenote_OnAPI_Channel_Schedule_Monitor
---

# Gracenote OnAPI Channel Schedule Monitor

This is a limited SRM-project-specific connector with a limited feature set created on T&M.

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
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection - Main

This connector uses a HyperText Transfer Protocol (HTTP) connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: *http://on-api.gracenote.com*.

HTTP Settings:

- **Port number**: The port of the connected device, by default *443*.
- **Timeout of a single command**: Default value: *10000* ms.

## How to Use

This connector uses HTTP requests to populate tables and parameters within the element.

When you have created the element, configure the following parameters to ensure that the connector can retrieve data:

- **API Key**: Specify your key. If you do not have a key yet, contact your Gracenote representative for your API Key Account.
- **Gracenote ID**: Specify your ID provided by your Gracenote representative.
