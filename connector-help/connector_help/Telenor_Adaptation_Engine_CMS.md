---
uid: Connector_help_Telenor_Adaptation_Engine_CMS
---

# Telenor Adaptation Engine CMS

The **Telenor Adaptation Engine CMS** driver is used to retrieve the list of assets and assets providers available on the Telenor system and export those as CSV files.

The list of assets and assets providers is retrieved from an HTTP server.

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

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Device address**: If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

To be able to communicate with the HTTP server, the **API Key** must be filled in on the **General** page.

You can also specify the folder where the CSV files will be exported on the **General** page.

The **Providers** page contains a table displaying all the providers.

The **Assets** page contains a table displaying all the assets. As there can be a large number of assets, this table is not filled in by default. To have it filled in, set the toggle button **Assets Display** to *Enabled.*
