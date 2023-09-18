---
uid: Connector_help_LTN_Transport_Portal
---

# LTN Transport Portal

The LTN transport portal is a platform for live video transmission solutions. It uses a global network of Points of Presence (PoPs) to ensure efficient and low-latency video delivery. With intelligent adaptive bit rate (ABR) encoding and dynamic stream routing, it optimizes video quality and routing paths based on real-time network conditions.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

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
- **IP port**: The IP port of the destination.
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

When the element has been created, specify the username, password, and API key to establish a connection with the portal. You will need to request an API key from the vendor.

## How to use

After you have configured the credentials, and the connector has obtained the token, the connector will send requests to retrieve the endpoints, bookings, and distribution groups every minute.
