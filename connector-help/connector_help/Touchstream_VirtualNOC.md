---
uid: Connector_help_Touchstream_VirtualNOC
---

# Touchstream VirtualNOC

Touchstream VirtualNOC is a driver used to communicate with the Touchstream API. The virtualNOC is an end-to-end monitoring solution that collects data from all endpoints of the video delivery chain and monitors it 24/7. This allows operators to visualize issues clearly and take action before these affect viewers.

## About

### Version Info

| **Range**            | **Key Features**                        | **Based on** | **System Impact** |
|----------------------|-----------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Implemented detailed stream status API. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | V6.0                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

### Connections

#### HTTP Main Connection

This driver uses an HTTPS connection to communicate with the Touchstream API.

HTTP CONNECTION:

- **IP address/host**: E.g. [https://tse.touchstream.global](https://tse.touchstream.global/)
- **IP port**: The IP port of the destination (default: *443*).

### Initialization

The driver requires an **API Key** (X-TS-ID header) and a **Bearer Key** (oauth Authorization header) in order to start the polling. These should be specified on the **General** page.
When this information has been added, the **Connection State** is "OK" if the device replies with "*HTTP/1.1 200 OK"* or "Error" for other HTTP responses.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

When the necessary credentials have been specified as detailed above, the tables of the element will be filled in.

To get an overview of all available streams, you can use the tree control.
