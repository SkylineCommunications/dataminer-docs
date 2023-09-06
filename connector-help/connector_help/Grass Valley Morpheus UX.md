---
uid: Connector_help_Grass_Valley_Morpheus_UX
---

# Grass Valley Morpheus UX

The **Grass Valley Morpheus UX** is a completely configurable user interface, that can be used for the **Morpheus playout automation** and **ICE channel-in-a-box** systems.

This protocol allows you to obtain the base data that is used to generate the user interfaces, and manage basic channel information.

## About

### Version Info

| **Range**           | **Key Features** | **Based on** | **System Impact** |
|---------------------|------------------|--------------|-------------------|
| 1.0.0.x\[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   |                        |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination. Please, include either http:// or https:// in here.
- **IP port**: The IP port of the destination.
- **Device address**: Proxy server location. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

After element creation, specify a valid **User Name**, **Password** and an **Operator Station**, to start polling data from the device. This is available directly in the **General** page.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### General Page

This page is used for configuration only. No extra data for the device is available.

### Operators

This page displays all the **channels** available for the configured **operator**. It also allows the **flag information** for the **operator** to be seen and configured.

### Channels

This page displays all the **channels**, for each of the **systems** associated with the **operator**. It also allows the user to configure said channel information, which includes the **On Air Status**.

### Alarms

This page displays both **unacknowledged** and **acknowledged alarms** on all the systems.

## Notes
