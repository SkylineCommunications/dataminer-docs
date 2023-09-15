---
uid: Connector_help_Coralbay_TV_Platform
---

# Coralbay TV Platform

The Coralbay TV Platform playout software is designed to work in the cloud but can also run on standard PCs. It provides an automation control interface and video pipeline, delivering video and audio in a variety of output formats.

This connector can be used to monitor the platform via an HTTP connection.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | API v1                 |

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
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

For the connector to be able to poll information from the API, you need to fill in the **Client ID** and **Client Secret** on the **Authentication** page of the element.

As the **Authentication URL** can be changed in the device, this can also be configured on the Authentication page.

### Redundancy

There is no redundancy defined.

## How to use

On the General page, you can see information about the **partitions**. Information regarding **channels**, **pipelines**, **asset locations** and **missing events** is also available.
