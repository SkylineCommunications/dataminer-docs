---
uid: Connector_help_Dolby_DP591
---

# Dolby DP591

The Dolby DP591 is an audio encoder that can be used to encode PCM audio stems and metadata to Dolby ED2 or Dolby Digital Plus with Dolby Atmos, transcode Dolby E/Dolby ED2 streams to Dolby Digital Plus/Dolby Digital Plus with Atmos, and decode Dolby ED2 content to its original PCM channels.

This driver allows you to monitor and manage this product.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.9.1.6                |

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
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

Most of the sets in the driver do not have data in the response, which means that the Stream Viewer application will show a "204 No Content" status response. This response indicates that the set request succeeded, even though no data is returned from the device in response. The driver retrieves the corresponding read value by polling the updated values, so that the updated value is displayed instantly.
