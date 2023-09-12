---
uid: Connector_help_Kantar_Media_SNAP_Watermarking_Monitor
---

# Kantar Media SNAP Watermarking Monitor

This **Watermarking Monitor** is dedicated to the monitoring of SNAP watermarking encoded in audio feeds streamed over IP. It is used to ensure the presence of watermarking in all the audio feeds. It is also used to build a large watermarking monitoring system.

The **Kantar Media SNAP Watermarking Monitor** connector is used to monitor and control the Watermarking Monitor server.

## About

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.2.0.82594270         |

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

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

On the **General** page, fill in the **user name** and **password** and click **Login** so that the client is authenticated on the monitoring server. If the authentication is successful, the connector will be able to retrieve the channel detail data and display this on the Channels page (in the columns to the right of Quality Index Status). If the authentication is not successful, these columns will not be filled in.

On the **Channels** page, you can **create new channels**, **update a channel**, and **delete one or more channels**. To access these features, right-click the **Watermarking Channel Table**. However, note that these features will only work if the client has been successfully authenticated as mentioned above.
