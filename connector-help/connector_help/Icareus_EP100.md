---
uid: Connector_help_Icareus_EP100
---

# Icareus EP100

The Icareus EPG platform is used by broadcasters and network operators to manage multi-platform EPG on a single integrated platform. It generates all the PSI/SI and EIT tables needed for premium DVB networks or to serve the IPTV/OTT middleware platform.

In the 1.0.0.x range, this connector uses a serial connection to communicate with the device to retrieve important KPIs. In range 1.1.0.x, an SNMP connection is used instead.

## About

### Version Info

| **Range**            | **Key Features**                                        | **Based on** | **System Impact**                                                                         |
|----------------------|---------------------------------------------------------|--------------|-------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version.                                        | \-           | \-                                                                                        |
| 1.1.0.x \[SLC Main\] | Changed from a serial connection to an SNMP connection. | 1.0.0.3      | Existing elements need to be reconfigured before the new connection will be taken in use. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.1.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Connection - range 1.0.0.x only

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination. **Default port: 22.**

#### SNMP Connection - range 1.1.0.x and later

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination. **Default port: 161.**
- **Bus address**: The bus address of the device.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No additional configuration is necessary to create a new element.

### Redundancy

There is no redundancy defined.

## How to use

When the element is polling the data, you can check the status information on the General page.
