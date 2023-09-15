---
uid: Connector_help_Sky_UK_Pin_Validation
---

# Sky UK Pin Validation

This connector can be used in order to check if there is **PIN protection** for a service and to know the status of the encryption.

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
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main connection

This connector uses an HTTP connection and requires the following input during element creation.

HTTP CONNECTION:

- **IP address/host**: The pooling IP of the device, e.g. *bcam.broadcast.bskyb.com.*
- **IP port**: The IP port of the device, e.g. *80.*
- **Bus address**: This should consist of a combination of the node/device name and the BUS value representing a service name. If the proxy server has to be bypassed, also specify *BypassProxy*.
  For example: *ByPassProxy;NodeName/DeviceName;BusAddress;*

## How to Use

This connector dynamically creates an HTTP address to obtain information through a JSON configuration. When you configure the element, make sure to specify the node/device in the bus address field as mentioned above, so that the connector creates the address for the specified device.

On the **Pin Status** page, you can find the following information: Last Checked Time, PIN Protection, PIN Unexpectedly Present and Service Encryption Status.
