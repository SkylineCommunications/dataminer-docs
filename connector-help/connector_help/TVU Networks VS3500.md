---
uid: Connector_help_TVU_Networks_VS3500
---

# TVU Networks VS3500

The TVU Networks VS3500 is designed to host multiple TVU applications that can accomplish multiple tasks simultaneously, including SDI/IP encoding and decoding, frame-accurate IP video switching, graphics overlay, AI-based closed captioning, storing and forwarding file transfers, and more.

This connector uses the TVU Grid API to communicate with the TVU Networks VS3500 device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**            |
|-----------|-----------------------------------|
| 1.0.0.x   | TVU Grid and Transceiver API v1.3 |

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
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

On the **General** page, specify the **Email**, **Password**, **App Secret**, and **App Key**. When you have done so, click **Get Session**. The connector will then start the polling of information.

### Redundancy

There is no redundancy defined.

## How to use

When the credentials on the **General** page have been correctly configured as detailed in the "Initialization" section above, the connector will poll information to display in the element.

On the **Overview** page, a tree control allows you to navigate through the **Source** and **Destination** devices and view information such as their **Name, Type, Status**, and **URL.**

The **Devices** page contains the same information as the Overview page but in the form of a **Source Table** and **Destination Table.**
