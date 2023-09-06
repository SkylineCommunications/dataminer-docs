---
uid: Connector_help_BBright_UHD-Decode
---

# BBright UHD-Decode

This connector implements the BBright UHD-Decode API. Communication happens via HTTP using JSON format.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                | **Based on** | **System Impact**         |
|----------------------|-----------------------------------------------------------------------------------------------------------------|--------------|---------------------------|
| 1.0.0.x              | Initial version.                                                                                                | \-           | \-                        |
| 1.1.0.x \[SLC Main\] | Added support for ASI interfaces.Changed implementation to accommodate latest firmware response format changes. | 1.0.0.x      | Not backwards compatible. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.0.1.1                |
| 1.1.0.x   | 2.0.4.9                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: Default: *80*.
- **Bus address**: Default: *bypassproxy.*

### Initialization

The API requires the use of a token for authentication. You can get an API token in the **device user interface** by going to the page **ADMIN** \> **Server** and clicking **REST API TOKEN**.

Copy this token to the **Token** parameter on the **General** page of the DataMiner element.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

On the General page, the token used for the communication should be specified. This page also displays other device parameters not related to the channels.

The element contains an overview of the channels in a tree view. It retrieves a list of the channels, as well as information specific to each channel in the list.

The element also allows you to configure the device via the API.
