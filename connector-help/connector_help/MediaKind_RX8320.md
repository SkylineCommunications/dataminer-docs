---
uid: Connector_help_MediaKind_RX8320
---

# MediaKind RX8320

This is an SNMP connector that shows the status of the different parameters of the MediaKind RX8320 IRD (Integrated Receiver Decoder).

The MediaKind RX8320 is a very versatile piece of equipment. It comes in many different configurations, with input options varying between satellite and ASI, and output options including ASI, satellite, and IP.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**     |
|-----------|----------------------------|
| 1.0.0.x   | SW Version 8.36.1 (Bank 1) |

### Version Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The connector uses SNMP retrieval to poll all of its parameters.

The **Status page** gives an overview of the main parameters from the other pages, so that you can find the most important status information summarized on this page.

The **Alarms** **page** contains the main parameters for monitoring.

The connector mirrors the web UI of the device, with the exception of a few parameters that were not exposed via SNMP in the initial development.

**Traps are not yet implemented in this initial version.**
