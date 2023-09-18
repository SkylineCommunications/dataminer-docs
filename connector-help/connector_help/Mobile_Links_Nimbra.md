---
uid: Connector_help_Mobile_Links_Nimbra
---

# Mobile Links Nimbra

This connector interacts with a custom API developed to use the Nimbra Network as an X-Y router panel and control it via HTTP requests.

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

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

When the element has been created, on the **General** page, specify the **API Secret**.

## How to use

On the **General** page of this connector, you can configure the **API Secret**, and there is also a **Matrix Display** toggle button that allows you to enable or disable the matrix UI of the element.

On the **Sources** and **Destinations** pages, you can find the Sources and Destinations tables, respectively.
