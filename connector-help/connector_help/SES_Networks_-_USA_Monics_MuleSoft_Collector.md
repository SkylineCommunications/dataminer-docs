---
uid: Connector_help_SES_Networks_-_USA_Monics_MuleSoft_Collector
---

# SES Networks - USA Monics MuleSoft Collector

This DataMiner connector can be used to retrieve carrier measurements from the SES Monics MuleSoft platform.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**    |
|-----------|---------------------------|
| 1.0.0.x   | REST API, version unknown |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination, i.e. *[https://api.ses.com](https://api.ses.com/)*.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

After a new element has been created using this connector, the API username and password must be configured on the **Configuration** page.

### Redundancy

There is no redundancy defined.

## How to use

REST API calls are used to retrieve data from the MuleSoft Monics platform.

When the specified API credentials are correct and the API is accessible, all data is shown on the **General** data page.
