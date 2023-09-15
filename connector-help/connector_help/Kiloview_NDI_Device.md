---
uid: Connector_help_Kiloview_NDI_Device
---

# Kiloview NDI Device

This connector communicates with Kiloview NDI device via the NDI device HTTP API. It displays data of the device and allows users to manage and control embedded Kiloview NDI encoder and decoder devices by sending HTTP requests.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.50                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection - Main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Initialization

When the element has been created in DataMiner, enter the username and password on the **General** page and click the **Login** button.

### Redundancy

No redundancy is defined in the connector.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

On the **General** page, you can specify the login credentials, as mentioned above. This page also shows the current working mode of the device (encoder or decoder) and allows you to change this working mode. Data related to the working status of the device is also displayed.

On the **Maintenance Actions** subpage, you can reboot the device, reset all NDI connections, and restore factory setting. The **Network Configuration** subpage displays the Network Interface Configuration table.

If the device works in encoder mode, an **Encoding status** page is available with data related to the encoder. Otherwise, a decoder-related data page, **Decoding status**, is available, along with subpages listing the discovered sources and presets.

The connector adds entries by parsing an **HTTP** response.
