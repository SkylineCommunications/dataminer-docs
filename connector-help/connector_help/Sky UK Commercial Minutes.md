---
uid: Connector_help_Sky_UK_Commercial_Minutes
---

# Sky UK Commercial Minutes

This driver is mainly intended to display alarms and commercial minutes.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | /                      |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main connection

This driver uses an HTTP connection and requires the following input during element creation.

HTTP CONNECTION:

- **IP address/host**: The pooling IP of the device, e.g. *bcam.broadcast.bskyb.com.*
- **IP port**: The IP port of the device, e.g. *80.*
- **Bus address**: This should consist of a combination of the node/device name, the BUS value representing the channel, and the channel type (Standard, Entertainment or Sports). If the proxy server has to be bypassed, also specify *BypassProxy*.For example: *ByPassProxy;NodeName/DeviceName;Bus;ChannelType*

## How to Use

This driver dynamically creates an HTTP address to obtain information through a JSON configuration. When you configure the element, make sure to specify the node/device in the bus address field as mentioned above, so that the driver creates the address for the specified device.

On the **Device Status** page, you can view alarms for **VICC File Age**, **Status** and **Commercial Minutes**. The page also shows the total minutes and frames during different time slots.
